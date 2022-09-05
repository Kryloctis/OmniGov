using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            uc = ucRealProperties1;
            InitializeComponent();
        }

        private void ucRealProperties1_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
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
            if(Save())
            {
                Helper.MessageBoxSuccess("Real Property has been updated.");
                _frmRealProperties.LoadRealProperties();
                Close();
            }
        }
    }
}
