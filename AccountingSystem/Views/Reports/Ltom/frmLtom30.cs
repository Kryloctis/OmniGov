using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Auction;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom30 : Form
    {
        private ucDeclarationOfForfeitureOfDelinquentProperty ucDeclarationOfForfeitureOfDelinquentProperty;

        public frmLtom30()
        {
            InitializeComponent();
            ucDeclarationOfForfeitureOfDelinquentProperty = ucDeclarationOfForfeitureOfDelinquentProperty1;
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void frmLtom30_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            ToogleRunButton(false);
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;
            ToogleRunButton(true);
        }

        private void OnLoad()
        {
            cmbxProperty.ResetText();
            cmbxProperty.SelectedIndex = -1;

            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadProperties();
            LoadAuctionSchedule();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                int rptId = Convert.ToInt32(cmbxProperty.SelectedValue);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxProperty.SelectedIndex == -1)
                    return;

                ucDeclarationOfForfeitureOfDelinquentProperty.OnLoad(auctionId, rptId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }
    }
}
