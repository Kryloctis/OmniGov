using System;
using System.Data;
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

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
                new DataColumn("is_active", typeof(bool)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string))
            };
        }

        private DataTable TaxpayersDataTable()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dtTaxpayersRecords;
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(TaxpayersColumns());

            if (txtSearch.Text.Length < 2)
                dtTaxpayersRecords = AccFactory.TaxpayersRepository().GetViewTaxpayerRecords();
            else
                dtTaxpayersRecords = AccFactory.TaxpayersRepository().GetViewTaxpayerRecordsBySearch(searchText);

            foreach (DataRow row in dtTaxpayersRecords.Rows)
            {
                var newRow = dataTable.NewRow();
                int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                string taxpayerTin = row["taxpayers_tin"].ToString();
                string taxpayerName = row["taxpayers_name"].ToString();
                string taxpayerTypeCode = row["taxpayer_type_code"].ToString();
                string street = string.IsNullOrEmpty(row["taxpayers_street"].ToString()) ? string.Empty : $"{row["taxpayers_street"]},";
                string barangay = string.IsNullOrEmpty(row["taxpayers_barangay"].ToString()) ? string.Empty : $"{row["taxpayers_barangay"]},";
                string municipality = string.IsNullOrEmpty(row["taxpayers_municipality"].ToString()) ? string.Empty : $"{row["taxpayers_municipality"]},";
                string province = string.IsNullOrEmpty(row["taxpayers_province"].ToString()) ? string.Empty : $"{row["taxpayers_province"]},";
                string taxpayerAddress = $"{street} {barangay} {municipality} {province}";
                string taxpayerContactInfo = row["taxpayers_contact_info"].ToString();
                bool isActive = Convert.ToBoolean(Convert.ToByte(row["is_active"]));
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();

                newRow["taxpayers_id"] = taxpayerId;
                newRow["taxpayer_type_code"] = taxpayerTypeCode;
                newRow["taxpayers_tin"] = taxpayerTin;
                newRow["taxpayers_name"] = taxpayerName;
                newRow["taxpayers_address"] = taxpayerAddress;
                newRow["taxpayers_contact_info"] = taxpayerContactInfo;
                newRow["is_active"] = isActive;
                newRow["created_at"] = createdAt;
                newRow["updated_at"] = updatedAt;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal void LoadTaxpayers()
        {
            try
            {
                HelperLoadRecords.TaxpayerDatagridView(dgTaxpayers, TaxpayersDataTable());
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
                toolStripStatusLabelRecordCount.Text = dgTaxpayers.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmTaxPayersSearch_Load(object sender, EventArgs e)
        {
            LoadTaxpayers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxpayers();
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
            int rowIndex = dgTaxpayers.CurrentCell.RowIndex;
            var taxpayerId = Convert.ToInt32(dgTaxpayers.Rows[rowIndex].Cells["taxpayers_id"].Value);
            _ = new frmEditTaxpayers(taxpayerId, this).ShowDialog();

        }

        public static void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
                tsBtnEdit.Enabled = true;
            else if (SelectedRows > 1)
                tsBtnEdit.Enabled = false;
            else
                tsBtnEdit.Enabled = false;
        }

        private void dgTaxpayers_SelectionChanged(object sender, EventArgs e)
        {
              try
            {
                var indexes = new byte[] { 7, 8 };
                EnableDisableToolStripButtons(dgTaxpayers, btnEdit);
                Helper.ShowRecordTimestamp(dgTaxpayers, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
