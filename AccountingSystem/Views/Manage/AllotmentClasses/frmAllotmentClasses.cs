using ACC.Domain.Models;
using System;
using System.Collections.Generic;
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
            var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
            var dtAllotmentClasses = allotmentClassesRepository.GetRecords();
            HelperLoadRecords.AllotmentClassesDatagridView(dtAllotmentClasses, dgAllotmentClasses);

            lblRecordCount.Text = allotmentClassesRepository.CountRecords().ToString();
        }

        private void frmAllotmentClasses_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentClassesAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAllotmentClasses.CurrentRow.Index;
            int allotmentId = Convert.ToInt32(dgAllotmentClasses.Rows[rowIndex].Cells["id"].Value);

            _ = new frmAllotmentClassesEdit(this, allotmentId).ShowDialog();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void dgAllotmentClasses_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgAllotmentClasses, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgAllotmentClasses, btnEdit, btnDelete);
        }
    }
}