using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Obligations
{
    public partial class frmObligations : Form
    {
        public frmObligations()
        {
            InitializeComponent();
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAlltmntClss();
                LoadFunds();
                HelperLoadRecords.ComboboxRowLimitFilter(tlStrpCmbxLimit.ComboBox);
                //tlStrpCmbxLimit.ComboBox.SelectionChangeCommitted += (s, ev) => LoadJevRecords();
                MonitorControlChanges(panel1, btnApplyFltr);
                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        private void LoadAlltmntClss()
        {
            var dtAlltmntClss = AccFactory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtAlltmntClss, cmbxAlltmntClss, "id", "allotment_name");
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

        private void ToggleCrud(bool isEdit)
        {
            string crudIndct;

            if (isEdit)
            {
                int rowIndex = dgvMain.CurrentCell.RowIndex;
                int jevId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Update Obligation Request";
            }
            else
            {
                customTabControl1.SelectedTab = tbPgCrud;
                crudIndct = "Create Obligation Request";
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

        private void ToggleView()
        {
            int rowIndex = dgvMain.CurrentCell.RowIndex;
            int jevId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
            //ucobl.OnLoad(true, jevId);
            //ucJevView.SetJevReadOnly(true);
            customTabControl1.SelectedTab = tbPgView;
        }

        private void tlStrpBtnView_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleView();
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

        private void ToggleAudit()
        {
            int rowIndex = dgvMain.CurrentCell.RowIndex;
            int jevId = Convert.ToInt32(dgvMain.Rows[rowIndex].Cells["id"].Value);
            //ucJevAudit.OnLoad(true, jevId);
            //ucJevAudit.SetJevReadOnly(true);
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

        private void btnApplyFltr_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
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
                EnableDisableButtons(dgvMain, tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnAudit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadObligationRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                int rowLimit = Convert.ToInt32(tlStrpCmbxLimit.ComboBox.SelectedValue);

                var parameters = new (string name, object value)[]
                {
                    ("search_key", tlStrpTxtSearch.Text),
                    ("status", GetFltrStatus()),
                    ("allotmnt_class", cmbxAlltmntClss.Text),
                    ("fund", cmbxFunds.Text),
                    ("date_from", dtPckrFrom.Value),
                    ("date_to", dtPckrTo.Value),
                    ("row_limit", rowLimit),
                };
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string srchKey, string status, string alltmntClss, string fund, DateTime dtFrom, DateTime dtTo, int rowLimit))e.Argument;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(new[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("trnsction_no", typeof(string)),
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
                                                                 parameters.status,
                                                                 parameters.alltmntClss,
                                                                 parameters.fund,
                                                                 parameters.dtFrom,
                                                                 parameters.dtTo,
                                                                 parameters.rowLimit);
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
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}