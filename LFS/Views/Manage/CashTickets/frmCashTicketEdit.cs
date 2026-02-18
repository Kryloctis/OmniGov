using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace LFS.Views.Manage.CashTickets
{
    public partial class frmCashTicketEdit : Form
    {
        private readonly frmCashTickets frmCashTickets;
        private readonly int cashTicketId;
        private readonly ucCashTickets uc;

        public frmCashTicketEdit(frmCashTickets frmCashTickets, int cashTicketId)
        {
            InitializeComponent();
            this.frmCashTickets = frmCashTickets;
            this.cashTicketId = cashTicketId;
            uc = ucCashTickets1;
        }

        private void FrmCashTicketEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, cashTicketId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Cash Ticket has been updated.");
                    frmCashTickets.LoadCashTickets();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return TreasuryFactory.CashTicketsRepository().Update(uc.CashTicketsModel());
        }
    }
}
