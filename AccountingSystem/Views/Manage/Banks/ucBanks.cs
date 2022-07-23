using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class ucBanks : UserControl
    {
        internal int bankId = 0;

        public ucBanks()
        {
            InitializeComponent();
        }

        private void ucBanks_Load(object sender, EventArgs e)
        {

        }
        internal void ResetForm()
        {
            txtacode.Clear();
            txtbankname.Clear();
            txtacode.Focus();
        }

        #region Validations
        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccountNumber.GetError(txtacode);
            errorArray[1] = epBankName.GetError(txtbankname);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtacode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epAccountNumber, txtacode, "account no.");

            var banksrepository = AccFactory.BanksRepository();
            string accountno = txtacode.Text.Trim();
            bool accountNoexist;

            if (bankId == 0)
                accountNoexist = banksrepository.CodeExist(accountno);
            else
                accountNoexist = banksrepository.CodeExist(accountno, bankId);
            if (accountNoexist)
            {
                epAccountNumber.SetError(txtacode, "Account Number already exist in your records!");
                e.Cancel = true;
            }
        }

        private void txtacode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epAccountNumber, txtacode);
        }

        private void txtbankname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epBankName, txtbankname, "bank name.");

        }

        private void txtbankname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epBankName, txtbankname);
        }

        #endregion


        




    }
}
