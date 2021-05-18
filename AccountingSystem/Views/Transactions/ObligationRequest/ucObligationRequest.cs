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
        internal int obligationRequestId = 0;
        internal int fppId;
        internal int? otherFPPId;
        internal int fundId;
        internal int allotmentClassId;
        internal int accountId;
        internal byte month;
        internal short year;
        internal decimal currentObligationAmount;

        public ucObligationRequest()
        {
            InitializeComponent();
        }


        internal void ResetForm()
        {
            mskTxtSeriesNo.Text = string.Empty;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            nudAmount.Value = 0;
            txtAllotmentReleaseBalance.Text = GetAmounts()["allotment_release_balance"].ToString("N2");
        }

        private Dictionary<string,decimal> GetAmounts() 
        {

            var records = new Dictionary<string, decimal>();

            decimal totalAllotmentReleaseAmountByYear = Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmountYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dtDateRequest.Value);

            decimal totalObligationAmountByYear = Factory.ObligationRequestRepository().GetTotalObligationAmountByYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, dtDateRequest.Value);

            decimal allotmentReleaseBalance = totalAllotmentReleaseAmountByYear - totalObligationAmountByYear;

            records.Add("allotment_release_balance", allotmentReleaseBalance);

            return records;
        }

    
        internal string GetFormErrors()
        {
            var errorArray = new string[5];

            errorArray[0] = epObligationSeriesNo.GetError(mskTxtTemplate);
            errorArray[1] = epReferenceNo.GetError(txtReferenceNo);
            errorArray[2] = epPayee.GetError(txtPayee);
            errorArray[3] = epExplanation.GetError(txtExplanation);
            errorArray[4] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal string  GenerateObligationNoTemplate() 
        {
            var fundsRepo = Factory.FundsRepository().GetRecordByID(fundId);

            string obligationNoTemplate = $"{dtDateRequest.Value.ToString("MM")}-{dtDateRequest.Value.ToString("yy")}-{fundsRepo["fund_code"]}";

            return obligationNoTemplate;
        }

        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                mskTxtTemplate.Text = GenerateObligationNoTemplate();
                dtDateRequest.MaxDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                dtDateRequest.MinDate = new DateTime(year, month, 1);
                txtAllotmentReleaseBalance.Text = GetAmounts()["allotment_release_balance"].ToString("N2");
            }
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
           mskTxtTemplate.Text =  GenerateObligationNoTemplate();
        }



        private bool ObligationNoExist()
        {
            try
            {
                string obligationNo = $"{mskTxtSeriesNo.Text}-{mskTxtTemplate.Text}";
                bool obligationNoExist;

                if (obligationRequestId == 0)
                    obligationNoExist = Factory.ObligationRequestRepository().ObligationNumExist(obligationNo);
                else
                    obligationNoExist = Factory.ObligationRequestRepository().ObligationNumExist(obligationRequestId, obligationNo);


                if (obligationNoExist) 
                {
                    epObligationSeriesNo.SetError(mskTxtTemplate, "Obligaton No. already exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ObligationSeriesNoEmpty() 
        {
            try
            {
                if (!mskTxtSeriesNo.MaskCompleted)
                {
                    epObligationSeriesNo.SetError(mskTxtTemplate, "Pleas put an Obligation Series No.");
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
            if (!mskTxtSeriesNo.MaskCompleted)
                e.Cancel = ObligationSeriesNoEmpty();
            else if (ObligationNoExist())
                e.Cancel = ObligationNoExist();
        }

        private void mskTxtSeriesNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearMaskedTextboxError(epObligationSeriesNo, mskTxtTemplate);
        }



        private void txtReferenceNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epReferenceNo, txtReferenceNo, "Reference No,");
        }

        private void txtReferenceNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReferenceNo, txtReferenceNo);
        }



        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtPayee, "Payee");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
        }



        private void txtExplanation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epExplanation, txtExplanation, "Explanation");
        }

        private void txtExplanation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epExplanation, txtExplanation);
        }



        private bool AmountExceed() 
        {
            try
            {

                bool amountExceed;

                if (obligationRequestId == 0)
                    amountExceed = nudAmount.Value > GetAmounts()["allotment_release_balance"];
                else
                    amountExceed = nudAmount.Value > GetAmounts()["allotment_release_balance"] + currentObligationAmount;

                if (amountExceed) 
                {
                    epAmount.SetError(nudAmount, "Amount you entered exceeds to the allotment release balance.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);    
            }
            return false;
        }

        private bool AmountIsZero() 
        {
            try
            {
                if (nudAmount.Value == 0 && !string.IsNullOrEmpty(nudAmount.Text)) 
                {
                    epAmount.SetError(nudAmount, "Valuable amount is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else if (AmountIsZero())
                e.Cancel = AmountIsZero();
            else if (AmountExceed())
                e.Cancel = AmountExceed();
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }
    }
}
