namespace AccountingSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.barangaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunds = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuJournals = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunctionProgramProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChartOfAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAllotmentClasses = new System.Windows.Forms.ToolStripMenuItem();
            this.amortiaztionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCollectingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisbursingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanks = new System.Windows.Forms.ToolStripMenuItem();
            this.bankAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTaxPayers = new System.Windows.Forms.ToolStripMenuItem();
            this.businessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessAddOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.discountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penaltyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDatabaseSynchronization = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlDashboard = new System.Windows.Forms.TabControl();
            this.tabPageBudget = new System.Windows.Forms.TabPage();
            this.tabControlBudget = new System.Windows.Forms.TabControl();
            this.tabPageBudgetDetailed = new System.Windows.Forms.TabPage();
            this.ucBudgetDetailed1 = new AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed();
            this.tabPageBudgetSummary = new System.Windows.Forms.TabPage();
            this.ucBudgetSummary1 = new AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBudgetAppropriations = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAllotmentRelease = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonObligation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.sAAOBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAAOBBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageAccounting = new System.Windows.Forms.TabPage();
            this.tabControlAccounting = new System.Windows.Forms.TabControl();
            this.tabPageJournalEntryVoucher = new System.Windows.Forms.TabPage();
            this.ucjevDashboard1 = new AccountingSystem.Views.Dashboard.ucJEVDashboard();
            this.tabPageJournals = new System.Windows.Forms.TabPage();
            this.ucJournalsDashboard1 = new AccountingSystem.Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            this.tabPageLedgers = new System.Windows.Forms.TabPage();
            this.tabControlLedgers = new System.Windows.Forms.TabControl();
            this.tabPageTransactionLog = new System.Windows.Forms.TabPage();
            this.ucTransactionLog1 = new AccountingSystem.Views.Reports.Ledgers.ucTransactionLog();
            this.tabPageSubsidiaryLedger = new System.Windows.Forms.TabPage();
            this.ucSubsidiaryLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucSubsidiaryLedger();
            this.tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            this.ucGeneralLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucGeneralLedger();
            this.tabPageTrialBalance = new System.Windows.Forms.TabPage();
            this.tabControlTrialBalance = new System.Windows.Forms.TabControl();
            this.tabPagePostTrial = new System.Windows.Forms.TabPage();
            this.ucPostClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPostClosingTrialBalance();
            this.tabPagePreTrial = new System.Windows.Forms.TabPage();
            this.ucPreClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPreClosingTrialBalance();
            this.tabPageFinancialStatements = new System.Windows.Forms.TabPage();
            this.tabControlFinancialStatements = new System.Windows.Forms.TabControl();
            this.tabPageSCBAA = new System.Windows.Forms.TabPage();
            this.tabPageSCF = new System.Windows.Forms.TabPage();
            this.ucStatementOfCashFlows1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfCashFlows();
            this.tabPageSCNAE = new System.Windows.Forms.TabPage();
            this.ucStatementOfChangesInNetAssetsEquity1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity();
            this.tabPageSFPerformance = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPerformance1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance();
            this.tabPageSFPosition = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPosition1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPosition();
            this.tabPageTreasury = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucrcdSummary1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucRCDSummary();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.issueRecieptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnedReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonRpt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBpl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.assessmentPostingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.checkIssuanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasedAndUnreleaseChecksToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bankDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.collectorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidatorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.collectionPaymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOfCollectionsDepositsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abstractOfGeneralCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realPropertyTaxStatementOfAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfDelinquentAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.reportOfCheckIssuedRCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releasedChequesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unreleasedChequesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankCashbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCashPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabPageBudget.SuspendLayout();
            this.tabControlBudget.SuspendLayout();
            this.tabPageBudgetDetailed.SuspendLayout();
            this.tabPageBudgetSummary.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPageAccounting.SuspendLayout();
            this.tabControlAccounting.SuspendLayout();
            this.tabPageJournalEntryVoucher.SuspendLayout();
            this.tabPageJournals.SuspendLayout();
            this.tabPageLedgers.SuspendLayout();
            this.tabControlLedgers.SuspendLayout();
            this.tabPageTransactionLog.SuspendLayout();
            this.tabPageSubsidiaryLedger.SuspendLayout();
            this.tabPageGeneralLedger.SuspendLayout();
            this.tabPageTrialBalance.SuspendLayout();
            this.tabControlTrialBalance.SuspendLayout();
            this.tabPagePostTrial.SuspendLayout();
            this.tabPagePreTrial.SuspendLayout();
            this.tabPageFinancialStatements.SuspendLayout();
            this.tabControlFinancialStatements.SuspendLayout();
            this.tabPageSCF.SuspendLayout();
            this.tabPageSCNAE.SuspendLayout();
            this.tabPageSFPerformance.SuspendLayout();
            this.tabPageSFPosition.SuspendLayout();
            this.tabPageTreasury.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuManage});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1229, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referencesToolStripMenuItem,
            this.menuLogout,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 24);
            this.menuFile.Text = "File";
            // 
            // referencesToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.Enabled = false;
            this.referencesToolStripMenuItem.Name = "referencesToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.referencesToolStripMenuItem.Text = "Preferences...";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(144, 22);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(144, 22);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // menuManage
            // 
            this.menuManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsers,
            this.barangaysToolStripMenuItem,
            this.signatoriesToolStripMenuItem,
            this.menuFunds,
            this.toolStripSeparator2,
            this.menuJournals,
            this.menuFunctionProgramProject,
            this.menuChartOfAccounts,
            this.menuAllotmentClasses,
            this.amortiaztionToolStripMenuItem,
            this.toolStripSeparator3,
            this.menuCollectingOfficer,
            this.menuDisbursingOfficer,
            this.menuBanks,
            this.bankAccountsToolStripMenuItem,
            this.menuAccForm,
            this.menuReceipts,
            this.menuTaxPayers,
            this.businessToolStripMenuItem,
            this.toolStripSeparator1,
            this.discountToolStripMenuItem,
            this.penaltyToolStripMenuItem,
            this.taxRateToolStripMenuItem,
            this.toolStripSeparator9,
            this.menuDatabaseSynchronization});
            this.menuManage.Name = "menuManage";
            this.menuManage.Size = new System.Drawing.Size(62, 24);
            this.menuManage.Text = "Manage";
            // 
            // menuUsers
            // 
            this.menuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserList,
            this.menuRoles});
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(223, 22);
            this.menuUsers.Text = "Users";
            // 
            // menuUserList
            // 
            this.menuUserList.Name = "menuUserList";
            this.menuUserList.Size = new System.Drawing.Size(111, 22);
            this.menuUserList.Text = "List...";
            this.menuUserList.Click += new System.EventHandler(this.menuUserList_Click);
            // 
            // menuRoles
            // 
            this.menuRoles.Name = "menuRoles";
            this.menuRoles.Size = new System.Drawing.Size(111, 22);
            this.menuRoles.Text = "Roles...";
            this.menuRoles.Click += new System.EventHandler(this.menuRoles_Click);
            // 
            // barangaysToolStripMenuItem
            // 
            this.barangaysToolStripMenuItem.Name = "barangaysToolStripMenuItem";
            this.barangaysToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.barangaysToolStripMenuItem.Text = "Barangays...";
            this.barangaysToolStripMenuItem.Click += new System.EventHandler(this.barangaysToolStripMenuItem_Click);
            // 
            // signatoriesToolStripMenuItem
            // 
            this.signatoriesToolStripMenuItem.Name = "signatoriesToolStripMenuItem";
            this.signatoriesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.signatoriesToolStripMenuItem.Text = "Signatories...";
            this.signatoriesToolStripMenuItem.Click += new System.EventHandler(this.signatoriesToolStripMenuItem_Click);
            // 
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(223, 22);
            this.menuFunds.Text = "Funds...";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // menuJournals
            // 
            this.menuJournals.Name = "menuJournals";
            this.menuJournals.Size = new System.Drawing.Size(223, 22);
            this.menuJournals.Text = "Journals...";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(223, 22);
            this.menuFunctionProgramProject.Text = "Function/Program/Project...";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuChartOfAccounts
            // 
            this.menuChartOfAccounts.Name = "menuChartOfAccounts";
            this.menuChartOfAccounts.Size = new System.Drawing.Size(223, 22);
            this.menuChartOfAccounts.Text = "Chart of Accounts...";
            this.menuChartOfAccounts.Click += new System.EventHandler(this.menuChartOfAccounts_Click);
            // 
            // menuAllotmentClasses
            // 
            this.menuAllotmentClasses.Name = "menuAllotmentClasses";
            this.menuAllotmentClasses.Size = new System.Drawing.Size(223, 22);
            this.menuAllotmentClasses.Text = "Allotment Classes...";
            this.menuAllotmentClasses.Click += new System.EventHandler(this.menuAllotmentClasses_Click);
            // 
            // amortiaztionToolStripMenuItem
            // 
            this.amortiaztionToolStripMenuItem.Enabled = false;
            this.amortiaztionToolStripMenuItem.Name = "amortiaztionToolStripMenuItem";
            this.amortiaztionToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.amortiaztionToolStripMenuItem.Text = "Amortization...";
            this.amortiaztionToolStripMenuItem.Click += new System.EventHandler(this.amortiaztionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(223, 22);
            this.menuCollectingOfficer.Text = "Collecting Officers...";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuDisbursingOfficer
            // 
            this.menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            this.menuDisbursingOfficer.Size = new System.Drawing.Size(223, 22);
            this.menuDisbursingOfficer.Text = "Disbursing Officers...";
            this.menuDisbursingOfficer.Click += new System.EventHandler(this.MenuDisbursingOffice_Click);
            // 
            // menuBanks
            // 
            this.menuBanks.Name = "menuBanks";
            this.menuBanks.Size = new System.Drawing.Size(223, 22);
            this.menuBanks.Text = "Banks...";
            this.menuBanks.Click += new System.EventHandler(this.menuBanks_Click);
            // 
            // bankAccountsToolStripMenuItem
            // 
            this.bankAccountsToolStripMenuItem.Name = "bankAccountsToolStripMenuItem";
            this.bankAccountsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.bankAccountsToolStripMenuItem.Text = "Bank Accounts...";
            this.bankAccountsToolStripMenuItem.Click += new System.EventHandler(this.bankAccountsToolStripMenuItem_Click);
            // 
            // menuAccForm
            // 
            this.menuAccForm.Name = "menuAccForm";
            this.menuAccForm.Size = new System.Drawing.Size(223, 22);
            this.menuAccForm.Text = "Accountable Form...";
            this.menuAccForm.Click += new System.EventHandler(this.menuAccForm_Click);
            // 
            // menuReceipts
            // 
            this.menuReceipts.Name = "menuReceipts";
            this.menuReceipts.Size = new System.Drawing.Size(223, 22);
            this.menuReceipts.Text = "Receipts...";
            this.menuReceipts.Click += new System.EventHandler(this.menureceipts_Click);
            // 
            // menuTaxPayers
            // 
            this.menuTaxPayers.Name = "menuTaxPayers";
            this.menuTaxPayers.Size = new System.Drawing.Size(223, 22);
            this.menuTaxPayers.Text = "Taxpayers...";
            this.menuTaxPayers.Click += new System.EventHandler(this.menuTaxPayers_Click);
            // 
            // businessToolStripMenuItem
            // 
            this.businessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.businessCategoriesToolStripMenuItem,
            this.businessAddOnToolStripMenuItem});
            this.businessToolStripMenuItem.Enabled = false;
            this.businessToolStripMenuItem.Name = "businessToolStripMenuItem";
            this.businessToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.businessToolStripMenuItem.Text = "Business";
            // 
            // businessCategoriesToolStripMenuItem
            // 
            this.businessCategoriesToolStripMenuItem.Name = "businessCategoriesToolStripMenuItem";
            this.businessCategoriesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.businessCategoriesToolStripMenuItem.Text = "Business Categories";
            this.businessCategoriesToolStripMenuItem.Click += new System.EventHandler(this.businessCategoriesToolStripMenuItem_Click);
            // 
            // businessAddOnToolStripMenuItem
            // 
            this.businessAddOnToolStripMenuItem.Name = "businessAddOnToolStripMenuItem";
            this.businessAddOnToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.businessAddOnToolStripMenuItem.Text = "Business Add-on Charges";
            this.businessAddOnToolStripMenuItem.Click += new System.EventHandler(this.businessAddOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // discountToolStripMenuItem
            // 
            this.discountToolStripMenuItem.Name = "discountToolStripMenuItem";
            this.discountToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.discountToolStripMenuItem.Text = "Discounts...";
            this.discountToolStripMenuItem.Click += new System.EventHandler(this.discountToolStripMenuItem_Click);
            // 
            // penaltyToolStripMenuItem
            // 
            this.penaltyToolStripMenuItem.Name = "penaltyToolStripMenuItem";
            this.penaltyToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.penaltyToolStripMenuItem.Text = "Penalties...";
            this.penaltyToolStripMenuItem.Click += new System.EventHandler(this.penaltyToolStripMenuItem_Click);
            // 
            // taxRateToolStripMenuItem
            // 
            this.taxRateToolStripMenuItem.Name = "taxRateToolStripMenuItem";
            this.taxRateToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.taxRateToolStripMenuItem.Text = "Tax Rates...";
            this.taxRateToolStripMenuItem.Click += new System.EventHandler(this.taxRateToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(220, 6);
            // 
            // menuDatabaseSynchronization
            // 
            this.menuDatabaseSynchronization.Name = "menuDatabaseSynchronization";
            this.menuDatabaseSynchronization.Size = new System.Drawing.Size(223, 22);
            this.menuDatabaseSynchronization.Text = "Database Synchronization...";
            this.menuDatabaseSynchronization.Click += new System.EventHandler(this.menuDatabaseSynchronization_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserFullName,
            this.lblUserRole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1229, 24);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUserFullName
            // 
            this.lblUserFullName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblUserFullName.Name = "lblUserFullName";
            this.lblUserFullName.Size = new System.Drawing.Size(82, 19);
            this.lblUserFullName.Text = "lblUserDetails";
            // 
            // lblUserRole
            // 
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(118, 19);
            this.lblUserRole.Text = "toolStripStatusLabel2";
            // 
            // tabControlDashboard
            // 
            this.tabControlDashboard.Controls.Add(this.tabPageBudget);
            this.tabControlDashboard.Controls.Add(this.tabPageAccounting);
            this.tabControlDashboard.Controls.Add(this.tabPageTreasury);
            this.tabControlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDashboard.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlDashboard.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControlDashboard.Location = new System.Drawing.Point(0, 24);
            this.tabControlDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlDashboard.Name = "tabControlDashboard";
            this.tabControlDashboard.Padding = new System.Drawing.Point(30, 3);
            this.tabControlDashboard.SelectedIndex = 0;
            this.tabControlDashboard.Size = new System.Drawing.Size(1229, 660);
            this.tabControlDashboard.TabIndex = 9;
            // 
            // tabPageBudget
            // 
            this.tabPageBudget.Controls.Add(this.tabControlBudget);
            this.tabPageBudget.Controls.Add(this.toolStrip1);
            this.tabPageBudget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageBudget.Location = new System.Drawing.Point(4, 34);
            this.tabPageBudget.Name = "tabPageBudget";
            this.tabPageBudget.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tabPageBudget.Size = new System.Drawing.Size(1221, 622);
            this.tabPageBudget.TabIndex = 3;
            this.tabPageBudget.Text = "Budget";
            this.tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // tabControlBudget
            // 
            this.tabControlBudget.Controls.Add(this.tabPageBudgetDetailed);
            this.tabControlBudget.Controls.Add(this.tabPageBudgetSummary);
            this.tabControlBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBudget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlBudget.ItemSize = new System.Drawing.Size(100, 20);
            this.tabControlBudget.Location = new System.Drawing.Point(3, 40);
            this.tabControlBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlBudget.Multiline = true;
            this.tabControlBudget.Name = "tabControlBudget";
            this.tabControlBudget.Padding = new System.Drawing.Point(0, 0);
            this.tabControlBudget.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlBudget.RightToLeftLayout = true;
            this.tabControlBudget.SelectedIndex = 0;
            this.tabControlBudget.Size = new System.Drawing.Size(1215, 579);
            this.tabControlBudget.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlBudget.TabIndex = 10;
            // 
            // tabPageBudgetDetailed
            // 
            this.tabPageBudgetDetailed.Controls.Add(this.ucBudgetDetailed1);
            this.tabPageBudgetDetailed.Location = new System.Drawing.Point(4, 24);
            this.tabPageBudgetDetailed.Name = "tabPageBudgetDetailed";
            this.tabPageBudgetDetailed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetDetailed.Size = new System.Drawing.Size(1207, 551);
            this.tabPageBudgetDetailed.TabIndex = 3;
            this.tabPageBudgetDetailed.Text = "Detailed";
            this.tabPageBudgetDetailed.UseVisualStyleBackColor = true;
            // 
            // ucBudgetDetailed1
            // 
            this.ucBudgetDetailed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetDetailed1.Location = new System.Drawing.Point(3, 3);
            this.ucBudgetDetailed1.Name = "ucBudgetDetailed1";
            this.ucBudgetDetailed1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucBudgetDetailed1.Size = new System.Drawing.Size(1201, 545);
            this.ucBudgetDetailed1.TabIndex = 0;
            // 
            // tabPageBudgetSummary
            // 
            this.tabPageBudgetSummary.AutoScroll = true;
            this.tabPageBudgetSummary.Controls.Add(this.ucBudgetSummary1);
            this.tabPageBudgetSummary.Location = new System.Drawing.Point(4, 24);
            this.tabPageBudgetSummary.Name = "tabPageBudgetSummary";
            this.tabPageBudgetSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetSummary.Size = new System.Drawing.Size(1207, 551);
            this.tabPageBudgetSummary.TabIndex = 2;
            this.tabPageBudgetSummary.Text = "Summary";
            this.tabPageBudgetSummary.UseVisualStyleBackColor = true;
            // 
            // ucBudgetSummary1
            // 
            this.ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetSummary1.Location = new System.Drawing.Point(3, 3);
            this.ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBudgetSummary1.Name = "ucBudgetSummary1";
            this.ucBudgetSummary1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucBudgetSummary1.Size = new System.Drawing.Size(1201, 545);
            this.ucBudgetSummary1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBudgetAppropriations,
            this.toolStripButtonAllotmentRelease,
            this.toolStripButtonObligation,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1215, 35);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonBudgetAppropriations
            // 
            this.toolStripButtonBudgetAppropriations.Image = global::AccountingSystem.Properties.Resources.view_list_money_banknotes_20px;
            this.toolStripButtonBudgetAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBudgetAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBudgetAppropriations.Name = "toolStripButtonBudgetAppropriations";
            this.toolStripButtonBudgetAppropriations.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripButtonBudgetAppropriations.Size = new System.Drawing.Size(159, 32);
            this.toolStripButtonBudgetAppropriations.Text = "Budget Appropriations";
            this.toolStripButtonBudgetAppropriations.Click += new System.EventHandler(this.toolStripButtonBudgetAppropriations_Click);
            // 
            // toolStripButtonAllotmentRelease
            // 
            this.toolStripButtonAllotmentRelease.Image = global::AccountingSystem.Properties.Resources.money_banknotes_1_filled_arrow_right_filled_20px;
            this.toolStripButtonAllotmentRelease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAllotmentRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAllotmentRelease.Name = "toolStripButtonAllotmentRelease";
            this.toolStripButtonAllotmentRelease.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripButtonAllotmentRelease.Size = new System.Drawing.Size(134, 32);
            this.toolStripButtonAllotmentRelease.Text = "Allotment Release";
            this.toolStripButtonAllotmentRelease.Click += new System.EventHandler(this.toolStripButtonAllotmentRelease_Click);
            // 
            // toolStripButtonObligation
            // 
            this.toolStripButtonObligation.Image = global::AccountingSystem.Properties.Resources.give_money_2_20px;
            this.toolStripButtonObligation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonObligation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonObligation.Name = "toolStripButtonObligation";
            this.toolStripButtonObligation.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripButtonObligation.Size = new System.Drawing.Size(95, 32);
            this.toolStripButtonObligation.Text = "Obligation";
            this.toolStripButtonObligation.Click += new System.EventHandler(this.toolStripButtonObligation_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sAAOBToolStripMenuItem,
            this.sAAOBBToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::AccountingSystem.Properties.Resources.documents_3_20px;
            this.toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStripSplitButton1.Size = new System.Drawing.Size(91, 32);
            this.toolStripSplitButton1.Text = "Reports";
            // 
            // sAAOBToolStripMenuItem
            // 
            this.sAAOBToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sAAOBToolStripMenuItem.Name = "sAAOBToolStripMenuItem";
            this.sAAOBToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.sAAOBToolStripMenuItem.Text = "SAAOB";
            this.sAAOBToolStripMenuItem.Click += new System.EventHandler(this.sAAOBToolStripMenuItem_Click);
            // 
            // sAAOBBToolStripMenuItem
            // 
            this.sAAOBBToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sAAOBBToolStripMenuItem.Name = "sAAOBBToolStripMenuItem";
            this.sAAOBBToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.sAAOBBToolStripMenuItem.Text = "SAAOBB";
            this.sAAOBBToolStripMenuItem.Click += new System.EventHandler(this.sAAOBBToolStripMenuItem_Click);
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.tabControlAccounting);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 34);
            this.tabPageAccounting.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageAccounting.Size = new System.Drawing.Size(1221, 622);
            this.tabPageAccounting.TabIndex = 1;
            this.tabPageAccounting.Text = "Accounting";
            this.tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // tabControlAccounting
            // 
            this.tabControlAccounting.Controls.Add(this.tabPageJournalEntryVoucher);
            this.tabControlAccounting.Controls.Add(this.tabPageJournals);
            this.tabControlAccounting.Controls.Add(this.tabPageLedgers);
            this.tabControlAccounting.Controls.Add(this.tabPageTrialBalance);
            this.tabControlAccounting.Controls.Add(this.tabPageFinancialStatements);
            this.tabControlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccounting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlAccounting.ItemSize = new System.Drawing.Size(150, 26);
            this.tabControlAccounting.Location = new System.Drawing.Point(0, 5);
            this.tabControlAccounting.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAccounting.Name = "tabControlAccounting";
            this.tabControlAccounting.SelectedIndex = 0;
            this.tabControlAccounting.Size = new System.Drawing.Size(1221, 617);
            this.tabControlAccounting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlAccounting.TabIndex = 0;
            // 
            // tabPageJournalEntryVoucher
            // 
            this.tabPageJournalEntryVoucher.Controls.Add(this.ucjevDashboard1);
            this.tabPageJournalEntryVoucher.Location = new System.Drawing.Point(4, 30);
            this.tabPageJournalEntryVoucher.Name = "tabPageJournalEntryVoucher";
            this.tabPageJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageJournalEntryVoucher.Size = new System.Drawing.Size(1213, 583);
            this.tabPageJournalEntryVoucher.TabIndex = 5;
            this.tabPageJournalEntryVoucher.Text = "Journal Entry Voucher";
            this.tabPageJournalEntryVoucher.UseVisualStyleBackColor = true;
            // 
            // ucjevDashboard1
            // 
            this.ucjevDashboard1.AutoSize = true;
            this.ucjevDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucjevDashboard1.Location = new System.Drawing.Point(0, 5);
            this.ucjevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucjevDashboard1.MinimumSize = new System.Drawing.Size(782, 160);
            this.ucjevDashboard1.Name = "ucjevDashboard1";
            this.ucjevDashboard1.Size = new System.Drawing.Size(1213, 578);
            this.ucjevDashboard1.TabIndex = 0;
            // 
            // tabPageJournals
            // 
            this.tabPageJournals.Controls.Add(this.ucJournalsDashboard1);
            this.tabPageJournals.Location = new System.Drawing.Point(4, 30);
            this.tabPageJournals.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageJournals.Name = "tabPageJournals";
            this.tabPageJournals.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageJournals.Size = new System.Drawing.Size(1213, 583);
            this.tabPageJournals.TabIndex = 1;
            this.tabPageJournals.Text = "Journals";
            this.tabPageJournals.UseVisualStyleBackColor = true;
            // 
            // ucJournalsDashboard1
            // 
            this.ucJournalsDashboard1.AutoSize = true;
            this.ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucJournalsDashboard1.Location = new System.Drawing.Point(0, 5);
            this.ucJournalsDashboard1.MinimumSize = new System.Drawing.Size(941, 160);
            this.ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            this.ucJournalsDashboard1.Size = new System.Drawing.Size(1213, 578);
            this.ucJournalsDashboard1.TabIndex = 0;
            // 
            // tabPageLedgers
            // 
            this.tabPageLedgers.Controls.Add(this.tabControlLedgers);
            this.tabPageLedgers.Location = new System.Drawing.Point(4, 30);
            this.tabPageLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageLedgers.Name = "tabPageLedgers";
            this.tabPageLedgers.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageLedgers.Size = new System.Drawing.Size(1213, 583);
            this.tabPageLedgers.TabIndex = 2;
            this.tabPageLedgers.Text = "Ledgers";
            this.tabPageLedgers.UseVisualStyleBackColor = true;
            // 
            // tabControlLedgers
            // 
            this.tabControlLedgers.Controls.Add(this.tabPageTransactionLog);
            this.tabControlLedgers.Controls.Add(this.tabPageSubsidiaryLedger);
            this.tabControlLedgers.Controls.Add(this.tabPageGeneralLedger);
            this.tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLedgers.ItemSize = new System.Drawing.Size(150, 20);
            this.tabControlLedgers.Location = new System.Drawing.Point(0, 5);
            this.tabControlLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlLedgers.Multiline = true;
            this.tabControlLedgers.Name = "tabControlLedgers";
            this.tabControlLedgers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlLedgers.RightToLeftLayout = true;
            this.tabControlLedgers.SelectedIndex = 0;
            this.tabControlLedgers.Size = new System.Drawing.Size(1213, 578);
            this.tabControlLedgers.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlLedgers.TabIndex = 0;
            // 
            // tabPageTransactionLog
            // 
            this.tabPageTransactionLog.Controls.Add(this.ucTransactionLog1);
            this.tabPageTransactionLog.Location = new System.Drawing.Point(4, 24);
            this.tabPageTransactionLog.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageTransactionLog.Name = "tabPageTransactionLog";
            this.tabPageTransactionLog.Size = new System.Drawing.Size(1205, 550);
            this.tabPageTransactionLog.TabIndex = 2;
            this.tabPageTransactionLog.Text = "Transaction Log";
            this.tabPageTransactionLog.UseVisualStyleBackColor = true;
            // 
            // ucTransactionLog1
            // 
            this.ucTransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTransactionLog1.Location = new System.Drawing.Point(0, 0);
            this.ucTransactionLog1.Name = "ucTransactionLog1";
            this.ucTransactionLog1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucTransactionLog1.Size = new System.Drawing.Size(1205, 550);
            this.ucTransactionLog1.TabIndex = 0;
            // 
            // tabPageSubsidiaryLedger
            // 
            this.tabPageSubsidiaryLedger.Controls.Add(this.ucSubsidiaryLedger1);
            this.tabPageSubsidiaryLedger.Location = new System.Drawing.Point(4, 24);
            this.tabPageSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSubsidiaryLedger.Name = "tabPageSubsidiaryLedger";
            this.tabPageSubsidiaryLedger.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageSubsidiaryLedger.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSubsidiaryLedger.TabIndex = 1;
            this.tabPageSubsidiaryLedger.Text = "Subsidiary Ledger";
            this.tabPageSubsidiaryLedger.UseVisualStyleBackColor = true;
            // 
            // ucSubsidiaryLedger1
            // 
            this.ucSubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubsidiaryLedger1.Location = new System.Drawing.Point(0, 5);
            this.ucSubsidiaryLedger1.Name = "ucSubsidiaryLedger1";
            this.ucSubsidiaryLedger1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucSubsidiaryLedger1.Size = new System.Drawing.Size(1205, 545);
            this.ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageGeneralLedger
            // 
            this.tabPageGeneralLedger.Controls.Add(this.ucGeneralLedger1);
            this.tabPageGeneralLedger.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneralLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            this.tabPageGeneralLedger.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageGeneralLedger.Size = new System.Drawing.Size(1205, 550);
            this.tabPageGeneralLedger.TabIndex = 0;
            this.tabPageGeneralLedger.Text = "General Ledger";
            this.tabPageGeneralLedger.UseVisualStyleBackColor = true;
            // 
            // ucGeneralLedger1
            // 
            this.ucGeneralLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGeneralLedger1.Location = new System.Drawing.Point(0, 5);
            this.ucGeneralLedger1.Name = "ucGeneralLedger1";
            this.ucGeneralLedger1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucGeneralLedger1.Size = new System.Drawing.Size(1205, 545);
            this.ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageTrialBalance
            // 
            this.tabPageTrialBalance.Controls.Add(this.tabControlTrialBalance);
            this.tabPageTrialBalance.Location = new System.Drawing.Point(4, 30);
            this.tabPageTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTrialBalance.Name = "tabPageTrialBalance";
            this.tabPageTrialBalance.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageTrialBalance.Size = new System.Drawing.Size(1213, 583);
            this.tabPageTrialBalance.TabIndex = 3;
            this.tabPageTrialBalance.Text = "Trial Balance";
            this.tabPageTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabControlTrialBalance
            // 
            this.tabControlTrialBalance.Controls.Add(this.tabPagePostTrial);
            this.tabControlTrialBalance.Controls.Add(this.tabPagePreTrial);
            this.tabControlTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTrialBalance.ItemSize = new System.Drawing.Size(180, 20);
            this.tabControlTrialBalance.Location = new System.Drawing.Point(0, 5);
            this.tabControlTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlTrialBalance.Name = "tabControlTrialBalance";
            this.tabControlTrialBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlTrialBalance.RightToLeftLayout = true;
            this.tabControlTrialBalance.SelectedIndex = 0;
            this.tabControlTrialBalance.Size = new System.Drawing.Size(1213, 578);
            this.tabControlTrialBalance.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlTrialBalance.TabIndex = 5;
            // 
            // tabPagePostTrial
            // 
            this.tabPagePostTrial.Controls.Add(this.ucPostClosingTrialBalance1);
            this.tabPagePostTrial.Location = new System.Drawing.Point(4, 24);
            this.tabPagePostTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePostTrial.Name = "tabPagePostTrial";
            this.tabPagePostTrial.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPagePostTrial.Size = new System.Drawing.Size(1205, 550);
            this.tabPagePostTrial.TabIndex = 1;
            this.tabPagePostTrial.Text = "Post-Closing Trial Balance";
            this.tabPagePostTrial.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            this.ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPostClosingTrialBalance1.Location = new System.Drawing.Point(0, 5);
            this.ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            this.ucPostClosingTrialBalance1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucPostClosingTrialBalance1.Size = new System.Drawing.Size(1205, 545);
            this.ucPostClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePreTrial
            // 
            this.tabPagePreTrial.Controls.Add(this.ucPreClosingTrialBalance1);
            this.tabPagePreTrial.Location = new System.Drawing.Point(4, 24);
            this.tabPagePreTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePreTrial.Name = "tabPagePreTrial";
            this.tabPagePreTrial.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPagePreTrial.Size = new System.Drawing.Size(1205, 550);
            this.tabPagePreTrial.TabIndex = 0;
            this.tabPagePreTrial.Text = "Pre-Closing Trial Balance";
            this.tabPagePreTrial.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            this.ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPreClosingTrialBalance1.Location = new System.Drawing.Point(0, 5);
            this.ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            this.ucPreClosingTrialBalance1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucPreClosingTrialBalance1.Size = new System.Drawing.Size(1205, 545);
            this.ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPageFinancialStatements
            // 
            this.tabPageFinancialStatements.Controls.Add(this.tabControlFinancialStatements);
            this.tabPageFinancialStatements.Location = new System.Drawing.Point(4, 30);
            this.tabPageFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageFinancialStatements.Name = "tabPageFinancialStatements";
            this.tabPageFinancialStatements.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageFinancialStatements.Size = new System.Drawing.Size(1213, 583);
            this.tabPageFinancialStatements.TabIndex = 4;
            this.tabPageFinancialStatements.Text = "Financial Statements";
            this.tabPageFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabControlFinancialStatements
            // 
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCBAA);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCF);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCNAE);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPerformance);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPosition);
            this.tabControlFinancialStatements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFinancialStatements.Location = new System.Drawing.Point(0, 5);
            this.tabControlFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlFinancialStatements.Name = "tabControlFinancialStatements";
            this.tabControlFinancialStatements.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlFinancialStatements.RightToLeftLayout = true;
            this.tabControlFinancialStatements.SelectedIndex = 0;
            this.tabControlFinancialStatements.Size = new System.Drawing.Size(1213, 578);
            this.tabControlFinancialStatements.TabIndex = 4;
            // 
            // tabPageSCBAA
            // 
            this.tabPageSCBAA.Location = new System.Drawing.Point(4, 24);
            this.tabPageSCBAA.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCBAA.Name = "tabPageSCBAA";
            this.tabPageSCBAA.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSCBAA.TabIndex = 4;
            this.tabPageSCBAA.Text = "Statement of Comparison of Budget and Actual Amounts";
            this.tabPageSCBAA.UseVisualStyleBackColor = true;
            // 
            // tabPageSCF
            // 
            this.tabPageSCF.Controls.Add(this.ucStatementOfCashFlows1);
            this.tabPageSCF.Location = new System.Drawing.Point(4, 24);
            this.tabPageSCF.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCF.Name = "tabPageSCF";
            this.tabPageSCF.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageSCF.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSCF.TabIndex = 3;
            this.tabPageSCF.Text = "Statement of Cash Flows";
            this.tabPageSCF.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfCashFlows1
            // 
            this.ucStatementOfCashFlows1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfCashFlows1.Location = new System.Drawing.Point(0, 5);
            this.ucStatementOfCashFlows1.Name = "ucStatementOfCashFlows1";
            this.ucStatementOfCashFlows1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucStatementOfCashFlows1.Size = new System.Drawing.Size(1205, 545);
            this.ucStatementOfCashFlows1.TabIndex = 0;
            // 
            // tabPageSCNAE
            // 
            this.tabPageSCNAE.Controls.Add(this.ucStatementOfChangesInNetAssetsEquity1);
            this.tabPageSCNAE.Location = new System.Drawing.Point(4, 24);
            this.tabPageSCNAE.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCNAE.Name = "tabPageSCNAE";
            this.tabPageSCNAE.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageSCNAE.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSCNAE.TabIndex = 2;
            this.tabPageSCNAE.Text = "Statement of Changes in Net Assets/Equity";
            this.tabPageSCNAE.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfChangesInNetAssetsEquity1
            // 
            this.ucStatementOfChangesInNetAssetsEquity1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfChangesInNetAssetsEquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfChangesInNetAssetsEquity1.Location = new System.Drawing.Point(0, 5);
            this.ucStatementOfChangesInNetAssetsEquity1.Name = "ucStatementOfChangesInNetAssetsEquity1";
            this.ucStatementOfChangesInNetAssetsEquity1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucStatementOfChangesInNetAssetsEquity1.Size = new System.Drawing.Size(1205, 545);
            this.ucStatementOfChangesInNetAssetsEquity1.TabIndex = 0;
            // 
            // tabPageSFPerformance
            // 
            this.tabPageSFPerformance.Controls.Add(this.ucStatementOfFinancialPerformance1);
            this.tabPageSFPerformance.Location = new System.Drawing.Point(4, 24);
            this.tabPageSFPerformance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPerformance.Name = "tabPageSFPerformance";
            this.tabPageSFPerformance.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageSFPerformance.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSFPerformance.TabIndex = 1;
            this.tabPageSFPerformance.Text = "Statement of Financial Performance";
            this.tabPageSFPerformance.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            this.ucStatementOfFinancialPerformance1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 5);
            this.ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            this.ucStatementOfFinancialPerformance1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(1205, 545);
            this.ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // tabPageSFPosition
            // 
            this.tabPageSFPosition.Controls.Add(this.ucStatementOfFinancialPosition1);
            this.tabPageSFPosition.Location = new System.Drawing.Point(4, 24);
            this.tabPageSFPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPosition.Name = "tabPageSFPosition";
            this.tabPageSFPosition.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageSFPosition.Size = new System.Drawing.Size(1205, 550);
            this.tabPageSFPosition.TabIndex = 0;
            this.tabPageSFPosition.Text = "Statement of Financial Position";
            this.tabPageSFPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            this.ucStatementOfFinancialPosition1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 5);
            this.ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            this.ucStatementOfFinancialPosition1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(1205, 545);
            this.ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabPageTreasury
            // 
            this.tabPageTreasury.Controls.Add(this.panel1);
            this.tabPageTreasury.Location = new System.Drawing.Point(4, 34);
            this.tabPageTreasury.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTreasury.Name = "tabPageTreasury";
            this.tabPageTreasury.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tabPageTreasury.Size = new System.Drawing.Size(1221, 622);
            this.tabPageTreasury.TabIndex = 2;
            this.tabPageTreasury.Text = "Treasury";
            this.tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucrcdSummary1);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 617);
            this.panel1.TabIndex = 0;
            // 
            // ucrcdSummary1
            // 
            this.ucrcdSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucrcdSummary1.Location = new System.Drawing.Point(0, 31);
            this.ucrcdSummary1.Name = "ucrcdSummary1";
            this.ucrcdSummary1.Size = new System.Drawing.Size(1221, 586);
            this.ucrcdSummary1.TabIndex = 10;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton2,
            this.toolStripButtonRpt,
            this.toolStripButtonBpl,
            this.toolStripSplitButton3,
            this.toolStripSplitButton4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1221, 31);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueRecieptsToolStripMenuItem,
            this.returnedReceiptsToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::AccountingSystem.Properties.Resources.document_delivery_receipt_signed_24px;
            this.toolStripSplitButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(91, 28);
            this.toolStripSplitButton2.Text = "Reciepts";
            // 
            // issueRecieptsToolStripMenuItem
            // 
            this.issueRecieptsToolStripMenuItem.Name = "issueRecieptsToolStripMenuItem";
            this.issueRecieptsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.issueRecieptsToolStripMenuItem.Text = "Issue Reciepts";
            this.issueRecieptsToolStripMenuItem.Click += new System.EventHandler(this.issueRecieptsToolStripMenuItem_Click);
            // 
            // returnedReceiptsToolStripMenuItem
            // 
            this.returnedReceiptsToolStripMenuItem.Name = "returnedReceiptsToolStripMenuItem";
            this.returnedReceiptsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.returnedReceiptsToolStripMenuItem.Text = "Returned Receipts";
            this.returnedReceiptsToolStripMenuItem.Click += new System.EventHandler(this.returnedReceiptsToolStripMenuItem_Click);
            // 
            // toolStripButtonRpt
            // 
            this.toolStripButtonRpt.Image = global::AccountingSystem.Properties.Resources.building_9_archive_24px;
            this.toolStripButtonRpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRpt.Name = "toolStripButtonRpt";
            this.toolStripButtonRpt.Size = new System.Drawing.Size(55, 28);
            this.toolStripButtonRpt.Text = "RPT";
            this.toolStripButtonRpt.Click += new System.EventHandler(this.toolStripButtonRpt_Click);
            // 
            // toolStripButtonBpl
            // 
            this.toolStripButtonBpl.Enabled = false;
            this.toolStripButtonBpl.Image = global::AccountingSystem.Properties.Resources.briefcase_business_20px;
            this.toolStripButtonBpl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButtonBpl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonBpl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBpl.Name = "toolStripButtonBpl";
            this.toolStripButtonBpl.Size = new System.Drawing.Size(51, 28);
            this.toolStripButtonBpl.Text = "BPL";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paymentsToolStripMenuItem,
            this.toolStripSeparator10,
            this.assessmentPostingToolStripMenuItem,
            this.toolStripSeparator11,
            this.checkIssuanceToolStripMenuItem,
            this.releasedAndUnreleaseChecksToolStripMenu,
            this.bankDepositToolStripMenuItem});
            this.toolStripSplitButton3.Image = global::AccountingSystem.Properties.Resources.money_2_24px;
            this.toolStripSplitButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(112, 28);
            this.toolStripSplitButton3.Text = "Transactions";
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.paymentsToolStripMenuItem.Text = "Payments";
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(214, 6);
            // 
            // assessmentPostingToolStripMenuItem
            // 
            this.assessmentPostingToolStripMenuItem.Name = "assessmentPostingToolStripMenuItem";
            this.assessmentPostingToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.assessmentPostingToolStripMenuItem.Text = "Assessment Posting";
            this.assessmentPostingToolStripMenuItem.Click += new System.EventHandler(this.assessmentPostingToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(214, 6);
            // 
            // checkIssuanceToolStripMenuItem
            // 
            this.checkIssuanceToolStripMenuItem.Name = "checkIssuanceToolStripMenuItem";
            this.checkIssuanceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.checkIssuanceToolStripMenuItem.Text = "Check Issuance";
            this.checkIssuanceToolStripMenuItem.Click += new System.EventHandler(this.CheckIssuanceToolStripMenuItem_Click);
            // 
            // releasedAndUnreleaseChecksToolStripMenu
            // 
            this.releasedAndUnreleaseChecksToolStripMenu.Name = "releasedAndUnreleaseChecksToolStripMenu";
            this.releasedAndUnreleaseChecksToolStripMenu.Size = new System.Drawing.Size(217, 22);
            this.releasedAndUnreleaseChecksToolStripMenu.Text = "Release/Unreleased Checks";
            this.releasedAndUnreleaseChecksToolStripMenu.Click += new System.EventHandler(this.releasedAndUnreleaseChecksToolStripMenu_Click);
            // 
            // bankDepositToolStripMenuItem
            // 
            this.bankDepositToolStripMenuItem.Name = "bankDepositToolStripMenuItem";
            this.bankDepositToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.bankDepositToolStripMenuItem.Text = "Bank Deposit";
            this.bankDepositToolStripMenuItem.Click += new System.EventHandler(this.bankDepositToolStripMenuItem_Click);
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorsRCDToolStripMenuItem,
            this.liquidatorsRCDToolStripMenuItem,
            this.toolStripSeparator12,
            this.collectionPaymentToolStripMenuItem1,
            this.toolStripSeparator13,
            this.reportOfCheckIssuedRCIToolStripMenuItem,
            this.releasedChequesToolStripMenuItem,
            this.unreleasedChequesToolStripMenuItem,
            this.bankCashbookToolStripMenuItem,
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem,
            this.dailyCashPositionsToolStripMenuItem});
            this.toolStripSplitButton4.Image = global::AccountingSystem.Properties.Resources.documents_3_20px;
            this.toolStripSplitButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(83, 28);
            this.toolStripSplitButton4.Text = "Reports";
            // 
            // collectorsRCDToolStripMenuItem
            // 
            this.collectorsRCDToolStripMenuItem.Name = "collectorsRCDToolStripMenuItem";
            this.collectorsRCDToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.collectorsRCDToolStripMenuItem.Text = "Collector\'s RCD";
            this.collectorsRCDToolStripMenuItem.Click += new System.EventHandler(this.collectorsRCDToolStripMenuItem_Click);
            // 
            // liquidatorsRCDToolStripMenuItem
            // 
            this.liquidatorsRCDToolStripMenuItem.Name = "liquidatorsRCDToolStripMenuItem";
            this.liquidatorsRCDToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.liquidatorsRCDToolStripMenuItem.Text = "Liquidator\'s RCD";
            this.liquidatorsRCDToolStripMenuItem.Click += new System.EventHandler(this.liquidatorsRCDToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(397, 6);
            // 
            // collectionPaymentToolStripMenuItem1
            // 
            this.collectionPaymentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportOfCollectionsDepositsRCDToolStripMenuItem,
            this.abstractOfGeneralCollectionsToolStripMenuItem,
            this.toolStripSeparator14,
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem,
            this.realPropertyTaxStatementOfAccountToolStripMenuItem,
            this.toolStripSeparator15,
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem,
            this.listOfDelinquentAccountsToolStripMenuItem});
            this.collectionPaymentToolStripMenuItem1.Name = "collectionPaymentToolStripMenuItem1";
            this.collectionPaymentToolStripMenuItem1.Size = new System.Drawing.Size(400, 22);
            this.collectionPaymentToolStripMenuItem1.Text = "Collection/Payment";
            // 
            // reportOfCollectionsDepositsRCDToolStripMenuItem
            // 
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Enabled = false;
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Name = "reportOfCollectionsDepositsRCDToolStripMenuItem";
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Text = "Report of Collections Deposits (RCD)";
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Click += new System.EventHandler(this.reportOfCollectionsDepositsRCDToolStripMenuItem_Click);
            // 
            // abstractOfGeneralCollectionsToolStripMenuItem
            // 
            this.abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;
            this.abstractOfGeneralCollectionsToolStripMenuItem.Name = "abstractOfGeneralCollectionsToolStripMenuItem";
            this.abstractOfGeneralCollectionsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.abstractOfGeneralCollectionsToolStripMenuItem.Text = "Abstract of General Collections";
            this.abstractOfGeneralCollectionsToolStripMenuItem.Click += new System.EventHandler(this.abstractOfGeneralCollectionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(301, 6);
            // 
            // realPropertyTaxAccountRegisterRPTARToolStripMenuItem
            // 
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Enabled = false;
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Name = "realPropertyTaxAccountRegisterRPTARToolStripMenuItem";
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Text = "Real Property Tax Account Register (RPTAR)";
            this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Click += new System.EventHandler(this.realPropertyTaxAccountRegisterRPTARToolStripMenuItem_Click);
            // 
            // realPropertyTaxStatementOfAccountToolStripMenuItem
            // 
            this.realPropertyTaxStatementOfAccountToolStripMenuItem.Enabled = false;
            this.realPropertyTaxStatementOfAccountToolStripMenuItem.Name = "realPropertyTaxStatementOfAccountToolStripMenuItem";
            this.realPropertyTaxStatementOfAccountToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.realPropertyTaxStatementOfAccountToolStripMenuItem.Text = "Real Property Tax Statement of Account";
            this.realPropertyTaxStatementOfAccountToolStripMenuItem.Click += new System.EventHandler(this.realPropertyTaxStatementOfAccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(301, 6);
            // 
            // consolidatedRealPropertyTaxDeliquencesToolStripMenuItem
            // 
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Enabled = false;
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Name = "consolidatedRealPropertyTaxDeliquencesToolStripMenuItem";
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Text = "Consolidated Real Property Tax Deliquences";
            this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Click += new System.EventHandler(this.consolidatedRealPropertyTaxDeliquencesToolStripMenuItem_Click);
            // 
            // listOfDelinquentAccountsToolStripMenuItem
            // 
            this.listOfDelinquentAccountsToolStripMenuItem.Enabled = false;
            this.listOfDelinquentAccountsToolStripMenuItem.Name = "listOfDelinquentAccountsToolStripMenuItem";
            this.listOfDelinquentAccountsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.listOfDelinquentAccountsToolStripMenuItem.Text = "List of Delinquent Accounts";
            this.listOfDelinquentAccountsToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemListOfDelinquentAccounts_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(397, 6);
            // 
            // reportOfCheckIssuedRCIToolStripMenuItem
            // 
            this.reportOfCheckIssuedRCIToolStripMenuItem.Name = "reportOfCheckIssuedRCIToolStripMenuItem";
            this.reportOfCheckIssuedRCIToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.reportOfCheckIssuedRCIToolStripMenuItem.Text = "Report of Check Issued (RCI)";
            this.reportOfCheckIssuedRCIToolStripMenuItem.Click += new System.EventHandler(this.reportOfCheckIssuedRCIToolStripMenuItem_Click);
            // 
            // releasedChequesToolStripMenuItem
            // 
            this.releasedChequesToolStripMenuItem.Name = "releasedChequesToolStripMenuItem";
            this.releasedChequesToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.releasedChequesToolStripMenuItem.Text = "Schedule of Released Cheques";
            this.releasedChequesToolStripMenuItem.Click += new System.EventHandler(this.releasedChequesToolStripMenuItem_Click);
            // 
            // unreleasedChequesToolStripMenuItem
            // 
            this.unreleasedChequesToolStripMenuItem.Name = "unreleasedChequesToolStripMenuItem";
            this.unreleasedChequesToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.unreleasedChequesToolStripMenuItem.Text = "Schedule of Unreleased Cheques";
            this.unreleasedChequesToolStripMenuItem.Click += new System.EventHandler(this.unreleasedChequesToolStripMenuItem_Click);
            // 
            // bankCashbookToolStripMenuItem
            // 
            this.bankCashbookToolStripMenuItem.Name = "bankCashbookToolStripMenuItem";
            this.bankCashbookToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.bankCashbookToolStripMenuItem.Text = "Bank Cashbook";
            this.bankCashbookToolStripMenuItem.Click += new System.EventHandler(this.bankCashbookToolStripMenuItem_Click);
            // 
            // consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem
            // 
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Name = "consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem";
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Text = "Consolidated Report of Accountability for Accountable Forms";
            this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Click += new System.EventHandler(this.consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem_Click);
            // 
            // dailyCashPositionsToolStripMenuItem
            // 
            this.dailyCashPositionsToolStripMenuItem.Name = "dailyCashPositionsToolStripMenuItem";
            this.dailyCashPositionsToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.dailyCashPositionsToolStripMenuItem.Text = "Daily Cash Positions";
            this.dailyCashPositionsToolStripMenuItem.Click += new System.EventHandler(this.dailyCashPositionsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1229, 708);
            this.Controls.Add(this.tabControlDashboard);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1244, 718);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Finance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlDashboard.ResumeLayout(false);
            this.tabPageBudget.ResumeLayout(false);
            this.tabPageBudget.PerformLayout();
            this.tabControlBudget.ResumeLayout(false);
            this.tabPageBudgetDetailed.ResumeLayout(false);
            this.tabPageBudgetSummary.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageAccounting.ResumeLayout(false);
            this.tabControlAccounting.ResumeLayout(false);
            this.tabPageJournalEntryVoucher.ResumeLayout(false);
            this.tabPageJournalEntryVoucher.PerformLayout();
            this.tabPageJournals.ResumeLayout(false);
            this.tabPageJournals.PerformLayout();
            this.tabPageLedgers.ResumeLayout(false);
            this.tabControlLedgers.ResumeLayout(false);
            this.tabPageTransactionLog.ResumeLayout(false);
            this.tabPageSubsidiaryLedger.ResumeLayout(false);
            this.tabPageGeneralLedger.ResumeLayout(false);
            this.tabPageTrialBalance.ResumeLayout(false);
            this.tabControlTrialBalance.ResumeLayout(false);
            this.tabPagePostTrial.ResumeLayout(false);
            this.tabPagePreTrial.ResumeLayout(false);
            this.tabPageFinancialStatements.ResumeLayout(false);
            this.tabControlFinancialStatements.ResumeLayout(false);
            this.tabPageSCF.ResumeLayout(false);
            this.tabPageSCNAE.ResumeLayout(false);
            this.tabPageSFPerformance.ResumeLayout(false);
            this.tabPageSFPosition.ResumeLayout(false);
            this.tabPageTreasury.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuManage;
        private System.Windows.Forms.ToolStripMenuItem menuJournals;
        private System.Windows.Forms.ToolStripMenuItem menuAllotmentClasses;
        private System.Windows.Forms.ToolStripMenuItem menuFunds;
        private System.Windows.Forms.ToolStripMenuItem menuChartOfAccounts;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionProgramProject;
        private System.Windows.Forms.ToolStripMenuItem menuCollectingOfficer;
        private System.Windows.Forms.ToolStripMenuItem menuDisbursingOfficer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserFullName;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripMenuItem menuBanks;
        private System.Windows.Forms.ToolStripMenuItem menuAccForm;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripMenuItem menuReceipts;
        private System.Windows.Forms.TabControl tabControlDashboard;
        internal System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.TabControl tabControlAccounting;
        private System.Windows.Forms.TabPage tabPageJournals;
        private System.Windows.Forms.TabPage tabPageLedgers;
        private System.Windows.Forms.TabPage tabPageTrialBalance;
        private System.Windows.Forms.TabPage tabPageFinancialStatements;
        private Views.Dashboard.ucJEVDashboard ucjevDashboard1;
        private Views.Dashboard.AccountingDashboard.ucJournalsDashboard ucJournalsDashboard1;
        private System.Windows.Forms.TabControl tabControlLedgers;
        private System.Windows.Forms.TabPage tabPageGeneralLedger;
        private System.Windows.Forms.TabPage tabPageSubsidiaryLedger;
        private Views.Reports.Ledgers.ucGeneralLedger ucGeneralLedger1;
        private Views.Reports.Ledgers.ucSubsidiaryLedger ucSubsidiaryLedger1;
        private System.Windows.Forms.TabControl tabControlTrialBalance;
        private System.Windows.Forms.TabPage tabPagePreTrial;
        private Views.Reports.TrialBalance.ucPreClosingTrialBalance ucPreClosingTrialBalance1;
        private System.Windows.Forms.TabPage tabPagePostTrial;
        private Views.Reports.TrialBalance.ucPostClosingTrialBalance ucPostClosingTrialBalance1;
        private System.Windows.Forms.TabControl tabControlFinancialStatements;
        private System.Windows.Forms.TabPage tabPageSFPosition;
        private System.Windows.Forms.TabPage tabPageSFPerformance;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
        private System.Windows.Forms.TabPage tabPageSCNAE;
        private System.Windows.Forms.TabPage tabPageSCF;
        private System.Windows.Forms.TabPage tabPageSCBAA;
        private System.Windows.Forms.ToolStripMenuItem amortiaztionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signatoriesToolStripMenuItem;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private Views.Dashboard.TreasuryDashboard.ucRCDSummary ucrcdSummary1;
        private Views.Reports.Financial_Statements.ucStatementOfCashFlows ucStatementOfCashFlows1;
        internal System.Windows.Forms.TabPage tabPageTransactionLog;
        private Views.Reports.Ledgers.ucTransactionLog ucTransactionLog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem discountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penaltyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem taxRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTaxPayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseSynchronization;
        private System.Windows.Forms.TabPage tabPageBudget;
        private System.Windows.Forms.TabControl tabControlBudget;
        private System.Windows.Forms.TabPage tabPageBudgetSummary;
        private System.Windows.Forms.TabPage tabPageBudgetDetailed;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonBudgetAppropriations;
        private System.Windows.Forms.ToolStripButton toolStripButtonAllotmentRelease;
        private System.Windows.Forms.ToolStripButton toolStripButtonObligation;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem sAAOBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAAOBBToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageJournalEntryVoucher;
        private System.Windows.Forms.ImageList imageList1;
        private Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity ucStatementOfChangesInNetAssetsEquity1;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem assessmentPostingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem checkIssuanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankDepositToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem collectorsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidatorsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem collectionPaymentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportOfCollectionsDepositsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem reportOfCheckIssuedRCIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankCashbookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCashPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abstractOfGeneralCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem realPropertyTaxAccountRegisterRPTARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realPropertyTaxStatementOfAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem consolidatedRealPropertyTaxDeliquencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfDelinquentAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueRecieptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnedReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessToolStripMenuItem; 
        private System.Windows.Forms.ToolStripMenuItem businessCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barangaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonBpl;
        private System.Windows.Forms.ToolStripButton toolStripButtonRpt;
        private System.Windows.Forms.ToolStripMenuItem businessAddOnToolStripMenuItem;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed ucBudgetDetailed1;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary ucBudgetSummary1;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasedAndUnreleaseChecksToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem releasedChequesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unreleasedChequesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankAccountsToolStripMenuItem;
    }
}