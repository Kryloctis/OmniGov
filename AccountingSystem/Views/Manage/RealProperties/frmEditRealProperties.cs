using ACC.Domain.Models;
using AccountingSystem.Views.Manage.RealProperties;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmEditRealProperties : Form
    {
        private ucRealProperties _ucRealProperties;
        private int _propertyId;
        private int _taxpayerId;
        private frmRealProperties _frmRealProperties;

        public frmEditRealProperties(frmRealProperties frmRealProperties)
        {
            InitializeComponent();
            _frmRealProperties = frmRealProperties;
            _propertyId = frmRealProperties.realPropertiesID;
            _taxpayerId = frmRealProperties.taxpayerID;
            _ucRealProperties = ucRealProperties1;
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            LoadSelectedProperty();
            LoadTaxpayer();
        }

        private void LoadSelectedProperty()
        {
            var dictRealProperties = AccFactory.RealPropertiesRepository().GetRecordByID(_propertyId);

            _ucRealProperties.txtArpNo.Text = dictRealProperties["complete_arp_no"];
            _ucRealProperties.txtPropertyPin.Text = dictRealProperties["property_pin"];
            _ucRealProperties.cmbxBarangays.SelectedValue = dictRealProperties["real_properties_barangays_id"];
            _ucRealProperties.cmbxClassification.SelectedValue = dictRealProperties["classification_codes_id"];
            _ucRealProperties.cmbxActualUse.SelectedValue = dictRealProperties["actual_use_codes_id"];
            _ucRealProperties.cmbxPropertyKind.SelectedText = dictRealProperties["property_kind"];
            _ucRealProperties.nudEffectivityQuarter.Text = dictRealProperties["effectivity_quarter"];
            _ucRealProperties.nudEffectivityYear.Text = dictRealProperties["effectivity_year"];
            _ucRealProperties.nudAssessedValue.Value = Convert.ToDecimal(dictRealProperties["assessed_value"]);
            _ucRealProperties.nudGrYear.Text = dictRealProperties["gr_year"];
            _ucRealProperties.nudOtherImprv.Text = dictRealProperties["other_improvements"];
            _ucRealProperties.nudArea.Text = dictRealProperties["area"];
            _ucRealProperties.txtLotNo.Text = dictRealProperties["lot_no"];
        }

            private void LoadTaxpayer()
            {
                var dictRealProperties = AccFactory.TaxpayersRepository().GetRecordByID(_taxpayerId);

                var address = $"{dictRealProperties["street"]}, {dictRealProperties["barangay"]}, {dictRealProperties["municipality"]} {dictRealProperties["province"]}";

                _ucRealProperties.txtTaxpayers.Text = dictRealProperties["name"];
                _ucRealProperties.txtTaxpayerType.Text = dictRealProperties["taxpayer_type_id"];
                _ucRealProperties.txtTaxpayerTIN.Text = dictRealProperties["tin"];
                _ucRealProperties.txtTaxpayerContact.Text = dictRealProperties["contact_info"];
                _ucRealProperties.txtTaxpayerAddress.Text = address;
            }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Real property has been updated.");
                _frmRealProperties.LoadProperties();
                Close();
            }
        }

        private bool Save()
        {
            try
            {
                if (!_ucRealProperties.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucRealProperties.GetFormError());
                    return false;
                }

                var realPropertiesModel = new RealPropertiesModel()
                {
                    Id = _propertyId,
                    RealTaxpayersId = _taxpayerId,
                    CompleteArpNo = _ucRealProperties.txtArpNo.Text,
                    ClassificationCodesId = Convert.ToInt32(_ucRealProperties.cmbxClassification.SelectedValue),
                    ActualUseCodesId = Convert.ToInt32(_ucRealProperties.cmbxActualUse.SelectedValue),
                    BarangaysId = Convert.ToInt32(_ucRealProperties.cmbxBarangays.SelectedValue),
                    PropertyIdentifier = _ucRealProperties.propertyIdentifier,
                    TaxpayerName = _ucRealProperties.txtTaxpayers.Text,
                    TaxpayerAddress = _ucRealProperties.txtTaxpayerAddress.Text,
                    PropertyPin = _ucRealProperties.txtPropertyPin.Text,
                    PropertyKind = _ucRealProperties.cmbxPropertyKind.Text,
                    EffectivityQuarter = Convert.ToInt32(_ucRealProperties.nudEffectivityQuarter.Value),
                    EffectivityYear = Convert.ToInt32(_ucRealProperties.nudEffectivityYear.Value),
                    AssessedValue = _ucRealProperties.nudAssessedValue.Value,
                    GrYear = Convert.ToInt32(_ucRealProperties.nudGrYear.Value),
                    OtherImprovements = _ucRealProperties.nudOtherImprv.Value,
                    Area = Convert.ToDecimal(_ucRealProperties.nudArea.Value),
                    LotNo = _ucRealProperties.txtLotNo.Text,
                    IsTaxable = _ucRealProperties.chckTaxable.Checked,
                    IsCancelled = _ucRealProperties.chckCancelled.Checked,
                    CreatedBy = Helper.UserId
                };

                return AccFactory.RealPropertiesRepository().Update(realPropertiesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


    }
}
