using AccountingSystem.Views.Shared;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using Microsoft.Reporting.WinForms;
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
using static AccountingSystem.Views.Transactions.PaymentPosting.frmPayments;

namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    public partial class frmTaxPayerPaymentHistory : Form
    {
        private readonly frmPayments _frmRealPropertyPayment;
        private readonly string _taxPayerName;

        public frmTaxPayerPaymentHistory(frmPayments frmPaymentPosting, string TaxPayerName)
        {
            InitializeComponent();
            _frmRealPropertyPayment = frmPaymentPosting;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            _taxPayerName = TaxPayerName;
        }

        private void LoadPaymentHistory()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var dateFrom = dtPckDateFrom.Value;
                var dateTo = dtPckDateTo.Value;

                var dtPaymentPosts = AccFactory.RptPaymentPostsRepository().GetViewRecordsByDateTaxPayerName(dateFrom, dateTo, _taxPayerName);
                HelperLoadRecords.PaymentHistoryDataGridView(dataGridView1, dtPaymentPosts);
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmTaxPayerPaymentHistory_Load(object sender, EventArgs e)
        {
            dtPckDateFrom.Value = new DateTime(dtPckDateFrom.Value.Year, dtPckDateFrom.Value.Month, 1);
            LoadPaymentHistory();
            EnableDisableButtons(btnPrintReceipt, btnSelect);
        }

        private void dtPckDateFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        }

        private void dtPckDateTo_ValueChanged(object sender, EventArgs e)
        {
            LoadPaymentHistory();
        } 

        private void EnableDisableButtons(ToolStripButton btnPrintRecieipt, Button btnSelect)
        {
            int selectedRowCount = dataGridView1.SelectedRows.Count;

            if(selectedRowCount == 0 || selectedRowCount > 1)
            {
                btnPrintRecieipt.Enabled = false;
                btnSelect.Enabled = false;
            }
            else
            {
                btnPrintRecieipt.Enabled = true;
                btnSelect.Enabled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons(btnPrintReceipt, btnSelect);
        }

        #region Get Selected Detailed Tax Dues

        private List<RptDetailedTaxDuesModel> GetSelectedDetailedTaxDues(int paymentPostId)
        {
            var list = new List<RptDetailedTaxDuesModel>();

            var dtRptTaxDues = AccFactory.RptTaxDuesRepository().GetViewRecordsByRptPaymentPostsId(paymentPostId);

            foreach (DataRow row in dtRptTaxDues.Rows)
            {

                int assessmentPostId = Convert.ToInt32(row["rpt_assessment_posts_id"]);
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                DateTime rowAssessmentPostsDate = Convert.ToDateTime(row["posted_at"]);
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                int rowAssessmentYear = Convert.ToInt32(row["year"]);
                int rowEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                int rowEffectivityQuarter = Convert.ToInt32(row["effectivity_quarterly"]);
                DateTime rowPaymentPostedDate = Convert.ToDateTime(row["rpt_payment_posts_posted_at"]);

                #region Tax Due

                decimal basicRate = Convert.ToDecimal(row["basic_rate"]);
                decimal sefRate = Convert.ToDecimal(row["sef_rate"]);
                decimal basicTaxDueAmount = RealPropertyTaxComputations.GetBasicTaxDue(basicRate, rowAssessedValue);
                decimal sefTaxDueAmount = RealPropertyTaxComputations.GetSefTaxDue(sefRate, rowAssessedValue);

                #endregion

                #region Discount

                bool discountIsAdvance = Convert.ToBoolean(row["is_advance"]);
                decimal discountRate = Convert.ToDecimal(row["discount_rate"]);

                decimal basicDiscountAmount = RealPropertyTaxComputations.GetDiscount(discountRate, basicTaxDueAmount);
                decimal sefDiscountAmount = RealPropertyTaxComputations.GetDiscount(discountRate, sefTaxDueAmount);

                #endregion

                #region  Penalty

                int previousAssessmentCount = AccFactory.RptAssessmentPostsRepository().PreviousAssessmentPostCount(rowCompleteArpNo, rowAssessmentYear);
                int delinquentMonths = RealPropertyTaxComputations.GetSelectedMonthsDelinquent(rowAssessmentYear, rowAssessmentPostsDate, rowPaymentPostedDate, rowEffectivityYear, previousAssessmentCount);
                decimal penaltyRate = Convert.ToDecimal(row["penalty_rate"]);


                decimal basicPenaltyAmount = RealPropertyTaxComputations.GetPenalty(penaltyRate, delinquentMonths, basicTaxDueAmount);
                decimal sefPenaltyAmount = RealPropertyTaxComputations.GetPenalty(penaltyRate, delinquentMonths, sefTaxDueAmount);

                #endregion

                #region Total TaxDue

                decimal totalBasicTaxDue = (basicTaxDueAmount + basicPenaltyAmount) - basicDiscountAmount;
                decimal totalSefTaxDue = (sefTaxDueAmount + sefPenaltyAmount) - sefDiscountAmount;

                #endregion

                var basicModel = new RptDetailedTaxDuesModel()
                {
                    AssessmentPostId = assessmentPostId,
                    Year = rowAssessmentYear,
                    CompleteArpNo = rowCompleteArpNo,
                    TaxType = "Basic",
                    TaxDue = basicTaxDueAmount,
                    Discount = basicDiscountAmount,
                    Penalty = basicPenaltyAmount,
                    TotalTaxDue = totalBasicTaxDue
                };

                var sefModel = new RptDetailedTaxDuesModel()
                {
                    AssessmentPostId = assessmentPostId,
                    Year = rowAssessmentYear,
                    CompleteArpNo = rowCompleteArpNo,
                    TaxType = "SEF",
                    TaxDue = sefTaxDueAmount,
                    Discount = sefDiscountAmount,
                    Penalty = sefPenaltyAmount,
                    TotalTaxDue = totalSefTaxDue
                }; 

                list.Add(basicModel);
                list.Add(sefModel);
            }

            return list;
        }

        private void LoadSelectedDetailedTaxDues()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            int paymentPostsId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["rpt_payment_posts_id"].Value);

            _frmRealPropertyPayment.CancelTransaction();
            _frmRealPropertyPayment.LoadSelectedDetailedTaxDues(GetSelectedDetailedTaxDues(paymentPostsId), paymentPostsId);

            Close();
        }

        #endregion

        private bool PrintSelectedReceipt()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int rowIndex = dataGridView1.CurrentRow.Index;
                var localReport = new LocalReport();
                var dictLguDetails = Helper.LGUDetails();
                var amountToWords = new Helper.AmountToWords();
                string amount = dataGridView1.Rows[rowIndex].Cells["payment_collections_amount"].Value.ToString();
                string receiptNo = dataGridView1.Rows[rowIndex].Cells["payment_collections_receipt_no"].Value.ToString();
                string paymentDate = dataGridView1.Rows[rowIndex].Cells["payment_collections_payment_date"].Value.ToString();
                string payee = dataGridView1.Rows[rowIndex].Cells["payment_collections_payee"].Value.ToString();
                string collectingOfficerId = dataGridView1.Rows[rowIndex].Cells["payment_collections_collecting_officers_id"].Value.ToString();
                string jobOrderCollectorId = dataGridView1.Rows[rowIndex].Cells["payment_collections_job_orders_id"].Value.ToString();
                string collectorName = string.Empty;

                if (string.IsNullOrEmpty(jobOrderCollectorId))
                {
                    var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByID(Convert.ToInt32(collectingOfficerId));
                    string prefix = dictCollectingOfficer["prefix"];
                    string suffix = dictCollectingOfficer["suffix"];
                    string firstName = dictCollectingOfficer["first_name"];
                    string middleInitial = dictCollectingOfficer["mid_initial"];
                    string lastName = dictCollectingOfficer["last_name"];

                    collectorName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);
                }
                else if (!string.IsNullOrEmpty(collectingOfficerId) && !string.IsNullOrEmpty(jobOrderCollectorId))
                {
                    var dictCollectingOfficer = AccFactory.JobOrderRepository().GetRecordByID(Convert.ToInt32(collectingOfficerId));
                    string prefix = dictCollectingOfficer["prefix"];
                    string suffix = dictCollectingOfficer["suffix"];
                    string firstName = dictCollectingOfficer["first_name"];
                    string middleInitial = dictCollectingOfficer["mid_initial"];
                    string lastName = dictCollectingOfficer["last_name"];

                    collectorName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);
                }
                else
                    collectorName = string.Empty;

                var parameters = new[]
                {
                new ReportParameter("paramMunicipality", dictLguDetails["lgu_name"]),
                new ReportParameter("paramReceiptNo", receiptNo),
                new ReportParameter("paramPaymentDate", paymentDate),
                new ReportParameter("paramAmount", amount),
                new ReportParameter("paramPayee", payee),
                new ReportParameter("paramCollectorName", collectorName),
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

        private void btnSelect_Click(object sender, EventArgs e)
        {            
            LoadSelectedDetailedTaxDues();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                LoadSelectedDetailedTaxDues();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            PrintSelectedReceipt();      
        }
    }
}
