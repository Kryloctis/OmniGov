using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestMain : Form
    {
        private ucObligationRequestMain uc;

        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnSave.Click += new EventHandler(BtnSave_Click);
            btnNew.Click += new EventHandler(BtnNew_Click);
            btnSearch.Click += new EventHandler(BtnSearch_Click);
            uc = ucObligationRequestMain1;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            uc.ResetForm();
        }

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private bool SaveObligationRequest()
        {
            try
            {
                if (!uc.ValidateChildren() || uc.ObligationRequestListEmpty()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var obligationRequestModelList = new List<ObligationRequestModel>();

                foreach (DataGridViewRow row in uc.dgObligationRequests.Rows)
                { 
                    int fppId = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                    int? otherFPPId = string.IsNullOrEmpty(uc.cmbxOthersFPP.Text) ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);
                    int accountId = Convert.ToInt32(row.Cells["accountId"].Value);
                    decimal obligationAmount = Convert.ToDecimal(row.Cells["obligationAmount"].Value);
                    int createdBy = Convert.ToInt32(Helper.GetLoggedInUser()["id"]);
                    string obligationNo = $"{uc.mskObligationSeriesNo.Text}-{uc.mskTxtObligationNoTemplate.Text}";

                    var obligationRequestModel = new ObligationRequestModel()
                    {
                        FundID = uc.fundId,
                        FPPId = fppId,
                        OtherFPPId = otherFPPId,
                        AllotmentClassesID = uc.allotmentClassId,
                        GenLedgerAccID = accountId,
                        DateRequested = uc.dtDateRequested.Value,
                        ObligationNo = obligationNo,
                        Payee = uc.txtPayee.Text,
                        Explanation = uc.txtExplanation.Text,
                        ReferencesNo = uc.txtReferenceNo.Text,
                        ObligationAmount = obligationAmount,
                        CreatedBy = createdBy
                    };

                    obligationRequestModelList.Add(obligationRequestModel);
                }

                return Factory.ObligationRequestRepository().BulkInsert(obligationRequestModelList);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e) 
        {
            if (SaveObligationRequest()) 
            {
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
                uc.ResetForm();
            }
        }
    }
}
