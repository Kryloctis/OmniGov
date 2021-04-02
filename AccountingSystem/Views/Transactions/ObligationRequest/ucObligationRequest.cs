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
        internal int obligationId = 0;
        internal int fundId = 0;
        internal int fppId = 0;
        internal int? othersFPPId = null;
        internal int allotmentClassId = 0;
        internal int accountId = 0;
        internal short year = 0;
        internal string obligationNo = string.Empty;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        //Load Record for Selected Allotment Record
        internal void LoadSelectedRecord() 
        {
            try
            {

                var selectedAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecord(fundId, fppId, othersFPPId, allotmentClassId, accountId, year);

                var obligationTotalAmount = Factory.ObligationRequestRepository().GetTotalObligationAmount(
                    fundId, 
                    fppId, 
                    othersFPPId, 
                    allotmentClassId, 
                    Convert.ToInt32(selectedAllotmentRelease["gen_ledger_acc_id"]), 
                    year);

                var allotmentReleaseTotalAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(
                    fundId,
                    fppId,
                    othersFPPId,
                    allotmentClassId,
                    Convert.ToInt32(selectedAllotmentRelease["gen_ledger_acc_id"]),
                    year);

                decimal unobligatedBalance = Convert.ToDecimal(
                    allotmentReleaseTotalAmount["total_allotment_release_amount"]) - Convert.ToDecimal(obligationTotalAmount["total_obligation_amount"]);

                lblTypeofFund.Text = selectedAllotmentRelease["fund_name"];
                lblFPPCode.Text = selectedAllotmentRelease["fpp_code"];
                lblFPPName.Text = selectedAllotmentRelease["fpp_name"];
                lblOtherFPP.Text = string.IsNullOrEmpty(selectedAllotmentRelease["others_fpp_name"]) ? "-" : selectedAllotmentRelease["others_fpp_name"];
                lblAllotmentClass.Text = selectedAllotmentRelease["allotment_class_code"];
                lblAccountCode.Text = selectedAllotmentRelease["account_code"];
                lblAccountName.Text = selectedAllotmentRelease["gen_ledger_name"];
                lblYear.Text = selectedAllotmentRelease["budget_appropriations_year"];
                lblBalance.Text = unobligatedBalance.ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        //Load Record for Searched Obligation Request
        internal void LoadSearchRecord() 
        {
            try
            {
                var selectedObligationRequest = Factory.ObligationRequestRepository().GetViewRecordByObligationNum(obligationNo);

                obligationId = Convert.ToInt32(selectedObligationRequest["obligation_request_id"]);
                fundId = Convert.ToInt32(selectedObligationRequest["funds_id"]);
                fppId = Convert.ToInt32(selectedObligationRequest["function_program_project_id"]);
                othersFPPId = string.IsNullOrEmpty(selectedObligationRequest["others_fpp_id"]) ? null : Convert.ToInt32(selectedObligationRequest["others_fpp_id"]);
                allotmentClassId = Convert.ToInt32(selectedObligationRequest["allotment_classes_id"]);
                accountId = Convert.ToInt32(selectedObligationRequest["general_ledger_accounts_id"]);
                year = Convert.ToInt16(selectedObligationRequest["year"]);

                var obligationTotalAmount = Factory.ObligationRequestRepository().GetTotalObligationAmount(
                    fundId,
                    fppId,
                    othersFPPId,
                    allotmentClassId,
                    Convert.ToInt32(selectedObligationRequest["general_ledger_accounts_id"]),
                    year);

                var allotmentReleaseTotalAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(
                    fundId,
                    fppId,
                    othersFPPId,
                    allotmentClassId,
                    accountId,
                    year);

                decimal unobligatedBalance = Convert.ToDecimal(
                    allotmentReleaseTotalAmount["total_allotment_release_amount"]) - Convert.ToDecimal(obligationTotalAmount["total_obligation_amount"]);

                lblTypeofFund.Text = selectedObligationRequest["funds_name"];
                lblFPPCode.Text = selectedObligationRequest["fpp_code"];
                lblFPPName.Text = selectedObligationRequest["fpp_name"];
                lblOtherFPP.Text = string.IsNullOrEmpty(selectedObligationRequest["others_fpp_name"]) ? "-" : selectedObligationRequest["others_fpp_name"];
                lblAllotmentClass.Text = selectedObligationRequest["allotment_code"];
                lblAccountCode.Text = selectedObligationRequest["account_code"];
                lblAccountName.Text = selectedObligationRequest["ledger_name"];
                lblYear.Text = selectedObligationRequest["year"];
                lblBalance.Text = unobligatedBalance.ToString("N2");
                mkTxtObligationNum.Text = selectedObligationRequest["obligation_no"];
                nudAmount.Value = Convert.ToDecimal(selectedObligationRequest["obligation_amount"]);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
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
            obligationId = 0;
            fundId = 0;
            fppId = 0;
            othersFPPId = null;
            allotmentClassId = 0;
            accountId = 0;
            lnklblAllotmentRelease.Enabled = true;
            year = 0;
            obligationNo = string.Empty;

            lblTypeofFund.Text = "-";
            lblFPPCode.Text = "-";
            lblFPPName.Text = "-";
            lblOtherFPP.Text = "-";
            lblAllotmentClass.Text = "-";
            lblAccountCode.Text = "-";
            lblAccountName.Text = "-";
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
