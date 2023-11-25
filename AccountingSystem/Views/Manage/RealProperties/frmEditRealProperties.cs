using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.RealProperties;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmEditRealProperties : Form
    {
        private ucRealProperties uc;
        private int _propertyId;
        private int _taxpayerId;
        private frmRealProperties _frmRealProperties;

        public frmEditRealProperties(frmRealProperties frmRealProperties)
        {
            InitializeComponent();
            _frmRealProperties = frmRealProperties;
            _propertyId = frmRealProperties.realPropertiesID;
            _taxpayerId = frmRealProperties.taxpayerID;
            uc = ucRealProperties1;
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            uc._form = this;
            LoadSelectedProperty();
            LoadTaxpayer();
        }

        private void LoadSelectedProperty()
        {
            var dictRealProperties = AccFactory.RealPropertiesRepository().GetRecordByID(_propertyId);

            uc.txtArpNo.Text = dictRealProperties["complete_arp_no"];
            uc.txtPropertyPin.Text = dictRealProperties["property_pin"];
            uc.cmbxBarangays.SelectedValue = dictRealProperties["real_properties_barangays_id"];
            uc.cmbxClassification.SelectedValue = dictRealProperties["classification_codes_id"];
            uc.cmbxActualUse.SelectedValue = dictRealProperties["actual_use_codes_id"];
            uc.cmbxPropertyKind.SelectedText = dictRealProperties["property_kind"];
            uc.nudEffectivityQuarter.Text = dictRealProperties["effectivity_quarter"];
            uc.nudEffectivityYear.Text = dictRealProperties["effectivity_year"];
            uc.nudAssessedValue.Value = Convert.ToDecimal(dictRealProperties["assessed_value"]);
            uc.nudGrYear.Text = dictRealProperties["gr_year"];
            uc.nudOtherImprv.Text = dictRealProperties["other_improvements"];
            uc.nudArea.Text = dictRealProperties["area"];
            uc.txtLotNo.Text = dictRealProperties["lot_no"];
        }

        private void LoadTaxpayer()
        {
            var dictRealProperties = AccFactory.TaxpayersRepository().GetRecordByID(_taxpayerId);

            var address = $"{dictRealProperties["street"]}, {dictRealProperties["barangay"]}, {dictRealProperties["municipality"]} {dictRealProperties["province"]}";

            uc.txtTaxpayers.Text = dictRealProperties["name"];
            uc.txtTaxpayerType.Text = dictRealProperties["taxpayer_type_id"];
            uc.txtTaxpayerTIN.Text = dictRealProperties["tin"];
            uc.txtTaxpayerContact.Text = dictRealProperties["contact_info"];
            uc.txtTaxpayerAddress.Text = address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Real property has been updated.");
                    _frmRealProperties.LoadProperties();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Save()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormError());
                return false;
            }

            var realPropertiesModel = new RealPropertiesModel()
            {
                Id = _propertyId,
                RealTaxpayersId = _taxpayerId,
                CompleteArpNo = uc.txtArpNo.Text,
                ClassificationCodesId = Convert.ToInt32(uc.cmbxClassification.SelectedValue),
                ActualUseCodesId = Convert.ToInt32(uc.cmbxActualUse.SelectedValue),
                BarangaysId = Convert.ToInt32(uc.cmbxBarangays.SelectedValue),
                PropertyIdentifier = uc.propertyIdentifier,
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
                CreatedBy = Helper.UserId
            };

            return AccFactory.RealPropertiesRepository().Update(realPropertiesModel);
        }
    }
}