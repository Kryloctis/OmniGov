using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

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
            txtBankCode.Focus();
            txtBankBranch.Clear();
            txtBankName.Clear();
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epProvider1.GetError(txtBankCode);
            errorArray[1] = epProvider1.GetError(txtBankName);
            errorArray[2] = epProvider1.GetError(txtBankBranch);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtBankCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epProvider1, txtBankCode, "Bank Code.");

            //var banksRepository = AccFactory.BanksRepository();
            //string accountno = txtBankBranch.Text.Trim();
            //bool bankCodeExist;

            //if (bankId == 0)
            //    bankCodeExist = banksRepository.CodeExist(accountno);

            //bankCodeExist = banksRepository.CodeExist(accountno, bankId);

            //if (bankCodeExist)
            //{
            //    epProvider1.SetError(txtBankBranch, "Bank code already exist in your records.");
            //    e.Cancel = true;
            //}
        }

        private void txtacode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epProvider1, txtBankBranch);
        }

        private void txtbankname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epProvider1, txtBankName, "bank name.");
        }

        private void txtbankname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epProvider1, txtBankName);
        }

        #endregion Validations
    }
}