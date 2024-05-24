using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Assessment
{
    public partial class frmWarrantLevy : Form
    {
        private bool isEdit;
        private ucWarrantLevy ucWarrantLevy;

        public frmWarrantLevy()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);

            //Removes tabs to tabcontrol
            tabControl1.Padding = new Point(0, 0);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            ucWarrantLevy = ucWarrantLevy1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = false;
                ucWarrantLevy.OnLoad(isEdit);
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Save (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = true;
                int rowIndex = dataGridView1.CurrentRow.Index;
                int warrantLevyId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["warrant_levy_id"].Value);
                ucWarrantLevy.OnLoad(isEdit, warrantLevyId);
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Update (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData(DataGridView dataGridView)
        {
            var selectedRows = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRows.Count))
            {
                var registryModels = new List<DelinquentNoticeModel>();

                foreach (DataGridViewRow row in selectedRows)
                    registryModels.Add(new DelinquentNoticeModel() { Id = Convert.ToInt32(row.Cells["delinquent_notice_id"].Value) });

                return AccFactory.DelinquentNoticeRepository().Delete(registryModels);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData(dataGridView1))
                {
                    Helper.MessageBoxSuccess($"{dataGridView1.SelectedRows.Count} record/s has been deleted.");
                }
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

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageMain;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmWarrantLevy_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRecords();
                dataGridView1_SelectionChanged(sender, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
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
                var dtWarrantLevy = AccFactory.RptLevyRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.searchKey);
                var dataTable = new DataTable();
                var dtColumns = new DataColumn[]
                {
                    new DataColumn("rpt_levy_id", typeof(int)),
                    new DataColumn("complete_arp_no", typeof(string)),
                    new DataColumn("property_kind", typeof(string)),
                    new DataColumn("taxpayers_name", typeof(DateTime)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("created_by", typeof(string)),
                    new DataColumn("updated_at", typeof(string)),
                    new DataColumn("updated_by", typeof(string)),
                };
                dataTable.Columns.AddRange(dtColumns);

                int totalProgressCount = dtWarrantLevy.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dtWarrantLevy.Rows)
                {
                    var newRow = dataTable.NewRow();
                    newRow["rpt_levy_id"] = dataRow["rpt_levy_id"];
                    newRow["complete_arp_no"] = dataRow["complete_arp_no"];
                    newRow["property_kind"] = dataRow["property_kind"];
                    newRow["taxpayers_name"] = dataRow["taxpayers_name"];
                    newRow["created_at"] = dataRow["created_at"];
                    newRow["created_by"] = string.IsNullOrWhiteSpace(dataRow["created_by"].ToString()) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(dataRow["created_by"]))["user_full_name"];
                    newRow["updated_at"] = dataRow["updated_at"];
                    newRow["updated_by"] = string.IsNullOrWhiteSpace(dataRow["updated_by"].ToString()) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(dataRow["updated_by"]))["user_full_name"];

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
                    return;

                if (dataTable.Rows.Count < 1)
                {
                    progressBar1.Value = 100;
                    lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["rpt_levy_id"].Visible = false;
                dataGridView1.Columns["complete_arp_no"].HeaderText = "ARP No.";
                dataGridView1.Columns["property_kind"].HeaderText = "Property Kind";
                dataGridView1.Columns["taxpayers_name"].HeaderText = "Taxpayer";
                dataGridView1.Columns["created_at"].Visible = false;
                dataGridView1.Columns["created_by"].HeaderText = "Created By";
                dataGridView1.Columns["updated_at"].Visible = false;
                dataGridView1.Columns["updated_by"].Visible = false;

                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
                lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var stampIndex = new byte[] { 4, 6 };
                Helper.ShowRecordTimestamp(dataGridView1, stampIndex, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}