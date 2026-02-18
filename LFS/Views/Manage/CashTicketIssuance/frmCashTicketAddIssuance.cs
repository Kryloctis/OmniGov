using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data.Factories;

namespace LFS.Views.Transactions.CashTicketIssuance
{
    public partial class frmCashTicketAddIssuance : Form
    {
        private readonly ucCashTicketIssuance uc;
        private frmCashTicketIssuance frmCashTicketIssuance;

        public frmCashTicketAddIssuance(frmCashTicketIssuance frmCashTicketIssuance)
        {
            InitializeComponent();
            uc = ucCashTicketIssuance1;
            this.frmCashTicketIssuance = frmCashTicketIssuance;
        }

        private void frmCashTicketAddIssuance_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Cash tickets has been issued.");
                    frmCashTicketIssuance.LoadIssuedCashTickets();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = uc.CashTicketsIssuedModel();
            return TreasuryFactory.CashTicketsIssuedRepository().Insert(model);
        }
    }
}
