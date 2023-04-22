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
            try
            {
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord()
        {
            var bankAccountRepository = AccFactory.BankAccountsRepository();
            var bankData = bankAccountRepository.GetRecordByID(_bankAccountID);

            _ucBankAccounts.cmbxBank.SelectedValue = bankData["banks_id"];
            _ucBankAccounts.txtAccountNo.Text = bankData["account_no"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Bank account has been updated.");
                    _frmBankAccounts.LoadBankAccounts();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
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
    }
}