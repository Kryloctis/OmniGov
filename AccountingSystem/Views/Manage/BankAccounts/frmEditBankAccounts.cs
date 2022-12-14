using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmEditBankAccounts : Form
    {
        private frmBankAccounts _frmBankAccounts;
        private int _bankAccountID;
        private readonly ucBankAccounts _ucBankAccounts;

        public frmEditBankAccounts(frmBankAccounts frmBankAccounts, int bankAccountID)
        {
            InitializeComponent();
            _frmBankAccounts = frmBankAccounts;
            _bankAccountID = bankAccountID;

            _ucBankAccounts = ucBankAccounts1;
        }

        private void frmEditBankAccounts_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var bankAccountRepository = AccFactory.BankAccountsRepository();
                var bankData = bankAccountRepository.GetRecordByID(_bankAccountID);

                _ucBankAccounts.cmbxBank.SelectedValue = bankData["banks_id"];
                _ucBankAccounts.txtAccountNo.Text = bankData["account_no"];
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Bank account has been updated.");
                _frmBankAccounts.LoadBankAccounts();
                Close();
            }
        }

        private bool SaveData()
        {
            try
            {
                if (!_ucBankAccounts.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucBankAccounts.GetFormErrors());
                    return false;
                }

                var bankAccountID = _bankAccountID;
                var bankID = Convert.ToInt32(_ucBankAccounts.cmbxBank.SelectedValue);
                var bankAccountNumber = _ucBankAccounts.txtAccountNo.Text.Trim();

                var bankAccountsModel = new BankAccountsModel()
                {
                    ID = bankAccountID,
                    BankID = bankID,
                    AccountNumber = bankAccountNumber
                };

                var bankAccountsRepository = AccFactory.BankAccountsRepository();
                return bankAccountsRepository.Update(bankAccountsModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }
    }
}