using ACC.Data;
using ACC.Domain.Models;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
            if (!backgroundWorker1.IsBusy)
            {
                string searchText = txtSearch.Text.Trim();
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((rowLimit, searchText));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddAllotmentClasses(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxError($"{dgAllotmentClasses.Rows.Count} record/s has been deleted.");
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgAllotmentClasses.CurrentRow.Index;
                int allotmentId = Convert.ToInt32(dgAllotmentClasses.Rows[rowIndex].Cells["id"].Value);

                _ = new frmEditAllotmentClasses(this, allotmentId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rowLimit, string searchKey))e.Argument;

                var dtAllotmentClasses = AccFactory.AllotmentClassesRepository().GetRecordsBySearch(parameters.rowLimit, parameters.searchKey.Trim());
                int totalProgressCount = dtAllotmentClasses.Rows.Count;
                int progressCount = 0;

                dtAllotmentClasses.Rows.Cast<DataRow>().ToList().ForEach(row => { progressCount++; Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount); });

                e.Result = dtAllotmentClasses;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                {
                    progressBar1.Value = 100;
                }

                HelperLoadRecords.AllotmentClassesDatagridView(dataTable, dgAllotmentClasses);
                dgAllotmentClasses.CurrentCell = dgAllotmentClasses.FirstDisplayedCell;
                lblRecordCount.Text = dgAllotmentClasses.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}