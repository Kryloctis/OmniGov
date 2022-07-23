using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class UcAccountGroup : UserControl
    {
        internal byte accountGroupId = 0;
        IAccountGroupRepository _accountGroupRepository;

        public UcAccountGroup()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");

            _accountGroupRepository = AccFactory.AccountGroupRepository();
            string accountGroupCode = txtCode.Text.Trim();
            bool codeExist;

            if (accountGroupId == 0)
                codeExist = _accountGroupRepository.CodeExist(accountGroupCode);
            else
                codeExist = _accountGroupRepository.CodeExist(accountGroupCode, accountGroupId);

            if (codeExist)
            {
                epCode.SetError(txtCode, $"Code you entered is not allowed. Already exist in your record.");
                e.Cancel = true;
            }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");

            _accountGroupRepository = AccFactory.AccountGroupRepository();
            string accountGroupName = txtName.Text.Trim();
            bool nameExist;

            if (accountGroupId == 0)
                nameExist = _accountGroupRepository.NameExist(accountGroupName);
            else
                nameExist = _accountGroupRepository.NameExist(accountGroupName, accountGroupId);

            if (nameExist)
            {
                epName.SetError(txtName, $"Name you entered is not allowed. Already exist in your record.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}
