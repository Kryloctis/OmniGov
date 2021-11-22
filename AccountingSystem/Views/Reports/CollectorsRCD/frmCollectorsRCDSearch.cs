using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCDSearch : Form
    {

        internal int reportId = 0;
        private readonly frmCollectorsRCD _frmCollectorsRCD;
        private readonly ucCollectorsRCD _uc;

        public frmCollectorsRCDSearch(frmCollectorsRCD frmCollectorsRCD, ucCollectorsRCD uc)
        {
            InitializeComponent();

            Helper.DatagridFullRowSelectStyle(dgCollectorsReport, true);
            _frmCollectorsRCD = frmCollectorsRCD;
            _uc = uc;
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

        private void frmCollectorsRCDSearch_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadRecords();
        }


        private void LoadRecords()
        {
            try
            {
                string status = cmbstatus.Text.ToUpper();
                byte fundId = (byte)(cmbfunds.SelectedValue != null ? Convert.ToByte(cmbfunds.SelectedValue.ToString()) : 0);
                string keySearch = txtsearch.Text;

                var colectorRepository = Factory.CollectorReportRepository();

                var dtrcd = colectorRepository.FilterRecords(status, fundId, keySearch);

                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgCollectorsReport);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgCollectorsReport_SelectionChanged(object sender, EventArgs e)
        {
            if (dgCollectorsReport.Rows.Count > 0 && dgCollectorsReport.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgCollectorsReport.SelectedRows)
                {
                    reportId = int.Parse(row.Cells[0].Value.ToString());
                }
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _frmCollectorsRCD.LoadSelectedValue(reportId);
            _uc.ActionPerformIsSave(false);
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

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
