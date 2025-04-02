using ACC.Data;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.Roles
{
    public partial class frmRolesAdd : Form
    {
        private frmRoles frmRoles;
        private ucRoles uc;

        public frmRolesAdd(frmRoles frmRoles)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmRoles = frmRoles;
            uc = ucRoles1;
        }

        private void frmRolesAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }
            return AccFactory.RolesRepository().Insert(uc.RolesModel());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Role has been saved.");
                    frmRoles.LoadRoles();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRolesAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Role has been saved.");
                        frmRoles.LoadRoles();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}