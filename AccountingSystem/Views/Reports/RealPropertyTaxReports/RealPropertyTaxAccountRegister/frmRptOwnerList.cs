using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister
{
    public partial class frmRptOwnerList : Form
    {
        private readonly frmRealPropertyTaxAccountRegisterReport _frmRealPropertyTaxAccountRegisterReport;

        public frmRptOwnerList(frmRealPropertyTaxAccountRegisterReport frmRealPropertyTaxAccountRegisterReport)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            _frmRealPropertyTaxAccountRegisterReport = frmRealPropertyTaxAccountRegisterReport;
        }

        private DataTable DataTableAssessmentPost(string searchText)
        {
            var columns = new string[] { "id", "owner_tin", "owner_name", "barangay_name", "municipality_name", "province_name", "owner_address" };
            var dtAssessmentPostin = AccFactory.RptAssessmentPostsRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtAssessmentPostin);
            return dtView.ToTable(false, columns);
        }

        private void LoadTaxpayerList()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.TaxPayerListDatagridView(dataGridView1, DataTableAssessmentPost(searchText));
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void EnableDisableSelectButton()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
                return;
            }
            btnSelect.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTaxpayerList();
        }

        private void frmRptOwnerList_Load(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void InitializeReport()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            string ownerTin = dataGridView1.Rows[rowIndex].Cells["owner_tin"].Value.ToString();
            string ownerName = dataGridView1.Rows[rowIndex].Cells["owner_name"].Value.ToString();
            string ownerAddress = dataGridView1.Rows[rowIndex].Cells["owner_address"].Value.ToString();

            _frmRealPropertyTaxAccountRegisterReport.OwnerName = ownerName;
            _frmRealPropertyTaxAccountRegisterReport.OwnerAddress = ownerAddress;
            _frmRealPropertyTaxAccountRegisterReport.OwnerTin = ownerTin;

            _frmRealPropertyTaxAccountRegisterReport.backgroundWorker1.RunWorkerAsync();
            _frmRealPropertyTaxAccountRegisterReport.btnReload.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                InitializeReport();
                Close();
            }
        }
    }
}
