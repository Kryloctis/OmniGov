using AccountingSystem.Views.Manage.Barangay;
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
    public partial class frmTaxpayers : Form
    {
        public frmTaxpayers()
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
            try
            {
                DataTable dtTaxpayers;
                var textSearch = txtSearch.Text.Trim();

                if (txtSearch.Text.Length < 2)
                    dtTaxpayers = AccFactory.TaxpayersRepository().GetRecords();
                else
                    dtTaxpayers = AccFactory.TaxpayersRepository().GetRecordsBySearch(textSearch);

                HelperLoadRecords.TaxpayerDatagridView(dgTaxpayers, TaxpayerDataTable(dtTaxpayers));
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            }


            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable TaxpayerDataTable(DataTable dtTaxpayers)
        {
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("name", typeof(string)),
                new DataColumn("taxpayer_type", typeof(string)),
                new DataColumn("barangays_id", typeof(int)),
                new DataColumn("barangay_code", typeof(string)),
                new DataColumn("barangay_name", typeof(string)),
                new DataColumn("municipalities_id", typeof(int)),
                new DataColumn("municipalities_code", typeof(string)),
                new DataColumn("municipalities_name", typeof(string)),
                new DataColumn("provinces_id", typeof(int)),
                new DataColumn("provinces_code", typeof(string)),
                new DataColumn("provinces_name", typeof(string)),
                new DataColumn("taxpayer_type_id", typeof(int)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("tin", typeof(string)),
                new DataColumn("contact_info", typeof(string)),
                new DataColumn("is_active", typeof(bool)),
            };

            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtTaxpayers.Rows)
            {
                var newRow = dataTable.NewRow();

                int rowTaxpayerId = Convert.ToInt32(row["id"]);
                string rowName = row["name"].ToString();
                string rowTaxpayerType = row["taxpayer_type"].ToString();
                int rowBarangaysId = Convert.ToInt32(row["barangays_id"]);
                string rowBarangaCode = row["barangay_code"].ToString();
                string rowBarangayName = row["barangay_name"].ToString();
                int rowMunicipalitiesId = Convert.ToInt32(row["municipalities_id"]);
                string rowMunicipalitiesCode = row["municipalities_code"].ToString();
                string rowMunicipalitiesName = row["municipalities_name"].ToString();
                int rowProvincesId = Convert.ToInt32(row["provinces_id"]);
                string rowProvincesName = row["provinces_name"].ToString();
                int rowTaxpayerTypeId = Convert.ToInt32(row["taxpayer_type_id"]);
                string rowTaxpayerTypeCode = row["taxpayer_type_code"].ToString();
                string rowTin = row["tin"].ToString();
                string rowContactInfo = row["contact_info"].ToString();
                bool rowIsActive = Convert.ToBoolean(row["is_active"]);

                newRow["id"] = rowTaxpayerId;
                newRow["name"] = rowName;
                newRow["taxpayer_type"] = rowTaxpayerType;
                newRow["barangays_id"] = rowBarangaysId;
                newRow["barangay_code"] = rowBarangaCode;
                newRow["barangay_name"] = rowBarangayName;
                newRow["municipalities_id"] = rowMunicipalitiesId;
                newRow["municipalities_code"] = rowMunicipalitiesCode;
                newRow["municipalities_name"] = rowMunicipalitiesName;
                newRow["provinces_id"] = rowProvincesId;
                newRow["provinces_name"] = rowProvincesName;
                newRow["taxpayer_type_id"] = rowTaxpayerTypeId;
                newRow["taxpayer_type_code"] = rowTaxpayerTypeCode;
                newRow["tin"] = rowTin;
                newRow["contact_info"] = rowContactInfo;
                newRow["is_active"] = rowIsActive;

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private void ShowEditForm()
        {
            var taxpayerId = Convert.ToInt32(dgTaxpayers.SelectedRows[0].Cells["id"].Value);
            _ = new frmEditTaxpayers(taxpayerId, this).ShowDialog();

        }
    }
}
