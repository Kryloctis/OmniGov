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
                errorProvider1.GetError(txtOldPassword),
                errorProvider1.GetError(txtNewPassword),
                errorProvider1.GetError(txtConfirmPassword),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad()
        {
            try
            {
                LoadCurrentUserAccount();
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
                    LoadCurrentUserAccount();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void AccountValidationOnly(bool validate)
        {
            txtUserName.CausesValidation = !validate;
            txtOldPassword.CausesValidation = !validate;
            txtNewPassword.CausesValidation = !validate;
            txtConfirmPassword.CausesValidation = !validate;


            txtFirstName.CausesValidation = validate;
            txtMiddleInitial.CausesValidation = validate;
            txtLastName.CausesValidation = validate;

        }

        private bool UpdateProfile()
        {
            AccountValidationOnly(true);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

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

        private void btnUpdateAccountSec_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateAccountSecurity())
                {
                    Helper.MessageBoxSuccess("Account Security Updated.");

                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateAccountSecurity()
        {
            AccountValidationOnly(false);

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtOldPassword, "Old Password.");
        }

        private void txtOldPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtOldPassword);
        }

        private void txtNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtNewPassword, "New Password.");
        }

        private void txtNewPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtNewPassword);
        }

        private bool PasswordMatchValidation()
        {
            bool isValidated;
            bool passwordMatch = txtNewPassword.Text.Trim() == txtConfirmPassword.Text.Trim();

            isValidated = !Helper.ShowErrorTextBoxEmpty(errorProvider1, txtConfirmPassword, "Confirm Password.") && !passwordMatch;
            errorProvider1.SetError(txtConfirmPassword, passwordMatch ? "Password doesn't match." : errorProvider1.GetError(txtConfirmPassword));

            return !isValidated;

        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !PasswordMatchValidation();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtConfirmPassword, "Confirm Password.");
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtConfirmPassword);
        }

        private void btnPasswordVisibility_Click(object sender, EventArgs e)
        {
            ShowHidePassword(txtOldPassword, btnOldPasswordVisibility);
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
                    buttonVisibility.Image = invisibleImage;
                    textBox.PasswordChar = default(char);
                }
                else
                {
                    buttonVisibility.Image = visibleImage;
                    textBox.PasswordChar = '•';
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


    }
}
