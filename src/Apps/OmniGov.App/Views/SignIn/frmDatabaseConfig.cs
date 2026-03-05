using OmniGov.App.Helpers;

using OmniGov.Core.Interfaces.Factories;

using OmniGov.Core.Models;

using OmniGov.Core.Services;

using System.ComponentModel;

namespace OmniGov.App.Views.SignIn

{
    public partial class frmDatabaseConfig : Form

    {
        private frmSignIn _frmSignIn;

        private List<LguProfile> _loadedProfiles = new();

        public frmDatabaseConfig(frmSignIn frmSignIn)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            _frmSignIn = frmSignIn;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            var availableProfiles = ServerHelper.GetAvailableProfiles();
            Invoke((MethodInvoker)delegate
            {
                LoadServers(availableProfiles);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void btnOk_Click(object sender, EventArgs e)

        {
            if (SetSelectedServer() && ServerHelper.SelectedProfile != null)
            {
                var profile = ServerHelper.SelectedProfile;
                _frmSignIn.UpdateServerLabel(profile);

                var factory = ServiceLocator.GetRequiredService<IRepositoryFactory>();
                factory.ServerRepository().ApplyProfile(profile);

                this.Close();
            }
        }

        private void frmDatabaseConfig_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Escape)

                Close();
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void LoadServers(List<LguProfile> availableProfiles)

        {
            _loadedProfiles = availableProfiles;

            int totalServers = availableProfiles.Count;

            int serverCount = 0;

            flowLayoutPanel1.Controls.Clear();

            progressBar1.Value = 0;

            foreach (var profile in availableProfiles)

            {
                var radioButton = new RadioButton()

                {
                    Tag = profile.Id,

                    Text = $"{profile.Name}, {profile.ProvinceName}",

                    Name = $"radBtn{profile.Name}{profile.ProvinceName}",

                    AutoSize = true
                };

                flowLayoutPanel1.Controls.Add(radioButton);

                serverCount++;

                int progressPercentage = totalServers > 0 ? (serverCount * 100) / totalServers : 0;

                progressBar1.Value = progressPercentage;
            }

            SelectCurrentServer();
        }

        private void OnLoad()

        {
            if (!backgroundWorker1.IsBusy)

                backgroundWorker1.RunWorkerAsync();
        }

        private void SelectCurrentServer()

        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().Count() < 1 || ServerHelper.SelectedProfile == null)

                return;

            foreach (RadioButton radioButton in flowLayoutPanel1.Controls)

            {
                if (Convert.ToInt32(radioButton.Tag) == ServerHelper.SelectedProfile.Id)

                    radioButton.Select();
            }
        }

        private bool SetSelectedServer()

        {
            var selectedRadio = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            if (selectedRadio == null) return false;

            int selectedId = Convert.ToInt32(selectedRadio.Tag);

            var profile = _loadedProfiles.FirstOrDefault(p => p.Id == selectedId);

            if (profile != null)

            {
                ServerHelper.SelectedProfile = profile;

                return true;
            }

            return false;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)

        {
            if (!backgroundWorker1.IsBusy)

                backgroundWorker1.RunWorkerAsync();
        }
    }
}