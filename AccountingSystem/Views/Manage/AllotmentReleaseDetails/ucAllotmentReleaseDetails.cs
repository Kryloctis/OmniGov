using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class ucAllotmentReleaseDetails : UserControl
    {
        internal int allotmentReleaseID = 0;
        internal int budgetAppropriationID = 0;
        internal decimal currentAllotmentReleaseAmount = 0;
        internal short year = Convert.ToInt16(DateTime.Now.Year);

        public ucAllotmentReleaseDetails()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epARONo.GetError(mskTxtAroNo);
            errorArray[1] = epPurpose.GetError(txtPurpose);
            errorArray[2] = epAmount.GetError(nudAmount);
            errorArray[3] = epDateIssued.GetError(dtDateIssued);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            mskTxtAroNo.Clear();
            txtPurpose.Clear();
            dtDateIssued.Value = DateTime.Now;
            nudAmount.Value = 0;
        }

        #region Validations
        private void AmountLogic(ErrorProvider ep, NumericUpDown numericUpDown, CancelEventArgs e) 
        {
            var totalAppropriationBalance = Factory.BudgetAppropriationsRepository().GetTotalAppropriationBalanceRecord(budgetAppropriationID);
            decimal appropriationBalance = Convert.ToDecimal(totalAppropriationBalance["appropriation_balance"]);

            if (allotmentReleaseID == 0)
            {
                string errorText = numericUpDown.Value > appropriationBalance ? "The amount you entered exceeds the appropriate balance." : string.Empty;
                bool errorBoolean = numericUpDown.Value > appropriationBalance ? true : false;
                ep.SetError(nudAmount, errorText);
                e.Cancel = errorBoolean;
            }
            else
            {
                string errorText = numericUpDown.Value > appropriationBalance + currentAllotmentReleaseAmount ? "The amount you entered exceeds the appropriate balance." : string.Empty;
                bool errorBoolean = numericUpDown.Value > appropriationBalance + currentAllotmentReleaseAmount ? true : false;
                ep.SetError(nudAmount, errorText);
                e.Cancel = errorBoolean;
            }
        }

        private void txtPurpose_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPurpose, txtPurpose, "Purpose");
        }
        private void txtPurpose_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPurpose, txtPurpose);
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
            {
                AmountLogic(epAmount, nudAmount, e);
            }
        }
        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void mskTxtAroNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowMaskedTextboxError(epARONo, mskTxtAroNo, "Allotment Release No.");

            //bool itemNameExist;

            //if (allotmentReleaseID == 0)
            //    itemNameExist = Factory.AllotmentReleaseRepository().allotmentReleaseNumExist(mskTxtAroNo.Text.Trim());
            //else
            //    itemNameExist = Factory.AllotmentReleaseRepository().allotmentReleaseNumExist(allotmentReleaseID, mskTxtAroNo.Text.Trim());

            //if (itemNameExist)
            //{
            //    epARONo.SetError(mskTxtAroNo, $"The Allotment Release No. You entered, \nIs already exist in your record.");
            //    e.Cancel = true;
            //}
        }
        private void mskTxtAroNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epARONo, mskTxtAroNo);
        }

        #endregion Validations

        private bool ErrorYearIsLessThanApproprationYear(ErrorProvider ep, DateTimePicker dateTimePicker) 
        {
            try
            {
                if (dateTimePicker.Value.Year < year)
                {
                    ep.SetError(dateTimePicker, "Issued date you entered is less than the year of the appropriation.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void dtDateIssued_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ErrorYearIsLessThanApproprationYear(epDateIssued, dtDateIssued);
        }

        private void ClearErrorDateTimePicker(ErrorProvider ep, DateTimePicker dateTimePicker) 
        {
            ep.SetError(dateTimePicker, string.Empty);
        }

        private void dtDateIssued_Validated(object sender, EventArgs e)
        {
            ClearErrorDateTimePicker(epDateIssued, dtDateIssued);
        }
    }
}
