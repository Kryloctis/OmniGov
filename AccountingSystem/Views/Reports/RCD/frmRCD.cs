using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRcd : Form
    {
        private ucRcd uc;

        public frmRcd()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            uc = ucRcd1;
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
                uc.OnLoad(false, null);
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
                uc.OnLoad(true, rcdId);
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
                LoadRowFilter();
                LoadRcd();
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
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

                lblRowCount.Text = dataTable.Rows.Count.ToString();

                if (dataTable.Rows.Count < 1)
                {
                    progressBar1.Value = 100;
                    HelperLoadRecords.DgvRcd(dataGridView1, dataTable);
                    return;
                }

                HelperLoadRecords.DgvRcd(dataGridView1, dataTable);
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
                lblRowCount.Text = dataTable.Rows.Count.ToString();
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

        private bool DeleteRecords(DataGridView dataGridView)
        {
            var models = new List<RcdModel>();
            var selectedRow = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRow.Count))
            {
                foreach (DataGridViewRow rowItem in selectedRow)
                {
                    var model = new RcdModel() { Id = Convert.ToInt32(rowItem.Cells["id"].Value) };
                    models.Add(model);
                }

                return AccFactory.RcdRepository().Delete(models);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dataGridView1.SelectedRows.Count;
                if (DeleteRecords(dataGridView1))
                {
                    Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                    LoadRcd();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isEdit = false;

                if (uc.Save(ref isEdit))
                {
                    if (isEdit)
                    {
                        Helper.MessageBoxSuccess("RCD has been updated.");
                        LoadRcd();
                        tabControl1.SelectedTab = tabPageList;
                    }
                    else
                    {
                        Helper.MessageBoxSuccess("RCD has been saved.");
                        LoadRcd();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRcd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control && tabControl1.SelectedTab == tabPageForm)
                {
                    bool isEdit = false;

                    if (uc.Save(ref isEdit))
                    {
                        if (isEdit)
                        {
                            Helper.MessageBoxSuccess("RCD has been updated.");
                            LoadRcd();
                            tabControl1.SelectedTab = tabPageList;
                        }
                        else
                        {
                            Helper.MessageBoxSuccess("RCD has been saved.");
                            LoadRcd();
                            uc.ResetForm();
                        }
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}