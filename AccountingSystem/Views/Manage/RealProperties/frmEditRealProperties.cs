using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmEditRealProperties : Form
    {
        private ucRealProperties uc;
        private int _realPropertiesId = 0;
        private readonly frmRealProperties _frmRealProperties;

        public frmEditRealProperties(int realPropertiesId, frmRealProperties frmRealProperties)
        {
            Helper.LoadFormIcon(this);
            _frmRealProperties = frmRealProperties;
            _realPropertiesId = realPropertiesId;
            InitializeComponent();
            uc = ucRealProperties1;
        }

        private void LoadSelectedRealProperties()
        {
            var dictRealProperties = AccFactory.RealPropertiesRepository().GetRecordByID(_realPropertiesId);

            uc.txtArpNo.Text = dictRealProperties["complete_arp_no"];
            uc.txtPropertyPin.Text = dictRealProperties["property_pin"];
            uc.txtBarangay.Text = dictRealProperties["barangay_name"];
            uc.txtMunicipality.Text = dictRealProperties["municipality_name"];
            uc.txtProvince.Text = dictRealProperties["province_name"];
            uc.cmbxPropertyKind.SelectedText = dictRealProperties["property_kind"];
            uc.nudEffectivityQuarter.Value = Convert.ToInt32(dictRealProperties["effectivity_quarter"]);
            uc.nudEffectivityYear.Value = Convert.ToInt32(dictRealProperties["effectivity_year"]);
            uc.nudAssessedValue.Value = Convert.ToDecimal(dictRealProperties["assessed_value"]);
            uc.nudGrYear.Value = Convert.ToDecimal(dictRealProperties["gr_year"]);
            uc.nudOtherImprv.Value = Convert.ToDecimal(dictRealProperties["other_improvements"]);
            uc.nudArea.Value = Convert.ToDecimal(dictRealProperties["area"]);
            uc.txtLotNo.Text = dictRealProperties["lot_no"];
            uc.txtOwnerName.Text = dictRealProperties["owner_name"];
            uc.txtOwnerTin.Text = dictRealProperties["owner_tin"];
            uc.txtOwnerAddress.Text = dictRealProperties["owner_address"];
            uc.txtOwnerContact.Text = dictRealProperties["owner_contact"];
            uc.txtClassificationCode.Text = dictRealProperties["classification_code"];
            uc.txtClassificationName.Text = dictRealProperties["classification_name"];
            uc.txtActualUseCode.Text = dictRealProperties["actual_use_code"];
            uc.txtActualUseName.Text = dictRealProperties["actual_use_name"];
            uc.chckTaxable.Checked = Convert.ToBoolean(Convert.ToByte(dictRealProperties["is_taxable"]));
            uc.chckCancelled.Checked = Convert.ToBoolean(Convert.ToByte(dictRealProperties["is_cancelled"]));
        }

        private string GetPropertyKind()
        {
            string propertyKind = uc.cmbxPropertyKind.Text.Trim();

            switch (propertyKind)
            {
                case "Land":
                    return "L";

                case "Building":
                    return "B";

                case "Machinery":
                    return "M";

                default:
                    return string.Empty;
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
                    Id = _realPropertiesId,
                    PropertyIdentifier = AccFactory.RealPropertiesRepository().GetLastInsertedId(),
                    CompleteArpNo = uc.txtArpNo.Text.Trim(),
                    Pin = uc.txtPropertyPin.Text.Trim(),
                    OwnerName = uc.txtOwnerName.Text.Trim(),
                    OwnerTin = uc.txtOwnerTin.Text.Trim(),
                    OwnerAddress = uc.txtOwnerAddress.Text.Trim(),
                    OwnerContact = uc.txtOwnerContact.Text.Trim(),
                    BarangayName = uc.txtBarangay.Text.Trim(),
                    MunicipalityName = uc.txtMunicipality.Text.Trim(),
                    ProvinceName = uc.txtProvince.Text.Trim(),
                    PropertyKind = GetPropertyKind(),
                    EffectivityQuarter = (int)uc.nudEffectivityQuarter.Value,
                    EffectivityYear = (int)uc.nudEffectivityYear.Value,
                    OtherImprovements = uc.nudOtherImprv.Value,
                    AssessedValue = uc.nudAssessedValue.Value,
                    Area = uc.nudArea.Value,
                    LotNo = uc.txtLotNo.Text.Trim(),
                    ClassificationCode = uc.txtClassificationCode.Text.Trim(),
                    ClassificationName = uc.txtClassificationName.Text.Trim(),
                    ActualUseCode = uc.txtActualUseCode.Text.Trim(),
                    ActualUseName = uc.txtActualUseName.Text.Trim(),
                    GrYear = (int)uc.nudGrYear.Value,
                    IsTaxable = uc.chckTaxable.Checked,
                    IsCancelled = uc.chckCancelled.Checked
                };

                return AccFactory.RealPropertiesRepository().Update(realPropertiesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Real Property has been updated.");
                _frmRealProperties.LoadRealProperties();
                Close();
            }
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
            uc.realPropertiesId = _realPropertiesId;
            LoadSelectedRealProperties();
        }
    }
}