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
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var userId = Factory.UsersRepository().ValidateLogin(username, password);

            if (userId != 0)
            {
                var mainForm = new MainForm();
                mainForm.userId = userId;
                mainForm.Show();
                return;
            }

            MessageBox.Show("Login failed.");
        }
    }
}
