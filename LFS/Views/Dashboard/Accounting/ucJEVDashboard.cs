using ACC.Data;
using LFS.Helpers;
using LFS.Views.Transactions.JEV;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Dashboard
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

            var dtJournals = AccFactory.JournalsRepository().GetRecords();
            dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");
            DataRow dr = dataTable.NewRow();
            dr["id"] = "0";
            dr["journal_name"] = "All";
            dataTable.Rows.InsertAt(dr, 0);

            return dataTable;
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();

            var newRow = dtFunds.NewRow();
            newRow["id"] = 0;
            newRow["fund_name"] = "All";
            dtFunds.Rows.InsertAt(newRow, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
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

            var jevCount = AccFactory.JEVRepository().GetJevCount(string.Empty, journalName, fundName, year);
            var approvedJEVCount = AccFactory.JEVRepository().GetJevCount("approved", journalName, fundName, year);
            var pendingJEVCount = AccFactory.JEVRepository().GetJevCount("pending", journalName, fundName, year);
            var disapprovedJEVCOunt = AccFactory.JEVRepository().GetJevCount("disapproved", journalName, fundName, year);
            var cancelledJEVCount = AccFactory.JEVRepository().GetJevCount("cancelled", journalName, fundName, year);

            lblJEVCounter.Text = jevCount.ToString();
            lblApprovedJEVCounter.Text = approvedJEVCount.ToString();
            lblPendingJEVCounter.Text = pendingJEVCount.ToString();
            lblDisapprovedJEVCounter.Text = disapprovedJEVCOunt.ToString();
            lblCancelledJEVCounter.Text = cancelledJEVCount.ToString();
        }

        private void btnRefreshCounter_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadJEVList()
        {
            string journalName = cmbxJournals.Text.Trim();
            string fundName = cmbxFunds.Text.Trim();
            short year = (short)nudYear.Value;
            var frmJEVList = new frmJevList(this);

            frmJEVList.cmbxJournals.Enabled = false;
            frmJEVList.nudYear.Enabled = false;
            frmJEVList.ShowDialog();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJev(false, null, this).ShowDialog();
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnRecordJev_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJevList(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}