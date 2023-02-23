using ACC.Domain.Interfaces;
using AccountingSystem.Views.Transactions.CheckIssuance.Deductions;
using AccountingSystem.Views.Transactions.CheckIssuance.Obligations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class ucRCI : UserControl
    {
        internal int Id = 0;
        internal int bankId = 0;
        internal int fundsId = 0;
        internal int functionId = 0;

        internal short obligationNumberCount = 0;
        internal decimal totalDeduction = 0;

        internal DataTable dtObligations = new();
        internal DataTable dtDeductions = new();

        public ucRCI()
        {
            InitializeComponent();
        }

        private void ucRCI_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBanks();
                LoadBankAccounts();
                LoadFunds();

                cmbFPP.SelectedValueChanged -= new EventHandler(cmbFPP_SelectedValueChanged);
                LoadFPP();
                cmbFPP.SelectedValueChanged += new EventHandler(cmbFPP_SelectedValueChanged);

                dtObligations.Columns.Add("obligation_no");
                dtObligations.Columns.Add("date_entry");
                dtDeductions.Columns.Add("description");
                dtDeductions.Columns.Add("amount");
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }

        internal void LoadFPP()
        {
            try
            {
                cmbFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbFPP.DataSource = new BindingSource(fppDict, null);
                cmbFPP.DisplayMember = "value";
                cmbFPP.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }

        internal void ResetForm()
        {
            txtDVNo.Clear();
            cmbfund.SelectedIndex = -1;
            bankId = fundsId = functionId = 0;
            cmbBank.SelectedIndex = -1;
            txtCheckNo.Clear();
            cmbFPP.SelectedIndex = -1;
            dtCheckDate.Value = DateTime.Now;
            txtPayee.Clear();
            txtNature.Clear();
            nudNetAmount.Value = Convert.ToDecimal("0.00");

            dtObligations.Rows.Clear();
            dtDeductions.Rows.Clear();

            btnAddObligation.Text = "Click to add obligation no.";
            btnAddDeductions.Text = "Click to add deductions.";
        }

        internal void LoadFunds()
        {
            try
            {
                var fundRepository = AccFactory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                dtFund.Columns.Add("funddisplay", typeof(string), "fund_code + ' - ' + fund_name");
                cmbfund.DataSource = dtFund;
                cmbfund.ValueMember = "id";
                cmbfund.DisplayMember = "funddisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadBanks()
        {
            try
            {
                var fundRepository = AccFactory.BanksRepository();
                var dtBank = fundRepository.GetRecords();
                cmbBank.DataSource = dtBank;
                cmbBank.ValueMember = "id";
                cmbBank.DisplayMember = "bank_name";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void SetSelectedValue(int Id, string table)
        {
            try
            {
                if (!string.IsNullOrEmpty(table) || Id > 0)
                {
                    if (table.Equals("functions"))
                    {
                        var functionRepository = AccFactory.FunctionProgramProjectRepository();
                        var functionData = functionRepository.GetRecordByID(Id);
                        functionId = Convert.ToInt16(functionData["id"]);
                        cmbFPP.Text = String.Format("{0} - {1}", functionData["fpp_code"], functionData["fpp_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public void LoadSelectedFunction(int Id, string value)
        {
            functionId = Id;
            cmbFPP.Text = value;
        }

        internal void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFPP.Text))
            {
                cmbFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP();
                cmbFPP.SelectedIndex = -1;
                cmbFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        internal void cmbFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            functionId = Convert.ToInt32(cmbFPP.SelectedValue);
        }

        private void btnAddObligation_Click(object sender, EventArgs e)
        {
            _ = new frmObligations(this).ShowDialog();
        }

        private void btnAddDeductions_Click(object sender, EventArgs e)
        {
            _ = new frmDeductions(this).ShowDialog();
        }

        internal void SetObligationLabel()
        {
            obligationNumberCount = (short)dtObligations.Rows.Count;
            btnAddObligation.Text = $"({obligationNumberCount}) obligation/s number added.";
        }

        internal void SetDeductionLabel()
        {
            foreach (DataRow row in dtDeductions.Rows)
                totalDeduction += Convert.ToDecimal(row[1].ToString());

            btnAddDeductions.Text = $"({totalDeduction:N2}) total deductions.";
            totalDeduction = 0;
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = epFund.GetError(cmbfund);
            errorArray[1] = epBank.GetError(cmbBank);
            errorArray[2] = epCheckNo.GetError(txtCheckNo);
            errorArray[3] = epCheckDate.GetError(dtCheckDate);
            errorArray[4] = epPayee.GetError(txtPayee);
            errorArray[5] = epNatureOfPayment.GetError(txtNature);
            errorArray[6] = epNetAmount.GetError(nudNetAmount);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtdvno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epDVNo, txtDVNo, "Disbursement No.");
        }

        private void txtdvno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epDVNo, txtDVNo);
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFund, cmbfund, "Fund.");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFund, cmbfund);
        }

        private void cmbbank_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epBank, cmbBank, "Bank.");
        }

        private void cmbbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epBank, cmbBank);
        }

        private void txtcheckno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCheckNo, txtCheckNo, "Check No.");
        }

        private void txtcheckno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCheckNo, txtCheckNo);
        }

        private void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtPayee, "Payee");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
        }

        private void txtnature_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epNatureOfPayment, txtNature, "Nature of Payment");
        }

        private void txtnature_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epNatureOfPayment, txtNature);
        }

        private void txtamount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epNetAmount, nudNetAmount, "Net Amount.");
        }

        private void txtamount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epNetAmount, nudNetAmount);
        }

        #endregion Validations

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }
    }
}