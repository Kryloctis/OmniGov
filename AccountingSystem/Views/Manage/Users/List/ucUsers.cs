using System;
using System.Data;
using ACC.Domain.Interfaces;
using System.Windows.Forms;
using System.ComponentModel;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class ucUsers : UserControl
    {
        internal int userId = 0;

        public ucUsers()
        {
            InitializeComponent();
        }

        internal void LoadRoleName()
        {
            try
            {
                DataTable dtRoleName = Factory.RolesRepository().GetRecords();
                HelperLoadRecords.RoleNameComboBox(dtRoleName, cmbRoles, "role_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = epRole.GetError(cmbRoles);
            errorArray[1] = epFirstName.GetError(txtFirstname);
            errorArray[2] = epMiddleInitial.GetError(txtMiddleInitial);
            errorArray[3] = epLastName.GetError(txtLastname);
            errorArray[4] = epUserName.GetError(txtUsername);
            errorArray[5] = epPassword.GetError(txtPassword);
            errorArray[6] = epConfirmPassword.GetError(txtConfirmPassword);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbRoles.SelectedIndex = -1;
            txtFirstname.Clear();
            txtLastname.Clear();
            txtMiddleInitial.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
         

        }

        private bool PasswordDoesNotMatch(ErrorProvider epPassword, TextBox txtBox)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                epPassword.SetError(txtBox, "Password does not match. Please try again.");
                return true;
            }

            return false;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epUserName, txtUsername, "username");

            var usersRepository = Factory.UsersRepository();
            string userName = txtUsername.Text.Trim();
            bool userNameExist;

            if (userId == 0)
                userNameExist = usersRepository.NameExist(userName); // add form
            else
                userNameExist = usersRepository.NameExist(userName, userId); // edit form

            if (userNameExist)
            {
                epUserName.SetError(txtUsername, "Username already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epUserName, txtUsername);
        }

        private void ucUsers_Load(object sender, EventArgs e)
        {
            
           
                
            
        }

        private void cmbRoles_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epRole, cmbRoles, "role name");

            int roleId = Convert.ToByte(cmbRoles.SelectedValue);
            bool idExist = Factory.RolesRepository().IdExist(roleId);

            if (!idExist)
            {
                epRole.SetError(cmbRoles, "Invalid role name. Please select on the list.");
                e.Cancel = true;
            }
        }

        private void cmbRoles_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epRole, cmbRoles);
        }

        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epFirstName, txtFirstname, "first name");
        }

        private void txtFirstname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFirstName, txtFirstname);
        }

        private void txtMiddleInitial_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epMiddleInitial, txtMiddleInitial);
        }

        private void txtMiddleInitial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epMiddleInitial, txtMiddleInitial, "middle initial");
        }

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epLastName, txtLastname, "last name");
        }

        private void txtLastname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epLastName, txtLastname);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (userId != 0) return;

            if (Helper.ShowErrorTextBoxEmpty(epPassword, txtPassword, "password"))
            {
                e.Cancel = true;
                return;
            }

            if (PasswordDoesNotMatch(epPassword, txtPassword))
            {
                e.Cancel = true;
                return;
            }
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPassword, txtPassword);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (userId != 0) return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(epConfirmPassword, txtConfirmPassword, "confirm password");
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epConfirmPassword, txtConfirmPassword);
        }
    }
}