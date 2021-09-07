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

            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
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
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            var jevCount = Factory.JEVRepository().TotalJEV(month, year);
            var approvedJEVCount = Factory.JEVRepository().TotalApproveJEV(month, year);
            var pendingJEVCount = Factory.JEVRepository().TotalPendingJEV(month, year);
            var disapprovedJEVCOunt = Factory.JEVRepository().TotalDisapprovedJEV(month, year);
            var cancelledJEVCount = Factory.JEVRepository().TotalCancelledJEV(month, year);

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

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEVSearch = new frmJEVSearch(true, new frmJEV());

            frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJEVSearch.cmbxJevStatus.Enabled = false;

            frmJEVSearch.cbMonth.SelectedIndex = cbMonth.SelectedIndex;
            frmJEVSearch.nudYear.Value = nudYear.Value;
            frmJEVSearch.ShowDialog();
        }

        private void OpenJEVTransactionForm(byte jevStatusIndex)
        {

            var frmJEVSearch = new frmJEVSearch(true);

            frmJEVSearch.cmbxJevStatus.SelectedIndex = jevStatusIndex;
            frmJEVSearch.cmbxJevStatus.Enabled = false;
            frmJEVSearch.cbMonth.Enabled = false;
            frmJEVSearch.nudYear.Enabled = false;
            frmJEVSearch.btnOK.Text = "Select";
            frmJEVSearch.Text = "Select JEV";
            frmJEVSearch.cbMonth.SelectedIndex = cbMonth.SelectedIndex;
            frmJEVSearch.nudYear.Value = nudYear.Value;
            frmJEVSearch.ShowDialog();
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJEVTransactionForm(1);
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJEVTransactionForm(2);
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenJEVTransactionForm(3);
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }
        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVCounter();
        }

    }
}
