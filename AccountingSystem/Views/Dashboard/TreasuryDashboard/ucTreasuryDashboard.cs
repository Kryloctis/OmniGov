using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.PaymentCollection;
using AccountingSystem.Views.Transactions.RCI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    public partial class ucTreasuryDashboard : UserControl
    {
        public ucTreasuryDashboard()
        {
            InitializeComponent();
        }

        private void btnGenerateRCD_Click(object sender, EventArgs e)
        {
            _ = new frmRCD().ShowDialog();
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
    }
}
