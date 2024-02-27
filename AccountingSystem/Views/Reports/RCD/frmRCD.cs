using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.BankDeposits;
using System;
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
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {
            try
            {
                btnRemove.Enabled = dgListOfApprovedReport.Rows.Count != 0;
                LoadFunds();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            var dtfunds = AccFactory.FundsRepository().GetRecords();

            cmbfunds.DataSource = dtfunds;
            cmbfunds.ValueMember = "id";
            cmbfunds.DisplayMember = "fund_name";
        }

        //Questionable Code

        private void btnSave_Click(object sender, EventArgs e)
        {
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

        private void InsertGeneralCollectionsPayment()
        {
            //var generalCollectionsId = GetGeneralCollectionsId();

            //foreach (DataGridViewRow row in dgListOfApprovedReport.Rows)
            //{
            //    ushort collectionsReportId = (ushort)Convert.ToInt32(row.Cells["reportId"].Value);

            //    var generalCollectionPaymentModel = new GeneralCollectionPaymentsModel()
            //    {
            //        CollectorsReportId = collectionsReportId,
            //        GeneralCollectionsId = generalCollectionsId
            //    };

            //    AccFactory.GeneralCollectionsPaymentsRepository().Insert(generalCollectionPaymentModel);
            //}
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                string referenceNumber = txtRCDNo.Text.Trim();
                decimal amount = Convert.ToDecimal(txtTotal.Text);
                int rcdId = int.Parse(this.rcdId);

                _ = new frmBankDepositsAdd(new frmBankDeposits(), rcdId, referenceNumber, amount).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dgListOfApprovedReport.SelectedRows)
                {
                    dgListOfApprovedReport.Rows.RemoveAt(item.Index);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgListOfApprovedReport_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgListOfApprovedReport.Rows.Count != 0;
        }

        private void dgListOfApprovedReport_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                SetStatusStrip();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgListOfApprovedReport_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                SetStatusStrip();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtRCDNo),
                errorProvider1.GetError(dgListOfApprovedReport)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void txtRCDNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRCDNo, "RCD No.");
        }

        private void txtRCDNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRCDNo);
        }

        private void dgListOfApprovedReport_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorDatagridView(errorProvider1, dgListOfApprovedReport, "Collectors Report.");
        }

        private void dgListOfApprovedReport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDatagridView(errorProvider1, dgListOfApprovedReport);
        }

        #endregion Validations
    }
}