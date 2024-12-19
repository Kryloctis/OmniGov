using AccountingSystem.Views.Manage.CashTickets;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FeesChargesConfig;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Assessment;
using AccountingSystem.Views.Transactions.Auction;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.Biddings;
using AccountingSystem.Views.Transactions.Payments;
using AccountingSystem.Views.Transactions.Payments.AF51_57;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using AccountingSystem.Views.Transactions.Payments.CattleOwnership;
using AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership;
using AccountingSystem.Views.Transactions.Payments.CommunityTaxCertificate;
using AccountingSystem.Views.Transactions.Payments.MarriageLicense;
using AccountingSystem.Views.Transactions.Payments.PaymentHistory;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
using AccountingSystem.Views.Transactions.ReleasedAndUnReleasedChecks;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.Treasury
{
    public partial class ucTreasury : UserControl
    {
        public ucTreasury()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            ValidatePermissions();
        }

        private void ValidatePermissions()
        {
            //if (!Helper.HasPermission("Manage > Returned Receipts"))
            //    ret.Enabled = false;

            //if (!Helper.HasPermission("Manage > Database Synchronization"))
            //    databaseSynchronizationToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Manage > Business Categories"))
            //    businessCategoriesToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Manage > Business Add-on Charges"))
            //    businessAddOnToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction > Generate RCD"))
            //    liquidatorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction > RCD Approval"))
            //    liquidatorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Report > Collector's RCD"))
            //    //collectorsRCDToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Collecting Officer"))
                collectingOfficersTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Disbursing Officer"))
                disbursementOfficersTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Taxpayers"))
                taxpayersTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Fees & Charges Config."))
                feesChargesTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Real Properties"))
                realPropertiesTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Check"))
                checkIssuanceTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Transaction > Bank Deposits"))
                bankDepositTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Receipts"))
                receiptInventoryTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Receipt"))
                recieiptIssuanceTstrpMnuItm.Enabled = false;

            if (!Helper.HasPermission("Manage > Receipts") && !Helper.HasPermission("Transaction > Issue Receipt"))
                receiptsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Payments"))
                paymentsToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction > Assessment Posting"))
            //    propertyTaxPostingToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Release / Unreleased Checks"))
                releasedAndUnreleaseChecksTstrpMnuItm.Enabled = false;
        }

        private void taxpayersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmTaxpayers().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void realPropertiesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRealProperties().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void collectingOfficersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCollectingOfficer().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void disbursementOfficersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmDisbursingOfficer().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }



        private void feesChargesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFeesChargesConfig().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af56TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmPaymentRpt().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af5157TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAF51_57().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af54TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmMarriageLicense().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af58TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBurialPermit().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af53TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCattleOwnership().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void af52TstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCattleTransfer().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void pymntHstoryTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmPaymentHistory().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void auctionTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAuction().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void biddingTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBiddings().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void checkIssuanceTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRCI().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void releasedAndUnreleaseChecksTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReleasedAndUnreleaseChecks().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bankDepositTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBankDeposits().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void receiptInventoryTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReceipts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void recieiptIssuanceTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReceiptsIssued().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void propertyAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptDelinquencyNotices().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void propertyTaxPostingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAssessmentPosting().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void warrantsOfLevyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmWarrantLevy().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void aF41CommunityTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCommunityTaxCertificate().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTickets().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}