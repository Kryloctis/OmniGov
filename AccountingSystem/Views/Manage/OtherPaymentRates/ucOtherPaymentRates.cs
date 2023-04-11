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
            var errorArray = new string[5];

            errorArray[0] = errorProvider1.GetError(txtRateID);
            errorArray[1] = errorProvider1.GetError(cmbxTaxType);
            errorArray[2] = errorProvider1.GetError(txtDescription);
            errorArray[3] = errorProvider1.GetError(nudAmount);
            errorArray[4] = errorProvider1.GetError(nudStartingYear);

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtRateID.Clear();
            cmbxTaxType.SelectedValue = -1;
            txtDescription.Clear();
            nudAmount.Value = 0.0m;
            nudStartingYear.Value = 2023;
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


    }
}
