using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.CashTicketIssuance;
using OmniGov.App.Views.Manage.CashTickets;
using OmniGov.App.Views.Manage.CollectingOfficer;
using OmniGov.App.Views.Manage.DisbursingOfficer;
using OmniGov.App.Views.Manage.FeesChargesConfig;
using OmniGov.App.Views.Manage.RealProperties;
using OmniGov.App.Views.Manage.Receipts;
using OmniGov.App.Views.Manage.TaxPayers;
using OmniGov.App.Views.Transactions.Assessment;
using OmniGov.App.Views.Transactions.Auction;
using OmniGov.App.Views.Transactions.BankDeposits;
using OmniGov.App.Views.Transactions.Biddings;
using OmniGov.App.Views.Transactions.CheckIssuance;
using OmniGov.App.Views.Transactions.Payments.AF51And57;
using OmniGov.App.Views.Transactions.Payments.BurialPermit;
using OmniGov.App.Views.Transactions.Payments.CattleOwnership;
using OmniGov.App.Views.Transactions.Payments.CattleTransferOfOwnership;
using OmniGov.App.Views.Transactions.Payments.CommunityTaxCertificate;
using OmniGov.App.Views.Transactions.Payments.MarriageLicense;
using OmniGov.App.Views.Transactions.Payments.PaymentHistory;
using OmniGov.App.Views.Transactions.Payments.RealProperty;
using OmniGov.App.Views.Transactions.ReceiptsIssued;
using OmniGov.App.Views.Transactions.ReleasedAndUnReleasedChecks;

namespace OmniGov.App.Views.Dashboard.Treasury
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

        private void aF41CommunityTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCommunityTaxCertificate().ShowDialog();
        }

        private void af5157TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmAF51And57().ShowDialog();
        }

        private void af52TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmCattleTransfer().ShowDialog();
        }

        private void af53TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmCattleOwnership().ShowDialog();
        }

        private void af54TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmMarriageLicense().ShowDialog();
        }

        private void af56TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentRpt().ShowDialog();
        }

        private void af58TstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmBurialPermit().ShowDialog();
        }

        private void auctionTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmAuction().ShowDialog();
        }

        private void bankDepositTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void biddingTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmBiddings().ShowDialog();
        }

        private void checkIssuanceTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
        }

        private void collectingOfficersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficer().ShowDialog();
        }

        private void disbursementOfficersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficer().ShowDialog();
        }

        private void feesChargesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmFeesChargesConfig().ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCashTickets().ShowDialog();
        }

        private void issuanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCashTicketIssuance().ShowDialog();
        }

        private void propertyAssessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptDelinquencyNotices().ShowDialog();
        }

        private void propertyTaxPostingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ = new frmPrptyTaxPosting().ShowDialog();
        }

        private void pymntHstoryTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentHistory().ShowDialog();
        }

        private void realPropertiesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmRealProperties().ShowDialog();
        }

        private void receiptInventoryTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmReceipts().ShowDialog();
        }

        private void recieiptIssuanceTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssued().ShowDialog();
        }

        private void releasedAndUnreleaseChecksTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmReleasedAndUnreleaseChecks().ShowDialog();
        }

        private void taxpayersTstrpMnuItm_Click(object sender, EventArgs e)
        {
            _ = new frmTaxpayers().ShowDialog();
        }

        private void ValidatePermissions()
        {
            collectingOfficersTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngCollOfficer);
            disbursementOfficersTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngDisbOfficer);
            taxpayersTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngTaxpayers);
            feesChargesTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngFeesChargesCfg);
            realPropertiesTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngRealProps);
            checkIssuanceTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransIssueChk);
            bankDepositTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransBankDeposits);
            receiptInventoryTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngReceipts);
            recieiptIssuanceTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransIssueReceipt);
            receiptsToolStripMenuItem.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngReceipts)
                && PrivilegesHelper.HasPrivilege(Privileges.TransIssueReceipt);
            paymentsToolStripMenuItem.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransPayments);
            releasedAndUnreleaseChecksTstrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransReleaseChk);
            tStrpMenuItmPrptyTaxPosting.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransAssessPosting);
        }

        private void warrantsOfLevyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmWarrantLevy().ShowDialog();
        }
    }
}