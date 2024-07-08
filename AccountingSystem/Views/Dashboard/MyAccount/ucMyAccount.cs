using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.MyAccount
{
    public partial class ucMyAccount : UserControl
    {
        byte rolesId;
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
                errorProvider1.GetError(txtConfirmPassword),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        private void ResetForm()
        {
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            txtPrefix.Clear();
            txtSuffix.Clear();
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

        }

        internal void OnLoad(frmMain frmMain, frmSignIn frmSignIn)
        {
            try
            {
                LoadCurrentUserAccount();
                this.frmMain = frmMain;
                this.frmSignIn = frmSignIn;
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        private void ucMyAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {

                if (UpdateProfile())
                {
                    Helper.MessageBoxSuccess("Account Profile Updated.");
                    ResetForm();
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
                    ResetForm();
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

        private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "First Name.");
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "Last Name.");
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtOldPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CurrentPasswordValidation();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool CurrentPasswordValidation()
        {
            bool isValid;
            string currentPassword = txtCurrentPassword.Text.Trim();
            string userName = txtUserName.Text.Trim();

            byte userId = AccFactory.UsersRepository().ValidateLogin(userName, currentPassword);


            isValid = !Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCurrentPassword, "Current Password.") && !(userId == 0);
            errorProvider1.SetError(txtCurrentPassword, (userId == 0) ? "Current password is incorrect." : errorProvider1.GetError(txtCurrentPassword));

            return isValid;

        }

        private void txtOldPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCurrentPassword);

        }

        private void txtNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void btnPasswordVisibility_Click(object sender, EventArgs e)
        {
            ShowHidePassword(txtCurrentPassword, btnOldPasswordVisibility);
        }

        private void btnNewPasswordVisibility_Click(object sender, EventArgs e)
        {
            ShowHidePassword(txtNewPassword, btnNewPasswordVisibility);
        }

        private void btnConfirmPasswordVisibility_Click(object sender, EventArgs e)
        {
            ShowHidePassword(txtConfirmPassword, btnConfirmPasswordVisibility);
        }

        private void ShowHidePassword(TextBox textBox, Button buttonVisibility)
        {
            try
            {
                Image invisibleImage = Properties.Resources.invisible_16px;
                Image visibleImage = Properties.Resources.visible_16px;

                if (textBox.PasswordChar == '•')
                {
                    buttonVisibility.Image = visibleImage;
                    textBox.PasswordChar = default(char);
                }
                else
                {
                    buttonVisibility.Image = invisibleImage;
                    textBox.PasswordChar = '•';
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


    }
}
