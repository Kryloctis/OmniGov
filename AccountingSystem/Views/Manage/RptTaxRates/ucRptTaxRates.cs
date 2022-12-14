using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptTaxRates
{
    public partial class ucRptTaxRates : UserControl
    {
        internal int rptTaxRatesId;
        internal bool isEdit = false;

        public ucRptTaxRates()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            if (isEdit)
                rptTaxRatesId = 0;

            txtCode.Clear();
            txtDescription.Clear();
            nudRate.Value = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudRate)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        #region Validations

        private bool CodeExist()
        {
            return Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Code");
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = CodeExist();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private bool DescriptionValidated()
        {
            return Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = DescriptionValidated();
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private bool RateValidated()
        {
            bool isValidated;

            bool isZero = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudRate, "Rate");
            bool isEmpty = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudRate, "Rate");

            if (isZero || isEmpty)
                isValidated = true;
            else
                isValidated = false;

            return isValidated;
        }

        private void nudRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = RateValidated();
        }

        private void nudRate_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudRate);
        }

        #endregion Validations
    }
}