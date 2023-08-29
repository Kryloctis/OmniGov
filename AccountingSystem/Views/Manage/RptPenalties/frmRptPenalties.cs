using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptPenalties
{
    public partial class frmRptPenalties : Form
    {
        private readonly MainForm _mainForm;

        public frmRptPenalties(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
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

        private DataTable DataTablePenalties(string searchText)
        {
            DataTable dtRptPenalties;
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsPenalties());

            if (searchText.Length < 2)
                dtRptPenalties = AccFactory.RptPenaltiesRepository().GetRecords();
            else
                dtRptPenalties = AccFactory.RptPenaltiesRepository().GetRecordsBySearch(searchText);

            int totalProgressCount = dtRptPenalties.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtRptPenalties.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string description = row["description"].ToString();
                string frequency = row["frequency"].ToString();
                decimal rate = Convert.ToDecimal(row["rate"]);

                progressCount++;
                int progressBarPercentage = (progressCount * 100) / totalProgressCount;
                dataTable.Rows.Add(id, description, frequency, rate);
                backgroundWorker1.ReportProgress(progressBarPercentage);
            }
            return dataTable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptPenalty(this).ShowDialog();
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
            LoadPenalties();
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var searchText = e.Argument as string;
            var dataTable = DataTablePenalties(searchText);

            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.PenaltiesDatagridView(dataGridView1, dataTable);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            int recordCount = dataGridView1.RowCount;
            lblRecordCount.Text = recordCount.ToString();
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}