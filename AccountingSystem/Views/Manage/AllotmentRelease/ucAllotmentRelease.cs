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
        internal int budgetAppropriationID = 0;
        internal int fppID = 0;
        internal int? othersFPPID = null;
        internal int allotmentClassesID = 0;
        internal int generalLedgerAccID = 0;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            BudgetAppropriationValidation();

            var errorArray = new string[4];
            errorArray[0] = epBudgetAppropriations.GetError(groupBox1);
            errorArray[1] = epARONo.GetError(txtAllotmentReleaseNo);
            errorArray[2] = epPurpose.GetError(txtPurpose);
            errorArray[3] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            budgetAppropriationID = 0;
            fppID = 0;
            othersFPPID = null;
            allotmentClassesID = 0;
            generalLedgerAccID = 0;
            lblFPPCode.Text = "-";
            lblFPP.Text = "-";
            lblOtherFPP.Text = "-";
            lblAccountCode.Text = "-";
            lblAllotmentClass.Text = "-";
            lblGenLedgerAcc.Text = "-";
            lblYear.Text = "-";
            lblAmount.Text = "-";
            txtAllotmentReleaseNo.Clear();
            txtPurpose.Clear();
            dtDateIssued.Value = DateTime.Now;
            nudAmount.Value = 0;
        }

        internal void LoadSelected()
        {
            try
            {
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationID, fppID, othersFPPID, allotmentClassesID, generalLedgerAccID);

                lblFPPCode.Text = selectedBudgetAppropriation["fpp_code"].ToString();
                lblFPP.Text = selectedBudgetAppropriation["fpp_name"].ToString();

                //if others fpp was null
                if (string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_name"]))
                    lblOtherFPP.Text = string.Empty;
                else
                    lblOtherFPP.Text = selectedBudgetAppropriation["others_fpp_name"];

                lblAccountCode.Text = selectedBudgetAppropriation["account_code"].ToString();
                lblAllotmentClass.Text = selectedBudgetAppropriation["allotment_code"].ToString();
                lblGenLedgerAcc.Text = selectedBudgetAppropriation["ledger_name"].ToString();
                lblYear.Text = selectedBudgetAppropriation["year"].ToString();
                lblAmount.Text = Convert.ToDecimal(selectedBudgetAppropriation["amount"]).ToString("N2");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region Validations

        //Overriden Validation
        private void BudgetAppropriationValidation() 
        {
            if (budgetAppropriationID == 0)
            {
                epBudgetAppropriations.SetError(groupBox1, "Budget Appropriation is required.");
            }
            else 
            {
                epBudgetAppropriations.SetError(groupBox1, string.Empty);
            }
        }

        private void txtAllotmentReleaseNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epARONo, txtAllotmentReleaseNo, "Allotment Release No.");
        }
        private void txtAllotmentReleaseNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epARONo, txtAllotmentReleaseNo);
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
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
        }
        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations
    }
}
