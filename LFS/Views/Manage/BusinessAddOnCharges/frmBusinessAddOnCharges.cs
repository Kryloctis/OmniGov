using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.BusinessAdOnCharges
{
    public partial class frmBusinessAddOnCharges : Form
    {
        public frmBusinessAddOnCharges()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBusinessAddOnCharges, true);
        }

        internal void LoadBusinessAddOnCharges()
        {
            var searchText = toolStripTextBoxSearch.Text.Trim();
            var dt = TreasuryFactory.BusinessAddOnChargesRepository().GetRecordsBySearch(searchText);
            HelperLoadRecords.BusinessAddOnChargesDataGridView(dgBusinessAddOnCharges, dt);
            dgBusinessAddOnCharges.CurrentCell = dgBusinessAddOnCharges.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgBusinessAddOnCharges.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddBusinessAddOnCharges(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int businessAddOnChargesID = Convert.ToInt32(dgBusinessAddOnCharges.SelectedRows[0].Cells[0].Value);
                _ = new frmEditBusinessAddOnCharges(businessAddOnChargesID, this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmBusinessAddOnCharges_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBusinessAddOnCharges();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBusinessAddOnCharges();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRecordTimeStamp(DataGridView dataGridView)
        {
            var createdAtColumnIndex = dataGridView.Columns["created_at"].Index;
            var updatedAtColumnIndex = dataGridView.Columns["updated_at"].Index;

            byte[] indexes = { (byte)createdAtColumnIndex, (byte)updatedAtColumnIndex };
            Helper.ShowRecordTimestamp(dataGridView, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
        }

        private void dgBusinessCategories_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgBusinessAddOnCharges, btnEdit, btnDelete);
                LoadRecordTimeStamp(dgBusinessAddOnCharges);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletedRecordCount;

                if (DeleteBusinessAddOnCharges(out deletedRecordCount))
                {
                    Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                    LoadBusinessAddOnCharges();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteBusinessAddOnCharges(out int deletedCount)
        {
            try
            {
                var businessAdOnChargesModelList = new List<BusinessAddOnChargesModel>();
                int rowCount = dgBusinessAddOnCharges.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgBusinessAddOnCharges.SelectedRows)
                    {
                        int businessAddOnID = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new BusinessAddOnChargesModel() { BusinessAddOnChargesID = businessAddOnID };
                        businessAdOnChargesModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return TreasuryFactory.BusinessAddOnChargesRepository().Delete(businessAdOnChargesModelList);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }
    }
}
