using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        }

        private void ShowSupplementalAppropriationsEdit()
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                var frmSupplementalAppropriationEdit = new frmSupplementalAppropriationsEdit(this);
                var ucfrmSupplementalAppropriationEdit = frmSupplementalAppropriationEdit.ucSupplementalAppropriations1;

                int supplementalAppropriationId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                ucfrmSupplementalAppropriationEdit.dateEntry = dateEntry;
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

                return Factory.SupplementalAppropriationsRepository().Delete(supplementalAppropriationsModelList);

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
                            LoadSupplementalApproprationsRecords();
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
            frmSupplementalAppropriationAdd.uc.dateEntry = dateEntry;
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

        internal void LoadSupplementalApproprationsRecords()
        {
            try
            {
                var supplementalRepo = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationId(budgetAppropriationsId);

                HelperLoadRecords.SupplementalDatagridView(supplementalRepo, dataGridView1);

                lblRecordCounts.Text = dataGridView1.Rows.Count.ToString();

                //Show Total Value 
                txtTotalSupplementalAppropriations.Text = (from DataGridViewRow row in dataGridView1.Rows
                                                           where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                                           select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowSupplementalAppropriationAdd();
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
            LoadSupplementalApproprationsRecords();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ShowSupplementaryStatus();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}
