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
    public partial class frmRolesEdit : Form
    {
        private frmRoles _frmRoles;
        public frmRolesEdit(frmRoles frmRoles, int roleId)
        {
            InitializeComponent();
            _frmRoles = frmRoles;
            ucRoles1.roleId = roleId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucRoles1;
                var rolesRepository = Factory.RolesRepository();
                var roleData = rolesRepository.GetRecordByID(uc.roleId);

                uc.txtName.Text = roleData["role_name"];
              
            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucRoles1;


                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to update
                var roleModel = new RolesModel()
                {
                    Id = uc.roleId,
                    RoleName = uc.txtName.Text.Trim(),
                  
                };

                var rolesRepository = Factory.RolesRepository();
                return rolesRepository.Update(roleModel);
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
                ucRoles1.ResetForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmRolesEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }
    }
}
