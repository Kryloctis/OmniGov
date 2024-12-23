using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CashTickets
{
    public partial class frmCashTickets : Form
    {
        public frmCashTickets()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgCashTickets, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketsAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgCashTickets.CurrentRow.Index;
                int cashTicketId = Convert.ToInt32(dgCashTickets.Rows[index].Cells["cash_tickets_id"].Value);
                _ = new frmCashTicketEdit(this, cashTicketId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCashTickets_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
                LoadCashTickets();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void LoadCashTickets()
        {
            if (!bgwLoadCashTickets.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                DateTime dateReceived = dtpReceivedDate.Value;
                int rowLimit = (int)cmbxRowFilter.SelectedValue;
                bgwLoadCashTickets.RunWorkerAsync((dateReceived, searchKey, rowLimit));
            }
        }

        private void bgwLoadCashTickets_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((DateTime dateReceived, string searchKey, int rowLimit))e.Argument;

                var dataColumns = new DataColumn[]
                {
                    new DataColumn("cash_tickets_id", typeof(int)),
                    new DataColumn("accountable_form_code", typeof(string)),
                    new DataColumn("quantity", typeof(int)),
                    new DataColumn("received_date", typeof(DateTime)),
                    new DataColumn("remarks", typeof(string)),
                };

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(dataColumns);
                DataTable dtReceiptsDb = AccFactory.CashTicketsRepository().GetRecordsByDateAndText(parameters.dateReceived, parameters.searchKey, parameters.rowLimit);

                int totalProgressCount = dtReceiptsDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtReceiptsDb.Rows)
                {
                    int id = Convert.ToInt32(row["cash_tickets_id"]);
                    string accountableFormCode = row["acc_form_no"].ToString();
                    int quantity = Convert.ToInt32(row["quantity"]);
                    DateTime receivedDate = Convert.ToDateTime(row["received_date"]);
                    string remarks = row["remarks"].ToString();

                    var newRow = dataTable.NewRow();
                    newRow["cash_tickets_id"] = id;
                    newRow["accountable_form_code"] = accountableFormCode;
                    newRow["quantity"] = quantity;
                    newRow["received_date"] = receivedDate;
                    newRow["remarks"] = remarks;

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(bgwLoadCashTickets, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwLoadCashTickets_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadCashTickets_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
            {
                pbLoadRecords.Value = 100;
                return;
            }

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.CashTicketsDatagridView(dataTable, dgCashTickets);
            dgCashTickets.CurrentCell = dgCashTickets.FirstDisplayedCell;
            lblRecordCount.Text = dgCashTickets.Rows.Count.ToString();
            Helper.EnableDisableToolStripButtons(dgCashTickets, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCashTickets();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Cash Ticket/s has been deleted.");
                    LoadCashTickets();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete Cash Ticket/s. The record was already used by a collecting officer.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgCashTickets.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var cashTicketsModelList = new List<CashTicketsModel>();
                foreach (DataGridViewRow row in dgCashTickets.SelectedRows)
                {
                    int cashTicketId = Convert.ToInt32(row.Cells["cash_tickets_id"].Value);
                    cashTicketsModelList.Add(new CashTicketsModel() { Id = cashTicketId });
                }
                return AccFactory.CashTicketsRepository().Delete(cashTicketsModelList);
            }

            return false;
        }
    }
}
