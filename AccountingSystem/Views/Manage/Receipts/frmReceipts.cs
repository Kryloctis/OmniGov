using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceipts : Form
    {
        DataTable receiptDataTable;

        public frmReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceipts, true);
        }

        private void frmAccForms_Load(object sender, EventArgs e)
        {
            SetToolStripStatusData();
        }

        private void SetToolStripStatusData()
        {
            var quantity = (from DataGridViewRow row in dgReceipts.Rows
                            where !String.IsNullOrEmpty(row.Cells["quantity"].FormattedValue.ToString())
                            select Convert.ToDecimal(row.Cells["quantity"].FormattedValue)).Sum().ToString();

            lblRecordCount.Text = dgReceipts.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int receiptId = Convert.ToInt32(dgReceipts.CurrentRow.Cells["id"].Value);
            _ = new frmReceiptsEdit(this, receiptId).ShowDialog();
        }

        private bool DeleteRecords()
        {

            int selectedRowsCount = dgReceipts.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var receiptModelList = new List<ReceiptsModel>();

                foreach (DataGridViewRow row in dgReceipts.SelectedRows)
                {
                    int receiptId = Convert.ToInt32(row.Cells["id"].Value);
                    receiptModelList.Add(new ReceiptsModel() { Id = receiptId });
                }
                return AccFactory.ReceiptsRepository().Delete(receiptModelList);
            }

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Receipt successfully deleted.");
                    if (!bgwLoadReceipts.IsBusy)
                        bgwLoadReceipts.RunWorkerAsync();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete receipt. The receipt was already used by a collecting officer.");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataColumn[] ReceiptsColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("accountable_form_code", typeof(string)),
                new DataColumn("receipt", typeof(string)),
                new DataColumn("receipt_number_from", typeof(int)),
                new DataColumn("receipt_number_to", typeof(int)),
                new DataColumn("quantity", typeof(int)),
                new DataColumn("received_date", typeof(DateTime)),
                new DataColumn("officer", typeof(string)),
            };

            return dataColumns;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadReceipts_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            HelperLoadRecords.ReceiptsDatagridView(receiptDataTable, dgReceipts);
        }

        private DataTable ReceiptDataTable()
        {
            receiptDataTable = new DataTable();
            receiptDataTable.Columns.AddRange(ReceiptsColumns());

            DateTime dateReceived = dtpReceivedDate.Value;
            string searchKey = txtSearch.Text.Trim();

            DataTable dtReceipts = AccFactory.ReceiptsRepository().GetRecordsByDateAndText(dateReceived, searchKey);
            int totalRecordsCount = dtReceipts.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtReceipts.Rows)
            {
                var newRow = receiptDataTable.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string accountableFormCode = row["acc_form_no"].ToString();
                string receipt = row["acc_form_desc"].ToString();
                int receiptFrom = Convert.ToInt32(row["receipt_number_from"]);
                int receipNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                int quantity = Convert.ToInt32(row["quantity"]);
                DateTime receivedDate = Convert.ToDateTime(row["received_date"]);
                string officer = row["officer"].ToString();

                newRow["id"] = id;
                newRow["accountable_form_code"] = accountableFormCode;
                newRow["receipt"] = receipt;
                newRow["receipt_number_from"] = receiptFrom;
                newRow["receipt_number_to"] = receipNumberTo;
                newRow["quantity"] = quantity;
                newRow["received_date"] = receivedDate;
                newRow["officer"] = officer;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / totalRecordsCount;
                bgwLoadReceipts.ReportProgress(progressBarPercentage);

                receiptDataTable.Rows.Add(newRow);
            }

            return receiptDataTable;
        }


        internal void LoadReceipts()
        {
            HelperLoadRecords.ReceiptsDatagridView(ReceiptDataTable(), dgReceipts);
            SetToolStripStatusData();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadReceipts();
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgwLoadReceipts.IsBusy)
                    bgwLoadReceipts.RunWorkerAsync();
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgReceipts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);
        }


    }
}