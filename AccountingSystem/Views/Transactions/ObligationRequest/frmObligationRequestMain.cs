using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            var obligationStatus = Factory.ObligationRequestRepository().GetObligationRequestStatus(uc.obligationRequestId);
            string message = "Are you sure? Changes will not be saved.";

            void ResetForm()
            {
                btnSave.Text = "Save";
                lblStatus.ForeColor = Color.Black;
                uc.Enabled = true;
                uc.isEdit = false;
                EnableDisableControls();
                uc.ResetForm();
            }

            if (uc.isEdit || uc.dgObligationRequests.Rows.Count > 0)
            {
                switch (obligationStatus.ToLower())
                {
                    case "approved":
                        ResetForm();
                        break;
                    case "disapproved":
                        ResetForm();
                        break;
                    case "cancelled":
                        ResetForm();
                        break;

                    default:
                        if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            ResetForm();
                        }
                        break;
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
                btnSave.Enabled = true;
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


        internal void GetObligationStatus()
        {
            try
            {
                string ObligationRequestStatus = Factory.ObligationRequestRepository().GetObligationRequestStatus(uc.obligationRequestId);


                switch (ObligationRequestStatus.ToLower())
                {
                    case "approved":
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        linkShowMessage.Visible = false;
                        lblStatus.ForeColor = Color.FromArgb(78, 159, 61);
                        uc.Enabled = false;
                        break;
                    case "disapproved":
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        linkShowMessage.Visible = true;
                        lblStatus.ForeColor = Color.FromArgb(149, 1, 1);
                        uc.Enabled = false;
                        break;
                    case "cancelled":
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancelObligation.Enabled = false;
                        btnDelete.Enabled = false;
                        linkShowMessage.Visible = false;
                        lblStatus.ForeColor = Color.FromArgb(66, 63, 62);
                        uc.Enabled = false;
                        break;
                    case "pending":
                        btnApprove.Enabled = true;
                        btnDisapprove.Enabled = true;
                        btnCancelObligation.Enabled = true;
                        btnSave.Enabled = true;
                        uc.Enabled = true;
                        linkShowMessage.Visible = false;
                        lblStatus.ForeColor = Color.FromArgb(216, 146, 22);
                        break;
                    default:
                        break;
                }

                lblStatus.Text = ObligationRequestStatus.ToUpper();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
                GetObligationStatus();
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Disapproval of the obligation request.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, defaultButton: MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (SetObligationStatus("disapprove"))
                {
                    Helper.MessageBoxSuccess("Obligation Request has been disapproved.");
                    GetObligationStatus();
                }
            }
        }

        private void btnCancelObligation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Cancellation of the obligation request.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, defaultButton: MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (SetObligationStatus("cancel"))
                {
                    Helper.MessageBoxSuccess("Obligation Request has been cancelled.");
                    GetObligationStatus();
                }
            }
        }
    }
}
