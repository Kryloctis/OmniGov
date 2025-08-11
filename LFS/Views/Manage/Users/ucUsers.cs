using ACC.Data;
using ACC.Domain.Models;
using LFS.CustomTools;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LFS.Views.Manage.Users
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
            LoadRoles(flwLytPnlRole);
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.userId = userId.Value;
                LoadSelectedRecord(userId.Value);
            }
        }

        internal UsersModel UsersModel()
        {
            return new UsersModel()
            {
                UserName = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Prefix = txtPrefix.Text.Trim(),
                FirstName = txtFirstname.Text.Trim(),
                MidInitial = txtMiddleInitial.Text.Trim(),
                LastName = txtLastname.Text.Trim(),
                Suffix = txtSuffix.Text.Trim(),
            };
        }

        private void LoadSelectedRecord(int userId)
        {
            var dictUser = AccFactory.UsersRepository().GetRecordByID(userId);
            var dictRoles = AccFactory.RolesRepository().GetRecordByID(Convert.ToInt32(dictUser["roles_id"]));

            txtPrefix.Text = dictUser["prefix"];
            txtFirstname.Text = dictUser["first_name"];
            txtMiddleInitial.Text = dictUser["mid_initial"];
            txtLastname.Text = dictUser["last_name"];
            txtSuffix.Text = dictUser["suffix"];
            txtUsername.Text = dictUser["username"];
        }

        internal void LoadRoles(FlowLayoutPanel flowLayoutPanel)
        {
            DataTable dtRole = AccFactory.RolesRepository().GetRecords();

            foreach (DataRow dtRow in dtRole.Rows)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Tag = dtRow["id"],
                    Text = dtRow["role_name"].ToString(),
                };
                flowLayoutPanel.Controls.Add(radioButton);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
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
            LoadRoles(flwLytPnlRole);
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

        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstname, "first name");
        }

        private void txtFirstname_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstname);
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

        private void ToggleTabs(CustomTabControl customTabControl)
        {
            var tabPage = customTabControl.SelectedTab;

            switch (tabPage.Name)
            {
                case "tbPgRole":
                    radRole.Checked = true;
                    break;

                case "tabPage2":
                    radioButton2.Checked = true;
                    break;

                default:
                    break;
            }
        }

        private void btnNextRole_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedTab = tabPage2;
        }

        private void btnBck_Click(object sender, EventArgs e)
        {
            customTabControl1.SelectedTab = tbPgRole;
        }

        private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleTabs(customTabControl1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}