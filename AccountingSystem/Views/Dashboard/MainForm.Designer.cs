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
            components = new System.ComponentModel.Container();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuFile = new System.Windows.Forms.ToolStripMenuItem();
            menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            menuManage = new System.Windows.Forms.ToolStripMenuItem();
            menuUsers = new System.Windows.Forms.ToolStripMenuItem();
            menuUserList = new System.Windows.Forms.ToolStripMenuItem();
            menuRoles = new System.Windows.Forms.ToolStripMenuItem();
            barangaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            signatoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuFunds = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            menuJournals = new System.Windows.Forms.ToolStripMenuItem();
            menuFunctionProgramProject = new System.Windows.Forms.ToolStripMenuItem();
            menuChartOfAccounts = new System.Windows.Forms.ToolStripMenuItem();
            menuAllotmentClasses = new System.Windows.Forms.ToolStripMenuItem();
            amortiaztionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            menuCollectingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            menuDisbursingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            menuBanks = new System.Windows.Forms.ToolStripMenuItem();
            bankAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuAccForm = new System.Windows.Forms.ToolStripMenuItem();
            menuReceipts = new System.Windows.Forms.ToolStripMenuItem();
            menuTaxPayers = new System.Windows.Forms.ToolStripMenuItem();
            businessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            businessCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            businessAddOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            discountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            penaltiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            taxRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            taxTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            otherPaymentRatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            databaseSynchronizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblUserFullName = new System.Windows.Forms.ToolStripStatusLabel();
            lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            tabControlDashboard = new System.Windows.Forms.TabControl();
            tabPageBudget = new System.Windows.Forms.TabPage();
            tabControlBudget = new System.Windows.Forms.TabControl();
            tabPageBudgetSummary = new System.Windows.Forms.TabPage();
            ucBudgetSummary1 = new Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary();
            tabPageBudgetDetailed = new System.Windows.Forms.TabPage();
            ucBudgetDetailed1 = new Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonBudgetAppropriations = new System.Windows.Forms.ToolStripButton();
            toolStripButtonAllotmentRelease = new System.Windows.Forms.ToolStripButton();
            toolStripButtonObligation = new System.Windows.Forms.ToolStripButton();
            toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            sAAOBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sAAOBBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tabPageAccounting = new System.Windows.Forms.TabPage();
            tabControlAccounting = new System.Windows.Forms.TabControl();
            tabPageJournalEntryVoucher = new System.Windows.Forms.TabPage();
            ucjevDashboard1 = new Views.Dashboard.ucJEVDashboard();
            tabPageJournals = new System.Windows.Forms.TabPage();
            ucJournalsDashboard1 = new Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            tabPageLedgers = new System.Windows.Forms.TabPage();
            tabControlLedgers = new System.Windows.Forms.TabControl();
            tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            ucGeneralLedger1 = new Views.Reports.Ledgers.ucGeneralLedger();
            tabPageSubsidiaryLedger = new System.Windows.Forms.TabPage();
            ucSubsidiaryLedger1 = new Views.Reports.Ledgers.ucSubsidiaryLedger();
            tabPageSummarySL = new System.Windows.Forms.TabPage();
            ucSummarySubsidiaryLedger1 = new Views.Reports.Ledgers.ucSummarySubsidiaryLedger();
            tabPageTransactionLog = new System.Windows.Forms.TabPage();
            ucTransactionLog1 = new Views.Reports.Ledgers.ucTransactionLog();
            tabPageTrialBalance = new System.Windows.Forms.TabPage();
            tabControlTrialBalance = new System.Windows.Forms.TabControl();
            tabPagePreTrial = new System.Windows.Forms.TabPage();
            ucPreClosingTrialBalance1 = new Views.Reports.TrialBalance.ucPreClosingTrialBalance();
            tabPagePostTrial = new System.Windows.Forms.TabPage();
            ucPostClosingTrialBalance1 = new Views.Reports.TrialBalance.ucPostClosingTrialBalance();
            tabPageFinancialStatements = new System.Windows.Forms.TabPage();
            tabControlFinancialStatements = new System.Windows.Forms.TabControl();
            tabPageSFPosition = new System.Windows.Forms.TabPage();
            ucStatementOfFinancialPosition1 = new Views.Reports.Financial_Statements.ucStatementOfFinancialPosition();
            tabPageSFPerformance = new System.Windows.Forms.TabPage();
            ucStatementOfFinancialPerformance1 = new Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance();
            tabPageSCNAE = new System.Windows.Forms.TabPage();
            ucStatementOfChangesInNetAssetsEquity1 = new Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity();
            tabPageSCF = new System.Windows.Forms.TabPage();
            ucStatementOfCashFlows1 = new Views.Reports.Financial_Statements.ucStatementOfCashFlows();
            tabPageSCBAA = new System.Windows.Forms.TabPage();
            tabPageTreasury = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            ucrcdSummary1 = new Views.Dashboard.TreasuryDashboard.ucRCDSummary();
            ToolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            issueRecieptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            returnedReceiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RptToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripButtonBpl = new System.Windows.Forms.ToolStripButton();
            toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            assessmentPostingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            checkIssuanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            releasedAndUnreleaseChecksToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            bankDepositToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            collectorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            liquidatorsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            collectionPaymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            reportOfCollectionsDepositsRCDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            abstractOfGeneralCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            realPropertyTaxStatementOfAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            consolidatedRealPropertyTaxDeliquencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            listOfDelinquentAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            reportOfCheckIssuedRCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            releasedChequesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            unreleasedChequesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bankCashbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dailyCashPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            imageList1 = new System.Windows.Forms.ImageList(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControlDashboard.SuspendLayout();
            tabPageBudget.SuspendLayout();
            tabControlBudget.SuspendLayout();
            tabPageBudgetSummary.SuspendLayout();
            tabPageBudgetDetailed.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabPageAccounting.SuspendLayout();
            tabControlAccounting.SuspendLayout();
            tabPageJournalEntryVoucher.SuspendLayout();
            tabPageJournals.SuspendLayout();
            tabPageLedgers.SuspendLayout();
            tabControlLedgers.SuspendLayout();
            tabPageGeneralLedger.SuspendLayout();
            tabPageSubsidiaryLedger.SuspendLayout();
            tabPageSummarySL.SuspendLayout();
            tabPageTransactionLog.SuspendLayout();
            tabPageTrialBalance.SuspendLayout();
            tabControlTrialBalance.SuspendLayout();
            tabPagePreTrial.SuspendLayout();
            tabPagePostTrial.SuspendLayout();
            tabPageFinancialStatements.SuspendLayout();
            tabControlFinancialStatements.SuspendLayout();
            tabPageSFPosition.SuspendLayout();
            tabPageSFPerformance.SuspendLayout();
            tabPageSCNAE.SuspendLayout();
            tabPageSCF.SuspendLayout();
            tabPageTreasury.SuspendLayout();
            panel1.SuspendLayout();
            ToolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            menuStrip1.ImageScalingSize = new System.Drawing.Size(0, 0);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuFile, menuManage });
            menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            menuStrip1.Size = new System.Drawing.Size(1229, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuLogout, menuExitApp });
            menuFile.Name = "menuFile";
            menuFile.Size = new System.Drawing.Size(37, 24);
            menuFile.Text = "File";
            // 
            // menuLogout
            // 
            menuLogout.Name = "menuLogout";
            menuLogout.Size = new System.Drawing.Size(112, 22);
            menuLogout.Text = "Logout";
            menuLogout.Click += menuLogout_Click;
            // 
            // menuExitApp
            // 
            menuExitApp.Name = "menuExitApp";
            menuExitApp.Size = new System.Drawing.Size(112, 22);
            menuExitApp.Text = "Exit";
            menuExitApp.Click += menuExitApp_Click;
            // 
            // menuManage
            // 
            menuManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuUsers, barangaysToolStripMenuItem, signatoriesToolStripMenuItem, menuFunds, toolStripSeparator2, menuJournals, menuFunctionProgramProject, menuChartOfAccounts, menuAllotmentClasses, amortiaztionToolStripMenuItem, toolStripSeparator3, menuCollectingOfficer, menuDisbursingOfficer, menuBanks, bankAccountsToolStripMenuItem, menuAccForm, menuReceipts, menuTaxPayers, businessToolStripMenuItem, toolStripSeparator1, discountsToolStripMenuItem, penaltiesToolStripMenuItem, taxRatesToolStripMenuItem, taxTypesToolStripMenuItem, otherPaymentRatesToolStripMenuItem, toolStripSeparator9, databaseSynchronizationToolStripMenuItem });
            menuManage.Name = "menuManage";
            menuManage.Size = new System.Drawing.Size(62, 24);
            menuManage.Text = "Manage";
            // 
            // menuUsers
            // 
            menuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuUserList, menuRoles });
            menuUsers.Name = "menuUsers";
            menuUsers.Size = new System.Drawing.Size(223, 22);
            menuUsers.Text = "Users";
            // 
            // menuUserList
            // 
            menuUserList.Name = "menuUserList";
            menuUserList.Size = new System.Drawing.Size(111, 22);
            menuUserList.Text = "List...";
            menuUserList.Click += menuUserList_Click;
            // 
            // menuRoles
            // 
            menuRoles.Name = "menuRoles";
            menuRoles.Size = new System.Drawing.Size(111, 22);
            menuRoles.Text = "Roles...";
            menuRoles.Click += menuRoles_Click;
            // 
            // barangaysToolStripMenuItem
            // 
            barangaysToolStripMenuItem.Name = "barangaysToolStripMenuItem";
            barangaysToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            barangaysToolStripMenuItem.Text = "Barangays...";
            barangaysToolStripMenuItem.Click += barangaysToolStripMenuItem_Click;
            // 
            // signatoriesToolStripMenuItem
            // 
            signatoriesToolStripMenuItem.Name = "signatoriesToolStripMenuItem";
            signatoriesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            signatoriesToolStripMenuItem.Text = "Signatories...";
            signatoriesToolStripMenuItem.Click += signatoriesToolStripMenuItem_Click;
            // 
            // menuFunds
            // 
            menuFunds.Name = "menuFunds";
            menuFunds.Size = new System.Drawing.Size(223, 22);
            menuFunds.Text = "Funds...";
            menuFunds.Click += menuFunds_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // menuJournals
            // 
            menuJournals.Name = "menuJournals";
            menuJournals.Size = new System.Drawing.Size(223, 22);
            menuJournals.Text = "Journals...";
            menuJournals.Click += menuJournals_Click;
            // 
            // menuFunctionProgramProject
            // 
            menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            menuFunctionProgramProject.Size = new System.Drawing.Size(223, 22);
            menuFunctionProgramProject.Text = "Function/Program/Project...";
            menuFunctionProgramProject.Click += menuFunctionProgramProject_Click;
            // 
            // menuChartOfAccounts
            // 
            menuChartOfAccounts.Name = "menuChartOfAccounts";
            menuChartOfAccounts.Size = new System.Drawing.Size(223, 22);
            menuChartOfAccounts.Text = "Chart of Accounts...";
            menuChartOfAccounts.Click += menuChartOfAccounts_Click;
            // 
            // menuAllotmentClasses
            // 
            menuAllotmentClasses.Name = "menuAllotmentClasses";
            menuAllotmentClasses.Size = new System.Drawing.Size(223, 22);
            menuAllotmentClasses.Text = "Allotment Classes...";
            menuAllotmentClasses.Click += menuAllotmentClasses_Click;
            // 
            // amortiaztionToolStripMenuItem
            // 
            amortiaztionToolStripMenuItem.Enabled = false;
            amortiaztionToolStripMenuItem.Name = "amortiaztionToolStripMenuItem";
            amortiaztionToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            amortiaztionToolStripMenuItem.Text = "Amortization...";
            amortiaztionToolStripMenuItem.Click += amortiaztionToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // menuCollectingOfficer
            // 
            menuCollectingOfficer.Name = "menuCollectingOfficer";
            menuCollectingOfficer.Size = new System.Drawing.Size(223, 22);
            menuCollectingOfficer.Text = "Collecting Officers...";
            menuCollectingOfficer.Click += menuCollectingOfficer_Click;
            // 
            // menuDisbursingOfficer
            // 
            menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            menuDisbursingOfficer.Size = new System.Drawing.Size(223, 22);
            menuDisbursingOfficer.Text = "Disbursing Officers...";
            menuDisbursingOfficer.Click += MenuDisbursingOffice_Click;
            // 
            // menuBanks
            // 
            menuBanks.Name = "menuBanks";
            menuBanks.Size = new System.Drawing.Size(223, 22);
            menuBanks.Text = "Banks...";
            menuBanks.Click += menuBanks_Click;
            // 
            // bankAccountsToolStripMenuItem
            // 
            bankAccountsToolStripMenuItem.Name = "bankAccountsToolStripMenuItem";
            bankAccountsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            bankAccountsToolStripMenuItem.Text = "Bank Accounts...";
            bankAccountsToolStripMenuItem.Click += bankAccountsToolStripMenuItem_Click;
            // 
            // menuAccForm
            // 
            menuAccForm.Name = "menuAccForm";
            menuAccForm.Size = new System.Drawing.Size(223, 22);
            menuAccForm.Text = "Accountable Form...";
            menuAccForm.Click += menuAccForm_Click;
            // 
            // menuReceipts
            // 
            menuReceipts.Name = "menuReceipts";
            menuReceipts.Size = new System.Drawing.Size(223, 22);
            menuReceipts.Text = "Receipts...";
            menuReceipts.Click += menureceipts_Click;
            // 
            // menuTaxPayers
            // 
            menuTaxPayers.Name = "menuTaxPayers";
            menuTaxPayers.Size = new System.Drawing.Size(223, 22);
            menuTaxPayers.Text = "Taxpayers...";
            menuTaxPayers.Click += menuTaxPayers_Click;
            // 
            // businessToolStripMenuItem
            // 
            businessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { businessCategoriesToolStripMenuItem, businessAddOnToolStripMenuItem });
            businessToolStripMenuItem.Enabled = false;
            businessToolStripMenuItem.Name = "businessToolStripMenuItem";
            businessToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            businessToolStripMenuItem.Text = "Business";
            // 
            // businessCategoriesToolStripMenuItem
            // 
            businessCategoriesToolStripMenuItem.Name = "businessCategoriesToolStripMenuItem";
            businessCategoriesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            businessCategoriesToolStripMenuItem.Text = "Business Categories";
            businessCategoriesToolStripMenuItem.Click += businessCategoriesToolStripMenuItem_Click;
            // 
            // businessAddOnToolStripMenuItem
            // 
            businessAddOnToolStripMenuItem.Name = "businessAddOnToolStripMenuItem";
            businessAddOnToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            businessAddOnToolStripMenuItem.Text = "Business Add-on Charges";
            businessAddOnToolStripMenuItem.Click += businessAddOnToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // discountsToolStripMenuItem
            // 
            discountsToolStripMenuItem.Name = "discountsToolStripMenuItem";
            discountsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            discountsToolStripMenuItem.Text = "Discounts...";
            discountsToolStripMenuItem.Click += discountToolStripMenuItem_Click;
            // 
            // penaltiesToolStripMenuItem
            // 
            penaltiesToolStripMenuItem.Name = "penaltiesToolStripMenuItem";
            penaltiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            penaltiesToolStripMenuItem.Text = "Penalties...";
            penaltiesToolStripMenuItem.Click += penaltyToolStripMenuItem_Click;
            // 
            // taxRatesToolStripMenuItem
            // 
            taxRatesToolStripMenuItem.Name = "taxRatesToolStripMenuItem";
            taxRatesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            taxRatesToolStripMenuItem.Text = "Tax Rates...";
            taxRatesToolStripMenuItem.Click += taxRateToolStripMenuItem_Click;
            // 
            // taxTypesToolStripMenuItem
            // 
            taxTypesToolStripMenuItem.Name = "taxTypesToolStripMenuItem";
            taxTypesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            taxTypesToolStripMenuItem.Text = "Tax Types";
            taxTypesToolStripMenuItem.Click += taxTypesToolStripMenuItem_Click;
            // 
            // otherPaymentRatesToolStripMenuItem
            // 
            otherPaymentRatesToolStripMenuItem.Name = "otherPaymentRatesToolStripMenuItem";
            otherPaymentRatesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            otherPaymentRatesToolStripMenuItem.Text = "Other Payment Rates";
            otherPaymentRatesToolStripMenuItem.Click += toolStripMenuItem1_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(220, 6);
            // 
            // databaseSynchronizationToolStripMenuItem
            // 
            databaseSynchronizationToolStripMenuItem.Name = "databaseSynchronizationToolStripMenuItem";
            databaseSynchronizationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            databaseSynchronizationToolStripMenuItem.Text = "Database Synchronization...";
            databaseSynchronizationToolStripMenuItem.Click += menuDatabaseSynchronization_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblUserFullName, lblUserRole });
            statusStrip1.Location = new System.Drawing.Point(0, 684);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            statusStrip1.Size = new System.Drawing.Size(1229, 24);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblUserFullName
            // 
            lblUserFullName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            lblUserFullName.Name = "lblUserFullName";
            lblUserFullName.Size = new System.Drawing.Size(82, 19);
            lblUserFullName.Text = "lblUserDetails";
            // 
            // lblUserRole
            // 
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new System.Drawing.Size(118, 19);
            lblUserRole.Text = "toolStripStatusLabel2";
            // 
            // tabControlDashboard
            // 
            tabControlDashboard.Controls.Add(tabPageBudget);
            tabControlDashboard.Controls.Add(tabPageAccounting);
            tabControlDashboard.Controls.Add(tabPageTreasury);
            tabControlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlDashboard.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControlDashboard.ItemSize = new System.Drawing.Size(200, 30);
            tabControlDashboard.Location = new System.Drawing.Point(0, 24);
            tabControlDashboard.Margin = new System.Windows.Forms.Padding(0);
            tabControlDashboard.Multiline = true;
            tabControlDashboard.Name = "tabControlDashboard";
            tabControlDashboard.Padding = new System.Drawing.Point(30, 3);
            tabControlDashboard.SelectedIndex = 0;
            tabControlDashboard.Size = new System.Drawing.Size(1229, 660);
            tabControlDashboard.TabIndex = 9;
            // 
            // tabPageBudget
            // 
            tabPageBudget.Controls.Add(tabControlBudget);
            tabPageBudget.Controls.Add(toolStrip1);
            tabPageBudget.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPageBudget.Location = new System.Drawing.Point(4, 34);
            tabPageBudget.Name = "tabPageBudget";
            tabPageBudget.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            tabPageBudget.Size = new System.Drawing.Size(1221, 622);
            tabPageBudget.TabIndex = 3;
            tabPageBudget.Text = "Budget";
            tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // tabControlBudget
            // 
            tabControlBudget.Controls.Add(tabPageBudgetSummary);
            tabControlBudget.Controls.Add(tabPageBudgetDetailed);
            tabControlBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlBudget.Location = new System.Drawing.Point(3, 40);
            tabControlBudget.Margin = new System.Windows.Forms.Padding(0);
            tabControlBudget.Multiline = true;
            tabControlBudget.Name = "tabControlBudget";
            tabControlBudget.SelectedIndex = 0;
            tabControlBudget.Size = new System.Drawing.Size(1215, 579);
            tabControlBudget.TabIndex = 12;
            // 
            // tabPageBudgetSummary
            // 
            tabPageBudgetSummary.Controls.Add(ucBudgetSummary1);
            tabPageBudgetSummary.Location = new System.Drawing.Point(4, 24);
            tabPageBudgetSummary.Margin = new System.Windows.Forms.Padding(0);
            tabPageBudgetSummary.Name = "tabPageBudgetSummary";
            tabPageBudgetSummary.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageBudgetSummary.Size = new System.Drawing.Size(1207, 551);
            tabPageBudgetSummary.TabIndex = 0;
            tabPageBudgetSummary.Text = "Summary";
            tabPageBudgetSummary.UseVisualStyleBackColor = true;
            // 
            // ucBudgetSummary1
            // 
            ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBudgetSummary1.Location = new System.Drawing.Point(0, 5);
            ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            ucBudgetSummary1.Name = "ucBudgetSummary1";
            ucBudgetSummary1.Size = new System.Drawing.Size(1207, 546);
            ucBudgetSummary1.TabIndex = 0;
            // 
            // tabPageBudgetDetailed
            // 
            tabPageBudgetDetailed.Controls.Add(ucBudgetDetailed1);
            tabPageBudgetDetailed.Location = new System.Drawing.Point(4, 24);
            tabPageBudgetDetailed.Margin = new System.Windows.Forms.Padding(0);
            tabPageBudgetDetailed.Name = "tabPageBudgetDetailed";
            tabPageBudgetDetailed.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageBudgetDetailed.Size = new System.Drawing.Size(1207, 551);
            tabPageBudgetDetailed.TabIndex = 1;
            tabPageBudgetDetailed.Text = "Details";
            tabPageBudgetDetailed.UseVisualStyleBackColor = true;
            // 
            // ucBudgetDetailed1
            // 
            ucBudgetDetailed1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBudgetDetailed1.Location = new System.Drawing.Point(0, 5);
            ucBudgetDetailed1.Name = "ucBudgetDetailed1";
            ucBudgetDetailed1.Size = new System.Drawing.Size(1207, 546);
            ucBudgetDetailed1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonBudgetAppropriations, toolStripButtonAllotmentRelease, toolStripButtonObligation, toolStripSplitButton1 });
            toolStrip1.Location = new System.Drawing.Point(3, 5);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1215, 35);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonBudgetAppropriations
            // 
            toolStripButtonBudgetAppropriations.Image = Properties.Resources.view_list_money_banknotes_20px;
            toolStripButtonBudgetAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonBudgetAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonBudgetAppropriations.Name = "toolStripButtonBudgetAppropriations";
            toolStripButtonBudgetAppropriations.Padding = new System.Windows.Forms.Padding(4);
            toolStripButtonBudgetAppropriations.Size = new System.Drawing.Size(159, 32);
            toolStripButtonBudgetAppropriations.Text = "Budget Appropriations";
            toolStripButtonBudgetAppropriations.Click += toolStripButtonBudgetAppropriations_Click;
            // 
            // toolStripButtonAllotmentRelease
            // 
            toolStripButtonAllotmentRelease.Image = Properties.Resources.money_banknotes_1_filled_arrow_right_filled_20px;
            toolStripButtonAllotmentRelease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonAllotmentRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonAllotmentRelease.Name = "toolStripButtonAllotmentRelease";
            toolStripButtonAllotmentRelease.Padding = new System.Windows.Forms.Padding(4);
            toolStripButtonAllotmentRelease.Size = new System.Drawing.Size(134, 32);
            toolStripButtonAllotmentRelease.Text = "Allotment Release";
            toolStripButtonAllotmentRelease.Click += toolStripButtonAllotmentRelease_Click;
            // 
            // toolStripButtonObligation
            // 
            toolStripButtonObligation.Image = Properties.Resources.give_money_2_20px;
            toolStripButtonObligation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonObligation.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonObligation.Name = "toolStripButtonObligation";
            toolStripButtonObligation.Padding = new System.Windows.Forms.Padding(4);
            toolStripButtonObligation.Size = new System.Drawing.Size(95, 32);
            toolStripButtonObligation.Text = "Obligation";
            toolStripButtonObligation.Click += toolStripButtonObligation_Click;
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { sAAOBToolStripMenuItem, sAAOBBToolStripMenuItem });
            toolStripSplitButton1.Image = Properties.Resources.documents_3_20px;
            toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Padding = new System.Windows.Forms.Padding(4);
            toolStripSplitButton1.Size = new System.Drawing.Size(91, 32);
            toolStripSplitButton1.Text = "Reports";
            // 
            // sAAOBToolStripMenuItem
            // 
            sAAOBToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            sAAOBToolStripMenuItem.Name = "sAAOBToolStripMenuItem";
            sAAOBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            sAAOBToolStripMenuItem.Text = "SAAOB";
            sAAOBToolStripMenuItem.Click += sAAOBToolStripMenuItem_Click;
            // 
            // sAAOBBToolStripMenuItem
            // 
            sAAOBBToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            sAAOBBToolStripMenuItem.Name = "sAAOBBToolStripMenuItem";
            sAAOBBToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            sAAOBBToolStripMenuItem.Text = "SAAOBB";
            sAAOBBToolStripMenuItem.Click += sAAOBBToolStripMenuItem_Click;
            // 
            // tabPageAccounting
            // 
            tabPageAccounting.Controls.Add(tabControlAccounting);
            tabPageAccounting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPageAccounting.Location = new System.Drawing.Point(4, 34);
            tabPageAccounting.Margin = new System.Windows.Forms.Padding(0);
            tabPageAccounting.Name = "tabPageAccounting";
            tabPageAccounting.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageAccounting.Size = new System.Drawing.Size(1221, 622);
            tabPageAccounting.TabIndex = 1;
            tabPageAccounting.Text = "Accounting";
            tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // tabControlAccounting
            // 
            tabControlAccounting.Controls.Add(tabPageJournalEntryVoucher);
            tabControlAccounting.Controls.Add(tabPageJournals);
            tabControlAccounting.Controls.Add(tabPageLedgers);
            tabControlAccounting.Controls.Add(tabPageTrialBalance);
            tabControlAccounting.Controls.Add(tabPageFinancialStatements);
            tabControlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlAccounting.Location = new System.Drawing.Point(0, 5);
            tabControlAccounting.Margin = new System.Windows.Forms.Padding(0);
            tabControlAccounting.Name = "tabControlAccounting";
            tabControlAccounting.Padding = new System.Drawing.Point(10, 3);
            tabControlAccounting.SelectedIndex = 0;
            tabControlAccounting.Size = new System.Drawing.Size(1221, 617);
            tabControlAccounting.TabIndex = 0;
            // 
            // tabPageJournalEntryVoucher
            // 
            tabPageJournalEntryVoucher.Controls.Add(ucjevDashboard1);
            tabPageJournalEntryVoucher.Location = new System.Drawing.Point(4, 24);
            tabPageJournalEntryVoucher.Margin = new System.Windows.Forms.Padding(0);
            tabPageJournalEntryVoucher.Name = "tabPageJournalEntryVoucher";
            tabPageJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageJournalEntryVoucher.Size = new System.Drawing.Size(1213, 589);
            tabPageJournalEntryVoucher.TabIndex = 0;
            tabPageJournalEntryVoucher.Text = "Journal Entry Voucher";
            tabPageJournalEntryVoucher.UseVisualStyleBackColor = true;
            // 
            // ucjevDashboard1
            // 
            ucjevDashboard1.AutoSize = true;
            ucjevDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucjevDashboard1.Location = new System.Drawing.Point(0, 5);
            ucjevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            ucjevDashboard1.MinimumSize = new System.Drawing.Size(782, 160);
            ucjevDashboard1.Name = "ucjevDashboard1";
            ucjevDashboard1.Size = new System.Drawing.Size(1213, 584);
            ucjevDashboard1.TabIndex = 0;
            // 
            // tabPageJournals
            // 
            tabPageJournals.Controls.Add(ucJournalsDashboard1);
            tabPageJournals.Location = new System.Drawing.Point(4, 24);
            tabPageJournals.Margin = new System.Windows.Forms.Padding(0);
            tabPageJournals.Name = "tabPageJournals";
            tabPageJournals.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageJournals.Size = new System.Drawing.Size(1213, 589);
            tabPageJournals.TabIndex = 1;
            tabPageJournals.Text = "Journals";
            tabPageJournals.UseVisualStyleBackColor = true;
            // 
            // ucJournalsDashboard1
            // 
            ucJournalsDashboard1.AutoSize = true;
            ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucJournalsDashboard1.Location = new System.Drawing.Point(0, 5);
            ucJournalsDashboard1.MinimumSize = new System.Drawing.Size(941, 160);
            ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            ucJournalsDashboard1.Size = new System.Drawing.Size(1213, 584);
            ucJournalsDashboard1.TabIndex = 0;
            // 
            // tabPageLedgers
            // 
            tabPageLedgers.Controls.Add(tabControlLedgers);
            tabPageLedgers.Location = new System.Drawing.Point(4, 24);
            tabPageLedgers.Margin = new System.Windows.Forms.Padding(0);
            tabPageLedgers.Name = "tabPageLedgers";
            tabPageLedgers.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageLedgers.Size = new System.Drawing.Size(1213, 589);
            tabPageLedgers.TabIndex = 2;
            tabPageLedgers.Text = "Ledgers";
            tabPageLedgers.UseVisualStyleBackColor = true;
            // 
            // tabControlLedgers
            // 
            tabControlLedgers.Controls.Add(tabPageGeneralLedger);
            tabControlLedgers.Controls.Add(tabPageSubsidiaryLedger);
            tabControlLedgers.Controls.Add(tabPageSummarySL);
            tabControlLedgers.Controls.Add(tabPageTransactionLog);
            tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlLedgers.Location = new System.Drawing.Point(0, 5);
            tabControlLedgers.Margin = new System.Windows.Forms.Padding(0);
            tabControlLedgers.Multiline = true;
            tabControlLedgers.Name = "tabControlLedgers";
            tabControlLedgers.Padding = new System.Drawing.Point(20, 3);
            tabControlLedgers.SelectedIndex = 0;
            tabControlLedgers.Size = new System.Drawing.Size(1213, 584);
            tabControlLedgers.TabIndex = 0;
            // 
            // tabPageGeneralLedger
            // 
            tabPageGeneralLedger.Controls.Add(ucGeneralLedger1);
            tabPageGeneralLedger.Location = new System.Drawing.Point(4, 24);
            tabPageGeneralLedger.Margin = new System.Windows.Forms.Padding(0);
            tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            tabPageGeneralLedger.Size = new System.Drawing.Size(1205, 556);
            tabPageGeneralLedger.TabIndex = 0;
            tabPageGeneralLedger.Text = "General Ledger";
            tabPageGeneralLedger.UseVisualStyleBackColor = true;
            // 
            // ucGeneralLedger1
            // 
            ucGeneralLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGeneralLedger1.Location = new System.Drawing.Point(0, 0);
            ucGeneralLedger1.Name = "ucGeneralLedger1";
            ucGeneralLedger1.Size = new System.Drawing.Size(1205, 556);
            ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageSubsidiaryLedger
            // 
            tabPageSubsidiaryLedger.Controls.Add(ucSubsidiaryLedger1);
            tabPageSubsidiaryLedger.Location = new System.Drawing.Point(4, 24);
            tabPageSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(0);
            tabPageSubsidiaryLedger.Name = "tabPageSubsidiaryLedger";
            tabPageSubsidiaryLedger.Size = new System.Drawing.Size(1205, 556);
            tabPageSubsidiaryLedger.TabIndex = 1;
            tabPageSubsidiaryLedger.Text = "Subsidiary Ledger";
            tabPageSubsidiaryLedger.UseVisualStyleBackColor = true;
            // 
            // ucSubsidiaryLedger1
            // 
            ucSubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSubsidiaryLedger1.Location = new System.Drawing.Point(0, 0);
            ucSubsidiaryLedger1.Name = "ucSubsidiaryLedger1";
            ucSubsidiaryLedger1.Size = new System.Drawing.Size(1205, 556);
            ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageSummarySL
            // 
            tabPageSummarySL.Controls.Add(ucSummarySubsidiaryLedger1);
            tabPageSummarySL.Location = new System.Drawing.Point(4, 24);
            tabPageSummarySL.Margin = new System.Windows.Forms.Padding(0);
            tabPageSummarySL.Name = "tabPageSummarySL";
            tabPageSummarySL.Size = new System.Drawing.Size(1205, 556);
            tabPageSummarySL.TabIndex = 2;
            tabPageSummarySL.Text = "Summary Subsidiary Ledger";
            tabPageSummarySL.UseVisualStyleBackColor = true;
            // 
            // ucSummarySubsidiaryLedger1
            // 
            ucSummarySubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSummarySubsidiaryLedger1.Location = new System.Drawing.Point(0, 0);
            ucSummarySubsidiaryLedger1.Name = "ucSummarySubsidiaryLedger1";
            ucSummarySubsidiaryLedger1.Size = new System.Drawing.Size(1205, 556);
            ucSummarySubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageTransactionLog
            // 
            tabPageTransactionLog.Controls.Add(ucTransactionLog1);
            tabPageTransactionLog.Location = new System.Drawing.Point(4, 24);
            tabPageTransactionLog.Margin = new System.Windows.Forms.Padding(0);
            tabPageTransactionLog.Name = "tabPageTransactionLog";
            tabPageTransactionLog.Size = new System.Drawing.Size(1205, 556);
            tabPageTransactionLog.TabIndex = 3;
            tabPageTransactionLog.Text = "Transaction Log";
            tabPageTransactionLog.UseVisualStyleBackColor = true;
            // 
            // ucTransactionLog1
            // 
            ucTransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTransactionLog1.Location = new System.Drawing.Point(0, 0);
            ucTransactionLog1.Name = "ucTransactionLog1";
            ucTransactionLog1.Size = new System.Drawing.Size(1205, 556);
            ucTransactionLog1.TabIndex = 0;
            // 
            // tabPageTrialBalance
            // 
            tabPageTrialBalance.Controls.Add(tabControlTrialBalance);
            tabPageTrialBalance.Location = new System.Drawing.Point(4, 24);
            tabPageTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            tabPageTrialBalance.Name = "tabPageTrialBalance";
            tabPageTrialBalance.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageTrialBalance.Size = new System.Drawing.Size(1213, 589);
            tabPageTrialBalance.TabIndex = 3;
            tabPageTrialBalance.Text = "Trial Balance";
            tabPageTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabControlTrialBalance
            // 
            tabControlTrialBalance.Controls.Add(tabPagePreTrial);
            tabControlTrialBalance.Controls.Add(tabPagePostTrial);
            tabControlTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlTrialBalance.Location = new System.Drawing.Point(0, 5);
            tabControlTrialBalance.Name = "tabControlTrialBalance";
            tabControlTrialBalance.Padding = new System.Drawing.Point(10, 3);
            tabControlTrialBalance.SelectedIndex = 0;
            tabControlTrialBalance.Size = new System.Drawing.Size(1213, 584);
            tabControlTrialBalance.TabIndex = 0;
            // 
            // tabPagePreTrial
            // 
            tabPagePreTrial.Controls.Add(ucPreClosingTrialBalance1);
            tabPagePreTrial.Location = new System.Drawing.Point(4, 24);
            tabPagePreTrial.Name = "tabPagePreTrial";
            tabPagePreTrial.Padding = new System.Windows.Forms.Padding(3);
            tabPagePreTrial.Size = new System.Drawing.Size(1205, 556);
            tabPagePreTrial.TabIndex = 0;
            tabPagePreTrial.Text = "Pre-Closing Trial Balance";
            tabPagePreTrial.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPreClosingTrialBalance1.Location = new System.Drawing.Point(3, 3);
            ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            ucPreClosingTrialBalance1.Size = new System.Drawing.Size(1199, 550);
            ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePostTrial
            // 
            tabPagePostTrial.Controls.Add(ucPostClosingTrialBalance1);
            tabPagePostTrial.Location = new System.Drawing.Point(4, 24);
            tabPagePostTrial.Name = "tabPagePostTrial";
            tabPagePostTrial.Padding = new System.Windows.Forms.Padding(3);
            tabPagePostTrial.Size = new System.Drawing.Size(1205, 556);
            tabPagePostTrial.TabIndex = 1;
            tabPagePostTrial.Text = "Post-Closing Trial Balance";
            tabPagePostTrial.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPostClosingTrialBalance1.Location = new System.Drawing.Point(3, 3);
            ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            ucPostClosingTrialBalance1.Size = new System.Drawing.Size(1199, 550);
            ucPostClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPageFinancialStatements
            // 
            tabPageFinancialStatements.Controls.Add(tabControlFinancialStatements);
            tabPageFinancialStatements.Location = new System.Drawing.Point(4, 24);
            tabPageFinancialStatements.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            tabPageFinancialStatements.Name = "tabPageFinancialStatements";
            tabPageFinancialStatements.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageFinancialStatements.Size = new System.Drawing.Size(1213, 589);
            tabPageFinancialStatements.TabIndex = 4;
            tabPageFinancialStatements.Text = "Financial Statements";
            tabPageFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabControlFinancialStatements
            // 
            tabControlFinancialStatements.Controls.Add(tabPageSFPosition);
            tabControlFinancialStatements.Controls.Add(tabPageSFPerformance);
            tabControlFinancialStatements.Controls.Add(tabPageSCNAE);
            tabControlFinancialStatements.Controls.Add(tabPageSCF);
            tabControlFinancialStatements.Controls.Add(tabPageSCBAA);
            tabControlFinancialStatements.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlFinancialStatements.Location = new System.Drawing.Point(0, 5);
            tabControlFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            tabControlFinancialStatements.Name = "tabControlFinancialStatements";
            tabControlFinancialStatements.Padding = new System.Drawing.Point(10, 3);
            tabControlFinancialStatements.SelectedIndex = 0;
            tabControlFinancialStatements.Size = new System.Drawing.Size(1213, 584);
            tabControlFinancialStatements.TabIndex = 0;
            // 
            // tabPageSFPosition
            // 
            tabPageSFPosition.Controls.Add(ucStatementOfFinancialPosition1);
            tabPageSFPosition.Location = new System.Drawing.Point(4, 24);
            tabPageSFPosition.Margin = new System.Windows.Forms.Padding(0);
            tabPageSFPosition.Name = "tabPageSFPosition";
            tabPageSFPosition.Size = new System.Drawing.Size(1205, 556);
            tabPageSFPosition.TabIndex = 0;
            tabPageSFPosition.Text = "Statement of Financial Position";
            tabPageSFPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            ucStatementOfFinancialPosition1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(1205, 556);
            ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabPageSFPerformance
            // 
            tabPageSFPerformance.Controls.Add(ucStatementOfFinancialPerformance1);
            tabPageSFPerformance.Location = new System.Drawing.Point(4, 24);
            tabPageSFPerformance.Margin = new System.Windows.Forms.Padding(0);
            tabPageSFPerformance.Name = "tabPageSFPerformance";
            tabPageSFPerformance.Size = new System.Drawing.Size(1205, 556);
            tabPageSFPerformance.TabIndex = 1;
            tabPageSFPerformance.Text = "Statement of Financial Performance";
            tabPageSFPerformance.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            ucStatementOfFinancialPerformance1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(1205, 556);
            ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // tabPageSCNAE
            // 
            tabPageSCNAE.Controls.Add(ucStatementOfChangesInNetAssetsEquity1);
            tabPageSCNAE.Location = new System.Drawing.Point(4, 24);
            tabPageSCNAE.Margin = new System.Windows.Forms.Padding(0);
            tabPageSCNAE.Name = "tabPageSCNAE";
            tabPageSCNAE.Size = new System.Drawing.Size(1205, 556);
            tabPageSCNAE.TabIndex = 2;
            tabPageSCNAE.Text = "Statement of Changes in Net Assets/Equity";
            tabPageSCNAE.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfChangesInNetAssetsEquity1
            // 
            ucStatementOfChangesInNetAssetsEquity1.BackColor = System.Drawing.Color.Transparent;
            ucStatementOfChangesInNetAssetsEquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfChangesInNetAssetsEquity1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfChangesInNetAssetsEquity1.Name = "ucStatementOfChangesInNetAssetsEquity1";
            ucStatementOfChangesInNetAssetsEquity1.Size = new System.Drawing.Size(1205, 556);
            ucStatementOfChangesInNetAssetsEquity1.TabIndex = 0;
            // 
            // tabPageSCF
            // 
            tabPageSCF.Controls.Add(ucStatementOfCashFlows1);
            tabPageSCF.Location = new System.Drawing.Point(4, 24);
            tabPageSCF.Margin = new System.Windows.Forms.Padding(0);
            tabPageSCF.Name = "tabPageSCF";
            tabPageSCF.Size = new System.Drawing.Size(1205, 556);
            tabPageSCF.TabIndex = 3;
            tabPageSCF.Text = "Statement of Cash Flows";
            tabPageSCF.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfCashFlows1
            // 
            ucStatementOfCashFlows1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucStatementOfCashFlows1.Location = new System.Drawing.Point(0, 0);
            ucStatementOfCashFlows1.Name = "ucStatementOfCashFlows1";
            ucStatementOfCashFlows1.Size = new System.Drawing.Size(1205, 556);
            ucStatementOfCashFlows1.TabIndex = 0;
            // 
            // tabPageSCBAA
            // 
            tabPageSCBAA.Location = new System.Drawing.Point(4, 24);
            tabPageSCBAA.Margin = new System.Windows.Forms.Padding(0);
            tabPageSCBAA.Name = "tabPageSCBAA";
            tabPageSCBAA.Size = new System.Drawing.Size(1205, 556);
            tabPageSCBAA.TabIndex = 4;
            tabPageSCBAA.Text = "Statement of Comparison of Budget and Actual Amounts";
            tabPageSCBAA.UseVisualStyleBackColor = true;
            // 
            // tabPageTreasury
            // 
            tabPageTreasury.Controls.Add(panel1);
            tabPageTreasury.Location = new System.Drawing.Point(4, 34);
            tabPageTreasury.Margin = new System.Windows.Forms.Padding(0);
            tabPageTreasury.Name = "tabPageTreasury";
            tabPageTreasury.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            tabPageTreasury.Size = new System.Drawing.Size(1221, 622);
            tabPageTreasury.TabIndex = 2;
            tabPageTreasury.Text = "Treasury";
            tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucrcdSummary1);
            panel1.Controls.Add(ToolStrip2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel1.Location = new System.Drawing.Point(0, 5);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1221, 617);
            panel1.TabIndex = 0;
            // 
            // ucrcdSummary1
            // 
            ucrcdSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucrcdSummary1.Location = new System.Drawing.Point(0, 31);
            ucrcdSummary1.Name = "ucrcdSummary1";
            ucrcdSummary1.Size = new System.Drawing.Size(1221, 586);
            ucrcdSummary1.TabIndex = 10;
            // 
            // ToolStrip2
            // 
            ToolStrip2.BackColor = System.Drawing.Color.Transparent;
            ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            ToolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripSplitButton2, RptToolStripButton, toolStripButtonBpl, toolStripSplitButton3, toolStripSplitButton4 });
            ToolStrip2.Location = new System.Drawing.Point(0, 0);
            ToolStrip2.Name = "ToolStrip2";
            ToolStrip2.Size = new System.Drawing.Size(1221, 31);
            ToolStrip2.TabIndex = 9;
            ToolStrip2.Text = "toolStrip2";
            // 
            // toolStripSplitButton2
            // 
            toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { issueRecieptsToolStripMenuItem, returnedReceiptsToolStripMenuItem });
            toolStripSplitButton2.Image = Properties.Resources.document_delivery_receipt_signed_24px;
            toolStripSplitButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripSplitButton2.Name = "toolStripSplitButton2";
            toolStripSplitButton2.Size = new System.Drawing.Size(91, 28);
            toolStripSplitButton2.Text = "Reciepts";
            // 
            // issueRecieptsToolStripMenuItem
            // 
            issueRecieptsToolStripMenuItem.Name = "issueRecieptsToolStripMenuItem";
            issueRecieptsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            issueRecieptsToolStripMenuItem.Text = "Issue Reciepts";
            issueRecieptsToolStripMenuItem.Click += issueRecieptsToolStripMenuItem_Click;
            // 
            // returnedReceiptsToolStripMenuItem
            // 
            returnedReceiptsToolStripMenuItem.Name = "returnedReceiptsToolStripMenuItem";
            returnedReceiptsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            returnedReceiptsToolStripMenuItem.Text = "Returned Receipts";
            returnedReceiptsToolStripMenuItem.Click += returnedReceiptsToolStripMenuItem_Click;
            // 
            // RptToolStripButton
            // 
            RptToolStripButton.Image = Properties.Resources.building_9_archive_24px;
            RptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            RptToolStripButton.Name = "RptToolStripButton";
            RptToolStripButton.Size = new System.Drawing.Size(55, 28);
            RptToolStripButton.Text = "RPT";
            RptToolStripButton.Click += toolStripButtonRpt_Click;
            // 
            // toolStripButtonBpl
            // 
            toolStripButtonBpl.Enabled = false;
            toolStripButtonBpl.Image = Properties.Resources.briefcase_business_20px;
            toolStripButtonBpl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            toolStripButtonBpl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripButtonBpl.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonBpl.Name = "toolStripButtonBpl";
            toolStripButtonBpl.Size = new System.Drawing.Size(51, 28);
            toolStripButtonBpl.Text = "BPL";
            // 
            // toolStripSplitButton3
            // 
            toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { paymentsToolStripMenuItem, toolStripSeparator10, assessmentPostingToolStripMenuItem, toolStripSeparator11, checkIssuanceToolStripMenuItem, releasedAndUnreleaseChecksToolStripMenu, bankDepositToolStripMenuItem });
            toolStripSplitButton3.Image = Properties.Resources.money_2_24px;
            toolStripSplitButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripSplitButton3.Name = "toolStripSplitButton3";
            toolStripSplitButton3.Size = new System.Drawing.Size(112, 28);
            toolStripSplitButton3.Text = "Transactions";
            // 
            // paymentsToolStripMenuItem
            // 
            paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            paymentsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            paymentsToolStripMenuItem.Text = "Payments";
            paymentsToolStripMenuItem.Click += paymentsToolStripMenuItem_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(214, 6);
            // 
            // assessmentPostingToolStripMenuItem
            // 
            assessmentPostingToolStripMenuItem.Name = "assessmentPostingToolStripMenuItem";
            assessmentPostingToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            assessmentPostingToolStripMenuItem.Text = "Assessment Posting";
            assessmentPostingToolStripMenuItem.Click += assessmentPostingToolStripMenuItem_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(214, 6);
            // 
            // checkIssuanceToolStripMenuItem
            // 
            checkIssuanceToolStripMenuItem.Name = "checkIssuanceToolStripMenuItem";
            checkIssuanceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            checkIssuanceToolStripMenuItem.Text = "Check Issuance";
            checkIssuanceToolStripMenuItem.Click += CheckIssuanceToolStripMenuItem_Click;
            // 
            // releasedAndUnreleaseChecksToolStripMenu
            // 
            releasedAndUnreleaseChecksToolStripMenu.Name = "releasedAndUnreleaseChecksToolStripMenu";
            releasedAndUnreleaseChecksToolStripMenu.Size = new System.Drawing.Size(217, 22);
            releasedAndUnreleaseChecksToolStripMenu.Text = "Release/Unreleased Checks";
            releasedAndUnreleaseChecksToolStripMenu.Click += releasedAndUnreleaseChecksToolStripMenu_Click;
            // 
            // bankDepositToolStripMenuItem
            // 
            bankDepositToolStripMenuItem.Name = "bankDepositToolStripMenuItem";
            bankDepositToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            bankDepositToolStripMenuItem.Text = "Bank Deposit";
            bankDepositToolStripMenuItem.Click += bankDepositToolStripMenuItem_Click;
            // 
            // toolStripSplitButton4
            // 
            toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { collectorsRCDToolStripMenuItem, liquidatorsRCDToolStripMenuItem, toolStripSeparator12, collectionPaymentToolStripMenuItem1, toolStripSeparator13, reportOfCheckIssuedRCIToolStripMenuItem, releasedChequesToolStripMenuItem, unreleasedChequesToolStripMenuItem, bankCashbookToolStripMenuItem, consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem, dailyCashPositionsToolStripMenuItem });
            toolStripSplitButton4.Image = Properties.Resources.documents_3_20px;
            toolStripSplitButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripSplitButton4.Name = "toolStripSplitButton4";
            toolStripSplitButton4.Size = new System.Drawing.Size(83, 28);
            toolStripSplitButton4.Text = "Reports";
            // 
            // collectorsRCDToolStripMenuItem
            // 
            collectorsRCDToolStripMenuItem.Name = "collectorsRCDToolStripMenuItem";
            collectorsRCDToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            collectorsRCDToolStripMenuItem.Text = "Collector's RCD";
            collectorsRCDToolStripMenuItem.Click += collectorsRCDToolStripMenuItem_Click;
            // 
            // liquidatorsRCDToolStripMenuItem
            // 
            liquidatorsRCDToolStripMenuItem.Name = "liquidatorsRCDToolStripMenuItem";
            liquidatorsRCDToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            liquidatorsRCDToolStripMenuItem.Text = "Liquidator's RCD";
            liquidatorsRCDToolStripMenuItem.Click += liquidatorsRCDToolStripMenuItem_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new System.Drawing.Size(397, 6);
            // 
            // collectionPaymentToolStripMenuItem1
            // 
            collectionPaymentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { reportOfCollectionsDepositsRCDToolStripMenuItem, abstractOfGeneralCollectionsToolStripMenuItem, toolStripSeparator14, realPropertyTaxAccountRegisterRPTARToolStripMenuItem, realPropertyTaxStatementOfAccountToolStripMenuItem, toolStripSeparator15, consolidatedRealPropertyTaxDeliquencesToolStripMenuItem, listOfDelinquentAccountsToolStripMenuItem });
            collectionPaymentToolStripMenuItem1.Name = "collectionPaymentToolStripMenuItem1";
            collectionPaymentToolStripMenuItem1.Size = new System.Drawing.Size(400, 22);
            collectionPaymentToolStripMenuItem1.Text = "Collection/Payment";
            // 
            // reportOfCollectionsDepositsRCDToolStripMenuItem
            // 
            reportOfCollectionsDepositsRCDToolStripMenuItem.Enabled = false;
            reportOfCollectionsDepositsRCDToolStripMenuItem.Name = "reportOfCollectionsDepositsRCDToolStripMenuItem";
            reportOfCollectionsDepositsRCDToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            reportOfCollectionsDepositsRCDToolStripMenuItem.Text = "Report of Collections Deposits (RCD)";
            reportOfCollectionsDepositsRCDToolStripMenuItem.Click += reportOfCollectionsDepositsRCDToolStripMenuItem_Click;
            // 
            // abstractOfGeneralCollectionsToolStripMenuItem
            // 
            abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;
            abstractOfGeneralCollectionsToolStripMenuItem.Name = "abstractOfGeneralCollectionsToolStripMenuItem";
            abstractOfGeneralCollectionsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            abstractOfGeneralCollectionsToolStripMenuItem.Text = "Abstract of General Collections";
            abstractOfGeneralCollectionsToolStripMenuItem.Click += abstractOfGeneralCollectionsToolStripMenuItem_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new System.Drawing.Size(301, 6);
            // 
            // realPropertyTaxAccountRegisterRPTARToolStripMenuItem
            // 
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Enabled = false;
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Name = "realPropertyTaxAccountRegisterRPTARToolStripMenuItem";
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Text = "Real Property Tax Account Register (RPTAR)";
            realPropertyTaxAccountRegisterRPTARToolStripMenuItem.Click += realPropertyTaxAccountRegisterRPTARToolStripMenuItem_Click;
            // 
            // realPropertyTaxStatementOfAccountToolStripMenuItem
            // 
            realPropertyTaxStatementOfAccountToolStripMenuItem.Enabled = false;
            realPropertyTaxStatementOfAccountToolStripMenuItem.Name = "realPropertyTaxStatementOfAccountToolStripMenuItem";
            realPropertyTaxStatementOfAccountToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            realPropertyTaxStatementOfAccountToolStripMenuItem.Text = "Real Property Tax Statement of Account";
            realPropertyTaxStatementOfAccountToolStripMenuItem.Click += realPropertyTaxStatementOfAccountToolStripMenuItem_Click;
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new System.Drawing.Size(301, 6);
            // 
            // consolidatedRealPropertyTaxDeliquencesToolStripMenuItem
            // 
            consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Name = "consolidatedRealPropertyTaxDeliquencesToolStripMenuItem";
            consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Text = "Consolidated Real Property Tax Deliquences";
            consolidatedRealPropertyTaxDeliquencesToolStripMenuItem.Click += consolidatedRealPropertyTaxDeliquencesToolStripMenuItem_Click;
            // 
            // listOfDelinquentAccountsToolStripMenuItem
            // 
            listOfDelinquentAccountsToolStripMenuItem.Name = "listOfDelinquentAccountsToolStripMenuItem";
            listOfDelinquentAccountsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            listOfDelinquentAccountsToolStripMenuItem.Text = "List of Delinquent Accounts";
            listOfDelinquentAccountsToolStripMenuItem.Click += toolStripMenuItemListOfDelinquentAccounts_Click;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new System.Drawing.Size(397, 6);
            // 
            // reportOfCheckIssuedRCIToolStripMenuItem
            // 
            reportOfCheckIssuedRCIToolStripMenuItem.Name = "reportOfCheckIssuedRCIToolStripMenuItem";
            reportOfCheckIssuedRCIToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            reportOfCheckIssuedRCIToolStripMenuItem.Text = "Report of Check Issued (RCI)";
            reportOfCheckIssuedRCIToolStripMenuItem.Click += reportOfCheckIssuedRCIToolStripMenuItem_Click;
            // 
            // releasedChequesToolStripMenuItem
            // 
            releasedChequesToolStripMenuItem.Name = "releasedChequesToolStripMenuItem";
            releasedChequesToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            releasedChequesToolStripMenuItem.Text = "Schedule of Released Cheques";
            releasedChequesToolStripMenuItem.Click += releasedChequesToolStripMenuItem_Click;
            // 
            // unreleasedChequesToolStripMenuItem
            // 
            unreleasedChequesToolStripMenuItem.Name = "unreleasedChequesToolStripMenuItem";
            unreleasedChequesToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            unreleasedChequesToolStripMenuItem.Text = "Schedule of Unreleased Cheques";
            unreleasedChequesToolStripMenuItem.Click += unreleasedChequesToolStripMenuItem_Click;
            // 
            // bankCashbookToolStripMenuItem
            // 
            bankCashbookToolStripMenuItem.Name = "bankCashbookToolStripMenuItem";
            bankCashbookToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            bankCashbookToolStripMenuItem.Text = "Bank Cashbook";
            bankCashbookToolStripMenuItem.Click += bankCashbookToolStripMenuItem_Click;
            // 
            // consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem
            // 
            consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Name = "consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem";
            consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Text = "Consolidated Report of Accountability for Accountable Forms";
            consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Click += consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem_Click;
            // 
            // dailyCashPositionsToolStripMenuItem
            // 
            dailyCashPositionsToolStripMenuItem.Name = "dailyCashPositionsToolStripMenuItem";
            dailyCashPositionsToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            dailyCashPositionsToolStripMenuItem.Text = "Daily Cash Positions";
            dailyCashPositionsToolStripMenuItem.Click += dailyCashPositionsToolStripMenuItem_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            imageList1.ImageSize = new System.Drawing.Size(16, 16);
            imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ClientSize = new System.Drawing.Size(1229, 708);
            Controls.Add(tabControlDashboard);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(2);
            MinimumSize = new System.Drawing.Size(1244, 718);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Local Finance System";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControlDashboard.ResumeLayout(false);
            tabPageBudget.ResumeLayout(false);
            tabPageBudget.PerformLayout();
            tabControlBudget.ResumeLayout(false);
            tabPageBudgetSummary.ResumeLayout(false);
            tabPageBudgetDetailed.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageAccounting.ResumeLayout(false);
            tabControlAccounting.ResumeLayout(false);
            tabPageJournalEntryVoucher.ResumeLayout(false);
            tabPageJournalEntryVoucher.PerformLayout();
            tabPageJournals.ResumeLayout(false);
            tabPageJournals.PerformLayout();
            tabPageLedgers.ResumeLayout(false);
            tabControlLedgers.ResumeLayout(false);
            tabPageGeneralLedger.ResumeLayout(false);
            tabPageSubsidiaryLedger.ResumeLayout(false);
            tabPageSummarySL.ResumeLayout(false);
            tabPageTransactionLog.ResumeLayout(false);
            tabPageTrialBalance.ResumeLayout(false);
            tabControlTrialBalance.ResumeLayout(false);
            tabPagePreTrial.ResumeLayout(false);
            tabPagePostTrial.ResumeLayout(false);
            tabPageFinancialStatements.ResumeLayout(false);
            tabControlFinancialStatements.ResumeLayout(false);
            tabPageSFPosition.ResumeLayout(false);
            tabPageSFPerformance.ResumeLayout(false);
            tabPageSCNAE.ResumeLayout(false);
            tabPageSCF.ResumeLayout(false);
            tabPageTreasury.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ToolStrip2.ResumeLayout(false);
            ToolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem amortiaztionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signatoriesToolStripMenuItem;
        private Views.Dashboard.TreasuryDashboard.ucRCDSummary ucrcdSummary1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem discountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penaltiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem taxRatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTaxPayers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem databaseSynchronizationToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageBudget;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonBudgetAppropriations;
        private System.Windows.Forms.ToolStripButton toolStripButtonAllotmentRelease;
        private System.Windows.Forms.ToolStripButton toolStripButtonObligation;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem sAAOBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAAOBBToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip ToolStrip2;
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
        private System.Windows.Forms.ToolStripMenuItem businessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barangaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonBpl;
        private System.Windows.Forms.ToolStripButton RptToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem businessAddOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releasedAndUnreleaseChecksToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem releasedChequesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unreleasedChequesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankAccountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherPaymentRatesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlBudget;
        private System.Windows.Forms.TabPage tabPageBudgetSummary;
        private System.Windows.Forms.TabPage tabPageBudgetDetailed;
        private System.Windows.Forms.TabControl tabControlAccounting;
        private System.Windows.Forms.TabPage tabPageJournalEntryVoucher;
        private System.Windows.Forms.TabPage tabPageJournals;
        private System.Windows.Forms.TabPage tabPageLedgers;
        private System.Windows.Forms.TabPage tabPageTrialBalance;
        private System.Windows.Forms.TabPage tabPageFinancialStatements;
        private System.Windows.Forms.TabControl tabControlLedgers;
        private System.Windows.Forms.TabPage tabPageGeneralLedger;
        private System.Windows.Forms.TabPage tabPageSubsidiaryLedger;
        private System.Windows.Forms.TabPage tabPageSummarySL;
        private System.Windows.Forms.TabPage tabPageTransactionLog;
        private System.Windows.Forms.TabControl tabControlTrialBalance;
        private System.Windows.Forms.TabPage tabPagePreTrial;
        private System.Windows.Forms.TabPage tabPagePostTrial;
        private System.Windows.Forms.TabControl tabControlFinancialStatements;
        private System.Windows.Forms.TabPage tabPageSFPosition;
        private System.Windows.Forms.TabPage tabPageSFPerformance;
        private System.Windows.Forms.TabPage tabPageSCNAE;
        private System.Windows.Forms.TabPage tabPageSCF;
        private Views.Dashboard.ucJEVDashboard ucjevDashboard1;
        private Views.Dashboard.AccountingDashboard.ucJournalsDashboard ucJournalsDashboard1;
        private Views.Reports.Ledgers.ucGeneralLedger ucGeneralLedger1;
        private Views.Reports.Ledgers.ucSubsidiaryLedger ucSubsidiaryLedger1;
        private Views.Reports.Ledgers.ucSummarySubsidiaryLedger ucSummarySubsidiaryLedger1;
        private Views.Reports.Ledgers.ucTransactionLog ucTransactionLog1;
        private Views.Reports.TrialBalance.ucPreClosingTrialBalance ucPreClosingTrialBalance1;
        private Views.Reports.TrialBalance.ucPostClosingTrialBalance ucPostClosingTrialBalance1;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
        private Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsEquity ucStatementOfChangesInNetAssetsEquity1;
        private Views.Reports.Financial_Statements.ucStatementOfCashFlows ucStatementOfCashFlows1;
        private System.Windows.Forms.TabPage tabPageSCBAA;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary ucBudgetSummary1;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed ucBudgetDetailed1;
    }
}