using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.CashTicketIssuance
{
    public partial class frmCashTicketEditIssuance : Form
    {
        private int cashTckIssId;
        private frmCashTicketIssuance frmCashTicketIssuance;
        private ucCashTicketIssuance uc;

        public frmCashTicketEditIssuance(frmCashTicketIssuance frmCashTicketIssuance, int cashTicketIssuanceId)
        {
            InitializeComponent();
            uc = ucCashTicketIssuance1;
            this.frmCashTicketIssuance = frmCashTicketIssuance;
            this.cashTckIssId = cashTicketIssuanceId;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Cash Ticket Issued has been updated.");
                frmCashTicketIssuance.LoadIssuedCashTickets();
                Close();
            }
        }

        private void frmCashTicketEditIssuance_Load(object sender, EventArgs e)
        {
            var cashTicketIssuedDict = TreasuryFactory.CashTicketsIssuedRepository().GetRecordByID(cashTckIssId);
            uc.OnLoad(true);
            uc.LoadSelectedValue(cashTicketIssuedDict);
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = uc.CashTicketsIssuedModel();
            model.Id = cashTckIssId;

            return TreasuryFactory.CashTicketsIssuedRepository().Update(model);
        }
    }
}