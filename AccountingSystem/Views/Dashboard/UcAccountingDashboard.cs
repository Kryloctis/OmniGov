using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucAccountingDashboard : UserControl
    {
        internal Dictionary<string, string> userDict;

        public ucAccountingDashboard()
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
            var disapprovedJEVCOunt = Factory.JEVRepository().TotalDisapprovedJEV();
            var cancelledJEVCount = Factory.JEVRepository().TotalCancelledJEV();

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

        private void lnkJEV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }


        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEVSearch = new frmJEVSearch(new frmJEV());

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJEVSearch.cmbxJevStatus.Enabled = false;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEVSearch = new frmJEVSearch(new frmJEV());

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 1;
            frmJEVSearch.cmbxJevStatus.Enabled = false;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEVSearch = new frmJEVSearch(new frmJEV());

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 2;
            frmJEVSearch.cmbxJevStatus.Enabled = false;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEVSearch = new frmJEVSearch(new frmJEV());

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 3;
            frmJEVSearch.cmbxJevStatus.Enabled = false;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }
    }
}
