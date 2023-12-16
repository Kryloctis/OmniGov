using ACC.Data;
using AccountingSystem.Views.Shared;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class ucCattleDetails : UserControl
    {
        public ucCattleDetails()
        {
            InitializeComponent();
        }

        #region Private Methods

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxType),
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudPrice)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        #endregion Private Methods

        #region Event Methods

        private void ucCattleOwnership_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }

        private void cmbxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxType, "Type");
        }

        private void cmbxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxType);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudPrice, "Price") || Helper.ShowErrorNumericUpDownZero(errorProvider1, nudPrice, "Price");
        }

        private void nudPrice_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudPrice);
        }

        #endregion Event Methods
    }
}