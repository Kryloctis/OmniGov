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

        internal string reportNo;
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
            cmbstatus.SelectedIndex = 1;
            LoadFunds();
            LoadRecords();


        }


        private void LoadRecords()
        {
            try
            {
                string status = cmbstatus.Text.ToLower();
                byte fundId = (byte)(cmbfunds.SelectedValue != null ? Convert.ToByte(cmbfunds.SelectedValue.ToString()) : 0);
                string keySearch = txtsearch.Text;
                //byte collectingOfficerId = (byte)_frmCollectorsRCD.ucCollectorsRCD1.collectorId;

                var colectorRepository = Factory.CollectorReportRepository();
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
            {
                reportNo = row.Cells[1].Value.ToString();
            }
        }
       
        private void btnSelect_Click(object sender, EventArgs e)
        {
            _frmCollectorsRCD.LoadSelectedValue(reportNo);
            _frmCollectorsRCD.CheckRCDStatus(reportNo);

            _uc.TotalCollections();
            _uc.cmbcollector.Enabled = false;
            _uc.txtReport.Enabled = false;
            _uc.dgPayments.Enabled = false;

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

    }
}
