using Accounting.Data;
using Accounting.Domain.Entities;
using LFS.Helpers;
using LFS.Views.Dashboard;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
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
        private ucJev ucJev;
        private ucJev ucJevView;

        public frmJevList(ucJevDashboard ucJevDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            this.ucJevDashboard = ucJevDashboard;
            ucJev = ucJev1;
            ucJevView = ucJev2;
            Helper.DatagridFullRowSelectStyle(dgJEV, true);
        }

        private void VerifyUserPrivileges()
        {
            tlStrpBtnAudit.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval);
        }

        private void frmJEVList_Load(object sender, EventArgs e)
        {
            try
            {
                VerifyUserPrivileges();
                LoadJournals();
                LoadFunds();
                HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
                tlStrpCmbxLimit.ComboBox.SelectionChangeCommitted += (s, ev) => LoadJevRecords();
                nudYear.Value = Helper.GetCurrentDate().Year;
                LoadJevRecords();
                MonitorControlChanges(panel1, btnApplyFltr);
                EnableDisableButtons(dgJEV, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DatatableJournals()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("journal_name");

            var dtJournals = Factory.JournalsRepository().GetRecords();
            dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");

            return dataTable;
        }

        internal void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
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

        private void EnableDisableButtons(DataGridView dgv,
                                      ToolStripButton btnCrt,
                                      ToolStripButton btnEdit,
                                      ToolStripButton btnDelete,
                                      ToolStripButton btnView,
                                      ToolStripButton btnAudit)
        {
            int selected = dgv.SelectedRows.Count;

            if (dgv.Rows.Count == 0)
            {
                btnCrt.Enabled = true;

                btnView.Visible = false;
                btnView.Enabled = false;

                btnEdit.Enabled = false;

                btnDelete.Enabled = false;

                btnAudit.Enabled = false;

                return;
            }

            string status = GetFltrStatus()?.ToLower() ?? "";

            btnDelete.Text = selected > 0 ? $"Delete ({selected})" : "Delete";

            var config = new Dictionary<string, (bool create,
                                                 bool viewVisible, bool viewEnabled,
                                                 bool editVisible, bool editEnabled,
                                                 bool deleteEnabled, bool auditEnabled)>
            {
                ["approved"] = (true, true, true, false, false, false, false),
                ["cancelled"] = (true, false, false, true, false, false, true),
                ["disapproved"] = (true, false, false, true, true, true, true),
                [""] = (true, false, false, true, true, true, true),
            };

            var c = config.ContainsKey(status) ? config[status] : config[""];

            btnCrt.Enabled = c.create;

            btnView.Visible = c.viewVisible;
            btnView.Enabled = c.viewEnabled && selected == 1;

            btnEdit.Visible = c.editVisible;
            btnEdit.Enabled = c.editEnabled && selected == 1;

            btnDelete.Enabled = c.deleteEnabled && selected > 0;

            bool auditFromStatus = c.auditEnabled;
            bool hasPrivilege = PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval);

            btnAudit.Enabled = auditFromStatus && hasPrivilege && selected > 0;
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons(dgJEV, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadJevRecords();
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

        internal void LoadJevRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                int rowLimit = Convert.ToInt32(tlStrpCmbxLimit.ComboBox.SelectedValue);

                var parameters = new (string name, object value)[]
                {
                    ("search_key", tlStrpTxtSearch.Text),
                    ("status", GetFltrStatus()),
                    ("journal", cmbxJournals.Text),
                    ("fund", cmbxFunds.Text),
                    ("year", nudYear.Value),
                    ("row_limit", rowLimit),
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
                new DataColumn("trnsction_no", typeof(string)),
                new DataColumn("jev_no", typeof(string)),
                new DataColumn("full_jev_no", typeof(string)),
                new DataColumn("date_entry", typeof(DateTime)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("status", typeof(string)),
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
            int rowLimit = Convert.ToInt32(dict["row_limit"]);
            string journal = dict["journal"]?.ToString() ?? string.Empty;
            string fund = dict["fund"]?.ToString() ?? string.Empty;
            short year = Convert.ToInt16(dict["year"]);

            // Retrieve data
            var dtJevDb = AccountingFactory.JEVRepository()
                .GetViewRecords(jevStatus, searchKey, journal, fund, year, rowLimit);

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

                DateTime dateEntry = Convert.ToDateTime(row["date_entry"]);
                string trnsctnNo = $"{dateEntry:yy}-{row["trns_no"]}";

                // Safely convert mixed numeric and string fields
                newRow["id"] = Convert.ToInt32(row["id"]);
                newRow["trnsction_no"] = trnsctnNo;
                newRow["jev_no"] = row["jev_no"]?.ToString();
                newRow["full_jev_no"] = row["full_jev_no"]?.ToString();
                newRow["date_entry"] = dateEntry;
                newRow["payee"] = row["payee"]?.ToString();
                newRow["status"] = jevStatus;
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
                LoadJevRecords();
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
                ucJev.OnLoad(true, jevId);
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Update Journal Entry Voucher";
            }
            else
            {
                ucJev.OnLoad(false, null);
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Create Journal Entry Voucher";
            }

            lblCrudStat.Text = crudIndct;
        }

        private void ToggleView()
        {
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
            ucJevView.OnLoad(true, jevId);
            ucJevView.SetJevReadOnly(true);
            customTabControl1.SelectedTab = tbPgView;
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

        private bool DeleteJev(DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection)
        {
            var models = new List<JevModel>();

            foreach (DataGridViewRow dgvRow in dataGridViewSelectedRowCollection)
            {
                var model = new JevModel();
                model.Id = Convert.ToInt32(dgvRow.Cells["id"].Value);
                models.Add(model);
            }

            return AccountingFactory.JEVRepository().Delete(models);
        }

        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var slctdRows = dgJEV.SelectedRows;
                if (Helper.MessageBoxConfirmDelete(slctdRows.Count))
                {
                    if (DeleteJev(slctdRows))
                    {
                        Helper.MessageBoxSuccess($"{slctdRows.Count} JEV records has been deleted");
                        LoadJevRecords();
                    }
                }
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
                if (!ucJev.ValidateChildren() || !ucJev.AccEntriesValidated().isValid)
                {
                    Helper.MessageBoxError(ucJev.GetFormErrors());
                    return;
                }

                bool jevIsSubmitted = ucJev.SubmitJev(out string message, out bool isEdit);

                if (jevIsSubmitted)
                {
                    Helper.MessageBoxSuccess(message);
                    LoadJevRecords();
                    ucJev.ResetForm();

                    if (isEdit)
                        customTabControl1.SelectedTab = tbPgMain;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleView();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleAudit()
        {
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
            ucJevAudit.OnLoad(true, jevId);
            ucJevAudit.SetJevReadOnly(true);
            customTabControl1.SelectedTab = tbPgAudit;
        }

        private void tlStrpBtnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleAudit();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlsStrpBtnBckView_Click(object sender, EventArgs e)
        {
            try
            {
                customTabControl1.SelectedTab = tbPgMain;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnBckAudit_Click(object sender, EventArgs e)
        {
            try
            {
                customTabControl1.SelectedTab = tbPgMain;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucJevAudit.ApproveJev(out string jevNo, out string trnsctnNo))
                {
                    Helper.MessageBoxSuccess($"JEV (Transaction No.{trnsctnNo}) has been Approved\nJEV No. {jevNo}");
                    int rowIndex = dgJEV.CurrentCell.RowIndex;
                    int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
                    ucJevView.OnLoad(true, jevId);
                    ucJevView.SetJevReadOnly(true);
                    customTabControl1.SelectedTab = tbPgView;
                    ucJevAudit.ResetForm();
                    LoadJevRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucJevAudit.DisapproveJev(out string trnsctnNo))
                {
                    Helper.MessageBoxSuccess($"JEV (Transaction No.{trnsctnNo}) has been Disapproved");
                    int rowIndex = dgJEV.CurrentCell.RowIndex;
                    int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
                    ucJevAudit.OnLoad(true, jevId);
                    ucJevAudit.SetJevReadOnly(true);
                    LoadJevRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucJevAudit.CancelJev(out string trnsctnNo))
                {
                    Helper.MessageBoxSuccess($"JEV (Transaction No.{trnsctnNo}) has been Cancelled");
                    int rowIndex = dgJEV.CurrentCell.RowIndex;
                    int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
                    ucJevAudit.OnLoad(true, jevId);
                    ucJevAudit.SetJevReadOnly(true);
                    LoadJevRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

