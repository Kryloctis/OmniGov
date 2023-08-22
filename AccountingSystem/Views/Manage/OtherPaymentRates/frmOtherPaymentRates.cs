using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmOtherPaymentRates : Form
    {
        public frmOtherPaymentRates()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgOtherPaymentRates, false);
        }

        private void frmOtherPaymentRates_Load(object sender, EventArgs e)
        {
            RunBackgroundWorker();
        }

        private DataColumn[] OtherPaymentRatesColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("tax_type_id", typeof(int)),
                new DataColumn("description", typeof(string)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("starting_year", typeof(string)),
                new DataColumn("is_rate_editable", typeof(bool)),
                new DataColumn("created_by", typeof(int)),
                new DataColumn("created_at", typeof(object)),
                new DataColumn("updated_by", typeof(int)),
                new DataColumn("updated_at", typeof(object)),
            };

            return dataColumns;
        }

        internal void LoadRecords()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                var dtOtherPaymentRates = new DataTable();
                var dtOtherPaymentRatesFromDB = new DataTable();
                int recordsCount = 0;
                int rowCount = 0;

                dtOtherPaymentRates.Columns.AddRange(OtherPaymentRatesColumns());

                if (searchText.Length > 2)
                    dtOtherPaymentRatesFromDB = AccFactory.OtherPaymentRatesRepository().GetRecordsBySearch(searchText);
                else
                    dtOtherPaymentRatesFromDB = AccFactory.OtherPaymentRatesRepository().GetRecords();

                recordsCount = dtOtherPaymentRatesFromDB.Rows.Count;

                foreach (DataRow row in dtOtherPaymentRatesFromDB.Rows)
                {
                    var newRow = dtOtherPaymentRates.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    int taxTypeId = Convert.ToInt32(row["tax_type_id"]);
                    string description = row["description"].ToString();
                    decimal amount = row.IsNull("amount") ? 0 : Convert.ToDecimal(row["amount"]);
                    int startingYear = row.IsNull("starting_year") ? 0 : Convert.ToInt32(row["starting_year"]);
                    bool isEditableRate = Convert.ToBoolean(row["is_rate_editable"]);
                    int createdBy = Convert.ToInt32(row["created_by"]);
                    object createdAt = row["created_at"].ToString();
                    int updateBy = row.IsNull("updated_by") ? 0 : Convert.ToInt32(row["updated_by"]);
                    object updateAt = row["updated_at"].ToString();

                    newRow["id"] = id;
                    newRow["tax_type_id"] = taxTypeId;
                    newRow["description"] = description;
                    newRow["amount"] = amount;
                    newRow["starting_year"] = startingYear;
                    newRow["is_rate_editable"] = isEditableRate;
                    newRow["created_by"] = createdBy;
                    newRow["created_at"] = createdAt;
                    newRow["updated_by"] = updateBy;
                    newRow["updated_at"] = updateAt;

                    rowCount++;
                    int progressBarPercentage = (rowCount * 100) / recordsCount;
                    backgroundWorker1.ReportProgress(progressBarPercentage);

                    dtOtherPaymentRates.Rows.Add(newRow);
                }

                HelperLoadRecords.OtherPaymentRatesDatagridView(dgOtherPaymentRates, dtOtherPaymentRates);
                SetStatusStripData();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgOtherPaymentRates_SelectionChanged(object sender, EventArgs e)
        {
            SetStatusStripData();
        }

        private void SetStatusStripData()
        {
            if (dgOtherPaymentRates.Columns.Count < 1)
                return;

            int rowCount = dgOtherPaymentRates.Rows.Count;
            toolStripStatusLabelRecordCount.Text = rowCount.ToString();
            byte createdByIndex = (byte)dgOtherPaymentRates.Columns["created_at"].Index;
            byte updatedByIndex = (byte)dgOtherPaymentRates.Columns["updated_at"].Index;

            var indexes = new byte[] { createdByIndex, updatedByIndex };
            Helper.EnableDisableToolStripButtons(dgOtherPaymentRates, btnEdit, btnDelete);
            Helper.ShowRecordTimestamp(dgOtherPaymentRates, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddOtherPaymentRates(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgOtherPaymentRates.CurrentCell.RowIndex;
            int otherPaymentRatesID = Convert.ToInt32(dgOtherPaymentRates.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditOtherPaymentRates(this, otherPaymentRatesID).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Other payment rate/s successfully deleted.");
                    RunBackgroundWorker();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete payment rate. The record/s was used as reference to different record.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgOtherPaymentRates.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var otherPaymentRatesModelList = new List<OtherPaymentRatesModel>();
                foreach (DataGridViewRow row in dgOtherPaymentRates.SelectedRows)
                {
                    int otherPaymentRateId = Convert.ToInt32(row.Cells["id"].Value);
                    otherPaymentRatesModelList.Add(new OtherPaymentRatesModel() { Id = otherPaymentRateId });
                }
                return AccFactory.OtherPaymentRatesRepository().Delete(otherPaymentRatesModelList);
            }

            return false;
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
                LoadRecords();
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