using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRcd : Form
    {
        private ucRcd ucRcd;

        public frmRcd()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            ucRcd = ucRcd1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageForm;
                ucRcd.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageForm;
                int index = dataGridView1.CurrentCell.RowIndex;
                int rcdId = Convert.ToInt32(dataGridView1.Rows[index].Cells["id"].Value);
                ucRcd.OnLoad(true, rcdId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPagePrint;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRcd()
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            Helper.EnableDisableToolStripButtons(dataGridView1, btnPrint, btnDelete);

            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                DateTime date = dateTimePicker1.Value;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((searchKey, rowFilter, date));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
                Helper.EnableDisableToolStripButtons(dataGridView1, btnPrint, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.RowFilterCombobox(cmbxRowFilter);
        }

        private void frmRcd_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
                LoadRcd();
                LoadRowFilter();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRcd();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowFilter, DateTime date))e.Argument;
                var dtDb = AccFactory.RcdRepository().GetViewRecords(parameters.searchKey, parameters.date, parameters.rowFilter);
                int totalProgressCount = dtDb.Rows.Count;
                int progressCount = 0;
                var dataTable = new DataTable();
                var dataColumns = new List<DataColumn>()
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("report_no", typeof(string)),
                    new DataColumn("created_by_id", typeof(int)),
                    new DataColumn("created_by_name", typeof(string)),
                    new DataColumn("date", typeof(DateTime)),
                    new DataColumn("created_at", typeof(DateTime)),
                };

                dataTable.Columns.AddRange(dataColumns.ToArray());

                foreach (DataRow row in dtDb.Rows)
                {
                    var newRow = dataTable.NewRow();
                    string fullName = Helper.GenerateFullName(row["prefix"].ToString(), row["first_name"].ToString(), row["mid_initial"].ToString(), row["last_name"].ToString(), row["suffix"].ToString());

                    newRow["id"] = row["id"];
                    newRow["report_no"] = row["report_no"];
                    newRow["created_by_id"] = row["created_by_id"];
                    newRow["created_by_name"] = fullName;
                    newRow["date"] = row["date"];
                    newRow["created_at"] = row["created_at"];

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
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    progressBar1.Value = 100;
                    return;
                }

                if (dataTable.Rows.Count < 1)
                {
                    progressBar1.Value = 100;
                    HelperLoadRecords.DgvRcd(dataGridView1, dataTable);
                    return;
                }

                HelperLoadRecords.DgvRcd(dataGridView1, dataTable);
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRcd();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRcd();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Save()
        {
            if (!ucRcd.ValidateChildren())
            {
                Helper.MessageBoxError(ucRcd.GetFormErrors());
                return false;
            }

            return AccFactory.RcdRepository().InsertWithCollectionsDeposits(ucRcd.RcdModel(), ucRcd.RcdCollectionsModels(), ucRcd.RcdDepositsModels());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("RCD has been saved.");
                    ucRcd.ResetForm();
                    LoadRcd();
                    tabControl1.SelectedTab = tabPageList;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}