using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.RptTaxRates
{
    public partial class frmRptTaxRates : Form
    {
        public frmRptTaxRates()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddRptTaxRate(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowEditForm()
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int rptTaxRatesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditRptTaxRates(rptTaxRatesId, this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEditForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Delete(out int deletedCount)
        {
            var rptTaxRatesModelList = new List<RptTaxRatesModel>();
            int rowCount = dataGridView1.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(rowCount))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int penaltiesId = Convert.ToInt32(row.Cells["id"].Value);
                    var model = new RptTaxRatesModel() { Id = penaltiesId };
                    rptTaxRatesModelList.Add(model);
                }

                deletedCount = rowCount;
                return TreasuryFactory.RptTaxRatesRepository().Delete(rptTaxRatesModelList);
            }

            deletedCount = 0;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletedRecordCount;

                if (Delete(out deletedRecordCount))
                {
                    Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                    LoadTaxRates();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void frmRptTaxRates_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTaxRates();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaxRates();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadTaxRates()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchText = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync(searchText);
            }
        }

        private DataColumn[] TaxRatesDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("code", typeof(string)),
                new DataColumn("description", typeof(string)),
                new DataColumn("rate", typeof(decimal)),
            };

            return dataColumns;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var searchText = e.Argument as string;

                DataTable dataTable = new DataTable();
                DataTable dtTaxRatesFromDb = TreasuryFactory.RptTaxRatesRepository().GetRecordsBySearch(searchText);

                dataTable.Columns.AddRange(TaxRatesDataColumns());

                if (dtTaxRatesFromDb.Rows.Count < 1)
                {
                    backgroundWorker1.ReportProgress(100);
                    e.Result = dataTable;
                    return;
                }

                int progressCount = 0;
                int totalProgressCount = dtTaxRatesFromDb.Rows.Count;

                foreach (DataRow row in dtTaxRatesFromDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    int id = Convert.ToInt32(row["id"]);
                    string code = row["code"].ToString();
                    string description = row["description"].ToString();
                    decimal rate = Convert.ToDecimal(row["rate"]);

                    newRow["id"] = id;
                    newRow["code"] = code;
                    newRow["description"] = description;
                    newRow["rate"] = rate;
                    dataTable.Rows.Add(newRow);

                    progressCount++;
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.TaxRatesDatagridView(dataGridView1, dataTable);
            int recordCount = dataGridView1.RowCount;
            lblRecordCount.Text = recordCount.ToString();
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}