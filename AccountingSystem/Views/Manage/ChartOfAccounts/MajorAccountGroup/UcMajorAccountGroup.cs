using System;
using System.Data;
using ACC.Domain.Interfaces;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.MajorAccountGroup
{
    public partial class UcMajorAccountGroup : UserControl
    {
        internal short majorAccountGroupId = 0;

        public UcMajorAccountGroup()
        {
            InitializeComponent();
        }

        internal void LoadAccountGroup()
        {
            try
            {
                DataTable dtAccountGroup = Factory.AccountGroupRepository().GetRecords();
                HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbAccountGroup, "account_group_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epAccountGroup.GetError(cmbAccountGroup);
            errorArray[1] = epCode.GetError(txtCode);
            errorArray[2] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbAccountGroup.SelectedIndex = -1;
            txtCode.Clear();
            txtName.Clear();
        }

        private void cmbAccountGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccountGroup, cmbAccountGroup, "account group");

            int accountGroupId = Convert.ToByte(cmbAccountGroup.SelectedValue);
            bool idExist = Factory.AccountGroupRepository().IdExist(accountGroupId);

            if (!idExist)
            {
                epAccountGroup.SetError(cmbAccountGroup, "Invalid account group. Please select on the list.");
                e.Cancel = true;
            }
        }

        private void cmbAccountGroup_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccountGroup, cmbAccountGroup);
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

      
    }
}
