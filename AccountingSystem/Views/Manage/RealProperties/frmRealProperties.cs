using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        internal void LoadProperties()
        {
            try
            {
                var dtRealProperties = AccFactory.RealPropertiesRepository().GetRecords();
                //HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, RealPropertiesDataTable(dtRealProperties));
                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, dtRealProperties);
                dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable RealPropertiesDataTable(DataTable dtRealProperties)
        {
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("real_properties_id", typeof(int)),
                new DataColumn("property_identifier", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("taxpayer_name", typeof(string)),
                new DataColumn("real_properties_municipalities_name", typeof(string)),
                new DataColumn("real_properties_provinces_name", typeof(string)),
                new DataColumn("classification_codes_name", typeof(string)),
                new DataColumn("actual_use_codes_name", typeof(string)),
                new DataColumn("other_improvements", typeof(string)),
                new DataColumn("assessed_value", typeof(string)),
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("is_cancelled", typeof(bool)),
            };
            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtRealProperties.Rows)
            {

                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["real_properties_id"]);
                string rowPropertyIdentifier = row["property_identifier"].ToString();
                string completeArpNumber = row["complete_arp_no"].ToString();
                string propertyPin = row["property_pin"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string propertyKind = row["property_kind"].ToString();
                string assessedValue = row["assessed_value"].ToString();
                string municipalityName = row["municipality_name"].ToString();
                string provinceName = row["province_name"].ToString();

                bool isTaxable = Convert.ToBoolean(row["is_taxable"]);
                bool isCancelled = Convert.ToBoolean(row["is_cancelled"]);

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

    }
}
