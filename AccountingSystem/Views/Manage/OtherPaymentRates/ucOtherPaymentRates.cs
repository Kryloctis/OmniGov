using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class ucOtherPaymentRates : UserControl
    {
        public ucOtherPaymentRates()
        {
            InitializeComponent();
        }

        internal string GetFormError()
        {
            var errorArray = new string[2];

            errorArray[0] = errorProvider1.GetError(cmbxTaxType);
            errorArray[1] = errorProvider1.GetError(txtDescription);

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxTaxType.SelectedValue = -1;
            nudAmount.Value = 0.0m;
            nudStartingYear.Value = 2023;
            cbIsRateEditable.Checked = false;
            txtDescription.Clear();
        }

        private void ucOtherPaymentRates_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadTaxTypes();
            }
        }

        private void LoadTaxTypes()
        {
            try
            {
                DataTable dtTaxTypes = AccFactory.TaxTypesRepository().GetRecords();
                cmbxTaxType.DataSource = dtTaxTypes;
                cmbxTaxType.ValueMember = "id";
                cmbxTaxType.DisplayMember = "code";
                cmbxTaxType.SelectedIndex = -1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region Validation

        private void cmbxTaxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxTaxType, "Tax Type");
        }

        private void cmbxTaxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxTaxType);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        #endregion Validation
    }
}