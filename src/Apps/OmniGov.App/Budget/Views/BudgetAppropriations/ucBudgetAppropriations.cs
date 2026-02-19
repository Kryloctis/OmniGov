using Budget.Data.Factories;
using OmniGov.App.Budget.Helpers;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OmniGov.App.Budget.Views.BudgetAppropriations
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
            decimal totalSupplementalApprorpriationAmount = BudgetFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(budgetAppropriationId);

            if (totalSupplementalApprorpriationAmount == 0)
                return;

            toolTip1.ToolTipTitle = "Info.";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ShowAlways = true;
            string message = $"This Object Expenditure have the following: \n ? Supplemental Appropriation: {totalSupplementalApprorpriationAmount.ToString("N2")}";
            toolTip1.SetToolTip(nudAmount, message);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epOthersFunctionProgramProject.GetError(cmbxOthersFPP),
                epGeneralLedgerAcc.GetError(cmbxAccount),
                epAmount.GetError(nudAmount),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadSubFPPByFPPIdCombobox(int fppId)
        {
            HelperLoadRecords.OthersFPPCombobox(Factory.SubFPPRepository().GetRecordsByFppId(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
        }

        private void LoadAccounts()
        {
            cmbxAccount.DroppedDown = false;

            string searchKey = cmbxAccount.Text?.Trim() ?? string.Empty;
            string allotmentClass = txtAllotmentClass.Text?.Trim() ?? string.Empty;

            // Get text after the last dash safely
            string allotmentClassName = allotmentClass.Contains('-')
                ? allotmentClass.Substring(allotmentClass.LastIndexOf('-') + 1).Trim()
                : allotmentClass;

            // Get filtered accounts
            var dataSource = BudgetHelper.GetAccountsByAllotmentClass(allotmentClassName, searchKey);

            if (dataSource.Rows.Count == 0) return;

            // Build dictionary using LINQ for cleaner code
            var accountDict = dataSource.AsEnumerable()
                .ToDictionary(
                    row => Convert.ToInt32(row["general_ledger_accounts_id"]),
                    row => $"{row["account_code"]} - {row["ledger_name"]}"
                );

            // Bind to ComboBox
            cmbxAccount.DataSource = new BindingSource(accountDict, null);
            cmbxAccount.DisplayMember = "Value";
            cmbxAccount.ValueMember = "Key";

            // Clear previous error (if any)
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxAccount);
        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    cmbxAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                    LoadAccounts();
                    cmbxAccount.SelectedIndex = -1;
                    cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && cmbxAccount.FindStringExact(cmbxAccount.Text) == -1 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    LoadAccounts();
                    cmbxAccount.DroppedDown = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            var fppRepo = Factory.FunctionProgramProjectRepository().GetRecordByID(fppId);
            var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
            var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);

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

        private void ucBudgetAppropriations_Load(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    OnLoad();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ShowErrorOthersFPPNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            if (!Factory.SubFPPRepository().NameExist(cmbxOthersFPP.Text) && !string.IsNullOrWhiteSpace(cmbxOthersFPP.Text))
            {
                ep.SetError(comboBox, fieldText);
                return true;
            }
            else
                return false;
        }

        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = ShowErrorOthersFPPNameExist(epOthersFunctionProgramProject, cmbxOthersFPP, "Invalid Others FPP. Please select on the list.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFunctionProgramProject, cmbxOthersFPP);
        }

        private bool ShowErrorLedgerNameNotExist()
        {
            if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
            {
                epGeneralLedgerAcc.SetError(cmbxAccount, "Invalid General Ledger Account. Please select on the list.");
                return true;
            }
            else
                return false;
        }

        private bool ShowErrorBudgetAppropriationContinuing()
        {
            int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
            int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);

            bool budgetAppropriationExist;

            if (budgetAppropriationId == 0)
                budgetAppropriationExist = BudgetFactory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
            else
                budgetAppropriationExist = BudgetFactory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);

            if (budgetAppropriationExist)
            {
                epGeneralLedgerAcc.SetError(cmbxAccount, "Account you entered is not allowed. Account has continuing appropriation already exist on your record.");
                return true;
            }
            else
                return false;
        }

        private bool ShowErrorBudgetAppropriationExist()
        {
            int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
            int generalLedgerAccId = Convert.ToInt32(cmbxAccount.SelectedValue);
            string remarks = txtRemarks.Text;

            bool budgetAppropriationExist;

            if (budgetAppropriationId == 0)
                budgetAppropriationExist = BudgetFactory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);
            else
                budgetAppropriationExist = BudgetFactory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);

            if (budgetAppropriationExist)
            {
                epGeneralLedgerAcc.SetError(cmbxAccount, "Account you entered is not allowed. Budget appropriation already exist on your record.");
                return true;
            }
            else
                return false;
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                AmountValidation(e);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void AmountValidation(CancelEventArgs e)
        {
            decimal totalSupplementalApprorpriationAmount = BudgetFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_BudgetAppropriationsId(budgetAppropriationId);

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

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }
    }
}