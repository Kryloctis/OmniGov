using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsEdit : Form
    {
        ucSupplementalAppropriations uc;
        ucSupplementalAppropriationsMain _ucSupplementalAppropriationsMain;
        internal int rowIndex;

        public frmSupplementalAppropriationsEdit(ucSupplementalAppropriationsMain ucSupplementalAppropriationsMain)
        {
            InitializeComponent();
            _ucSupplementalAppropriationsMain = ucSupplementalAppropriationsMain;
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

                    _ucSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["date_entry"].Value = dateEntry;
                    _ucSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["amount"].Value = amount;
                    _ucSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows[rowIndex].Cells["remarks"].Value = remarks;
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
