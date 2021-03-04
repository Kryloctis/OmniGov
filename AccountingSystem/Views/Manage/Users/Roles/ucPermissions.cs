using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class ucPermissions : UserControl
    {
        int getroleId = 0;
        
        public ucPermissions()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = epPermissions.GetError(cmbPermissions);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbPermissions.SelectedIndex = -1;

        }
        internal void LoadPermissions()
        {
            try
            {
                DataTable dtPermissionsName = Factory.PermissionsRepository().GetRecords();
                HelperLoadRecords.PermissionsComboBox(dtPermissionsName, cmbPermissions, "permission_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


      /*  internal void LoadAddedPermissions(int getroleId)
        {
            try
            {
                var permissionsRepository = Factory.PermissionsRepository();
                var dtAddedPermissions = permissionsRepository.GetAddedPermissions();
                HelperLoadRecords.AddedPermissionsDatagridView(dtAddedPermissions, dgPermissions);

                
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
      */

        private void cmbPermissions_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epPermissions, cmbPermissions, "permission name");

            int permissionId = Convert.ToByte(cmbPermissions.SelectedValue);
            getroleId =  frmAddPermissions.getroleId;
            int currentRoleId = getroleId;
            bool idExist = Factory.PermissionsRepository().IdExist(permissionId);
            bool PermissionExists = Factory.PermissionsRepository().PermissionExists(permissionId, currentRoleId);

            if (!idExist)
            {
                epPermissions.SetError(cmbPermissions, "Invalid permissions name. Please select on the list.");
                e.Cancel = true;
            }
            else if (PermissionExists)
            {
                epPermissions.SetError(cmbPermissions, "This permission already exists for this user.");
                e.Cancel = true;

            }
            




        }

        private void cmbPermissions_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epPermissions, cmbPermissions);
        }

        
    }
}
