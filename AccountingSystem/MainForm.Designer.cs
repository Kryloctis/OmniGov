
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFunds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJournals = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunctionProgramProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChartOfAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAllotmentClasses = new System.Windows.Forms.ToolStripMenuItem();
            this.amortiaztionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signatoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCollectingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisbursingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTaxPayers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.discountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penaltyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDatabaseSynchronization = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radBtnBudget = new System.Windows.Forms.RadioButton();
            this.radBtnAccounting = new System.Windows.Forms.RadioButton();
            this.radBtnTreasury = new System.Windows.Forms.RadioButton();
            this.tabControlDashboard = new System.Windows.Forms.TabControl();
            this.tabPageBudget = new System.Windows.Forms.TabPage();
            this.tabControlBudget = new System.Windows.Forms.TabControl();
            this.tabPageBudgetSummary = new System.Windows.Forms.TabPage();
            this.ucBudgetSummary1 = new AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary();
            this.tabPageBudgetDetailed = new System.Windows.Forms.TabPage();
            this.ucBudgetDetailed1 = new AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed();
            this.chkbxDetailed = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBudgetAppropriations = new System.Windows.Forms.Button();
            this.btnAllotmentRelease = new System.Windows.Forms.Button();
            this.btnObligationRequest = new System.Windows.Forms.Button();
            this.btnSAAOB = new System.Windows.Forms.Button();
            this.btnSAAOBB = new System.Windows.Forms.Button();
            this.tabPageAccounting = new System.Windows.Forms.TabPage();
            this.tabControlAccounting = new System.Windows.Forms.TabControl();
            this.tabPageJournalEntryVoucher = new System.Windows.Forms.TabPage();
            this.ucjevDashboard1 = new AccountingSystem.Views.Dashboard.ucJEVDashboard();
            this.tabPageJournals = new System.Windows.Forms.TabPage();
            this.ucJournalsDashboard1 = new AccountingSystem.Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            this.tabPageLedgers = new System.Windows.Forms.TabPage();
            this.tabControlLedgers = new System.Windows.Forms.TabControl();
            this.tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            this.ucGeneralLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucGeneralLedger();
            this.tabPageSubsidiaryLedger = new System.Windows.Forms.TabPage();
            this.ucSubsidiaryLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucSubsidiaryLedger();
            this.tabPageTransactionLog = new System.Windows.Forms.TabPage();
            this.ucTransactionLog1 = new AccountingSystem.Views.Reports.Ledgers.ucTransactionLog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioGeneralLedger = new System.Windows.Forms.RadioButton();
            this.radioSubsidiaryLedger = new System.Windows.Forms.RadioButton();
            this.radioTransactionLog = new System.Windows.Forms.RadioButton();
            this.tabPageTrialBalance = new System.Windows.Forms.TabPage();
            this.tabControlTrialBalance = new System.Windows.Forms.TabControl();
            this.tabPagePreTrial = new System.Windows.Forms.TabPage();
            this.ucPreClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPreClosingTrialBalance();
            this.tabPagePostTrial = new System.Windows.Forms.TabPage();
            this.ucPostClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPostClosingTrialBalance();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioPreTB = new System.Windows.Forms.RadioButton();
            this.radioPostTB = new System.Windows.Forms.RadioButton();
            this.tabPageFinancialStatements = new System.Windows.Forms.TabPage();
            this.tabControlFinancialStatements = new System.Windows.Forms.TabControl();
            this.tabPageSFPosition = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPosition1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPosition();
            this.tabPageSFPerformance = new System.Windows.Forms.TabPage();
            this.ucStatementOfFinancialPerformance1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance();
            this.tabPageSCNAE = new System.Windows.Forms.TabPage();
            this.ucStatementOfChangesInNetAssetsquity1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity();
            this.tabPageSCF = new System.Windows.Forms.TabPage();
            this.ucStatementOfCashFlows1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfCashFlows();
            this.tabPageSCBAA = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radSFPosition = new System.Windows.Forms.RadioButton();
            this.radSFPerformance = new System.Windows.Forms.RadioButton();
            this.radSCNAE = new System.Windows.Forms.RadioButton();
            this.radSCF = new System.Windows.Forms.RadioButton();
            this.radSCBAA = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.radJournalEntryVoucher = new System.Windows.Forms.RadioButton();
            this.radJournals = new System.Windows.Forms.RadioButton();
            this.radLedgers = new System.Windows.Forms.RadioButton();
            this.radTrialBalance = new System.Windows.Forms.RadioButton();
            this.radFinancialStatements = new System.Windows.Forms.RadioButton();
            this.tabPageTreasury = new System.Windows.Forms.TabPage();
            this.ucrcdSummary1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucRCDSummary();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.issueReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnedReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkIssuanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPaymentPortal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuAssessmentPosting = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidatorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.collectionPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportOfCollectionsDepositsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abstractOfGeneralCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemrealPropertyTaxAccountRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemListOfDelinquentAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.rCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankCashbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolidatedReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCashPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabPageBudget.SuspendLayout();
            this.tabControlBudget.SuspendLayout();
            this.tabPageBudgetSummary.SuspendLayout();
            this.tabPageBudgetDetailed.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.tabPageAccounting.SuspendLayout();
            this.tabControlAccounting.SuspendLayout();
            this.tabPageJournalEntryVoucher.SuspendLayout();
            this.tabPageJournals.SuspendLayout();
            this.tabPageLedgers.SuspendLayout();
            this.tabControlLedgers.SuspendLayout();
            this.tabPageGeneralLedger.SuspendLayout();
            this.tabPageSubsidiaryLedger.SuspendLayout();
            this.tabPageTransactionLog.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPageTrialBalance.SuspendLayout();
            this.tabControlTrialBalance.SuspendLayout();
            this.tabPagePreTrial.SuspendLayout();
            this.tabPagePostTrial.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabPageFinancialStatements.SuspendLayout();
            this.tabControlFinancialStatements.SuspendLayout();
            this.tabPageSFPosition.SuspendLayout();
            this.tabPageSFPerformance.SuspendLayout();
            this.tabPageSCNAE.SuspendLayout();
            this.tabPageSCF.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.tabPageTreasury.SuspendLayout();
            this.menuStrip2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1405, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 24);
            this.menuFile.Text = "&File";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(197, 26);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(197, 26);
            this.menuExitApp.Text = "Exit Application";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // menuManage
            // 
            this.menuManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsers,
            this.toolStripSeparator2,
            this.menuFunds,
            this.menuJournals,
            this.menuFunctionProgramProject,
            this.menuChartOfAccounts,
            this.menuAllotmentClasses,
            this.amortiaztionToolStripMenuItem,
            this.signatoriesToolStripMenuItem,
            this.toolStripSeparator3,
            this.menuCollectingOfficer,
            this.menuDisbursingOfficer,
            this.menuBanks,
            this.menuAccForm,
            this.menuReceipts,
            this.menuTaxPayers,
            this.toolStripSeparator1,
            this.discountToolStripMenuItem,
            this.penaltyToolStripMenuItem,
            this.taxRateToolStripMenuItem,
            this.toolStripSeparator9,
            this.menuDatabaseSynchronization});
            this.menuManage.Name = "menuManage";
            this.menuManage.Size = new System.Drawing.Size(77, 24);
            this.menuManage.Text = "Manage";
            // 
            // menuUsers
            // 
            this.menuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserList,
            this.menuRoles});
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(264, 26);
            this.menuUsers.Text = "Users";
            // 
            // menuUserList
            // 
            this.menuUserList.Name = "menuUserList";
            this.menuUserList.Size = new System.Drawing.Size(137, 26);
            this.menuUserList.Text = "List...";
            this.menuUserList.Click += new System.EventHandler(this.menuUserList_Click);
            // 
            // menuRoles
            // 
            this.menuRoles.Name = "menuRoles";
            this.menuRoles.Size = new System.Drawing.Size(137, 26);
            this.menuRoles.Text = "Roles...";
            this.menuRoles.Click += new System.EventHandler(this.menuRoles_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(264, 26);
            this.menuFunds.Text = "Funds";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // menuJournals
            // 
            this.menuJournals.Name = "menuJournals";
            this.menuJournals.Size = new System.Drawing.Size(264, 26);
            this.menuJournals.Text = "Journals";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(264, 26);
            this.menuFunctionProgramProject.Text = "Function/Program/Project";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuChartOfAccounts
            // 
            this.menuChartOfAccounts.Name = "menuChartOfAccounts";
            this.menuChartOfAccounts.Size = new System.Drawing.Size(264, 26);
            this.menuChartOfAccounts.Text = "Chart of Accounts";
            this.menuChartOfAccounts.Click += new System.EventHandler(this.menuChartOfAccounts_Click);
            // 
            // menuAllotmentClasses
            // 
            this.menuAllotmentClasses.Name = "menuAllotmentClasses";
            this.menuAllotmentClasses.Size = new System.Drawing.Size(264, 26);
            this.menuAllotmentClasses.Text = "Allotment Classes";
            this.menuAllotmentClasses.Click += new System.EventHandler(this.menuAllotmentClasses_Click);
            // 
            // amortiaztionToolStripMenuItem
            // 
            this.amortiaztionToolStripMenuItem.Name = "amortiaztionToolStripMenuItem";
            this.amortiaztionToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.amortiaztionToolStripMenuItem.Text = "Amortization";
            this.amortiaztionToolStripMenuItem.Click += new System.EventHandler(this.amortiaztionToolStripMenuItem_Click);
            // 
            // signatoriesToolStripMenuItem
            // 
            this.signatoriesToolStripMenuItem.Name = "signatoriesToolStripMenuItem";
            this.signatoriesToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.signatoriesToolStripMenuItem.Text = "Signatories";
            this.signatoriesToolStripMenuItem.Click += new System.EventHandler(this.signatoriesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(261, 6);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(264, 26);
            this.menuCollectingOfficer.Text = "Collecting Officers";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuDisbursingOfficer
            // 
            this.menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            this.menuDisbursingOfficer.Size = new System.Drawing.Size(264, 26);
            this.menuDisbursingOfficer.Text = "Disbursing Officers";
            this.menuDisbursingOfficer.Click += new System.EventHandler(this.MenuDisbursingOffice_Click);
            // 
            // menuBanks
            // 
            this.menuBanks.Name = "menuBanks";
            this.menuBanks.Size = new System.Drawing.Size(264, 26);
            this.menuBanks.Text = "Banks";
            this.menuBanks.Click += new System.EventHandler(this.menuBanks_Click);
            // 
            // menuAccForm
            // 
            this.menuAccForm.Name = "menuAccForm";
            this.menuAccForm.Size = new System.Drawing.Size(264, 26);
            this.menuAccForm.Text = "Accountable Form";
            this.menuAccForm.Click += new System.EventHandler(this.menuAccForm_Click);
            // 
            // menuReceipts
            // 
            this.menuReceipts.Name = "menuReceipts";
            this.menuReceipts.Size = new System.Drawing.Size(264, 26);
            this.menuReceipts.Text = "Receipts";
            this.menuReceipts.Click += new System.EventHandler(this.menureceipts_Click);
            // 
            // menuTaxPayers
            // 
            this.menuTaxPayers.Name = "menuTaxPayers";
            this.menuTaxPayers.Size = new System.Drawing.Size(264, 26);
            this.menuTaxPayers.Text = "Taxpayers";
            this.menuTaxPayers.Click += new System.EventHandler(this.menuTaxPayers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // discountToolStripMenuItem
            // 
            this.discountToolStripMenuItem.Name = "discountToolStripMenuItem";
            this.discountToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.discountToolStripMenuItem.Text = "Discounts";
            this.discountToolStripMenuItem.Click += new System.EventHandler(this.discountToolStripMenuItem_Click);
            // 
            // penaltyToolStripMenuItem
            // 
            this.penaltyToolStripMenuItem.Name = "penaltyToolStripMenuItem";
            this.penaltyToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.penaltyToolStripMenuItem.Text = "Penalties";
            this.penaltyToolStripMenuItem.Click += new System.EventHandler(this.penaltyToolStripMenuItem_Click);
            // 
            // taxRateToolStripMenuItem
            // 
            this.taxRateToolStripMenuItem.Name = "taxRateToolStripMenuItem";
            this.taxRateToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.taxRateToolStripMenuItem.Text = "Tax Rates";
            this.taxRateToolStripMenuItem.Click += new System.EventHandler(this.taxRateToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(261, 6);
            // 
            // menuDatabaseSynchronization
            // 
            this.menuDatabaseSynchronization.Enabled = false;
            this.menuDatabaseSynchronization.Name = "menuDatabaseSynchronization";
            this.menuDatabaseSynchronization.Size = new System.Drawing.Size(264, 26);
            this.menuDatabaseSynchronization.Text = "Database Synchronization";
            this.menuDatabaseSynchronization.Click += new System.EventHandler(this.menuDatabaseSynchronization_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserFullName,
            this.lblUserRole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 909);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1405, 30);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUserFullName
            // 
            this.lblUserFullName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblUserFullName.Name = "lblUserFullName";
            this.lblUserFullName.Size = new System.Drawing.Size(105, 24);
            this.lblUserFullName.Text = "lblUserDetails";
            // 
            // lblUserRole
            // 
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(151, 24);
            this.lblUserRole.Text = "toolStripStatusLabel2";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.radBtnBudget);
            this.flowLayoutPanel1.Controls.Add(this.radBtnAccounting);
            this.flowLayoutPanel1.Controls.Add(this.radBtnTreasury);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1405, 49);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radBtnBudget
            // 
            this.radBtnBudget.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radBtnBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnBudget.Location = new System.Drawing.Point(2, 12);
            this.radBtnBudget.Margin = new System.Windows.Forms.Padding(2, 4, 1, 4);
            this.radBtnBudget.Name = "radBtnBudget";
            this.radBtnBudget.Size = new System.Drawing.Size(107, 33);
            this.radBtnBudget.TabIndex = 0;
            this.radBtnBudget.Text = "BUDGET";
            this.radBtnBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnBudget.UseVisualStyleBackColor = true;
            this.radBtnBudget.Visible = false;
            this.radBtnBudget.CheckedChanged += new System.EventHandler(this.radBtnBudget_CheckedChanged);
            // 
            // radBtnAccounting
            // 
            this.radBtnAccounting.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnAccounting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radBtnAccounting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnAccounting.Location = new System.Drawing.Point(111, 12);
            this.radBtnAccounting.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.radBtnAccounting.Name = "radBtnAccounting";
            this.radBtnAccounting.Size = new System.Drawing.Size(117, 33);
            this.radBtnAccounting.TabIndex = 1;
            this.radBtnAccounting.Text = "ACCOUNTING";
            this.radBtnAccounting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnAccounting.UseVisualStyleBackColor = true;
            this.radBtnAccounting.Visible = false;
            this.radBtnAccounting.CheckedChanged += new System.EventHandler(this.radBtnAccounting_CheckedChanged);
            // 
            // radBtnTreasury
            // 
            this.radBtnTreasury.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnTreasury.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radBtnTreasury.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnTreasury.Location = new System.Drawing.Point(230, 12);
            this.radBtnTreasury.Margin = new System.Windows.Forms.Padding(1, 4, 2, 4);
            this.radBtnTreasury.Name = "radBtnTreasury";
            this.radBtnTreasury.Size = new System.Drawing.Size(117, 33);
            this.radBtnTreasury.TabIndex = 2;
            this.radBtnTreasury.Text = "TREASURY";
            this.radBtnTreasury.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radBtnTreasury.UseVisualStyleBackColor = true;
            this.radBtnTreasury.Visible = false;
            this.radBtnTreasury.CheckedChanged += new System.EventHandler(this.radBtnTreasury_CheckedChanged);
            // 
            // tabControlDashboard
            // 
            this.tabControlDashboard.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlDashboard.Controls.Add(this.tabPageBudget);
            this.tabControlDashboard.Controls.Add(this.tabPageAccounting);
            this.tabControlDashboard.Controls.Add(this.tabPageTreasury);
            this.tabControlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDashboard.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlDashboard.Location = new System.Drawing.Point(0, 73);
            this.tabControlDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlDashboard.Name = "tabControlDashboard";
            this.tabControlDashboard.Padding = new System.Drawing.Point(0, 0);
            this.tabControlDashboard.SelectedIndex = 0;
            this.tabControlDashboard.Size = new System.Drawing.Size(1405, 836);
            this.tabControlDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDashboard.TabIndex = 9;
            // 
            // tabPageBudget
            // 
            this.tabPageBudget.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudget.Controls.Add(this.tabControlBudget);
            this.tabPageBudget.Controls.Add(this.chkbxDetailed);
            this.tabPageBudget.Controls.Add(this.flowLayoutPanel6);
            this.tabPageBudget.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageBudget.Name = "tabPageBudget";
            this.tabPageBudget.Size = new System.Drawing.Size(1397, 827);
            this.tabPageBudget.TabIndex = 0;
            this.tabPageBudget.Text = "Budget";
            // 
            // tabControlBudget
            // 
            this.tabControlBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlBudget.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlBudget.Controls.Add(this.tabPageBudgetSummary);
            this.tabControlBudget.Controls.Add(this.tabPageBudgetDetailed);
            this.tabControlBudget.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlBudget.Location = new System.Drawing.Point(0, 72);
            this.tabControlBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlBudget.Name = "tabControlBudget";
            this.tabControlBudget.SelectedIndex = 0;
            this.tabControlBudget.Size = new System.Drawing.Size(1397, 748);
            this.tabControlBudget.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlBudget.TabIndex = 8;
            // 
            // tabPageBudgetSummary
            // 
            this.tabPageBudgetSummary.AutoScroll = true;
            this.tabPageBudgetSummary.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.tabPageBudgetSummary.AutoScrollMinSize = new System.Drawing.Size(1112, 535);
            this.tabPageBudgetSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudgetSummary.Controls.Add(this.ucBudgetSummary1);
            this.tabPageBudgetSummary.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudgetSummary.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageBudgetSummary.Name = "tabPageBudgetSummary";
            this.tabPageBudgetSummary.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageBudgetSummary.Size = new System.Drawing.Size(1389, 739);
            this.tabPageBudgetSummary.TabIndex = 0;
            this.tabPageBudgetSummary.Text = "Budget Summary";
            // 
            // ucBudgetSummary1
            // 
            this.ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetSummary1.Location = new System.Drawing.Point(2, 4);
            this.ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBudgetSummary1.MinimumSize = new System.Drawing.Size(1112, 535);
            this.ucBudgetSummary1.Name = "ucBudgetSummary1";
            this.ucBudgetSummary1.Size = new System.Drawing.Size(1385, 731);
            this.ucBudgetSummary1.TabIndex = 0;
            // 
            // tabPageBudgetDetailed
            // 
            this.tabPageBudgetDetailed.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudgetDetailed.Controls.Add(this.ucBudgetDetailed1);
            this.tabPageBudgetDetailed.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudgetDetailed.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageBudgetDetailed.Name = "tabPageBudgetDetailed";
            this.tabPageBudgetDetailed.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageBudgetDetailed.Size = new System.Drawing.Size(1214, 544);
            this.tabPageBudgetDetailed.TabIndex = 1;
            this.tabPageBudgetDetailed.Text = "Budget Detailed";
            // 
            // ucBudgetDetailed1
            // 
            this.ucBudgetDetailed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetDetailed1.Location = new System.Drawing.Point(2, 4);
            this.ucBudgetDetailed1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucBudgetDetailed1.Name = "ucBudgetDetailed1";
            this.ucBudgetDetailed1.Size = new System.Drawing.Size(1210, 538);
            this.ucBudgetDetailed1.TabIndex = 0;
            // 
            // chkbxDetailed
            // 
            this.chkbxDetailed.AutoSize = true;
            this.chkbxDetailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkbxDetailed.Location = new System.Drawing.Point(6, 51);
            this.chkbxDetailed.Margin = new System.Windows.Forms.Padding(0);
            this.chkbxDetailed.Name = "chkbxDetailed";
            this.chkbxDetailed.Size = new System.Drawing.Size(88, 24);
            this.chkbxDetailed.TabIndex = 7;
            this.chkbxDetailed.Text = "Detailed";
            this.chkbxDetailed.UseVisualStyleBackColor = true;
            this.chkbxDetailed.CheckedChanged += new System.EventHandler(this.chkbxDetailed_CheckedChanged);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.AutoSize = true;
            this.flowLayoutPanel6.Controls.Add(this.btnBudgetAppropriations);
            this.flowLayoutPanel6.Controls.Add(this.btnAllotmentRelease);
            this.flowLayoutPanel6.Controls.Add(this.btnObligationRequest);
            this.flowLayoutPanel6.Controls.Add(this.btnSAAOB);
            this.flowLayoutPanel6.Controls.Add(this.btnSAAOBB);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(1397, 43);
            this.flowLayoutPanel6.TabIndex = 9;
            // 
            // btnBudgetAppropriations
            // 
            this.btnBudgetAppropriations.AutoSize = true;
            this.btnBudgetAppropriations.BackColor = System.Drawing.Color.Transparent;
            this.btnBudgetAppropriations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBudgetAppropriations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBudgetAppropriations.Image = global::AccountingSystem.Properties.Resources.view_list_money_banknotes_20px;
            this.btnBudgetAppropriations.Location = new System.Drawing.Point(0, 0);
            this.btnBudgetAppropriations.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnBudgetAppropriations.Name = "btnBudgetAppropriations";
            this.btnBudgetAppropriations.Size = new System.Drawing.Size(218, 43);
            this.btnBudgetAppropriations.TabIndex = 0;
            this.btnBudgetAppropriations.Text = "Budget Appropriations";
            this.btnBudgetAppropriations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBudgetAppropriations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBudgetAppropriations.UseVisualStyleBackColor = false;
            this.btnBudgetAppropriations.Click += new System.EventHandler(this.btnBudgetAppropriations_Click);
            // 
            // btnAllotmentRelease
            // 
            this.btnAllotmentRelease.AutoSize = true;
            this.btnAllotmentRelease.BackColor = System.Drawing.Color.Transparent;
            this.btnAllotmentRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAllotmentRelease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAllotmentRelease.Image = global::AccountingSystem.Properties.Resources.money_banknotes_1_filled_arrow_right_filled_20px;
            this.btnAllotmentRelease.Location = new System.Drawing.Point(220, 0);
            this.btnAllotmentRelease.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnAllotmentRelease.Name = "btnAllotmentRelease";
            this.btnAllotmentRelease.Size = new System.Drawing.Size(183, 43);
            this.btnAllotmentRelease.TabIndex = 1;
            this.btnAllotmentRelease.Text = "Allotment Release";
            this.btnAllotmentRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllotmentRelease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAllotmentRelease.UseVisualStyleBackColor = false;
            this.btnAllotmentRelease.Click += new System.EventHandler(this.btnAllotmentRelease_Click);
            // 
            // btnObligationRequest
            // 
            this.btnObligationRequest.AutoSize = true;
            this.btnObligationRequest.BackColor = System.Drawing.Color.Transparent;
            this.btnObligationRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnObligationRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnObligationRequest.Image = global::AccountingSystem.Properties.Resources.give_money_2_20px;
            this.btnObligationRequest.Location = new System.Drawing.Point(405, 0);
            this.btnObligationRequest.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnObligationRequest.Name = "btnObligationRequest";
            this.btnObligationRequest.Size = new System.Drawing.Size(126, 43);
            this.btnObligationRequest.TabIndex = 2;
            this.btnObligationRequest.Text = "Obligation";
            this.btnObligationRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnObligationRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnObligationRequest.UseVisualStyleBackColor = false;
            this.btnObligationRequest.Click += new System.EventHandler(this.btnObligationRequest_Click);
            // 
            // btnSAAOB
            // 
            this.btnSAAOB.Image = global::AccountingSystem.Properties.Resources.document_data_2_20px;
            this.btnSAAOB.Location = new System.Drawing.Point(533, 0);
            this.btnSAAOB.Margin = new System.Windows.Forms.Padding(0);
            this.btnSAAOB.Name = "btnSAAOB";
            this.btnSAAOB.Size = new System.Drawing.Size(110, 43);
            this.btnSAAOB.TabIndex = 3;
            this.btnSAAOB.Text = "SAAOB";
            this.btnSAAOB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSAAOB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSAAOB.UseVisualStyleBackColor = true;
            this.btnSAAOB.Click += new System.EventHandler(this.btnSAAOB_Click);
            // 
            // btnSAAOBB
            // 
            this.btnSAAOBB.Image = global::AccountingSystem.Properties.Resources.document_data_20px;
            this.btnSAAOBB.Location = new System.Drawing.Point(643, 0);
            this.btnSAAOBB.Margin = new System.Windows.Forms.Padding(0);
            this.btnSAAOBB.Name = "btnSAAOBB";
            this.btnSAAOBB.Size = new System.Drawing.Size(110, 43);
            this.btnSAAOBB.TabIndex = 3;
            this.btnSAAOBB.Text = "SAAOBB";
            this.btnSAAOBB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSAAOBB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSAAOBB.UseVisualStyleBackColor = true;
            this.btnSAAOBB.Click += new System.EventHandler(this.btnSAAOBB_Click);
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.tabControlAccounting);
            this.tabPageAccounting.Controls.Add(this.flowLayoutPanel5);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 5);
            this.tabPageAccounting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Size = new System.Drawing.Size(1221, 610);
            this.tabPageAccounting.TabIndex = 1;
            this.tabPageAccounting.Text = "Accounting";
            this.tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // tabControlAccounting
            // 
            this.tabControlAccounting.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlAccounting.Controls.Add(this.tabPageJournalEntryVoucher);
            this.tabControlAccounting.Controls.Add(this.tabPageJournals);
            this.tabControlAccounting.Controls.Add(this.tabPageLedgers);
            this.tabControlAccounting.Controls.Add(this.tabPageTrialBalance);
            this.tabControlAccounting.Controls.Add(this.tabPageFinancialStatements);
            this.tabControlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccounting.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlAccounting.Location = new System.Drawing.Point(0, 51);
            this.tabControlAccounting.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAccounting.Name = "tabControlAccounting";
            this.tabControlAccounting.Padding = new System.Drawing.Point(0, 0);
            this.tabControlAccounting.SelectedIndex = 0;
            this.tabControlAccounting.Size = new System.Drawing.Size(1221, 572);
            this.tabControlAccounting.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlAccounting.TabIndex = 0;
            // 
            // tabPageJournalEntryVoucher
            // 
            this.tabPageJournalEntryVoucher.Controls.Add(this.ucjevDashboard1);
            this.tabPageJournalEntryVoucher.Location = new System.Drawing.Point(4, 5);
            this.tabPageJournalEntryVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageJournalEntryVoucher.Name = "tabPageJournalEntryVoucher";
            this.tabPageJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageJournalEntryVoucher.Size = new System.Drawing.Size(1213, 563);
            this.tabPageJournalEntryVoucher.TabIndex = 0;
            this.tabPageJournalEntryVoucher.Text = "Journal Entry Voucher";
            this.tabPageJournalEntryVoucher.UseVisualStyleBackColor = true;
            // 
            // ucjevDashboard1
            // 
            this.ucjevDashboard1.AutoSize = true;
            this.ucjevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucjevDashboard1.Location = new System.Drawing.Point(2, 4);
            this.ucjevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucjevDashboard1.MinimumSize = new System.Drawing.Size(817, 227);
            this.ucjevDashboard1.Name = "ucjevDashboard1";
            this.ucjevDashboard1.Size = new System.Drawing.Size(1209, 170);
            this.ucjevDashboard1.TabIndex = 0;
            // 
            // tabPageJournals
            // 
            this.tabPageJournals.Controls.Add(this.ucJournalsDashboard1);
            this.tabPageJournals.Location = new System.Drawing.Point(4, 5);
            this.tabPageJournals.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageJournals.Name = "tabPageJournals";
            this.tabPageJournals.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPageJournals.Size = new System.Drawing.Size(1213, 563);
            this.tabPageJournals.TabIndex = 1;
            this.tabPageJournals.Text = "Journals";
            this.tabPageJournals.UseVisualStyleBackColor = true;
            // 
            // ucJournalsDashboard1
            // 
            this.ucJournalsDashboard1.AutoSize = true;
            this.ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucJournalsDashboard1.Location = new System.Drawing.Point(2, 4);
            this.ucJournalsDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucJournalsDashboard1.MinimumSize = new System.Drawing.Size(983, 227);
            this.ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            this.ucJournalsDashboard1.Size = new System.Drawing.Size(1209, 170);
            this.ucJournalsDashboard1.TabIndex = 0;
            // 
            // tabPageLedgers
            // 
            this.tabPageLedgers.Controls.Add(this.tabControlLedgers);
            this.tabPageLedgers.Controls.Add(this.flowLayoutPanel2);
            this.tabPageLedgers.Location = new System.Drawing.Point(4, 5);
            this.tabPageLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageLedgers.Name = "tabPageLedgers";
            this.tabPageLedgers.Size = new System.Drawing.Size(1213, 563);
            this.tabPageLedgers.TabIndex = 2;
            this.tabPageLedgers.Text = "Ledgers";
            this.tabPageLedgers.UseVisualStyleBackColor = true;
            // 
            // tabControlLedgers
            // 
            this.tabControlLedgers.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlLedgers.Controls.Add(this.tabPageGeneralLedger);
            this.tabControlLedgers.Controls.Add(this.tabPageSubsidiaryLedger);
            this.tabControlLedgers.Controls.Add(this.tabPageTransactionLog);
            this.tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLedgers.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlLedgers.Location = new System.Drawing.Point(0, 43);
            this.tabControlLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlLedgers.Multiline = true;
            this.tabControlLedgers.Name = "tabControlLedgers";
            this.tabControlLedgers.Padding = new System.Drawing.Point(0, 0);
            this.tabControlLedgers.SelectedIndex = 0;
            this.tabControlLedgers.Size = new System.Drawing.Size(1213, 531);
            this.tabControlLedgers.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlLedgers.TabIndex = 0;
            // 
            // tabPageGeneralLedger
            // 
            this.tabPageGeneralLedger.Controls.Add(this.ucGeneralLedger1);
            this.tabPageGeneralLedger.Location = new System.Drawing.Point(4, 5);
            this.tabPageGeneralLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            this.tabPageGeneralLedger.Size = new System.Drawing.Size(1205, 522);
            this.tabPageGeneralLedger.TabIndex = 0;
            this.tabPageGeneralLedger.Text = "Generl Ledger";
            this.tabPageGeneralLedger.UseVisualStyleBackColor = true;
            // 
            // ucGeneralLedger1
            // 
            this.ucGeneralLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGeneralLedger1.Location = new System.Drawing.Point(0, 0);
            this.ucGeneralLedger1.Margin = new System.Windows.Forms.Padding(0);
            this.ucGeneralLedger1.Name = "ucGeneralLedger1";
            this.ucGeneralLedger1.Size = new System.Drawing.Size(1205, 522);
            this.ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageSubsidiaryLedger
            // 
            this.tabPageSubsidiaryLedger.Controls.Add(this.ucSubsidiaryLedger1);
            this.tabPageSubsidiaryLedger.Location = new System.Drawing.Point(4, 5);
            this.tabPageSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSubsidiaryLedger.Name = "tabPageSubsidiaryLedger";
            this.tabPageSubsidiaryLedger.Size = new System.Drawing.Size(1205, 522);
            this.tabPageSubsidiaryLedger.TabIndex = 1;
            this.tabPageSubsidiaryLedger.Text = "Subsidiary Ledger";
            this.tabPageSubsidiaryLedger.UseVisualStyleBackColor = true;
            // 
            // ucSubsidiaryLedger1
            // 
            this.ucSubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubsidiaryLedger1.Location = new System.Drawing.Point(0, 0);
            this.ucSubsidiaryLedger1.Margin = new System.Windows.Forms.Padding(0);
            this.ucSubsidiaryLedger1.Name = "ucSubsidiaryLedger1";
            this.ucSubsidiaryLedger1.Size = new System.Drawing.Size(1205, 522);
            this.ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageTransactionLog
            // 
            this.tabPageTransactionLog.Controls.Add(this.ucTransactionLog1);
            this.tabPageTransactionLog.Location = new System.Drawing.Point(4, 5);
            this.tabPageTransactionLog.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTransactionLog.Name = "tabPageTransactionLog";
            this.tabPageTransactionLog.Size = new System.Drawing.Size(1205, 522);
            this.tabPageTransactionLog.TabIndex = 2;
            this.tabPageTransactionLog.Text = "tabPage1";
            this.tabPageTransactionLog.UseVisualStyleBackColor = true;
            // 
            // ucTransactionLog1
            // 
            this.ucTransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTransactionLog1.Location = new System.Drawing.Point(0, 0);
            this.ucTransactionLog1.Margin = new System.Windows.Forms.Padding(0);
            this.ucTransactionLog1.Name = "ucTransactionLog1";
            this.ucTransactionLog1.Size = new System.Drawing.Size(1205, 522);
            this.ucTransactionLog1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.radioGeneralLedger);
            this.flowLayoutPanel2.Controls.Add(this.radioSubsidiaryLedger);
            this.flowLayoutPanel2.Controls.Add(this.radioTransactionLog);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1213, 32);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // radioGeneralLedger
            // 
            this.radioGeneralLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioGeneralLedger.Checked = true;
            this.radioGeneralLedger.Enabled = false;
            this.radioGeneralLedger.Location = new System.Drawing.Point(2, 4);
            this.radioGeneralLedger.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioGeneralLedger.Name = "radioGeneralLedger";
            this.radioGeneralLedger.Size = new System.Drawing.Size(127, 35);
            this.radioGeneralLedger.TabIndex = 5;
            this.radioGeneralLedger.TabStop = true;
            this.radioGeneralLedger.Tag = "1";
            this.radioGeneralLedger.Text = "General Ledger";
            this.radioGeneralLedger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioGeneralLedger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioGeneralLedger.UseVisualStyleBackColor = true;
            this.radioGeneralLedger.CheckedChanged += new System.EventHandler(this.radioGeneralLedger_CheckedChanged);
            // 
            // radioSubsidiaryLedger
            // 
            this.radioSubsidiaryLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioSubsidiaryLedger.Enabled = false;
            this.radioSubsidiaryLedger.Location = new System.Drawing.Point(133, 4);
            this.radioSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioSubsidiaryLedger.Name = "radioSubsidiaryLedger";
            this.radioSubsidiaryLedger.Size = new System.Drawing.Size(127, 35);
            this.radioSubsidiaryLedger.TabIndex = 6;
            this.radioSubsidiaryLedger.Tag = "2";
            this.radioSubsidiaryLedger.Text = "Subsidiary Ledger";
            this.radioSubsidiaryLedger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioSubsidiaryLedger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioSubsidiaryLedger.UseVisualStyleBackColor = true;
            this.radioSubsidiaryLedger.CheckedChanged += new System.EventHandler(this.radioSubsidiaryLedger_CheckedChanged);
            // 
            // radioTransactionLog
            // 
            this.radioTransactionLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioTransactionLog.Enabled = false;
            this.radioTransactionLog.Location = new System.Drawing.Point(264, 4);
            this.radioTransactionLog.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioTransactionLog.Name = "radioTransactionLog";
            this.radioTransactionLog.Size = new System.Drawing.Size(127, 35);
            this.radioTransactionLog.TabIndex = 7;
            this.radioTransactionLog.Tag = "3";
            this.radioTransactionLog.Text = "Transaction Log";
            this.radioTransactionLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioTransactionLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioTransactionLog.UseVisualStyleBackColor = true;
            this.radioTransactionLog.CheckedChanged += new System.EventHandler(this.radioTransactionLog_CheckedChanged);
            // 
            // tabPageTrialBalance
            // 
            this.tabPageTrialBalance.Controls.Add(this.tabControlTrialBalance);
            this.tabPageTrialBalance.Controls.Add(this.flowLayoutPanel4);
            this.tabPageTrialBalance.Location = new System.Drawing.Point(4, 5);
            this.tabPageTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTrialBalance.Name = "tabPageTrialBalance";
            this.tabPageTrialBalance.Size = new System.Drawing.Size(1213, 563);
            this.tabPageTrialBalance.TabIndex = 3;
            this.tabPageTrialBalance.Text = "Trial Balance";
            this.tabPageTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabControlTrialBalance
            // 
            this.tabControlTrialBalance.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlTrialBalance.Controls.Add(this.tabPagePreTrial);
            this.tabControlTrialBalance.Controls.Add(this.tabPagePostTrial);
            this.tabControlTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTrialBalance.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlTrialBalance.Location = new System.Drawing.Point(0, 43);
            this.tabControlTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlTrialBalance.Name = "tabControlTrialBalance";
            this.tabControlTrialBalance.Padding = new System.Drawing.Point(0, 0);
            this.tabControlTrialBalance.SelectedIndex = 0;
            this.tabControlTrialBalance.Size = new System.Drawing.Size(1213, 531);
            this.tabControlTrialBalance.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlTrialBalance.TabIndex = 5;
            // 
            // tabPagePreTrial
            // 
            this.tabPagePreTrial.Controls.Add(this.ucPreClosingTrialBalance1);
            this.tabPagePreTrial.Location = new System.Drawing.Point(4, 5);
            this.tabPagePreTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePreTrial.Name = "tabPagePreTrial";
            this.tabPagePreTrial.Size = new System.Drawing.Size(1205, 522);
            this.tabPagePreTrial.TabIndex = 0;
            this.tabPagePreTrial.Text = "tabPage1";
            this.tabPagePreTrial.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            this.ucPreClosingTrialBalance1.BackColor = System.Drawing.Color.Transparent;
            this.ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPreClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            this.ucPreClosingTrialBalance1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            this.ucPreClosingTrialBalance1.Size = new System.Drawing.Size(1205, 522);
            this.ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePostTrial
            // 
            this.tabPagePostTrial.Controls.Add(this.ucPostClosingTrialBalance1);
            this.tabPagePostTrial.Location = new System.Drawing.Point(4, 5);
            this.tabPagePostTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePostTrial.Name = "tabPagePostTrial";
            this.tabPagePostTrial.Size = new System.Drawing.Size(1205, 522);
            this.tabPagePostTrial.TabIndex = 1;
            this.tabPagePostTrial.Text = "tabPage2";
            this.tabPagePostTrial.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            this.ucPostClosingTrialBalance1.BackColor = System.Drawing.Color.Transparent;
            this.ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPostClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            this.ucPostClosingTrialBalance1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            this.ucPostClosingTrialBalance1.Size = new System.Drawing.Size(1205, 522);
            this.ucPostClosingTrialBalance1.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.radioPreTB);
            this.flowLayoutPanel4.Controls.Add(this.radioPostTB);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1213, 32);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // radioPreTB
            // 
            this.radioPreTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPreTB.Checked = true;
            this.radioPreTB.Enabled = false;
            this.radioPreTB.Location = new System.Drawing.Point(2, 4);
            this.radioPreTB.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioPreTB.Name = "radioPreTB";
            this.radioPreTB.Size = new System.Drawing.Size(130, 35);
            this.radioPreTB.TabIndex = 6;
            this.radioPreTB.TabStop = true;
            this.radioPreTB.Text = "Pre Trial Balance";
            this.radioPreTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPreTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPreTB.UseVisualStyleBackColor = true;
            this.radioPreTB.Click += new System.EventHandler(this.radioPreTB_CheckedChanged);
            // 
            // radioPostTB
            // 
            this.radioPostTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPostTB.Enabled = false;
            this.radioPostTB.Location = new System.Drawing.Point(136, 4);
            this.radioPostTB.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioPostTB.Name = "radioPostTB";
            this.radioPostTB.Size = new System.Drawing.Size(130, 35);
            this.radioPostTB.TabIndex = 7;
            this.radioPostTB.Text = "Post Trial Balance";
            this.radioPostTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPostTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPostTB.UseVisualStyleBackColor = true;
            this.radioPostTB.Click += new System.EventHandler(this.radioPostTB_CheckedChanged);
            // 
            // tabPageFinancialStatements
            // 
            this.tabPageFinancialStatements.Controls.Add(this.tabControlFinancialStatements);
            this.tabPageFinancialStatements.Controls.Add(this.flowLayoutPanel3);
            this.tabPageFinancialStatements.Location = new System.Drawing.Point(4, 5);
            this.tabPageFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageFinancialStatements.Name = "tabPageFinancialStatements";
            this.tabPageFinancialStatements.Size = new System.Drawing.Size(1213, 563);
            this.tabPageFinancialStatements.TabIndex = 4;
            this.tabPageFinancialStatements.Text = "Financial Statements";
            this.tabPageFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabControlFinancialStatements
            // 
            this.tabControlFinancialStatements.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPosition);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSFPerformance);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCNAE);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCF);
            this.tabControlFinancialStatements.Controls.Add(this.tabPageSCBAA);
            this.tabControlFinancialStatements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFinancialStatements.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlFinancialStatements.Location = new System.Drawing.Point(0, 31);
            this.tabControlFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlFinancialStatements.Name = "tabControlFinancialStatements";
            this.tabControlFinancialStatements.SelectedIndex = 0;
            this.tabControlFinancialStatements.Size = new System.Drawing.Size(1213, 532);
            this.tabControlFinancialStatements.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlFinancialStatements.TabIndex = 4;
            // 
            // tabPageSFPosition
            // 
            this.tabPageSFPosition.Controls.Add(this.ucStatementOfFinancialPosition1);
            this.tabPageSFPosition.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPosition.Name = "tabPageSFPosition";
            this.tabPageSFPosition.Size = new System.Drawing.Size(1205, 523);
            this.tabPageSFPosition.TabIndex = 0;
            this.tabPageSFPosition.Text = "tabSFPosition";
            this.tabPageSFPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            this.ucStatementOfFinancialPosition1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPosition1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            this.ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(1205, 523);
            this.ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabPageSFPerformance
            // 
            this.tabPageSFPerformance.Controls.Add(this.ucStatementOfFinancialPerformance1);
            this.tabPageSFPerformance.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPerformance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPerformance.Name = "tabPageSFPerformance";
            this.tabPageSFPerformance.Size = new System.Drawing.Size(1205, 523);
            this.tabPageSFPerformance.TabIndex = 1;
            this.tabPageSFPerformance.Text = "tabSFPerformance";
            this.tabPageSFPerformance.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            this.ucStatementOfFinancialPerformance1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPerformance1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            this.ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(1205, 523);
            this.ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // tabPageSCNAE
            // 
            this.tabPageSCNAE.Controls.Add(this.ucStatementOfChangesInNetAssetsquity1);
            this.tabPageSCNAE.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCNAE.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCNAE.Name = "tabPageSCNAE";
            this.tabPageSCNAE.Size = new System.Drawing.Size(1205, 523);
            this.tabPageSCNAE.TabIndex = 2;
            this.tabPageSCNAE.Text = "tabSCNAE";
            this.tabPageSCNAE.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfChangesInNetAssetsquity1
            // 
            this.ucStatementOfChangesInNetAssetsquity1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfChangesInNetAssetsquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfChangesInNetAssetsquity1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfChangesInNetAssetsquity1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ucStatementOfChangesInNetAssetsquity1.Name = "ucStatementOfChangesInNetAssetsquity1";
            this.ucStatementOfChangesInNetAssetsquity1.Size = new System.Drawing.Size(1205, 523);
            this.ucStatementOfChangesInNetAssetsquity1.TabIndex = 0;
            // 
            // tabPageSCF
            // 
            this.tabPageSCF.Controls.Add(this.ucStatementOfCashFlows1);
            this.tabPageSCF.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCF.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCF.Name = "tabPageSCF";
            this.tabPageSCF.Size = new System.Drawing.Size(1205, 523);
            this.tabPageSCF.TabIndex = 3;
            this.tabPageSCF.Text = "tabSCF";
            this.tabPageSCF.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfCashFlows1
            // 
            this.ucStatementOfCashFlows1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfCashFlows1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfCashFlows1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucStatementOfCashFlows1.Name = "ucStatementOfCashFlows1";
            this.ucStatementOfCashFlows1.Size = new System.Drawing.Size(1205, 523);
            this.ucStatementOfCashFlows1.TabIndex = 0;
            // 
            // tabPageSCBAA
            // 
            this.tabPageSCBAA.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCBAA.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCBAA.Name = "tabPageSCBAA";
            this.tabPageSCBAA.Size = new System.Drawing.Size(1205, 523);
            this.tabPageSCBAA.TabIndex = 4;
            this.tabPageSCBAA.Text = "tabSCBAA";
            this.tabPageSCBAA.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.Controls.Add(this.radSFPosition);
            this.flowLayoutPanel3.Controls.Add(this.radSFPerformance);
            this.flowLayoutPanel3.Controls.Add(this.radSCNAE);
            this.flowLayoutPanel3.Controls.Add(this.radSCF);
            this.flowLayoutPanel3.Controls.Add(this.radSCBAA);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1213, 31);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // radSFPosition
            // 
            this.radSFPosition.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSFPosition.AutoSize = true;
            this.radSFPosition.Location = new System.Drawing.Point(2, 4);
            this.radSFPosition.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radSFPosition.Name = "radSFPosition";
            this.radSFPosition.Size = new System.Drawing.Size(223, 30);
            this.radSFPosition.TabIndex = 5;
            this.radSFPosition.Text = "Statement of Financial Position";
            this.radSFPosition.UseVisualStyleBackColor = true;
            this.radSFPosition.CheckedChanged += new System.EventHandler(this.radSFPosition_CheckedChanged);
            // 
            // radSFPerformance
            // 
            this.radSFPerformance.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSFPerformance.AutoSize = true;
            this.radSFPerformance.Enabled = false;
            this.radSFPerformance.Location = new System.Drawing.Point(229, 4);
            this.radSFPerformance.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radSFPerformance.Name = "radSFPerformance";
            this.radSFPerformance.Size = new System.Drawing.Size(254, 30);
            this.radSFPerformance.TabIndex = 4;
            this.radSFPerformance.Text = "Statement of Financial Performance";
            this.radSFPerformance.UseVisualStyleBackColor = true;
            this.radSFPerformance.CheckedChanged += new System.EventHandler(this.radSFPerformance_CheckedChanged);
            // 
            // radSCNAE
            // 
            this.radSCNAE.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCNAE.AutoSize = true;
            this.radSCNAE.Enabled = false;
            this.radSCNAE.Location = new System.Drawing.Point(487, 4);
            this.radSCNAE.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radSCNAE.Name = "radSCNAE";
            this.radSCNAE.Size = new System.Drawing.Size(301, 30);
            this.radSCNAE.TabIndex = 3;
            this.radSCNAE.Text = "Statement of Changes in Net Assets/Equity";
            this.radSCNAE.UseVisualStyleBackColor = true;
            this.radSCNAE.CheckedChanged += new System.EventHandler(this.radSCNAE_CheckedChanged);
            // 
            // radSCF
            // 
            this.radSCF.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCF.AutoSize = true;
            this.radSCF.Enabled = false;
            this.radSCF.Location = new System.Drawing.Point(792, 4);
            this.radSCF.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radSCF.Name = "radSCF";
            this.radSCF.Size = new System.Drawing.Size(181, 30);
            this.radSCF.TabIndex = 2;
            this.radSCF.Text = "Statement of Cash Flows";
            this.radSCF.UseVisualStyleBackColor = true;
            this.radSCF.CheckedChanged += new System.EventHandler(this.radSCF_CheckedChanged);
            // 
            // radSCBAA
            // 
            this.radSCBAA.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSCBAA.AutoSize = true;
            this.radSCBAA.Enabled = false;
            this.radSCBAA.Location = new System.Drawing.Point(795, 3);
            this.radSCBAA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radSCBAA.Name = "radSCBAA";
            this.radSCBAA.Size = new System.Drawing.Size(397, 30);
            this.radSCBAA.TabIndex = 1;
            this.radSCBAA.Text = "Statement of Comparison of Budget and Actual Amounts";
            this.radSCBAA.UseVisualStyleBackColor = true;
            this.radSCBAA.CheckedChanged += new System.EventHandler(this.radSCBAA_CheckedChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.Controls.Add(this.radJournalEntryVoucher);
            this.flowLayoutPanel5.Controls.Add(this.radJournals);
            this.flowLayoutPanel5.Controls.Add(this.radLedgers);
            this.flowLayoutPanel5.Controls.Add(this.radTrialBalance);
            this.flowLayoutPanel5.Controls.Add(this.radFinancialStatements);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1221, 38);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // radJournalEntryVoucher
            // 
            this.radJournalEntryVoucher.Appearance = System.Windows.Forms.Appearance.Button;
            this.radJournalEntryVoucher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radJournalEntryVoucher.Image = global::AccountingSystem.Properties.Resources.document_blue_filled_edit_filled_20px;
            this.radJournalEntryVoucher.Location = new System.Drawing.Point(0, 0);
            this.radJournalEntryVoucher.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.radJournalEntryVoucher.Name = "radJournalEntryVoucher";
            this.radJournalEntryVoucher.Size = new System.Drawing.Size(193, 43);
            this.radJournalEntryVoucher.TabIndex = 5;
            this.radJournalEntryVoucher.TabStop = true;
            this.radJournalEntryVoucher.Text = "Journal Entry Voucher";
            this.radJournalEntryVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radJournalEntryVoucher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radJournalEntryVoucher.UseVisualStyleBackColor = true;
            this.radJournalEntryVoucher.Visible = false;
            this.radJournalEntryVoucher.CheckedChanged += new System.EventHandler(this.radJournalEntryVoucher_CheckedChanged);
            // 
            // radJournals
            // 
            this.radJournals.Appearance = System.Windows.Forms.Appearance.Button;
            this.radJournals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radJournals.Image = global::AccountingSystem.Properties.Resources.knowledge_books_filled_20px;
            this.radJournals.Location = new System.Drawing.Point(195, 0);
            this.radJournals.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.radJournals.Name = "radJournals";
            this.radJournals.Size = new System.Drawing.Size(125, 43);
            this.radJournals.TabIndex = 6;
            this.radJournals.TabStop = true;
            this.radJournals.Text = "Journals";
            this.radJournals.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radJournals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radJournals.UseVisualStyleBackColor = true;
            this.radJournals.Visible = false;
            this.radJournals.CheckedChanged += new System.EventHandler(this.radJournals_CheckedChanged);
            // 
            // radLedgers
            // 
            this.radLedgers.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLedgers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radLedgers.Image = global::AccountingSystem.Properties.Resources.notes_text_20px;
            this.radLedgers.Location = new System.Drawing.Point(322, 0);
            this.radLedgers.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.radLedgers.Name = "radLedgers";
            this.radLedgers.Size = new System.Drawing.Size(120, 43);
            this.radLedgers.TabIndex = 7;
            this.radLedgers.TabStop = true;
            this.radLedgers.Text = "Ledgers";
            this.radLedgers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radLedgers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radLedgers.UseVisualStyleBackColor = true;
            this.radLedgers.Visible = false;
            this.radLedgers.CheckedChanged += new System.EventHandler(this.radLedgers_CheckedChanged);
            // 
            // radTrialBalance
            // 
            this.radTrialBalance.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTrialBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radTrialBalance.Image = global::AccountingSystem.Properties.Resources.justice_filled_document_20px;
            this.radTrialBalance.Location = new System.Drawing.Point(444, 0);
            this.radTrialBalance.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.radTrialBalance.Name = "radTrialBalance";
            this.radTrialBalance.Size = new System.Drawing.Size(138, 43);
            this.radTrialBalance.TabIndex = 8;
            this.radTrialBalance.TabStop = true;
            this.radTrialBalance.Text = "Trial Balance";
            this.radTrialBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radTrialBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radTrialBalance.UseVisualStyleBackColor = true;
            this.radTrialBalance.Visible = false;
            this.radTrialBalance.CheckedChanged += new System.EventHandler(this.radTrialBalance_CheckedChanged);
            // 
            // radFinancialStatements
            // 
            this.radFinancialStatements.Appearance = System.Windows.Forms.Appearance.Button;
            this.radFinancialStatements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radFinancialStatements.Image = global::AccountingSystem.Properties.Resources.document_text_graph_stats_filled_20px;
            this.radFinancialStatements.Location = new System.Drawing.Point(584, 0);
            this.radFinancialStatements.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.radFinancialStatements.Name = "radFinancialStatements";
            this.radFinancialStatements.Size = new System.Drawing.Size(205, 43);
            this.radFinancialStatements.TabIndex = 9;
            this.radFinancialStatements.TabStop = true;
            this.radFinancialStatements.Text = "Financial Statements";
            this.radFinancialStatements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radFinancialStatements.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radFinancialStatements.UseVisualStyleBackColor = true;
            this.radFinancialStatements.Visible = false;
            this.radFinancialStatements.CheckedChanged += new System.EventHandler(this.radFinancialStatements_CheckedChanged);
            // 
            // tabPageTreasury
            // 
            this.tabPageTreasury.Controls.Add(this.ucrcdSummary1);
            this.tabPageTreasury.Controls.Add(this.menuStrip2);
            this.tabPageTreasury.Location = new System.Drawing.Point(4, 5);
            this.tabPageTreasury.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTreasury.Name = "tabPageTreasury";
            this.tabPageTreasury.Size = new System.Drawing.Size(1397, 827);
            this.tabPageTreasury.TabIndex = 2;
            this.tabPageTreasury.Text = "Treasury";
            this.tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // ucrcdSummary1
            // 
            this.ucrcdSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucrcdSummary1.Location = new System.Drawing.Point(0, 28);
            this.ucrcdSummary1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucrcdSummary1.Name = "ucrcdSummary1";
            this.ucrcdSummary1.Size = new System.Drawing.Size(1397, 799);
            this.ucrcdSummary1.TabIndex = 4;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemReceipts,
            this.checkIssuanceToolStripMenuItem,
            this.bankDepositToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip2.Size = new System.Drawing.Size(1397, 28);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItemReceipts
            // 
            this.toolStripMenuItemReceipts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.issueReceiptsToolStripMenuItem,
            this.returnedReceiptsToolStripMenuItem});
            this.toolStripMenuItemReceipts.Image = global::AccountingSystem.Properties.Resources.document_delivery_24px;
            this.toolStripMenuItemReceipts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemReceipts.Name = "toolStripMenuItemReceipts";
            this.toolStripMenuItemReceipts.Size = new System.Drawing.Size(103, 28);
            this.toolStripMenuItemReceipts.Text = "Receipts";
            // 
            // issueReceiptsToolStripMenuItem
            // 
            this.issueReceiptsToolStripMenuItem.Name = "issueReceiptsToolStripMenuItem";
            this.issueReceiptsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.issueReceiptsToolStripMenuItem.Text = "Issue Receipts";
            this.issueReceiptsToolStripMenuItem.Click += new System.EventHandler(this.btnIssueReceipt_Click);
            // 
            // returnedReceiptsToolStripMenuItem
            // 
            this.returnedReceiptsToolStripMenuItem.Name = "returnedReceiptsToolStripMenuItem";
            this.returnedReceiptsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.returnedReceiptsToolStripMenuItem.Text = "Returned Receipts";
            this.returnedReceiptsToolStripMenuItem.Click += new System.EventHandler(this.menuReturnReceipts_Click);
            // 
            // checkIssuanceToolStripMenuItem
            // 
            this.checkIssuanceToolStripMenuItem.Image = global::AccountingSystem.Properties.Resources.check_24px;
            this.checkIssuanceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkIssuanceToolStripMenuItem.Name = "checkIssuanceToolStripMenuItem";
            this.checkIssuanceToolStripMenuItem.Size = new System.Drawing.Size(145, 28);
            this.checkIssuanceToolStripMenuItem.Text = "Check Issuance";
            this.checkIssuanceToolStripMenuItem.Click += new System.EventHandler(this.checkIssuanceToolStripMenuItem_Click);
            // 
            // bankDepositToolStripMenuItem
            // 
            this.bankDepositToolStripMenuItem.Image = global::AccountingSystem.Properties.Resources.bank_deposit_filled_24px;
            this.bankDepositToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bankDepositToolStripMenuItem.Name = "bankDepositToolStripMenuItem";
            this.bankDepositToolStripMenuItem.Size = new System.Drawing.Size(135, 28);
            this.bankDepositToolStripMenuItem.Text = "Bank Deposit";
            this.bankDepositToolStripMenuItem.Click += new System.EventHandler(this.bankDepositToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPaymentPortal,
            this.toolStripSeparator4,
            this.toolStripMenuAssessmentPosting});
            this.paymentsToolStripMenuItem.Image = global::AccountingSystem.Properties.Resources.money_banknote_filled_archive_24px;
            this.paymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // MenuPaymentPortal
            // 
            this.MenuPaymentPortal.Enabled = false;
            this.MenuPaymentPortal.Name = "MenuPaymentPortal";
            this.MenuPaymentPortal.Size = new System.Drawing.Size(180, 22);
            this.MenuPaymentPortal.Text = "Payment Portal";
            this.MenuPaymentPortal.Click += new System.EventHandler(this.MenuPaymentPortal_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuAssessmentPosting
            // 
            this.toolStripMenuAssessmentPosting.Enabled = false;
            this.toolStripMenuAssessmentPosting.Name = "toolStripMenuAssessmentPosting";
            this.toolStripMenuAssessmentPosting.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuAssessmentPosting.Text = "Assessment Posting";
            this.toolStripMenuAssessmentPosting.Click += new System.EventHandler(this.toolStripMenuAssessmentPosting_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectorsRCDToolStripMenuItem,
            this.liquidatorsRCDToolStripMenuItem,
            this.toolStripSeparator6,
            this.collectionPaymentToolStripMenuItem,
            this.toolStripSeparator5,
            this.rCIToolStripMenuItem,
            this.bankCashbookToolStripMenuItem,
            this.consolidatedReceiptsToolStripMenuItem,
            this.dailyCashPositionsToolStripMenuItem});
            this.reportsToolStripMenuItem.Image = global::AccountingSystem.Properties.Resources.knowledge_books_filled_24px;
            this.reportsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // collectorsRCDToolStripMenuItem
            // 
            this.collectorsRCDToolStripMenuItem.Name = "collectorsRCDToolStripMenuItem";
            this.collectorsRCDToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.collectorsRCDToolStripMenuItem.Text = "Collector\'s RCD";
            this.collectorsRCDToolStripMenuItem.Click += new System.EventHandler(this.collectorsRCDToolStripMenuItem_Click);
            // 
            // liquidatorsRCDToolStripMenuItem
            // 
            this.liquidatorsRCDToolStripMenuItem.Name = "liquidatorsRCDToolStripMenuItem";
            this.liquidatorsRCDToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.liquidatorsRCDToolStripMenuItem.Text = "Liquidator\'s RCD";
            this.liquidatorsRCDToolStripMenuItem.Click += new System.EventHandler(this.liquidatorsRCDToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(497, 6);
            // 
            // collectionPaymentToolStripMenuItem
            // 
            this.collectionPaymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportOfCollectionsDepositsRCDToolStripMenuItem,
            this.abstractOfGeneralCollectionsToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItemrealPropertyTaxAccountRegister,
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount,
            this.toolStripSeparator7,
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues,
            this.toolStripMenuItemListOfDelinquentAccounts});
            this.collectionPaymentToolStripMenuItem.Name = "collectionPaymentToolStripMenuItem";
            this.collectionPaymentToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.collectionPaymentToolStripMenuItem.Text = "Collection/Payment";
            // 
            // reportOfCollectionsDepositsRCDToolStripMenuItem
            // 
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Name = "reportOfCollectionsDepositsRCDToolStripMenuItem";
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Size = new System.Drawing.Size(383, 26);
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Text = "Report of Collections Deposits (RCD)";
            this.reportOfCollectionsDepositsRCDToolStripMenuItem.Click += new System.EventHandler(this.reportOfCollectionsDepositsRCDToolStripMenuItem_Click);
            // 
            // abstractOfGeneralCollectionsToolStripMenuItem
            // 
            this.abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;
            this.abstractOfGeneralCollectionsToolStripMenuItem.Name = "abstractOfGeneralCollectionsToolStripMenuItem";
            this.abstractOfGeneralCollectionsToolStripMenuItem.Size = new System.Drawing.Size(383, 26);
            this.abstractOfGeneralCollectionsToolStripMenuItem.Text = "Abstract of General Collections";
            this.abstractOfGeneralCollectionsToolStripMenuItem.Click += new System.EventHandler(this.abstractOfGeneralCollectionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(380, 6);
            // 
            // toolStripMenuItemrealPropertyTaxAccountRegister
            // 
            this.toolStripMenuItemrealPropertyTaxAccountRegister.Enabled = false;
            this.toolStripMenuItemrealPropertyTaxAccountRegister.Name = "toolStripMenuItemrealPropertyTaxAccountRegister";
            this.toolStripMenuItemrealPropertyTaxAccountRegister.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItemrealPropertyTaxAccountRegister.Text = "Real Property Tax Account Register (RPTAR)";
            this.toolStripMenuItemrealPropertyTaxAccountRegister.Click += new System.EventHandler(this.toolStripMenuItemrealPropertyTaxAccountRegister_Click);
            // 
            // toolStripMenuItemRealPropertyTaxStatementOfAccount
            // 
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount.Enabled = false;
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount.Name = "toolStripMenuItemRealPropertyTaxStatementOfAccount";
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount.Text = "Real Property Tax Statement of Account";
            this.toolStripMenuItemRealPropertyTaxStatementOfAccount.Click += new System.EventHandler(this.toolStripMenuItemRealPropertyTaxStatementOfAccount_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(380, 6);
            // 
            // toolStripMenuItemConsolidatedRealPropertyTaxDues
            // 
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues.Enabled = false;
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues.Name = "toolStripMenuItemConsolidatedRealPropertyTaxDues";
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues.Text = "Consolidated Real Property Tax Deliquences";
            this.toolStripMenuItemConsolidatedRealPropertyTaxDues.Click += new System.EventHandler(this.toolStripMenuItemConsolidatedRealPropertyTaxDues_Click);
            // 
            // toolStripMenuItemListOfDelinquentAccounts
            // 
            this.toolStripMenuItemListOfDelinquentAccounts.Enabled = false;
            this.toolStripMenuItemListOfDelinquentAccounts.Name = "toolStripMenuItemListOfDelinquentAccounts";
            this.toolStripMenuItemListOfDelinquentAccounts.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItemListOfDelinquentAccounts.Text = "List of Delinquent Accounts";
            this.toolStripMenuItemListOfDelinquentAccounts.Click += new System.EventHandler(this.toolStripMenuItemListOfDelinquentAccounts_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(497, 6);
            // 
            // rCIToolStripMenuItem
            // 
            this.rCIToolStripMenuItem.Name = "rCIToolStripMenuItem";
            this.rCIToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.rCIToolStripMenuItem.Text = "Report of Check Issued (RCI)";
            this.rCIToolStripMenuItem.Click += new System.EventHandler(this.rCIToolStripMenuItem_Click);
            // 
            // bankCashbookToolStripMenuItem
            // 
            this.bankCashbookToolStripMenuItem.Name = "bankCashbookToolStripMenuItem";
            this.bankCashbookToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.bankCashbookToolStripMenuItem.Text = "Bank Cashbook";
            this.bankCashbookToolStripMenuItem.Click += new System.EventHandler(this.bankCashbookToolStripMenuItem_Click);
            // 
            // consolidatedReceiptsToolStripMenuItem
            // 
            this.consolidatedReceiptsToolStripMenuItem.Name = "consolidatedReceiptsToolStripMenuItem";
            this.consolidatedReceiptsToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.consolidatedReceiptsToolStripMenuItem.Text = "Consolidated Report of Accountability for Accountable Forms";
            this.consolidatedReceiptsToolStripMenuItem.Click += new System.EventHandler(this.consolidatedReceiptsToolStripMenuItem_Click);
            // 
            // dailyCashPositionsToolStripMenuItem
            // 
            this.dailyCashPositionsToolStripMenuItem.Name = "dailyCashPositionsToolStripMenuItem";
            this.dailyCashPositionsToolStripMenuItem.Size = new System.Drawing.Size(500, 26);
            this.dailyCashPositionsToolStripMenuItem.Text = "Daily Cash Positions";
            this.dailyCashPositionsToolStripMenuItem.Click += new System.EventHandler(this.dailyCashPositionsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1405, 939);
            this.Controls.Add(this.tabControlDashboard);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(1420, 975);
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabControlDashboard.ResumeLayout(false);
            this.tabPageBudget.ResumeLayout(false);
            this.tabPageBudget.PerformLayout();
            this.tabControlBudget.ResumeLayout(false);
            this.tabPageBudgetSummary.ResumeLayout(false);
            this.tabPageBudgetDetailed.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.tabPageAccounting.ResumeLayout(false);
            this.tabPageAccounting.PerformLayout();
            this.tabControlAccounting.ResumeLayout(false);
            this.tabPageJournalEntryVoucher.ResumeLayout(false);
            this.tabPageJournalEntryVoucher.PerformLayout();
            this.tabPageJournals.ResumeLayout(false);
            this.tabPageJournals.PerformLayout();
            this.tabPageLedgers.ResumeLayout(false);
            this.tabPageLedgers.PerformLayout();
            this.tabControlLedgers.ResumeLayout(false);
            this.tabPageGeneralLedger.ResumeLayout(false);
            this.tabPageSubsidiaryLedger.ResumeLayout(false);
            this.tabPageTransactionLog.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPageTrialBalance.ResumeLayout(false);
            this.tabPageTrialBalance.PerformLayout();
            this.tabControlTrialBalance.ResumeLayout(false);
            this.tabPagePreTrial.ResumeLayout(false);
            this.tabPagePostTrial.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.tabPageFinancialStatements.ResumeLayout(false);
            this.tabPageFinancialStatements.PerformLayout();
            this.tabControlFinancialStatements.ResumeLayout(false);
            this.tabPageSFPosition.ResumeLayout(false);
            this.tabPageSFPerformance.ResumeLayout(false);
            this.tabPageSCNAE.ResumeLayout(false);
            this.tabPageSCF.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.tabPageTreasury.ResumeLayout(false);
            this.tabPageTreasury.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.RadioButton radBtnBudget;
        private System.Windows.Forms.RadioButton radBtnAccounting;
        private System.Windows.Forms.ToolStripMenuItem menuReceipts;
        private System.Windows.Forms.TabControl tabControlDashboard;
        internal System.Windows.Forms.TabPage tabPageAccounting;
        internal System.Windows.Forms.TabPage tabPageBudget;
        private System.Windows.Forms.TabControl tabControlAccounting;
        private System.Windows.Forms.TabPage tabPageJournalEntryVoucher;
        private System.Windows.Forms.TabPage tabPageJournals;
        private System.Windows.Forms.TabPage tabPageLedgers;
        private System.Windows.Forms.TabPage tabPageTrialBalance;
        private System.Windows.Forms.TabPage tabPageFinancialStatements;
        private Views.Dashboard.ucJEVDashboard ucjevDashboard1;
        private System.Windows.Forms.RadioButton radBtnTreasury;
        private Views.Dashboard.AccountingDashboard.ucJournalsDashboard ucJournalsDashboard1;
        private System.Windows.Forms.TabControl tabControlLedgers;
        private System.Windows.Forms.TabPage tabPageGeneralLedger;
        private System.Windows.Forms.TabPage tabPageSubsidiaryLedger;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radioGeneralLedger;
        private System.Windows.Forms.RadioButton radioSubsidiaryLedger;
        private System.Windows.Forms.RadioButton radioTransactionLog;
        private Views.Reports.Ledgers.ucGeneralLedger ucGeneralLedger1;
        private Views.Reports.Ledgers.ucSubsidiaryLedger ucSubsidiaryLedger1;
        private System.Windows.Forms.TabControl tabControlTrialBalance;
        private System.Windows.Forms.TabPage tabPagePreTrial;
        private Views.Reports.TrialBalance.ucPreClosingTrialBalance ucPreClosingTrialBalance1;
        private System.Windows.Forms.TabPage tabPagePostTrial;
        private Views.Reports.TrialBalance.ucPostClosingTrialBalance ucPostClosingTrialBalance1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radSFPosition;
        private System.Windows.Forms.RadioButton radSFPerformance;
        private System.Windows.Forms.RadioButton radSCNAE;
        private System.Windows.Forms.RadioButton radSCF;
        private System.Windows.Forms.RadioButton radSCBAA;
        private System.Windows.Forms.TabControl tabControlFinancialStatements;
        private System.Windows.Forms.TabPage tabPageSFPosition;
        private System.Windows.Forms.TabPage tabPageSFPerformance;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
        private System.Windows.Forms.TabPage tabPageSCNAE;
        private Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity ucStatementOfChangesInNetAssetsquity1;
        private System.Windows.Forms.TabPage tabPageSCF;
        private System.Windows.Forms.TabPage tabPageSCBAA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radioPostTB;
        private System.Windows.Forms.RadioButton radioPreTB;
        private System.Windows.Forms.ToolStripMenuItem amortiaztionToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkbxDetailed;
        private System.Windows.Forms.TabControl tabControlBudget;
        private System.Windows.Forms.TabPage tabPageBudgetSummary;
        private System.Windows.Forms.TabPage tabPageBudgetDetailed;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed ucBudgetDetailed1;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.RadioButton radJournalEntryVoucher;
        private System.Windows.Forms.RadioButton radJournals;
        private System.Windows.Forms.RadioButton radLedgers;
        private System.Windows.Forms.RadioButton radTrialBalance;
        private System.Windows.Forms.RadioButton radFinancialStatements;
        private System.Windows.Forms.ToolStripMenuItem signatoriesToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        internal System.Windows.Forms.Button btnBudgetAppropriations;
        internal System.Windows.Forms.Button btnAllotmentRelease;
        internal System.Windows.Forms.Button btnObligationRequest;
        private System.Windows.Forms.Button btnSAAOB;
        private System.Windows.Forms.Button btnSAAOBB;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary ucBudgetSummary1;
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
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReceipts;
        private System.Windows.Forms.ToolStripMenuItem checkIssuanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankDepositToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuPaymentPortal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAssessmentPosting;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectorsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidatorsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem rCIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankCashbookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consolidatedReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCashPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnedReceiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem collectionPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemrealPropertyTaxAccountRegister;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConsolidatedRealPropertyTaxDues;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemListOfDelinquentAccounts;
        private System.Windows.Forms.ToolStripMenuItem reportOfCollectionsDepositsRCDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abstractOfGeneralCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuTaxPayers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRealPropertyTaxStatementOfAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseSynchronization;
    }
}

