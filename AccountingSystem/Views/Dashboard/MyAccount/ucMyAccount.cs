using ACC.Data;
using ACC.Domain.Models;
using System;
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

        private bool UpdateProfile()
        {
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
                RoleId = rolesId
            };
            return AccFactory.UsersRepository().Update(userModel);

        }

        private void btnUpdateAccountSec_Click(object sender, EventArgs e)
        {
            UpdateAccountSecurity();
        }

        private void UpdateAccountSecurity()
        {
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
    }
}
