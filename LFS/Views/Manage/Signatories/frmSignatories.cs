using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LFS.Views.Manage.Signatories
{
    public partial class frmSignatories : Form
    {
        public frmSignatories()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgSignatories, true);
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void frmSignatories_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRecords();
                TogglePreviewDocuments();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadReferencedDocuments(DataGridView dataGridView, RichTextBox richTextBox)
        {
            int rowIndex = dataGridView.CurrentCell.RowIndex;
            int signatoriesId = Convert.ToInt32(dataGridView.Rows[rowIndex].Cells["id"].Value);
            var dtReferencedDocuments = AccFactory.SignatoriesHasReferencesRepository().GetDocumentRecordsBySignatoryId(signatoriesId);
            var sbDocuments = new StringBuilder();
            dtReferencedDocuments.Rows.Cast<DataRow>().ToList().ForEach(x => { sbDocuments.AppendLine($" {x["documents_name"]}"); });
            richTextBox.Text = sbDocuments.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddSignatories(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int signatoriesId = Convert.ToInt32(dgSignatories.Rows[dgSignatories.CurrentRow.Index].Cells["id"].Value);

                var _frmEditSignatories = new frmEditSignatories(this);
                _frmEditSignatories.uc.signatoriesId = signatoriesId;
                _frmEditSignatories.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgSignatories_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var stampIndex = new byte[] { 3, 4 };
                Helper.ShowRecordTimestamp(dgSignatories, stampIndex, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgSignatories, btnEdit, btnDelete);
                if (dgSignatories.SelectedRows.Count == 1) LoadReferencedDocuments(dgSignatories, rchTxtDocuments);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowCount = dgSignatories.SelectedRows.Count;

            if (selectedRowCount < 1)
                return false;

            if (Helper.MessageBoxConfirmDelete(selectedRowCount))
            {
                var signatoriesModelList = new List<SignatoriesModel>();

                foreach (DataGridViewRow row in dgSignatories.SelectedRows)
                {
                    var signatoriesModel = new SignatoriesModel() { Id = Convert.ToInt16(row.Cells["id"].Value) };
                    signatoriesModelList.Add(signatoriesModel);
                }

                return AccFactory.SignatoriesRepository().Delete(signatoriesModelList);
            }

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxError($"{dgSignatories.SelectedRows.Count} record/s has been deleted.");
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                new DataColumn("id", typeof(int)),
                new DataColumn("name", typeof(string)),
                new DataColumn("title", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
                };

                dataTable.Columns.AddRange(dataColumns);
                var dtSignatories = AccFactory.SignatoriesRepository().GetRecords();
                int totalProgressCount = dtSignatories.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtSignatories.Rows)
                {
                    var newRow = dataTable.NewRow();
                    string prefix = row["prefix"].ToString();
                    string firstName = row["first_name"].ToString();
                    string middleInitial = row["middle_initial"].ToString();
                    string lastName = row["last_name"].ToString();
                    string suffix = row["suffix"].ToString();

                    newRow["id"] = row["id"];
                    newRow["name"] = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);
                    newRow["title"] = row["title"];
                    newRow["created_at"] = row["created_at"];
                    newRow["updated_at"] = row["updated_at"];

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
                    progressBar1.Value = 100;

                HelperLoadRecords.SignatoriesDatagridView(dataTable, dgSignatories);
                dgSignatories.CurrentCell = dgSignatories.FirstDisplayedCell;
                lblRecordCount.Text = dgSignatories.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void TogglePreviewDocuments()
        {
            switch (splitContainer1.Panel2Collapsed)
            {
                case true:
                    splitContainer1.Panel2Collapsed = false;
                    btnShowSidePanel.Text = "✕";
                    break;

                case false:
                    splitContainer1.Panel2Collapsed = true;
                    btnShowSidePanel.Text = "☰";
                    break;
            }
        }

        private void btnShowSidePanel_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePreviewDocuments();
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
    }
}