using LFS.Helpers;
using OmniGov.Core.Entities;
using PropertyAssessment.Data.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.DatabaseSynchronization
{
    public partial class frmDatabaseSynchronization : Form
    {
        private ucDatabaseSynchronization uc;

        public frmDatabaseSynchronization()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucDatabaseSynchronization1;
            uc.lblProgressStatus.Text = string.Empty;
            uc.lblProgressStatus.Visible = false;
            uc.progressBar1.Visible = false;
        }

        private void frmDatabaseSynchronization_Load(object sender, EventArgs e)
        {
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerRptSync.IsBusy)
                {
                    uc.lblProgressStatus.Visible = true;
                    uc.progressBar1.Visible = true;
                    backgroundWorkerRptSync.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        #region Database Sync Progresses

        private void backgroundWorkerRptSync_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var dtRealProperties = PropertyAssessmentFactory.RealPropertiesRepository().GetViewLFSRealPropertiesRecords();
                int totalProgressCount = dtRealProperties.Rows.Count;
                int progressCount = 0;
                int remainingItems = dtRealProperties.Rows.Count;

                foreach (DataRow row in dtRealProperties.Rows)
                {
                    if (backgroundWorkerRptSync.CancellationPending)
                    {
                        e.Result = "cancelled";
                        break;
                    }

                    int realPropertiesId = Convert.ToInt32(row["real_properties_id"]);
                    string realPropertiesIdentifier = row["real_properties_identifier"].ToString();
                    string realTaxpayerTin = row["real_owner_tin"].ToString();
                    string realTaxpayerName = row["real_owner_name"].ToString().ToUpper();
                    string realTaxpayerStreet = row["real_owner_street"].ToString();
                    string realTaxpayerBarangay = row["real_owner_barangay"].ToString();
                    string realTaxpayerMunicipality = row["real_owner_municipality"].ToString();
                    string realTaxpayerProvince = row["real_owner_province"].ToString();
                    string realTaxpayerContactInfo = row["real_owner_contact_info"].ToString();
                    string realTaxpayerTypeCode = row["real_owner_type_code"].ToString();
                    string realTaxpayerType = row["real_owner_type"].ToString();

                    string taxpayerTin = row["owner_tin"].ToString();
                    string taxpayerName = row["owner_name"].ToString();
                    string taxpayerAddress = row["owner_address"].ToString();
                    string taxpayerContactInfo = row["owner_contact"].ToString();

                    string completeArpNo = row["complete_arp_no"].ToString();
                    decimal propertyLandArea = Convert.ToDecimal(row["land_area"]);
                    decimal propertyAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                    char propertyKind = row["property_kind"].ToString()[0];
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
                    bool classificationIsSpecial = Convert.ToBoolean(Convert.ToByte(row["classification_is_special"]));

                    //RPT Previous Assessment
                    var dictPreviousAssessment = PropertyAssessmentFactory.PreviousAssessmentRepository().GetRecordByRealPropertiesId(realPropertiesId);
                    string prevAssessmentCompleteArpNo = dictPreviousAssessment["arp_no"].ToString();
                    string prevAssessmentPin = dictPreviousAssessment["pin"].ToString();
                    string prevAssessmentOwner = dictPreviousAssessment["previous_owner"].ToString();
                    string prevAssessmentEffectivity = dictPreviousAssessment["effectivity_assessment"].ToString();
                    string prevAssessmentRecordingPerson = dictPreviousAssessment["recording_person"].ToString();
                    decimal prevAssessmentAssessedValue = Convert.ToDecimal(dictPreviousAssessment["assessed_value"]);
                    string prevAssessmentDateRecorded = dictPreviousAssessment["date_recorded"].ToString();

                    //RPT Property Identifier
                    string propertyIdentifierCompleteArpNo = string.Empty;

                    //if (!string.IsNullOrEmpty(realPropertiesIdentifier))
                    //{
                    //    var dictFindPropertyIdentifier = RptFactory.RealPropertiesRepository().GetViewLFSRealPropertiesRecordById(Convert.ToInt32(realPropertiesIdentifier));
                    //    propertyIdentifierCompleteArpNo = dictFindPropertyIdentifier["complete_arp_no"];
                    //}

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

                    var taxpayerTypeModel = new TaxpayerTypeModel()
                    {
                        Code = realTaxpayerTypeCode,
                        taxpayerType = realTaxpayerType
                    };

                    var taxpayersModel = new TaxpayersModel()
                    {
                        Name = realTaxpayerName,
                        Tin = realTaxpayerTin,
                        Address = realTaxpayerStreet,
                        Municipality = realTaxpayerMunicipality,
                        Province = realTaxpayerProvince,
                        ContactInfo = realTaxpayerContactInfo,
                        CreatedBy = UserHelper.loggedUser.Id,
                        UpdatedBy = UserHelper.loggedUser.Id
                    };

                    var barangayModel = new BarangayModel()
                    {
                        Code = barangaysCode,
                        Name = barangaysName,
                    };

                    var municipalitiesModel = new MunicipalitiesModel()
                    {
                        Code = municipalitiesCode,
                        Name = municipalitiesName,
                    };

                    var provincesModel = new ProvincesModel()
                    {
                        Code = provinceCode,
                        Name = provinceName,
                    };

                    var rptPreviousAssessmentModel = new List<RptPreviousAssessmentModel>()
                    {
                        //CompleteArpNo = prevAssessmentCompleteArpNo,
                        //PropertyPin = prevAssessmentPin,
                        //PreviousOwner = prevAssessmentOwner,
                        //EffectivityAssessment = prevAssessmentEffectivity,
                        //AssessedValue = prevAssessmentAssessedValue,
                        //DateRecorded = string.IsNullOrEmpty(prevAssessmentDateRecorded) ? null : DateTime.Parse(prevAssessmentDateRecorded)
                    };

                    var realPropertiesModel = new RealPropertiesModel()
                    {
                        CompleteArpNo = completeArpNo,
                        PropertyPin = propertyPin,
                        Street = propertyStreet,
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
                        CreatedBy = UserHelper.loggedUser.Id,
                        UpdatedBy = UserHelper.loggedUser.Id,
                        TaxpayerTypeModel = taxpayerTypeModel,
                        TaxpayersModel = taxpayersModel,
                        ProvincesModel = provincesModel,
                        MunicipalitiesModel = municipalitiesModel,
                        BarangayModel = barangayModel,
                        ActualUseCodesModel = actualUseCodesModel,
                        ClassificationCodesModel = classificationCodesModel,
                        RptPreviousAssessmentModels = rptPreviousAssessmentModel
                    };

                    TreasuryFactory.RealPropertiesRepository().Synchronize(realPropertiesModel);

                    progressCount++;
                    remainingItems--;
                    backgroundWorkerRptSync.ReportProgress((progressCount * 100) / totalProgressCount, $"Importing ARP No. {completeArpNo} | Remaining Items {remainingItems}");
                }

                if (backgroundWorkerRptSync.CancellationPending)
                {
                    e.Result = "Sync Cancelled";
                    return;
                }
            }
            catch (Exception ex)
            {
                e.Result = $"RPT Sync Failed...\n\nCause:\n{ex.Message}";
            }
        }

        private void backgroundWorkerRptSync_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            uc.progressBar1.Value = e.ProgressPercentage;
            btnSync.Enabled = false;
            btnStop.Enabled = true;
            uc.cmbxSyncType.Enabled = false;

            if (e.ProgressPercentage == 100)
            {
                uc.lblProgressStatus.Text = "Finishing Sync...";
                btnStop.Enabled = false;
                ControlBox = false;
            }
            else
                uc.lblProgressStatus.Text = $"{e.ProgressPercentage}% {e.UserState}";
        }

        private void backgroundWorkerRptSync_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
                Helper.MessageBoxSuccess("RPT synced successfully.");
            else
                Helper.MessageBoxError(e.Result.ToString());

            uc.lblProgressStatus.Text = string.Empty;
            uc.progressBar1.Value = 0;
            uc.lblProgressStatus.Visible = false;
            uc.progressBar1.Visible = false;
            ControlBox = true;
            uc.cmbxSyncType.Enabled = true;
            btnStop.Enabled = false;
            btnSync.Enabled = true;
        }

        #endregion Database Sync Progresses

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorkerRptSync.CancelAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}