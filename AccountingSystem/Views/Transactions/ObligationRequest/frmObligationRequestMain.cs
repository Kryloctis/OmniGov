using ACC.Domain.Models;
using MySql.Data.MySqlClient;
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
            uc = ucObligationRequestMain1;
        }

        private List<ObligationAccountModel> ObligationAccountsModelList()
        {
            var obligationRequestModelList = new List<ObligationAccountModel>();

            foreach (DataGridViewRow item in uc.dgObligationRequests.Rows)
            {
                int budgetAppropriationId = Convert.ToInt32(item.Cells["budget_appropriation_id"].Value);
                decimal obligationAmount = Convert.ToDecimal(item.Cells["obligation_amount"].Value);

                var obligationAccountModel = new ObligationAccountModel()
                {
                    BudgetAppropriationId = budgetAppropriationId,
                    Amount = obligationAmount
                };

                obligationRequestModelList.Add(obligationAccountModel);
            }

            return obligationRequestModelList;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmDelete(1))
                {
                    _ = Factory.ObligationRequestRepository().Delete(uc.obligationRequestId);
                    btnSave.Text = "&Save";
                    btnDelete.Enabled = false;
                    uc.ResetForm();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool InsertData()
        {
            try
            {
                string obligationNo = $"{uc.mskTxtObligationNoSeries.Text}-{uc.mskTxtObligationNoTemplate.Text}";

                var obligationRequestModel = new ObligationRequestModel()
                {
                    ObligationNo = obligationNo,
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
                    DateRequested = uc.dtDateRequest.Value,
                    CreatedBy = Helper.UserId
                };


                return Factory.ObligationRequestRepository().Insert(obligationRequestModel, ObligationAccountsModelList());
            }
            catch (MySqlException ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool UpdateData()
        {
            try
            {
                string obligationNo = $"{uc.mskTxtObligationNoSeries.Text}-{uc.mskTxtObligationNoTemplate.Text}";

                var obligationRequestModel = new ObligationRequestModel()
                {
                    Id = uc.obligationRequestId,
                    ObligationNo = obligationNo,
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
                    DateRequested = uc.dtDateRequest.Value,
                    UpdatedBy = Helper.UserId
                };


                return Factory.ObligationRequestRepository().Update(obligationRequestModel, ObligationAccountsModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                bool saveData;

                if (!uc.isEdit)
                    saveData = InsertData();
                else
                    saveData = UpdateData();

                return saveData;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                string message = !uc.isEdit ? "saved" : "updated";
                Helper.MessageBoxSuccess($"Obligation Request has been {message}.");
                uc.ResetForm();
                EnableDisableControls();
                btnSave.Text = "Save";
            }
        }

        private void CancelAction()
        {
            string message = "Are you sure? Changes will not be saved.";

            if (uc.isEdit || uc.dgObligationRequests.Rows.Count > 0)
            {
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    btnSave.Text = "Save";
                    uc.isEdit = false;
                    EnableDisableControls();
                    uc.ResetForm();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelAction();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestSearch(this).ShowDialog();
        }

        internal void EnableDisableControls()
        {
            if (!uc.isEdit)
            {
                btnApprove.Enabled = false;
                btnDisapprove.Enabled = false;
                btnCancelObligation.Enabled = false;
                lblStatus.Text = "--";
                linkShowMessage.Visible = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnApprove.Enabled = true;
                btnDisapprove.Enabled = true;
                btnCancelObligation.Enabled = true;
                btnDelete.Enabled = true;
            }

        }

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private bool SetObligationStatus(string status)
        {
            try
            {
                return Factory.ObligationRequestRepository().SetObligationRequestStatus(uc.obligationRequestId, status);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (SetObligationStatus("approve"))
            {
                Helper.MessageBoxSuccess("Obligation Request has been approved.");
            }
        }
    }
}
