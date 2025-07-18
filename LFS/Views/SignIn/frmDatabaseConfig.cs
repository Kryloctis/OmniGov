using ACC.Data;
using RPT.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace LFS.Views.SignIn
{
    public partial class frmDatabaseConfig : Form
    {
        private frmSignIn _frmSignIn;

        public frmDatabaseConfig(frmSignIn frmSignIn)

        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmSignIn = frmSignIn;
        }

        private void LoadServers()
        {
            int totalServers = Helper.AvailableServerList().Count;
            int serverCount = 0;

            flowLayoutPanel1.Controls.Clear();
            progressBar1.Value = 0;

            foreach (var model in Helper.AvailableServerList())
            {
                int lguId = model.LguId;
                string municipalityName = model.MunicipalityName;
                string provinceName = model.ProvinceName;

                var radioButton = new RadioButton()
                {
                    Tag = lguId,
                    Text = $"{municipalityName}, {provinceName}",
                    Name = $"radBtn{municipalityName}{provinceName}",
                    AutoSize = true
                };

                flowLayoutPanel1.Controls.Add(radioButton);
                serverCount++;
                int progressPercentage = (serverCount * 100) / totalServers;
                backgroundWorker1.ReportProgress(progressPercentage);
            }

            SelectCurrentServer();
        }

        private void SelectCurrentServer()
        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().Count() < 1 || Helper.selectedServerModel == null)
                return;

            foreach (RadioButton radioButton in flowLayoutPanel1.Controls)
            {
                if (Convert.ToInt32(radioButton.Tag) == Helper.selectedServerModel.LguId)

                    radioButton.Select();
            }
        }

        private bool SetSelectedServer()
        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().Count() < 1)
                return false;

            foreach (RadioButton radioButton in flowLayoutPanel1.Controls)
            {
                if (radioButton.Checked)
                {
                    var radTag = radioButton.Tag;
                    var selectedModel = Helper.AvailableServerList().Where(g => g.LguId == Convert.ToInt32(radTag)).Select(m => new Helper.LguServerModel { LguId = m.LguId, MunicipalityCode = m.MunicipalityCode, MunicipalityName = m.MunicipalityName, ProvinceCode = m.ProvinceCode, ProvinceName = m.ProvinceName, lfsInstance = m.lfsInstance, rpmInstance = m.rpmInstance, Emblem = m.Emblem }).First();
                    Helper.selectedServerModel = selectedModel;
                    return true;
                }
            }
            return false;
        }

        private void OnLoad()
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmDatabaseConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetSelectedServer())
                {
                    _frmSignIn.lblServer.Text = $"(F12) Server: {Helper.selectedServerModel.MunicipalityName}, {Helper.selectedServerModel.ProvinceName}";
                    AccFactory.ServerRepository().ApplyConnection(Helper.selectedServerModel.lfsInstance);
                    RptFactory.ServerRepository().ApplyConnection(Helper.selectedServerModel.rpmInstance);
                    this.Close();
                }
                ;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                    {
                        LoadServers();
                    });
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}