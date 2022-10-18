using ACC.Domain.Models;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DatabaseSynchronization
{
    public partial class frmDatabaseSynchronization : Form
    {
        public frmDatabaseSynchronization()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            progressBar1.Visible = false;
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
                {
                    backgroundWorkerRptSync.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        #region Database Sync Progresses

        private void backgroundWorkerRptSync_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                int progressCount = 0;
                var dtRealProperties = RptFactory.RealPropertiesRepository().GetViewLFSRealPropertiesRecords();
                var realPropertiesModels = new List<RealPropertiesModel>();
                var provincesModels = new List<ProvincesModel>();

                foreach (DataRow row in dtRealProperties.Rows)
                {
                    string completeArpNo = row["complete_arp_no"].ToString();
                    string provinceCode = row["provinces_code"].ToString();
                    string provinceName = row["provinces_name"].ToString();
                    string municipalitiesCode = row["municipalities_code"].ToString();
                    string municipalitiesName = row["municipality_name"].ToString();
                    string barangaysCode = row["barangays_code"].ToString();
                    string barangaysName = row["barangays_name"].ToString();

                    var realPropertiesModel = new RealPropertiesModel()
                    {
                        CompleteArpNo = completeArpNo,

                    };

                    var barangaysModel = new BarangayModel()
                    {
                        Code = row["barangays_code"].ToString(),
                        Name = row["barangays_name"].ToString()
                    };

                    var municipalitiesModel = new MunicipalitiesModel()
                    {
                        Code = municipalitiesCode,
                        Name = municipalitiesName,
                        BarangayModel = barangaysModel
                    };

                    var provincesModel = new ProvincesModel()
                    {
                        Code = provinceCode,
                        Name = provinceName,
                        MunicipalitiesModel = municipalitiesModel,
                    };

                    progressCount += 1;
                    provincesModels.Add(provincesModel);
                }

                AccFactory.RealPropertiesRepository().SynchronizeData(realPropertiesModels, provincesModels);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorkerRptSync_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerRptSync_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Helper.MessageBoxSuccess("RPT synced successfuly.");
        }

        #endregion
    }
}
