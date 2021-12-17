using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class ucSignatories : UserControl
    {
        public ucSignatories()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtPrefix),
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtMiddleInitial),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtTitle)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        #region Validation

        private void txtPrefix_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPrefix, "Prefix");
        }

        private void txtPrefix_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPrefix);
        }

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "First Name");
        }

        private void txtFirstName_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtMiddleInitial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMiddleInitial, "Middle Initial");
        }

        private void txtMiddleInitial_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMiddleInitial);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "Last Name");
        }

        private void txtLastName_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtTitle, "Title");
        }

        private void txtTitle_Validated(object sender, System.EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtTitle);
        }

        #endregion
    }
}
