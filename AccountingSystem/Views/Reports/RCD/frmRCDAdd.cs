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


            cmbCollector.SelectedValueChanged -= new EventHandler(cmbCollector_SelectedValueChanged);
            LoadCollectors();
            cmbCollector.SelectedValueChanged += new EventHandler(cmbCollector_SelectedValueChanged);


            LoadFunds();
            LoadRecords();


            cmbCollector.SelectedIndex = -1;
        }

        private void LoadCollectors()
        {
            try
            {
                //cmbCollector.SelectedValueChanged -= new EventHandler(cmbcollector_SelectedValueChanged);
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();


                var dtCollectors = new DataTable();
                dtCollectors = collectingOfficerRepository.GetRecords();

                dtCollectors.Rows.Add(0, "All");

                cmbCollector.DataSource = dtCollectors;
                cmbCollector.DisplayMember = "fullname";
                cmbCollector.ValueMember = "id";

                //cmbCollector.SelectedValueChanged += new EventHandler(cmbcollector_SelectedValueChanged);

                //collectorId = (ushort)Convert.ToInt32(cmbCollector.SelectedValue);

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

                if (collectorId == 0)
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
            string amount = String.Empty;


            foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
            {
                reportId = row.Cells["id"].Value.ToString();
                collectingOfficer = row.Cells["collector_officer"].Value.ToString();
                reportNo = row.Cells["report_no"].Value.ToString();
                amount = row.Cells["amount"].Value.ToString();
            }



            foreach (DataGridViewRow row in _frmRCD.dgpayments.Rows)
            {
                reportNoChecker = row.Cells[2].Value.ToString();

                if (reportNo == reportNoChecker)
                {
                    Helper.MessageBoxError("Collector's report is already on the list.");
                    return;
                }
            }

            object[] reportRow = new object[]
            {
                reportId,
                collectingOfficer,
                reportNo,
                amount
            };

            _frmRCD.dgpayments.Rows.Add(reportRow);

            //this.Close();
        }

        private void dgCollectorsReport_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCollectorsReport.Rows.Count > 0 && dgCollectorsReport.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
                {
                    collectorsReportId = row.Cells[0].Value.ToString();
                    reportNo = row.Cells[1].Value.ToString();
                    collector = row.Cells[3].Value.ToString();
                }
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
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
