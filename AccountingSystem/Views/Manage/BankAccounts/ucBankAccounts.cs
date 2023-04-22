using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class ucBankAccounts : UserControl
    {
        internal int bankAccountID = 0;

        public ucBankAccounts()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            txtAccountNo.Clear();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxBank),
                errorProvider1.GetError(txtAccountNo)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void ucBankAccounts_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadBanks();
            }
        }

        private void LoadBanks()
        {
            var dtBanks = AccFactory.BanksRepository().GetRecords();
            cmbxBank.DataSource = dtBanks;
            cmbxBank.ValueMember = "id";
            cmbxBank.DisplayMember = "bank_name";
        }

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountNo, "Account Number");
        }

        private void txtAccountNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountNo);
        }

        private void cmbxBank_Validating(object sender, CancelEventArgs e)
        {
        }

        private void cmbxBank_Validated(object sender, EventArgs e)
        {
        }
    }
}