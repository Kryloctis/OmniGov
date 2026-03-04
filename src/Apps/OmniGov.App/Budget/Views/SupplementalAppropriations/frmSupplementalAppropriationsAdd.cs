using OmniGov.App.Helpers;

namespace OmniGov.App.Budget.Views.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsAdd : Form
    {
        private ucSupplementalAppropriations uc;
        private frmSupplementalAppropriationsMain _FrmSupplementalAppropriationsMain;

        public frmSupplementalAppropriationsAdd(frmSupplementalAppropriationsMain frmSupplementalAppropriationsMain)
        {
            InitializeComponent();
            uc = ucSupplementalAppropriations1;
            _FrmSupplementalAppropriationsMain = frmSupplementalAppropriationsMain;
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

            _FrmSupplementalAppropriationsMain.dgSupplementalAppropriations.Rows.Add(row);
            _FrmSupplementalAppropriationsMain.GetTotalSupplementalAmount();

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
