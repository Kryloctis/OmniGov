using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class UcAccountingDashboard : UserControl
    {
        internal Dictionary<string, string> userDict;

        public UcAccountingDashboard()
        {
            InitializeComponent();
        }

        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Dock = DockStyle.Fill;
                LoadJEVCounter();
            }
        }

        private void LoadJEVCounter()
        {
            var jevCount = Factory.JEVRepository().CountRecords();
            var approvedJEVCount = Factory.JEVRepository().TotalApproveJEV();
            var pendingJEVCount = Factory.JEVRepository().TotalPendingJEV();
            lblJEVCounter.Text = jevCount.ToString();
            lblApprovedJEVCounter.Text = approvedJEVCount.ToString();
            lblPendingJEVCounter.Text = pendingJEVCount.ToString();

        }

        private void btnRefreshCounter_Click(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

        private void lnkJEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 1;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);
            frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }
    }
}
