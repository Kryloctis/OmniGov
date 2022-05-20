using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.PaymentCollection;
using AccountingSystem.Views.Transactions.RCI;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    public partial class ucTreasuryDashboard : UserControl
    {
        public ucTreasuryDashboard()
        {
            InitializeComponent();
        }

        private void btnBankDeposit_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void btnPaymentCollection_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollection().ShowDialog();
        }

        private void BtnRCI_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
        }

        private void btnIssueReceipt_Click(object sender, EventArgs e)
        {
            _ = new Transactions.ReceiptsIssued.frmReceiptsIssued().ShowDialog();
        }

        private void ucTreasuryDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerateRCD_Click(object sender, EventArgs e)
        {
            frmRCD frmRCD = new frmRCD();
            frmRCD.ShowDialog();
        }

        private void btnReportOfCollections_Click(object sender, EventArgs e)
        {
            _ = new Reports.CollectorsRCD.frmCollectorsRCD().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          _ = new frmSearchProperties().ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
