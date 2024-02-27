using ACC.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class ucBankDeposits : UserControl
    {
        internal int Id;
        internal int bankId;
        internal int fundId;
        internal int userid;

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

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadBanks();
                LoadBankAccounts();
                LoadFunds();
            }
        }

        private void ucBankDeposit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void ResetForm()
        {
            txtReferenceNumber.Clear();
            dtDate.Value = DateTime.Now;
            nudAmount.Value = Convert.ToDecimal("0.00");
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbBank.DataSource = dtBank;
                cmbBank.ValueMember = "id";
                cmbBank.DisplayMember = "bank_name";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadFunds()
        {
            var fundsRepository = AccFactory.FundsRepository();
            var dtfunds = fundsRepository.GetRecords();

            HelperLoadRecords.FundsComboBox(dtfunds, cmbFund, "fund_name", "id");
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
            LoadBankAccounts();
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }
    }
}