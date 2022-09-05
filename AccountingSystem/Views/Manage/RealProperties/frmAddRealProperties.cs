using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmAddRealProperties : Form
    {
        private ucRealProperties uc;
        private readonly frmRealProperties _frmRealProperties;

        public frmAddRealProperties(frmRealProperties frmRealProperties)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            uc = ucRealProperties1;
            _frmRealProperties = frmRealProperties;
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
                    PropertyKind = uc.cmbxPropertyKind.Text.Trim(),
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

               return AccFactory.RealPropertiesRepository().Insert(realPropertiesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Real Property has been saved.");
                _frmRealProperties.LoadRealProperties();
                uc.ResetForm();
            }
        }

        private void frmAddRealProperties_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }
    }
}