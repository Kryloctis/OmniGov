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
    public partial class frmRolesAdd : Form
    {
        private frmRoles _frmRoles;
        public frmRolesAdd(frmRoles frmRoles)
        {
            InitializeComponent();
            _frmRoles = frmRoles;
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

                // proceed to insert
                var roleModel = new RolesModel()
                {
                    RoleName = uc.txtName.Text.Trim()
                   
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

        private void frmRolesAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Role has been saved.");
                
                _frmRoles.LoadRecords();
                //ucRoles1.ResetForm();

                
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
