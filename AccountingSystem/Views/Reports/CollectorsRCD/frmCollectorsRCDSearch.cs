using ACC.Data;
using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCDSearch : Form
    {
        internal string reportNo;
        private readonly frmCollectorsRCD _frmCollectorsRCD;
        private readonly ucCollectorsRCD _uc;

        public frmCollectorsRCDSearch(frmCollectorsRCD frmCollectorsRCD, ucCollectorsRCD uc)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgCollectorsReport, true);

            _frmCollectorsRCD = frmCollectorsRCD;
            _uc = uc;
            cmbstatus.SelectedIndex = 1;
        }

        private void LoadFunds()
        {
            var dtfunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtfunds, cmbfunds, "fund_name", "id");
        }

        private void OnLoad()
        {
            LoadFunds();
            LoadRecords();
        }

        private void frmCollectorsRCDSearch_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRecords()
        {
            string status = cmbstatus.Text.ToLower();
            byte fundId = Convert.ToByte(cmbfunds.SelectedValue);
            string keySearch = txtsearch.Text;

            var dtRCD = AccFactory.CollectorReportRepository().FilterRecords(status, fundId, keySearch);

            HelperLoadRecords.CollectorReportDatagridView(dtRCD, dgCollectorsReport);

            if (dgCollectorsReport.Rows.Count == 0)
            {
                btnSelect.Enabled = false;
                return;
            }

            btnSelect.Enabled = true;
        }

        private void dgCollectorsReport_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
                reportNo = row.Cells[1].Value.ToString();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                _frmCollectorsRCD.LoadSelectedValue(reportNo);
                _frmCollectorsRCD.CheckRCDStatus(reportNo);

                _uc.TotalCollections();
                this.Close();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbfunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbstatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgCollectorsReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _frmCollectorsRCD.LoadSelectedValue(reportNo);
                _frmCollectorsRCD.CheckRCDStatus(reportNo);

                _uc.TotalCollections();
                Close();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}