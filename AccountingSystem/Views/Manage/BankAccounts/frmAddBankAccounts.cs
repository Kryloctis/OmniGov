using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmAddBankAccounts : Form
    {
        private readonly ucBankAccounts uc;
        private readonly frmBankAccounts frmBankAccounts;

        public frmAddBankAccounts(frmBankAccounts frmBankAccounts)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucBankAccounts1;
            this.frmBankAccounts = frmBankAccounts;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Account has been saved.");
                    frmBankAccounts.LoadBankAccounts();
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

            BankAccountsModel bankAccountsModel = new BankAccountsModel()
            {
                BankID = Convert.ToInt32(uc.cmbxBank.SelectedValue),
                AccountNumber = uc.txtAccountNo.Text
            };

            return AccFactory.BankAccountsRepository().Insert(bankAccountsModel);
        }
    }
}