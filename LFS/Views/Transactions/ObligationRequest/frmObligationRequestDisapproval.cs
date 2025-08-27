using ACC.Data;
using ACC.Domain.Interfaces;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestDisapproval : Form
    {
        private frmObligationRequestMain _frmObligationRequestMain;

        public frmObligationRequestDisapproval(frmObligationRequestMain frmObligationRequestMain)
        {
            InitializeComponent();
            _frmObligationRequestMain = frmObligationRequestMain;
        }

        private string GetFormErrors()
        {
            string[] errorArray = new string[]
            {
                txtDissaprovalMessage.Tag.ToString()
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private bool SetObligationStatus(string status, string disapprovalMessage)
        {
            try
            {
                return AccFactory.ObligationRequestRepository().SetObligationRequestStatus(_frmObligationRequestMain.ucObligationRequestMain1.obligationRequestId, status, disapprovalMessage);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool DisapproveObligationRequest()
        {
            try
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }

                string disapprovalMessage = txtDissaprovalMessage.Text.Trim();
                return SetObligationStatus("disapprove", disapprovalMessage);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private string GetDissaprovalMessage()
        {
            int obligationrequestId = _frmObligationRequestMain.ucObligationRequestMain1.obligationRequestId;
            string disapprovalMessage = AccFactory.ObligationRequestRepository().GetRecordByID(obligationrequestId)["disapproval_message"];

            return disapprovalMessage;
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Disapproval of obligation request.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, defaultButton: MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (DisapproveObligationRequest())
                {
                    Helper.MessageBoxSuccess("Obligation Request has been disapproved.");
                    _frmObligationRequestMain.GetObligationStatus();
                    Close();
                }
            }
        }

        private void frmObligationRequestDisapproval_Load(object sender, EventArgs e)
        {
            if (AccFactory.ObligationRequestRepository().GetObligationRequestStatus(_frmObligationRequestMain.ucObligationRequestMain1.obligationRequestId).ToLower() == "disapproved")
            {
                if (_frmObligationRequestMain.ucObligationRequestMain1.Enabled)
                    btnAccept.Visible = false;

                btnDisapprove.Visible = false;
                txtDissaprovalMessage.Text = GetDissaprovalMessage();

                btnCancel.Text = "Close";
            }
            else
            {
                btnAccept.Visible = false;
                btnSaveMessage.Visible = false;
                AcceptButton = btnDisapprove;
            }

            VerifyPermissions();
        }

        private void VerifyPermissions()
        {
            if (!PrivilegesHelper.HasPrivilege(Privileges.TransObligationAppr))
            {
                btnSaveMessage.Visible = false;
                txtDissaprovalMessage.SelectionStart = 0;
                txtDissaprovalMessage.ReadOnly = true;
            }

            var dictObligationRequest = AccFactory.ObligationRequestRepository().GetViewRecordById(_frmObligationRequestMain.ucObligationRequestMain1.obligationRequestId);

            int obligationRequestCreatedById = Convert.ToInt32(dictObligationRequest["created_by_id"]);

            if (obligationRequestCreatedById != Helper.userId)
                btnAccept.Enabled = false;
        }

        private void txtDissaprovalMessage_Validating(object sender, CancelEventArgs e)
        {
            if (txtDissaprovalMessage.Text == string.Empty)
            {
                txtDissaprovalMessage.Tag = "Please enter a disapproval message";
                e.Cancel = true;
            }
            else
                e.Cancel = false;
        }

        private void txtDissaprovalMessage_Validated(object sender, EventArgs e)
        {
            txtDissaprovalMessage.Tag = string.Empty;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _frmObligationRequestMain.btnSave.Enabled = true;
            _frmObligationRequestMain.ucObligationRequestMain1.Enabled = true;
            Close();
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            if (DisapproveObligationRequest()) Helper.MessageBoxSuccess("Disapproval message has been updated.");
        }
    }
}