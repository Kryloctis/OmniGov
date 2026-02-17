using LFS.Helpers;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.AccountableForm
{
    public partial class ucFaceValue : UserControl
    {
        public ucFaceValue()
        {
            InitializeComponent();
        }

        internal void LoadSelectedData(int faceValueId)
        {
            var dictFaceValue = Factory.FaceValueRepository().GetRecordByID(faceValueId);

            dtDateEffective.Value = Convert.ToDateTime(dictFaceValue["date_effective"]);
            nudAmount.Value = Convert.ToDecimal(dictFaceValue["amount"]);
            chckDefault.Checked = Convert.ToBoolean(Convert.ToByte(dictFaceValue["is_default"]));
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(nudAmount)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            dtDateEffective.Value = Helper.GetCurrentDate();
            nudAmount.Value = 0;
        }

        #region Validations

        private void nudAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAmount, "Amount");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        #endregion Validations
    }
}

