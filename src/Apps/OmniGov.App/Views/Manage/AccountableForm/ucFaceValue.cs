using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.AccountableForm
{
    public partial class ucFaceValue : UserControl
    {
        public ucFaceValue()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(nudAmount)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadSelectedData(int faceValueId)
        {
            var dictFaceValue = Factory.FaceValueRepository().GetRecordByID(faceValueId);

            dtDateEffective.Value = Convert.ToDateTime(dictFaceValue["date_effective"]);
            nudAmount.Value = Convert.ToDecimal(dictFaceValue["amount"]);
            chckDefault.Checked = Convert.ToBoolean(Convert.ToByte(dictFaceValue["is_default"]));
        }

        internal void ResetForm()
        {
            dtDateEffective.Value = Helper.GetCurrentDate();
            nudAmount.Value = 0;
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        private void nudAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAmount, "Amount");
        }
    }
}