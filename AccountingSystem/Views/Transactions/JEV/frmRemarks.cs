using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmRemarks : Form
    {
        internal bool isDissaprove;
        private bool isAccepted = false;
        frmJEV _frmJEV;

        public frmRemarks(frmJEV frmjev)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            _frmJEV = frmjev;
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {

        }

        private bool SetJEVToDisapproved()
        {
            try
            {
                var userId = Helper.UserId;

                if (!_frmJEV.FormValidations())
                    return false;

                var isDisapproved = Factory.JEVRepository().SetJEVStatus(_frmJEV.ucjev1.jevId, 2);

                //return isApproved ? true : false;
                return isDisapproved;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isDissaprove)
            {
                if (MessageBox.Show("Are you sure you want to disapproved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (SetJEVToDisapproved())
                    {
                        Helper.MessageBoxSuccess("JEV has been disapproved.");
                        _frmJEV.CheckJevStatus(_frmJEV.ucjev1.jevId);
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
