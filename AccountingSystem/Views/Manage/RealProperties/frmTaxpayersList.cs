using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmTaxpayersList : Form
    {
        private readonly ucRealProperties _ucRealProperties;

        public frmTaxpayersList(ucRealProperties ucRealProperties)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
            _ucRealProperties = ucRealProperties;
        }

        private void frmTaxpayersList_Load(object sender, EventArgs e)
        {
            LoadTaxpayerList();
        }

        private void LoadTaxpayerList()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.TaxPayerListDatagridView(dgTaxpayers, DataTableTaxpayerList(searchText));
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableTaxpayerList(string searchText)
        {
            var columns = new string[] { "taxpayers_id", "taxpayers_name", "taxpayer_type", "taxpayers_tin", "taxpayers_contact_info", "taxpayers_barangay", "taxpayers_street", "taxpayers_municipality", "taxpayers_province" };

            var dtTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordsBySearch(searchText);
            var dtView = new DataView(dtTaxpayer);
            return dtView.ToTable(false, columns);
        }

        private void dgTaxpayers_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void EnableDisableSelectButton()
        {
            if (dgTaxpayers.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
                return;
            }
            btnSelect.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelectedTaxpayer();
        }

        private void LoadSelectedTaxpayer()
        {
            int rowIndex = dgTaxpayers.CurrentRow.Index;

            var taxpayerID = Convert.ToInt32(dgTaxpayers.Rows[rowIndex].Cells["taxpayers_id"].Value);
            var taxpayer = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_name"].Value.ToString();
            var taxpayerType = dgTaxpayers.Rows[rowIndex].Cells["taxpayer_type"].Value.ToString();
            var taxpayerTIN = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_tin"].Value.ToString();
            var taxpayerContact = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_contact_info"].Value.ToString();
            var taxpayerBarangay = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_barangay"].Value.ToString();
            var taxpayerMunicipality = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_municipality"].Value.ToString();
            var taxpayerProvince = dgTaxpayers.Rows[rowIndex].Cells["taxpayers_province"].Value.ToString();

            var address = $"{taxpayerBarangay}, {taxpayerMunicipality}, {taxpayerProvince}";

            _ucRealProperties.taxpayerID = taxpayerID;
            _ucRealProperties.txtTaxpayers.Text = taxpayer;
            _ucRealProperties.txtTaxpayerType.Text = taxpayerType;
            _ucRealProperties.txtTaxpayerTIN.Text = taxpayerTIN;
            _ucRealProperties.txtTaxpayerContact.Text = taxpayerContact;
            _ucRealProperties.txtTaxpayerAddress.Text = address;

            Close();
        }

        private void dgTaxpayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LoadSelectedTaxpayer();
                Close();
            }
        }
    }
}