using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Budget.Views.Obligations
{
    public partial class frmObligations : Form
    {
        public frmObligations()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvMain, true);
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
                tlStrpCmbxLimit.ComboBox.SelectionChangeCommitted += (s, ev) => LoadOblgtnRecords();
                dtPckrFrom.Value = dtPckrTo.Value.AddYears(-1);
                MonitorControlChanges(panel1, btnApplyFltr);
                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        private void EnableDisableButtons(DataGridView dgv, ToolStripButton btnCrt, ToolStripButton btnEdit, ToolStripButton btnDelete, ToolStripButton btnView, ToolStripButton btnAudit)
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

        private void MonitorControlChanges(Control parent, Button targetButton)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                    tb.TextChanged += (s, e) => targetButton.Enabled = true;
                else if (ctrl is RadioButton rb)
                    rb.CheckedChanged += (s, e) => targetButton.Enabled = true;
                else if (ctrl is ComboBox cb)
                    cb.SelectedIndexChanged += (s, e) => targetButton.Enabled = true;
                else if (ctrl is CheckBox chk)
                    chk.CheckedChanged += (s, e) => targetButton.Enabled = true;
                else if (ctrl is DateTimePicker dp)
                    dp.ValueChanged += (s, e) => targetButton.Enabled = true;

                // Recurse into child containers
                if (ctrl.HasChildren)
                    MonitorControlChanges(ctrl, targetButton);
            }
        }

        private void ToggleCrud(bool isEdit)
        {
            string crudIndct;

            if (isEdit)
            {
                int rowIndex = dgvMain.CurrentCell.RowIndex;
                int oblgtnRqstId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
                ucObligationsCrud.LoadCrudMode(true, oblgtnRqstId);
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Update Obligation Request";
            }
            else
            {
                ucObligationsCrud.LoadCrudMode(false);
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Create Obligation Request";
            }

            lblCrudStat.Text = crudIndct;
        }

        private void ToggleView()
        {
            int rowIndex = dgvMain.CurrentCell.RowIndex;
            int oblgtnId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
            ucObligationsView.LoadViewMode(oblgtnId);
            customTabControl1.SelectedTab = tbPgView;
        }

        private void ToggleAudit()
        {
            int rowIndex = dgvMain.CurrentCell.RowIndex;
            int oblgtnId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
            ucObligationsAudit.LoadAuditMode(oblgtnId);
            customTabControl1.SelectedTab = tbPgAudit;
        }

        private bool DeleteData(List<int> oblgtnIds)
        {
            var models = new List<ObligationRequestModel>();

            foreach (int oblgtnId in oblgtnIds)
            {
                var model = new ObligationRequestModel() { Id = oblgtnId };
                models.Add(model);
            }

            return AccFactory.ObligationRequestRepository().Delete(models);
        }

        private string GetUserFullName(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return string.Empty;

            var userData = Helper.GetUserDataById(Convert.ToInt32(userId));
            return userData?["user_full_name"] ?? string.Empty;
        }

        private void LoadOblgtnRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                btnApplyFltr.Enabled = false;

                (string srchKey,
                string status,
                DateTime dtFrom,
                DateTime dtTo,
                int rowLimit)
                parameters =
                (
                    tlStrpTxtSearch.Text,
                    GetFltrStatus(),
                    dtPckrFrom.Value,
                    dtPckrTo.Value,
                    Convert.ToInt32(tlStrpCmbxLimit.ComboBox.SelectedValue)
                );

                backgroundWorker1.RunWorkerAsync(parameters);
            }
        }

        private bool SaveOblgtnRqst((ObligationRequestModel oblgtnRqstModel, List<ObligationAccountModel> oblgtnAccModels) models)
        {
            if (models.oblgtnRqstModel.Id == 0)
                return AccFactory.ObligationRequestRepository().Insert(models.oblgtnRqstModel, models.oblgtnAccModels);
            else
                return AccFactory.ObligationRequestRepository().Update(models.oblgtnRqstModel, models.oblgtnAccModels);
        }

        #region Events

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

        private void tlStrpBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleView();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleAudit();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var slctdRow = dgvMain.SelectedRows;
                List<int> oblgtnRqstIds = dgvMain.SelectedRows
                                                .Cast<DataGridViewRow>()
                                                .Select(r => Convert.ToInt32(r.Cells["id"].Value)).ToList();

                if (Helper.MessageBoxConfirmDelete(slctdRow.Count))
                {
                    if (DeleteData(oblgtnRqstIds))
                    {
                        LoadOblgtnRecords();
                        EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlsStrpBtnBckView, tlStrpBtnAudit);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnApplyFltr_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnCrudBack_Click(object sender, EventArgs e)
        {
            try
            {
                customTabControl1.SelectedTab = tbPgMain;
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

        private void btnCrudSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var models = ucObligationsCrud.ObligationRequestModel();

                if (SaveOblgtnRqst(models))
                {
                    string message = $"Obligation Request (Transaction No. {models.oblgtnRqstModel.TransactionNo})";

                    if (models.oblgtnRqstModel.Id == 0)
                    {
                        Helper.MessageBoxSuccess($"{message} has been submitted");
                    }
                    else
                    {
                        Helper.MessageBoxSuccess($"{message} modification has been submitted");
                        customTabControl1.SelectedTab = tbPgMain;
                    }

                    ucObligationsCrud.ResetForm();
                    LoadOblgtnRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtPckrFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtPckrTo.MinDate = dtPckrFrom.Value;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string srchKey, string status, DateTime dtFrom, DateTime dtTo, int rowLimit))e.Argument;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(new[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("transaction_no", typeof(string)),
                    new DataColumn("obligation_no", typeof(string)),
                    new DataColumn("date_requested", typeof(DateTime)),
                    new DataColumn("payee", typeof(string)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("created_by_id", typeof(string)),
                    new DataColumn("created_by_name", typeof(string)),
                    new DataColumn("updated_at", typeof(string)),
                    new DataColumn("updated_by_id", typeof(string)),
                    new DataColumn("updated_by_name", typeof(string)),
                });

                var dtObligations = AccFactory.ObligationRequestRepository().GetRecords(parameters.srchKey,
                                                 parameters.status.ToLower(),
                                                 parameters.dtFrom,
                                                 parameters.dtTo,
                                                 parameters.rowLimit);

                int totalRowCount = dtObligations.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dtRow in dtObligations.Rows)
                {
                    var newRow = dataTable.NewRow();
                    newRow["id"] = dtRow["id"];
                    newRow["transaction_no"] = dtRow["transaction_no"];
                    newRow["obligation_no"] = dtRow["obligation_no"];
                    newRow["date_requested"] = dtRow["date_requested"];
                    newRow["payee"] = dtRow["payee"];

                    string createdById = dtRow["created_by"]?.ToString();
                    string updatedById = dtRow["updated_by"]?.ToString();

                    newRow["created_at"] = dtRow["created_at"];
                    newRow["created_by_id"] = dtRow["created_by"];
                    newRow["created_by_name"] = GetUserFullName(createdById);
                    newRow["updated_at"] = dtRow["updated_at"];
                    newRow["updated_by_id"] = dtRow["updated_by"];
                    newRow["updated_by_name"] = GetUserFullName(updatedById);

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalRowCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pbLoadRecords.Value = e.ProgressPercentage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is DataTable dataTable)
                {
                    if (dataTable.Rows.Count < 1) pbLoadRecords.Value = 100;
                    HelperLoadRecords.DgvOblgtnRqst(dataTable, dgvMain);
                    dgvMain.CurrentCell = dgvMain.FirstDisplayedCell;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Events
    }
}