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
        internal int budgetAppropriationId = 0;

        public ucBudgetAppropriations()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[6];
            errorArray[0] = epFunctionProgramProject.GetError(cmbxFPP);
            errorArray[1] = epOthersFunctionProgramProject.GetError(cmbxOthersFPP);
            errorArray[2] = epAllotmentClass.GetError(cmbxAllotmentClass);
            errorArray[3] = epGeneralLedgerAcc.GetError(cmbxLedgerAccount);
            errorArray[4] = epAmount.GetError(nudAmount);
            errorArray[5] = epBudgetAppropriation.GetError(cmbxFPP);

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
                cmbxFPP.TextChanged -= new EventHandler(cmbxFunctionProgramProject_TextChanged);
                HelperLoadRecords.FPPCombobox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
                cmbxFPP.TextChanged += new EventHandler(cmbxFunctionProgramProject_TextChanged);
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
                    HelperLoadRecords.OthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByID(fppId), cmbxOthersFPP, "name", "id");
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
                cmbxAllotmentClass.TextChanged -= new EventHandler(cmbxAllotmentClass_TextChanged);
                HelperLoadRecords.AllotmentCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClass, "allotment_name", "id");
                cmbxAllotmentClass.TextChanged += new EventHandler(cmbxAllotmentClass_TextChanged);
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
                        HelperLoadRecords.GeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetAllViewRecords(), cmbxLedgerAccount, "ledger_name", "general_ledger_accounts_id");
                    }
                    else 
                    {
                        HelperLoadRecords.GeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(cmbxAllotmentClass.Text.Trim()), cmbxLedgerAccount, "ledger_name", "general_ledger_accounts_id");
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

        #region Validations

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFunctionProgramProject, cmbxFPP, "Function Program Project");

            if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text.Trim()))
            {
                epFunctionProgramProject.SetError(cmbxFPP, "Invalid FPP. Please select on the list.");
                e.Cancel = true;
            }
        }
        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFunctionProgramProject, cmbxFPP);
        }

        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
            if (!Factory.OthersFPPRepository().NameExist(cmbxOthersFPP.Text.Trim()) && !string.IsNullOrWhiteSpace(cmbxOthersFPP.Text)) 
            {
                epOthersFunctionProgramProject.SetError(cmbxOthersFPP, "Invalid Others FPP. Please select on the list.");
                e.Cancel = true;
            }
        }
        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFunctionProgramProject, cmbxOthersFPP);
        }

        private void cmbxAllotmentClass_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAllotmentClass, cmbxAllotmentClass, "Allotment Class");

            if (!Factory.AllotmentClassesRepository().NameExist(cmbxAllotmentClass.Text.Trim()))
            {
                epAllotmentClass.SetError(cmbxAllotmentClass, "Invalid Allotment Class. Please select on the list.");
                e.Cancel = true;
            }
        }
        private void cmbxAllotmentClass_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAllotmentClass, cmbxAllotmentClass);
        }

        private void cmbxLedgerAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epGeneralLedgerAcc, cmbxLedgerAccount, "General Ledger Account");

            if (!Factory.GeneralLedgerAccountsRepository().NameExist(cmbxLedgerAccount.Text.Trim()))
            {
                epGeneralLedgerAcc.SetError(cmbxLedgerAccount, "Invalid General Ledger Account. Please select on the list.");
                e.Cancel = true;
            }
        }
        private void cmbxLedgerAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epGeneralLedgerAcc, cmbxLedgerAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");

            if (nudAmount.Value == nudAmount.Minimum || nudAmount.Value == 0) 
            {
                epAmount.SetError(nudAmount, Helper.ErrorMessage("Valuable Amount"));
                e.Cancel = true;
            }

            #region Validation of Budget Appropriration Record

            int FPPId = Convert.ToInt32(cmbxFPP.SelectedValue);
            int? othersFPPId;
            int allotmentClassId = Convert.ToInt32(cmbxAllotmentClass.SelectedValue);
            int generalLedgerAccId = Convert.ToInt32(cmbxLedgerAccount.SelectedValue);

            if (cmbxOthersFPP.SelectedValue == null)
                othersFPPId = null;
            else
                othersFPPId = Convert.ToInt32(cmbxOthersFPP.SelectedValue);


            bool budgetAppropriationExist;

            if (budgetAppropriationId == 0)
            {
                budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAllotmentExist(FPPId, othersFPPId, allotmentClassId, generalLedgerAccId);
            }
            else
            {
                budgetAppropriationExist = Factory.BudgetAppropriationsRepository().BudgetAllotmentExist(budgetAppropriationId, FPPId, othersFPPId, allotmentClassId, generalLedgerAccId);
            }

            if (budgetAppropriationExist)
            {
                epBudgetAppropriation.SetError(cmbxFPP, "Budget Appropriation you entered is not allowed. Already exist on your record.");
                e.Cancel = true;
            }

            #endregion 

        }
        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations

        private void cmbxFunctionProgramProject_TextChanged(object sender, EventArgs e)
        {
            LoadOtherFPPRecords();
        }

        private void cmbxAllotmentClass_TextChanged(object sender, EventArgs e)
        {
            LoadGeneralLedgerAccounts();
        }
    }
}
