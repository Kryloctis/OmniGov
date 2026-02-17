using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.Barangay
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
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
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
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxSuccess($"{dgBarangay.SelectedRows.Count} record/s has been deleted.");
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
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

                return Factory.BarangayRepository().Delete(barangayModelList);
            }

            return false;
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                string searchKey = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync((rowLimit, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rowLimit, string searchKey))e.Argument;
                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("code", typeof(string)),
                    new DataColumn("name", typeof(string)),
                };
                dataTable.Columns.AddRange(dataColumns);

                var dtBarangayFromDb = Factory.BarangayRepository().GetRecordsBySearch(parameters.rowLimit, parameters.searchKey, ServerHelper.selectedServer.LguId);
                int totalProgressCount = dtBarangayFromDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtBarangayFromDb.Rows)
                {
                    var newRow = dataTable.NewRow();
                    newRow["id"] = Convert.ToInt32(row["id"]);
                    newRow["code"] = row["code"].ToString();
                    newRow["name"] = row["name"].ToString();

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
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
                    pbLoadRecords.Value = 100;

                HelperLoadRecords.BarangaysDatagridView(dgBarangay, dataTable);
                dgBarangay.CurrentCell = dgBarangay.FirstDisplayedCell;
                lblRecordCount.Text = dgBarangay.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

