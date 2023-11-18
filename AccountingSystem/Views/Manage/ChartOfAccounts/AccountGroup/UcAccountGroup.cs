using ACC.Data;
using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class UcAccountGroup : UserControl
    {
        internal byte accountGroupId = 0;
        private IAccountGroupRepository _accountGroupRepository;

        public UcAccountGroup()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epCode.GetError(txtCode),
                epName.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private bool CodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            _accountGroupRepository = AccFactory.AccountGroupRepository();
            string accountGroupCode = txtCode.Text.Trim();
            bool codeExist = accountGroupId == 0 ? _accountGroupRepository.CodeExist(accountGroupCode) : _accountGroupRepository.CodeExist(accountGroupCode, accountGroupId);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "code"))
                return false;
            else if (codeExist)
            {
                epCode.SetError(txtCode, $"Code you entered is not allowed. Already exist in your record.");
                return false;
            }
            return true;
        }

        private bool NameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            _accountGroupRepository = AccFactory.AccountGroupRepository();
            string accountGroupName = textBox.Text.Trim();
            bool nameExist = accountGroupId == 0 ? _accountGroupRepository.NameExist(accountGroupName) : _accountGroupRepository.NameExist(accountGroupName, accountGroupId);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "name"))
                return false;
            else if (nameExist)
            {
                errorProvider.SetError(textBox, $"Name you entered is not allowed. Already exist in your record.");
                return false;
            }
            return true;
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CodeValidated(epCode, txtCode);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !NameValidated(epName, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}