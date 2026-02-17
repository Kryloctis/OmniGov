using LFS.Helpers;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Budget.Data.Factories;

namespace LFS.Budget.Views.Realignment
{
    public partial class ucRealignment : UserControl
    {
        internal int budgetId;
        internal int fundId;
        internal int fppId;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal short year;

        public ucRealignment()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbFPP),
                errorProvider1.GetError(cmbAllotmentClass),
                errorProvider1.GetError(cmbAccount),
                errorProvider1.GetError(nudAmount),
                errorProvider1.GetError(txtRemarks),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;
            cmbFPP.SelectedIndex = -1;
            cmbOthersFPP.SelectedIndex = -1;
            cmbAllotmentClass.SelectedIndex = -1;
            cmbAccount.SelectedIndex = -1;
            dtDateIssued.Value = DateTime.Now;
            txtRemarks.Text = string.Empty;
        }

        internal void LoadFunds()
        {
            cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbFunds.DisplayMember = "fund_name";
            cmbFunds.ValueMember = "id";
        }

        private void LoadAllotmentClasses()
        {
            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentClassCombobox(dtAllotmentClasses, cmbAllotmentClass, "allotment_code", "id");
        }

        internal void LoadFPP(bool isSearch)
        {
            try
            {
                cmbFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0)
                {
                    cmbFPP.DataSource = null;
                    cmbFPP.DropDownHeight = 100;
                    return;
                }
                ;

                var fppDict = new Dictionary<string, string>();

                foreach (DataRow item in DataTableFPP().Rows)
                {
                    string fppId = item["id"].ToString();
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbFPP.DataSource = new BindingSource(fppDict, null);
                cmbFPP.DisplayMember = "value";
                cmbFPP.ValueMember = "key";
                cmbFPP.DropDownHeight = 400;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            byte fppId = Convert.ToByte(cmbFPP.SelectedValue);
            HelperLoadRecords.OthersFPPCombobox(Factory.SubFPPRepository().GetRecordsByFppId(fppId), cmbOthersFPP, "name", "id");
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }

        private void LoadBudgetAppropriationAccounts()
        {
            try
            {
                if (DatatableAccounts().Rows.Count == 0)
                {
                    cmbAccount.DataSource = null;
                    cmbAccount.Items.Clear();
                    return;
                }

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["general_ledger_accounts_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbAccount.DataSource = new BindingSource(accountDict, null);
                cmbAccount.DisplayMember = "value";
                cmbAccount.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtRealignmentAccounts;
            dtRealignmentAccounts = BudgetFactory.BudgetAppropriationsRepository().GetViewRecordsByFPPIdAndFundIdAndAllotmentClassIdAndDateEntryAndBudgetAppropriationId(fppId.ToString(), othersFPPId, fundId, allotmentClassId, dtDateIssued.Value, budgetId);
            return dtRealignmentAccounts;
        }

        private void ucRealignment_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadBudgetAppropriationAccounts();
                LoadFunds();
                LoadAllotmentClasses();
                LoadFPP(false);
                LoadOthersFPPByFPPIdCombobox();
                FilterSearchDetails();
                ResetForm();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SetAmountFields();
        }

        private void SetAmountFields()
        {
            decimal appropriationBalance = Convert.ToDecimal(txtAppropriationBalance.Text);

            nudAmount.Maximum = appropriationBalance;
            nudAmount.Value = appropriationBalance;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private string GetBudgetIdByGeneralLedgerAccountId(string generalLedgerId)
        {
            return BudgetFactory.BudgetAppropriationsRepository().GetBudgetIdByGeneralLedgerId(generalLedgerId);
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbAccount.Text))
                {
                    cmbAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                    LoadBudgetAppropriationAccounts();
                    cmbAccount.SelectedIndex = -1;
                    cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void FilterSearchDetails()
        {
            fundId = Convert.ToInt32(cmbFunds.SelectedValue);
            fppId = Convert.ToInt32(cmbFPP.SelectedValue);
            othersFPPId = Convert.ToInt32(cmbOthersFPP.SelectedValue) == 0 ? null : Convert.ToInt32(cmbOthersFPP.SelectedValue);
            allotmentClassId = Convert.ToInt32(cmbAllotmentClass.SelectedValue);
            year = (short)dtDateIssued.Value.Year;

            LoadBudgetAppropriationAccounts();
        }

        private void cmbOthersFPP_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbOthersFPP.Text))
            {
                FilterSearchDetails();
            }
        }

        private void cmbFPP_DropDownClosed(object sender, EventArgs e)
        {
            LoadOthersFPPByFPPIdCombobox();
            FilterSearchDetails();
        }

        private void cmbFunds_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }

        private void cmbOthersFPP_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }

        private void cmbAllotmentClass_DropDownClosed(object sender, EventArgs e)
        {
            FilterSearchDetails();
        }

        #region Validations

        private void cmbAllotmentClass_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbAllotmentClass, "allotment class");

                if (!string.IsNullOrWhiteSpace(cmbAllotmentClass.Text))
                    e.Cancel = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAllotmentClass_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbAllotmentClass);
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRemarks, "Remark");
        }

        private void txtRemarks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRemarks);
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbFPP, "FPP");

                if (!string.IsNullOrWhiteSpace(cmbFPP.Text))
                    e.Cancel = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbFPP);
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbAccount, "accounts");

                if (!string.IsNullOrWhiteSpace(cmbAccount.Text))
                    e.Cancel = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAmount, "amount");

                decimal appropriationBalance = Convert.ToDecimal(txtAppropriationBalance.Text);
                decimal realignmentAmount = nudAmount.Value;
                decimal remainingBalance = appropriationBalance - realignmentAmount;

                bool isBudgetNotEnough = remainingBalance < 0;

                if (isBudgetNotEnough)
                {
                    errorProvider1.SetError(nudAmount, "insufficient budget appropriation to realign.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        #endregion Validations
    }
}

