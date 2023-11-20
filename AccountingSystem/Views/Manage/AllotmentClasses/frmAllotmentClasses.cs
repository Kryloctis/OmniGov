using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class frmAllotmentClasses : Form
    {
        public frmAllotmentClasses()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAllotmentClasses, true);
        }

        internal void LoadRecords()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dataTable;

            if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
                dataTable = AccFactory.AllotmentClassesRepository().GetRecords();
            else
                dataTable = AccFactory.AllotmentClassesRepository().GetRecordsBySearch(searchText);

            HelperLoadRecords.AllotmentClassesDatagridView(dataTable, dgAllotmentClasses);

            lblRecordCount.Text = dgAllotmentClasses.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAllotmentClasses(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAllotmentClasses.CurrentRow.Index;
            int allotmentId = Convert.ToInt32(dgAllotmentClasses.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditAllotmentClasses(this, allotmentId).ShowDialog();
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgAllotmentClasses.SelectedRows.Count;

            if (selectedRowsCount < 1)
                return false;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var allotmentClassesModelList = new List<AllotmentClassesModel>();
                foreach (DataGridViewRow row in dgAllotmentClasses.SelectedRows)
                {
                    int allotmentId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    allotmentClassesModelList.Add(new AllotmentClassesModel() { Id = allotmentId });
                }

                return AccFactory.AllotmentClassesRepository().Delete(allotmentClassesModelList);
            }
            return false;
        }

        private void dgAllotmentClasses_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgAllotmentClasses, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgAllotmentClasses, btnEdit, btnDelete);
        }

        private void frmAllotmentClasses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}