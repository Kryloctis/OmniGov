using ACC.Data;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.MyAccount
{
    public partial class ucMyAccount : UserControl
    {
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
            LoadCurrentUserAccount();
        }

        private void LoadCurrentUserAccount()
        {

            var dictUserData = Helper.LoggedInUserData();


            txtFirstName.Text = dictUserData["first_name"];
            txtMiddleName.Text = dictUserData["mid_initial"];
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
            UpdateProfile();
        }

        private void UpdateProfile()
        {
        }

        private void btnUpdateAccountSec_Click(object sender, EventArgs e)
        {
            UpdateAccountSecurity();
        }

        private void UpdateAccountSecurity()
        {
        }

    }
}
