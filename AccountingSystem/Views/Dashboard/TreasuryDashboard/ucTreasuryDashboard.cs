using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.PaymentCollection;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystem.Views.Reports.PaymentCollection;

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
            _ = new frmReceipts().ShowDialog();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            _ = new frmAccForms().ShowDialog();
        }

        private void ucTreasuryDashboard_Load(object sender, EventArgs e)
        {
        }

        private void btnReportCollections_Click(object sender, EventArgs e)
        {
            _ = new frmPCReport().ShowDialog();
        }

        private void btnGenerateRCD_Click(object sender, EventArgs e)
        {

        }
    }
}
