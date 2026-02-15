using LFS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Domain.Entities;

namespace LFS.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssued : Form
    {
        public frmReceiptsIssued()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceiptIssued, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReceiptsIssuedAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgReceiptIssued.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var receiptModelList = new List<ReceiptsIssuedModel>();

                foreach (DataGridViewRow row in dgReceiptIssued.SelectedRows)
                {
                    int receiptIssuedId = Convert.ToInt32(row.Cells["id"].Value);
                    receiptModelList.Add(new ReceiptsIssuedModel() { Id = receiptIssuedId });
                }

                return AccFactory.ReceiptsIssuedRepository().Delete(receiptModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Issued receipts has been deleted.");
                    LoadRecords();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete issued receipt. The receipt was already used by a collecting officer.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowRecordTimeStamp()
        {
        }

        private void dgissue_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int receiptIssuedID = Convert.ToInt32(dgReceiptIssued.SelectedRows[0].Cells["id"].Value);
                _ = new frmReceiptsIssuedEdit(this, receiptIssuedID).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Helper.MessageBoxSuccess("To be fixed.");
            //int issuanceId = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["id"].Value);
            //int lastIssued = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value.ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value);

            //int issuedSerialNoFrom = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].Value);

            //int returnSerialNoFrom = lastIssued == 0 ? issuedSerialNoFrom : lastIssued + 1;
            //int returnSerialNoTo = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].Value);

            //_ = new frmReturnReceipts(this, issuanceId, returnSerialNoFrom, returnSerialNoTo).ShowDialog();
        }

        private string CollectingOfficerFullName(DataRow row)
        {
            string jobOrdersID = row["job_orders_id"].ToString();

            string prefix = row["collecting_officers_prefix"].ToString();
            string firstName = row["collecting_officers_first_name"].ToString();
            string midInitial = row["collecting_officers_mid_initial"].ToString();
            string lastName = row["collecting_officers_last_name"].ToString();
            string suffix = row["collecting_officers_suffix"].ToString();

            if (!string.IsNullOrEmpty(jobOrdersID))
            {
                prefix = row["job_orders_prefix"].ToString();
                firstName = row["job_orders_first_name"].ToString();
                midInitial = row["job_orders_mid_initial"].ToString();
                lastName = row["job_orders_last_name"].ToString();
                suffix = row["job_orders_suffix"].ToString();
            }

            return Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);
        }

        internal void LoadRecords()
        {
            if (!bgwLoadIssuedReceipts.IsBusy)
            {
                pbLoadRecords.Value = 0;
                DateTime searchDateIssued = dtpDateIssued.Value;
                string searchText = txtSearch.Text.Trim();
                int rowLimit = (int)cmbxRowFilter.SelectedValue;
                bgwLoadIssuedReceipts.RunWorkerAsync((searchDateIssued, searchText, rowLimit));
            }
        }

        private void bgwLoadIssuedReceipts_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((DateTime dateIssued, string searchKey, int rowLimit))e.Argument;

            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("receipts", typeof(string)),
                new DataColumn("serial_number_from", typeof(object)),
                new DataColumn("serial_number_to", typeof(object)),
                new DataColumn("quantity", typeof(int)),
                new DataColumn("date_issued", typeof(DateTime)),
                new DataColumn("collecting_officer", typeof(string)),
                new DataColumn("issued_by", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);

            DataTable dtReceiptsIssuedDb = AccFactory.ReceiptsIssuedRepository().GetRecordsBySearch(parameters.dateIssued, parameters.searchKey, parameters.rowLimit);
            int totalProgressCount = dtReceiptsIssuedDb.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtReceiptsIssuedDb.Rows)
            {
                var newRow = dataTable.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string receipt = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int receiptFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receipNumberTo = Convert.ToInt32(row["receipt_issued_to"]);
                int quantity = Convert.ToInt32(row["quantity"]);
                DateTime dateIssued = Convert.ToDateTime(row["date_issued"]);
                string collectingOfficer = CollectingOfficerFullName(row);
                string issuedBy = row["issued_by"].ToString();

                newRow["id"] = id;
                newRow["receipts"] = receipt;
                newRow["serial_number_from"] = receiptFrom == 0 ? string.Empty : receiptFrom;
                newRow["serial_number_to"] = receipNumberTo == 0 ? string.Empty : receipNumberTo;
                newRow["quantity"] = quantity;
                newRow["date_issued"] = dateIssued;
                newRow["collecting_officer"] = collectingOfficer;
                newRow["issued_by"] = issuedBy;

                dataTable.Rows.Add(newRow);
                progressCount++;
                Helper.ProgressCounter(bgwLoadIssuedReceipts, totalProgressCount, progressCount);
            }

            e.Result = dataTable;
        }

        private void bgwLoadIssuedReceipts_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadIssuedReceipts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    pbLoadRecords.Value = 100;
                    return;
                }

                if (dataTable.Rows.Count < 1)
                    pbLoadRecords.Value = 100;

                HelperLoadRecords.ReceiptsIssuedDatagridView(dataTable, dgReceiptIssued);
                dgReceiptIssued.CurrentCell = dgReceiptIssued.FirstDisplayedCell;
                lblRecordCount.Text = dgReceiptIssued.Rows.Count.ToString();
                Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);
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

        private void frmReceiptsIssued_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtpDateIssued_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}