using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.Receipts
{
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceipts, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReceiptsAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgReceipts.CurrentRow.Index;
                int receiptId = Convert.ToInt32(dgReceipts.Rows[index].Cells["id"].Value);
                _ = new frmReceiptsEdit(this, receiptId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                    Helper.MessageBoxSuccess("Receipt/s has been deleted.");
                    LoadReceipts();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete receipt. The receipt was already used by a collecting officer.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadReceipts()
        {
            if (!bgwLoadReceipts.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                DateTime dateReceived = dtpReceivedDate.Value;
                int rowLimit = (int)cmbxRowFilter.SelectedValue;
                bgwLoadReceipts.RunWorkerAsync((dateReceived, searchKey, rowLimit));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((DateTime dateRecieved, string searchKey, int rowLimit))e.Argument;

                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("accountable_form_code", typeof(string)),
                    new DataColumn("receipt", typeof(string)),
                    new DataColumn("receipt_number", typeof(string)),
                    new DataColumn("quantity", typeof(int)),
                    new DataColumn("received_date", typeof(DateTime)),
                    new DataColumn("officer", typeof(string)),
                };

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(dataColumns);
                DataTable dtReceiptsDb = AccFactory.ReceiptsRepository().GetRecordsByDateAndText(parameters.dateRecieved, parameters.searchKey, parameters.rowLimit);

                int totalProgressCount = dtReceiptsDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtReceiptsDb.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string accountableFormCode = row["acc_form_no"].ToString();
                    string receipt = row["acc_form_desc"].ToString();
                    int receiptNumberFrom = Convert.ToInt32(row["receipt_number_from"]);
                    int receipNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                    string receiptNumber = receipNumberTo == 0 && receiptNumberFrom == 0 ? "--" : $"{receiptNumberFrom.ToString("D7")} > {receipNumberTo.ToString("D7")}";
                    int quantity = Convert.ToInt32(row["quantity"]);
                    DateTime receivedDate = Convert.ToDateTime(row["received_date"]);
                    string officer = string.Empty;

                    var newRow = dataTable.NewRow();
                    newRow["id"] = id;
                    newRow["accountable_form_code"] = accountableFormCode;
                    newRow["receipt"] = receipt;
                    newRow["receipt_number"] = receiptNumber;
                    newRow["quantity"] = quantity;
                    newRow["received_date"] = receivedDate;
                    newRow["officer"] = officer;

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(bgwLoadReceipts, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadReceipts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
            {
                pbLoadRecords.Value = 100;
                return;
            }

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.ReceiptsDatagridView(dataTable, dgReceipts);
            dgReceipts.CurrentCell = dgReceipts.FirstDisplayedCell;
            lblRecordCount.Text = dgReceipts.Rows.Count.ToString();
            Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReceipts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgReceipts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);

            if (dgReceipts.SelectedRows.Count != 0)
            {
                int receiptId = Convert.ToInt32(dgReceipts.SelectedRows[0].Cells["id"].Value);
                int totalIssued = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptId);
                btnDelete.Enabled = totalIssued == 0;
            }
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
                LoadReceipts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadReceipts();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dtpReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReceipts();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}