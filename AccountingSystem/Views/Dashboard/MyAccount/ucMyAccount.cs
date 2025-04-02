using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.MyAccount
{
    public partial class ucMyAccount : UserControl
    {
        private byte rolesId;
        private frmMain frmMain;
        private frmSignIn frmSignIn;

        public ucMyAccount()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtUserName),
                errorProvider1.GetError(txtCurrentPassword),
                errorProvider1.GetError(txtNewPassword),
                errorProvider1.GetError(txtProfileCurrentPassword),
                errorProvider1.GetError(txtConfirmPassword),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        private void ResetForm(object sender)
        {
            if (sender == btnProfileCancel)
            {
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
                txtLastName.Clear();
                txtUserName.Clear();
                txtPrefix.Clear();
                txtSuffix.Clear();
                txtProfileCurrentPassword.Clear();
                LoadCurrentUserAccount();
            }
            if (sender == btnSecurityCancel)
            {
                txtCurrentPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }

            errorProvider1.Clear();
        }

        internal void OnLoad(frmMain frmMain, frmSignIn frmSignIn)
        {
            try
            {
                LoadCurrentUserAccount();
                LoadListOfPermissions();
                this.frmMain = frmMain;
                this.frmSignIn = frmSignIn;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadListOfPermissions()
        {
            byte userRoleId = rolesId;
            var permissions = AccFactory.RoleHasPermissionsRepository()
                                        .GetRecordsByRoleId(userRoleId)
                                        .AsEnumerable()
                                        .Select(dtRowPermissions => $"• {dtRowPermissions["permission_name"]}")
                                        .ToList();

            txtRolePermissions.Text = string.Join("\n", permissions);
        }

        private void LoadCurrentUserAccount()
        {
            var dictUserData = Helper.LoggedInUserData();

            rolesId = Convert.ToByte(dictUserData["roles_id"]);
            txtFirstName.Text = dictUserData["first_name"];
            txtMiddleInitial.Text = dictUserData["mid_initial"];
            txtLastName.Text = dictUserData["last_name"];
            txtPrefix.Text = dictUserData["prefix"];
            txtSuffix.Text = dictUserData["suffix"];
            txtUserName.Text = dictUserData["username"];
            lblUserFullName.Text = dictUserData["user_full_name"].Trim();
            lblUserDesignation.Text = dictUserData["role_name"];
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateProfile())
                {
                    Helper.MessageBoxSuccess("Account Profile Updated.");
                    ResetForm(btnProfileCancel);
                    LoadCurrentUserAccount();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void AccountProfileValidation(bool validate)
        {
            errorProvider1.Clear();

            txtUserName.CausesValidation = !validate;
            txtCurrentPassword.CausesValidation = !validate;
            txtNewPassword.CausesValidation = !validate;
            txtConfirmPassword.CausesValidation = !validate;

            txtFirstName.CausesValidation = validate;
            txtMiddleInitial.CausesValidation = validate;
            txtLastName.CausesValidation = validate;
            txtProfileCurrentPassword.CausesValidation = validate;
        }

        private bool UpdateProfile()
        {
            AccountProfileValidation(true);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Are you sure you want update account profile?"))
            {
                var userModel = new UsersModel()
                {
                    Id = Helper.userId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Prefix = txtPrefix.Text.Trim(),
                    Suffix = txtSuffix.Text.Trim(),
                    MidInitial = txtMiddleInitial.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    RoleId = rolesId
                };
                return AccFactory.UsersRepository().Update(userModel);
            }

            return false;
        }

        private void btnUpdateAccountSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateAccountSecurity())
                {
                    Helper.MessageBoxSuccess("Account Security Updated. Please log in with your new password to continue.");
                    ResetForm(btnSecurityCancel);
                    frmMain.Close();
                    frmSignIn.Show();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateAccountSecurity()
        {
            AccountProfileValidation(false);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            if (Helper.MessageBoxConfirmCancel("Are you sure you want to update your account security details?"))
            {
                var userModel = new UsersModel()
                {
                    Id = Helper.userId,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Prefix = txtPrefix.Text,
                    Suffix = txtSuffix.Text,
                    MidInitial = txtMiddleInitial.Text,
                    UserName = txtUserName.Text,
                    Password = txtNewPassword.Text.Trim(),
                    RoleId = rolesId
                };

                return AccFactory.UsersRepository().UpdateWithPassword(userModel);
            }

            return false;
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "First Name.");
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "Last Name.");
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CurrentPasswordValidation(txtCurrentPassword);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool CurrentPasswordValidation(TextBox txtBoxCurrentPassowrd)
        {
            bool isValid;
            string currentPassword = txtBoxCurrentPassowrd.Text.Trim();
            string userName = txtUserName.Text.Trim();

            byte userId = AccFactory.UsersRepository().ValidateLogin(userName, currentPassword);

            isValid = !Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBoxCurrentPassowrd, "Current Password.") && !(userId == 0);
            errorProvider1.SetError(txtBoxCurrentPassowrd, (userId == 0) ? "Current password is incorrect." : errorProvider1.GetError(txtBoxCurrentPassowrd));

            return isValid;
        }

        private void txtOldPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCurrentPassword);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtNewPassword, "New Password.");
        }

        private void txtNewPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtNewPassword);
        }

        private bool PasswordMatch()
        {
            bool isValid;
            bool passwordMatch = txtNewPassword.Text.Trim() == txtConfirmPassword.Text.Trim();

            isValid = !Helper.ShowErrorTextBoxEmpty(errorProvider1, txtConfirmPassword, "Confirm Password.") && passwordMatch;
            errorProvider1.SetError(txtConfirmPassword, !passwordMatch ? "Password doesn't match." : errorProvider1.GetError(txtConfirmPassword));

            return isValid;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !PasswordMatch();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtConfirmPassword);
        }

        private void txtProfileCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CurrentPasswordValidation(txtProfileCurrentPassword);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtProfileCurrentPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtProfileCurrentPassword);
        }

        private void btnProfileCancel_Click(object sender, EventArgs e)
        {
            ResetForm(sender);
        }

        private void btnSecurityCancel_Click(object sender, EventArgs e)
        {
            ResetForm(sender);
        }
    }
}