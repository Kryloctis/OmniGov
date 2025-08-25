using ACC.Data;
using ACC.Domain.Models;
using LFS.CustomTools;
using LFS.Helpers;
using LFS.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        internal void OnLoad(bool isEdit, int? userId = null)
        {
            this.isEdit = isEdit;
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            LoadRoles(flwLytPnlRole);

            if (isEdit)
            {
                this.userId = userId.Value;
                LoadSelectedRecord(userId.Value);
            }
        }

        internal UsersModel UsersModel()
        {
            var model = new UsersModel();

            if (isEdit) model.Id = userId;

            model.UserName = txtUsername.Text.Trim();
            model.Password = txtPassword.Text.Trim();
            model.Prefix = txtPrefix.Text.Trim();
            model.FirstName = txtFirstname.Text.Trim();
            model.MidInitial = txtMiddleInitial.Text.Trim();
            model.LastName = txtLastname.Text.Trim();
            model.Suffix = txtSuffix.Text.Trim();
            model.RoleId = GetSelectedRoleId().Value;

            return model;
        }

        private void LoadSelectedRecord(int userId)
        {
            var dictUser = AccFactory.UsersRepository().GetViewRecordById(userId);
            int roleId = Convert.ToInt32(dictUser["roles_id"]);
            var dictRoles = AccFactory.RolesRepository().GetRecordByID(roleId);

            var radioButtons = flwLytPnlRole.Controls.OfType<RadioButton>();

            foreach (RadioButton item in radioButtons)
            {
                if (Convert.ToInt32(item.Tag) == roleId)
                {
                    item.Checked = true;
                }
            }

            txtPrefix.Text = dictUser["prefix"];
            txtFirstname.Text = dictUser["first_name"];
            txtMiddleInitial.Text = dictUser["mid_initial"];
            txtLastname.Text = dictUser["last_name"];
            txtSuffix.Text = dictUser["suffix"];
            txtUsername.Text = dictUser["username"];
        }

        private byte? GetSelectedRoleId()
        {
            var checkedRadio = flwLytPnlRole.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(rb => rb.Checked);

            return checkedRadio != null ? Convert.ToByte(checkedRadio.Tag) : (byte?)null;
        }

        internal void LoadRoles(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.Controls.Clear();
            DataTable dtRole = AccFactory.RolesRepository().GetRecords();

            foreach (DataRow dtRow in dtRole.Rows)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Tag = dtRow["id"],
                    Text = dtRow["role_name"].ToString(),
                    Appearance = Appearance.Button,
                    TextAlign = ContentAlignment.MiddleCenter,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                    AutoSize = true,
                    Padding = new Padding(2, 2, 2, 2)
                };

                radioButton.CheckedChanged += radRoles_CheckedChanged;
                flowLayoutPanel.Controls.Add(radioButton);
            }
        }

        private void radRoles_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;

            if (rb.Checked) rb.Image = Resources.symbol_ok_18px;
            else rb.Image = null;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtFirstname),
                errorProvider1.GetError(txtMiddleInitial),
                errorProvider1.GetError(txtLastname),
                errorProvider1.GetError(txtUsername),
                errorProvider1.GetError(txtPassword),
                errorProvider1.GetError(txtConfirmPassword),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            errorProvider1.Clear();
            customTabControl1.SelectedTab = tbPgRole;
            txtPrefix.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtSuffix.Clear();
            txtMiddleInitial.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            LoadRoles(flwLytPnlRole);
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

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (isEdit)
                    e.Cancel = !PasswordValidated(errorProvider1, txtPassword, txtConfirmPassword);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtPassword_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPassword);
        }

        private bool PasswordValidated(ErrorProvider errorProvider, TextBox txtPass, TextBox txtCnfrmPass)
        {
            string notMatchMssg = "Password does not match. Please try again.";

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, txtPass, "Password"))
            {
                return false;
            }
            else if (Helper.ShowErrorTextBoxEmpty(errorProvider, txtPass, "Confirm Password"))
            {
                return false;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider.SetError(txtCnfrmPass, notMatchMssg);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (isEdit)
                    e.Cancel = !PasswordValidated(errorProvider1, txtPassword, txtConfirmPassword);
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

        private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleIndicators(customTabControl1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleIndicators(CustomTabControl customTabControl)
        {
            var tabPage = customTabControl.SelectedTab;
            radRole.Checked = radUserInfo.Checked = radAccInfo.Checked = false;

            switch (tabPage.Name)
            {
                case "tbPgRole":
                    radRole.Checked = true;

                    break;

                case "tbPgUserInfo":
                    radUserInfo.Checked = true;
                    break;

                case "tbPgAccInf":
                    radAccInfo.Checked = true;
                    break;
            }
        }

        internal void TogglePages(bool next)
        {
            if (customTabControl1?.TabPages.Count > 0)
            {
                int maxIndex = customTabControl1.TabPages.Count - 1;
                int newIndex = Math.Clamp(customTabControl1.SelectedIndex + (next ? 1 : -1), 0, maxIndex);
                customTabControl1.SelectedIndex = newIndex;
            }
        }

        internal void ToggleButtons(Button btnBck, Button btnNxt, Button btnSave)
        {
            var selectedTab = customTabControl1.SelectedTab.Name;

            switch (selectedTab)
            {
                case "tbPgRole":
                    btnBck.Visible = false;
                    btnNxt.Visible = true;
                    btnSave.Visible = false;
                    break;

                case "tbPgUserInfo":
                    btnBck.Visible = true;
                    btnNxt.Visible = true;
                    btnSave.Visible = false;
                    break;

                case "tbPgAccInf":
                    btnBck.Visible = true;
                    btnNxt.Visible = false;
                    btnSave.Visible = true;
                    break;

                default:
                    break;
            }
        }
    }
}