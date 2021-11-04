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
        private frmRCDEdit frmrcd;
        internal int Id = 0;
        public frmSearch(frmRCDEdit _frmrcd)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgrcd);
            frmrcd = _frmrcd;
            
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadRecords();
            dgrcd.Columns[7].Visible = false;
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
            }catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadRecords()
        {
            try
            {
                int approved = cmbstatus.SelectedIndex != -1 && cmbstatus.SelectedItem.Equals("Approved") ? 1:0;
                string status = cmbstatus.SelectedIndex != -1 && (cmbstatus.SelectedItem.Equals("Pending") || cmbstatus.SelectedItem.Equals("Cancelled")) ? cmbstatus.SelectedItem.ToString().ToUpper():string.Empty;
                int fundid = cmbfunds.SelectedValue != null ? int.Parse(cmbfunds.SelectedValue.ToString()):0;

                var colrepo = Factory.CollectorReportRepository();
                var dtrcd = colrepo.GetRecords(approved, status, fundid, string.Empty);
                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgrcd);
            }
            catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtrcd = Factory.CollectorReportRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgrcd);

                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void cmbstatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cmbfunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dgrcd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(Id > 0)
            {
                frmrcd.LoadSearchValue(Id);
                this.Close();
            }
        }
       

        private void dgrcd_SelectionChanged(object sender, EventArgs e)
        {
            if (dgrcd.Rows.Count > 0 && dgrcd.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrcd.SelectedRows)
                {
                    Id = int.Parse(row.Cells[0].Value.ToString());
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
