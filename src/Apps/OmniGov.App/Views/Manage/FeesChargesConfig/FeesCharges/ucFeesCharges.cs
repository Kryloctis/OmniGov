using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.FeesChargesConfig.FeesCharges
{
    public partial class ucFeesCharges : UserControl
    {
        public ucFeesCharges()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtDescription)
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? feesChargesId = null)
        {
            if (isEdit)
                LoadSelectedRecord(Convert.ToInt32(feesChargesId));
        }

        private void LoadSelectedRecord(int feesChargesId)
        {
            var dictFeesCharges = TreasuryFactory.OtherPaymentRatesRepository().GetRecordByID(feesChargesId);

            chckEditableRate.Checked = Convert.ToBoolean(Convert.ToByte(dictFeesCharges["is_rate_editable"]));
            txtDescription.Text = dictFeesCharges["description"];
            nudAmount.Value = Convert.ToDecimal(dictFeesCharges["amount"]);
            nudStartingYear.Value = Convert.ToDecimal(dictFeesCharges["starting_year"]);
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }
    }
}