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
    public partial class frmSearchObligationRequest : Form
    {
        private frmObligationRequest _frmObligationRequest;
        public frmSearchObligationRequest(frmObligationRequest frmObligationRequest)
        {
            InitializeComponent();
            _frmObligationRequest = frmObligationRequest;
        }

        private void LoadSelectedObligationInfo() 
        {
            try
            {
                var uc = _frmObligationRequest.ucObligationRequestNew1;

                uc.isEdit = true;
                uc.lnklblAllotmentRelease.Enabled = false;

                var selectedObligation = Factory.ObligationRequestRepository().GetRecordByObligationNum(mkTxtObligationNum.Text);
                uc.lblTypeofFund.Text = selectedObligation["fund_name"];
                uc.lblFPPCode.Text = selectedObligation["fpp_code"];
                uc.lblFPPName.Text = selectedObligation["fpp_name"];
                uc.lblOtherFPP.Text = string.IsNullOrEmpty(selectedObligation["others_fpp_name"])? "-": selectedObligation["others_fpp_name"];
                uc.lblAllotmentClass.Text = selectedObligation["allotment_code"];
                uc.lblAccount.Text = selectedObligation["ledger_name"];
                uc.mkTxtObligationNum.Text = selectedObligation["obligation_no"];
                uc.nudAmount.Value = Convert.ToDecimal(selectedObligation["obligation_amount"]);

                uc.obligationId = Convert.ToInt32(selectedObligation["obligation_request_id"]);
                uc.fundId = Convert.ToInt32(selectedObligation["funds_id"]);
                uc.fppId = Convert.ToInt32(selectedObligation["function_program_project_id"]);
                uc.othersFPPId = string.IsNullOrEmpty(selectedObligation["others_fpp_id"])? null : Convert.ToInt32(selectedObligation["others_fpp_id"]);
                uc.allotmentClassId = Convert.ToInt32(selectedObligation["allotment_classes_id"]);
                uc.accountId = Convert.ToInt32(selectedObligation["general_ledger_accounts_id"]);
                uc.obligationNo = selectedObligation["obligation_no"].ToString();

                _frmObligationRequest.btnCancel.Enabled = true;
                _frmObligationRequest.btnDelete.Enabled = true;
                _frmObligationRequest.btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void mkTxtObligationNum_TextChanged(object sender, EventArgs e)
        {
            if (mkTxtObligationNum.MaskCompleted)
            {
                if (Factory.ObligationRequestRepository().ObligationNumExist(mkTxtObligationNum.Text))
                {
                    LoadSelectedObligationInfo();
                    Close();
                }
                btnOk.Enabled = true;   
            }
            else
                btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Factory.ObligationRequestRepository().ObligationNumExist(mkTxtObligationNum.Text))
            {
                LoadSelectedObligationInfo();
                Close();
            }
            else
                Helper.MessageBoxError("Obligation No. Doesn't exist.");
        }
    }
}
