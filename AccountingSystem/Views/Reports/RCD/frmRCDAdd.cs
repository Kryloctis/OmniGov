using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();

                DataTable dtCollectors = collectingOfficerRepository.GetRecords();
                DataView dv = dtCollectors.DefaultView;

                cmbCollector.DataSource = dtCollectors;
                cmbCollector.DisplayMember = "fullname";
                cmbCollector.ValueMember = "id";
                dtCollectors.Rows.Add(0, "All");

                dv.Sort = "id asc";

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
                string status = cmbCollector.Text.ToLower();
                byte fundId = (byte)(cmbfunds.SelectedValue != null ? Convert.ToByte(cmbfunds.SelectedValue.ToString()) : 0);
                string keySearch = txtsearch.Text;


                var colectorRepository = Factory.CollectorReportRepository();

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
                var fundrepo = Factory.FundsRepository();
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

            string reportId = String.Empty;
            string collectingOfficer = String.Empty;
            string reportNo = String.Empty;
            string reportNoChecker = String.Empty;
            decimal amount = 0.0m;


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
                        Helper.MessageBoxError("Selected collector's report is already on the list.");
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
