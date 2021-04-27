using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        internal int roleId = 0;

        public ucRoles()
        {
            InitializeComponent();
            cmbOffice.SelectedIndex = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = epName.GetError(txtName);

            var _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
        }

        internal void CreateDatagridViewColumns(DataGridView datagrid)
        {
            datagrid.ColumnCount = 2;
            datagrid.Columns[0].Name = "id";
            datagrid.Columns[0].Visible = false;
            datagrid.Columns[1].Name = "permission_name";
            datagrid.Columns[1].HeaderText = "Permission";

            datagrid.RowHeadersVisible = false;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "role name");

            var rolesRepository = Factory.RolesRepository();
            string roleName = txtName.Text.Trim();
            bool roleNameExist;

            if (roleId == 0)
                roleNameExist = rolesRepository.NameExist(roleName); // add form
            else
                roleNameExist = rolesRepository.NameExist(roleName, roleId); // edit form

            if (roleNameExist)
            {
                epName.SetError(txtName, "Role name already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void ucRoles_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgPermissions);
            Helper.DatagridDefaultStyle(dgPermissionGranted);
            CreateDatagridViewColumns(dgPermissions);
            CreateDatagridViewColumns(dgPermissionGranted);
        }

        private void dgPermissions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPermissions.SelectedRows.Count > 0)
            {
                btnGrantPermission.Enabled = true;
                btnGrantAllPermissions.Enabled = true;
                return;
            }

            btnGrantPermission.Enabled = false;
            btnGrantAllPermissions.Enabled = false;
        }

        private void dgPermissionGranted_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPermissionGranted.SelectedRows.Count > 0)
            {
                btnDenyPermission.Enabled = true;
                btnDenyAllPermissions.Enabled = true;
                return;
            }

            btnDenyPermission.Enabled = false;
            btnDenyAllPermissions.Enabled = false;
        }

        private void AddPermission(string permissionId, string permissionName, DataGridView datagrid)
        {
            _ = datagrid.Rows.Add(new string[] { permissionId, permissionName });
        }

        private void RemovePermission(DataGridViewRow row, DataGridView datagrid)
        {
            datagrid.Rows.Remove(row);
        }

        private void RemoveAllPermissions(DataGridView datagrid)
        {
            datagrid.Rows.Clear();
        }

        private void btnGrantAllPermissions_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPermissions.Rows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissionGranted);
            }

            RemoveAllPermissions(dgPermissions);
        }

        private void btnDenyAllPermissions_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPermissionGranted.Rows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissions);
            }

            RemoveAllPermissions(dgPermissionGranted);
        }

        private void btnGrantPermission_Click(object sender, EventArgs e)
        {
            // add permission to dgPermissionGranted
            foreach (DataGridViewRow row in dgPermissions.SelectedRows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissionGranted);
            }

            // remove the permission from dgPermissions
            foreach (DataGridViewRow row in dgPermissions.SelectedRows)
            {
                RemovePermission(row, dgPermissions);
            }
        }

        private void btnDenyPermission_Click(object sender, EventArgs e)
        {
            // add permission to dgPermissionGranted
            foreach (DataGridViewRow row in dgPermissionGranted.SelectedRows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissions);
            }

            // remove the permission from dgPermissions
            foreach (DataGridViewRow row in dgPermissionGranted.SelectedRows)
            {
                RemovePermission(row, dgPermissionGranted);
            }
        }
    }
}
