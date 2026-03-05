using OmniGov.App.Helpers;

using OmniGov.App.Properties;

using OmniGov.App.Views.Dashboard;

using OmniGov.Core.Interfaces.Factories;

using OmniGov.Core.Interfaces.Services;

using OmniGov.Core.Models;

using OmniGov.Core.Services;

using System.ComponentModel;

namespace OmniGov.App.Views.SignIn

{
    public partial class frmSignIn : Form

    {
        private string errorMessage = string.Empty;

        public frmSignIn()

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);
        }

        public void UpdateServerLabel(LguProfile profile)

        {
            if (profile != null)

            {
                lblServer.Text = $"(F12) Server: {profile.Name}, {profile.ProvinceName}";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {
        }

        private void btnSignIn_Click(object sender, EventArgs e)

        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!this.ValidateChildren())
            {
                txtUsername.SelectAll();
                return;
            }

            if (!IsValidated(username, password))
            {
                Helper.MessageBoxError(errorMessage);
                return;
            }

            this.Hide();

            using (var main = new frmMain(this))
            {
                main.ShowDialog();
            }

            // When we return here, the main form has closed.
            // We show the sign-in form again and reset fields.
            this.Show();
            txtPassword.Clear();
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void btnVisibility_Click(object sender, EventArgs e)

        {
            if (txtPassword.PasswordChar == '*')

            {
                txtPassword.PasswordChar = '\0';

                btnVisibility.Image = Resources.invisible_16px;
            }
            else

            {
                txtPassword.PasswordChar = '*';

                btnVisibility.Image = Resources.visible_16px;
            }
        }

        private bool IsValidated(string username, string password)

        {
            if (ServerHelper.SelectedProfile == null)

            {
                errorMessage = "No server profile selected. Please press F12 to select a server.";

                return false;
            }

            var factory = ServiceLocator.GetRequiredService<IRepositoryFactory>();

            var connectionProvider = ServiceLocator.GetRequiredService<IConnectionProvider>();

            if (!connectionProvider.IsInitialized)

            {
                factory.ServerRepository().ApplyProfile(ServerHelper.SelectedProfile);
            }

            var userRecord = factory.UsersRepository().GetUserRecordByAcc(username, password);

            if (userRecord.Count < 1)

            {
                errorMessage = "Invalid username or password.";

                return false;
            }

            // Initialize the user session

            _ = new UserHelper(userRecord);

            return true;
        }

        private void SignInForm_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.F12)

            {
                var config = new frmDatabaseConfig(this);

                config.ShowDialog();
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)

        {
            txtVersion.Text = $"v{Helper.version}";

            var profiles = ServerHelper.LoadProfiles();
            if (profiles.Count > 0)
            {
                ServerHelper.SelectedProfile = profiles[0];
                UpdateServerLabel(profiles[0]);

                var factory = ServiceLocator.GetRequiredService<IRepositoryFactory>();
                factory.ServerRepository().ApplyProfile(profiles[0]);
            }
            else
            {
                lblServer.Text = "Server: None selected (F12)";
            }
        }

        private void SignInForm_VisibleChanged(object sender, EventArgs e)

        {
        }

        private void Username_Password_Validated(object sender, EventArgs e)

        {
        }

        private void Username_Password_Validating(object sender, CancelEventArgs e)

        {
        }
    }
}