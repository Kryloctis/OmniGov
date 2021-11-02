using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using MySql.Data.MySqlClient;
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

        public frmSupplementalAppropriations(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void ShowSupplementalAppropriationsEdit()
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                var frmSupplementalAppropriationEdit = new frmSupplementalAppropriationsEdit(this);
                var ucfrmSupplementalAppropriationEdit = frmSupplementalAppropriationEdit.ucSupplementalAppropriations1;

                int supplementalAppropriationId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                ucfrmSupplementalAppropriationEdit.supplementalAppropriationId = supplementalAppropriationId;
                ucfrmSupplementalAppropriationEdit.budgetAppropriationId = budgetAppropriationsId;

                frmSupplementalAppropriationEdit.ShowDialog();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriationsEdit();
        }

        private bool DeleteSupplementalRecords() 
        {
            try
            {
                var supplementalAppropriationsModelList = new List<SupplementalAppropriationsModel>();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int supplementalAppropriationId = int.Parse(row.Cells[0].Value.ToString());
                    var supplementalAppropriationsModel = new SupplementalAppropriationsModel()
                    {
                        Id = supplementalAppropriationId
                    };

                    supplementalAppropriationsModelList.Add(supplementalAppropriationsModel);
                }

                return  Factory.SupplementalAppropriationsRepository().Delete(supplementalAppropriationsModelList);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowsCount = dataGridView1.SelectedRows.Count;

                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        if (DeleteSupplementalRecords())
                        {
                            LoadSupplementalApproprations();
                            _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                            Helper.MessageBoxSuccess("Supplemental Appropriation has been deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ShowSupplementalAppropriationAdd() 
        {
            var frmSupplementalAppropriationAdd = new frmSupplementalAppropriationAdd(this);
            frmSupplementalAppropriationAdd.uc.budgetAppropriationId = budgetAppropriationsId;
            frmSupplementalAppropriationAdd.ShowDialog();
        }

        private void ShowSupplementaryStatus() 
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (dataGridView1.SelectedRows.Count == 1) 
            {
                var dateEntry = dataGridView1.Rows[rowIndex].Cells["date_entry"].Value.ToString();
                var createdAt = dataGridView1.Rows[rowIndex].Cells["created_at"].Value.ToString();
                var updatedAt = dataGridView1.Rows[rowIndex].Cells["updated_at"].Value.ToString();


                lblDateEntry.Text = dateEntry;
                lblCreatedAt.Text = createdAt;
                lblUpdatedAt.Text = updatedAt;
            }
        }

        internal void LoadSupplementalApproprations() 
        {
            var supplementalRepo = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(budgetAppropriationsId);

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
