using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        internal string GetFormErrors()
        {
            var errorArray = new string[3];

            errorArray[0] = epOthersFunctionProgramProject.GetError(cmbxOthersFPP);
            errorArray[1] = epGeneralLedgerAcc.GetError(cmbxLedgerAccount);
            errorArray[2] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
        }


        //combobox others fpp 

        private bool ShowErrorOthersFPPNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            try
            {
                if (!Factory.OthersFPPRepository().NameExist(cmbxOthersFPP.Text) && !string.IsNullOrWhiteSpace(cmbxOthersFPP.Text))
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
        

        //combobox account

        private bool ShowErrorLedgerNameNotExist()
        {
            try
            {
                if (cmbxLedgerAccount.FindStringExact(cmbxLedgerAccount.Text) < 0 && !string.IsNullOrEmpty(cmbxLedgerAccount.Text))
                {
                    epGeneralLedgerAcc.SetError(cmbxLedgerAccount, "Invalid General Ledger Account. Please select on the list.");
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
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
                else
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);

                if (budgetAppropriationExist)
                {
                    epGeneralLedgerAcc.SetError(cmbxLedgerAccount, "Account you entered is not allowed. Account has continuing appropriation already exist on your record.");
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
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);
                string remarks = txtRemarks.Text;

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);
                else
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year, remarks);
                
                if (budgetAppropriationExist)
                {
                    epGeneralLedgerAcc.SetError(cmbxLedgerAccount, "Account you entered is not allowed. Budget appropriation already exist on your record.");
                    return true;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;

        }

        private void cmbxLedgerAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxLedgerAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epGeneralLedgerAcc, cmbxLedgerAccount, "General Ledger Account");
            else if (ShowErrorLedgerNameNotExist())
                e.Cancel = ShowErrorLedgerNameNotExist();
            else if(ShowErrorBudgetAppropriationContinuing())
                e.Cancel = ShowErrorBudgetAppropriationContinuing();
            else
                e.Cancel = ShowErrorBudgetAppropriationExist();
        }

        private void cmbxLedgerAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxLedgerAccount);
        }

        private void LoadAccounts() 
        {
            try
            {
                var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
                string accountGroupName = allotmentClassRepo["allotment_name"];

                DataTable dtAccounts;

                if (Convert.ToInt32(allotmentClassId) == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByAccountGroupName("Assets");
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(accountGroupName, cmbxLedgerAccount.Text);

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in dtAccounts.Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxLedgerAccount.DataSource = new BindingSource(accountDict, null);
                cmbxLedgerAccount.DisplayMember = "value";
                cmbxLedgerAccount.ValueMember = "key";
                cmbxLedgerAccount.SelectedIndex = -1;

                Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxLedgerAccount);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxLedgerAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbxLedgerAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
                    string accountGroupName = allotmentClassRepo["allotment_name"];

                    DataTable dtAccounts;

                    if (Convert.ToInt32(allotmentClassId) == 4)
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxLedgerAccount.Text);
                    else
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(accountGroupName, cmbxLedgerAccount.Text);

                    if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbxLedgerAccount.Text.Trim())) return;

                    var accountDict = new Dictionary<int, string>();
                    foreach (DataRow item in dtAccounts.Rows)
                    {
                        int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                        string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                        accountDict.Add(accountId, accountName);
                    }

                    cmbxLedgerAccount.DataSource = new BindingSource(accountDict, null);
                    cmbxLedgerAccount.DisplayMember = "value";
                    cmbxLedgerAccount.ValueMember = "key";
                    cmbxLedgerAccount.DroppedDown = true;

                    Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxLedgerAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }


        //numeric up down amounts

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {

            decimal totalSupplementalApprorpriationAmount = Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountById(budgetAppropriationId);

            decimal appropriationAmount = nudAmount.Value;

            decimal totalAppropriationAmount = totalSupplementalApprorpriationAmount + appropriationAmount;

            if (string.IsNullOrEmpty(nudAmount.Text))
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            }
            else if (nudAmount.Value == 0)
            {
                epAmount.SetError(nudAmount, Helper.ErrorMessage("Valuable Amount"));
                e.Cancel = true;
            }
            else if(totalAppropriationAmount < totalAllotmentRelease)
            {
                epAmount.SetError(nudAmount, "Amount you entered is less than allotment released.");
                e.Cancel = true;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }


        private void ucBudgetAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var fppRepo = Factory.FunctionProgramProjectRepository().GetRecordByID(fppId);
                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var allotmentClassRepo = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
                txtFPP.Text = $"{fppRepo["fpp_code"]} - {fppRepo["fpp_name"]}";
                txtFund.Text = $"{fundRepo["fund_code"]} - {fundRepo["fund_name"]}";
                txtAllotmentClass.Text = $"{allotmentClassRepo["allotment_code"]} - {allotmentClassRepo["allotment_name"]}";
                txtYear.Text = year.ToString();
                dtDateEntry.MaxDate = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));

                LoadOthersFPPByFPPIdCombobox();
                LoadAccounts();
            }
        }
    }
}
