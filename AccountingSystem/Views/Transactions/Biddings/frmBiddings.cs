using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Payments;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings
{
    public partial class frmBiddings : Form
    {
        private ucTaxPayers ucTaxPayers;
        private ucBiddings ucBiddings;
        private ucPayment ucPayment;

        public frmBiddings()
        {
            InitializeComponent();

            ucTaxPayers = ucTaxPayers1;
            ucBiddings = ucBiddings1;
            ucPayment = ucPayment1;

            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBiddings, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePayment);
        }

        private void btnPaymentBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private decimal ComputeAmountDue()
        {
            decimal bidAmount = ucBiddings.nudBidAmount.Value;
            decimal otherDuesToBeDeterminedLater = 0;

            decimal amountDue = bidAmount + otherDuesToBeDeterminedLater;

            return amountDue;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePayment);

            decimal totalAmountPayable = ComputeAmountDue();
            ucPayment1.OnLoad(Helper.userId, string.Empty, totalAmountPayable);
        }

        private void frmBiddings_Load(object sender, EventArgs e)
        {
            LoadRowFilter();
            ucTaxPayers.LoadTaxPayersType();
            Helper.EnableDisableToolStripButtons(dgBiddings, btnEdit, btnDelete);
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
        }

        private void lTOM26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePublicAuctionRegistrationForm);
        }

        private void lTOM26ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfRegisteredBidders);
        }

        private void lTOM27ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageUndertakingAndWaiverOfBidders);
        }

        private void lTOM28ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageRulesAndRegulationOfPublicAuction);
        }

        private void TabPageController(TabPage tabPageRoute)
        {
            try
            {
                if (tabControlPrintPreview.TabPages.Contains(tabPageRoute))
                {
                    tabControl1.SelectedTab = tabPagePrint;
                    tabControlPrintPreview.SelectedTab = tabPageRoute;
                    Text = $"Transaction > Print > {tabPageRoute.Text} ";
                    return;
                }

                Text = $"Transaction > {tabPageRoute.Text} ";
                tabControl1.SelectedTab = tabPageRoute;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageList);
        }

        private void ResetForm()
        {
            TabPageController(tabPageList);
        }
        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfirmPayment())
                {
                    Helper.MessageBoxSuccess("Payment has been saved, initiating the printing of the receipt...");
                    ResetForm();
                    return;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ConfirmPayment()
        {

            var biddersModel = new BiddersModel()
            {
                AuctionId = Convert.ToInt32(ucBiddings.cmbxAuctionSchedule.SelectedValue),
                BidderNo = "123",
                CreatedBy = Helper.userId
            };

            var biddingModel = new BiddingsModel()
            {
                RptAuctionId = Convert.ToInt32(ucBiddings.cmbxAuctionSchedule.SelectedValue),
                OrdinanceNo = ucBiddings.txtOrdinanceNo.Text,
                Date = ucBiddings.dtpDate.Value,
                BidAmount = Convert.ToDecimal(ucBiddings.nudBidAmount.Value),
                CreatedBy = Helper.userId
            };


            return AccFactory.PaymentCollectionsRepository().InsertWithBiddingPayment(ucPayment.PaymentCollectionsModel(), null, ucTaxPayers.TaxpayersModel(), biddingModel, biddersModel);
        }


    }
}
