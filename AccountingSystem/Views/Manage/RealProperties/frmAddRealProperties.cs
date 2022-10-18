using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
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
    public partial class frmAddRealProperties : Form
    {
        private frmRealProperties _frmRealProperties;
        private ucRealProperties uc;

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
                Helper.MessageBoxSuccess("Real property has been updated.");
                _frmRealProperties.LoadProperties();
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
                    //Id = _propertyId,
                    CompleteArpNo = uc.txtArpNo.Text,
                    //TaxpayersId = uc.taxPayerId,
                    PropertyPin = uc.txtPropertyPin.Text,
                    BarangayName = uc.txtBarangay.Text,
                    MunicipalityName = uc.txtMunicipality.Text,
                    ProvinceName = uc.txtProvince.Text,
                    PropertyKind = uc.cmbxPropertyKind.Text,
                    EffectivityQuarter = Convert.ToInt32(uc.nudEffectivityQuarter.Value),
                    EffectivityYear = Convert.ToInt32(uc.nudEffectivityYear.Value),
                    AssessedValue = uc.nudAssessedValue.Value,
                    GrYear = Convert.ToInt32(uc.nudGrYear.Value),
                    OtherImprovements = uc.nudOtherImprv.Value,
                    Area = Convert.ToDecimal(uc.nudArea.Value),
                    LotNo = uc.txtLotNo.Text,
                    ClassificationCode = uc.txtClassificationCode.Text,
                    ClassificationName = uc.txtClassificationName.Text,
                    ActualUseCode = uc.txtActualUseCode.Text,
                    ActualUseName = uc.txtActualUseName.Text,
                    IsTaxable = uc.chckTaxable.Checked,
                    IsCancelled = uc.chckCancelled.Checked,
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
