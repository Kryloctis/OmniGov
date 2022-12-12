using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using RPT.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmAddRealProperties : Form
    {
        private frmRealProperties _frmRealProperties;
        internal ucRealProperties uc;

        public frmAddRealProperties(frmRealProperties frmRealProperties)
        {
            InitializeComponent();
            uc = ucRealProperties1;
            _frmRealProperties = frmRealProperties;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Real property has been saved.");
                _frmRealProperties.LoadAllProperties();
                Close();
            }
        }

        private bool Save()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormError());
                    return false;
                }

                var realPropertiesModel = new RealPropertiesModel()
                {
                    CompleteArpNo = uc.txtArpNo.Text,
                    ClassificationCodesId = Convert.ToInt32(uc.cmbxClassification.SelectedValue),
                    ActualUseCodesId = Convert.ToInt32(uc.cmbxActualUse.SelectedValue),
                    BarangaysId = Convert.ToInt32(uc.cmbxBarangays.SelectedValue),
                    PropertyIdentifier = uc.propertyIdentifier,
                    RealTaxpayersId = uc.taxpayerID,
                    TaxpayerName = uc.txtTaxpayers.Text,
                    TaxpayerAddress = uc.txtTaxpayerAddress.Text, 
                    PropertyPin = uc.txtPropertyPin.Text,
                    PropertyKind = uc.cmbxPropertyKind.Text,
                    EffectivityQuarter = Convert.ToInt32(uc.nudEffectivityQuarter.Value),
                    EffectivityYear = Convert.ToInt32(uc.nudEffectivityYear.Value),
                    AssessedValue = uc.nudAssessedValue.Value,
                    GrYear = Convert.ToInt32(uc.nudGrYear.Value),
                    OtherImprovements = uc.nudOtherImprv.Value,
                    Area = Convert.ToDecimal(uc.nudArea.Value),
                    LotNo = uc.txtLotNo.Text,
                    IsTaxable = uc.chckTaxable.Checked,
                    IsCancelled = uc.chckCancelled.Checked,
                    CreatedBy  = Helper.UserId

                };

                if (uc.propertyIdentifier != "0")
                {
                    var previousAssessment = new RptPreviousAssessmentModel()
                    {
                        RealPropertiesId = AccFactory.RealPropertiesRepository().GetLastInsertedId(),
                        PropertyPin = uc.txtPreviousPin.Text,
                        CompleteArpNo = uc.cmbxCompletePreviousARPNumber.Text,
                        AssessedValue = Convert.ToDecimal(uc.txtPreviousAssessedValue.Text),
                        PreviousOwner = uc.txtPreviousOwner.Text,
                        EffectivityAssessment = uc.txtPreviousEffectivityAssessment.Text
                    };

                    return AccFactory.RealPropertiesRepository().InsertWithPreviousAssessment(realPropertiesModel, previousAssessment);

                }
                else
                    return AccFactory.RealPropertiesRepository().Insert(realPropertiesModel);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

    }
}
