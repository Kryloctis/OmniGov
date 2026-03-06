using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.Banks
{
    public partial class frmEditBank : Form
    {
        private readonly frmBanks frmBanks;
        private readonly ucBanks uc;
        private int bankId;

        public frmEditBank(frmBanks frmBanks, int bankId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBanks = frmBanks;
            this.bankId = bankId;
            uc = ucBanks1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Bank has been updated.");
                frmBanks.LoadRecords();
                uc.ResetForm();
                Close();
            }
        }

        private void frmBankEdit_Load(object sender, EventArgs e)
        {
            uc.OnLoad(true, bankId);
        }

        private void frmEditBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank has been updated.");
                    frmBanks.LoadRecords();
                    uc.ResetForm();
                    Close();
                }
            }
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var banksModel = uc.BanksModel();
            banksModel.Id = bankId;

            return TreasuryFactory.BanksRepository().Update(banksModel);
        }
    }
}