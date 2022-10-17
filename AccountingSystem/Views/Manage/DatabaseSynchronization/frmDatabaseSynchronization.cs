using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DatabaseSynchronization
{
    public partial class frmDatabaseSynchronization : Form
    {
        public frmDatabaseSynchronization()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void LoadSyncOptions()
        {
            var dict = new Dictionary<string, string>()
            {
                { "RPT", "0"}
            };

            var bindingSource = new BindingSource(dict, null);
            cmbxSyncType.DataSource = bindingSource;
            cmbxSyncType.DisplayMember = "Key";
            cmbxSyncType.ValueMember = "Value";
        }

        private void frmDatabaseSynchronization_Load(object sender, EventArgs e)
        {
            LoadSyncOptions();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerRptSync.IsBusy)
                    backgroundWorkerRptSync.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region Database Sync Progresses







        private void backgroundWorkerRptSync_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorkerRptSync_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerRptSync_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                Helper.MessageBoxSuccess("RPT synced successfuly.");
                progressBar1.Value = 0;
            }
        }

        #endregion


    }
}
