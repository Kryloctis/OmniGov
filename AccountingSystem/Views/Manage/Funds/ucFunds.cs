using ACC.Data;
using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class ucFunds : UserControl
    {
        internal int fundId = 0;

        public ucFunds()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epCode.GetError(txtCode),
                epName.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "fund name");

                string fundName = txtName.Text.Trim();
                bool fundNameExist;

                if (fundId == 0)
                    fundNameExist = AccFactory.FundsRepository().NameExist(fundName); // add form
                else
                    fundNameExist = AccFactory.FundsRepository().NameExist(fundName, fundId); // edit form

                if (fundNameExist)
                {
                    epName.SetError(txtName, "Fund name already exist in your records.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void ucFunds_Load(object sender, EventArgs e)
        {
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "fund code");

                string fundCode = txtCode.Text.Trim();
                bool fundCodeExist;

                if (fundId == 0)
                    fundCodeExist = AccFactory.FundsRepository().CodeExist(fundCode); // add form
                else
                    fundCodeExist = AccFactory.FundsRepository().CodeExist(fundCode, fundId); // edit form

                if (fundCodeExist)
                {
                    epCode.SetError(txtCode, "Fund code already exist in your records.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }
    }
}