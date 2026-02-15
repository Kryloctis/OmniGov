using LFS.Helpers;
using LFS.Properties;
using LFS.Views.SignIn;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.MyAccount
{
    public partial class ucMyAccount : UserControl
    {
        private int rolesId;
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

            return Factory.CreateErrors(errors).GenerateErrorMessage();
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
            var permissions = Factory.RolesPermissionsRepository()
                                        .GetViewRecordsByRoleId(rolesId)
                                        .AsEnumerable()
                                        .Select(dtRowPermissions => $"  -{dtRowPermissions["permission_name"]}")
                                        .ToList();
            var sb = new StringBuilder();

            foreach (var permission in permissions)
                sb.AppendLine(permission.ToString());

            txtPriviledges.Text = sb.ToString();
        }

        private void LoadGreetings(string userName)
        {
            string greeting;

            int hour = DateTime.Now.Hour;

            if (hour < 12)
                greeting = "Good Morning";
            else if (hour < 18)
                greeting = "Good Afternoon";
            else
                greeting = "Good Evening";

            lblGreetings.Text = $"{greeting}!";
        }

        private void LoadCurrentUserAccount()
        {
            rolesId = UserHelper.loggedUser.RoleId.Value;
            txtFirstName.Text = UserHelper.loggedUser.FirstName;
            txtMiddleInitial.Text = UserHelper.loggedUser.MiddleName;
            txtLastName.Text = UserHelper.loggedUser.LastName;
            txtPrefix.Text = UserHelper.loggedUser.Prefix;
            txtSuffix.Text = UserHelper.loggedUser.Suffix;
            txtUserName.Text = UserHelper.loggedUser.UserName;

            var userDesignation = UserHelper.loggedUser.RoleName;
            var userName = UserHelper.loggedUser.FullName;
            LoadGreetings(userName);
            lblPrivileges.Text = $"{userDesignation} Privileges";
            lblUserName.Text = userName;
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
                    Id = UserHelper.loggedUser.Id,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Prefix = txtPrefix.Text.Trim(),
                    Suffix = txtSuffix.Text.Trim(),
                    MidInitial = txtMiddleInitial.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    RoleId = rolesId
                };
                return Factory.UsersRepository().Update(userModel);
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
                    Id = UserHelper.loggedUser.Id,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Prefix = txtPrefix.Text,
                    Suffix = txtSuffix.Text,
                    MidInitial = txtMiddleInitial.Text,
                    UserName = txtUserName.Text,
                    Password = txtNewPassword.Text.Trim(),
                    RoleId = rolesId
                };

                return Factory.UsersRepository().UpdateWithPassword(userModel);
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

            bool userCredIsValid = Factory.UsersRepository().AccIsValidated(userName, currentPassword);

            isValid = !Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBoxCurrentPassowrd, "Current Password.")
                      && !userCredIsValid;

            errorProvider1.SetError(txtBoxCurrentPassowrd, (!userCredIsValid) ? "Current password is incorrect." : errorProvider1.GetError(txtBoxCurrentPassowrd));

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

        private void TogglePanels()
        {
            if (splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
                btnEditAcc.Image = Resources.symbol_cancel_20px;
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
                btnEditAcc.Image = Resources.tool_pencil_filled_20px;
            }
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            try
            {
                TogglePanels();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}