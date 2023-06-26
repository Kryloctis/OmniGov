using AccountingSystem.Properties;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void OnLoad()
        {
            lblLgu.Text = $"Local Goverment Unit of {Helper.LGUDetails()["municipality"]}";
            lblProvince.Text = Helper.LGUDetails()["lgu_province"];
            pcBoxEmblem.Image = Resources.lgu_buug_symbol;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
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
                    Cursor = Cursors.Default;
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
    }
}