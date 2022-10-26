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

                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, RealPropertiesDataTable(dtRealProperties));
                dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable RealPropertiesDataTable(DataTable dtRealProperties)
        {
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("property_identifier", typeof(string)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("barangay_name", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("assessed_value", typeof(string)),
                new DataColumn("municipality_name", typeof(string)),
                new DataColumn("province_name", typeof(string)),
            };
            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtRealProperties.Rows)
            {

                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["id"]);
                string rowPropertyIdentifier = row["property_identifier"].ToString();
                string completeArpNumber = row["complete_arp_no"].ToString();
                string propertyPin = row["property_pin"].ToString();
                string barangayName = row["barangay_name"].ToString();
                string propertyKind = row["property_kind"].ToString();
                string assessedValue = row["assessed_value"].ToString();
                string municipalityName = row["municipality_name"].ToString();
                string provinceName = row["province_name"].ToString();

                newRow["id"] = rowId;
                newRow["property_identifier"] = rowPropertyIdentifier;
                newRow["complete_arp_no"] = completeArpNumber;
                newRow["property_pin"] = propertyPin;
                newRow["barangay_name"] = barangayName;
                newRow["property_kind"] = propertyKind;
                newRow["assessed_value"] = assessedValue;
                newRow["municipality_name"] = municipalityName;
                newRow["province_name"] = provinceName;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }
    }
}
