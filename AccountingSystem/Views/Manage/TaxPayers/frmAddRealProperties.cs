using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmAddRealProperties : Form
    {
        internal readonly ucRealProperties uc;
        internal readonly ucTaxPayers _ucTaxpayer;
        internal int _taxPayerId = 0;

        public frmAddRealProperties(ucTaxPayers ucTaxPayer)
        {
            InitializeComponent();
            uc = ucvRealProperties1;
            _ucTaxpayer = ucTaxPayer;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InsertRealProperties())
            {
                Helper.MessageBoxSuccess("Taxpayer Property has been saved.");
                _ucTaxpayer.LoadProperties();
            }
        }

        private bool InsertRealProperties()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormError());
                return false;
            }

            var realPropertiesModel = new RealPropertiesModel()
            {
                CompleteArpNo = uc.txtArpNo.Text,
                TaxpayersId = _ucTaxpayer.taxPayerId,
                Pin = uc.txtPropertyPin.Text,
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

            return AccFactory.RealPropertiesRepository().Insert(realPropertiesModel);
                
        }
    }
}
