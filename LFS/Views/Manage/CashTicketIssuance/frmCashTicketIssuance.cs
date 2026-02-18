using LFS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace LFS.Views.Transactions.CashTicketIssuance
{
    public partial class frmCashTicketIssuance : Form
    {
        public frmCashTicketIssuance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgCashTicketIssued, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketAddIssuance(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int cashTicketIssuedID = Convert.ToInt32(dgCashTicketIssued.SelectedRows[0].Cells["id"].Value);
                _ = new frmCashTicketEditIssuance(this, cashTicketIssuedID).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCashTicketIssuance_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
                LoadIssuedCashTickets();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadIssuedCashTickets()
        {
            if (!bgwLoadIssuedCashTickets.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                DateTime dateIssued = dtpDateIssued.Value;
                int rowLimit = (int)cmbxRowFilter.SelectedValue;
                bgwLoadIssuedCashTickets.RunWorkerAsync((dateIssued, searchKey, rowLimit));
            }
        }

        private void bgwLoadIssuedCashTickets_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((DateTime dateIssued, string searchKey, int rowLimit))e.Argument;

                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("cash_tickets_desc", typeof(string)),
                    new DataColumn("quantity", typeof(int)),
                    new DataColumn("date_issued", typeof(DateTime)),
                    new DataColumn("collecting_officer", typeof(string)),
                    new DataColumn("issued_by", typeof(string)),
                };

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(dataColumns);
                DataTable dtCashTicketDb = TreasuryFactory.CashTicketsIssuedRepository().GetViewRecordsBySearch(parameters.dateIssued, parameters.searchKey, parameters.rowLimit);

                int totalProgressCount = dtCashTicketDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtCashTicketDb.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string cashTicket = row["cash_tickets_desc"].ToString();
                    int quantity = Convert.ToInt32(row["quantity"]);
                    DateTime dateIssued = Convert.ToDateTime(row["date_issued"]);
                    string collectingOfficer = CollectingOfficerFullName(row);
                    string issuedBy = row["issued_by"].ToString();

                    var newRow = dataTable.NewRow();
                    newRow["id"] = id;
                    newRow["cash_tickets_desc"] = cashTicket;
                    newRow["quantity"] = quantity;
                    newRow["date_issued"] = dateIssued;
                    newRow["collecting_officer"] = collectingOfficer;
                    newRow["issued_by"] = issuedBy;

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(bgwLoadIssuedCashTickets, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwLoadIssuedCashTickets_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadIssuedCashTickets_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                HelperLoadRecords.CashTicketIssuedDatagridView(dataTable, dgCashTicketIssued);
                dgCashTicketIssued.CurrentCell = dgCashTicketIssued.FirstDisplayedCell;
                lblRecordCount.Text = dgCashTicketIssued.Rows.Count.ToString();
                Helper.EnableDisableToolStripButtons(dgCashTicketIssued, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string CollectingOfficerFullName(DataRow row)
        {
            string jobOrdersID = row["jo_id"].ToString();

            string prefix = row["co_prefix"].ToString();
            string firstName = row["co_first_name"].ToString();
            string midInitial = row["co_mid_initial"].ToString();
            string lastName = row["co_last_name"].ToString();
            string suffix = row["co_suffix"].ToString();

            if (!string.IsNullOrEmpty(jobOrdersID))
            {
                prefix = row["jo_prefix"].ToString();
                firstName = row["jo_first_name"].ToString();
                midInitial = row["jo_mid_initial"].ToString();
                lastName = row["jo_last_name"].ToString();
                suffix = row["jo_suffix"].ToString();
            }

            return Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Issued Cash Tickets has been deleted.");
                    LoadIssuedCashTickets();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete issued tickets. The tickets was already used by a collecting officer.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgCashTicketIssued.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var cashTicketIssuedModelList = new List<CashTicketsIssuedModel>();

                foreach (DataGridViewRow row in dgCashTicketIssued.SelectedRows)
                {
                    int cashTicketIssuedId = Convert.ToInt32(row.Cells["id"].Value);
                    cashTicketIssuedModelList.Add(new CashTicketsIssuedModel() { Id = cashTicketIssuedId });
                }

                return TreasuryFactory.CashTicketsIssuedRepository().Delete(cashTicketIssuedModelList);
            }
            return false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadIssuedCashTickets();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
