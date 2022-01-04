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
    public partial class frmSearch : Form
    {
        internal int Id = 0;

        internal string reportNo;
        internal string rcdNo;
        internal string rcdId;

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
                var dtRCD = rcdRepository.GetRecords();

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
                var dtrcd = Factory.GeneralCollectionsRepository().GetRecordsBySearch(searchkey);

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

            _frmRCD.btnPrint.Enabled = true;
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
                    rcdId = row.Cells[0].Value.ToString();
                    rcdNo = row.Cells[1].Value.ToString();
                    reportNo = row.Cells[3].Value.ToString();
                }
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }
    }
}
