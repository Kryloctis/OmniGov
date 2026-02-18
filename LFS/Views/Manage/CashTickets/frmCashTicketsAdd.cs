using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace LFS.Views.Manage.CashTickets
{
    public partial class frmCashTicketsAdd : Form
    {
        private readonly ucCashTickets uc;
        private frmCashTickets frmCashTickets;

        public frmCashTicketsAdd(frmCashTickets frmCashTickets)
        {
            InitializeComponent();
            uc = ucCashTickets1;
            this.frmCashTickets = frmCashTickets;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Cash Ticket has been added.");
                frmCashTickets.LoadCashTickets();
                uc.ResetForm();
            }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return TreasuryFactory.CashTicketsRepository().Insert(uc.CashTicketsModel());
        }
    }
}
