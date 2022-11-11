using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Barangay;
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgBusinessCategories_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBusinessCategories, btnEdit, btnDelete);
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
    }
}
