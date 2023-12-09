using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges
{
    public partial class ucFeesCharges : UserControl
    {
        public ucFeesCharges()
        {
            InitializeComponent();
        }

        #region Private Methods

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtDescription)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? feesChargesId = null)
        {
            if (isEdit)
                LoadSelectedRecord(Convert.ToInt32(feesChargesId));
        }

        private void LoadSelectedRecord(int feesChargesId)
        {
            var dictFeesCharges = AccFactory.OtherPaymentRatesRepository().GetRecordByID(feesChargesId);

            chckEditableRate.Checked = Convert.ToBoolean(Convert.ToByte(dictFeesCharges["is_rate_editable"]));
            txtDescription.Text = dictFeesCharges["description"];
            nudAmount.Value = Convert.ToDecimal(dictFeesCharges["amount"]);
            nudStartingYear.Value = Convert.ToDecimal(dictFeesCharges["starting_year"]);
        }

        #endregion Private Methods

        #region Event Methods

        #region Validations

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        #endregion Validations

        #endregion Event Methods
    }
}