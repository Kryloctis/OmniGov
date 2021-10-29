using System;
using System.Data;
using ACC.Domain.Interfaces;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class ucUsers : UserControl
    {
        internal int userId = 0;

        public ucUsers()
        {
            InitializeComponent();
        }

      

        internal void LoadOffice()
        {
            cmbOffice.SelectedValueChanged -= new EventHandler(CmbxOffice_SelectedValueChanged);

            var userDict = Helper.LoggedInUserData();
            switch (userDict["office"])
            {
                case "SysAdmin":
                    cmbOffice.Items.AddRange(new string[] { "Budget", "Accounting", "Treasury" });
                    break;
                default:
                    cmbOffice.Items.Add(userDict["office"]);
                    break;
            }

            cmbOffice.SelectedIndex = 0;

            cmbOffice.SelectedValueChanged += new EventHandler(CmbxOffice_SelectedValueChanged);
        }

        internal void LoadRoles()
        {
            try
            {
                string office = cmbOffice.Text;

                DataTable dtRoleName = Factory.RolesRepository().GetRecordsByOffice(office);
                HelperLoadRecords.RoleNameComboBox(dtRoleName, cmbRoles, "role_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void CmbxOffice_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbRoles.Text = string.Empty;
            LoadRoles();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = epRole.GetError(cmbRoles);
            errorArray[1] = epFirstName.GetError(txtFirstname);
            errorArray[2] = epMiddleInitial.GetError(txtMiddleInitial);
            errorArray[3] = epLastName.GetError(txtLastname);
            errorArray[4] = epUserName.GetError(txtUsername);
            errorArray[5] = txtPassword.Tag.ToString();
            errorArray[6] = txtConfirmPassword.Tag.ToString();

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


        private bool textBoxIsEmpty(TextBox textBox, string field)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Tag = field;
                return true;
            }

            textBox.Tag = string.Empty;
            return false;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (userId != 0) return;

            e.Cancel = textBoxIsEmpty(txtPassword, Helper.ErrorMessage("Password"));
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPassword, txtPassword);
        }


        private bool PasswordDoesNotMatch(TextBox txtBox)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtBox.Tag = "Password does not match. Please try again.";
                return true;
            }

            txtBox.Tag = string.Empty;
            return false;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (userId != 0) return;
            e.Cancel = textBoxIsEmpty(txtConfirmPassword,"Please confirm password");

            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = PasswordDoesNotMatch(txtConfirmPassword);
            }
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epConfirmPassword, txtConfirmPassword);
        }

        private void btnPasswordVisibility_Click(object sender, EventArgs e)
        {
            Image invisibleImage = Properties.Resources.invisible_16px;
            Image visibleImage = Properties.Resources.visible_16px;

            if (txtPassword.PasswordChar == '•')
            {
                btnPasswordVisibility.Image = invisibleImage;
                txtPassword.PasswordChar = default(char);
            }
            else
            {
                btnPasswordVisibility.Image = visibleImage;
                txtPassword.PasswordChar = '•';
            }
        }

        private void btnConfirmPasswordVisibility_Click(object sender, EventArgs e)
        {
            Image invisibleImage = Properties.Resources.invisible_16px;
            Image visibleImage = Properties.Resources.visible_16px;

            if (txtConfirmPassword.PasswordChar == '•')
            {
                btnConfirmPasswordVisibility.Image = invisibleImage;
                txtConfirmPassword.PasswordChar = default(char);
            }
            else
            {
                btnConfirmPasswordVisibility.Image = visibleImage;
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void ucUsers_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadOffice();
            }
        }
    }
}