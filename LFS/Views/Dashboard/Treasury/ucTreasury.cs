using LFS.Helpers;
using LFS.Views.Manage.CashTickets;
using LFS.Views.Manage.CollectingOfficer;
using LFS.Views.Manage.DisbursingOfficer;
using LFS.Views.Manage.FeesChargesConfig;
using LFS.Views.Manage.RealProperties;
using LFS.Views.Manage.Receipts;
using LFS.Views.Manage.TaxPayers;
using LFS.Views.Transactions.Assessment;
using LFS.Views.Transactions.Auction;
using LFS.Views.Transactions.BankDeposits;
using LFS.Views.Transactions.Biddings;
using LFS.Views.Transactions.CashTicketIssuance;
using LFS.Views.Transactions.Payments;
using LFS.Views.Transactions.Payments.AF51_57;
using LFS.Views.Transactions.Payments.BurialPermit;
using LFS.Views.Transactions.Payments.CattleOwnership;
using LFS.Views.Transactions.Payments.CattleTransferOfOwnership;
using LFS.Views.Transactions.Payments.CommunityTaxCertificate;
using LFS.Views.Transactions.Payments.MarriageLicense;
using LFS.Views.Transactions.Payments.PaymentHistory;
using LFS.Views.Transactions.RCI;
using LFS.Views.Transactions.ReceiptsIssued;
using LFS.Views.Transactions.ReleasedAndUnReleasedChecks;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Treasury
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
                _ = new frmPrptyTaxPosting().ShowDialog();
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

        private void issuanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashTicketIssuance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
