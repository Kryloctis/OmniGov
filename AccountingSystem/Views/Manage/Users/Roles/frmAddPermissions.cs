using ACC.Domain.Models;
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
    public partial class frmAddPermissions : Form
    {
        private frmRoles _frmRoles;
        public static int getroleId;
        

        public frmAddPermissions(frmRoles frmRoles, int roleId)
        {
            InitializeComponent();
            _frmRoles = frmRoles;
            getroleId = roleId;
            
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucPermissions1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var permissionsModel = new PermissionsModel()
                {

                    Id = ((byte)uc.cmbPermissions.SelectedValue),
                    currentRole = (getroleId),
                    

                };

                var permissionsRepository = Factory.PermissionsRepository();
                return permissionsRepository.Insert(permissionsModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }





        private void frmAddPermissions_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucPermissions1.LoadPermissions();
            ucPermissions1.LoadAddedPermissions();
            //ucPermissions1.LoadAddedPermissions(getroleId);



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Permission added.");
                //ucPermissions1.ResetForm();
                ucPermissions1.LoadAddedPermissions();

            }
        }
    }
}
