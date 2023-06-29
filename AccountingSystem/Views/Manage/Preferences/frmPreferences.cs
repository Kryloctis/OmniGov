using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Preferences
{
    public partial class frmPreferences : Form
    {
        private Image lguEmblem = null;

        public frmPreferences()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void OnLoad()
        {
            LoadPreferences();
        }

        private void LoadPreferences()
        {
            var dictPreferences = AccFactory.PreferencesRepository().GetDynamicRecordByID(1);
            Image emblem = Convert.IsDBNull(dictPreferences["emblem"]) ? null : Helper.ByteArrayToImage(dictPreferences["emblem"]);
            txtMunicipality.Text = dictPreferences["municipality"];
            txtProvince.Text = dictPreferences["province"];
            lguEmblem = emblem;
            pcEmblem.Image = emblem;
        }

        private bool SaveLguDetails()
        {
            var preferencesModel = new PreferencesModel()
            {
                Municipality = txtMunicipality.Text.Trim(),
                Province = txtProvince.Text.Trim(),
                Emblem = Helper.ImageToByteArray(lguEmblem)
            };

            return AccFactory.PreferencesRepository().Insert(preferencesModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveLguDetails())
            {
                Helper.MessageBoxSuccess("Preferences has been saved.");
                this.Close();
            }
        }

        private void btnEmblem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            lguEmblem = new Bitmap(openFileDialog1.FileName);
            pcEmblem.Image = lguEmblem;
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}