using OmniGov.App.Helpers;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.BankAccounts
{
    public partial class frmAddBankAccounts : Form
    {
        private readonly ucBankAccounts uc;
        private readonly frmBankAccounts frmBankAccounts;

        public frmAddBankAccounts(frmBankAccounts frmBankAccounts)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBankAccounts = frmBankAccounts;
            uc = ucBankAccounts1;
        }

        private void frmAddBankAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Account has been saved.");
                    frmBankAccounts.LoadRecords();
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

            return TreasuryFactory.BankAccountsRepository().Insert(uc.BankAccountsModel());
        }

        private void frmAddBankAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
