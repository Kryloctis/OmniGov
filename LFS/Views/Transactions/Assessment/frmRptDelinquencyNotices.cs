using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace LFS.Views.Transactions.Assessment
{
    public partial class frmRptDelinquencyNotices : Form
    {
        private bool isEdit;
        private ucDelinquenyNotice ucDelinquenyNotice;

        public frmRptDelinquencyNotices()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);

            //Removes tabs to tabcontrol
            tabControl1.Padding = new Point(0, 0);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            ucDelinquenyNotice = ucDelinquenyNotice1;
        }

        private void frnRptAssessment_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRptDelinquentNotices();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = false;
                ucDelinquenyNotice.ResetForm();
                ucDelinquenyNotice.OnLoad(isEdit);
                tabControl1.SelectedTab = tabPageForm;
                btnSave.Text = "Save (Ctrl + S)";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRptDelinquentNotices();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                isEdit = true;
                int rowIndex = dataGridView1.CurrentRow.Index;
                int delinquencyNoticeId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["delinquent_notice_id"].Value);
                ucDelinquenyNotice.OnLoad(isEdit, delinquencyNoticeId);
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

                return TreasuryFactory.DelinquentNoticeRepository().Delete(registryModels);
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
                    LoadRptDelinquentNotices();
                }
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SaveData()
        {
            if (isEdit)
            {
                if (ucDelinquenyNotice.UpdateData())
                {
                    Helper.MessageBoxSuccess("Delinquency notice has been updated.");
                    ucDelinquenyNotice.ResetForm();
                    tabControl1.SelectedTab = tabPageMain;
                    LoadRptDelinquentNotices();
                }
            }
            else
            {
                if (ucDelinquenyNotice.InsertData())
                {
                    Helper.MessageBoxSuccess("Delinquency notice has been saved.");
                    ucDelinquenyNotice.ResetForm();
                    LoadRptDelinquentNotices();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRptDelinquentNotices()
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
                var dtDelinquencyNotice = TreasuryFactory.DelinquentNoticeRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.searchKey);
                var dataTable = new DataTable();
                int totalProgressCount = dtDelinquencyNotice.Rows.Count;
                int progressCount = 0;

                var dtColumns = new DataColumn[]
                {
                    new DataColumn("delinquent_notice_id", typeof(int)),
                    new DataColumn("complete_arp_no",typeof(string)),
                    new DataColumn("taxpayers_name", typeof(string)),
                    new DataColumn("notice_type", typeof(string)),
                    new DataColumn("notice_date", typeof(DateTime)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("created_by", typeof(string)),
                    new DataColumn("updated_at", typeof(string)),
                    new DataColumn("updated_by", typeof(string)),
                };

                dataTable.Columns.AddRange(dtColumns);

                foreach (DataRow dataRow in dtDelinquencyNotice.Rows)
                {
                    var newRow = dataTable.NewRow();
                    newRow["delinquent_notice_id"] = dataRow["delinquent_notice_id"];
                    newRow["notice_type"] = dataRow["notice_type"];
                    newRow["notice_date"] = dataRow["notice_date"];
                    newRow["complete_arp_no"] = dataRow["complete_arp_no"];
                    newRow["taxpayers_name"] = dataRow["taxpayers_name"];
                    newRow["created_at"] = dataRow["created_at"];
                    newRow["created_by"] = string.IsNullOrWhiteSpace(dataRow["created_by"].ToString()) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(dataRow["created_by"]))["user_full_name"];
                    newRow["updated_at"] = dataRow["updated_at"];
                    newRow["updated_by"] = string.IsNullOrWhiteSpace(dataRow["updated_at"].ToString()) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(dataRow["updated_by"]))["user_full_name"];

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

                HelperLoadRecords.DgvRptDelinquencyNotices(dataGridView1, dataTable);
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
                lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRptDelinquentNotices();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var stampIndex = new byte[] { 5, 7 };
                Helper.ShowRecordTimestamp(dataGridView1, stampIndex, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptDelinquencyNotices_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control && tabControl1.SelectedTab == tabPageForm)
                {
                    SaveData();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
