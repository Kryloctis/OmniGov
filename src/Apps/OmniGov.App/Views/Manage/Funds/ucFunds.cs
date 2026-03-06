using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

using System.ComponentModel;

namespace OmniGov.App.Views.Manage.Funds

{
    public partial class ucFunds : UserControl

    {
        private int fundId;

        private bool isEdit;

        public ucFunds()

        {
            InitializeComponent();
        }

        internal FundsModel FundsModel()

        {
            return new FundsModel()

            {
                FundCode = txtCode.Text.Trim(),

                FundName = txtName.Text.Trim(),
            };
        }

        internal string GetFormErrors()

        {
            var errorArray = new string[]

            {
                errorProvider1.GetError(txtCode),

                errorProvider1.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? fundId)

        {
            this.isEdit = isEdit;

            if (isEdit)

            {
                this.fundId = fundId.Value;

                LoadSelectedRecord();
            }
        }

        internal void ResetForm()

        {
            txtCode.Clear();

            txtName.Clear();
        }

        private bool FundCodeValidated(ErrorProvider errorProvider, TextBox textBox)

        {
            string fundCode = textBox.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "fund code"))

                return false;

            bool fundCodeExist = isEdit ? Factory.FundsRepository().CodeExist(fundCode, fundId) : Factory.FundsRepository().CodeExist(fundCode);

            if (fundCodeExist)

            {
                errorProvider.SetError(txtCode, "Fund code already exist in your records.");

                return false;
            }

            return true;
        }

        private bool FundNameValidated(ErrorProvider errorProvider, TextBox textBox)

        {
            string fundName = textBox.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "fund name"))

                return false;

            bool fundNameExist = isEdit ? Factory.FundsRepository().NameExist(fundName, fundId) : Factory.FundsRepository().NameExist(fundName);

            if (fundNameExist)

            {
                errorProvider.SetError(textBox, "Fund name already exist.");

                return false;
            }

            return true;
        }

        private void LoadSelectedRecord()

        {
            var fundData = Factory.FundsRepository().GetRecordByID(1);

            txtCode.Text = fundData["fund_code"];

            txtName.Text = fundData["fund_name"];
        }

        private void txtCode_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = !FundCodeValidated(errorProvider1, txtCode);
        }

        private void txtName_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = !FundNameValidated(errorProvider1, txtName);
        }
    }
}