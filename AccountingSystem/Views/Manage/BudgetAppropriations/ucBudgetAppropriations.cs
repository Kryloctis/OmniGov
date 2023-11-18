using ACC.Data;
using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class ucBudgetAppropriations : UserControl
    {
        internal int budgetAppropriationId;
        internal int fppId;
        internal int? othersFPPId;
        internal int fundId;
        internal int allotmentClassId;
        internal int generalLedgerAccountId;
        internal short year;
        internal decimal totalAllotmentRelease;

        public ucBudgetAppropriations()
        {
            InitializeComponent();
        }

        private void SetAppropriationInfoToolTip()
        {
            decimal totalSupplementalApprorpriationAmount = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(budgetAppropriationId);

            if (totalSupplementalApprorpriationAmount == 0)
                return;

            toolTip1.ToolTipTitle = "Info.";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ShowAlways = true;
            string message = $"This Object Expenditure have the following: \n ● Supplemental Appropriation: {totalSupplementalApprorpriationAmount.ToString("N2")}";
            toolTip1.SetToolTip(nudAmount, message);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];

            errorArray[0] = epOthersFunctionProgramProject.GetError(cmbxOthersFPP);
            errorArray[1] = epGeneralLedgerAcc.GetError(cmbxAccount);
            errorArray[2] = epAmount.GetError(nudAmount);

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadSubFPPByFPPIdCombobox(int fppId)
        {
            HelperLoadRecords.OthersFPPCombobox(AccFactory.SubFPPRepository().GetRecordsByFPPId(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
        }

        #region Validations

        #region Sub FPP Validation

        private bool ShowErrorOthersFPPNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            try
            {
                if (!AccFactory.SubFPPRepository().NameExist(cmbxOthersFPP.Text) && !string.IsNullOrWhiteSpace(cmbxOthersFPP.Text))
                {
                    ep.SetError(comboBox, fieldText);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ShowErrorOthersFPPNameExist(epOthersFunctionProgramProject, cmbxOthersFPP, "Invalid Others FPP. Please select on the list.");
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFunctionProgramProject, cmbxOthersFPP);
        }

        #endregion Sub FPP Validation

        #region Account Validation

        private bool ShowErrorLedgerNameNotExist()
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    epGeneralLedgerAcc.SetError(cmbxAccount, "Invalid General Ledger Account. Please select on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorBudgetAppropriationContinuing()
        {
            try
            {
                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = AccFactory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
                else
                    budgetAppropriationExist = AccFactory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);

                if (budgetAppropriationExist)
                {
                    epGeneralLedgerAcc.SetError(cmbxAccount, "Account you entered is not allowed. Account has continuing appropriation already exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorBudgetAppropriationExist()
        {
            try
            {
                #region Validation of Budget Appropriation Record

                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);
                string remarks = txtRemarks.Text;

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = AccFactory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);
                else
                    budgetAppropriationExist = AccFactory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);

                if (budgetAppropriationExist)
                {
                    epGeneralLedgerAcc.SetError(cmbxAccount, "Account you entered is not allowed. Budget appropriation already exist on your record.");
                    return true;
                }

                #endregion Validation of Budget Appropriation Record
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epGeneralLedgerAcc, cmbxAccount, "General Ledger Account");
            else if (ShowErrorLedgerNameNotExist())
                e.Cancel = ShowErrorLedgerNameNotExist();
            else if (ShowErrorBudgetAppropriationContinuing())
                e.Cancel = ShowErrorBudgetAppropriationContinuing();
            else
                e.Cancel = ShowErrorBudgetAppropriationExist();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxAccount);
        }

        #endregion Account Validation

        #region Amount Validation

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            AmountValidation(e);
        }

        private void AmountValidation(CancelEventArgs e)
        {
            try
            {
                decimal totalSupplementalApprorpriationAmount = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(budgetAppropriationId);

                decimal appropriationAmount = nudAmount.Value;

                decimal totalAppropriationAmount = totalSupplementalApprorpriationAmount + appropriationAmount;

                if (string.IsNullOrEmpty(nudAmount.Text))
                    e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
                else if (totalAppropriationAmount == 0)
                {
                    epAmount.SetError(nudAmount, Helper.ErrorMessage("Amount"));
                    e.Cancel = true;
                }
                else if (totalAppropriationAmount < totalAllotmentRelease)
                {
                    epAmount.SetError(nudAmount, "Amount you entered is less than allotment released.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Amount Validation

        #endregion Validations

        #region General Ledgers Accounts

        private DataTable DatatableAccounts()
        {
            var allotmentClassRepo = AccFactory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
            string accountGroupName = allotmentClassRepo["allotment_name"];

            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupName("Assets");
                else
                    dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupName(accountGroupName);
            }
            else
            {
                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupNameSearch("Assets", cmbxAccount.Text);
                else
                    dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsByMajorAccGroupNameSearch(accountGroupName, cmbxAccount.Text);
            }

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            try
            {
                cmbxAccount.DroppedDown = false;

                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxAccount.DataSource = new BindingSource(accountDict, null);
                cmbxAccount.DisplayMember = "value";
                cmbxAccount.ValueMember = "key";
                Cursor.Current = Cursors.Default;

                Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                cmbxAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadAccounts();
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxAccount.FindStringExact(cmbxAccount.Text) == -1 && !string.IsNullOrEmpty(cmbxAccount.Text))
            {
                LoadAccounts();
                cmbxAccount.DroppedDown = true;
            }
        }

        #endregion General Ledgers Accounts

        private void OnLoad()
        {
            try
            {
                var fppRepo = AccFactory.FunctionProgramProjectRepository().GetRecordByID(fppId);
                var fundRepo = AccFactory.FundsRepository().GetRecordByID(fundId);
                var allotmentClassRepo = AccFactory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

                txtFPP.Text = $"{fppRepo["fpp_code"]} - {fppRepo["fpp_name"]}";
                txtFund.Text = $"{fundRepo["fund_code"]} - {fundRepo["fund_name"]}";
                txtAllotmentClass.Text = $"{allotmentClassRepo["allotment_code"]} - {allotmentClassRepo["allotment_name"]}";
                txtYear.Text = year.ToString();
                dtDateEntry.MaxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
                dtDateEntry.MinDate = new DateTime(year, 1, 1);

                LoadSubFPPByFPPIdCombobox(fppId);
                LoadAccounts();
                SetAppropriationInfoToolTip();
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void ucBudgetAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                OnLoad();
            }
        }
    }
}