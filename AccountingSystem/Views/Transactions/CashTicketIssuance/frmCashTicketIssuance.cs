using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CashTicketIssuance
{
    public partial class frmCashTicketIssuance : Form
    {
        public frmCashTicketIssuance()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketAddIssuance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketEditIssuance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
