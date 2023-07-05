using AccountingSystem.Properties;
using AccountingSystem.Views.SignIn;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                Image visibleImage = Properties.Resources.visible_16px;
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    Helper.MessageBoxError("Please enter both username and password.");
                    return;
                }

                var userId = AccFactory.UsersRepository().ValidateLogin(username, password);

                if (userId != 0)
                {
                    Helper.UserId = userId;
                    var mainForm = new MainForm(this);
                    mainForm.Show();
                    Hide();
                    txtPassword.Clear();
                    btnVisibility.Image = visibleImage;
                    txtPassword.PasswordChar = '•';
                    return;
                }

                Helper.MessageBoxError("Incorrect username or password.");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            Cursor = Cursors.Default;
        }

        private void btnVisibility_Click(object sender, EventArgs e)
        {
            Image invisibleImage = Properties.Resources.invisible_16px;
            Image visibleImage = Properties.Resources.visible_16px;

            if (txtPassword.PasswordChar == '•')
            {
                btnVisibility.Image = invisibleImage;
                txtPassword.PasswordChar = default(char);
            }
            else
            {
                btnVisibility.Image = visibleImage;
                txtPassword.PasswordChar = '•';
            }
        }

        private void SignIn_Shown(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
            txtUsername.Focus();
        }

        private void SignInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
                _ = new frmDatabaseConfig().ShowDialog();
        }
    }
}