using ACC.Data;
using LFS.Views.Manage.Users.List;
using LFS;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users.Roles
{
    public partial class frmRolesEdit : Form
    {
        private frmRoles frmRoles;
        private byte roleId;
        private ucRoles uc;

        public frmRolesEdit(frmRoles frmRoles, byte roleId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucRoles1;
            this.roleId = roleId;
            this.frmRoles = frmRoles;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var model = uc.RolesModel();
            model.Id = roleId;

            return AccFactory.RolesRepository().Update(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Role has been saved.");
                    frmRoles.LoadRoles();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRolesEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, roleId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRolesEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Role has been saved.");
                        frmRoles.LoadRoles();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}