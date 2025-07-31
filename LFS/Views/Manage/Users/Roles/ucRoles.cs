using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        private byte roleId;
        private bool isEdit;

        public ucRoles()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPermissions, true, false);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epName.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal RolesModel RolesModel()
        {
            DataTable dtPermissions = (DataTable)dgPermissions.DataSource;
            var permissionModels = dtPermissions.AsEnumerable().Where(row => (bool)row["is_checked"] == true).Select(row => new PermissionsModel { Id = Convert.ToByte(row["id"]) }).ToList();

            return new RolesModel()
            {
                RoleName = txtName.Text.Trim(),
                PermissionsModels = permissionModels,
            };
        }

        private void LoadSelectedRole()
        {
            var roleDict = AccFactory.RolesRepository().GetRecordByID(roleId);
            txtName.Text = roleDict["role_name"];
        }

        internal void OnLoad(bool isEdit, byte? roleId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.roleId = roleId.Value;
                LoadSelectedRole();
            }

            LoadPermissions();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            LoadPermissions();
        }

        internal void LoadPermissions()
        {
            var dtPermissions = AccFactory.PermissionsRepository().GetRecords();
            var dataTable = new DataTable();
            var dataColumns = new DataColumn[]
            {
                new DataColumn("is_checked", typeof(bool)),
                new DataColumn("id", typeof(int)),
                new DataColumn("permission_name", typeof(string)),
            };
            dataTable.Columns.AddRange(dataColumns);

            foreach (DataRow dataRow in dtPermissions.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["is_checked"] = false;
                newRow["id"] = dataRow["id"];
                newRow["permission_name"] = dataRow["permission_name"];
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.RolesPermissionsDataGridView(dataTable, dgPermissions);
        }

        private bool NameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string roleName = txtName.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Name"))
                return false;
            else if (isEdit ? AccFactory.RolesRepository().NameExist(roleName, roleId) : AccFactory.RolesRepository().NameExist(roleName))
            {
                errorProvider.SetError(textBox, "Role name already exist in this office.");
                return false;
            }
            return true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !NameValidated(epName, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}