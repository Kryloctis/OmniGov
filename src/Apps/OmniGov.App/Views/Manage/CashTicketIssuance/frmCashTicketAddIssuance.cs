using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.CashTicketIssuance
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
            uc.OnLoad(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Cash tickets has been issued.");
                frmCashTicketIssuance.LoadIssuedCashTickets();
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

            var model = uc.CashTicketsIssuedModel();
            return TreasuryFactory.CashTicketsIssuedRepository().Insert(model);
        }
    }
}