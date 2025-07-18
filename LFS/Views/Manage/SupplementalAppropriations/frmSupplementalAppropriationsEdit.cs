using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsEdit : Form
    {
        private ucSupplementalAppropriations uc;
        private frmSupplementalAppropriationsMain _FrmSupplementalAppropriationsMain;
        internal int rowIndex;

        public frmSupplementalAppropriationsEdit(frmSupplementalAppropriationsMain frmSupplementalAppropriationsMain)
        {
            InitializeComponent();
            _FrmSupplementalAppropriationsMain = frmSupplementalAppropriationsMain;
            uc = ucSupplementalAppropriations1;
        }

        private bool UpdateSupplemental()
        {
            try
            {
                if (rowIndex != -1)
                {
                    var dateEntry = uc.dtpDateEntry.Value;
                    decimal amount = uc.nudAmount.Value;
                    string remarks = uc.txtRemarks.Text.Trim();

                    _FrmSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["date_entry"].Value = dateEntry;
                    _FrmSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["amount"].Value = amount;
                    _FrmSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["remarks"].Value = remarks;
                    _FrmSupplementalAppropriationsMain.GetTotalSupplementalAmount();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (UpdateSupplemental())
            {
                Close();
            }
        }
    }
}