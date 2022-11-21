using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Barangay;
using AccountingSystem.Views.Manage.BusinessAdOnCharges;
using AccountingSystem.Views.Manage.BusinessCategories.AddOnCharges;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessCategories
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
            _ = new frmAddBusinessCategories(this).ShowDialog();
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

        private void frmBusinessCategories_Load(object sender, EventArgs e)
        {
            LoadBusinessCategories();         
        }

        internal void LoadBusinessCategories()
        {
            try
            {
                var dt = new DataTable();   
                var searchText = toolStripTextBoxSearch.Text.Trim();

                if (searchText.Length > 2)
                    dt = AccFactory.BusinessCategoriesRepository().GetRecordsBySearch(searchText);
                else
                    dt = AccFactory.BusinessCategoriesRepository().GetRecords();

                HelperLoadRecords.BusinessCategoriesDataGridView(dgBusinessCategories, dt);
                dgBusinessCategories.CurrentCell = dgBusinessCategories.FirstDisplayedCell;
                EnableDisableToolStripButtons(dgBusinessCategories, btnEdit, btnDelete, btnAddOnCharges);
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void dgBusinessCategories_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableToolStripButtons(dgBusinessCategories, btnEdit, btnDelete, btnAddOnCharges);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (DeleteBusinessCategories(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadBusinessCategories();
            }
        }

        private bool DeleteBusinessCategories(out int deletedCount)
        {
            try
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
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int businessCategoriesID = Convert.ToInt32(dgBusinessCategories.SelectedRows[0].Cells[0].Value);

            _ = new frmEditBusinessCategories(businessCategoriesID, this).ShowDialog();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBusinessCategories();
        }

        private void ShowAddOnCharges() 
        {
            try
            {
                int rowIndex = dgBusinessCategories.CurrentCell.RowIndex;
                int categoriesId = Convert.ToInt32(dgBusinessCategories.Rows[rowIndex].Cells["id"].Value);

                _ = new frmBusinessCategoriesAddOnCharges(categoriesId, this).ShowDialog();
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void btnAddOnCharges_Click(object sender, EventArgs e)
        {
            ShowAddOnCharges();
        }
    }
}
