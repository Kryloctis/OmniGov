using ACC.Data;
using LFS.Helpers;
using LFS.Views.Dashboard;
using System;
using System.CodeDom;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class frmJevList : Form
    {
        internal ucJevDashboard ucJevDashboard;
        private ucJev ucJev;

        public frmJevList(ucJevDashboard ucJevDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.ucJevDashboard = ucJevDashboard;
            ucJev = ucJev1;
            Helper.DatagridFullRowSelectStyle(dgJEV);
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
                MonitorControlChanges(panel1, btnApplyFltr);
                Helper.EnableDisableToolStripButtons(dgJEV, tlStrpBtnUpdate, tlStrpBtnDelete);
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

            return dataTable;
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
        }

        private void MonitorControlChanges(Control parent, Button targetButton)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                    tb.TextChanged += (s, e) => btnApplyFltr.Enabled = true;
                else if (ctrl is RadioButton rb)
                    rb.CheckedChanged += (s, e) => btnApplyFltr.Enabled = true;
                else if (ctrl is ComboBox cb)
                    cb.SelectedIndexChanged += (s, e) => btnApplyFltr.Enabled = true;
                else if (ctrl is CheckBox chk)
                    chk.CheckedChanged += (s, e) => btnApplyFltr.Enabled = true;
                else if (ctrl is DateTimePicker dp)
                    dp.ValueChanged += (s, e) => btnApplyFltr.Enabled = true;

                // Recurse into child containers
                if (ctrl.HasChildren)
                    MonitorControlChanges(ctrl, btnApplyFltr);
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

        private void dgJEV_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgJEV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private string GetFltrStatus()
        {
            if (radApproved.Checked)
                return "Approved";
            else if (radDisapproved.Checked)
                return "Disapproved";
            else if (radCancelled.Checked)
                return "Cancelled";
            else
                return "Pending";
        }

        internal void LoadJEVList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;

                var parameters = new (string name, object value)[]
                {
                    ("search_key", tlStrpTxtSearch.Text),
                    ("status", GetFltrStatus()),
                    ("journal", cmbxJournals.Text),
                    ("fund", cmbxFunds.Text),
                    ("year", nudYear.Value)
                };

                backgroundWorker1.RunWorkerAsync(parameters);
            }
        }

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
            string jevStatus = dict["status"]?.ToString().ToLower();
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

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.JevDatagridView(dgJEV, dataTable);
            dgJEV.CurrentCell = dgJEV.FirstDisplayedCell;
        }

        private void frmJEVList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnApplyFltr_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJEVList();
                btnApplyFltr.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleCrud(bool isEdit)
        {
            string crudIndct;

            if (isEdit)
            {
                int rowIndex = dgJEV.CurrentCell.RowIndex;
                int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
                customTabControl1.SelectedTab = tbPgCrud;
                ucJev.OnLoad(true, jevId);
                crudIndct = "Create Journal Entry Voucher";
            }
            else
            {
                customTabControl1.SelectedTab = tbPgCrud;
                ucJev.OnLoad(false, null);
                crudIndct = "Update Journal Entry Voucher";
            }

            lblCrudStat.Text = crudIndct;
        }

        private void tlStrpBtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                customTabControl1.SelectedTab = tbPgMain;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ucJev.ValidateChildren())
                {
                    Helper.MessageBoxError(ucJev.GetFormErrors());
                    return;
                }

                bool jevIsSubmitted = ucJev.SubmitJev(out string message, out bool isEdit);

                if (jevIsSubmitted)
                {
                    Helper.MessageBoxSuccess(message);
                    LoadJEVList();

                    if (!isEdit)
                    {
                        ucJev.ResetForm();
                        customTabControl1.SelectedTab = tbPgMain;
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        //private bool InsertData()
        //{
        //    switch ()
        //    {
        //        case "General Journal":
        //            return InsertGeneralJournal();

        //        case "Procurement Received Journal":
        //            return InsertProcuremntRcvJournal();

        //        case "Cash Disbursements Journal":
        //            return InsertCashDisbursementsJournal();

        //        case "Cash Receipts Journal":
        //            return InsertCashReceiptsJournal();

        //        case "Check Disbursements Journal":
        //            return InsertCheckDisbursementJournal();

        //        case "Authority to Debit Account Disbursement Journal":
        //            return InsertADADisbursementsJournal();

        //        default: return false;
        //    }
        //}

        //internal bool UpdateData()
        //{
        //    bool updated;

        //    //switch (jevStatus.ToLower())
        //    //{
        //    //    case "pending":
        //    //        jevModel.JEVNumber = null;
        //    //        jevModel.IsApproved = false;
        //    //        jevModel.IsDisapproved = false;
        //    //        jevModel.IsCancelled = false;
        //    //        jevModel.Remarks = remarks;
        //    //        break;

        //    //    case "disapproved":
        //    //        jevModel.JEVNumber = null;
        //    //        jevModel.IsApproved = false;
        //    //        jevModel.IsDisapproved = true;
        //    //        jevModel.Remarks = remarks;
        //    //        break;

        //    //    case "approved":
        //    //        jevModel.JEVNumber = AccFactory.JEVRepository().GetLastJevNoSeries(uc.fundId);
        //    //        jevModel.IsApproved = true;
        //    //        jevModel.IsDisapproved = false;
        //    //        jevModel.IsCancelled = false;
        //    //        jevModel.Remarks = remarks;
        //    //        break;

        //    //    case "cancelled":
        //    //        jevModel.IsCancelled = true;
        //    //        jevModel.Remarks = remarks;
        //    //        break;
        //    //}

        //    switch ()
        //    {
        //        case "General Journal":
        //            updated = UpdateGenJrnl();
        //            break;

        //        case "Cash Disbursements Journal":
        //            updated = UpdateCshDsbrsmntsJrnl();
        //            break;

        //        case "Cash Receipts Journal":
        //            updated = UpdateCshRcptsJrnl();
        //            break;

        //        case "Check Disbursements Journal":
        //            updated = UpdateChkDsbrsmntJrnl();
        //            break;

        //        case "Procurement Received Journal":
        //            updated = UpdateProctRcvJrnl();
        //            break;

        //        case "Authority to Debit Account Disbursement Journal":
        //            updated = UpdateAdaDsbrsmntsJrnl();
        //            break;

        //        default:
        //            updated = false;
        //            break;
        //    }

        //    if (journalId != oldJournalId) //CHECK IF THE PREVIOUS JOURNAL ID IS NOT EQUAL TO NEW SELECTED JOURNAL ID
        //    {
        //        switch (oldJournalId)
        //        {
        //            case 1:
        //                AccFactory.GeneralJournalRepository().DeleteGenJrnlJevId(jevId);
        //                break;

        //            case 2:
        //                AccFactory.CashReceiptsJournalRepository().DeleteCshRcptsJrnlJevId(jevId);
        //                break;

        //            case 3:
        //                //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
        //                break;

        //            case 4:
        //                AccFactory.CashDisbursementsJournalRepository().DeleteCshDsbrsmntJrnlJevId(jevId);
        //                break;

        //            case 5:
        //                AccFactory.CheckDisbursementsJournalRepository().DeleteChckDsbrsmntJrnlJevId(jevId);
        //                break;

        //            case 6:
        //                //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
        //                break;
        //        }
        //    }

        //    return updated;
        //}

        //private bool SaveData()
        //{
        //    if (!FormValidations())
        //        return false;

        //    bool saveData;

        //    if (isEdit)
        //    {
        //        string currentJevStatus = AccFactory.JEVRepository().GetJevStatus(jevId);
        //        if (currentJevStatus.ToLower() == "disapproved")
        //        {
        //            if (Helper.MessageBoxConfirmCancel("This JEV will be return into Pending.\nConfirm if you want to proceed..."))
        //                saveData = UpdateData("pending");
        //            else
        //                return false;
        //        }
        //        else
        //            saveData = UpdateData(currentJevStatus);
        //    }
        //    else
        //        saveData = InsertData();

        //    return saveData;
        //}
    }
}