using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class frmUsersEdit : Form
    {
        private frmUsers frmUsers;
        private ucUsers uc;
        private int userId;

        public frmUsersEdit(frmUsers frmUsers, int userId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmUsers = frmUsers;
            uc = ucUsers1;
            this.userId = userId;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var userModel = new UsersModel()
            {
                Id = userId,
                UserName = uc.txtUsername.Text.Trim(),
                Password = uc.txtPassword.Text.Trim(),
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstname.Text.Trim(),
                MidInitial = uc.txtMiddleInitial.Text.Trim(),
                LastName = uc.txtLastname.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                RoleId = (byte)uc.cmbRoles.SelectedValue,
            };

            if (string.IsNullOrWhiteSpace(uc.txtPassword.Text))
                return AccFactory.UsersRepository().Update(userModel);
            else
                return AccFactory.UsersRepository().UpdateWithPassword(userModel);
        }

        private void frmUsersEdit_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, userId);
                uc.txtUsername.ReadOnly = true;
                uc.lblPassword.Text = "New Password";
                uc.lblConfirmPassword.Text = $"Confirm New{Environment.NewLine}Password";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("User has been updated.");
                    frmUsers.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmUsersEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("User has been updated.");
                        frmUsers.LoadRecords();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}