using ACC.Data;
using AccountingSystem.Views.Dashboard.Accounting;
using AccountingSystem.Views.Dashboard.AccountingDashboard;
using AccountingSystem.Views.Dashboard.Budget;
using AccountingSystem.Views.Dashboard.Settings;
using AccountingSystem.Views.Dashboard.Treasury;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountingSystem.Views.Dashboard
{
    public partial class frmMain : Form
    {
        private frmSignIn frmSignIn;
        private ucBudget ucBudget;
        private ucAccounting ucAccounting;
        private ucTreasury ucTreasury;
        private ucSettings ucSettings;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmSignIn = frmSignIn;

            //Removes tabs to tabcontrol
            tabControlMain.Padding = new Point(0, 0);
            tabControlMain.ItemSize = new Size(0, 1);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.ucBudget = ucBudget1;
            this.ucAccounting = ucAccounting1;
            this.ucTreasury = ucTreasury1;
            this.ucSettings = ucSettings1;
        }

        #region Permission Validations

        private void ValidatePermissions()
        {
            ValidateDashboadPermissions();

            //ValidateManagePermissions();

            //ValidateBudgetPermissions();

            //ValidateAccountingPermissions();

            //ValidateTreasuryPermissions();
        }

        private void ValidateDashboadPermissions()
        {
            if (!Helper.HasPermission("Dashboard > Budget"))
            {
                tabControlMain.TabPages.Remove(tabPageBudget);
                radBudget.Visible = false;
            }

            if (!Helper.HasPermission("Dashboard > Accounting"))
            {
                tabControlMain.TabPages.Remove(tabPageAccounting);
                radAccounting.Visible = false;
            }

            if (!Helper.HasPermission("Dashboard > Treasury"))
            {
                tabControlMain.TabPages.Remove(tabPageTreasury);
                radTreasury.Visible = false;
            }
        }

        //private void ValidateTreasuryPermissions()
        //{
        //    //Manage
        //    if (!Helper.HasPermission("Manage > Banks"))
        //        menuBanks.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Collecting Officer"))
        //        menuCollectingOfficer.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Accountable Forms"))
        //        menuAccForm.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Disbursing Officer"))
        //        menuDisbursingOfficer.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Taxpayers"))
        //        menuTaxPayers.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Returned Receipts"))
        //        returnedReceiptsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Database Synchronization"))
        //        databaseSynchronizationToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Business Categories"))
        //        businessCategoriesToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Business Add-on Charges"))
        //        businessAddOnToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Bank Accounts"))
        //        bankAccountsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Fees & Charges Config."))
        //        feesChargesConfigToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Real Properties"))
        //        RptToolStripButton.Enabled = false;

        //    //Transactions
        //    if (!Helper.HasPermission("Transaction > Issue Check"))
        //        checkIssuanceToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Issue Check"))
        //        checkIssuanceToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Bank Deposits"))
        //        bankDepositToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Issue Receipt"))
        //        issueRecieptsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Payments"))
        //        paymentsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Assessment Posting"))
        //        assessmentPostingToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Transaction > Release / Unreleased Checks"))
        //        releasedAndUnreleaseChecksToolStripMenu.Enabled = false;

        //    //Reports
        //    if (!Helper.HasPermission("Report > List of Delinquent Accounts"))
        //        listOfRealPropertyDelinquenciesToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Report of Checks Issued"))
        //        reportOfCheckIssuedRCIToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Report of Collections and Deposits"))
        //        reportOfCollectionsRCDToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Abstract of General Collections"))
        //        abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Bank Cashbook"))
        //        bankCashbookToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Consolidated Receipts"))
        //        consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Daily Cash Position"))
        //        dailyCashPositionsToolStripMenuItem.Enabled = false;

        //    //if (!Helper.HasPermission("Transaction > Generate RCD"))
        //    //    liquidatorsRCDToolStripMenuItem.Enabled = false;

        //    //if (!Helper.HasPermission("Transaction > RCD Approval"))
        //    //    liquidatorsRCDToolStripMenuItem.Enabled = false;

        //    //if (!Helper.HasPermission("Report > Collector's RCD"))
        //    //    //collectorsRCDToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Real Property Tax Account Register (RPTAR)"))
        //        realPropertTaxDuesAndPaymentsToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Consolidated Real Property Tax Dues"))
        //        certifiedListOfRealPropertyTaxDeliquenciesToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Schedule of Released Cheques"))
        //        releasedChequesToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > Schedule of Unreleased Cheques"))
        //        unreleasedChequesToolStripMenuItem.Enabled = false;
        //}

        //private void ValidateBudgetPermissions()
        //{
        //    //Manage
        //    if (!Helper.HasPermission("Manage > Allotment Releases"))
        //        toolStripButtonAllotmentRelease.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Budget Appropriations"))
        //        toolStripButtonBudgetAppropriations.Enabled = false;

        //    //Reports
        //    if (!Helper.HasPermission("Report > SAAOB"))
        //        sAAOBToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Report > SAAOBB"))
        //        sAAOBBToolStripMenuItem.Enabled = false;
        //}

        //private void ValidateManagePermissions()
        //{
        //    if (!Helper.HasPermission("Manage > Allotment Classes"))
        //        menuAllotmentClasses.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Chart of Accounts"))
        //        menuChartOfAccounts.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Function/Program/Project"))
        //        menuFunctionProgramProject.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Funds"))
        //        menuFunds.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Users") && !Helper.HasPermission("Manage Roles"))
        //        menuUsers.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Users"))
        //        menuUserList.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Roles"))
        //        menuRoles.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Receipts"))
        //        receiptsInventoryToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Signatories"))
        //        signatoriesToolStripMenuItem.Enabled = false;

        //    if (!Helper.HasPermission("Manage > Barangays"))
        //        barangaysToolStripMenuItem.Enabled = false;

        //    if (Helper.LoggedInUserData()["role_name"] != "System Administrator")
        //    {
        //        discountsToolStripMenuItem.Enabled = false;
        //        penaltiesToolStripMenuItem.Enabled = false;
        //        taxRatesToolStripMenuItem.Enabled = false;
        //    }
        //}

        //private void ValidateAccountingPermissions()
        //{
        //    //Manage

        //    if (!Helper.HasPermission("Manage > Journals"))
        //        menuJournals.Enabled = false;

        //    //Transactions
        //    if (!Helper.HasPermission("Transaction > Obligation Request"))
        //        toolStripButtonObligation.Enabled = false;

        //    //Reports

        //    #region Journal Entry Voucher

        //    if (Helper.HasPermission("Transaction > JEV") || Helper.HasPermission("Report > JEVs"))
        //        tabControlAccounting.TabPages.Add(tabPageJournalEntryVoucher);

        //    #endregion Journal Entry Voucher

        //    #region Journals

        //    if (Helper.HasPermission("Report > General Journal") || Helper.HasPermission("Report > Cash Receipts Journal") || Helper.HasPermission("Report > Procurement Received Journal") || Helper.HasPermission("Report > Cash Disbursements Journal") || Helper.HasPermission("Report > Check Disbursements Journal") || Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
        //        tabControlAccounting.TabPages.Add(tabPageJournals);

        //    if (!Helper.HasPermission("Report > General Journal"))
        //        ucJournalsDashboard1.lnkGeneralJournal.Enabled = false;

        //    if (!Helper.HasPermission("Report > Cash Receipts Journal"))
        //        ucJournalsDashboard1.lnkCashReceiptJournal.Enabled = false;

        //    if (!Helper.HasPermission("Report > Procurement Received Journal"))
        //        ucJournalsDashboard1.lnkProcurementReceivedJournal.Enabled = false;

        //    if (!Helper.HasPermission("Report > Cash Disbursements Journal"))
        //        ucJournalsDashboard1.lnkCashDisbursementJournal.Enabled = false;

        //    if (!Helper.HasPermission("Report > Check Disbursements Journal"))
        //        ucJournalsDashboard1.lnkCheckDisbursementsJournal.Enabled = false;

        //    if (!Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
        //        ucJournalsDashboard1.lnkADAdisbursementsJournal.Enabled = false;

        //    #endregion Journals

        //    #region Ledgers

        //    //if (Helper.HasPermission("Report > Transaction Log"))
        //    //    tabControlLedgers.TabPages.Add(tabPageTransactionLog);

        //    if (Helper.HasPermission("Report > General Ledger"))
        //        tabControlLedgers.TabPages.Add(tabPageGeneralLedger);

        //    if (Helper.HasPermission("Report > Subsidiary Ledger"))
        //        tabControlLedgers.TabPages.Add(tabPageSubsidiaryLedger);

        //    if (Helper.HasPermission("Report > Summary Subsidiary Ledger"))
        //        tabControlLedgers.TabPages.Add(tabPageSummarySL);

        //    if (Helper.HasPermission("Report > General Ledger") || Helper.HasPermission("Report > Subsidiary Ledger"))
        //        tabControlAccounting.TabPages.Add(tabPageLedgers);

        //    #endregion Ledgers

        //    #region Trial Balance

        //    if (Helper.HasPermission("Report > Pre Trial Balance") || Helper.HasPermission("Report > Post Trial Balance"))
        //        tabControlAccounting.TabPages.Add(tabPageTrialBalance);

        //    if (Helper.HasPermission("Report > Pre Trial Balance"))
        //        tabControlTrialBalance.TabPages.Add(tabPagePreTrial);

        //    if (Helper.HasPermission("Report > Post Trial Balance"))
        //        tabControlTrialBalance.TabPages.Add(tabPagePostTrial);

        //    #endregion Trial Balance

        //    #region Financial Statements

        //    if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity") || Helper.HasPermission("Report > Statement of Financial Performance"))
        //        tabControlAccounting.TabPages.Add(tabPageFinancialStatements);

        //    if (Helper.HasPermission("Report > Statement of Financial Position"))
        //        tabControlFinancialStatements.TabPages.Add(tabPageSFPosition);

        //    if (Helper.HasPermission("Report > Statement of Financial Performance"))
        //        tabControlFinancialStatements.TabPages.Add(tabPageSFPerformance);

        //    if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity"))
        //        tabControlFinancialStatements.TabPages.Add(tabPageSCNAE);

        //    if (Helper.HasPermission("Report > Statement of Cash Flows"))
        //        tabControlFinancialStatements.TabPages.Add(tabPageSCF);

        //    if (Helper.HasPermission("Report > Statement of Comparison of Budget and Actual Amounts"))
        //        tabControlFinancialStatements.TabPages.Add(tabPageSCBAA);

        //    #endregion Financial Statements
        //}

        #endregion Permission Validations

        private void radBudget_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageBudget;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadTabPagesContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageBudget":
                    ucBudget.OnloadEvent();
                    radBudget.Checked = true;
                    break;

                case "tabPageAccounting":
                    ucAccounting.OnLoad();
                    radAccounting.Checked = true;
                    break;

                case "tabPageTreasury":
                    radTreasury.Checked = true;
                    break;

                case "tabPageSettings":
                    ucSettings.OnLoad();
                    radSettings.Checked = true;
                    break;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                ValidatePermissions();
                LoadTabPagesContents(tabControlMain);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radAccounting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageAccounting;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radTreasury_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageTreasury;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                frmSignIn.Show();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSignIn.Show();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radSettings_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageSettings;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabPagesContents(tabControlMain);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}