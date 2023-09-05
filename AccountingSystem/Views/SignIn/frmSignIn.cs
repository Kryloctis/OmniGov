using ACC.Data;
using ACC.Domain.Interfaces;
using AccountingSystem.Properties;
using AccountingSystem.Views.Dashboard;
using AccountingSystem.Views.SignIn;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Org.BouncyCastle.Pkcs;
using RPT.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Web;
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLoginCredentials();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleCharVisibility(TextBox textBox, Button button)
        {
            Image invisibleImage = Resources.invisible_16px;
            Image visibleImage = Resources.visible_16px;

            if (textBox.PasswordChar == '•')
            {
                button.Image = invisibleImage;
                textBox.PasswordChar = default(char);
            }
            else
            {
                button.Image = visibleImage;
                textBox.PasswordChar = '•';
            }
        }

        private void btnVisibility_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleCharVisibility(txtPassword, btnVisibility);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string GetFormErrors()
        {
            string[] errorArray =
            {
                txtUsername.Tag.ToString(),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void OnLoad()
        {
            ScanAvailableServers();
            txtUsername.Tag = string.Empty;
            txtPassword.Tag = string.Empty;
        }

        private void ScanAvailableServers()
        {
            var availableServerList = Helper.AvailableServerList();
            if (availableServerList.Count < 1)
            {
                lblServer.Text = $"(F12) Server: No server found.";
                return;
            }
            else
                SelectFirstServerLoaded();
        }

        private void SelectFirstServerLoaded()
        {
            var availableServerList = Helper.AvailableServerList();
            Helper.selectedServerModel = availableServerList.First();

            AccFactory.ServerRepository().ApplyConnection(Helper.selectedServerModel.LfsInstance);
            RptFactory.ServerRepository().ApplyConnection(Helper.selectedServerModel.RpmInstance);
            lblServer.Text = $"(F12) Server: {Helper.selectedServerModel.MunicipalityName}, {Helper.selectedServerModel.ProvinceName}.";
        }

        private void SignInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                _ = new frmDatabaseConfig(this).ShowDialog();
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

        private void ValidateLoginCredentials()
        {
            if (!this.ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

            Image visibleImage = Resources.visible_16px;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Helper.UserId = AccFactory.UsersRepository().ValidateLogin(username, password);
            var mainForm = new MainForm(this);
            txtUsername.SelectAll();
            txtUsername.Focus();
            txtPassword.Clear();

            mainForm.Show();
            Hide();

            btnVisibility.Image = visibleImage;
            txtPassword.PasswordChar = '•';
        }

        #region Validations

        private bool Server_Validated()
        {
            string errorMessage;
            bool isServerNull = Helper.selectedServerModel == null;

            if (!isServerNull)
            {
                var selectedServerModel = Helper.selectedServerModel;
                bool lfsTestConnection = AccFactory.ServerRepository().TestConnection(selectedServerModel.LfsInstance);
                bool rptmTestConnection = RptFactory.ServerRepository().TestConnection(selectedServerModel.RpmInstance);
                bool isTestConnectionSucceed = lfsTestConnection && rptmTestConnection;
                if (!isTestConnectionSucceed)
                {
                    errorMessage = "Server connection failed";
                    txtUsername.Tag = errorMessage;
                    txtPassword.Tag = errorMessage;
                    return false;
                }
                return true;
            }
            else
            {
                errorMessage = "No server found";
                txtUsername.Tag = errorMessage;
                txtPassword.Tag = errorMessage;
                return false;
            }
        }

        private bool Username_Password_Validated()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            int userId = AccFactory.UsersRepository().ValidateLogin(username, password);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                string errorMessage = "Please enter username and password.";
                txtUsername.Tag = errorMessage;
                txtPassword.Tag = errorMessage;
                return false;
            }
            else if (userId == 0)
            {
                string errorMessage = "Incorrect username or password.";
                txtUsername.Tag = errorMessage;
                txtPassword.Tag = errorMessage;
                return false;
            }
            return true;
        }

        private void Username_Password_Validated(object sender, EventArgs e)
        {
            txtUsername.Tag = string.Empty;
            txtPassword.Tag = string.Empty;
        }

        private void Username_Password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !Server_Validated() || !Username_Password_Validated();
        }

        #endregion Validations
    }
}