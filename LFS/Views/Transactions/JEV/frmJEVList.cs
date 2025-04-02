using ACC.Data;
using LFS.Views.Dashboard;
using LFS;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class frmJevList : Form
    {
        private string journalName;
        private string fundName;
        private byte month;
        private short year;
        internal ucJevDashboard ucJevDashboard;

        public frmJevList(string journalName, string fundName, byte month, short year, ucJevDashboard ucJevDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.journalName = journalName;
            this.fundName = fundName;
            this.month = month;
            this.year = year;
            this.ucJevDashboard = ucJevDashboard;
            Helper.DatagridFullRowSelectStyle(dgJEV, true);
        }

        private void frmJEVList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadJournals();
                LoadMonths();
                LoadJEVList();
                LoadFunds();
                nudYear.Value = year == 0 ? DateTime.Now.Year : year;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DatatableJournals()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("journal_name");

            var dtJournals = AccFactory.JournalsRepository().GetRecords();
            dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");
            DataRow dr = dataTable.NewRow();
            dr["id"] = "0";
            dr["journal_name"] = "All";
            dataTable.Rows.InsertAt(dr, 0);

            return dataTable;
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";
            dtFunds.Rows.InsertAt(dr, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");

            int index = cmbxFunds.FindString(fundName);
            cmbxFunds.SelectedIndex = index;
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
            if (journalName != string.Empty)
            {
                int index = cmbxJournals.FindString(journalName);
                cmbxJournals.SelectedIndex = index;
            }
        }

        private void LoadSelected()
        {
            Cursor = Cursors.WaitCursor;
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            string jevNo = dgJEV.Rows[rowIndex].Cells["jev_no"].Value.ToString();
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
            int createdById = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["created_by_id"].Value);

            var frmJev = new frmJev(true, this, ucJevDashboard);
            var ucFrmJev = frmJev.ucjev1;
            ucFrmJev.jevNo = jevNo;
            ucFrmJev.jevId = jevId;
            frmJev.createdById = createdById;
            frmJev.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSelected();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = month == 0 ? DateTime.Now.Month - 1 : month;
        }

        private void EnableDisableButtons()
        {
            if (dgJEV.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
            }
            else
                btnSelect.Enabled = false;
        }

        private string GetJevStatus(byte isApproved, byte isDisapproved, byte isCancelled)
        {
            if (isApproved == 0 && isDisapproved == 0 && isCancelled == 0)
                return "Pending";

            if (isApproved == 1 && isDisapproved == 0 && isCancelled == 0)
                return "Approved";

            if (isApproved == 0 && isDisapproved == 1 && isCancelled == 0)
                return "Disapproved";

            if (isCancelled == 1)
                return "Cancelled";

            return string.Empty;
        }

        private void LoadStatusColors()
        {
            foreach (DataGridViewRow row in dgJEV.Rows)
            {
                string status = row.Cells["status"].Value.ToString();
                row.Cells["status"].Style.BackColor = Helper.StatusColor(status);
                row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor(status);
                row.Cells["status"].Style.Format.ToUpper();
            }
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxJevStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgJEV_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgJEV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgJEV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            LoadSelected();
        }

        internal void LoadJEVList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync(JevListParameters());
            }
        }

        private Dictionary<string, string> JevListParameters()
        {
            string jevStatus = cmbxJevStatus.Text.ToLower();
            string searchKey = txtSearch.Text;

            var dictParameters = new Dictionary<string, string>();

            dictParameters.Add("jev_status", jevStatus);
            dictParameters.Add("search_key", searchKey);
            dictParameters.Add("journal", journalName);
            dictParameters.Add("fund", fundName);
            dictParameters.Add("month", month.ToString());
            dictParameters.Add("year", year.ToString());

            return dictParameters;
        }

        private DataColumn[] JevListColumns()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "jev_no", typeof(string)),
                new DataColumn(Name = "full_jev_no", typeof(string)),
                new DataColumn(Name = "date_entry", typeof(DateTime)),
                new DataColumn(Name = "funds_id", typeof(int)),
                new DataColumn(Name = "fund_name", typeof(string)),
                new DataColumn(Name = "journals_id", typeof(int)),
                new DataColumn(Name = "journal_name", typeof(string)),
                new DataColumn(Name = "ref_no", typeof(string)),
                new DataColumn(Name = "payee", typeof(string)),
                new DataColumn(Name = "explanation", typeof(string)),
                new DataColumn(Name = "created_at", typeof(string)),
                new DataColumn(Name = "created_by_id", typeof(string)),
                new DataColumn(Name = "created_by_name", typeof(string)),
                new DataColumn(Name = "updated_at", typeof(string)),
                new DataColumn(Name = "updated_by_id",typeof(string)),
                new DataColumn(Name = "updated_by_name", typeof(string)),
                new DataColumn(Name = "status", typeof(string))
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Check if the parameters are valid
            if (e.Argument is not Dictionary<string, string> dictParameters)
                throw new ArgumentException("Parameters is not a Dictionary");

            string searchKey = dictParameters["search_key"];
            string jevStatus = dictParameters["jev_status"];
            string journal = dictParameters["journal"];
            string fund = dictParameters["fund"];
            short month = Convert.ToInt16(dictParameters["month"]);
            short year = Convert.ToInt16(dictParameters["year"]);

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(JevListColumns());

            var dtJevDb = AccFactory.JEVRepository().GetViewRecords_By_Status_JournalName_Search_Month_Year(jevStatus, searchKey, journal, fund, month, year);

            //Check if the database data table rows is less than 1
            if (dtJevDb.Rows.Count < 1)
            {
                e.Result = dataTable;
                backgroundWorker1.ReportProgress(100);
                return;
            }

            int progressCount = 0;
            int totalProgressCount = dtJevDb.Rows.Count;

            foreach (DataRow row in dtJevDb.Rows)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var newRow = dataTable.NewRow();
                byte isApproved = Convert.ToByte(row["is_approved"]);
                byte isDisapproved = Convert.ToByte(row["is_disapproved"]);
                byte isCancelled = Convert.ToByte(row["is_cancelled"]);

                int rowId = Convert.ToInt32(row["id"]);
                DateTime rowDateEntry = Convert.ToDateTime(row["date_entry"].ToString());
                string rowJevNo = row["jev_no"].ToString();
                string rowFullJEVNo = row["full_jev_no"].ToString();
                int rowFundId = Convert.ToInt32(row["funds_id"]);
                string rowFundName = row["fund_name"].ToString();
                int rowJournalId = Convert.ToInt32(row["journals_id"]);
                string rowJournalName = row["journal_name"].ToString();
                string rowRefNo = row["ref_no"].ToString();
                string rowPayee = row["payee"].ToString();
                string rowExplanation = row["explanation"].ToString();
                string rowCreatedAt = row["created_at"].ToString();
                string rowCreatedById = row["created_by"].ToString();
                var dictUserCreatedBy = AccFactory.UsersRepository().GetUserByID(Convert.ToByte(rowCreatedById));
                var rowCreatedByName = string.IsNullOrEmpty(rowCreatedById) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(rowCreatedById))["user_full_name"];
                string rowUpdatedAt = row["updated_at"].ToString();
                string rowUpdatedById = row["updated_by"].ToString();
                string rowUpdatedByName = string.IsNullOrEmpty(rowUpdatedById) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(rowUpdatedById))["user_full_name"]; ;
                string rowStatus = GetJevStatus(isApproved, isDisapproved, isCancelled);

                newRow["id"] = rowId;
                newRow["date_entry"] = rowDateEntry;
                newRow["jev_no"] = rowJevNo;
                newRow["full_jev_no"] = rowFullJEVNo;
                newRow["funds_id"] = rowFundId;
                newRow["fund_name"] = rowFundName;
                newRow["journals_id"] = rowJournalId;
                newRow["journal_name"] = rowJournalName;
                newRow["ref_no"] = rowRefNo;
                newRow["payee"] = rowPayee;
                newRow["explanation"] = rowExplanation;
                newRow["created_at"] = rowCreatedAt;
                newRow["created_by_id"] = rowCreatedById;
                newRow["created_by_name"] = rowCreatedByName;
                newRow["updated_at"] = rowUpdatedAt;
                newRow["updated_by_id"] = rowUpdatedById;
                newRow["updated_by_name"] = rowUpdatedByName;
                newRow["status"] = rowStatus;

                progressCount++;
                dataTable.Rows.Add(newRow);
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = dataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.JevDatagridView(dgJEV, dataTable);
            dgJEV.CurrentCell = dgJEV.FirstDisplayedCell;
            LoadStatusColors();
            EnableDisableButtons();
        }

        private void frmJEVList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}