using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dashboard;
using LFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptPenalties
{
    public partial class frmRptPenalties : Form
    {
        public frmRptPenalties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddRptPenalty(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int penaltiesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                _ = new frmEditRptPenalties(penaltiesId, this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Delete(out int deletedCount)
        {
            var rptPenalitiesModelList = new List<RptPenaltiesModel>();
            int rowCount = dataGridView1.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(rowCount))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int penaltiesId = Convert.ToInt32(row.Cells["id"].Value);
                    var model = new RptPenaltiesModel() { Id = penaltiesId };
                    rptPenalitiesModelList.Add(model);
                }

                deletedCount = rowCount;
                return AccFactory.RptPenaltiesRepository().Delete(rptPenalitiesModelList);
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
                    LoadPenalties();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptPenalties_Load(object sender, EventArgs e)
        {
            LoadPenalties();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadPenalties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadPenalties()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchText = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync(searchText);
            }
        }

        private DataColumn[] DataColumnsPenalties()
        {
            return new DataColumn[]
            {
                new DataColumn(Name  = "id", typeof(int)),
                new DataColumn(Name =  "description", typeof(string)),
                new DataColumn(Name = "frequency", typeof(string)),
                new DataColumn(Name = "rate", typeof(decimal))
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var searchText = e.Argument as string;
                DataTable dtRptPenalties = AccFactory.RptPenaltiesRepository().GetRecordsBySearch(searchText);
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(DataColumnsPenalties());

                if (dtRptPenalties.Rows.Count < 1)
                {
                    backgroundWorker1.ReportProgress(100);
                    e.Result = dataTable;
                    return;
                }

                int progressCount = 0;
                int totalProgressCount = dtRptPenalties.Rows.Count;

                foreach (DataRow row in dtRptPenalties.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    string description = row["description"].ToString();
                    string frequency = row["frequency"].ToString();
                    decimal rate = Convert.ToDecimal(row["rate"]);

                    newRow["id"] = id;
                    newRow["description"] = description;
                    newRow["frequency"] = frequency;
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

            HelperLoadRecords.PenaltiesDatagridView(dataGridView1, dataTable);
            int recordCount = dataGridView1.RowCount;
            lblRecordCount.Text = recordCount.ToString();
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}