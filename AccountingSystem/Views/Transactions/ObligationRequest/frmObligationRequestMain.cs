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
    public partial class frmObligationRequestMain : Form
    {
        ucObligationRequestMain uc;

        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnAdd.Click += new EventHandler(BtnAdd_Click);
            btnEdit.Click += new EventHandler(BtnEdit_Click);
            uc = ucObligationRequestMain1;
            uc.LoadReferenceObligationRequestMain(this);
        }

        private void ShowObligationRequestEdit()
        {
  
            var frmObligationRequestEdit = new frmObligationRequestEdit(this);
            var ucObligationRequestEdit = frmObligationRequestEdit.ucObligationRequest1;
               
            int rowIndex = uc.dgObligationRequests.CurrentCell.RowIndex;

            int obligationRequestId = Convert.ToInt32(uc.dgObligationRequests.Rows[rowIndex].Cells["obligation_request_id"].Value);
            var obligationRequestRepo = Factory.ObligationRequestRepository().GetViewRecordsById(obligationRequestId);

            int fppId = Convert.ToInt32(obligationRequestRepo["fpp_id"]);
            int? otherFPPId = string.IsNullOrEmpty(obligationRequestRepo["others_fpp_id"]) ? null : Convert.ToInt32(obligationRequestRepo["others_fpp_id"]);
            int fundId = Convert.ToInt32(obligationRequestRepo["fund_id"]);
            int allotmentClassId = Convert.ToInt32(obligationRequestRepo["allotment_class_id"]);
            int accountId = Convert.ToInt32(obligationRequestRepo["gen_ledger_acc_id"]);
            DateTime dateRequested = Convert.ToDateTime(obligationRequestRepo["date_requested"]);

            string accountName = obligationRequestRepo["gen_ledger_acc_name"];
            string seriesNo = obligationRequestRepo["obligation_no"];
            string referenceNo = obligationRequestRepo["reference_no"];
            string payee = obligationRequestRepo["payee"];
            string explanation = obligationRequestRepo["explanation"];
            decimal obligationAmount = Convert.ToDecimal(obligationRequestRepo["obligation_amount"]);


            ucObligationRequestEdit.obligationRequestId = obligationRequestId;
            ucObligationRequestEdit.fppId = fppId;
            ucObligationRequestEdit.otherFPPId = otherFPPId;
            ucObligationRequestEdit.fundId = fundId;
            ucObligationRequestEdit.allotmentClassId = allotmentClassId;
            ucObligationRequestEdit.accountId = accountId;
            ucObligationRequestEdit.currentObligationAmount = obligationAmount;


            ucObligationRequestEdit.month = Convert.ToByte(dateRequested.Month);
            ucObligationRequestEdit.year = Convert.ToInt16(dateRequested.Year);
            ucObligationRequestEdit.txtAccountName.Text = accountName;
            ucObligationRequestEdit.mskTxtSeriesNo.Text = seriesNo;
            ucObligationRequestEdit.txtReferenceNo.Text = referenceNo;
            ucObligationRequestEdit.txtPayee.Text = payee;
            ucObligationRequestEdit.txtExplanation.Text = explanation;
            ucObligationRequestEdit.nudAmount.Value = obligationAmount;
            ucObligationRequestEdit.dtDateRequest.Enabled = false;


            frmObligationRequestEdit.ShowDialog();
  
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowObligationRequestEdit();
        }

        private bool ShowObligationRequestAdd() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var frmObligationAdd = new frmObligationRequestAdd(this);
                var ucFrmObligationAdd = frmObligationAdd.ucObligationRequest1;

                ucFrmObligationAdd.fppId = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                ucFrmObligationAdd.otherFPPId = string.IsNullOrEmpty(uc.cmbxOthersFPP.Text) ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);
                ucFrmObligationAdd.fundId = uc.fundId;
                ucFrmObligationAdd.allotmentClassId = uc.allotmentClassId;
                ucFrmObligationAdd.accountId = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
                ucFrmObligationAdd.txtAccountName.Text = uc.cmbxAccount.Text;
                ucFrmObligationAdd.month = Convert.ToByte(uc.cmbxMonths.SelectedValue);
                ucFrmObligationAdd.year = Convert.ToInt16(uc.nudYear.Value);

                frmObligationAdd.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowObligationRequestAdd();
        }

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {

        }

    }
}
