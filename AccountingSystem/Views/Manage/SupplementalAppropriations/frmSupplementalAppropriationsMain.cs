using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsMain : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriations;
        internal int budgetAppropriationsId;
        internal DateTime dateEntry;

        public frmSupplementalAppropriationsMain(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
        }

    }
}
