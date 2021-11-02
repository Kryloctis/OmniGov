using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                LoadCardColors();
            }
        }

        private void LoadCardColors() 
        {
            pnlApprovedJEV.BackColor = Helper.StatusColor("Approved");
            pnlPendingJEV.BackColor = Helper.StatusColor("Pending");
            pnlDisapproved.BackColor = Helper.StatusColor("Disapproved");
            pnlCancelled.BackColor = Helper.StatusColor("Cancelled");
            pnlJEV.BackColor = Color.FromArgb(40, 56, 94);
            lblApprovedJEVCounter.ForeColor = Color.White;
            lblPendingJEVCounter.ForeColor = Color.White;
            lblDisapprovedJEVCounter.ForeColor = Color.White;
            lblCancelledJEVCounter.ForeColor = Color.White;
            lblJEVCounter.ForeColor = Color.White;
            lnkApproved.LinkColor = Color.White;
            lnkPending.LinkColor = Color.White;
            linkDisapproved.LinkColor = Color.White;
            lnkCancelled.LinkColor = Color.White;
            lnkJEV.LinkColor = Color.White;
            lnkPending.ActiveLinkColor = Color.White;
            lnkApproved.ActiveLinkColor = Color.White;
            lnkCancelled.ActiveLinkColor = Color.White;
            lnkJEV.ActiveLinkColor = Color.White;
            lnkJEV.VisitedLinkColor = Color.White;
            lnkApproved.VisitedLinkColor = Color.White;
            lnkPending.VisitedLinkColor = Color.White;
            linkDisapproved.VisitedLinkColor = Color.White;
            lnkCancelled.VisitedLinkColor = Color.White;
        }

        private void LoadJournals()
        {
            var dtJournals = Factory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournals, "id", "journal_name");
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

            var jevCount = Factory.JEVRepository().JevCounterByStatus(string.Empty,journalName, month, year);
            var approvedJEVCount = Factory.JEVRepository().JevCounterByStatus("approved", journalName,month, year);
            var pendingJEVCount = Factory.JEVRepository().JevCounterByStatus("pending",journalName, month, year);
            var disapprovedJEVCOunt = Factory.JEVRepository().JevCounterByStatus("disapproved" ,journalName ,month, year);
            var cancelledJEVCount = Factory.JEVRepository().JevCounterByStatus("cancelled" ,journalName , month, year);

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
            _ = new frmJEV(null,this).ShowDialog();
        }

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

    
    }
}
