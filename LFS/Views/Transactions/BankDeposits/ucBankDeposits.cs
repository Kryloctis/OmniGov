using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.BankDeposits
{
    public partial class ucBankDeposits : UserControl
    {
        private bool isEdit;
        private int? bankDepositId;

        public ucBankDeposits()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbBank),
                errorProvider1.GetError(cmbFund),
                errorProvider1.GetError(txtReferenceNumber),
                errorProvider1.GetError(nudAmount)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadSelectedRecords()
        {
            var dictBankDeposits = AccFactory.BankDepositsRepository().GetViewRecordById(bankDepositId.Value);
            txtAccountableOfficer.Text = Helper.GetUserDataById(Convert.ToInt32(dictBankDeposits["created_by"]))["user_full_name"];
            cmbFund.SelectedValue = dictBankDeposits["funds_id"];
            cmbBank.SelectedValue = dictBankDeposits["banks_id"];
            cmbBankAccounts.SelectedValue = dictBankDeposits["bank_accounts_id"];
            txtReferenceNumber.Text = dictBankDeposits["reference"];
            dtDate.Value = Convert.ToDateTime(dictBankDeposits["date"]);
            nudAmount.Value = Convert.ToDecimal(dictBankDeposits["amount"]);
            errorProvider1.Clear();
        }

        internal void OnLoad(bool isEdit, int? bankDepositId)
        {
            if (!DesignMode)
            {
                this.isEdit = isEdit;
                this.bankDepositId = bankDepositId;
                LoadBanks();
                LoadBankAccounts();
                LoadFunds();

                if (isEdit)
                {
                    LoadSelectedRecords();
                }
                else
                {
                    ResetForm();
                    txtAccountableOfficer.Text = Helper.LoggedInUserData()["user_full_name"];
                }
            }
        }

        private BankDepositsModel BankDepositsModel()
        {
            return new BankDepositsModel()
            {
                Reference = txtReferenceNumber.Text.Trim(),
                Date = dtDate.Value,
                FundId = Convert.ToInt32(cmbFund.SelectedValue),
                BankAccountsID = Convert.ToInt32(cmbBankAccounts.SelectedValue),
                Amount = nudAmount.Value,
            };
        }

        internal bool Save(ref bool isEdit)
        {
            isEdit = this.isEdit;

            if (!this.ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            if (this.isEdit)
            {
                var model = BankDepositsModel();
                model.Id = bankDepositId.Value;
                model.UpdatedBy = Helper.userId;
                return AccFactory.BankDepositsRepository().Update(model);
            }
            else
            {
                var model = BankDepositsModel();
                model.CreatedBy = Helper.userId;
                return AccFactory.BankDepositsRepository().Insert(model);
            }
        }

        internal void ResetForm()
        {
            txtReferenceNumber.Clear();
            dtDate.Value = Helper.GetCurrentDate();
            nudAmount.Value = 0;
            LoadBanks();
            LoadBankAccounts();
            LoadFunds();
            errorProvider1.Clear();
        }

        private void LoadBanks()
        {
            var dataTable = AccFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dataTable, cmbBank, "id", "bank_name");
        }

        private void LoadFunds()
        {
            var dataTable = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dataTable, cmbFund, "fund_name", "id");
        }

        private void cmbbanks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbBank, "Banks.");
        }

        private void cmbbanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbBank);
        }

        private void cmbfunds_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbFund, "Fund.");
        }

        private void cmbfunds_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbFund);
        }

        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReferenceNumber, "Reference.");
        }

        private void txtreference_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReferenceNumber);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAmount, "Amount.");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);
            HelperLoadRecords.BankAccountsComboBox(dtBankAccounts, cmbBankAccounts, "id", "account_no");
        }
    }
}