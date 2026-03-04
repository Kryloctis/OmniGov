using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;
using OmniGov.Budget.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Budget.Views.Obligations
{
    public partial class frmObligations : Form
    {
        public frmObligations()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgvMain, true);

            btnApprove.Click += btnApprove_Click;
            btnDisapprove.Click += btnDisapprove_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {
            //HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
            dtPckrFrom.Value = dtPckrTo.Value.AddYears(-1);

            EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnReview);
            LoadOblgtnRecords();
        }

        private ObligationRequestModel.Status GetFltrStatus()
        {
            if (radApproved.Checked)
                return ObligationRequestModel.Status.approved;
            else if (radDisapproved.Checked)
                return ObligationRequestModel.Status.disapproved;
            else if (radCancelled.Checked)
                return ObligationRequestModel.Status.cancelled;
            else
                return ObligationRequestModel.Status.pending;
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

            string status = GetFltrStatus().ToString().ToLower();

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

            return BudgetFactory.ObligationRequestRepository().Delete(models);
        }

        private void LoadOblgtnRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;

                (string srchKey,
                ObligationRequestModel.Status status,
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

        private void tlStrpBtnCreate_Click(object sender, EventArgs e)
        {
            ToggleCrud(false);
        }

        private void tlStrpBtnUpdate_Click(object sender, EventArgs e)
        {
            ToggleCrud(true);
        }

        private void tlStrpBtnView_Click(object sender, EventArgs e)
        {
            ToggleView();
        }

        private void tlStrpBtnAudit_Click(object sender, EventArgs e)
        {
            ToggleReview();
        }

        private void tlStrpBtnDelete_Click(object sender, EventArgs e)
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

        private void tlStrpBtnCrudBack_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedTab = tbPgMain;
        }

        private void tlsStrpBtnBckView_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedTab = tbPgMain;
        }

        private void tlStrpBtnBckAudit_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedTab = tbPgMain;
        }

        private bool SaveOblgtnRqst((ObligationRequestModel oblgtnRqstModel, List<ObligationAccountModel> oblgtnAccModels) models)
        {
            ucObligationsCrud.ValidateChildren();
            string errs = ucObligationsCrud.GetFormErrors();
            if (!string.IsNullOrWhiteSpace(errs))
            {
                Helper.MessageBoxError(errs);
                return false;
            }

            if (models.oblgtnRqstModel.Id == 0)
                return BudgetFactory.ObligationRequestRepository().Insert(models.oblgtnRqstModel, models.oblgtnAccModels);
            else
                return BudgetFactory.ObligationRequestRepository().Update(models.oblgtnRqstModel, models.oblgtnAccModels);
        }

        private void btnCrudSubmit_Click(object sender, EventArgs e)
        {
            var models = ucObligationsCrud.ObligationRequestModels();

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

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnReview);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((string srchKey, ObligationRequestModel.Status status, DateTime dtFrom, DateTime dtTo, int rowLimit))e.Argument;

            var service = new OmniGov.App.Budget.Services.ObligationService();
            e.Result = service.GetObligationRequests(
                parameters.srchKey,
                parameters.status,
                parameters.dtFrom,
                parameters.dtTo,
                parameters.rowLimit,
                (current, total) => Helper.ProgressCounter(backgroundWorker1, total, current)
            );
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is DataTable dataTable)
            {
                if (dataTable.Rows.Count < 1) pbLoadRecords.Value = 100;
                HelperLoadRecords.DgvOblgtnRqst(dataTable, dgvMain);
                dgvMain.CurrentCell = dgvMain.FirstDisplayedCell;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTxt = txtSearch.Text.Trim();

            if (searchTxt.Length > 3 || searchTxt.Length < 1)
                LoadOblgtnRecords();
        }

        private void radPending_CheckedChanged(object sender, EventArgs e)
        {
            LoadOblgtnRecords();
        }

        private void radApproved_CheckedChanged(object sender, EventArgs e)
        {
            LoadOblgtnRecords();
        }

        private void radDisapproved_CheckedChanged(object sender, EventArgs e)
        {
            LoadOblgtnRecords();
        }

        private void radCancelled_CheckedChanged(object sender, EventArgs e)
        {
            LoadOblgtnRecords();
        }

        private void dtPckrFrom_ValueChanged(object sender, EventArgs e)
        {
            dtPckrTo.MinDate = dtPckrFrom.Value;
            LoadOblgtnRecords();
        }

        private void dtPckrTo_ValueChanged(object sender, EventArgs e)
        {
            LoadOblgtnRecords();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirm("Are you sure you want to approve this Obligation Request?"))
            {
                if (ucObligationsAudit.Approve())
                {
                    Helper.MessageBoxSuccess("Obligation Request has been approved.");
                    customTabControl1.SelectedTab = tbPgMain;
                    LoadOblgtnRecords();
                }
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirm("Are you sure you want to disapprove this Obligation Request?"))
            {
                if (ucObligationsAudit.Disapprove())
                {
                    Helper.MessageBoxSuccess("Obligation Request has been disapproved.");
                    customTabControl1.SelectedTab = tbPgMain;
                    LoadOblgtnRecords();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirm("Are you sure you want to cancel this Obligation Request?"))
            {
                if (ucObligationsAudit.Cancel())
                {
                    Helper.MessageBoxSuccess("Obligation Request has been cancelled.");
                    customTabControl1.SelectedTab = tbPgMain;
                    LoadOblgtnRecords();
                }
            }
        }
    }
}