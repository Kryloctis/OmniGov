using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class ucFunds : UserControl
    {
        private int fundId;
        private bool isEdit;

        public ucFunds()
        {
            InitializeComponent();
        }

        private void LoadSelectedRecord()
        {
            var fundData = AccFactory.FundsRepository().GetRecordByID(1);
            txtCode.Text = fundData["fund_code"];
            txtName.Text = fundData["fund_name"];
        }

        internal FundsModel FundsModel()
        {
            return new FundsModel()
            {
                FundCode = txtCode.Text.Trim(),
                FundName = txtName.Text.Trim(),
            };
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

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private bool FundNameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string fundName = textBox.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "fund name"))
                return false;

            bool fundNameExist = isEdit ? AccFactory.FundsRepository().NameExist(fundName, fundId) : AccFactory.FundsRepository().NameExist(fundName);
            if (fundNameExist)
            {
                errorProvider.SetError(textBox, "Fund name already exist.");
                return false;
            }
            return true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !FundNameValidated(errorProvider1, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private bool FundCodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string fundCode = textBox.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "fund code"))
                return false;

            bool fundCodeExist = isEdit ? AccFactory.FundsRepository().CodeExist(fundCode, fundId) : AccFactory.FundsRepository().CodeExist(fundCode);

            if (fundCodeExist)
            {
                errorProvider.SetError(txtCode, "Fund code already exist in your records.");
                return false;
            }

            return true;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !FundCodeValidated(errorProvider1, txtCode);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }
    }
}