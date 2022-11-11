using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BusinessCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
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
            try
            {
                var dt = new DataTable();
                var searchText = toolStripTextBoxSearch.Text.Trim();

                if (searchText.Length > 2)
                    dt = AccFactory.BusinessAddOnChargesRepository().GetRecordsBySearch(searchText);
                else
                    dt = AccFactory.BusinessAddOnChargesRepository().GetRecords();

                HelperLoadRecords.BusinessAddOnChargesDataGridView(dgBusinessAddOnCharges, dt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBusinessAddOnCharges(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int businessAddOnChargesID = Convert.ToInt32(dgBusinessAddOnCharges.SelectedRows[0].Cells[0].Value);
            _ = new frmEditBusinessAddOnCharges(businessAddOnChargesID, this).ShowDialog();
        }

        private void frmBusinessAddOnCharges_Load(object sender, EventArgs e)
        {
            LoadBusinessAddOnCharges();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadBusinessAddOnCharges();
        }

        private void dgBusinessCategories_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBusinessAddOnCharges, btnEdit, btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (DeleteBusinessAddOnCharges(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadBusinessAddOnCharges();
            }
        }

        private bool DeleteBusinessAddOnCharges(out int deletedCount)
        {
            try
            {
                var businessAdOnChargesModelList = new List<BusinessAdOnChargesModel>();
                int rowCount = dgBusinessAddOnCharges.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgBusinessAddOnCharges.SelectedRows)
                    {
                        int businessAddOnID = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new BusinessAdOnChargesModel() { BusinessAdOnChargesID = businessAddOnID };
                        businessAdOnChargesModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.BusinessAddOnChargesRepository().Delete(businessAdOnChargesModelList);
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
