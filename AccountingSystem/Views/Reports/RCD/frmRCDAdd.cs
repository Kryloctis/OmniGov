using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRCDAdd : Form
    {

        private readonly frmRCD _frmRCD;
        private string reportNo;
        private string collectorsReportId;
        private string collector;

        public frmRCDAdd(frmRCD frmRCD)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgCollectorsReport, true);

            _frmRCD = frmRCD;
        }

        private void frmRCDAdd_Load(object sender, EventArgs e)
        {
            LoadCollectors();
            LoadFunds();
            LoadRecords();
        }

        private void LoadCollectors()
        {
            try
            {
                cmbCollector.SelectedValueChanged -= new EventHandler(cmbCollector_SelectedValueChanged);

                var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
                var collectingOfficerHasJORepo = AccFactory.CollectingOfficerHasJobOrdersRepository();

                DataTable dtCollectors = new();
                var dtJOCollectors = collectingOfficerHasJORepo.GetRecords();
                var dtRegularCollectors = collectingOfficerRepository.GetRecords();

                dtRegularCollectors.Merge(dtJOCollectors);
                dtRegularCollectors.Rows.Add(0, "All");

                dtCollectors = dtRegularCollectors;
                cmbCollector.DataSource = dtCollectors;
                cmbCollector.DisplayMember = "fullname";
                cmbCollector.ValueMember = "id";

                dtCollectors.DefaultView.Sort = "id ASC";

                cmbCollector.SelectedValueChanged += new EventHandler(cmbCollector_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadRecords()
        {
            try
            {
                short collectorId = (short)Convert.ToInt32(cmbCollector.SelectedValue);
                string status = "approved";
                byte fundId = (byte)(cmbfunds.SelectedValue != null ? Convert.ToByte(cmbfunds.SelectedValue.ToString()) : 0);
                string keySearch = txtsearch.Text;


                var colectorRepository = AccFactory.CollectorReportRepository();


                var dtrcd = new DataTable();
                if (cmbCollector.Text == "All")
                    dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch);
                else
                    dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch, collectorId);


                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgCollectorsReport);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {

            string reportId;
            string collectingOfficer;
            string reportNo;
            string reportNoChecker;
            decimal amount;


            foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
            {
                reportId = row.Cells["id"].Value.ToString();
                collectingOfficer = row.Cells["collector_officer"].Value.ToString();
                reportNo = row.Cells["report_no"].Value.ToString();
                amount = Convert.ToDecimal(row.Cells["amount"].Value);

                foreach (DataGridViewRow _frmRCDRow in _frmRCD.dgListOfApprovedReport.Rows)
                {
                    reportNoChecker = _frmRCDRow.Cells[2].Value.ToString();

                    if (reportNo == reportNoChecker)
                    {
                        Helper.MessageBoxSuccess("Selected collector's report is already on the list.");
                        return;
                    }
                }

                object[] reportRow = new object[]
                {
                    reportId,
                    collectingOfficer,
                    reportNo,
                    amount.ToString("N2")
                };

                _frmRCD.dgListOfApprovedReport.Rows.Add(reportRow);
            }

            //this.Close();
        }


        private void dgCollectorsReport_SelectionChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = dgCollectorsReport.SelectedRows.Count != 0;
            
            foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
            {
                collectorsReportId = row.Cells[0].Value.ToString();
                reportNo = row.Cells[1].Value.ToString();
                collector = row.Cells[3].Value.ToString();
            }
          
        }

        private void cmbCollector_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dgCollectorsReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgCollectorsReport_DoubleClick(object sender, EventArgs e)
        {
            btnOkay.PerformClick();
        }
    }
}
