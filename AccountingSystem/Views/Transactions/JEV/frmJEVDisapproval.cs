using ACC.Data;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVDisapproval : Form
    {
        private frmJEV _frmJEV;

        public frmJEVDisapproval(frmJEV frmjev)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            _frmJEV = frmjev;
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            int jevId = _frmJEV.ucjev1.jevId;
            txtRemarks.Text = AccFactory.JEVRepository().GetRemarks(jevId);
            txtRemarks.SelectionStart = 0;
            PermissionVerification();
        }

        private void PermissionVerification()
        {
            if (_frmJEV.createdById != Helper.UserId)
                btnAccept.Enabled = false;

            if (!Helper.HasPermission("Transaction > JEV Approval"))
            {
                txtRemarks.ReadOnly = true;
                btnSaveMessage.Enabled = false;
            }
            else
                btnSaveMessage.Enabled = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _frmJEV.btnSave.Enabled = true;
            _frmJEV.btnSave.Text = "Update";
            _frmJEV.ucjev1.Enabled = true;
            _frmJEV.ucjev1.SetJevReadOnly(false);
            Close();
        }

        private bool DissaproveJev()
        {
            string remarks = txtRemarks.Text.Trim();

            if (!_frmJEV.FormValidations())
                return false;

            if (MessageBox.Show("Are you sure you want to disapproved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                return _frmJEV.UpdateData("disapproved", remarks);
            }
            return false;
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (DissaproveJev())
                {
                    Helper.MessageBoxSuccess("JEV has been disapproved.");
                    _frmJEV.GetJevStatus(_frmJEV.ucjev1.jevId);
                    _frmJEV._frmJEVList.LoadJEVList();
                    _frmJEV._ucJEVDashboard.LoadJEVCounter();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveDisapprovalMessage()
        {
            string remarks = txtRemarks.Text.Trim();

            return _frmJEV.UpdateData("disapproved", remarks);
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveDisapprovalMessage())

                    Helper.MessageBoxSuccess("Dissaproval message has been saved.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}