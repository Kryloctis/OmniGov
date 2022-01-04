using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Transactions;
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
            lblCreatedBy.Text = "--";
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

        internal void LoadSearched()
        {
            try
            {
                uc.dgObligationRequests.Rows.Clear();

                var dictObligationRequest = Factory.ObligationRequestRepository().GetViewRecordById(uc.obligationRequestId);
                var dtObligationRequest = Factory.ObligationRequestRepository().GetViewRecordsById(uc.obligationRequestId);

                int fppId = Convert.ToInt32(dictObligationRequest["function_program_project_id"]);
                int fundId = Convert.ToInt32(dictObligationRequest["funds_id"]);
                int allotmentClassId = Convert.ToInt32(dictObligationRequest["allotment_classes_id"]);
                string obligationRequestNo = dictObligationRequest["obligation_no"].ToString();
                DateTime dateOfRequest = Convert.ToDateTime(dictObligationRequest["date_requested"]);
                string referenceNo = dictObligationRequest["reference_no"].ToString();
                string payee = dictObligationRequest["payee"].ToString();
                string explanation = dictObligationRequest["explanation"].ToString();
                string createdBy = dictObligationRequest["created_by_full_name"].ToString();


                uc.cmbxFPP.SelectedValue = fppId;
                uc.CheckedFund(fundId);
                uc.CheckedAllotmentClass(allotmentClassId);
                uc.mskTxtObligationNoSeries.Text = obligationRequestNo;
                uc.dtDateRequest.Value = dateOfRequest;
                uc.txtReferenceNo.Text = referenceNo;
                uc.txtPayee.Text = payee;
                uc.txtExplanation.Text = explanation;
                lblCreatedBy.Text = createdBy;

                foreach (DataRow item in dtObligationRequest.Rows)
                {
                    string remarks = item["remarks"].ToString();

                    var obligationRequest = new object[]
                    {
                        item["budget_appropriations_id"],
                        $"{item["ledger_name"]} ({remarks})",
                        item["account_code"],
                        item["amount"]
                    };

                    uc.dgObligationRequests.Rows.Add(obligationRequest);
                    uc.GetTotalObligations();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        private bool InsertData(ref string message)
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

                if (Helper.HasPermission("Transaction Obligation Request Approved"))
                {
                    obligationRequestModel.IsApproved = true;
                    obligationRequestModel.IsDisapproved = false;
                    obligationRequestModel.IsCancelled = false;
                    obligationRequestModel.DisapprovalMessage = string.Empty;
                }

                message = "Obligation Request has been saved.";
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

        private bool UpdateData(ref string message)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bool updated = true;

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

                    string ObligationRequestStatus = Factory.ObligationRequestRepository().GetObligationRequestStatus(uc.obligationRequestId);

                    if (ObligationRequestStatus.ToLower() == "disapproved")
                    {
                        _ = Factory.ObligationRequestRepository().SetObligationRequestStatus(uc.obligationRequestId, "pending");
                        obligationRequestModel.DisapprovalMessage = string.Empty;
                        message = "Obligation request updated and will be send back to pending.";
                    }
                    else
                        message = "Obligation Request has been Updated";

                    _ = Factory.ObligationRequestRepository().Update(obligationRequestModel, ObligationAccountsModelList());

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
                    updated = false;
                }

                if (updated)
                    return true;
                else
                    return false;
            }
        }

        private bool SaveData(ref string message)
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            bool saveData;

            if (!uc.isEdit)
                saveData = InsertData(ref message);
            else
                saveData = UpdateData(ref message);

            return saveData;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (SaveData(ref message))
            {
                Helper.MessageBoxSuccess(message);
                uc.ResetForm();
                ResetControls();
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
                ResetControls();
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

        internal void ResetControls()
        {
            if (!uc.isEdit)
            {
                btnApprove.Enabled = false;
                btnDisapprove.Enabled = false;
                btnCancelObligation.Enabled = false;
                lblStatus.Text = "--";
                lblCreatedBy.Text = "--";
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
                lblCreatedBy.Text = "--";
            }

        }

        private void VerifyPermissions()
        {
            if (!Helper.HasPermission("Transaction Obligation Request Approval"))
            {
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
                btnCancelObligation.Visible = false;
                toolStripSeparator1.Visible = false;
            }
        }

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {
            ResetControls();
            VerifyPermissions();
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
            _ = new frmObligationRequestDisapproval(this).ShowDialog();
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

        private void linkShowMessage_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestDisapproval(this).ShowDialog();
        }
    }
}
