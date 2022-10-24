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
                var dtRealProperties = RptFactory.RealPropertiesRepository().GetViewLFSRealPropertiesRecords();
                var realPropertiesModels = new List<RealPropertiesModel>();
                var provincesModels = new List<ProvincesModel>();
                var taxpayerTypeModels = new List<TaxpayerTypeModel>();
                var actualUseCodeModels = new List<ActualUseCodesModel>();
                var classificationCodeModels = new List<ClassificationCodesModel>();
                var taxpayersModels = new List<TaxpayersModel>();

                foreach (DataRow row in dtRealProperties.Rows)
                {
                    string taxpayerTin = row["owner_tin"].ToString();
                    string taxpayerName = row["owner_name"].ToString();
                    string taxpayerContactInfo = row["owner_contact"].ToString();
                    string taxpayerStreet = row["owner_street"].ToString();
                    string completeArpNo = row["complete_arp_no"].ToString();
                    string provinceCode = row["provinces_code"].ToString();
                    string provinceName = row["provinces_name"].ToString();
                    string municipalitiesCode = row["municipalities_code"].ToString();
                    string municipalitiesName = row["municipality_name"].ToString();
                    string barangaysCode = row["barangays_code"].ToString();
                    string barangaysName = row["barangays_name"].ToString();
                    string taxpayerTypeCode = row["owner_type_code"].ToString();
                    string taxpayerType = row["owner_type"].ToString();
                    string actualUseCode = row["actual_use_code"].ToString();
                    string actualUseName = row["actual_use_name"].ToString();
                    string classificationCode = row["classification_code"].ToString();
                    string classificationName = row["classification_name"].ToString();
                    bool actualUseIsGovernment = Convert.ToBoolean(Convert.ToByte(row["actual_use_is_government"]));
                    bool classificationIsSpecial = Convert.ToBoolean(Convert.ToByte(row["classfication_is_special"]));

                    var realPropertiesModel = new RealPropertiesModel()
                    {


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

                    var taxpayerTypeModel = new TaxpayerTypeModel()
                    {
                        Code = taxpayerTypeCode,
                        taxpayerType = taxpayerType
                    };

                    var actualUseCodesModel = new ActualUseCodesModel()
                    {
                        Code = actualUseCode,
                        Name = actualUseName,
                        IsGovernment = actualUseIsGovernment
                    };

                    var classificationCodesModel = new ClassificationCodesModel()
                    {
                        Code = classificationCode,
                        Name = classificationName,
                        IsSpecial = classificationIsSpecial
                    };

                    var taxpayersModel = new TaxpayersModel()
                    {
                        Name = taxpayerName,
                        ContactInfo = taxpayerContactInfo,
                        Street = taxpayerStreet,
                        Tin = taxpayerTin,
                    };

                    provincesModels.Add(provincesModel);
                    taxpayersModels.Add(taxpayersModel);
                    taxpayerTypeModels.Add(taxpayerTypeModel);
                    actualUseCodeModels.Add(actualUseCodesModel);
                    classificationCodeModels.Add(classificationCodesModel);

                }

                //AccFactory.RealPropertiesRepository().SynchronizeData(realPropertiesModels, actualUseCodeModels, classificationCodeModels, provincesModels, taxpayerTypeModels, taxpayersModels);
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
