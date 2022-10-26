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
                    string realTaxpayerTin = row["real_owner_tin"].ToString();
                    string realTaxpayerName = row["real_owner_name"].ToString();
                    string realTaxpayerStreet = row["real_owner_street"].ToString();
                    string realTaxpayerBarangay = row["real_owner_barangay"].ToString();
                    string realTaxpayerMunicipality = row["real_owner_municipality"].ToString();
                    string realTaxpayerProvince = row["real_owner_province"].ToString();
                    string realTaxpayerContactInfo = row["real_owner_contact_info"].ToString();
                    string realTaxpayerTypeCode = row["real_owner_type_code"].ToString();
                    string realTaxpayerType = row["real_owner_type"].ToString();
                    int taxpayerTypeId = AccFactory.TaxpayerTypeRepository().GetIdByName(realTaxpayerType);

                    string taxpayerTin = row["owner_tin"].ToString();
                    string taxpayerName = row["owner_name"].ToString();
                    string taxpayerAddress = row["owner_address"].ToString();
                    string taxpayerContactInfo = row["owner_contact"].ToString();

                    string completeArpNo = row["complete_arp_no"].ToString();
                    decimal propertyLandArea = Convert.ToDecimal(row["land_area"]);
                    decimal propertyAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    string propertyKind = row["property_kind"].ToString();
                    string propertyLotNo = row["land_lot_no"].ToString();
                    string propertyPin = row["pin"].ToString();
                    string propertyStreet = row["street"].ToString();
                    int propertyEffectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                    int propertyEffectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    int propertyGrYear = Convert.ToInt32(row["gryear"]);
                    decimal propertyOtherImprovements = Convert.ToDecimal(row["other_improvements"]);
                    bool propertyIsCancelled = Convert.ToBoolean(Convert.ToByte(row["is_cancelled"]));
                    bool propertyIsTaxable = Convert.ToBoolean(Convert.ToByte(row["is_taxable"]));

                    string provinceCode = row["provinces_code"].ToString();
                    string provinceName = row["provinces_name"].ToString();
                    string municipalitiesCode = row["municipalities_code"].ToString();
                    string municipalitiesName = row["municipality_name"].ToString();
                    string barangaysCode = row["barangays_code"].ToString();
                    string barangaysName = row["barangays_name"].ToString();
                    string actualUseCode = row["actual_use_code"].ToString();
                    string actualUseName = row["actual_use_name"].ToString();
                    string classificationCode = row["classification_code"].ToString();
                    string classificationName = row["classification_name"].ToString();
                    bool actualUseIsGovernment = Convert.ToBoolean(Convert.ToByte(row["actual_use_is_government"]));
                    bool classificationIsSpecial = Convert.ToBoolean(Convert.ToByte(row["classfication_is_special"]));

                    int provinceId;
                    int municipalityId;
                    int barangayId;
                    int actualUseId;
                    int classificationId;
                    int realTaxpayersId;
                    int realTaxpayerTypeId;

                    #region PROVINCE
                    if (AccFactory.ProvincesRepository().NameExist(provinceName))
                        provinceId = AccFactory.ProvincesRepository().GetIdByName(provinceName);
                    else
                    {
                        var provincesModel = new ProvincesModel()
                        {
                            Code = provinceCode,
                            Name = provinceName
                        };

                        _ = AccFactory.ProvincesRepository().Insert(provincesModel);
                        provinceId = AccFactory.ProvincesRepository().GetLastInsertedId();
                    }

                    #endregion

                    #region MUNICIPALITY
                    if (AccFactory.MunicipalitiesRepository().NameExistByProvinceName(municipalitiesName, provinceName))
                        municipalityId = AccFactory.MunicipalitiesRepository().GetIdByNameProvinceName(municipalitiesName, provinceName);
                    else
                    {
                        var municipalitiesModel = new MunicipalitiesModel()
                        {
                            ProvincesId = provinceId,
                            Code = municipalitiesCode,
                            Name = municipalitiesName,
                        };

                        _ = AccFactory.MunicipalitiesRepository().Insert(municipalitiesModel);
                        municipalityId = AccFactory.MunicipalitiesRepository().GetLastInsertedId();
                    }
                    #endregion

                    #region BARANGAY
                    if (AccFactory.BarangayRepository().NameExistByMunicipalitiesName_ProvincesName(barangaysName, municipalitiesName, provinceName))
                        barangayId = AccFactory.BarangayRepository().GetIdByName_MunicipalitiesName_ProvincesName(barangaysName, municipalitiesName, provinceName);
                    else
                    {
                        var barangaysModel = new BarangayModel()
                        {
                            MunicipalityID = municipalityId,
                            Code = row["barangays_code"].ToString(),
                            Name = row["barangays_name"].ToString()
                        };

                        _ = AccFactory.BarangayRepository().Insert(barangaysModel);
                        barangayId = AccFactory.BarangayRepository().GetLastInsertedId();
                    }
                    #endregion

                    #region ACTUAL USE
                    if (AccFactory.ActualUseCodesRepository().NameExist(actualUseName))
                        actualUseId = AccFactory.ActualUseCodesRepository().GetIdByName(actualUseName);
                    else
                    {
                        var actualUseCodesModel = new ActualUseCodesModel()
                        {
                            Code = actualUseCode,
                            Name = actualUseName,
                            IsGovernment = actualUseIsGovernment
                        };

                        _ = AccFactory.ActualUseCodesRepository().Insert(actualUseCodesModel);
                        actualUseId = AccFactory.ActualUseCodesRepository().GetLastInsertedId();
                    }
                    #endregion

                    #region CLASSIFICATION
                    if (AccFactory.ClassificationCodesRepository().NameExist(classificationName))
                        classificationId = AccFactory.ClassificationCodesRepository().GetIdByName(classificationName);
                    else
                    {
                        var classificationCodesModel = new ClassificationCodesModel()
                        {
                            Code = classificationCode,
                            Name = classificationName,
                            IsSpecial = classificationIsSpecial
                        };

                        _ = AccFactory.ClassificationCodesRepository().Insert(classificationCodesModel);
                        classificationId = AccFactory.ClassificationCodesRepository().GetLastInsertedId();
                    }
                    #endregion

                    #region TAXPAYER TYPE
                    if (AccFactory.TaxpayerTypeRepository().NameExist(realTaxpayerType))
                        realTaxpayerTypeId = Convert.ToInt32(AccFactory.TaxpayerTypeRepository().GetIdByName(realTaxpayerType));
                    else
                    {
                        var taxpayerTypeModel = new TaxpayerTypeModel()
                        {
                            Code = realTaxpayerTypeCode,
                            taxpayerType = realTaxpayerType
                        };

                        _ = AccFactory.TaxpayerTypeRepository().Insert(taxpayerTypeModel);
                        realTaxpayerTypeId = AccFactory.TaxpayerTypeRepository().GetLastInsertedId();
                    }
                    #endregion

                    #region REAL PROPERTIES

                    if (AccFactory.RealPropertiesRepository().CompleteArpNoExist(completeArpNo))
                    {
                        int realPropertiesId = AccFactory.RealPropertiesRepository().GetIdByCompleteArpNo(completeArpNo);
                        var dictRealProperties = AccFactory.RealPropertiesRepository().GetRecordByID(realPropertiesId);
                        realTaxpayersId = Convert.ToInt32(dictRealProperties["real_taxpayers_id"]);


                        //UPDATE TAXPAYER 
                        var taxpayersModel = new TaxpayersModel()
                        {
                            Id = realTaxpayersId,
                            Name = realTaxpayerName,
                            Tin = realTaxpayerTin,
                            Street = realTaxpayerStreet,
                            Barangay = realTaxpayerBarangay,
                            Municipality = realTaxpayerMunicipality,
                            Province = realTaxpayerProvince,
                            ContactInfo = realTaxpayerContactInfo,
                            TaxpayerTypeId = realTaxpayerTypeId,
                            UpdatedBy = Helper.UserId
                        };

                        _ = AccFactory.TaxpayersRepository().Update(taxpayersModel);

                        //UPDATE REAL PROPERTY
                        var realPropertiesModel = new RealPropertiesModel()
                        {
                            Id = realPropertiesId,
                            CompleteArpNo = completeArpNo,
                            PropertyPin = propertyPin,
                            Street = propertyStreet,
                            TaxpayerTin = taxpayerTin,
                            TaxpayerName = taxpayerName,
                            TaxpayerAddress = taxpayerAddress,
                            TaxpayerContactInfo = taxpayerContactInfo,
                            PropertyKind = propertyKind,
                            OtherImprovements = propertyOtherImprovements,
                            Area = propertyLandArea,
                            AssessedValue = propertyAssessedValue,
                            EffectivityQuarter = propertyEffectivityQuarter,
                            EffectivityYear = propertyEffectivityYear,
                            LotNo = propertyLotNo,
                            GrYear = propertyGrYear,
                            IsCancelled = propertyIsCancelled,
                            IsTaxable = propertyIsTaxable,
                            ActualUseCodesId = actualUseId,
                            ClassificationCodesId = classificationId,
                            BarangaysId = barangayId,
                            RealTaxpayersId = realTaxpayersId,
                            UpdatedBy = Helper.UserId
                        };
                        _ = AccFactory.RealPropertiesRepository().Update(realPropertiesModel);
                    }
                    else
                    {
                        //CHECK TAXPAYER NAME EXIST
                        if (AccFactory.TaxpayersRepository().TaxpayerNameExist(realTaxpayerName))
                            realTaxpayersId = AccFactory.TaxpayersRepository().GetIdByName(realTaxpayerName);
                        else
                        {
                            var taxpayersModel = new TaxpayersModel()
                            {
                                Tin = realTaxpayerTin,
                                Name = realTaxpayerName,
                                Street = realTaxpayerStreet,
                                Barangay = realTaxpayerBarangay,
                                Municipality = realTaxpayerMunicipality,
                                Province = realTaxpayerProvince,
                                ContactInfo = realTaxpayerContactInfo,
                                TaxpayerTypeId = realTaxpayerTypeId,
                                IsActive = true,
                                CreatedBy = Helper.UserId,
                            };

                            _ = AccFactory.TaxpayersRepository().Insert(taxpayersModel);
                            realTaxpayersId = AccFactory.TaxpayersRepository().GetLastInsertedId();
                        }

                        //INSERT REAL PROPERTIES
                        var realPropertiesModel = new RealPropertiesModel()
                        {
                            CompleteArpNo = completeArpNo,
                            PropertyPin = propertyPin,
                            Street = propertyStreet,
                            TaxpayerTin = taxpayerTin,
                            TaxpayerName = taxpayerName,
                            TaxpayerAddress = taxpayerAddress,
                            TaxpayerContactInfo = taxpayerContactInfo,
                            PropertyKind = propertyKind,
                            OtherImprovements = propertyOtherImprovements,
                            Area = propertyLandArea,
                            AssessedValue = propertyAssessedValue,
                            EffectivityQuarter = propertyEffectivityQuarter,
                            EffectivityYear = propertyEffectivityYear,
                            LotNo = propertyLotNo,
                            GrYear = propertyGrYear,
                            IsCancelled = propertyIsCancelled,
                            IsTaxable = propertyIsTaxable,
                            ActualUseCodesId = actualUseId,
                            ClassificationCodesId = classificationId,
                            BarangaysId = barangayId,
                            RealTaxpayersId = realTaxpayersId,
                            CreatedBy = Helper.UserId
                        };

                        _ = AccFactory.RealPropertiesRepository().Insert(realPropertiesModel);
                    }

                    #endregion
                }
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
