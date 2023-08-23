using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptTaxRates
{
    public partial class frmRptTaxRates : Form
    {
        private readonly MainForm _mainForm;

        public frmRptTaxRates(MainForm mainForm)
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

        internal void LoadTaxRates()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dtTaxRates = new();
            DataTable dtTaxRatesFromDB = new();
            int rowCount = 0;
            int recordsCount = 0;

            dtTaxRates.Columns.AddRange(TaxRatesDataColumns());

            if (searchText.Length < 2)
                dtTaxRatesFromDB = AccFactory.RptTaxRatesRepository().GetRecords();
            else
                dtTaxRatesFromDB = AccFactory.RptTaxRatesRepository().GetRecordsBySearch(searchText);

            recordsCount = dtTaxRatesFromDB.Rows.Count;

            foreach (DataRow row in dtTaxRatesFromDB.Rows)
            {
                var newRow = dtTaxRates.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string code = row["code"].ToString();
                string description = row["description"].ToString();
                decimal rate = Convert.ToDecimal(row["rate"]);

                newRow["id"] = id;
                newRow["code"] = code;
                newRow["description"] = description;
                newRow["rate"] = rate;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordsCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);

                dtTaxRates.Rows.Add(newRow);
            }


            HelperLoadRecords.TaxRatesDatagridView(dataGridView1, dtTaxRates);

            UpdateRecordCount(dataGridView1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptTaxRate(this).ShowDialog();
        }

        private void ShowEditForm()
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int rptTaxRatesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

                _ = new frmEditRptTaxRates(rptTaxRatesId, this).ShowDialog();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private bool Delete(out int deletedCount)
        {
            try
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
                    return AccFactory.RptTaxRatesRepository().Delete(rptTaxRatesModelList);
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
                LoadTaxRates();
            }
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
            RunBackgroundWorker();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RunBackgroundWorker();
        }

        internal void RunBackgroundWorker()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadTaxRates();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}