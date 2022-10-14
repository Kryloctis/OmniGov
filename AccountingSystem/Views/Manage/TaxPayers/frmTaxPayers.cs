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
    public partial class frmTaxPayers : Form
    {
        public frmTaxPayers()
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
                new DataColumn("tax_payer_id", typeof(int)),
                new DataColumn("barangays_id", typeof(string)),
                new DataColumn("barangays_name", typeof(string)),
                new DataColumn("taxpayer_type_id", typeof(string)),
                new DataColumn("taxpayer_type", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("tin", typeof(string)),
                new DataColumn("contact_info", typeof(string)),
            };

            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtTaxpayersRecords.Rows)
            {
                var newRow = dataTable.NewRow();
                int rowTaxPayerId = Convert.ToInt32(row["tax_payer_id"]);
                string rowBarangayId = row["barangays_id"].ToString();
                string rowBarangay = row["barangays_name"].ToString();
                string rowTaxpayerTypeId = row["taxpayer_type_id"].ToString();
                string rowTaxpayerType = row["taxpayer_type"].ToString();
                string rowTIN = row["tin"].ToString();
                string rowName = row["taxpayers_name"].ToString();
                string rowContact = row["contact_info"].ToString();

                newRow["tax_payer_id"] = rowTaxPayerId;
                newRow["barangays_id"] = rowBarangayId;
                newRow["barangays_name"] = rowBarangay;
                newRow["taxpayer_type_id"] = rowTaxpayerTypeId;
                newRow["taxpayer_type"] = rowTaxpayerType;
                newRow["tin"] = rowTIN;
                newRow["taxpayers_name"] = rowName;
                newRow["contact_info"] = rowContact;
             
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddTaxpayers().ShowDialog();
        }
    }
}
