using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Registry;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsersAdd : Form
    {
        private frmUsers frmUsers;
        private ucUsers uc;

        public frmUsersAdd(frmUsers frmUsers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmUsers = frmUsers;
            uc = ucUsers1;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var userModel = new UsersModel()
            {
                RoleId = ((byte)uc.cmbRoles.SelectedValue),
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstname.Text.Trim(),
                MidInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastname.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                UserName = uc.txtUsername.Text.Trim(),
                Password = uc.txtPassword.Text.Trim(),
            };

            return AccFactory.UsersRepository().Insert(userModel);
        }

        private void frmUsersAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("User has been saved.");
                    frmUsers.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmUsersAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("User has been saved.");
                        frmUsers.LoadRecords();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}