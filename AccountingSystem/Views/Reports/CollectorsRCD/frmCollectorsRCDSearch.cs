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
            try
            {
                var fundrepo = AccFactory.FundsRepository();
                var dtfunds = fundrepo.GetRecords();
                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "fund_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmCollectorsRCDSearch_Load(object sender, EventArgs e)
        {
            cmbfunds.SelectedValueChanged -= new EventHandler(cmbfunds_SelectedValueChanged);
            LoadFunds();
            cmbfunds.SelectedValueChanged += new EventHandler(cmbfunds_SelectedValueChanged);
            LoadRecords();
        }


        private void LoadRecords()
        {
            try
            {
                string status = cmbstatus.Text.ToLower();
                byte fundId = Convert.ToByte(cmbfunds.SelectedValue);
                string keySearch = txtsearch.Text;

                var colectorRepository = AccFactory.CollectorReportRepository();
                var dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch);

                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgCollectorsReport);

                if (dgCollectorsReport.Rows.Count == 0)
                {
                    btnSelect.Enabled = false;
                    return;
                }

                btnSelect.Enabled = true;

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgCollectorsReport_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
                reportNo = row.Cells[1].Value.ToString();
        }
       
        private void btnSelect_Click(object sender, EventArgs e)
        {
            _frmCollectorsRCD.LoadSelectedValue(reportNo);
            _frmCollectorsRCD.CheckRCDStatus(reportNo);
            
            _uc.TotalCollections();
            this.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cmbstatus_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cmbfunds_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dgCollectorsReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _frmCollectorsRCD.LoadSelectedValue(reportNo);
            _frmCollectorsRCD.CheckRCDStatus(reportNo);

            _uc.TotalCollections();
            this.Close();
        }
    }
}
