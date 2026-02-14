using ACC.Data;
using LFS.Budget.Helpers;
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
                //HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
                dtPckrFrom.Value = dtPckrTo.Value.AddYears(-1);

                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnReview);
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

        private void EnableDisableButtons(DataGridView dgv, ToolStripButton btnCrt, ToolStripButton btnEdit, ToolStripButton btnDelete, ToolStripButton btnView, ToolStripButton btnReview)
        {
            int selected = dgv.SelectedRows.Count;

            if (dgv.Rows.Count == 0)
            {
                btnCrt.Enabled = true;

                btnView.Visible = false;
                btnView.Enabled = false;

                btnEdit.Enabled = false;

                btnDelete.Enabled = false;

                btnReview.Enabled = false;

                return;
            }

            string status = GetFltrStatus()?.ToLower() ?? "";

            btnDelete.Text = selected > 0 ? $"Delete ({selected})" : "Delete";

            var config = new Dictionary<string, (bool create,
                                                 bool viewVisible, bool viewEnabled,
                                                 bool editVisible, bool editEnabled,
                                                 bool deleteEnabled, bool reviewEnabled)>
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

            bool auditFromStatus = c.reviewEnabled;
            bool hasPrivilege = PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval);

            btnReview.Enabled = auditFromStatus && hasPrivilege && selected > 0;
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

        private void ToggleReview()
        {
            int rowIndex = dgvMain.CurrentCell.RowIndex;
            int oblgtnId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
            ucObligationsAudit.LoadReviewMode(oblgtnId);
            customTabControl1.SelectedTab = tbPgReview;
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

                (string srchKey,
                string status,
                DateTime dtFrom,
                DateTime dtTo,
                int rowLimit)
                parameters =
                (
                    txtSearch.Text,
                    GetFltrStatus(),
                    dtPckrFrom.Value,
                    dtPckrTo.Value,
                    100
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
                ToggleReview();
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
                        EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlsStrpBtnBckView, tlStrpBtnReview);
                    }
                }
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

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnReview);
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

                var service = new Services.ObligationService();
                e.Result = service.GetObligationRequests(
                    parameters.srchKey,
                    parameters.status,
                    parameters.dtFrom,
                    parameters.dtTo,
                    parameters.rowLimit,
                    (current, total) => Helper.ProgressCounter(backgroundWorker1, total, current)
                );
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

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchTxt = txtSearch.Text.Trim();

                if (searchTxt.Length > 3 || searchTxt.Length < 1)
                    LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radPending_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radApproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radDisapproved_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radCancelled_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtPckrTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOblgtnRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}