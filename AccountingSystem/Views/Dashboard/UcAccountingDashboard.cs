using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucAccountingDashboard : UserControl
    {
        public ucAccountingDashboard()
        {
            InitializeComponent();
      
        }

        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                foreach (var item in Helper.MonthsDatasource().Values)
                    cbMonth.Items.Add(item);
                cbMonth.SelectedIndex = DateTime.Now.Month - 1;
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

        private void LoadJEVList(byte jevStatus)
        {

            byte month = Convert.ToByte(cbMonth.SelectedIndex);
            int year = (int)nudYear.Value;
            var _frmJEVSearch = new frmJEVSearch(null,month, year);

            switch (jevStatus)
            {
                case 0:
                    _frmJEVSearch.cmbxJevStatus.SelectedIndex = 0;
                    break;
                case 1:
                    _frmJEVSearch.cmbxJevStatus.SelectedIndex = 1;
                    break;
                case 2:
                    _frmJEVSearch.cmbxJevStatus.SelectedIndex = 2;
                    break;
                case 3:
                    _frmJEVSearch.cmbxJevStatus.SelectedIndex = 3;
                    break;
            }

            _frmJEVSearch.cmbxJevStatus.Enabled = false;
            _frmJEVSearch.cbMonth.Enabled = false;
            _frmJEVSearch.nudYear.Enabled = false;
            _frmJEVSearch.ShowDialog();
        }

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList(0);
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList(1);
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList(2);
        }

        private void lnkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadJEVList(3);
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
