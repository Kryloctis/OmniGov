using OmniGov.Accounting.Data.Factories;
using OmniGov.Accounting.Domain.Entities;
using OmniGov.App.Accounting.Views.JournalEntryVoucher;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.Data;

namespace OmniGov.App.Accounting.Views.Dashboard
{
    public partial class ucJevDashboard : UserControl
    {
        public ucJevDashboard()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            LoadJournals();
            LoadJEVCounter();
            LoadFunds();
            nudYear.Value = DateTime.Now.Year;
        }

        private DataTable DatatableJournals()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("journal_name");

            var dtJournals = Factory.JournalsRepository().GetRecords();
            dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");
            DataRow dr = dataTable.NewRow();
            dr["id"] = "0";
            dr["journal_name"] = "All";
            dataTable.Rows.InsertAt(dr, 0);

            return dataTable;
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();

            var newRow = dtFunds.NewRow();
            newRow["id"] = 0;
            newRow["fund_name"] = "All";
            dtFunds.Rows.InsertAt(newRow, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
        }

        internal void LoadJEVCounter()
        {
            string journalName = cmbxJournals.Text.Trim();
            string fundName = cmbxFunds.Text.Trim();
            short year = Convert.ToInt16(nudYear.Value);

            var jevCount = AccountingFactory.JEVRepository().GetJevCount(null, journalName, fundName, year);
            var approvedJevCount = AccountingFactory.JEVRepository().GetJevCount(JevModel.Status.approved, journalName, fundName, year);
            var pendingJevCount = AccountingFactory.JEVRepository().GetJevCount(JevModel.Status.pending, journalName, fundName, year);
            var disapprovedJevCount = AccountingFactory.JEVRepository().GetJevCount(JevModel.Status.disapproved, journalName, fundName, year);
            var cancelledJevCount = AccountingFactory.JEVRepository().GetJevCount(JevModel.Status.cancelled, journalName, fundName, year);

            lblJEVCounter.Text = jevCount.ToString();
            lblApprovedJEVCounter.Text = approvedJevCount.ToString();
            lblPendingJEVCounter.Text = pendingJevCount.ToString();
            lblDisapprovedJEVCounter.Text = disapprovedJevCount.ToString();
            lblCancelledJEVCounter.Text = cancelledJevCount.ToString();
        }

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkJEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadJEVCounter();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVCounter();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVCounter();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnJev_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournalEntryVoucher(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}