using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmTaxPayersSearch : Form
    {
        public frmTaxPayersSearch()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
        }

        private void frmTaxPayersSearch_Load(object sender, EventArgs e)
        {
            LoadTaxpayer();
        }

        internal void LoadTaxpayer()
        {
            try
            {
                var dtTaxpayersRecords = AccFactory.TaxpayersRepository().GetRecords();
                HelperLoadRecords.TaxpayerDatagridView(dgTaxpayers, TaxpayerDataTable(dtTaxpayersRecords));
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadTaxpayersBySearch()
        {
            if (txtSearch.Text.Length < 2)
                return;
            

            try
            {
                var textSearch = txtSearch.Text.Trim();
                var dtTaxpayersRecords = AccFactory.TaxpayersRepository().GetRecordsBySearch(textSearch);
                HelperLoadRecords.TaxpayerDatagridView(dgTaxpayers, TaxpayerDataTable(dtTaxpayersRecords));
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable TaxpayerDataTable(DataTable dtTaxpayersRecords)
        {
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("tin", typeof(string)),
                new DataColumn("name", typeof(string)),
                new DataColumn("type", typeof(string)),
                new DataColumn("contact_info", typeof(string)),
                new DataColumn("street", typeof(string)),
                new DataColumn("barangay", typeof(string)),
                new DataColumn("municipality", typeof(string)),
                new DataColumn("province", typeof(string)),
            };
            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtTaxpayersRecords.Rows)
            {
                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["id"]);
                string rowTIN = row["tin"].ToString();
                string rowName = row["name"].ToString();
                string rowType = row["type"].ToString();
                string rowContact = row["contact_info"].ToString();
                string rowStreet = row["street"].ToString();
                string rowBarangay = row["barangay"].ToString();
                string rowMunicipality = row["municipality"].ToString();
                string rowProvince = row["province"].ToString();

                newRow["id"] = rowId;
                newRow["tin"] = rowTIN;
                newRow["name"] = rowName;
                newRow["type"] = rowType;
                newRow["contact_info"] = rowContact;
                newRow["street"] = rowStreet;
                newRow["barangay"] = rowBarangay;
                newRow["municipality"] = rowMunicipality;
                newRow["province"] = rowProvince;
             
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadTaxpayer();
                return;
            }
            
            LoadTaxpayersBySearch();
        }
    }
}
