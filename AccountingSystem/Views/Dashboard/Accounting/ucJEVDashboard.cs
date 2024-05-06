using ACC.Data;
using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucJevDashboard : UserControl
    {
        public ucJevDashboard()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            LoadMonths();
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

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";
            dtFunds.Rows.InsertAt(dr, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
        }

        private void LoadMonths()
        {
            cmbxMonth.DataSource = new BindingSource(Helper.MonthsDatasource(), null);
            cmbxMonth.ValueMember = "Key";
            cmbxMonth.DisplayMember = "Value";
        }

        internal void LoadJEVCounter()
        {
            string journalName = cmbxJournals.Text.Trim();
            string fundName = cmbxFunds.Text.Trim();
            short month = Convert.ToInt16(cmbxMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            var jevCount = AccFactory.JEVRepository().GetJEVCount(string.Empty, journalName, fundName, month, year);
            var approvedJEVCount = AccFactory.JEVRepository().GetJEVCount("approved", journalName, fundName, month, year);
            var pendingJEVCount = AccFactory.JEVRepository().GetJEVCount("pending", journalName, fundName, month, year);
            var disapprovedJEVCOunt = AccFactory.JEVRepository().GetJEVCount("disapproved", journalName, fundName, month, year);
            var cancelledJEVCount = AccFactory.JEVRepository().GetJEVCount("cancelled", journalName, fundName, month, year);

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
                LoadJEVCounter();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadJEVList(string jevStatus)
        {
            string journalName = cmbxJournals.Text.Trim();
            string fundName = cmbxFunds.Text.Trim();
            byte month = Convert.ToByte(cmbxMonth.SelectedValue);
            short year = (short)nudYear.Value;
            var _frmJEVList = new frmJevList(journalName, fundName, month, year, this);

            switch (jevStatus)
            {
                case "all":
                    _frmJEVList.cmbxJevStatus.SelectedIndex = 0;
                    break;

                case "pending":
                    _frmJEVList.cmbxJevStatus.SelectedIndex = 1;
                    break;

                case "approved":
                    _frmJEVList.cmbxJevStatus.SelectedIndex = 2;
                    break;

                case "disapproved":
                    _frmJEVList.cmbxJevStatus.SelectedIndex = 3;
                    break;

                case "cancelled":
                    _frmJEVList.cmbxJevStatus.SelectedIndex = 4;
                    break;
            }

            _frmJEVList.cmbxJournals.Enabled = false;
            _frmJEVList.cmbxJevStatus.Enabled = false;
            _frmJEVList.cbMonth.Enabled = false;
            _frmJEVList.nudYear.Enabled = false;
            _frmJEVList.ShowDialog();
        }

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LoadJEVList("pending");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LoadJEVList("approved");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LoadJEVList("disapproved");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LoadJEVList("cancelled");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lnkJEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LoadJEVList("all");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadJEVCounter();
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

        private void btnAddJEV_Click(object sender, EventArgs e)
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
    }
}