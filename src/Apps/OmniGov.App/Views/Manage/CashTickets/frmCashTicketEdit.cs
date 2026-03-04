using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.CashTickets
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
            uc.OnLoad(true, cashTicketId);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Cash Ticket has been updated.");
                frmCashTickets.LoadCashTickets();
                Close();
            }
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