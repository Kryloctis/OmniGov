using AccountingSystem.Views.Help;
using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.Amortization;
using AccountingSystem.Views.Manage.BankAccounts;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.Barangay;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Manage.BusinessAdOnCharges;
using AccountingSystem.Views.Manage.BusinessCategories;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DatabaseSynchronization;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FeesChargesConfig;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.Registry;
using AccountingSystem.Views.Manage.ReturnedReceipts;
using AccountingSystem.Views.Manage.RptDiscount;
using AccountingSystem.Views.Manage.RptPenalties;
using AccountingSystem.Views.Manage.RptTaxRates;
using AccountingSystem.Views.Manage.Signatories;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Manage.Users.Roles;
using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.DailyCashReport;
using AccountingSystem.Views.Reports.GeneralCollection;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.ReleasedAndUnreleasedCheques;
using AccountingSystem.Views.Reports.RptReports;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.SAAOBB;
using AccountingSystem.Views.Transactions.AssessmentPosting;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.ObligationRequest;
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
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, dynamic> userDict;
        private readonly frmSignIn signInForm;

        public MainForm(frmSignIn _signInForm)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ClearTabPages();
            userDict = Helper.LoggedInUserData();
            signInForm = _signInForm;
        }

        private void ClearTabPages()
        {
            tabControlDashboard.TabPages.Clear();
            tabControlAccounting.TabPages.Clear();
            tabControlLedgers.TabPages.Clear();
            tabControlTrialBalance.TabPages.Clear();
            tabControlFinancialStatements.TabPages.Clear();
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadLoggedInUser();
                ValidatePermissions();
                lblVersion.Text = Helper.GetVersionLog().Split('\n')[1];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadLoggedInUser()
        {
            lblUserFullName.Text = $"Welcome: {userDict["user_full_name"]}";
            lblUserRole.Text = userDict["role_name"];
        }

        #region Permission Validations

        private void ValidatePermissions()
        {
            ValidateDashboadPermissions();

            ValidateManagePermissions();

            ValidateBudgetPermissions();

            ValidateAccountingPermissions();

            ValidateTreasuryPermissions();
        }

        private void ValidateDashboadPermissions()
        {
            if (Helper.HasPermission("Dashboard > Budget"))
                tabControlDashboard.TabPages.Add(tabPageBudget);

            if (Helper.HasPermission("Dashboard > Accounting"))
                tabControlDashboard.TabPages.Add(tabPageAccounting);

            if (Helper.HasPermission("Dashboard > Treasury"))
                tabControlDashboard.TabPages.Add(tabPageTreasury);
        }

        private void ValidateTreasuryPermissions()
        {
            //Manage
            if (!Helper.HasPermission("Manage > Banks"))
                menuBanks.Enabled = false;

            if (!Helper.HasPermission("Manage > Collecting Officer"))
                menuCollectingOfficer.Enabled = false;

            if (!Helper.HasPermission("Manage > Accountable Forms"))
                menuAccForm.Enabled = false;

            if (!Helper.HasPermission("Manage > Disbursing Officer"))
                menuDisbursingOfficer.Enabled = false;

            if (!Helper.HasPermission("Manage > Taxpayers"))
                menuTaxPayers.Enabled = false;

            if (!Helper.HasPermission("Manage > Returned Receipts"))
                returnedReceiptsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Database Synchronization"))
                databaseSynchronizationToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Business Categories"))
                businessCategoriesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Business Add-on Charges"))
                businessAddOnToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Bank Accounts"))
                bankAccountsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Fees & Charges Config."))
                feesChargesConfigToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Real Properties"))
                RptToolStripButton.Enabled = false;

            //Transactions
            if (!Helper.HasPermission("Transaction > Issue Check"))
                checkIssuanceToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Check"))
                checkIssuanceToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Bank Deposits"))
                bankDepositToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Receipt"))
                issueRecieptsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Payments"))
                paymentsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Assessment Posting"))
                assessmentPostingToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Release / Unreleased Checks"))
                releasedAndUnreleaseChecksToolStripMenu.Enabled = false;

            //Reports
            if (!Helper.HasPermission("Report > List of Delinquent Accounts"))
                listOfRealPropertyDelinquenciesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Report of Checks Issued"))
                reportOfCheckIssuedRCIToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Report of Collections and Deposits"))
                reportOfCollectionsRCDToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Abstract of General Collections"))
                abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Bank Cashbook"))
                bankCashbookToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Consolidated Receipts"))
                consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Daily Cash Position"))
                dailyCashPositionsToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction > Generate RCD"))
            //    liquidatorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction > RCD Approval"))
            //    liquidatorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Report > Collector's RCD"))
            //    //collectorsRCDToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Real Property Tax Account Register (RPTAR)"))
                realPropertTaxDuesAndPaymentsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Consolidated Real Property Tax Dues"))
                certifiedListOfRealPropertyTaxDeliquenciesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Schedule of Released Cheques"))
                releasedChequesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Schedule of Unreleased Cheques"))
                unreleasedChequesToolStripMenuItem.Enabled = false;
        }

        private void ValidateBudgetPermissions()
        {
            //Manage
            if (!Helper.HasPermission("Manage > Allotment Releases"))
                toolStripButtonAllotmentRelease.Enabled = false;

            if (!Helper.HasPermission("Manage > Budget Appropriations"))
                toolStripButtonBudgetAppropriations.Enabled = false;

            //Reports
            if (!Helper.HasPermission("Report > SAAOB"))
                sAAOBToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > SAAOBB"))
                sAAOBBToolStripMenuItem.Enabled = false;
        }

        private void ValidateManagePermissions()
        {
            if (!Helper.HasPermission("Manage > Allotment Classes"))
                menuAllotmentClasses.Enabled = false;

            if (!Helper.HasPermission("Manage > Chart of Accounts"))
                menuChartOfAccounts.Enabled = false;

            if (!Helper.HasPermission("Manage > Function/Program/Project"))
                menuFunctionProgramProject.Enabled = false;

            if (!Helper.HasPermission("Manage > Funds"))
                menuFunds.Enabled = false;

            if (!Helper.HasPermission("Manage > Users") && !Helper.HasPermission("Manage Roles"))
                menuUsers.Enabled = false;

            if (!Helper.HasPermission("Manage > Users"))
                menuUserList.Enabled = false;

            if (!Helper.HasPermission("Manage > Roles"))
                menuRoles.Enabled = false;

            if (!Helper.HasPermission("Manage > Receipts"))
                receiptsInventoryToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Signatories"))
                signatoriesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Barangays"))
                barangaysToolStripMenuItem.Enabled = false;

            if (Helper.LoggedInUserData()["role_name"] != "System Administrator")
            {
                discountsToolStripMenuItem.Enabled = false;
                penaltiesToolStripMenuItem.Enabled = false;
                taxRatesToolStripMenuItem.Enabled = false;
            }
        }

        private void ValidateAccountingPermissions()
        {
            //Manage

            if (!Helper.HasPermission("Manage > Journals"))
                menuJournals.Enabled = false;

            //Transactions
            if (!Helper.HasPermission("Transaction > Obligation Request"))
                toolStripButtonObligation.Enabled = false;

            //Reports

            #region Journal Entry Voucher

            if (!Helper.HasPermission("Transaction > JEV"))
                ucJevDashboard1.btnAddJEV.Enabled = false;

            if (Helper.HasPermission("Transaction > JEV") || Helper.HasPermission("Report > JEVs"))
                tabControlAccounting.TabPages.Add(tabPageJournalEntryVoucher);

            #endregion Journal Entry Voucher

            #region Journals

            if (Helper.HasPermission("Report > General Journal") || Helper.HasPermission("Report > Cash Receipts Journal") || Helper.HasPermission("Report > Procurement Received Journal") || Helper.HasPermission("Report > Cash Disbursements Journal") || Helper.HasPermission("Report > Check Disbursements Journal") || Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
                tabControlAccounting.TabPages.Add(tabPageJournals);

            if (!Helper.HasPermission("Report > General Journal"))
                ucJournalsDashboard1.lnkGeneralJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Cash Receipts Journal"))
                ucJournalsDashboard1.lnkCashReceiptJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Procurement Received Journal"))
                ucJournalsDashboard1.lnkProcurementReceivedJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Cash Disbursements Journal"))
                ucJournalsDashboard1.lnkCashDisbursementJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Check Disbursements Journal"))
                ucJournalsDashboard1.lnkCheckDisbursementsJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
                ucJournalsDashboard1.lnkADAdisbursementsJournal.Enabled = false;

            #endregion Journals

            #region Ledgers

            //if (Helper.HasPermission("Report > Transaction Log"))
            //    tabControlLedgers.TabPages.Add(tabPageTransactionLog);

            if (Helper.HasPermission("Report > General Ledger"))
                tabControlLedgers.TabPages.Add(tabPageGeneralLedger);

            if (Helper.HasPermission("Report > Subsidiary Ledger"))
                tabControlLedgers.TabPages.Add(tabPageSubsidiaryLedger);

            if (Helper.HasPermission("Report > Summary Subsidiary Ledger"))
                tabControlLedgers.TabPages.Add(tabPageSummarySL);

            if (Helper.HasPermission("Report > General Ledger") || Helper.HasPermission("Report > Subsidiary Ledger"))
                tabControlAccounting.TabPages.Add(tabPageLedgers);

            #endregion Ledgers

            #region Trial Balance

            if (Helper.HasPermission("Report > Pre Trial Balance") || Helper.HasPermission("Report > Post Trial Balance"))
                tabControlAccounting.TabPages.Add(tabPageTrialBalance);

            if (Helper.HasPermission("Report > Pre Trial Balance"))
                tabControlTrialBalance.TabPages.Add(tabPagePreTrial);

            if (Helper.HasPermission("Report > Post Trial Balance"))
                tabControlTrialBalance.TabPages.Add(tabPagePostTrial);

            #endregion Trial Balance

            #region Financial Statements

            if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity") || Helper.HasPermission("Report > Statement of Financial Performance"))
                tabControlAccounting.TabPages.Add(tabPageFinancialStatements);

            if (Helper.HasPermission("Report > Statement of Financial Position"))
                tabControlFinancialStatements.TabPages.Add(tabPageSFPosition);

            if (Helper.HasPermission("Report > Statement of Financial Performance"))
                tabControlFinancialStatements.TabPages.Add(tabPageSFPerformance);

            if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCNAE);

            if (Helper.HasPermission("Report > Statement of Cash Flows"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCF);

            if (Helper.HasPermission("Report > Statement of Comparison of Budget and Actual Amounts"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCBAA);

            #endregion Financial Statements
        }

        #endregion Permission Validations

        private void menuJournals_Click(object sender, EventArgs e)
        {
            _ = new frmJournals().ShowDialog();
        }

        private void menuFunds_Click(object sender, EventArgs e)
        {
            _ = new frmFunds().ShowDialog();
        }

        private void menuChartOfAccounts_Click(object sender, EventArgs e)
        {
            _ = new frmChartOfAccounts().ShowDialog();
        }

        private void menuAllotmentClasses_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentClasses().ShowDialog();
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            _ = new frmRoles().ShowDialog();
        }

        private void menuUserList_Click(object sender, EventArgs e)
        {
            _ = new frmUsers().ShowDialog();
        }

        private void menuFunctionProgramProject_Click(object sender, EventArgs e)
        {
            _ = new frmFunctionProgramProject().ShowDialog();
        }

        private void menuBanks_Click(object sender, EventArgs e)
        {
            _ = new frmBanks().ShowDialog();
        }

        private void menuAccForm_Click(object sender, EventArgs e)
        {
            _ = new frmAccountableForm().ShowDialog();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            signInForm.Show();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            signInForm.Show();
        }

        private void amortiaztionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAmortization().ShowDialog();
        }

        private void signatoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSignatories().ShowDialog();
        }

        #region Budget Module

        private void toolStripButtonBudgetAppropriations_Click(object sender, EventArgs e)
        {
            _ = new frmBudgetAppropriations().ShowDialog();
        }

        private void toolStripButtonAllotmentRelease_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseMain().ShowDialog();
        }

        private void toolStripButtonObligation_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }

        #region SAAOB and SAAOBB report

        private void sAAOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOB().ShowDialog();
        }

        private void sAAOBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOBB().ShowDialog();
        }

        #endregion SAAOB and SAAOBB report

        #endregion Budget Module

        #region Treasury

        private void menuCollectingOfficer_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficer().ShowDialog();
        }

        private void MenuDisbursingOffice_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficer().ShowDialog();
        }

        private void issueRecieptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssued().ShowDialog();
        }

        private void reportOfCheckIssuedRCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCIReport().ShowDialog();
        }

        private void reportOfCollectionsRCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCD().ShowDialog();
        }

        private void abstractOfGeneralCollectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new AbstractOfGeneralCollection().ShowDialog();
        }

        private void bankCashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCashbook().ShowDialog();
        }

        private void consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmConsolidatedReceipts().ShowDialog();
        }

        private void dailyCashPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmDailyCash().ShowDialog();
        }

        private void certifiedListOfRealPropertyTaxDeliquenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCertifiedListRptDelinquences().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void returnedReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmReturnedReceipts().ShowDialog();
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptDiscounts(this).ShowDialog();
        }

        private void penaltyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptPenalties(this).ShowDialog();
        }

        private void taxRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxRates(this).ShowDialog();
        }

        private void CheckIssuanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
        }

        private void bankDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void assessmentPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAssessmentPosting().ShowDialog();
        }

        #endregion Treasury

        private void menuDatabaseSynchronization_Click(object sender, EventArgs e)
        {
            _ = new frmDatabaseSynchronization().ShowDialog();
        }

        private void menuTaxPayers_Click(object sender, EventArgs e)
        {
            _ = new frmTaxpayers().ShowDialog();
        }

        private void barangaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBarangay().ShowDialog();
        }

        private void toolStripButtonRpt_Click(object sender, EventArgs e)
        {
            _ = new frmRealProperties().ShowDialog();
        }

        private void businessCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBusinessCategories().ShowDialog();
        }

        private void businessAddOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBusinessAddOnCharges().ShowDialog();
        }

        private void releasedAndUnreleaseChecksToolStripMenu_Click(object sender, EventArgs e)
        {
            _ = new frmReleasedAndUnreleaseChecks().ShowDialog();
        }

        private void releasedChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmReleasedChecksReport().ShowDialog();
        }

        private void unreleasedChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmUnreleasedChequesReport().ShowDialog();
        }

        private void bankAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBankAccounts().ShowDialog();
        }

        private void feesChargesConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmFeesChargesConfig().ShowDialog();
        }

        private void aF5157ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAF51_57().ShowDialog();
        }

        private void rPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentRpt().ShowDialog();
        }

        private void aF54ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmMarriageLicense().ShowDialog();
        }

        private void aF58BurialPermitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBurialPermit().ShowDialog();
        }

        private void aF53CattleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCattleOwnership().ShowDialog();
        }

        private void registryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRegistry().ShowDialog();
        }

        private void realPropertTaxDuesAndPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptDuesPayments().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void listOfRealPropertyDelinquenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmListRptDelinquencies().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void realPropertyTaxStatementOfAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRealPropertyTaxStatementOfAccount().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmPaymentHistory().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void receiptsInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReceipts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void aboutLocalFinanceSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAboutRptMgmtApp();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private static void ShowAboutRptMgmtApp()
        {
            var frmUpdatess = new frmAbout();
            frmUpdatess.Show();
            frmUpdatess.TopMost = true;
        }

        private void aF52CattleTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCattleTransfer().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lTOM16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmNoticeOfDelinquencyInThePaymentOfRPT().ShowDialog();
        }

    }
}