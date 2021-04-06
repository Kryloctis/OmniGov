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

        private void LoadSelectedObligationRequest() 
        {
            var uc = _frmObligationRequest.ucObligationRequest1;

            var obligationRequestRecord =  Factory.ObligationRequestRepository().GetRecordByObligationNum(mkTxtObligationNum.Text.Trim());

            uc.obligationID = Convert.ToInt32(obligationRequestRecord["id"]);
            uc.obligationRequestAmount = Convert.ToDecimal(obligationRequestRecord["obligation_amount"]);
            uc.cmbxFunds.SelectedValue = Convert.ToInt32(obligationRequestRecord["funds_id"]);
            uc.cmbxFPP.SelectedValue = Convert.ToInt32(obligationRequestRecord["function_program_project_id"]);
            uc.cmbxOthersFPP.SelectedValue = string.IsNullOrEmpty(obligationRequestRecord["others_fpp_id"].ToString())? null : Convert.ToInt32(obligationRequestRecord["others_fpp_id"]);
            uc.cmbxAllotmentClasses.SelectedValue = Convert.ToInt32(obligationRequestRecord["allotment_classes_id"]);
            uc.cmbxAccount.SelectedValue = Convert.ToInt32(obligationRequestRecord["general_ledger_accounts_id"]);
            uc.dtPickerDateIssued.Value = Convert.ToDateTime(obligationRequestRecord["date_issued"]);
            uc.mkTxtObligationNum.Text = obligationRequestRecord["obligation_no"];
            uc.nudAmount.Value = Convert.ToDecimal(obligationRequestRecord["obligation_amount"]);
        }

        private void EnableDisableComponents() 
        {
            var uc = _frmObligationRequest.ucObligationRequest1;

            _frmObligationRequest.btnCancel.Enabled = true;
            _frmObligationRequest.btnDelete.Enabled = true;
            _frmObligationRequest.btnSave.Text = "Update";

            uc.cmbxFunds.Enabled = false;
            uc.cmbxFPP.Enabled = false;
            uc.cmbxOthersFPP.Enabled = false;
            uc.cmbxAllotmentClasses.Enabled = false;
            uc.cmbxAccount.Enabled = false;
            uc.dtPickerDateIssued.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Factory.ObligationRequestRepository().ObligationNumExist(mkTxtObligationNum.Text))
            {
                LoadSelectedObligationRequest();
                EnableDisableComponents();
                Close();
            }
            else
                Helper.MessageBoxError("Obligation No. Doesn't exist.");
        }

        private void mkTxtObligationNum_TextChanged(object sender, EventArgs e)
        {
            if (mkTxtObligationNum.MaskCompleted)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }
    }
}
