using OmniGov.App.Budget.Views.BudgetAppropriations;

namespace OmniGov.App.Budget.Views.Realignment
{
    public partial class frmRealignmentAdd : Form
    {
        private ucRealignment uc;
        private readonly frmRealignment _frmRealignment;
        private readonly frmBudgetAppropriations _frmBudgetAppropriations;

        public frmRealignmentAdd(frmRealignment frmRealignment, frmBudgetAppropriations frmBudgetAppropriation)
        {
            InitializeComponent();
            uc = ucRealignment1;
            _frmRealignment = frmRealignment;
            _frmBudgetAppropriations = frmBudgetAppropriation;
        }
    }
}
