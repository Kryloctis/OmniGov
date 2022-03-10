using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucJEVDashboard : UserControl
    {
        public ucJEVDashboard()
        {
            InitializeComponent();

        }

        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMonths();
                LoadJournals();
                LoadJEVCounter();
                LoadFunds();
                nudYear.Value = DateTime.Now.Year;
            }
        }

        private DataTable DatatableJournals()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("journal_name");

            try
            {
                var dtJournals = Factory.JournalsRepository().GetRecords();
                dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");
                DataRow dr = dataTable.NewRow();
                dr["id"] = "0";
                dr["journal_name"] = "All";
                dataTable.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return dataTable;
        }

        internal void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";

            dtFunds.Rows.InsertAt(dr, 0);
            cmbxFunds.DataSource = dtFunds;
            cmbxFunds.DisplayMember = "fund_name";
            cmbxFunds.ValueMember = "id";
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
            Dock = DockStyle.Fill;
        }

        internal void LoadJEVCounter()
        {
            string journalName = cmbxJournals.Text.Trim();
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            var jevCount = Factory.JEVRepository().GetJEVCount(string.Empty, journalName, month, year);
            var approvedJEVCount = Factory.JEVRepository().GetJEVCount("approved", journalName, month, year);
            var pendingJEVCount = Factory.JEVRepository().GetJEVCount("pending", journalName, month, year);
            var disapprovedJEVCOunt = Factory.JEVRepository().GetJEVCount("disapproved", journalName, month, year);
            var cancelledJEVCount = Factory.JEVRepository().GetJEVCount("cancelled", journalName, month, year);

            lblJEVCounter.Text = jevCount.ToString();
            lblApprovedJEVCounter.Text = approvedJEVCount.ToString();
            lblPendingJEVCounter.Text = pendingJEVCount.ToString();
            lblDisapprovedJEVCounter.Text = disapprovedJEVCOunt.ToString();
            lblCancelledJEVCounter.Text = cancelledJEVCount.ToString();
        }

        private void btnRefreshCounter_Click(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

        private void LoadJEVList(string jevStatus)
        {
            string journalName = cmbxJournals.Text.Trim();
            byte month = Convert.ToByte(cbMonth.SelectedIndex);
            int year = (int)nudYear.Value;
            var _frmJEVList = new frmJEVList(journalName, month, year, this);

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
            LoadJEVList("pending");
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList("approved");
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList("disapproved");
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList("cancelled");
        }

        private void lnkJEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList("all");
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

        private void btnAddJEV_Click(object sender, EventArgs e)
        {
            _ = new frmJEV(null, this).ShowDialog();
        }

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }
    }
}
