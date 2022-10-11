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
        private frmTaxPayers _frmTaxPayers;

        public frmTaxPayersSearch(frmTaxPayers frmTaxPayers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
            _frmTaxPayers = frmTaxPayers;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectTaxPayer();
        }

        private void dgTaxpayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectTaxPayer();
        }

        private void SelectTaxPayer()
        {
            int rowIndex = dgTaxpayers.CurrentCell.RowIndex;
            var ucTaxPayers = _frmTaxPayers.uc;

            ucTaxPayers.taxPayerId = Convert.ToInt32(dgTaxpayers.Rows[rowIndex].Cells["id"].Value);
            var tin = dgTaxpayers.Rows[rowIndex].Cells["tin"].Value.ToString();
            var name = dgTaxpayers.Rows[rowIndex].Cells["name"].Value.ToString();
            var type = dgTaxpayers.Rows[rowIndex].Cells["type"].Value.ToString();
            var contactInfo = dgTaxpayers.Rows[rowIndex].Cells["contact_info"].Value.ToString();
            var street = dgTaxpayers.Rows[rowIndex].Cells["street"].Value.ToString();
            var barangay = dgTaxpayers.Rows[rowIndex].Cells["barangay"].Value.ToString();
            var municipality = dgTaxpayers.Rows[rowIndex].Cells["municipality"].Value.ToString();
            var province = dgTaxpayers.Rows[rowIndex].Cells["province"].Value.ToString();

            ucTaxPayers.txtTIN.Text = tin;
            ucTaxPayers.txtName.Text = name;
            ucTaxPayers.cmbxTaxPayerType.Text = type;
            ucTaxPayers.txtContact.Text = contactInfo;
            ucTaxPayers.txtStreet.Text = street;
            ucTaxPayers.txtBarangay.Text = barangay;
            ucTaxPayers.txtMunicipality.Text = municipality;
            ucTaxPayers.txtProvince.Text = province;

            _frmTaxPayers.btnSave.Text = "Update";
            _frmTaxPayers.uc.isEdit = true;
            _frmTaxPayers.uc.tabPage1.Enabled = true;
            _frmTaxPayers.btnCancel.Enabled = true;

            _frmTaxPayers.uc.LoadProperties();
            Close();
        }
    }
}
