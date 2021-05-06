using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriations : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriations;
        internal int budgetAppropriationsId;
        internal DateTime dateEntry;

        public frmSupplementalAppropriations(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBudgetAppropriations = frmBudgetAppropriations;
            btnAdd.Click += new EventHandler(BtnAdd_Click);
        }

        private void ShowSupplementalAppropriationAdd() 
        {
            var frmSupplementalAppropriationAdd = new frmSupplementalAppropriationAdd(this);

            frmSupplementalAppropriationAdd.uc.budgetAppropriationId = budgetAppropriationsId;
            frmSupplementalAppropriationAdd.uc.dateEntry = dateEntry;

            frmSupplementalAppropriationAdd.ShowDialog();
        }

        private void ShowSupplementaryStatus() 
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (dataGridView1.SelectedRows.Count == 1) 
            {
                var rowDateEntry = dataGridView1.Rows[rowIndex].Cells["date_entry"].Value.ToString();
                var rowCreatedAt = dataGridView1.Rows[rowIndex].Cells["created_at"].Value.ToString();
                var rowUpdatedAt = dataGridView1.Rows[rowIndex].Cells["updated_at"].Value.ToString();

                var dateEntry = string.IsNullOrEmpty(rowDateEntry) ? null : Convert.ToDateTime(rowDateEntry).ToString("MM/dd/yyyy");
                var createdAt = string.IsNullOrEmpty(rowCreatedAt) ? null : Convert.ToDateTime(rowCreatedAt).ToString("MM/dd/yyyy");
                var updatedAt = string.IsNullOrEmpty(rowUpdatedAt)? null : Convert.ToDateTime(rowUpdatedAt).ToString("MM/dd/yyyy");

                lblDateEntry.Text = dateEntry;
                lblCreatedAt.Text = createdAt;
                lblUpdatedAt.Text = updatedAt;
            }
        }

        internal void LoadSupplementalApproprations() 
        {
            var supplementalRepo = Factory.SupplementalAppropriationsRepository().GetRecordsById(budgetAppropriationsId);

            HelperLoadRecords.SupplementalDatagridView(supplementalRepo, dataGridView1);

            lblRecordCounts.Text = dataGridView1.Rows.Count.ToString();

            //Show Total Value 
            txtTotalSupplementalAppropriations.Text = (from DataGridViewRow row in dataGridView1.Rows
                                             where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                             select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriationAdd();
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
            LoadSupplementalApproprations();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ShowSupplementaryStatus();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}
