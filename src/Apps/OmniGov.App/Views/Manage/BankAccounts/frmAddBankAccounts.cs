using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.BankAccounts
{
    public partial class frmAddBankAccounts : Form
    {
        private readonly frmBankAccounts frmBankAccounts;
        private readonly ucBankAccounts uc;

        public frmAddBankAccounts(frmBankAccounts frmBankAccounts)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBankAccounts = frmBankAccounts;
            uc = ucBankAccounts1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Account has been saved.");
                frmBankAccounts.LoadRecords();
                uc.ResetForm();
            }
        }

        private void frmAddBankAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Bank account has been saved.");
                    frmBankAccounts.LoadRecords();
                    uc.ResetForm();
                }
            }
        }

        private void frmAddBankAccounts_Load(object sender, EventArgs e)
        {
            uc.OnLoad(false, null);
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return TreasuryFactory.BankAccountsRepository().Insert(uc.BankAccountsModel());
        }
    }
}