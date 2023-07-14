using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssued : Form
    {
        public frmReceiptsIssued()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceiptIssued, true, false);
        }

        private DataColumn[] ReceiptsIssuedDataColumn()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("receipts", typeof(string)),
                new DataColumn("serial_number_from", typeof(int)),
                new DataColumn("serial_number_to", typeof(int)),
                new DataColumn("quantity", typeof(int)),
                new DataColumn("date_issued", typeof(DateTime)),
                new DataColumn("collecting_officer", typeof(string)),
                new DataColumn("issued_by", typeof(string)),
            };

            return dataColumns;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssuedAdd(this).ShowDialog();
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
                    LoadRecords();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ShowRecordTimeStamp(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count == 1 && dataGridView.CurrentRow.Cells["id"].Value != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;

                string createdAt = dataGridView.Rows[rowIndex].Cells["date_issued"].Value.ToString();

                toolStripStatusLabelCreatedAt.Text = createdAt;
            }
        }

        private void dgissue_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);
            ShowRecordTimeStamp(dgReceiptIssued);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int receiptIssuedID = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["id"].Value);
            _ = new frmReceiptsIssuedEdit(this, receiptIssuedID).ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int issuanceId = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["id"].Value);
            int lastIssued = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value.ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value);

            int issuedSerialNoFrom = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].Value);

            int returnSerialNoFrom = lastIssued == 0 ? issuedSerialNoFrom : lastIssued + 1;
            int returnSerialNoTo = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].Value);

            _ = new frmReturnReceipts(this, issuanceId, returnSerialNoFrom, returnSerialNoTo).ShowDialog();
        }



        internal void LoadRecords()
        {
            DateTime searchDateIssued = dtpDateIssued.Value;
            string searchText = txtsearch.Text.Trim();

            DataTable dtReceiptsIssued = new();
            dtReceiptsIssued.Columns.AddRange(ReceiptsIssuedDataColumn());

            DataTable dtReceiptsIssuedFromDB = AccFactory.ReceiptsIssuedRepository().GetRecordsBySearch(searchDateIssued, searchText);
            int totalRecordsFromDB = dtReceiptsIssuedFromDB.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtReceiptsIssuedFromDB.Rows)
            {
                var newRow = dtReceiptsIssued.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string receipt = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int receiptFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receipNumberTo = Convert.ToInt32(row["receipt_issued_to"]);
                int quantity = Convert.ToInt32(row["quantity"]);
                DateTime dateIssued = Convert.ToDateTime(row["date_issued"]);
                string officer = row["issued_by"].ToString();

                newRow["id"] = id;
                newRow["receipts"] = receipt;
                newRow["serial_number_from"] = receiptFrom;
                newRow["serial_number_to"] = receipNumberTo;
                newRow["quantity"] = quantity;
                newRow["date_issued"] = dateIssued;
                newRow["collecting_officer"] = officer;
                newRow["issued_by"] = officer;

                dtReceiptsIssued.Rows.Add(newRow);
                rowCount++;
                int progressBarPercentage = (rowCount * 100) / totalRecordsFromDB;
                bgwLoadIssuedReceipts.ReportProgress(progressBarPercentage);
            }

            HelperLoadRecords.ReceiptsIssuedDatagridView(dtReceiptsIssued, dgReceiptIssued);
        }

        private void bgwLoadIssuedReceipts_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadRecords();
            });
        }

        private void bgwLoadIssuedReceipts_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgwLoadIssuedReceipts.IsBusy)
                    bgwLoadIssuedReceipts.RunWorkerAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmReceiptsIssued_Load(object sender, EventArgs e)
        {

        }
    }
}