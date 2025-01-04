using ACC.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CashTicketIssuance
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
                _ = new frmCashTicketAddIssuance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketEditIssuance().ShowDialog();
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

        private void bgwLoadIssuedCashTickets_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((DateTime dateIssued, string searchKey, int rowLimit))e.Argument;

                var dataColumns = new DataColumn[]
                {
                    //Cash Ticket No.
                    //Quantity
                    //date issued
                    //Collecting Officer
                    //Issued By

                    new DataColumn("cash_tickets_id", typeof(int)),
                    new DataColumn("accountable_form_code", typeof(string)),
                    new DataColumn("quantity", typeof(int)),
                    new DataColumn("received_date", typeof(DateTime)),
                    new DataColumn("remarks", typeof(string)),
                };

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(dataColumns);
                DataTable dtReceiptsDb = AccFactory.CashTicketsRepository().GetRecordsByDateAndText(parameters.dateIssued, parameters.searchKey, parameters.rowLimit);

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
                    Helper.ProgressCounter(bgwLoadIssuedCashTickets, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwLoadIssuedCashTickets_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwLoadIssuedCashTickets_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
            {
                pbLoadRecords.Value = 100;
                return;
            }

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.CashTicketsDatagridView(dataTable, dgCashTicketIssued);
            dgCashTicketIssued.CurrentCell = dgCashTicketIssued.FirstDisplayedCell;
            lblRecordCount.Text = dgCashTicketIssued.Rows.Count.ToString();
            Helper.EnableDisableToolStripButtons(dgCashTicketIssued, btnEdit, btnDelete);
        }
    }
}
