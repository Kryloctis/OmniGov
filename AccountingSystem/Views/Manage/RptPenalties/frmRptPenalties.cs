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

        private void UpdateRecordCount(DataGridView dataGridView)
        {
            int recordCount = dataGridView.Rows.Count;
            lblRecordCount.Text = recordCount.ToString();
        }


        internal void LoadPenalties()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dtRptPenalties;
            var dataTable = new DataTable();

            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("description", typeof(string));
            dataTable.Columns.Add("frequency", typeof(string));
            dataTable.Columns.Add("rate", typeof(decimal));

            if (searchText.Length < 2)
                dtRptPenalties = AccFactory.RptPenaltiesRepository().GetRecords();
            else
                dtRptPenalties = AccFactory.RptPenaltiesRepository().GetRecordsBySearch(searchText);

            int recordCount = dtRptPenalties.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtRptPenalties.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string description = row["description"].ToString();
                string frequency = row["frequency"].ToString();
                decimal rate = Convert.ToDecimal(row["rate"]);

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                dataTable.Rows.Add(id, description, frequency, rate);
            }

            HelperLoadRecords.PenaltiesDatagridView(dataGridView1, dataTable);
            UpdateRecordCount(dataGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptPenalty(this).ShowDialog();
        }

        private void ShowEditForm()
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int penaltiesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditRptPenalties(penaltiesId, this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private bool Delete(out int deletedCount)
        {
            try
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
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (Delete(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadPenalties();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void frmRptPenalties_Load(object sender, EventArgs e)
        {
            LoadPenalties();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPenalties();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}