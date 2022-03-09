using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsMain : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriations;
        ucSupplementalAppropriationsMain uc;

        public frmSupplementalAppropriationsMain(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucSupplementalAppropriationsMain1;
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                return true;
            }
            catch (Exception ex) { Helper.MessageBoxSuccess(ex.Message); }
            return false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Supplemental appropriations has been saved.");
            }
        }
    }
}
