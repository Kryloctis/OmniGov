using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentEdit : Form
    {
        private ucRealignment uc;
        private readonly frmRealignment _frmRealignment;
        private readonly frmBudgetAppropriations _frmBudgetAppropriations;

        public frmRealignmentEdit(frmRealignment frmRealignment, frmBudgetAppropriations frmBudgetAppropriation)
        {
            InitializeComponent();
            uc = ucRealignment1;
            _frmRealignment = frmRealignment;
            _frmBudgetAppropriations = frmBudgetAppropriation;
        }

        private void frmRealignmentEdit_Load(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
    }
}
