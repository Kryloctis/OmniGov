using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users.Roles
{
    public partial class ucRoles : UserControl
    {
        private int roleId;
        private bool isEdit;

        public ucRoles()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epName.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal RolesModel RolesModel()
        {
            var selectedIds = chkBxPermissions.CheckedItems
           .Cast<KeyValuePair<int, string>>()
           .Select(item => item.Key)
           .ToList();

            var permissionModels = selectedIds
                .Select(id => new PermissionsModel { Id = (byte)id })
                .ToList();

            var model = new RolesModel();

            if (isEdit)
            {
                model.Id = roleId;
            }

            model.RoleName = txtName.Text.Trim();
            model.PermissionsModels = permissionModels;

            return model;
        }

        private void LoadSelectedRole()
        {
            var roleDict = Factory.RolesRepository().GetRecordByID(roleId);
            var rolePermissionIds = Factory.RolesPermissionsRepository()
                                    .GetViewRecordsByRoleId(roleId)
                                    .AsEnumerable()
                                    .Select(row => Convert.ToInt32(row["permissions_id"]))
                                    .ToList();

            txtName.Text = roleDict["role_name"];

            for (int i = 0; i < chkBxPermissions.Items.Count; i++)
            {
                var item = (KeyValuePair<int, string>)chkBxPermissions.Items[i];
                if (rolePermissionIds.Contains(item.Key))
                {
                    chkBxPermissions.SetItemChecked(i, true);
                }
            }
        }

        internal void OnLoad(bool isEdit, byte? roleId = null)
        {
            epName.Clear();
            this.isEdit = isEdit;
            LoadPermissions();

            if (isEdit)
            {
                this.roleId = roleId.Value;
                LoadSelectedRole();
            }
            UpdateCheckedCountLabel(chkBxPermissions, lblPermissions);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        internal void ResetForm()
        {
            txtName.Clear();
            LoadPermissions();
        }

        internal void LoadPermissions()
        {
            var dtPermissions = Factory.PermissionsRepository().GetRecords();

            chkBxPermissions.Items.Clear(); // Clear any existing items
            chkBxPermissions.DisplayMember = "Value"; // Display the permission name

            foreach (DataRow row in dtPermissions.Rows)
            {
                var item = new KeyValuePair<int, string>(
                    Convert.ToInt32(row["id"]),
                    row["permission_name"].ToString()
                );

                chkBxPermissions.Items.Add(item, false); // unchecked by default
            }
        }

        private bool NameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string roleName = txtName.Text.Trim();

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Name"))
                return false;
            else if (isEdit ? Factory.RolesRepository().NameExist(roleName, roleId) : Factory.RolesRepository().NameExist(roleName))
            {
                errorProvider.SetError(textBox, "Role name already exist");
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

        private void UpdateCheckedCountLabel(CheckedListBox checkedListBox, Label label)
        {
            int total = checkedListBox.Items.Count;
            int checkedCount = checkedListBox.CheckedItems.Cast<object>().Count();

            label.Text = $"Permissions ({checkedCount}/{total}):";
        }

        private void chkBxPermissions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    UpdateCheckedCountLabel(chkBxPermissions, lblPermissions);
                }));
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chkBxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var isAllCheck = chkBxSelectAll.Checked;

                for (int i = 0; i < chkBxPermissions.Items.Count; i++)
                {
                    chkBxPermissions.SetItemChecked(i, isAllCheck);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

