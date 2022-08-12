using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Reports.RCD.Liquidating;
using AccountingSystem.Views.Transactions.BankDeposits;
using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRCD : Form
    {
        internal ushort collectorId;
        internal sbyte fundId;
        internal string rcdId;
        internal short reportQuantity;
        internal DateTime date;

        public frmRCD()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgListOfApprovedReport, true);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _ = new frmRCDAdd(this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmSearch(this).ShowDialog();
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgListOfApprovedReport.Rows.Count != 0;
            LoadFunds();
        }

        private void LoadFunds()
        {
            try
            {
                var fundrepo = AccFactory.FundsRepository();
                var dtfunds = fundrepo.GetRecords();

                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "fund_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadSelectedRCD(string rcdNo)
        {
            try
            {
                var generalCollectionsPaymentRepo = AccFactory.GeneralCollectionsPaymentsRepository();
                var dtRCD = generalCollectionsPaymentRepo.GetRecordsByRCDNO(rcdNo);

                string reportId;
                string collectingOfficer;
                string reportNo;
                string amount;

                foreach (DataRow row in dtRCD.Rows)
                {
                    reportId = row["collectors_report_id"].ToString();
                    collectingOfficer = $"{row["collecting_officers_first_name"]} {row["collecting_officers_mid_initial"]}. {row["collecting_officers_last_name"]} ";

                    if (!string.IsNullOrEmpty(row["job_orders_id"].ToString()))
                        collectingOfficer = $"{row["job_orders_first_name"]} {row["job_orders_mid_initial"]}. {row["job_orders_last_name"]} ";

                    reportNo = row["report_no"].ToString();
                    amount = Convert.ToDecimal(row["amount"].ToString()).ToString("N2");

                    object[] reportRow = new object[]
                    {
                        reportId,
                        collectingOfficer,
                        reportNo,
                        amount
                    };

                    dgListOfApprovedReport.Rows.Add(reportRow);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadSelectedReport(string reportNo)
        {
            try
            {
                var rcdRepository = AccFactory.CollectorReportRepository();
                var rcdData = rcdRepository.GetRecordByID(reportNo);


                collectorId = (ushort)Convert.ToInt16(rcdData["collecting_officers_id"]);
                fundId = (sbyte)Convert.ToInt32(rcdData["funds_id"]);
                reportNo = rcdData["report_no"];
                date = Convert.ToDateTime(rcdData["date"]);



                var colectorRepository = AccFactory.CollectorReportRepository();
                var dtrcd = new DataTable();
                dtrcd = colectorRepository.FilterRecords(fundId, collectorId, reportNo);
                HelperLoadRecords.RCDDatagridView(dtrcd, dgListOfApprovedReport);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCD has been created.");
                ResetForm();
            }
        }

        private void ResetForm()
        {
            txtRCDNo.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            panelRCD.Enabled = true;

            btnDeposit.Enabled = false;
            btnPrint.Enabled = false;
            btnCancelPrint.Enabled = false;

            btnRemove.Enabled = false;

            dgListOfApprovedReport.Rows.Clear();
        }

        private bool SaveData()
        {

            using (var scope = new TransactionScope())
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }

                var generalCollectionModel = new GeneralCollectionsModel()
                {
                    RcdNo = txtRCDNo.Text,
                    Rcddate = Convert.ToDateTime(dtpDate.Value),
                    FundId = Convert.ToInt32(cmbfunds.SelectedValue),
                    Userid = Helper.UserId
                };

                bool rcdSaveSuccess = AccFactory.GeneralCollectionsRepository().Insert(generalCollectionModel);
                if (!rcdSaveSuccess)
                    return false;


                InsertGeneralCollectionsPayment();
                scope.Complete();
                return true;
            }
        }

        private void InsertGeneralCollectionsPayment()
        {
            var generalCollectionsId = GetGeneralCollectionsId();

            foreach (DataGridViewRow row in dgListOfApprovedReport.Rows)
            {
                ushort collectionsReportId = (ushort)Convert.ToInt32(row.Cells["reportId"].Value);

                var generalCollectionPaymentModel = new GeneralCollectionPaymentsModel()
                {
                    CollectorsReportId = collectionsReportId,
                    GeneralCollectionsId = generalCollectionsId
                };

                AccFactory.GeneralCollectionsPaymentsRepository().Insert(generalCollectionPaymentModel);
            }
        }

        private int GetGeneralCollectionsId()
        {
            var rcdNo = txtRCDNo.Text;
            int generalCollectionId = AccFactory.GeneralCollectionsRepository().GetGeneralCollectionId(rcdNo);
            return generalCollectionId;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            string referenceNumber = txtRCDNo.Text.Trim();
            decimal amount = Convert.ToDecimal(txtTotal.Text);
            int rcdId = int.Parse(this.rcdId);

            _ = new frmBankDepositsAdd(new frmBankDeposits(), rcdId, referenceNumber, amount).ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string reportNo = txtRCDNo.Text.Trim();
            _ = new frmLiquidatingRCD(reportNo).ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgListOfApprovedReport.SelectedRows)
            {
                dgListOfApprovedReport.Rows.RemoveAt(item.Index);
            }
        }

        private void dgListOfApprovedReport_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgListOfApprovedReport.Rows.Count != 0;
        }

        private void dgListOfApprovedReport_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SetStatusStrip();
        }

        private void dgListOfApprovedReport_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetStatusStrip();
        }

        internal void SetStatusStrip()
        {
            decimal totalCollections = 0.0m;

            foreach (DataGridViewRow row in dgListOfApprovedReport.Rows)
                totalCollections += Convert.ToDecimal(row.Cells["amount"].Value);

            reportQuantity = (short)dgListOfApprovedReport.Rows.Count;
            lblRecordCount.Text = reportQuantity.ToString();
            txtTotal.Text = totalCollections.ToString("N2");


            
        }

        private void btnCancelPrint_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Do you want to cancel printing."))
            {
                ResetForm();
            }
        }


        #region Validations
        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epRCDNo.GetError(txtRCDNo);
            errorArray[1] = epDgCollectorRepor.GetError(dgListOfApprovedReport);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtRCDNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epRCDNo, txtRCDNo, "RCD No.");
        }

        private void txtRCDNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epRCDNo, txtRCDNo);
        }

        private void dgListOfApprovedReport_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorDatagridView(epDgCollectorRepor, dgListOfApprovedReport, "Collectors Report.");
        }
        private void dgListOfApprovedReport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDatagridView(epDgCollectorRepor, dgListOfApprovedReport);
        }


        #endregion

    }
}
