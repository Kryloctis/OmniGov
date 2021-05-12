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

        internal void LoadFPPRecords()
        {
            try
            {
                cmbxFPP.SelectedValueChanged -= new EventHandler(cmbxFPP_SelectedValueChanged);
                HelperLoadRecords.FPPComboBox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
                cmbxFPP.SelectedValueChanged += new EventHandler(cmbxFPP_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOtherFPPRecords()
        {
            try
            {
                if (cmbxFPP.SelectedIndex < 0 || string.IsNullOrEmpty(cmbxFPP.Text))
                {
                    cmbxOthersFPP.Enabled = false;
                    cmbxOthersFPP.DataSource = null;
                }
                else
                {
                    int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                    HelperLoadRecords.BudgetAppropriationsOthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppId), cmbxOthersFPP, "name", "id");
                    cmbxOthersFPP.SelectedIndex = -1;
                    cmbxOthersFPP.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadAllotmentClassRecords()
        {
            try
            {
                cmbxAllotmentClass.SelectedValueChanged -= new EventHandler(cmbxAllotmentClass_SelectedValueChanged);
                HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_name", "id");
                cmbxAllotmentClass.SelectedValueChanged += new EventHandler(cmbxAllotmentClass_SelectedValueChanged);
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void LoadGeneralLedgerAccounts()
        {
            try
            {
                if (cmbxAllotmentClass.SelectedIndex < 0 || string.IsNullOrEmpty(cmbxAllotmentClass.Text))
                {
                    cmbxLedgerAccount.Enabled = false;
                    cmbxLedgerAccount.DataSource = null;
                }
                else
                {
                    if (Convert.ToInt32(cmbxAllotmentClass.SelectedValue) == 4)
                    {
                        HelperLoadRecords.BudgetAppropriationsGeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetAllViewRecords(), cmbxLedgerAccount, "ledger_name", "general_ledger_accounts_id");
                    }
                    else
                    {
                        HelperLoadRecords.BudgetAppropriationsGeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(cmbxAllotmentClass.Text.Trim()), cmbxLedgerAccount, "ledger_name", "general_ledger_accounts_id");
                    }

                    cmbxLedgerAccount.Enabled = true;
                    cmbxLedgerAccount.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);

            }
        }

        internal void LoadTypeOfFund()
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

        private void cmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOtherFPPRecords();
        }

        private void cmbxAllotmentClass_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadGeneralLedgerAccounts();
        }


        //combobox fpp

        private bool ShowErrorFPPNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            try
            {
                if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text))
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

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epFunctionProgramProject, cmbxFPP, "Function Program Project");
            }
            else 
            {
                e.Cancel = ShowErrorFPPNameExist(epFunctionProgramProject, cmbxFPP, "Invalid FPP. Please select on the list.");
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

        private bool ShowErrorAllotmentClassNameExist(ErrorProvider ep, ComboBox comboBox, string fieldText)
        {
            try
            {
                if (!Factory.AllotmentClassesRepository().NameExist(cmbxAllotmentClass.Text))
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

        private void cmbxAllotmentClass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAllotmentClass.Text))
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAllotmentClass, cmbxAllotmentClass, "Allotment Class");
            }
            else 
            {
                e.Cancel = ShowErrorAllotmentClassNameExist(epAllotmentClass, cmbxAllotmentClass, "Invalid Allotment Class. Please select on the list.");
            }
        }

        private void cmbxAllotmentClass_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAllotmentClass, cmbxAllotmentClass);
        }

        //combobox account

        private bool ShowErrorLedgerNameExist()
        {
            try
            {
                if (!Factory.GeneralLedgerAccountsRepository().NameExist(cmbxLedgerAccount.Text))
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
            else if (ShowErrorLedgerNameExist())
                e.Cancel = ShowErrorLedgerNameExist();
            else if(ShowErrorBudgetAppropriationContinuing())
                e.Cancel = ShowErrorBudgetAppropriationContinuing();
            else
                e.Cancel = ShowErrorBudgetAppropriationExist();
        }

        private void cmbxLedgerAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxLedgerAccount);
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
        private void cmbxTypeOfFund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epTypeOfFund, cmbxTypeOfFund, "Type of Fund");
        }

        private void cmbxTypeOfFund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epTypeOfFund, cmbxTypeOfFund);
        }

    }
}
