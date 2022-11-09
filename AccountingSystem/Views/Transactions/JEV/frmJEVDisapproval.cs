using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVDisapproval : Form
    {

        frmJEV _frmJEV;

        public frmJEVDisapproval(frmJEV frmjev)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            _frmJEV = frmjev;
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

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            int jevId = _frmJEV.ucjev1.jevId;
            txtRemarks.Text = AccFactory.JEVRepository().GetRemarks(jevId);
            txtRemarks.SelectionStart = 0;
            PermissionVerification();
        }

        private bool SetRemarks()
        {
            try
            {
                if (!_frmJEV.FormValidations())
                    return false;

                int jevId = _frmJEV.ucjev1.jevId;
                var remarks = AccFactory.JEVRepository().SetRemarks(jevId, txtRemarks.Text.Trim());

                return remarks;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool SetJEVToDisapproved()
        {
            try
            {
                var userId = Helper.UserId;
                int jevId = _frmJEV.ucjev1.jevId;

                if (!_frmJEV.FormValidations())
                    return false;

                var isDisapproved = AccFactory.JEVRepository().SetJEVStatus(jevId, "disapprove");

                return isDisapproved;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
            }

            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _frmJEV.btnSave.Enabled = true;
            _frmJEV.btnSave.Text = "Update";
            _frmJEV.ucjev1.Enabled = true;
            Close();
        }

        private void btnSaveMessage_Click(object sender, EventArgs e)
        {
            if (SetRemarks())
            {
                Helper.MessageBoxSuccess("Dissaproval message has been saved.");
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to disapproved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (SetJEVToDisapproved() && SetRemarks())
                    {
                        Helper.MessageBoxSuccess("JEV has been disapproved.");
                        _frmJEV.GetJevStatus(_frmJEV.ucjev1.jevId);
                        _frmJEV._frmJEVList.LoadJEVList();
                        _frmJEV._ucJEVDashboard.LoadJEVCounter();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
