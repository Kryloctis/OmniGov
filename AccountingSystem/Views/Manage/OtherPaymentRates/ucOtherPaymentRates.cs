using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var errorArray = new string[4];

            errorArray[0] = errorProvider1.GetError(cmbxTaxType);
            errorArray[1] = errorProvider1.GetError(txtDescription);
            errorArray[2] = errorProvider1.GetError(nudAmount);
            errorArray[3] = errorProvider1.GetError(nudStartingYear);

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxTaxType.SelectedValue = -1;
            txtDescription.Clear();
            nudAmount.Value = 0.0m;
            nudStartingYear.Value = 2023;
            cbIsRateEditable.Checked = false;
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

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAmount, "Amount");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }
    }
}
