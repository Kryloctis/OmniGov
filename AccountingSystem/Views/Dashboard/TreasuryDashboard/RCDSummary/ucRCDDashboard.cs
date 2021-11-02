using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingSystem.Views.Reports.RCD;

namespace AccountingSystem.Views.Dashboard.TreasuryDashboard.RCDSummary
{
    public partial class ucRCDDashboard : UserControl
    {
        public ucRCDDashboard()
        {
            InitializeComponent();
        }

        private void ucRCDDashboard_Load(object sender, EventArgs e)
        {
            LoadCollectors();
            LoadFunds();            
            LoadSummary();
        }

        private void btnAddRCD_Click(object sender, EventArgs e)
        {
            _ = new frmRCDEdit(new frmRCD(), 0).ShowDialog();
        }

        private void LoadCollectors()
        {
            try
            {
                var colRepository = Factory.CollectingOfficerRepository();
                var dtCol = colRepository.GetRecords();
                cmbcollector.DataSource = dtCol;
                cmbcollector.ValueMember = "id";
                cmbcollector.DisplayMember = "fullname";

                var uRepository = Factory.UsersRepository();
                if (uRepository.LinkedCollector(Helper.UserId))
                {
                    var data = colRepository.GetRecordByUserID(Helper.UserId);
                    cmbcollector.SelectedValue = data["id"];
                    cmbcollector.Enabled = false;
                }

            }
            catch(Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            try
            {
                var fundRepository = Factory.FundsRepository();
                var dtfunds = fundRepository.GetRecords();
                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "fund_name";

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadSummary()
        {
            var rcdRepository = Factory.CollectorReportRepository();
            var dtrcd = rcdRepository.GetSummary(cmbcollector.SelectedValue != null ? int.Parse(cmbcollector.SelectedValue.ToString()) : 0,
            cmbfunds.SelectedValue != null ? int.Parse(cmbfunds.SelectedValue.ToString()) : 0, int.Parse(nudYear.Value.ToString()));
            lblRCD.Text = dtrcd.Rows.Count.ToString();

            DataRow[] rowapproved = dtrcd.Select("is_approved=1");
            lblApproved.Text = rowapproved.Length.ToString();
            DataRow[] rowdisapproved = dtrcd.Select("is_approved=0");
            lblDisapproved.Text = rowdisapproved.Length.ToString();
            DataRow[] rowpending = dtrcd.Select("status='PENDING'");
            lblPending.Text = rowpending.Length.ToString();
            DataRow[] rowcancelled = dtrcd.Select("status='CANCELLED'");
            lblCancelled.Text = rowcancelled.Length.ToString();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbcollector.SelectedIndex = cmbcollector.Enabled ? -1 : cmbcollector.SelectedIndex;
            cmbfunds.SelectedIndex = -1;
            nudYear.Value = DateTime.Now.Year;
            LoadSummary();
        }
        
        private void cmbcollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSummary();
        }

        private void cmbfunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadSummary();
        }
    }
}
