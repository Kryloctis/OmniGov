using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Image visibleImage = Properties.Resources.visible_16px;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Helper.MessageBoxError("Please enter both username and password.");
                return;
            }

            var userId = Factory.UsersRepository().ValidateLogin(username, password);

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
    }
}
