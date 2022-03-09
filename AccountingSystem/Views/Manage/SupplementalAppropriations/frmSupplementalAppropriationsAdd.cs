using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsAdd : Form
    {
        ucSupplementalAppropriations uc;
        ucSupplementalAppropriationsMain _ucSupplementalAppropriationsMain;

        public frmSupplementalAppropriationsAdd(ucSupplementalAppropriationsMain ucSupplementalAppropriationsMain)
        {
            InitializeComponent();
            uc = ucSupplementalAppropriations1;
            _ucSupplementalAppropriationsMain = ucSupplementalAppropriationsMain;
        }

        private bool AddSupplemental()
        {
            DateTime dateEntry = uc.dtpDateEntry.Value;
            decimal amount = uc.nudAmount.Value;
            string remarks = uc.txtRemarks.Text.Trim();

            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var row = new object[] { dateEntry, amount, remarks };

            _ucSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows.Add(row);
            _ucSupplementalAppropriationsMain.GetTotalSupplementalAmount();

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AddSupplemental())
            {
                uc.ResetForm();
            }
        }
    }
}
