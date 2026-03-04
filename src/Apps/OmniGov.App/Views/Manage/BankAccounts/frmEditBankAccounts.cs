using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.BankAccounts
{
    public partial class frmEditBankAccounts : Form
    {
        private int bankAccId;
        private readonly frmBankAccounts frmBankAccounts;
        private readonly ucBankAccounts uc;

        public frmEditBankAccounts(frmBankAccounts frmBankAccounts, int bankAccId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBankAccounts = frmBankAccounts;
            this.bankAccId = bankAccId;
            uc = ucBankAccounts1;
        }

        private void frmEditBankAccounts_Load(object sender, EventArgs e)
        {
            uc.OnLoad(true, bankAccId);
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var bankAccModel = uc.BankAccountsModel();
            bankAccModel.Id = bankAccId;

            return TreasuryFactory.BankAccountsRepository().Update(bankAccModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Bank account has been updated.");
                frmBankAccounts.LoadRecords();
                Close();
            }
        }

        private void frmEditBankAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank account has been updated.");
                    frmBankAccounts.LoadRecords();
                    Close();
                }
            }
        }
    }
}