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

        internal string budgetAppropriationId;
        internal string budgetAppropriationAccount;
        internal string budgetAppropriationAmount;

        public frmRealignment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignment_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.Text} > {budgetAppropriationAccount.Trim()}";
            LoadSelectedAppropriation();
            LoadBudgetRealignments();

            txtTotalRealignmentAppropriation.Text = (from DataGridViewRow row in dgRealignment.Rows
                                                       where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                                       select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

        }

        internal void LoadBudgetRealignments()
        {
            var dtBudgetRealignment = Factory.BudgetRealignmentRepository().GetRecordsByBudgetAppropriationId(int.Parse(budgetAppropriationId));
            HelperLoadRecords.BudgetRealignmentDatagridView(dtBudgetRealignment, dgRealignment);
        }

        private void LoadSelectedAppropriation()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmRealignmentAdd  = new frmRealignmentAdd(this);
            frmRealignmentAdd._budgetAppropriationAmount = budgetAppropriationAmount;
            frmRealignmentAdd._budgetAppropriationId = budgetAppropriationId;
            frmRealignmentAdd.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRealignment, btnEdit, btnDelete);
        }
    }
}
