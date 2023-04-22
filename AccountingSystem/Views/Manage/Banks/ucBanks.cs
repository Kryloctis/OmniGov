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
            txtBankCode.Clear();
            txtBankBranch.Clear();
            txtBankName.Clear();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epProvider1.GetError(txtBankName)
            };
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void txtbankname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epProvider1, txtBankName, "bank name.");
        }

        private void txtbankname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epProvider1, txtBankName);
        }
    }
}