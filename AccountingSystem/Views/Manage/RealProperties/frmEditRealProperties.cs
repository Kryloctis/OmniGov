using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmEditRealProperties : Form
    {
        internal ucRealProperties _ucRealProperties;
        internal ucTaxPayers _ucTaxpayers;
        private int _propertyId;

        public frmEditRealProperties(int propertyId, ucTaxPayers ucTaxpayers)
        {
            InitializeComponent();
            _ucTaxpayers = ucTaxpayers;
            _propertyId = propertyId;
            _ucRealProperties = ucRealProperties1;
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            LoadSelectedProperty();
        }

        private void LoadSelectedProperty()
        {
            var dictRealProperties = AccFactory.RealPropertiesRepository().GetRecordByID(_propertyId);

            _ucRealProperties.txtArpNo.Text = dictRealProperties["complete_arp_no"];
            _ucRealProperties.txtPropertyPin.Text = dictRealProperties["property_pin"];
            _ucRealProperties.txtPropertyPin.Text = dictRealProperties["property_kind"];
            _ucRealProperties.nudEffectivityQuarter.Text = dictRealProperties["effectivity_quarter"];
            _ucRealProperties.nudEffectivityYear.Text = dictRealProperties["effectivity_year"];
            _ucRealProperties.nudGrYear.Text = dictRealProperties["gr_year"];
            _ucRealProperties.nudOtherImprv.Text = dictRealProperties["other_improvements"];
            _ucRealProperties.nudArea.Text = dictRealProperties["area"];
            _ucRealProperties.txtLotNo.Text = dictRealProperties["lot_no"];
            _ucRealProperties.chckTaxable.Checked = Convert.ToBoolean(int.Parse(dictRealProperties["is_taxable"]));
            _ucRealProperties.chckCancelled.Checked = Convert.ToBoolean(int.Parse(dictRealProperties["is_cancelled"]));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Real property has been updated.");
                //_ucTaxpayers.LoadProperties();
                Close();
            }
        }

        private bool Save()
        {
            try
            {
                if (!_ucTaxpayers.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucTaxpayers.GetFormErrors());
                    return false;
                }

                var realPropertiesModel = new RealPropertiesModel()
                {
                    Id = _propertyId,
                    CompleteArpNo = _ucRealProperties.txtArpNo.Text,
                    TaxpayersId = _ucTaxpayers.taxPayerId,
                    PropertyPin = _ucRealProperties.txtPropertyPin.Text,
                    PropertyKind = _ucRealProperties.cmbxPropertyKind.Text,
                    EffectivityQuarter = Convert.ToInt32(_ucRealProperties.nudEffectivityQuarter.Value),
                    EffectivityYear = Convert.ToInt32(_ucRealProperties.nudEffectivityYear.Value),
                    AssessedValue = _ucRealProperties.nudAssessedValue.Value,
                    GrYear = Convert.ToInt32(_ucRealProperties.nudGrYear.Value),
                    OtherImprovements = _ucRealProperties.nudOtherImprv.Value,
                    Area = Convert.ToDecimal(_ucRealProperties.nudArea.Value),
                    LotNo = _ucRealProperties.txtLotNo.Text,

                    IsCancelled = _ucRealProperties.chckCancelled.Checked,
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
