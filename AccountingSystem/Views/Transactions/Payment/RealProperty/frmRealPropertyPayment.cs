using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using Microsoft.Reporting.WinForms;
using RPT.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    public partial class frmRealPropertyPayment : Form
    {
        private ucRealPropertyTaxPayment ucPaymentInfo;
        private readonly MainForm _mainForm;
        internal List<RptTaxDuesModel> rptTaxDuesModels;
        internal bool isReadonly = false;
        internal rptPropertyPaymentTaxPayerInfoModel paymentTaxPayerInfoModel;

        public frmRealPropertyPayment(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            ucPaymentInfo = ucPropertyTaxPayment1;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void LoadSelectedDetailedTaxDues(List<RptDetailedTaxDuesModel> realPropertyPaymentTaxDueModels, int paymentPostsId)
        {
            try
            {

                var dictViewPaymentPost = AccFactory.RptPaymentPostsRepository().GetViewRecordById(paymentPostsId);

                string payee = dictViewPaymentPost["payment_collections_payee"];
                DateTime paymentDate = Convert.ToDateTime(dictViewPaymentPost["payment_collections_payment_date"]);
                string receiptNo = dictViewPaymentPost["payment_collections_receipt_no"];
                int collectingOfficerId = Convert.ToInt32(dictViewPaymentPost["payment_collections_collecting_officers_id"]);
                string jobOrderId = dictViewPaymentPost["payment_collections_job_orders_id"];

                ucPaymentInfo.txtPayee.Text = payee;
                ucPaymentInfo.dtPaymentDate.Value = paymentDate;
                ucPaymentInfo.txtReceipts.Text = receiptNo;

                ucPaymentInfo.LoadCollectorInfoById(collectingOfficerId, jobOrderId);         
                FormIsReadOnly(true);

                LoadRptDetailedTaxDues(realPropertyPaymentTaxDueModels);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private DataTable RealPropertyPaymentTaxDuesDataTable(List<RptDetailedTaxDuesModel> realPropertyPaymentTaxDueModelList)
        {
            var dataTable = new DataTable();

            //Set up data columns
            var columns = new DataColumn[]
            {
                new DataColumn("assessment_post_id", typeof(int)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("tax_type", typeof(string)),
                new DataColumn("tax_due", typeof(decimal)),
                new DataColumn("discount", typeof(decimal)),
                new DataColumn("penalty", typeof(decimal)),
                new DataColumn("total_sef_basic", typeof(decimal))
            };
            dataTable.Columns.AddRange(columns);

            //Populate data table
            if (realPropertyPaymentTaxDueModelList != null)
            {
                foreach (RptDetailedTaxDuesModel model in realPropertyPaymentTaxDueModelList)
                {
                    var newRow = dataTable.NewRow();
                    newRow["assessment_post_id"] = model.AssessmentPostId;
                    newRow["year"] = model.Year;
                    newRow["complete_arp_no"] = model.CompleteArpNo;
                    newRow["tax_type"] = model.TaxType;
                    newRow["tax_due"] = model.TaxDue;
                    newRow["discount"] = model.Discount;
                    newRow["penalty"] = model.Penalty;
                    newRow["total_sef_basic"] = model.TotalTaxDue;

                    dataTable.Rows.Add(newRow);
                }
            }

            return dataTable;
        }

        private decimal GetTotalDue(DataGridView dataGridView)
        {
            decimal totalDue = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalDue += Convert.ToDecimal(row.Cells["total_sef_basic"].Value);
            }

            return totalDue;
        }

        internal void LoadRptDetailedTaxDues(List<RptDetailedTaxDuesModel> realPropertyPaymentTaxDueModelList)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                HelperLoadRecords.PropertyPaymentPropertiesTaxDuesDatagridView(RealPropertyPaymentTaxDuesDataTable(realPropertyPaymentTaxDueModelList), dataGridView1);
                txtTotalDue.Text = GetTotalDue(dataGridView1).ToString("N2");
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                Cursor = Cursors.Default;
            }
        }

        internal void GetSelectedTaxPayerInfo()
        {
            txtTin.Text = paymentTaxPayerInfoModel.TIN;
            txtTaxpayer.Text = paymentTaxPayerInfoModel.TaxPayerName;
            txtBarangay.Text = paymentTaxPayerInfoModel.BarangayName;
            txtMunicipality.Text = paymentTaxPayerInfoModel.MunicipalityName;
            txtProvince.Text = paymentTaxPayerInfoModel.ProvinceName;
            txtAddress.Text = paymentTaxPayerInfoModel.Address;
            btnGetTaxDue.Enabled = true;
            btnPaymentHistory.Enabled = true;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            string taxPayerName = txtTaxpayer.Text.Trim();
            _ = new frmTaxPayerPaymentHistory(this, taxPayerName).ShowDialog();
        }

        private void frmPaymentPosting_Load(object sender, EventArgs e)
        {
            LoadRptDetailedTaxDues(null);
        }

        private void btnFindTaxPayer_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayerList(null, null, null, this, null).ShowDialog();
            LoadRptDetailedTaxDues(null);
        }

        private void ShowTaxDue()
        {
            string taxPayerName = txtTaxpayer.Text.Trim();

            _ = new frmPropertyTaxDue(taxPayerName, this).ShowDialog();
        }

        private void btnGetTaxDue_Click(object sender, EventArgs e)
        {
            ShowTaxDue();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormIsReadOnly(false);
        }

        #region Cancel Transaction Methods

        internal void CancelTransaction()
        {
            LoadRptDetailedTaxDues(null);
            ucPaymentInfo.ResetForm();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            CancelTransaction();
        }

        #endregion

        #region Payment Methods

        private bool PrintReceipt() 
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;   
                var localReport = new LocalReport();
                var dictLguDetails = Helper.LGUDetails();
                var amountToWords = new Helper.AmountToWords();
                string amount = txtTotalDue.Text.Trim();

                var parameters = new[]
                {
                new ReportParameter("paramMunicipality", dictLguDetails["lgu_name"]),
                new ReportParameter("paramReceiptNo", ucPaymentInfo.txtReceipts.Text.Trim()),
                new ReportParameter("paramPaymentDate", ucPaymentInfo.dtPaymentDate.Value.ToString()),
                new ReportParameter("paramAmount", amount),
                new ReportParameter("paramPayee", ucPaymentInfo.txtPayee.Text.Trim()),
                new ReportParameter("paramCollectorName", ucPaymentInfo.txtCollectingOfficer.Text.Trim()),
                new ReportParameter("paramAmountInWord", amountToWords.ConvertAmountToWords(amount))
                };            

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\real-property-payment-receipt.rdlc";
                localReport.SetParameters(parameters);

                //Set page settings for receipt printing
                var localReportDefaultSetting = localReport.GetDefaultPageSettings();
                var pageSettings = new PageSettings();
                pageSettings.PaperSize = localReportDefaultSetting.PaperSize;

                Helper.PrintToPrinter(localReport, pageSettings);
                Helper.DisposePrintToPrinter();
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            Cursor.Current = Cursors.Default;
            return false;       
        }

        private bool ValidatePayment()
        {
            decimal totalDue = Convert.ToDecimal(txtTotalDue.Text);

            if (totalDue == 0)
                return false;

            return true;
        }

        private bool SavePayment() 
        {
            try
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(ucPaymentInfo.GetFormErrors());
                    return false;
                }

                if(!Helper.MessageBoxConfirmCancel("Confirm Payment?"))
                    return false;

                //Payment Collections
                int accountableFormId = ucPaymentInfo.accountableFormNoId;
                decimal amount = Convert.ToDecimal(txtTotalDue.Text.Trim());
                string receiptNo = ucPaymentInfo.txtReceipts.Text.Trim();
                string payee = ucPaymentInfo.txtPayee.Text.Trim();
                DateTime paymentDate = ucPaymentInfo.dtPaymentDate.Value;
                var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);
                var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId);
                int collectingOfficerId = dictCollectingOfficer.Values.Count < 1 ? 0 : Convert.ToInt32(dictCollectingOfficer["id"]);
                int? jobOrderId = dictJobOrder.Values.Count < 1 ? null : Convert.ToInt32(dictJobOrder["id"]);

                var paymentCollectionsModel = new PaymentCollectionsModel()
                {
                    AccountableFormId = accountableFormId,
                    CollectingOfficerId = collectingOfficerId,
                    JobOrderId = jobOrderId,
                    Amount = amount,
                    FundId = 1,
                    ReceiptNo = receiptNo,
                    Payee = payee,
                    PaymentDate = paymentDate,
                    IsCancelled = false,
                    CreatedBy = Helper.UserId
                };

                var rptPaymentPostsModel = new RptPaymentPostsModel()
                {
                    PostedBy = Helper.UserId
                };

                return AccFactory.PaymentCollectionsRepository().InsertWithPaymentPosts(paymentCollectionsModel, rptPaymentPostsModel, rptTaxDuesModels);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (SavePayment())
            {
                PrintReceipt();
                Helper.MessageBoxSuccess("Payment Confirmed.");
                LoadRptDetailedTaxDues(null);
                rptTaxDuesModels.Clear();
                ucPaymentInfo.ResetForm();
            }   
        }

        #endregion

        private void FormIsReadOnly(bool isReadOnly) 
        {
            ucPaymentInfo.isReadOnly = isReadOnly;
            isReadonly = isReadOnly;
            btnGetTaxDue.Enabled = !isReadOnly;
            btnPay.Enabled = !isReadOnly;
            btnPay.Text = "Paid";
            ucPaymentInfo.txtReceipts.ReadOnly = isReadOnly;
            ucPaymentInfo.txtPayee.ReadOnly = isReadOnly;
            btnCancelTransaction.Enabled = !isReadOnly;
            ucPaymentInfo.dtPaymentDate.Enabled = !isReadOnly;
            btnNew.Enabled = isReadOnly;

            if (!isReadOnly)
            {
                LoadRptDetailedTaxDues(null);
                EnableDisablePayCancelTransButton(btnPay, btnCancelTransaction);
                btnPay.Text = "Pay";
                ucPaymentInfo.LoadCollectorInfoByUserId();
                ucPaymentInfo.loadReceiptNos();
                ucPaymentInfo.txtPayee.Clear();
                ucPaymentInfo.dtPaymentDate.Value = Helper.GetCurrentDate();
            }
        }

        private void EnableDisablePayCancelTransButton(Button btnPay, Button btnCancel) 
        {
            if (isReadonly || !ValidatePayment())
            {
                btnPay.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                btnPay.Enabled = true;
                btnCancel.Enabled = true;
            }

        }

        private void txtTotalDue_TextChanged(object sender, EventArgs e)
        {
            EnableDisablePayCancelTransButton(btnPay, btnCancelTransaction);
        }
    }
}
