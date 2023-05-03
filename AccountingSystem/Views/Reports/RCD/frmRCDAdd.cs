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
            Helper.DatagridFullRowSelectStyle(dgCollectorsReport, false);
            Helper.LoadFormIcon(this);
            _frmRCD = frmRCD;
        }

        private void frmRCDAdd_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCollectors();
                LoadFunds();
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] DataColumnCollectors()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };
        }

        private DataTable DtJobOrderCollectingOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnCollectors());
            DataTable dtJOCollectingOfficers = AccFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecords();

            foreach (DataRow row in dtJOCollectingOfficers.Rows)
            {
                DataRow newRow = dataTable.NewRow();
                int Id = Convert.ToInt32(row["job_orders_id"]);
                string prefix = row["job_orders_prefix"].ToString();
                string firstName = row["job_orders_first_name"].ToString();
                string midInitial = row["job_orders_mid_initial"].ToString();
                string lastName = row["job_orders_last_name"].ToString();
                string suffix = row["job_orders_suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private DataTable DtCollectingOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnCollectors());
            DataTable dtCollectingOfficers = AccFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dtCollectingOfficers.Rows)
            {
                DataRow newRow = dataTable.NewRow();
                int Id = Convert.ToInt32(row["id"]);
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string midInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private void LoadCollectors()
        {
            cmbCollector.SelectedValueChanged -= new EventHandler(cmbCollector_SelectedValueChanged);

            DtCollectingOfficers().Merge(DtJobOrderCollectingOfficers());
            HelperLoadRecords.CollectingOfficerComboBox(DtCollectingOfficers(), cmbCollector, "full_name", "id");

            cmbCollector.SelectedValueChanged += new EventHandler(cmbCollector_SelectedValueChanged);
        }

        private void LoadRecords()
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
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSelect_Click(object sender, EventArgs e)
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
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgCollectorsReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgCollectorsReport_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }
    }
}