using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class frmRolesAdd : Form
    {
        private frmRoles _frmRoles;
        private ucRoles uc;

        public frmRolesAdd(frmRoles frmRoles)
        {
            InitializeComponent();
            _frmRoles = frmRoles;
            uc = ucRoles1;
        }

        internal void LoadPermissions()
        {
            try
            {
                var dtPermissions = Factory.PermissionsRepository().GetRecords();
                foreach (DataRow row in dtPermissions.Rows)
                {
                    string permissionId = row["id"].ToString();
                    string permissionName = row["permission_name"].ToString();
                    uc.dgPermissions.Rows.Add(new string[] { permissionId, permissionName });
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmRolesAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadPermissions();
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

                // proceed to insert
                var permissionModelList = new List<PermissionsModel>();
                foreach (DataGridViewRow row in uc.dgPermissionGranted.Rows)
                {
                    permissionModelList.Add(new PermissionsModel() { Id = Convert.ToByte(row.Cells["id"].Value) });
                }
                var roleModel = new RolesModel()
                {
                    Office = uc.cmbOffice.Text,
                    RoleName = uc.txtName.Text.Trim(),
                    PermissionsModels = permissionModelList
                };

                var rolesRepository = Factory.RolesRepository();
                return rolesRepository.Insert(roleModel);
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
                _frmRoles.LoadRecords();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
