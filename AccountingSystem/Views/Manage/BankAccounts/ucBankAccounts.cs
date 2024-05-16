using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class ucBankAccounts : UserControl
    {
        private int bankAccId;
        private bool isEdit;

        public ucBankAccounts()
        {
            InitializeComponent();
        }

        private void LoadSelectedRecord(int bankAccId)
        {
            var dictBankAccounts = AccFactory.BankAccountsRepository().GetRecordByID(bankAccId);
            cmbxBank.SelectedValue = dictBankAccounts["banks_id"];
            txtAccountNo.Text = dictBankAccounts["account_no"];
        }

        internal BankAccountsModel BankAccountsModel()
        {
            return new BankAccountsModel()
            {
                BanksModel = new BanksModel() { Id = Convert.ToInt32(cmbxBank.SelectedValue) },
                AccountNumber = txtAccountNo.Text.Trim(),
            };
        }

        internal void OnLoad(bool isEdit, int? bankAccId)
        {
            this.isEdit = isEdit;
            LoadBanks();

            if (isEdit)
            {
                this.bankAccId = bankAccId.Value;
                LoadSelectedRecord(this.bankAccId);
            }
        }

        internal void ResetForm()
        {
            LoadBanks();
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

        private void LoadBanks()
        {
            DataTable dataTable = AccFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dataTable, cmbxBank, "id", "bank_name");
        }

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAccountNo, "Account Number");
        }

        private void txtAccountNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAccountNo);
        }
    }
}