using ACC.Data;
using Google.Protobuf.WellKnownTypes;
using LFS.Helpers;
using LFS.Properties;
using LFS.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class frmJevList : Form
    {
        internal ucJevDashboard ucJevDashboard;

        public frmJevList(ucJevDashboard ucJevDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.ucJevDashboard = ucJevDashboard;
            Helper.DatagridFullRowSelectStyle(dgJEV, true);
        }

        private void frmJEVList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadJournals();
                LoadFunds();
                HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
                nudYear.Value = Helper.GetCurrentDate().Year;
                LoadJEVList();
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
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
        }

        private void LoadSelected()
        {
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
                Helper.EnableDisableToolStripButtons(dgJEV, tlStrpBtnUpdate, tlStrpBtnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnSearch_Click(object sender, EventArgs e)
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

        internal void LoadJEVList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;

                var parameters = new (string name, object value)[]
                {
                    ("search_key", tlStrpTxtSearch.Text),
                    ("journal", cmbxJournals.Text),
                    ("fund", cmbxFunds.Text),
                    ("year", nudYear.Value)
                };

                backgroundWorker1.RunWorkerAsync(parameters);
            }
        }

        private string GetJevStatus(bool isApproved, bool isDisapproved, bool isCancelled) =>
            isCancelled ? "Cancelled" :
            isApproved ? "Approved" :
            isDisapproved ? "Disapproved" :
            "Pending";

        private string GetUserFullName(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return string.Empty;

            var userData = Helper.GetUserDataById(Convert.ToInt32(userId));
            return userData?["user_full_name"] ?? string.Empty;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Define columns once
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("status", typeof(string)),
                new DataColumn("TRN. No.", typeof(string)),
                new DataColumn("jev_no", typeof(string)),
                new DataColumn("full_jev_no", typeof(string)),
                new DataColumn("date_entry", typeof(DateTime)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("created_by_id", typeof(string)),
                new DataColumn("created_by_name", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
                new DataColumn("updated_by_id", typeof(string)),
                new DataColumn("updated_by_name", typeof(string)),
            });

            // Convert arguments to dictionary
            var args = (ValueTuple<string, object>[])e.Argument;
            var dict = args.ToDictionary(x => x.Item1, x => x.Item2);

            string searchKey = dict["search_key"]?.ToString() ?? string.Empty;
            string jevStatus = "All"; // Default value
            string journal = dict["journal"]?.ToString() ?? string.Empty;
            string fund = dict["fund"]?.ToString() ?? string.Empty;
            short year = Convert.ToInt16(dict["year"]);

            // Retrieve data
            var dtJevDb = AccFactory.JEVRepository()
                .GetViewRecords(jevStatus, searchKey, journal, fund, year);

            int totalCount = dtJevDb.Rows.Count;
            int progress = 0;

            foreach (DataRow row in dtJevDb.Rows)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var newRow = dataTable.NewRow();

                // Safely convert numeric flags to bool
                bool isApproved = Convert.ToInt32(row["is_approved"]) == 1;
                bool isDisapproved = Convert.ToInt32(row["is_disapproved"]) == 1;
                bool isCancelled = Convert.ToInt32(row["is_cancelled"]) == 1;

                // Safely convert mixed numeric and string fields
                newRow["id"] = Convert.ToInt32(row["id"]);
                newRow["jev_no"] = row["jev_no"]?.ToString();
                newRow["full_jev_no"] = row["full_jev_no"]?.ToString();
                newRow["date_entry"] = Convert.ToDateTime(row["date_entry"]);
                newRow["payee"] = row["payee"]?.ToString();
                newRow["created_at"] = row["created_at"]?.ToString();
                newRow["updated_at"] = row["updated_at"]?.ToString();

                // Convert nullable IDs safely
                string createdById = row["created_by"]?.ToString();
                string updatedById = row["updated_by"]?.ToString();

                newRow["created_by_id"] = createdById;
                newRow["created_by_name"] = GetUserFullName(createdById);
                newRow["updated_by_id"] = updatedById;
                newRow["updated_by_name"] = GetUserFullName(updatedById);
                newRow["status"] = GetJevStatus(isApproved, isDisapproved, isCancelled);

                dataTable.Rows.Add(newRow);

                Helper.ProgressCounter(backgroundWorker1, totalCount, ++progress);
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
        }

        private void frmJEVList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
                tlStrpBtnFilter.Image = splitContainer1.Panel2Collapsed ?
                                        Resources.filter_20px : Resources.symbol_cancel_20px;
                tlStrpBtnFilter.Text = splitContainer1.Panel2Collapsed ? "Filter" : "Close";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnApplyFltr_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}