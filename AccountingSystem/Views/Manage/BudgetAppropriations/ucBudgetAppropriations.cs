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

            cmbxOthersFPP.Enabled = false;
            cmbxLedgerAccount.Enabled = false;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];

            errorArray[0] = epOthersFunctionProgramProject.GetError(cmbxOthersFPP);
            errorArray[1] = epAllotmentClass.GetError(cmbxAllotmentClass);
            errorArray[2] = epGeneralLedgerAcc.GetError(cmbxLedgerAccount);
            errorArray[3] = epYear.GetError(nudYear);
            errorArray[4] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxAllotmentClass.SelectedIndex = -1;
            cmbxLedgerAccount.SelectedIndex = -1;
            nudAmount.Value = nudAmount.Minimum;
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
        

        //combobox allotment classes

        internal void LoadAllotmentClassRecords()
        {
            try
            {
                cmbxAllotmentClass.SelectedValueChanged -= new EventHandler(CmbxAllotmentClass_SelectedValueChanged);
                cmbxAllotmentClass.TextChanged -= new EventHandler(CmbxAllotmentClass_TextChanged);

                HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_name", "id");

                cmbxAllotmentClass.SelectedIndex = -1;

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
                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);


                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
                }
                else
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationContinuing(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId);
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

                int? othersFPPId = string.IsNullOrEmpty(cmbxOthersFPP.Text.ToString()) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
                int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);
                short year = Convert.ToInt16(nudYear.Value);

                bool budgetAppropriationExist;

                if (budgetAppropriationId == 0)
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year);
                }
                else
                {
                    budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAppropriationExist(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, generalLedgerAccId, year);
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

                DataTable dtAccounts;

                if (Convert.ToInt32(cmbxAllotmentClass.SelectedValue) == 4)
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxLedgerAccount.Text);
                else
                    dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupNameSearch(cmbxAllotmentClass.Text, cmbxLedgerAccount.Text);

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
                        dtAccounts = Factory.GeneralLedgerAccountsRepository().GetAllViewRecordsBySearch(cmbxLedgerAccount.Text);
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

        private void ucBudgetAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var fppRepo = Factory.FunctionProgramProjectRepository().GetRecordByID(fppId);
                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                txtFPP.Text = $"{fppRepo["fpp_code"]} - {fppRepo["fpp_name"]}";
                txtFund.Text = $"{fundRepo["fund_code"]} - {fundRepo["fund_name"]}";


                LoadAllotmentClassRecords();
                LoadOthersFPPByFPPIdCombobox();
                nudYear.Value = DateTime.Now.Year;
            }
        }
    }
}
