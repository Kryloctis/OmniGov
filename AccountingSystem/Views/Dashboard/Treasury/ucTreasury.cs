using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FeesChargesConfig;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.DailyCashReport;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.ReleasedAndUnreleasedCheques;
using AccountingSystem.Views.Reports.RptReports;
using AccountingSystem.Views.Transactions.AssessmentPosting;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.Payments;
using AccountingSystem.Views.Transactions.Payments.AF51_57;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using AccountingSystem.Views.Transactions.Payments.CattleOwnership;
using AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership;
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

        private void assessmentPostingTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAssessmentPosting().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void auctionTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new NotImplementedException();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void biddingTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new NotImplementedException();
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

        private void rcdTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRcd().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rptStatementOfAccTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRealPropertyTaxStatementOfAccount().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void listOfRealPropertyDelinquenciesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmListRptDelinquencies().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void rptDuesAndPymntsTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptDuesPayments().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void crtfdListOfRptDeliquenciesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCertifiedListRptDelinquences().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bankCashbookTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashbook().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void reportOfCheckIssuedRciTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRCIReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void schedReleasedChequesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReleasedChecksReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void schedUnreleasedChequesTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmUnreleasedChequesReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void consolidatedReportOfAccountabilityForAccFormsTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmConsolidatedReceipts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dailyCashPositionsTstrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmDailyCash().ShowDialog();
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
    }
}