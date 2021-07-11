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

namespace AccountingSystem.Views.Dashboard
{
    public partial class UcAccountingDashboard : UserControl
    {
        private Dictionary<string, string> userDict;
        public UcAccountingDashboard(Dictionary<string, string> _userDict)
        {
            InitializeComponent();
            userDict = _userDict;
        }

        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Dock = DockStyle.Fill;

                VisibilityJournalCardsCounter(false);

                if (userDict["office"] == "Accounting" || userDict["office"] == "SysAdmin")
                    VisibilityJournalCardsCounter(true);

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

        private void VisibilityJournalCardsCounter(bool visible)
        {
            pnlGJ.Visible = visible;
            pnlCRJ.Visible = visible;
            pnlADADJ.Visible = visible;
            pnlCDJ.Visible = visible;
            pnlCkDJ.Visible = visible;
            pnlPRJ.Visible = visible;
            pnlJEV.Visible = visible;
            pnlApprovedJEV.Visible = visible;
            pnlPendingJEV.Visible = visible;
        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
