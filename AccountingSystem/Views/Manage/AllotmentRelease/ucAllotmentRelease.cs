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
    public partial class ucAllotmentRelease : UserControl
    {
        internal int allotmentReleaseID = 0;
        internal int budgetAppropriationID = 0;
        internal decimal currentAllotmentReleaseAmount = 0;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {


            var errorArray = new string[3];
            errorArray[0] = epARONo.GetError(mskTxtAroNo);
            errorArray[1] = epPurpose.GetError(txtPurpose);
            errorArray[2] = epAmount.GetError(nudAmount);

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
    }
}
