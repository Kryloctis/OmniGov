using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        internal byte roleId = 0;

        public ucRoles()
        {
            InitializeComponent();
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
            dgPermissionGranted.Rows.Clear();
            LoadPermissions();
        }

        private bool AuthorizedPermissionExist(string permissionId)
        {
            foreach (DataGridViewRow row in dgPermissionGranted.Rows)
            {
                if (permissionId == row.Cells["id"].Value.ToString())
                    return true;
            }

            return false;
        }

        internal void LoadPermissions()
        {
            try
            {
                dgPermissions.DataSource = null;
                dgPermissions.Rows.Clear();

                var dtPermissions = new DataTable();
                var userDict = Helper.LoggedInUserData();
                string office = cmbOffice.Text;

               dtPermissions = Factory.PermissionsRepository().GetRecordsByOffice(office);

                foreach (DataRow row in dtPermissions.Rows)
                {
                    string permissionId = row["id"].ToString();
                    string permissionName = row["permission_name"].ToString();

                    if (AuthorizedPermissionExist(permissionId)) continue;

                    dgPermissions.Rows.Add(new string[] { permissionId, permissionName });
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadOffice()
        {
            cmbOffice.SelectedValueChanged -= new EventHandler(CmbxOffice_SelectedValueChanged);

            var userDict = Helper.LoggedInUserData();
            switch (userDict["office"])
            {
                case "SysAdmin":
                    cmbOffice.Items.AddRange(new string[] { "Budget", "Accounting", "Treasury" });
                    break;
                default:
                    cmbOffice.Items.Add(userDict["office"]);
                    break;
            }

            cmbOffice.SelectedIndex = 0;

            cmbOffice.SelectedValueChanged += new EventHandler(CmbxOffice_SelectedValueChanged);
        }

        private void CmbxOffice_SelectedValueChanged(object sender, EventArgs e)
        {
            dgPermissionGranted.Rows.Clear();
            LoadPermissions();
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
            string office = cmbOffice.Text;
            bool roleNameExist;

            if (roleId == 0)
                roleNameExist = rolesRepository.NameExist(roleName, office); // add form
            else
                roleNameExist = rolesRepository.NameExist(roleName, office, roleId); // edit form

            if (roleNameExist)
            {
                epName.SetError(txtName, "Role name already exist in this office.");
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
            foreach (DataGridViewRow row in dgPermissions.SelectedRows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissionGranted);
            }

            foreach (DataGridViewRow row in dgPermissions.SelectedRows)
            {
                RemovePermission(row, dgPermissions);
            }
        }

        private void btnDenyPermission_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPermissionGranted.SelectedRows)
            {
                string permissionId = row.Cells["id"].Value.ToString();
                string permissionName = row.Cells["permission_name"].Value.ToString();
                AddPermission(permissionId, permissionName, dgPermissions);
            }

            foreach (DataGridViewRow row in dgPermissionGranted.SelectedRows)
            {
                RemovePermission(row, dgPermissionGranted);
            }
        }
    }
}
