using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignment : Form
    {

        internal ushort budgetAppropriationId;
        internal string budgetAppropriationAccount;
        internal string budgetAppropriationAmount;

        public frmRealignment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignment_Load(object sender, EventArgs e)
        {
            LoadSelectedAppropriation();
            LoadBudgetRealignments();
        }

        private void LoadBudgetRealignments()
        {
            var dtBudgetRealignment = Factory.BudgetRealignmentRepository().GetRecordsByBudgetAppropriationId(budgetAppropriationId);
            HelperLoadRecords.BudgetRealignmentDatagridView(dtBudgetRealignment, dgRealignment);
        }

        private void LoadSelectedAppropriation()
        {
            txtAccountSelected.Text = budgetAppropriationAccount;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmRealignmentAdd  = new frmRealignmentAdd();
            frmRealignmentAdd._budgetAppropriationAmount = budgetAppropriationAmount;
            frmRealignmentAdd.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRealignment, btnEdit, btnDelete);
        }
    }
}
