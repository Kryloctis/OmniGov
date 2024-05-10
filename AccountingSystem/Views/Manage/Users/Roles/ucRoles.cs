using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        private byte roleId;
        private bool isEdit;

        public ucRoles()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPermissions, true, false);
            dgPermissions.BorderStyle = BorderStyle.Fixed3D;
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
                Office = cmbxOffice.Text,
                RoleName = txtName.Text.Trim(),
                PermissionsModels = permissionModels,
            };
        }

        private void LoadSelectedRole()
        {
            var roleDict = AccFactory.RolesRepository().GetRecordByID(roleId);
            cmbxOffice.Text = roleDict["office"];
            txtName.Text = roleDict["role_name"];
        }

        internal void OnLoad(bool isEdit, byte? roleId)
        {
            this.isEdit = isEdit;
            LoadOffice();

            if (isEdit)
            {
                this.roleId = roleId.Value;
                LoadSelectedRole();
            }
        }

        internal void ResetForm()
        {
            txtName.Clear();
            LoadOffice();
            LoadPermissions();
        }

        internal void LoadPermissions()
        {
            string office = cmbxOffice.Text;
            var dtPermissions = AccFactory.PermissionsRepository().GetRecordsByOffice(office);
            var dataTable = new DataTable();
            var dataColumns = new DataColumn[]
            {
                new DataColumn("is_checked", typeof(bool)),
                new DataColumn("id", typeof(int)),
                new DataColumn("permission_name", typeof(string)),
            };
            dataTable.Columns.AddRange(dataColumns);

            if (isEdit)
            {
                var dtRolePermissions = AccFactory.RoleHasPermissionsRepository().GetRecordsByRoleId(roleId);
            }

            foreach (DataRow dataRow in dtPermissions.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["is_checked"] = dtPermissions.AsEnumerable().Any(row => Convert.ToInt32(row.Field<byte>("permissions_id")) == Convert.ToInt32(dataRow["id"]));
                newRow["id"] = dataRow["id"];
                newRow["permission_name"] = dataRow["permission_name"];
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.RolesPermissionsDataGridView(dataTable, dgPermissions);
        }

        internal void LoadOffice()
        {
            var userDict = Helper.LoggedInUserData();
            string[] offices;

            switch (userDict["office"])
            {
                case "SysAdmin":
                    offices = new string[] { "Budget", "Accounting", "Treasury" };
                    break;

                default:
                    offices = new string[] { userDict["office"] };
                    break;
            }

            cmbxOffice.DataSource = offices;
        }

        private void CmbxOffice_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPermissions();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool NameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string roleName = txtName.Text.Trim();
            string office = cmbxOffice.Text;

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Name"))
                return false;
            else if (isEdit ? AccFactory.RolesRepository().NameExist(roleName, office, roleId) : AccFactory.RolesRepository().NameExist(roleName, office))
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