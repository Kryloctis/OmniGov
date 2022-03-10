using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmSearch : Form
    {
        internal int Id = 0;

        internal int fundId=1;
        internal string reportNo;
        internal string rcdNo;
        internal string rcdId;
        internal string rcdDate;

        private readonly frmRCD _frmRCD;

        public frmSearch(frmRCD frmRCD)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgRCDSearch, true);
            _frmRCD = frmRCD;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadRecords();
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

        private void LoadRecords()
        {
            try
            {
                var rcdRepository = Factory.GeneralCollectionsRepository();
                var dtRCD = rcdRepository.GetRecordsByFundId(fundId);

                HelperLoadRecords.RCDSearchDatagridView(dtRCD, dgRCDSearch);
            }
            catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchkey = Convert.ToString(txtsearch.Text.Trim());
                var dtrcd = Factory.GeneralCollectionsRepository().GetRecordsByFundIdAndSearchKey(fundId, searchkey);

                HelperLoadRecords.RCDSearchDatagridView(dtrcd, dgRCDSearch);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgrcd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _frmRCD.dgListOfApprovedReport.Rows.Clear();
            _frmRCD.txtRCDNo.Text = rcdNo;
            _frmRCD.rcdId = rcdId;
            _frmRCD.dtpDate.Value = Convert.ToDateTime(rcdDate);

            _frmRCD.btnDeposit.Enabled = true;
            _frmRCD.btnPrint.Enabled = true;
            _frmRCD.btnCancelPrint.Enabled = true;
            _frmRCD.panelRCD.Enabled = false;

            _frmRCD.LoadSelectedRCD(rcdNo);

            this.Close();
        }
       
        private void dgrcd_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRCDSearch.Rows.Count > 0 && dgRCDSearch.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgRCDSearch.SelectedRows)
                {
                    rcdId = row.Cells["id"].Value.ToString();
                    rcdNo = row.Cells["rcd_no"].Value.ToString();
                    reportNo = row.Cells["report_no"].Value.ToString();
                    rcdDate = row.Cells["date"].Value.ToString();
                }
                btnSelect.Enabled = true;
            }
            else
                btnSelect.Enabled = false;
        }

        private void cmbfunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                fundId = Convert.ToInt32(cmbfunds.SelectedValue);

                var rcdRepository = Factory.GeneralCollectionsRepository();
                var dtRCD = rcdRepository.GetRecordsByFundId(fundId);

                HelperLoadRecords.RCDSearchDatagridView(dtRCD, dgRCDSearch);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
