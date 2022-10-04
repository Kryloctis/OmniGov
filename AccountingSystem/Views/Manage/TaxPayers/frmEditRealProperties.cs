using RPT.Data;
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
            _ucRealProperties.txtBarangay.Text = dictRealProperties["barangay_name"];
            _ucRealProperties.txtMunicipality.Text = dictRealProperties["municipality_name"];
            _ucRealProperties.txtProvince.Text = dictRealProperties["province_name"];
            _ucRealProperties.txtPropertyPin.Text = dictRealProperties["property_kind"];
            _ucRealProperties.nudEffectivityQuarter.Text = dictRealProperties["effectivity_quarter"];
            _ucRealProperties.nudEffectivityYear.Text = dictRealProperties["effectivity_year"];
            _ucRealProperties.nudGrYear.Text = dictRealProperties["gr_year"];
            _ucRealProperties.nudOtherImprv.Text = dictRealProperties["other_improvements"];
            _ucRealProperties.nudArea.Text = dictRealProperties["area"];
            _ucRealProperties.txtLotNo.Text = dictRealProperties["lot_no"];

            _ucRealProperties.chckTaxable.Checked = Convert.ToBoolean(int.Parse(dictRealProperties["is_taxable"]));
            _ucRealProperties.chckCancelled.Checked = Convert.ToBoolean(int.Parse(dictRealProperties["is_cancelled"]));

            _ucRealProperties.txtClassificationCode.Text = dictRealProperties["classification_code"];
            _ucRealProperties.txtClassificationName.Text = dictRealProperties["classification_name"];

            _ucRealProperties.txtActualUseCode.Text = dictRealProperties["actual_use_code"];
            _ucRealProperties.txtActualUseName.Text = dictRealProperties["actual_use_name"];

        }


    }
}
