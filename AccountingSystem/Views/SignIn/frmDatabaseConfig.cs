using ACC.Data;
using DocumentFormat.OpenXml.Presentation;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace AccountingSystem.Views.SignIn
{
    public partial class frmDatabaseConfig : Form
    {
        private frmSignIn _frmSignIn;

        public frmDatabaseConfig(frmSignIn frmSignIn)

        {
            InitializeComponent();
            _frmSignIn = frmSignIn;
        }

        private void LoadAvailableServers()
        {
            foreach (var model in Helper.LguServerModels())
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
            }

            SelectCurrentServer();
        }

        private void SelectCurrentServer()
        {
            if (flowLayoutPanel1.Controls.OfType<RadioButton>().Count() < 1)
                return;

            foreach (RadioButton radioButton in flowLayoutPanel1.Controls)
            {
                if (Convert.ToInt32(radioButton.Tag) == Helper.selectedServerModel.LguId)

                    radioButton.Select();
            }
        }

        private void SetSelectedServer()
        {
            foreach (RadioButton radioButton in flowLayoutPanel1.Controls)
            {
                if (radioButton.Checked)
                {
                    foreach (var model in Helper.LguServerModels())
                    {
                        if (Convert.ToInt32(radioButton.Tag) == model.LguId)
                        {
                            Helper.selectedServerModel = model;
                            string municipalityName = model.MunicipalityName;
                            string provinceName = model.ProvinceName;

                            AccFactory.mySqlGenericCommandsLFS = new AccGenericCommands(model.LfsInstance);
                            RptFactory.mySqlGenericCommandsRPT = new RptGenericCommands(model.RpmInstance);
                            _frmSignIn.lblServer.Text = $"Server: {municipalityName}, {provinceName}";
                            this.Close();
                        }
                    }
                }
            }
        }

        private void OnLoad()
        {
            LoadAvailableServers();
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
                SetSelectedServer();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}