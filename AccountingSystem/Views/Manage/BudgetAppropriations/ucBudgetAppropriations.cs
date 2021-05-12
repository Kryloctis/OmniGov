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
        internal int fundId;
        internal int budgetAppropriationId;
        internal int fppId;
        internal int? othersFPPId;
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
            var errorArray = new string[7];

            errorArray[0] = epTypeOfFund.GetError(cmbxTypeOfFund);
            errorArray[1] = epFunctionProgramProject.GetError(cmbxFPP);
            errorArray[2] = epOthersFunctionProgramProject.GetError(cmbxOthersFPP);
            errorArray[3] = epAllotmentClass.GetError(cmbxAllotmentClass);
            errorArray[4] = epGeneralLedgerAcc.GetError(cmbxLedgerAccount);
            errorArray[5] = epYear.GetError(nudYear);
            errorArray[6] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxFPP.SelectedIndex = -1;
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxAllotmentClass.SelectedIndex = -1;
            cmbxLedgerAccount.SelectedIndex = -1;
            nudAmount.Value = nudAmount.Minimum;
        }


        //combobox fpp

        internal void LoadFPPRecords()
        {
            try
            {
                HelperLoadRecords.FPPComboBox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
                cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
                cmbxFPP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOthersFPPByFPPIdCombobox()
        {
            var fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxOthersFPP.Text = string.Empty;
            cmbxOthersFPP.Enabled = true;
        }

        private bool ShowErrorFPPNameExist()
        {
            try
            {
                if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text) && !string.IsNullOrEmpty(cmbxFPP.Text))
                {
                    epFunctionProgramProject.SetError(cmbxFPP, "Invalid FPP. Please select on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (ShowErrorFPPNameExist())
            {
                cmbxOthersFPP.Enabled = false;
                cmbxOthersFPP.SelectedIndex = -1;
                cmbxOthersFPP.Text = string.Empty;
            }
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOthersFPPByFPPIdCombobox();
        }

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epFunctionProgramProject, cmbxFPP, "Function Program Project");
            }
            else 
            {
                e.Cancel = ShowErrorFPPNameExist();
            }
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFunctionProgramProject, cmbxFPP);
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

        

        //combobox allotment classes

        internal void LoadAllotmentClassRecords()
        {
            try
            {
                HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_name", "id");

                cmbxAllotmentClass.SelectedValueChanged += new EventHandler(CmbxAllotmentClass_SelectedValueChanged);
                cmbxAllotmentClass.TextChanged += new EventHandler(CmbxAllotmentClass_TextChanged);
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        private void CmbxAllotmentClass_SelectedValueChanged(object  sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAllotmentClass.Text) || ShowErrorAllotmentClassNameNotExist())
            {
                cmbxLedgerAccount.DataSource = null;
                cmbxLedgerAccount.Text = string.Empty;
                cmbxLedgerAccount.Enabled = false;
            }
            else
            { 
                cmbxLedgerAccount.Enabled = true;
                LoadAccounts();
            }
        }
         
        private void CmbxAllotmentClass_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbxAllotmentClass.Text) || ShowErrorAllotmentClassNameNotExist())
            {
                cmbxLedgerAccount.DataSource = null;
                cmbxLedgerAccount.Text = string.Empty;
                cmbxLedgerAccount.Enabled = false;
            }
            else
            {
                cmbxLedgerAccount.Enabled = true;
                LoadAccounts();
            }
        }

        private bool ShowErrorAllotmentClassNameNotExist()
        {
            try
            {
                if (!Factory.AllotmentClassesRepository().NameExist(cmbxAllotmentClass.Text) && !string.IsNullOrEmpty(cmbxAllotmentClass.Text))
                {
                    epAllotmentClass.SetError(cmbxAllotmentClass, "Invalid Allotment Class. Please select on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxAllotmentClass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAllotmentClass.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAllotmentClass, cmbxAllotmentClass, "Allotment Class");
            else 
                e.Cancel = ShowErrorAllotmentClassNameNotExist();
        }

        private void CmbxAllotmentClass_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAllotmentClass, cmbxAllotmentClass);
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

                int fundID = Convert.ToInt32(cmbxTypeOfFund.SelectedValue);
                int FPPId = Convert.ToInt32(cmbxFPP.SelectedValue);
                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);


                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundID, FPPId, othersFPPId, allotmentClassId, generalLedgerAccId);
                }
                else
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundID, FPPId, othersFPPId, allotmentClassId, generalLedgerAccId);
                }

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
                #region Validation of Budget Appropriration Record

                int fundID = Convert.ToInt32(cmbxTypeOfFund.SelectedValue);
                int FPPId = Convert.ToInt32(cmbxFPP.SelectedValue);
                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);
                short year = Convert.ToInt16(nudYear.Value);

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundID, FPPId, othersFPPId, allotmentClassId, generalLedgerAccId, year);
                }
                else
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundID, FPPId, othersFPPId, allotmentClassId, generalLedgerAccId, year);
                }

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
                string accountGroupName = cmbxAllotmentClass.Text;
                DataTable dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(accountGroupName);

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
                    DataTable dtAccounts;

                    if (Convert.ToInt32(cmbxAllotmentClass.SelectedValue) == 4)
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbxLedgerAccount.Text);
                    else
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(cmbxAllotmentClass.Text, cmbxLedgerAccount.Text);

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



        //numeric up down year

        private void nudYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epYear, nudYear, "Year");
        }

        private void nudYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epYear, nudYear);
        }



        //combobox funds

        internal void LoadFunds()
        {
            try
            {
                HelperLoadRecords.BudgetAppropriationsTypeOfFundsCombobox(Factory.FundsRepository().GetRecords(), cmbxTypeOfFund, "fund_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxTypeOfFund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epTypeOfFund, cmbxTypeOfFund, "Type of Fund");
        }

        private void cmbxTypeOfFund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epTypeOfFund, cmbxTypeOfFund);
        }



        private void ucBudgetAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadFPPRecords();
                LoadAllotmentClassRecords();
                LoadFunds();
                ResetForm();
                nudYear.Value = DateTime.Now.Year;

                cmbxOthersFPP.Enabled = false;
                cmbxLedgerAccount.Enabled = false;
            }
        }
    }
}
