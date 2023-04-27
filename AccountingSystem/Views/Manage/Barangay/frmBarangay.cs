using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmBarangay : Form
    {
        public frmBarangay()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBarangay, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBarangay(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBarangay.CurrentRow.Index;
            int barangayId = Convert.ToInt32(dgBarangay.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditBarangay(barangayId, this).ShowDialog();
        }

        private void frmBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            DataTable dtBarangay;
            var searchText = toolStripTextBoxSearch.Text.Trim();

            if (searchText.Length > 2)
                dtBarangay = AccFactory.BarangayRepository().GetRecordsBySearch(searchText);
            else
                dtBarangay = AccFactory.BarangayRepository().GetRecords();

            HelperLoadRecords.BarangaysDatagridView(dgBarangay, dtBarangay);
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgBarangay_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBarangay, btnEdit, btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (DeleteData(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadRecords();
            }
        }

        private bool DeleteData(out int deletedCount)
        {
            try
            {
                var barangayModelList = new List<BarangayModel>();
                int rowCount = dgBarangay.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dgBarangay.SelectedRows)
                    {
                        int barangayId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new BarangayModel() { Id = barangayId };
                        barangayModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.BarangayRepository().Delete(barangayModelList);
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