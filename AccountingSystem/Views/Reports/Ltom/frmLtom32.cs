using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom32 : Form
    {
        private ucCertificateOfRedemption ucCertificateOfRedemption;

        public frmLtom32()
        {
            InitializeComponent();
            ucCertificateOfRedemption = ucCertificateOfRedemption1;
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void frmLtom32_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            cmbxProperty.ResetText();
            cmbxProperty.SelectedIndex = -1;

            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;

        }

        private void ucCertificateOfRedemption1_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int rptId = Convert.ToInt32(cmbxProperty.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxProperty.SelectedIndex == -1)
                    return;

                ucCertificateOfRedemption.OnLoad(auctionId, rptId);
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

    }
}
