using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmRemarks : Form
    {
        internal bool isDissaprove;

        frmJEV _frmJEV;

        public frmRemarks(frmJEV frmjev)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            _frmJEV = frmjev;
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            int jevId = _frmJEV.ucjev1.jevId;
            txtRemarks.Text = Factory.JEVRepository().GetRemarks(jevId);
        }

        private bool SetRemarks()
        {
            try
            {
                if (!_frmJEV.FormValidations())
                    return false;

                int jevId = _frmJEV.ucjev1.jevId;
                var remarks = Factory.JEVRepository().SetRemarks(jevId, txtRemarks.Text.Trim());

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

                var isDisapproved = Factory.JEVRepository().SetJEVStatus(jevId, 2);

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
            if (isDissaprove)
            {
                if (MessageBox.Show("Are you sure you want to disapproved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (SetJEVToDisapproved() && SetRemarks())
                    {
                        Helper.MessageBoxSuccess("JEV has been disapproved.");
                        _frmJEV.ucjev1.isDisapproved = 1;
                        _frmJEV.CheckJevStatus(_frmJEV.ucjev1.jevId);
                        _frmJEV._frmJEVList.LoadJEVList();
                        _frmJEV._ucJEVDashboard.LoadJEVCounter();
                        Close();
                    }
                }
            }
            else
            {
                _frmJEV.btnSave.Enabled = true;
                _frmJEV.btnSave.Text = "Update";
                _frmJEV.ucjev1.Enabled = true;
                Close();
            }
        }
    }
}
