using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users.Roles
{
    public partial class frmRoles : Form
    {
        private bool isEdit;
        private ucRoles uc;

        public frmRoles()
        {
            InitializeComponent();
            uc = ucRoles1;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRoles, true, true, false, false);
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRoles();
                Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleCrud(bool isEdit)
        {
            this.isEdit = isEdit;

            if (this.isEdit)
            {
                int rowIndex = dgRoles.CurrentRow.Index;
                bool isValid = sbyte.TryParse(dgRoles.Rows[rowIndex].Cells["id"].Value.ToString(), out sbyte roleId);

                lblTitle.Text = "Update Role";

                if (isValid)
                    uc.OnLoad(true, (byte)roleId);
            }
            else
            {
                lblTitle.Text = "Create Role";
                uc.OnLoad(false);
                uc.ResetForm();
            }

            customTabControl1.SelectedTab = tbPgCrud;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCrud(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgRoles.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var rolesModelList = new List<RolesModel>();
                foreach (DataGridViewRow row in dgRoles.SelectedRows)
                {
                    byte roleId = Convert.ToByte(row.Cells["id"].Value.ToString());
                    rolesModelList.Add(new RolesModel() { Id = roleId });
                }

                return AccFactory.RolesRepository().Delete(rolesModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxSuccess($"{dgRoles.SelectedRows.Count} record/s has been deleted");
                    LoadRoles();
                }
            }
            catch (MySqlException mysqlEx)
            {
                switch (mysqlEx.Number)
                {
                    case 1451:
                        Helper.MessageBoxError("Can't delete role, The role was referenced to a user.");
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRoles()
        {
            if (!backgroundWorker1.IsBusy)
            {
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                string searchKey = txtSearch.Text.Trim();
                progressBar1.Value = 0;

                backgroundWorker1.RunWorkerAsync((rowLimit, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int rowLimit, string searchKey))e.Argument;
                var dbDataTable = AccFactory.RolesRepository().GetRecords(parameters.rowLimit, parameters.searchKey);
                int totalProgressCount = dbDataTable.Rows.Count;
                int progressCount = 0;

                var dataTable = new DataTable();
                var dataColumns = new DataColumn[]
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("role_name", typeof(string)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("updated_at", typeof(string))
                };
                dataTable.Columns.AddRange(dataColumns);

                foreach (DataRow dataRow in dbDataTable.Rows)
                {
                    var newRow = dataTable.NewRow();

                    byte roleId = Convert.ToByte(dataRow["id"]);
                    newRow["id"] = roleId;
                    newRow["role_name"] = dataRow["role_name"];
                    newRow["created_at"] = dataRow["created_at"];
                    newRow["updated_at"] = dataRow["updated_at"];

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                HelperLoadRecords.DgvRoles(dataTable, dgRoles);
                dgRoles.CurrentCell = dgRoles.FirstDisplayedCell;
                lblRecordCount.Text = dgRoles.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgRoles.SelectedRows.Count == 1)
                {
                    int rowIndex = dgRoles.CurrentRow.Index;
                    bool isValidRoleId = int.TryParse(dgRoles.Rows[rowIndex].Cells["id"].Value.ToString(), out int roleId);

                    if (isValidRoleId)
                    {
                        var permissions = LoadPrivileges(roleId);
                        rchTxtBxPrivileges.Text = permissions;
                    }
                }

                Helper.ShowRecordTimestampMod(dgRoles, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string LoadPrivileges(int? roleId)
        {
            if (roleId is null) return string.Empty;
            var dtRolePermissions = AccFactory.RolesPermissionsRepository().GetViewRecordsByRoleId(roleId.Value);
            var sb = new StringBuilder();

            foreach (DataRow dataRow in dtRolePermissions.Rows)
                sb.AppendLine($"- {dataRow["permission_name"]}");

            if (sb.Length < 1) sb.AppendLine("- No Privileges");

            return sb.ToString();
        }

        private void TogglePreviewPermissions()
        {
            switch (splitContainer1.Panel2Collapsed)
            {
                case true:
                    splitContainer1.Panel2Collapsed = false;
                    btnShowSidePanel.Text = "✕";
                    break;

                case false:
                    splitContainer1.Panel2Collapsed = true;
                    btnShowSidePanel.Text = "☰";
                    break;
            }
        }

        private void btnShowSidePanel_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePreviewPermissions();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void SaveRole(bool isEdit)
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return;
            }

            bool isSaved = isEdit ?
                AccFactory.RolesRepository().Update(uc.RolesModel()) :
                AccFactory.RolesRepository().Insert(uc.RolesModel());

            if (isSaved)
            {
                uc.ResetForm();
                LoadRoles();

                if (isEdit)
                {
                    customTabControl1.SelectedTab = tbPgList;
                    Helper.MessageBoxSuccess("Role has been updated");
                }
                else
                {
                    Helper.MessageBoxSuccess("Role has been saved");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveRole(isEdit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                customTabControl1.SelectedTab = tbPgList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}