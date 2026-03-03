using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.Banks
{
    public partial class ucBanks : UserControl
    {
        private int bankId;
        private bool isEdit;

        public ucBanks()
        {
            InitializeComponent();
        }

        private void LoadSelectedRecord(int bankId)
        {
            var dictBank = TreasuryFactory.BanksRepository().GetRecordByID(bankId);
            txtBankCode.Text = dictBank["bank_code"];
            txtBankName.Text = dictBank["bank_name"];
            txtBankBranch.Text = dictBank["bank_branch"];
        }

        internal BanksModel BanksModel()
        {
            return new BanksModel()
            {
                BankCode = txtBankCode.Text.Trim(),
                BankName = txtBankName.Text.Trim(),
                BankBranch = txtBankBranch.Text.Trim(),
            };
        }

        internal void OnLoad(bool isEdit, int? bankId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.bankId = bankId.Value;
                LoadSelectedRecord(this.bankId);
            }
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
                errorProvider1.GetError(txtBankName)
            };
            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void txtbankname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBankName, "bank name.");
        }

        private void txtbankname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtBankName);
        }
    }
}