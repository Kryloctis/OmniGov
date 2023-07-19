using ACC.Data;
using AccountingSystem.Properties;
using AccountingSystem.Views.SignIn;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using RPT.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
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
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                    txtPassword.Clear();

                    mainForm.Show();
                    Hide();

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

        private void LoadFirstDetectedServer()
        {
            var serverList = Helper.LguServerModels();
            string municipalityName = serverList.First().MunicipalityName;
            string provinceName = serverList.First().ProvinceName;
            Helper.selectedServerModel = serverList.First();

            lblServer.Text = $"(F12) Server: {municipalityName}, {provinceName}";
        }

        private void OnLoad()
        {
            LoadFirstDetectedServer();
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void SignInForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void SignInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                _ = new frmDatabaseConfig(this).ShowDialog();
        }

        private void ScanAvailableServers()
        {
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }
    }
}