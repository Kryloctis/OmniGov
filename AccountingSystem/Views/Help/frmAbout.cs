using AccountingSystem.Properties;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Help
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void OnLoad()
        {
            richTextBox1.Text = Helper.GetVersionLog();
            checkBox1.Checked = !Settings.Default.showAbout;
        }

        private void frmUpdates_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmUpdates_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.showAbout = !checkBox1.Checked;
                Settings.Default.Save();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}