using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class ucBankDeposits : UserControl
    {
        internal int Id = 0;
        internal int bankId = 0;
        internal int fundId = 0;
        internal int userid = 0;

        public ucBankDeposits()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epBank.GetError(cmbBank);
            errorArray[1] = epFund.GetError(cmbFund);
            errorArray[2] = epReferenceNumber.GetError(txtReferenceNumber);
            errorArray[3] = epAmount.GetError(nudAmount);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void ucBD_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBanks();
                LoadBankAccounts();
                LoadFunds();

            }
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
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadFunds()
        {
            var fundsRepository = AccFactory.FundsRepository();
            var dtfunds = fundsRepository.GetRecords();

            HelperLoadRecords.FundsComboBox(dtfunds, cmbFund, "fund_name", "id");
        }

        #region Validations

        private void cmbbanks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epBank, cmbBank, "Banks.");
        }

        private void cmbbanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epBank, cmbBank);
        }

        private void cmbfunds_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFund, cmbFund, "Fund.");
        }

        private void cmbfunds_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFund, cmbFund);
        }

        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epReferenceNumber, txtReferenceNumber, "Reference.");
        }

        private void txtreference_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReferenceNumber, txtReferenceNumber);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount.");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations

        private void label1_Click(object sender, EventArgs e)
        {

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