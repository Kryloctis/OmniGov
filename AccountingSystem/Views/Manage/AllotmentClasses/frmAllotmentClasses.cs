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
        }
        internal void LoadRecords()
        {
            try
            {
                var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
                var dtAllotmentClasses = allotmentClassesRepository.GetRecords();
                HelperLoadRecords.AllotmentClassesDatagridView(dtAllotmentClasses, dgAllotmentClasses);

                lblRecordCount.Text = allotmentClassesRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAllotmentClasses_Load(object sender, EventArgs e)
        {
            Helper.DatagridEditableRowStyle(dgAllotmentClasses, true);
            dgAllotmentClasses.ShowCellToolTips = false;
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentClassesAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int allotmentId = int.Parse(dgAllotmentClasses.SelectedCells[0].Value.ToString());
            _ = new frmAllotmentClassesEdit(this, allotmentId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgAllotmentClasses.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var allotmentClassesModelList = new List<AllotmentClassesModel>();
                        foreach (DataGridViewRow row in dgAllotmentClasses.SelectedRows)
                        {
                            int allotmentId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            allotmentClassesModelList.Add(new AllotmentClassesModel() { Id = allotmentId });
                        }

                        var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
                        _ = allotmentClassesRepository.Delete(allotmentClassesModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgAllotmentClasses_SelectionChanged_1(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgAllotmentClasses, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgAllotmentClasses, btnEdit, btnDelete);
        }
    }
}
