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
            var errorArray = new string[2];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }


        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "fund name");

            var fundsRepository = Factory.FundsRepository();
            string fundName = txtName.Text.Trim();
            bool fundNameExist;

            if (fundId == 0)
                fundNameExist = fundsRepository.NameExist(fundName); // add form
            else
                fundNameExist = fundsRepository.NameExist(fundName, fundId); // edit form

            if (fundNameExist)
            {
                epName.SetError(txtName, "Fund name already exist in your records.");
                e.Cancel = true;
            }

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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "fund code");

            var fundsRepository = Factory.FundsRepository();
            string fundCode = txtCode.Text.Trim();
            bool fundCodeExist;

            if (fundId == 0)
                fundCodeExist = fundsRepository.CodeExist(fundCode); // add form
            else
                fundCodeExist = fundsRepository.CodeExist(fundCode, fundId); // edit form

            if (fundCodeExist)
            {
                epCode.SetError(txtCode, "Fund code already exist in your records.");
                e.Cancel = true;
            }
        }

		private void txtCode_Validated(object sender, EventArgs e)
		{
            Helper.ClearErrorTextBox(epCode, txtCode);
        }
	}
}
