using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class ucObligationRequest : UserControl
    {
        internal int obligationID = 0;
        internal decimal obligationRequestAmount = 0;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = epFunds.GetError(cmbxFunds);
            errorArray[1] = epFPP.GetError(cmbxFPP);
            errorArray[2] = epOthersFPP.GetError(cmbxOthersFPP);
            errorArray[3] = epAllotmentClass.GetError(cmbxAllotmentClasses);
            errorArray[4] = epAccount.GetError(cmbxAccount);
            errorArray[5] = epObligationNum.GetError(mkTxtObligationNum);
            errorArray[6] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            obligationID = 0;
            obligationRequestAmount = 0;
            cmbxFunds.SelectedIndex = -1;
            cmbxFPP.SelectedIndex = -1;
            cmbxOthersFPP.SelectedIndex = -1;
            cmbxAllotmentClasses.SelectedIndex = -1;
            cmbxAccount.SelectedIndex = -1;
            dtPickerDateIssued.Value = DateTime.Now;
            mkTxtObligationNum.Clear();
            nudAmount.Value = 0;

            cmbxFunds.Enabled = true;
            cmbxFPP.Enabled = true;
            cmbxOthersFPP.Enabled = true;
            cmbxAllotmentClasses.Enabled = true;
            cmbxAccount.Enabled = true;
            dtPickerDateIssued.Enabled = true;
        }

        internal void ResetFields() 
        {
            mkTxtObligationNum.Clear();
            nudAmount.Value = 0;
        }

        private void LoadGeneralLedgerAccountsCombobox() 
        {
            try
            {
                   if (Convert.ToInt32(cmbxAllotmentClasses.SelectedValue) == 4)
            {
                HelperLoadRecords.ObligationRequestAccountCombobox(Factory.GeneralLedgerAccountsRepository().GetAllViewRecords(), cmbxAccount, "ledger_name", "general_ledger_accounts_id");
            }
            else
            {
                  HelperLoadRecords.BudgetAppropriationsGeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(cmbxAllotmentClasses.Text.Trim()), cmbxAccount, "ledger_name", "general_ledger_accounts_id");
            }

            cmbxAccount.Enabled = true;
            cmbxAccount.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadComboboxes() 
        {
            try
            {
                HelperLoadRecords.ObligationRequestFundsCombobox(Factory.FundsRepository().GetRecords(), cmbxFunds, "fund_name", "id");
                HelperLoadRecords.ObligationRequestFPPCombobox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
             
                HelperLoadRecords.ObligationRequestAllotmentClassesCombobox(Factory.AllotmentClassesRepository().GetRecords(), cmbxAllotmentClasses, "allotment_name", "id");


                cmbxFunds.SelectedIndex = -1;
                cmbxFPP.SelectedIndex = -1;
                cmbxAllotmentClasses.SelectedIndex = -1;

                cmbxOthersFPP.Enabled = false;
                cmbxAccount.Enabled = false;
                cmbxFPP.SelectedValueChanged += new EventHandler(cmbxFPP_SelectedValueChanged);
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
                cmbxAllotmentClasses.SelectedValueChanged += new EventHandler(cmbxAllotmentClasses_SelectedValueChanged);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxFPP_SelectedValueChanged(object sender, EventArgs e) 
        {
            int fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
            cmbxOthersFPP.Enabled = true;
            HelperLoadRecords.ObligationRequestOthersFPPCombobox(Factory.OthersFPPRepository().GetRecordsByFPPID(fppID), cmbxOthersFPP, "name", "id");
            cmbxOthersFPP.SelectedIndex = -1;
        }

        private void cmbxFPP_TextChanged(object sender, EventArgs e) 
        {
            if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text.Trim())) 
            {
                cmbxOthersFPP.Enabled = false;
                cmbxOthersFPP.SelectedIndex = -1;
            }
        }

        private void cmbxAllotmentClasses_SelectedValueChanged(object sender, EventArgs e) 
        {
            if (cmbxAllotmentClasses.SelectedIndex < 0)
            {
                cmbxAccount.Enabled = false;
                cmbxAccount.SelectedIndex = -1;
            }
            else 
            {
                cmbxAccount.Enabled = true;
                LoadGeneralLedgerAccountsCombobox();
            }

        }

        #region Validations

        //private bool ShowObligationNumExistError(ErrorProvider ep, MaskedTextBox maskedTextBox, string fieldText) 
        //{
        //    try
        //    {
        //        if (obligationID == 0)
        //        {
        //            if (Factory.ObligationRequestRepository().ObligationNumExist(maskedTextBox.Text)) 
        //            {
        //                ep.SetError(maskedTextBox,$"{fieldText} is already exist on your record.");
        //                return true;
        //            }
        //        }
        //        else 
        //        {
        //            if (Factory.ObligationRequestRepository().ObligationNumExist(obligationID, maskedTextBox.Text))
        //            {
        //                ep.SetError(maskedTextBox, $"{fieldText} is already exist on your record.");
        //                return true;
        //            }
        //        }

        //    }
        //    catch (Exception ex) 
        //    {
        //        Helper.MessageBoxError(ex.Message);
        //    }
        //    return false;
        //}

        private bool ShowAmountValidationError(ErrorProvider ep, NumericUpDown numericUpDown, string fieldText) 
        {
            try
            {
                int fundID = Convert.ToInt32(cmbxFunds.SelectedValue);
                int fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
                int? othersfppID = string.IsNullOrEmpty(cmbxOthersFPP.Text) ? null : Convert.ToInt32(cmbxOthersFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(cmbxAllotmentClasses.SelectedValue);
                int accountID = Convert.ToInt32(cmbxAccount.SelectedValue);
                DateTime dateIssued = dtPickerDateIssued.Value;

                var totalAllotmentAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(fundID, fppID, othersfppID, allotmentClassID, accountID, dateIssued);

                var totalObligationAmountByYear = Factory.ObligationRequestRepository().GetTotalObligationAmountByYear(fundID, fppID, othersfppID, allotmentClassID, accountID, Convert.ToInt16(dateIssued.Year));

                var totalAllotmentBalanceAmount = Convert.ToDecimal(totalAllotmentAmount["total_allotment_amount"]) - Convert.ToDecimal(totalObligationAmountByYear["total_obligation_amount"]);

                if (obligationID == 0)
                {
                    string errorText = numericUpDown.Value > Convert.ToDecimal(totalAllotmentBalanceAmount) ?  fieldText : string.Empty;
                    bool errorBoolean = numericUpDown.Value > Convert.ToDecimal(totalAllotmentBalanceAmount) ? true : false;

                    ep.SetError(numericUpDown, errorText);
                    return errorBoolean;
                }
                else 
                {
                    string errorText = numericUpDown.Value > Convert.ToDecimal(totalAllotmentBalanceAmount) + obligationRequestAmount ? fieldText : string.Empty;
                    bool errorBoolean = numericUpDown.Value > Convert.ToDecimal(totalAllotmentBalanceAmount) + obligationRequestAmount ? true : false;

                    ep.SetError(numericUpDown, errorText);
                    return errorBoolean;
                }
            
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxFunds_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFunds.Text))
            {
                epFunds.SetError(cmbxFunds, "Fund is required.");
                e.Cancel = true;
            }
        }
        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFunds, cmbxFunds);
        }

        private void cmbxAllotmentClasses_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAllotmentClasses.Text))
            {
                epAllotmentClass.SetError(cmbxAllotmentClasses, "Allotment Class required.");
                e.Cancel = true;
            }
        }
        private void cmbxAllotmentClasses_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAllotmentClass, cmbxAllotmentClasses);
        }

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                epFPP.SetError(cmbxFPP, "FPP is Required.");
                e.Cancel = true;
            }
            else if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text.Trim()))
            {
                epFPP.SetError(cmbxFPP, "FPP Name doesn't exist");
                e.Cancel = true;
                cmbxOthersFPP.SelectedIndex = -1;
                cmbxOthersFPP.Enabled = false;
            }

        }
        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }

        private void cmbxOthersFPP_Validating(object sender, CancelEventArgs e)
        {
            if (!Factory.OthersFPPRepository().NameExist(cmbxOthersFPP.Text.Trim()) && !string.IsNullOrEmpty(cmbxOthersFPP.Text.Trim()))
            {
                epOthersFPP.SetError(cmbxOthersFPP, "Others FPP Name doesn't exist.");
                e.Cancel = true;
            }
        }
        private void cmbxOthersFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epOthersFPP, cmbxOthersFPP);
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text.Trim()))
            {
                epAccount.SetError(cmbxAccount, "Account is required");
                e.Cancel = true;
            }
            else if (!Factory.GeneralLedgerAccountsRepository().NameExist(cmbxAccount.Text.Trim()))
            {
                epAccount.SetError(cmbxAccount, "Account Name doesn't exist");
                e.Cancel = true;
            }
        }
        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private void mkTxtObligationNum_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowMaskedTextboxError(epObligationNum, mkTxtObligationNum, "Obligation No.");
        }
        private void mkTxtObligationNum_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epObligationNum, mkTxtObligationNum);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            }
            else if (nudAmount.Value == 0)
            {
                epAmount.SetError(nudAmount, "Enter a valuable amount.");
                e.Cancel = true;
            }
            else
                e.Cancel = ShowAmountValidationError(epAmount, nudAmount, "Amount Exceed to the alloted amount");

        }
        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations

    }
}
