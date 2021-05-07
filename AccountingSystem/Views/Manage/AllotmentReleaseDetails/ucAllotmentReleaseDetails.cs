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
        internal DateTime dateEntry = DateTime.Now;

        public ucAllotmentReleaseDetails()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = epARONo.GetError(mskTxtYear);
            errorArray[1] = epPurpose.GetError(txtPurpose);
            errorArray[2] = epAmount.GetError(nudAmount);
            errorArray[3] = epDateIssued.GetError(dtDateIssued);
            errorArray[4] = AllotmentReleaseExist() ? Tag.ToString() : string.Empty; 

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            mskTxtSeriesNo.Clear();
            txtPurpose.Clear();
            dtDateIssued.Value = DateTime.Now;
            nudAmount.Value = 0;
        }

        private void AROyearValue()
        {
            mskTxtYear.Text = dtDateIssued.Value.Year.ToString();
        }

        internal bool AllotmentReleaseExist()
        {
            try
            {
                DateTime dateIssued = dtDateIssued.Value;

                bool allotmentReleaseExist;

                if (allotmentReleaseID == 0)
                 allotmentReleaseExist = Factory.AllotmentReleaseRepository().allotmentReleaseExist(budgetAppropriationID, dateIssued.ToString("yyyy-MM-dd"));
                else
                  allotmentReleaseExist = Factory.AllotmentReleaseRepository().allotmentReleaseExist(allotmentReleaseID, budgetAppropriationID, dateIssued.ToString("yyyy-MM-dd"));

                if (allotmentReleaseExist)
                {
                    Tag = "Allotment Release already exist on the date it was issued.";
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        #region Validations
        private void AmountLogic(ErrorProvider ep, NumericUpDown numericUpDown, CancelEventArgs e) 
        {
            //var totalAppropriationBalance = Factory.BudgetAppropriationsRepository().GetTotalAppropriationBalanceRecord(budgetAppropriationID);
            //decimal appropriationBalance = Convert.ToDecimal(totalAppropriationBalance["appropriation_balance"]);

            //if (allotmentReleaseID == 0)
            //{
            //    string errorText = numericUpDown.Value > appropriationBalance ? "The amount you entered exceeds the appropriate balance." : string.Empty;
            //    bool errorBoolean = numericUpDown.Value > appropriationBalance ? true : false;
            //    ep.SetError(nudAmount, errorText);
            //    e.Cancel = errorBoolean;
            //}
            //else
            //{
            //    string errorText = numericUpDown.Value > appropriationBalance + currentAllotmentReleaseAmount ? "The amount you entered exceeds the appropriate balance." : string.Empty;
            //    bool errorBoolean = numericUpDown.Value > appropriationBalance + currentAllotmentReleaseAmount ? true : false;
            //    ep.SetError(nudAmount, errorText);
            //    e.Cancel = errorBoolean;
            //}
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

        private bool ErrorYearIsLessThanApproprationYear(ErrorProvider ep, DateTimePicker dateTimePicker)
        {
            try
            {
                if (dateTimePicker.Value < dateEntry)
                {
                    ep.SetError(dateTimePicker, "Date Issue you entered is less than the date of the appropriation.");
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

        #endregion Validations

        private void dtDateIssued_ValueChanged(object sender, EventArgs e)
        {
            AROyearValue();
        }

        private void ucAllotmentReleaseDetails_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                AROyearValue();
            }
        }

        private bool ShowErrorSeriesNo(ErrorProvider ep, MaskedTextBox mskTxtSeriesNo, MaskedTextBox mskTxtYear) 
        {
            try
            {
                if (!mskTxtSeriesNo.MaskCompleted) 
                {
                    ep.SetError(mskTxtYear, "ARO Series No. is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mskTxtSeriesNo_Validating(object sender, CancelEventArgs e)
        {
           e.Cancel = ShowErrorSeriesNo(epARONo, mskTxtSeriesNo, mskTxtYear);
        }

        private void mskTxtSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epARONo, mskTxtYear);
        }
    }
}
