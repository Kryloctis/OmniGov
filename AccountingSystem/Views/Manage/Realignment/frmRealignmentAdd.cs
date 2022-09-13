using ACC.Domain.Models;
using System;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.BudgetAppropriations;

namespace AccountingSystem.Views.Manage.Realignment
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
