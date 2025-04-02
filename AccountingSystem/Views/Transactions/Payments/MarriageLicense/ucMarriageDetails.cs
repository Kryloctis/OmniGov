using ACC.Data;
using LFS;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    public partial class ucMarriageDetails : UserControl
    {
        public ucMarriageDetails()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            txtLicenseNo.Clear();
            txtRegistrationNumber.Clear();
            dtpPublishedDate.Value = Helper.GetCurrentDate();
            dtpIssuedDate.Value = Helper.GetCurrentDate();
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
                errorProvider1.GetError(txtLicenseNo),
                errorProvider1.GetError(txtRegistrationNumber)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal (string licenseNo, string registryNo, DateTime publishedOn, DateTime issuedOn) GetMarriageDetails()
        {
            string licenseNumber = txtLicenseNo.Text.Trim();
            string registrationNumber = txtRegistrationNumber.Text.Trim();
            DateTime publishedDate = dtpPublishedDate.Value;
            DateTime issuedDate = dtpIssuedDate.Value;

            return (licenseNumber, registrationNumber, publishedDate, issuedDate);
        }

        private void TxtRegistrationNumber_Validating(object sender, CancelEventArgs e) => e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRegistrationNumber, "registration no.");

        private void TxtRegistrationNumber_Validated(object sender, EventArgs e) => Helper.ClearErrorTextBox(errorProvider1, txtRegistrationNumber);

        private void txtLicenseNo_Validating(object sender, CancelEventArgs e) => e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLicenseNo, "license no.");

        private void txtLicenseNo_Validated(object sender, EventArgs e) => Helper.ClearErrorTextBox(errorProvider1, txtLicenseNo);
    }
}