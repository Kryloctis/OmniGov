using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystem.Views.Transactions.JEV;

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
                LoadObligationRecordCount();
                LoadJEVCounter();
            }
        }


        private void LoadObligationRecordCount() 
        {
            int recordCount = Factory.ObligationAccountRepository().ObligationsRecordCount();

            lblObligationRecordCount.Text = recordCount.ToString();
        }

        private void LoadJEVCounter()
        {
            var generalJournalCount = Factory.JEVRepository().JevCounter(1);
            var cashReceiptsJournalCount = Factory.JEVRepository().JevCounter(2);
            var procurementReceivedJournalCount = Factory.JEVRepository().JevCounter(3);
            var cashDisbursementJournalCount = Factory.JEVRepository().JevCounter(4);
            var checkDisbursementJournalCount = Factory.JEVRepository().JevCounter(5);
            var authorityToDebitJournalCount = Factory.JEVRepository().JevCounter(6);
            var jevCount = Factory.JEVRepository().CountRecords();
            var approvedJEVCount = Factory.JEVRepository().TotalApproveJEV();
            var pendingJEVCount = Factory.JEVRepository().TotalPendingJEV();

            lblGJCounter.Text = generalJournalCount.ToString();
            lblCRJCounter.Text = cashReceiptsJournalCount.ToString();
            lblPRJCounter.Text = procurementReceivedJournalCount.ToString();
            lblCDJCounter.Text = cashDisbursementJournalCount.ToString();
            lblCkDJCounter.Text = checkDisbursementJournalCount.ToString();
            lblADADJCounter.Text = authorityToDebitJournalCount.ToString();
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

            frmJEVSearch.rbApproved.Checked = true;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);

            frmJEVSearch.rbApproved.Checked = true;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

        private void lnkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmJEV = new frmJEV();
            frmJEV.Show();
            var frmJEVSearch = new frmJEVSearch(frmJEV);

            frmJEVSearch.rbPending.Checked = true;
            frmJEVSearch.LoadJEVList();
            frmJEVSearch.ShowDialog();
        }

    }
}
