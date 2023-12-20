using ACC.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense
{
    public partial class ucMarriageDetails : UserControl
    {
        public ucMarriageDetails()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            dtpIssuedDate.Value = Helper.GetCurrentDate();
            dtpPublishedDate.Value = Helper.GetCurrentDate();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtRegistrationNumber)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        private bool RegistrationNumberValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))
            {
                errorProvider.SetError(textBox, Helper.ErrorMessage("registration no."));
                return false;
            }

            return true;
        }

        private void TxtRegistrationNumber_Validating(object sender, CancelEventArgs e) => e.Cancel = !RegistrationNumberValidated(errorProvider1, txtRegistrationNumber);

        private void TxtRegistrationNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRegistrationNumber);
        }
    }
}