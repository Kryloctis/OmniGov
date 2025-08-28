using ACC.Data;
using LFS.Helpers;
using LFS.Properties;
using LFS.Views.Dashboard;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.SignIn
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var availableServerList = ServerHelper.AvailableServerList();
            e.Result = availableServerList.Count < 1 ? false : true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool hostFound = (bool)e.Result;

            if (hostFound)
            {
                var serverHelpers = ServerHelper.AvailableServerList();
                SelectFirstServerLoaded(serverHelpers);
            }
            else
            {
                lblServer.Text = $"(F12) Server: No server found.";
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                Image visibleImage = Resources.visible_16px;

                if (!this.ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                var userDict = AccFactory.UsersRepository().GetUserRecordByAcc(username, password);
                _ = new UserHelper(userDict);

                var dashboardForm = new frmMain(this);
                txtUsername.SelectAll();
                txtUsername.Focus();
                txtPassword.Clear();

                dashboardForm.Show();
                Hide();

                btnVisibility.Image = visibleImage;
                txtPassword.PasswordChar = '•';
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
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
            if (!backgroundWorker1.IsBusy)
            {
                lblServer.Text = "Scanning Server...";
                backgroundWorker1.RunWorkerAsync();
            }

            txtUsername.Tag = string.Empty;
            txtPassword.Tag = string.Empty;
            txtVersion.Text = Helper.version;
        }

        private void SelectFirstServerLoaded(List<ServerHelper> serverHelpers)
        {
            ServerHelper.selectedServer = serverHelpers.First();
            AccFactory.ServerRepository().ApplyConnection(ServerHelper.selectedServer.LfsInstance);
            RptFactory.ServerRepository().ApplyConnection(ServerHelper.selectedServer.RpmsInstance);

            lblServer.Text = $"(F12) Server: {ServerHelper.selectedServer.MunicipalityName}, {ServerHelper.selectedServer.ProvinceName}.";
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

        private bool Server_Validated()
        {
            string errorMessage;
            bool isServerNull = ServerHelper.selectedServer == null;

            if (!isServerNull)
            {
                bool lfsTestConnection =
                    AccFactory.ServerRepository().TestConnection(ServerHelper.selectedServer.LfsInstance);
                bool rptmTestConnection =
                    RptFactory.ServerRepository().TestConnection(ServerHelper.selectedServer.RpmsInstance);

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

        private bool Username_Password_Validated(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                string errorMessage = "Please enter username and password.";
                txtUsername.Tag = errorMessage;
                txtPassword.Tag = errorMessage;
                return false;
            }
            else if (!AccFactory.UsersRepository().AccIsValidated(username, password))
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

        private void Username_Password_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                e.Cancel = !Server_Validated() || !Username_Password_Validated(username, password);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}