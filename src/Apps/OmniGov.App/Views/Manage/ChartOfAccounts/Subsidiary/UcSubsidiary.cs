using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.ChartOfAccounts.Subsidiary
{
    public partial class ucSubsidiary : UserControl
    {
        internal byte fundId;
        internal ushort generalLedgerId;

        public ucSubsidiary()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Focus();
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtAddress_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAddress);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAddress, "address");
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "code");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "name");
        }

        private void UcSubsidiary_Load(object sender, EventArgs e)
        {
        }
    }
}