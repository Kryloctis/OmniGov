using ACC.Data;
using ACC.Domain.Models;
using LFS.Views.Manage.BusinessCategories.AddOnCharges;
using LFS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LFS.Views.Manage.BusinessCategories
{
    public partial class frmBusinessCategories : Form
    {
        public frmBusinessCategories()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBusinessCategories, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddBusinessCategories(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete, ToolStripButton tsBtnAddOnCharges)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
                tsBtnAddOnCharges.Enabled = true;
            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
                tsBtnDelete.Text = "Delete (" + SelectedRows + ")";
                tsBtnAddOnCharges.Enabled = false;
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
                tsBtnDelete.Text = "Delete";
                tsBtnAddOnCharges.Enabled = false;
            }
        }

        private void OnLoad()
        {
            LoadBusinessCategories();
        }

        private void frmBusinessCategories_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadBusinessCategories()
        {
            var searchText = toolStripTextBoxSearch.Text.Trim();
            var dtBusinessCategories = AccFactory.BusinessCategoriesRepository().GetRecordsBySearch(searchText);
            var dataTable = dtBusinessCategories.Clone();
            dataTable.Columns["is_line_of_business"].DataType = typeof(bool);
            foreach (DataRow row in dtBusinessCategories.Rows) { dataTable.Rows.Add(row.ItemArray); }
            HelperLoadRecords.BusinessCategoriesDataGridView(dgBusinessCategories, dataTable);
            dgBusinessCategories.CurrentCell = dgBusinessCategories.FirstDisplayedCell;
            EnableDisableToolStripButtons(dgBusinessCategories, btnEdit, btnDelete, btnAddOnCharges);
            toolStripStatusLabelRecordCount.Text = dgBusinessCategories.Rows.Count.ToString();
        }

        private int GetCurrentCellId()
        {
            int rowIndex = dgBusinessCategories.CurrentCell.RowIndex;
            return Convert.ToInt32(dgBusinessCategories.Rows[rowIndex].Cells["id"].Value);
        }

        private void LoadBusinessCategoriesAddons(int businessCategoriesId)
        {
            listBox1.Items.Clear();
            var dtBusinessAddons = AccFactory.BusinessCategoriesHasAddOnCharges().GetViewRecordsByBusinessCategoriesId(businessCategoriesId);
            foreach (DataRow item in dtBusinessAddons.Rows) { listBox1.Items.Add($"{item["business_add_on_charges_code"]}-{item["business_add_on_charges_description"]}"); }
        }

        private void LoadRecordTimestamp(DataGridView dataGridView)
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
                EnableDisableToolStripButtons(dgBusinessCategories, btnEdit, btnDelete, btnAddOnCharges);
                LoadRecordTimestamp(dgBusinessCategories);
                LoadBusinessCategoriesAddons(GetCurrentCellId());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteBusinessCategories(ref int deletedCount)
        {
            var businessCategoriesModelList = new List<BusinessCategoriesModel>();
            int rowCount = dgBusinessCategories.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(rowCount))
            {
                foreach (DataGridViewRow row in dgBusinessCategories.SelectedRows)
                {
                    int businessCategoriesID = Convert.ToInt32(row.Cells["id"].Value);
                    var model = new BusinessCategoriesModel() { BusinessCategoryID = businessCategoriesID };
                    businessCategoriesModelList.Add(model);
                }

                deletedCount = rowCount;
                return AccFactory.BusinessCategoriesRepository().Delete(businessCategoriesModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletedRecordCount = 0;

                if (DeleteBusinessCategories(ref deletedRecordCount))
                {
                    Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                    LoadBusinessCategories();
                }
            }
            catch (MySqlException sqlEx)
            { Debug.WriteLine(sqlEx.ErrorCode); }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmEditBusinessCategories(GetCurrentCellId(), this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBusinessCategories();
        }

        private void ShowAddOnCharges()
        {
            int rowIndex = dgBusinessCategories.CurrentCell.RowIndex;
            int categoriesId = Convert.ToInt32(dgBusinessCategories.Rows[rowIndex].Cells["id"].Value);

            _ = new frmBusinessCategoriesAddOnCharges(categoriesId, this).ShowDialog();
        }

        private void btnAddOnCharges_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAddOnCharges();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}