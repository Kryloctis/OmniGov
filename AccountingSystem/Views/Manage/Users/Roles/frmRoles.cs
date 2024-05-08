using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRoles, true);
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            try
            {
                HelperLoadRecords.RowFilterCombobox(cmbxRowLimit);
                LoadRoles();
                Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void LoadRoleAccess(byte roleId)
        {
            lstboxAuthorize.DataSource = AccFactory.RoleHasPermissionsRepository().GetRecordsByRoleId(roleId);
            lstboxAuthorize.DisplayMember = "permission_name";
            lstboxAuthorize.ValueMember = "permissions_id";
        }

        private void dgRoles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgRoles.SelectedRows.Count == 1)
                {
                    var rowIndex = dgRoles.CurrentRow.Index;
                    LoadRoleAccess(Convert.ToByte(dgRoles.Rows[rowIndex].Cells["id"].Value));
                }
                else
                {
                    var dataTable = (DataTable)lstboxAuthorize.DataSource;
                    dataTable.Rows.Clear();
                    lstboxAuthorize.Refresh();
                }

                byte[] columnIndexTimestamp = { 3, 4 };
                Helper.ShowRecordTimestamp(dgRoles, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgRoles, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRolesAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                byte roleId = byte.Parse(dgRoles.SelectedCells[0].Value.ToString());
                _ = new frmRolesEdit(this, roleId).ShowDialog();
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
                    byte roleId = Convert.ToByte(row.Cells[0].Value.ToString());
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
                    LoadRoles();
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

        private void searchTstripBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
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
                string searchKey = searchTstripTxtbx.Text.Trim();

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

                foreach (DataRow dataRow in dbDataTable.Rows)
                {
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dbDataTable;
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

                HelperLoadRecords.RolesDatagridView(dataTable, dgRoles);
                dgRoles.CurrentCell = dgRoles.FirstDisplayedCell;
                lblRecordCount.Text = dgRoles.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}