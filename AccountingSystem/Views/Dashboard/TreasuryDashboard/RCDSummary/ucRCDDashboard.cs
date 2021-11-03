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
        private string allrcd = string.Empty;
        private string approved = string.Empty;
        private string pending = string.Empty;
        private string disapproved = string.Empty;
        private string cancelled = string.Empty;
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
            _ = new frmRCDEdit(new frmRCD(string.Empty), 0).ShowDialog();
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
            allrcd = string.Join(",", dtrcd.Rows.OfType<DataRow>().Select(r => r[0].ToString()));

            DataRow[] rowapproved = dtrcd.Select("is_approved=1");
            lblApproved.Text = rowapproved.Length.ToString();
            approved = string.Join(",", rowapproved.Select(r => r[0].ToString()).ToArray());
            DataRow[] rowdisapproved = dtrcd.Select("is_approved=0");
            lblDisapproved.Text = rowdisapproved.Length.ToString();
            disapproved = string.Join(",", rowdisapproved.Select(r => r[0].ToString()).ToArray());
            DataRow[] rowpending = dtrcd.Select("status='PENDING'");
            lblPending.Text = rowpending.Length.ToString();
            pending = string.Join(",", rowpending.Select(r => r[0].ToString()).ToArray());
            DataRow[] rowcancelled = dtrcd.Select("status='CANCELLED'");
            lblCancelled.Text = rowcancelled.Length.ToString();
            cancelled = string.Join(",", rowcancelled.Select(r => r[0].ToString()).ToArray());
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

        private void linkRCD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.Parse(lblRCD.Text.Trim()) > 0)
            {
                _ = new frmRCD(allrcd).ShowDialog();
            }
        }

        private void linkApproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.Parse(lblApproved.Text.Trim()) > 0)
            {
                _ = new frmRCD(approved).ShowDialog();
            }
        }

        private void linkPending_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.Parse(lblPending.Text.Trim()) > 0)
            {
                _ = new frmRCD(pending).ShowDialog();
            }
        }

        private void linkDisapproved_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.Parse(lblDisapproved.Text.Trim()) > 0)
            {
                _ = new frmRCD(disapproved).ShowDialog();
            }
        }

        private void linkCancelled_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.Parse(lblCancelled.Text.Trim()) > 0)
            {
                _ = new frmRCD(cancelled).ShowDialog();
            }
        }
    }
}
