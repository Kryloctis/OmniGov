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
        internal bool isEdit = false;
        internal int obligationId = 0;
        internal int fundId = 0;
        internal int fppId = 0;
        internal int? othersFPPId = null;
        internal int allotmentClassId = 0;
        internal int accountId = 0;
        internal string obligationNo = string.Empty;
        internal decimal unobligatedBalance = 0;
        internal short year = 0;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = fundId == 0 ? "Allotment Release is Required. Please select an allotment release.": string.Empty;
            errorArray[1] = epObligationNum.GetError(mkTxtObligationNum);
            errorArray[2] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            isEdit = false;
            obligationId = 0;
            fundId = 0;
            fppId = 0;
            othersFPPId = null;
            allotmentClassId = 0;
            accountId = 0;
            obligationNo = string.Empty;
            lnklblAllotmentRelease.Enabled = true;
            unobligatedBalance = 0;
            year = 0;

            lblTypeofFund.Text = "-";
            lblFPPCode.Text = "-";
            lblFPPName.Text = "-";
            lblOtherFPP.Text = "-";
            lblAllotmentClass.Text = "-";
            lblAccount.Text = "-";
            lblYear.Text = "-";
            lblBalance.Text = "-";

            mkTxtObligationNum.Clear();
            nudAmount.Value = 0;

            epAmount.SetError(nudAmount, string.Empty);
            epObligationNum.SetError(mkTxtObligationNum, string.Empty);
        }

        internal void ResetFields() 
        {
            mkTxtObligationNum.Clear();
            nudAmount.Value = 0;
        }

        private void lnklblAllotmentRelease_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ = new frmSelectAllotmentRelease(this).ShowDialog();
        }

        #region Validations

        private bool ShowObligationNumExistError(ErrorProvider ep, MaskedTextBox maskedTextBox, string fieldText) 
        {
            try
            {
                if (obligationId == 0)
                {
                    if (Factory.ObligationRequestRepository().ObligationNumExist(maskedTextBox.Text)) 
                    {
                        ep.SetError(maskedTextBox,$"{fieldText} is already exist on your record.");
                        return true;
                    }
                }
                else 
                {
                    if (Factory.ObligationRequestRepository().ObligationNumExist(obligationId, maskedTextBox.Text))
                    {
                        ep.SetError(maskedTextBox, $"{fieldText} is already exist on your record.");
                        return true;
                    }
                }

            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mkTxtObligationNum_Validating(object sender, CancelEventArgs e)
        {
            if(mkTxtObligationNum.MaskCompleted)
                e.Cancel = ShowObligationNumExistError(epObligationNum, mkTxtObligationNum, "Obligation No.");
            else
                e.Cancel = Helper.ShowMaskedTextboxError(epObligationNum, mkTxtObligationNum, "Obligation No.");

        }
        private void mkTxtObligationNum_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epObligationNum, mkTxtObligationNum);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");

            if (nudAmount.Value == 0)
            {
                epAmount.SetError(nudAmount, Helper.ErrorMessage("Valuable Amount"));
                e.Cancel = true;
            }
        }
        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations
    }
}
