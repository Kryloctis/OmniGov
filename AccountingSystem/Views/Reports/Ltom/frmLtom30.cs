using ACC.Data;
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

            var delinquentProperties = AccFactory.DelinquentNoticeRepository().GetViewRecords("3rd Notice");

            cmbxProperty.ValueMember = "real_properties_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = delinquentProperties;

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
                ucDeclarationOfForfeitureOfDelinquentProperty.OnLoad(rptId, auctionId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

    }
}
