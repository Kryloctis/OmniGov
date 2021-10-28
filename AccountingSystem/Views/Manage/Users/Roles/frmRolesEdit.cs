using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class frmRolesEdit : Form
    {
        private frmRoles _frmRoles;
        private ucRoles uc;

        public frmRolesEdit(frmRoles frmRoles, byte roleId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucRoles1;
            _frmRoles = frmRoles;
            uc.roleId = roleId;
        }

        private void LoadSelectedRole()
        {
            try
            {
                var rolesRepository = Factory.RolesRepository();
                var roleDict = rolesRepository.GetRecordByID(uc.roleId);


                uc.cmbOffice.Text = roleDict["office"];
                uc.txtName.Text = roleDict["role_name"];
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadPermissionsByRoleId()
        {
            var dtRolesHasPermissions = Factory.RoleHasPermissionsRepository().GetRecordsByRoleId(uc.roleId);
            foreach (DataRow row in dtRolesHasPermissions.Rows)
            {
                string permissionId = row["permissions_id"].ToString();
                string permissionName = row["permission_name"].ToString();
                uc.dgPermissionGranted.Rows.Add(new string[] { permissionId, permissionName });
            }
        }

        private bool SaveData()
        {
            try
            {
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // if no permission has been granted
                if (uc.dgPermissionGranted.SelectedRows.Count == 0)
                {
                    Helper.MessageBoxError("Please select at least one permission.");
                    return false;
                }

                // get all the selected permissions
                var permissionModelList = new List<PermissionsModel>();
                foreach (DataGridViewRow row in uc.dgPermissionGranted.Rows)
                {
                    permissionModelList.Add(new PermissionsModel() { Id = Convert.ToByte(row.Cells["id"].Value) });
                }

                // proceed to update
                var roleModel = new RolesModel()
                {
                    Id = uc.roleId,
                    Office = uc.cmbOffice.Text,
                    RoleName = uc.txtName.Text.Trim(),
                    PermissionsModels = permissionModelList
                };

                return Factory.RolesRepository().Update(roleModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Role has been saved.");
                _frmRoles.LoadRoles();
            }
        }

        private void frmRolesEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadOffice();
            LoadSelectedRole();
            LoadPermissionsByRoleId();
            uc.LoadPermissions();
         
        }
    }
}
