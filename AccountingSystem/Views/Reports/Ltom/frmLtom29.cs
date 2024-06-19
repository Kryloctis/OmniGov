using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Auction;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{

    public partial class frmLtom29 : Form
    {
        private ucCertificateOfSale ucCertificateOfSale;

        public frmLtom29()
        {
            InitializeComponent();
            ucCertificateOfSale = ucCertificateOfSale1;

        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int rptId = Convert.ToInt32(cmbxProperty.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxProperty.SelectedIndex == -1)
                    return;

                ucCertificateOfSale.OnLoad(auctionId, rptId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void frmLtom29_Load(object sender, EventArgs e)
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
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;

        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxProperty.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxProperty.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        private void ucCertificateOfSale1_Load(object sender, EventArgs e)
        {

        }
    }
}
