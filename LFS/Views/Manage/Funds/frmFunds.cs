using LFS.Helpers;
using OmniGov.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Manage.Funds
{
    public partial class frmFunds : Form
    {
        public frmFunds()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgFunds, true);
        }

        private void frmFunds_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxFilter);
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFundAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgFunds.CurrentRow.Index;
                int fundId = Convert.ToInt32(dgFunds.Rows[rowIndex].Cells["id"].Value);
                _ = new frmFundEdit(this, fundId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgFunds.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var fundsModelList = new List<FundsModel>();
                    foreach (DataGridViewRow row in dgFunds.SelectedRows)
                    {
                        int fundId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        fundsModelList.Add(new FundsModel() { Id = fundId });
                    }

                    return AccFactory.FundsRepository().Delete(fundsModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxError($"{dgFunds.SelectedRows.Count} record/s has been deleted.");
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgFunds_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                Helper.ShowRecordTimestamp(dgFunds, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgFunds, btnEdit, btnDelete);
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

        private void cmbxFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowLimit = Convert.ToInt32(cmbxFilter.SelectedValue);
                progressBar1.Value = 0;

                backgroundWorker1.RunWorkerAsync((searchKey, rowLimit));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowLimit))e.Argument;
                DataTable dtFunds = AccFactory.FundsRepository().GetRecords(parameters.searchKey, parameters.rowLimit);
                int totalProgressCount = dtFunds.Rows.Count;
                int progressCount = 0;

                dtFunds.Rows.Cast<DataRow>().ToList().ForEach(row => { progressCount++; Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount); });
                e.Result = dtFunds;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                HelperLoadRecords.FundsDatagridView(dataTable, dgFunds);
                dgFunds.CurrentCell = dgFunds.FirstDisplayedCell;
                lblRecordCount.Text = dgFunds.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}