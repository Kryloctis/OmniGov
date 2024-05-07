using ACC.Data;
using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Users.List
{
    public partial class ucUsers : UserControl
    {
        private bool isEdit;
        private int userId;

        public ucUsers()
        {
            InitializeComponent();
        }

        internal void OnLoad(bool isEdit, int? userId)
        {
            this.isEdit = isEdit;
            LoadOffice();

            if (isEdit)
            {
                this.userId = userId.Value;
                LoadSelectedRecord(userId.Value);
            }
        }

        private void LoadSelectedRecord(int userId)
        {
            var dictUser = AccFactory.UsersRepository().GetRecordByID(userId);
            var dictRoles = AccFactory.RolesRepository().GetRecordByID(Convert.ToInt32(dictUser["roles_id"]));

            cmbOffice.Text = dictRoles["office"];
            cmbRoles.SelectedValue = dictUser["roles_id"];
            txtPrefix.Text = dictUser["prefix"];
            txtFirstname.Text = dictUser["first_name"];
            txtMiddleInitial.Text = dictUser["mid_initial"];
            txtLastname.Text = dictUser["last_name"];
            txtSuffix.Text = dictUser["suffix"];
            txtUsername.Text = dictUser["username"];
        }

        private void cmbOffice_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRoles();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadOffice()
        {
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
        }

        internal void LoadRoles()
        {
            string office = cmbOffice.Text;
            DataTable dtRoleName = AccFactory.RolesRepository().GetRecordsByOffice(office);
            HelperLoadRecords.RoleNameComboBox(dtRoleName, cmbRoles, "role_name", "id");
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbRoles),
                errorProvider1.GetError(txtFirstname),
                errorProvider1.GetError(txtMiddleInitial),
                errorProvider1.GetError(txtLastname),
                errorProvider1.GetError(txtUsername),
                txtPassword.Tag.ToString(),
                txtConfirmPassword.Tag.ToString()
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            LoadRoles();
            txtPrefix.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtSuffix.Clear();
            txtMiddleInitial.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtUsername, "username");

                var usersRepository = AccFactory.UsersRepository();
                string userName = txtUsername.Text.Trim();
                bool userNameExist;

                if (userId == 0)
                    userNameExist = usersRepository.NameExist(userName); // add form
                else
                    userNameExist = usersRepository.NameExist(userName, userId); // edit form

                if (userNameExist)
                {
                    errorProvider1.SetError(txtUsername, "Username already exist in your records.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtUsername_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtUsername);
        }

        private void cmbRoles_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbRoles, "role name");

                int roleId = Convert.ToByte(cmbRoles.SelectedValue);
                bool idExist = AccFactory.RolesRepository().IdExist(roleId);

                if (!idExist)
                {
                    errorProvider1.SetError(cmbRoles, "Invalid role name. Please select on the list.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbRoles_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbRoles);
        }

        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstname, "first name");
        }

        private void txtFirstname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstname);
        }

        private void txtMiddleInitial_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMiddleInitial);
        }

        private void txtMiddleInitial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMiddleInitial, "middle initial");
        }

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastname, "last name");
        }

        private void txtLastname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastname);
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
            Helper.ClearErrorTextBox(errorProvider1, txtPassword);
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
            try
            {
                if (userId != 0) return;
                e.Cancel = textBoxIsEmpty(txtConfirmPassword, "Please confirm password");

                if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    e.Cancel = PasswordDoesNotMatch(txtConfirmPassword);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtConfirmPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtConfirmPassword);
        }

        private void btnPasswordVisibility_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnConfirmPasswordVisibility_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}