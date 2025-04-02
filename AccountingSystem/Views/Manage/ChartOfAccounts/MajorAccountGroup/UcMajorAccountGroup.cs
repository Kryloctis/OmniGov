using ACC.Data;
using LFS;
using System;
using System.Data;
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

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epAccountGroup.GetError(cmbAccountGroup),
                epCode.GetError(txtCode),
                epName.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadAccountGroup()
        {
            DataTable dtAccountGroup = AccFactory.AccountGroupRepository().GetRecords();
            HelperLoadRecords.AccountGroupComboBox(dtAccountGroup, cmbAccountGroup, "account_group_name", "id");
        }

        internal void ResetForm()
        {
            cmbAccountGroup.SelectedIndex = -1;
            txtCode.Clear();
            txtName.Clear();
        }

        private bool AccountGroupValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            int accountGroupId = Convert.ToByte(comboBox.SelectedValue);
            bool idExist = AccFactory.AccountGroupRepository().IdExist(accountGroupId);

            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "account group"))
                return false;
            else if (!idExist)
            {
                errorProvider.SetError(comboBox, "Invalid account group. Please select on the list.");
                return false;
            }
            return true;
        }

        private void cmbAccountGroup_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccountGroup, cmbAccountGroup);
        }

        private void cmbAccountGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !AccountGroupValidated(epAccountGroup, cmbAccountGroup);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");
        }
    }
}