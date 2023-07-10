using ACC.Domain.Models;
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

            lblProgressCount.Visible = false;
            progressBarLoadRecords.Visible = false;
        }


        private void SetToolStripStatusData()
        {
            var quantity = (from DataGridViewRow row in dgReceipts.Rows
                            where !String.IsNullOrEmpty(row.Cells["quantity"].FormattedValue.ToString())
                            select Convert.ToDecimal(row.Cells["quantity"].FormattedValue)).Sum().ToString();

            lblRecordCount.Text = dgReceipts.Rows.Count.ToString();
            lblQuantity.Text = quantity;
        }

        private void dgreceipts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);

            int receiptId = Convert.ToInt32(dgReceipts.CurrentRow.Cells[0].Value);
            bool hasIssueance = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int receiptId = int.Parse(dgReceipts.CurrentRow.Cells[0].Value.ToString());
            _ = new frmReceiptsEdit(this, receiptId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmDelete(dgReceipts.SelectedRows.Count))
            {
                var receiptsRepository = AccFactory.ReceiptsRepository();
                var receiptModel = new List<ReceiptsModel>();

                foreach (DataGridViewRow row in dgReceipts.SelectedRows)
                {
                    int receiptId = int.Parse(row.Cells[0].Value.ToString());

                    var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);

                    if (!receiptIsUsed)
                        receiptModel.Add(new ReceiptsModel() { Id = receiptId });
                }
                _ = receiptsRepository.Delete(receiptModel);

                Helper.MessageBoxSuccess("Receipt successfullt deleted.");
            }
        }


        private DataColumn[] ReceiptsColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("receipt", typeof(string)),
                new DataColumn("receipt_number_from", typeof(int)),
                new DataColumn("receipt_number_to", typeof(int)),
                new DataColumn("quantity", typeof(int)),
                new DataColumn("received_date", typeof(DateTime)),
                new DataColumn("officer", typeof(string)),
            };

            return dataColumns;
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int rowCount = 0;

                receiptDataTable = new DataTable();
                receiptDataTable.Columns.AddRange(ReceiptsColumns());

                DateTime dateReceived = dtpReceivedDate.Value;
                string searchKey = txtSearch.Text.Trim();

                var dtReceipts = AccFactory.ReceiptsRepository().GetRecordsByDateAndText(dateReceived.ToString("yyyy-MM-dd"), searchKey);

                foreach (DataRow row in dtReceipts.Rows)
                {
                    var newRow = receiptDataTable.NewRow();

                    int id = Convert.ToInt32(row["id"]);
                    string receipt = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                    int receiptFrom = Convert.ToInt32(row["receipt_number_from"]);
                    int receipNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                    int quantity = Convert.ToInt32(row["quantity"]);
                    DateTime receivedDate = Convert.ToDateTime(row["received_date"]);
                    string officer = row["officer"].ToString();

                    newRow["id"] = id;
                    newRow["receipt"] = receipt;
                    newRow["receipt_number_from"] = receiptFrom;
                    newRow["receipt_number_to"] = receipNumberTo;
                    newRow["quantity"] = quantity;
                    newRow["received_date"] = receivedDate;
                    newRow["officer"] = officer;

                    rowCount += 1;
                    receiptDataTable.Rows.Add(newRow);
                    bgwLoadReceipts.ReportProgress(((rowCount * 100) / dtReceipts.Rows.Count), rowCount);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblRecordCount.Text = e.UserState.ToString();
            progressBarLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (progressBarLoadRecords.Value == 100)
            {
                progressBarLoadRecords.Visible = false;
                progressBarLoadRecords.Value = 0;
            }


            HelperLoadRecords.ReceiptsDatagridView(receiptDataTable, dgReceipts);
            lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dgReceipts).ToString();

            this.UseWaitCursor = false;
            this.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReceipts();
        }

        private void LoadReceipts()
        {
            try
            {
                if (!bgwLoadReceipts.IsBusy)
                {
                    bgwLoadReceipts.RunWorkerAsync();
                    this.UseWaitCursor = true;
                    this.Enabled = false;
                    progressBarLoadRecords.Visible = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtpReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            dtpReceivedDate.CustomFormat = "MMMM, dd yyyy";
        }
    }
}