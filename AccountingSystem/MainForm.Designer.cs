
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
            this.menuJournals = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChartOfAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAllotmentClasses = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunctionProgramProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCollectingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisbursingOfficer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.amortiaztionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprintRCI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprintPC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprintGC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBankCashBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReceiptsConsolidated = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDailyCash = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBudgetAppropriations = new System.Windows.Forms.ToolStripButton();
            this.btnAllotmentRelease = new System.Windows.Forms.ToolStripButton();
            this.btnObligationRequest = new System.Windows.Forms.ToolStripButton();
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
            this.ucStatementOfChangesInNetAssetsquity1 = new AccountingSystem.Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsquity();
            this.tabPageSCF = new System.Windows.Forms.TabPage();
            this.tabPageSCBAA = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radSFPosition = new System.Windows.Forms.RadioButton();
            this.radSFPerformance = new System.Windows.Forms.RadioButton();
            this.radSCNAE = new System.Windows.Forms.RadioButton();
            this.radSCF = new System.Windows.Forms.RadioButton();
            this.radSCBAA = new System.Windows.Forms.RadioButton();
            this.tabPageTreasury = new System.Windows.Forms.TabPage();
            this.ucTreasuryDashboard1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabPageBudget.SuspendLayout();
            this.tabControlBudget.SuspendLayout();
            this.tabPageBudgetSummary.SuspendLayout();
            this.tabPageBudgetDetailed.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPageAccounting.SuspendLayout();
            this.tabControlAccounting.SuspendLayout();
            this.tabPageJournalEntryVoucher.SuspendLayout();
            this.tabPageJournals.SuspendLayout();
            this.tabPageLedgers.SuspendLayout();
            this.tabControlLedgers.SuspendLayout();
            this.tabPageGeneralLedger.SuspendLayout();
            this.tabPageSubsidiaryLedger.SuspendLayout();
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
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPageTreasury.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuManage,
            this.menuReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1199, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 19);
            this.menuFile.Text = "&File";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(157, 22);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(157, 22);
            this.menuExitApp.Text = "Exit Application";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // menuManage
            // 
            this.menuManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsers,
            this.menuJournals,
            this.menuChartOfAccounts,
            this.menuAllotmentClasses,
            this.menuFunds,
            this.menuFunctionProgramProject,
            this.menuCollectingOfficer,
            this.menuDisbursingOfficer,
            this.menuBanks,
            this.menuAccForm,
            this.menuReceipts,
            this.amortiaztionToolStripMenuItem});
            this.menuManage.Name = "menuManage";
            this.menuManage.Size = new System.Drawing.Size(62, 19);
            this.menuManage.Text = "Manage";
            // 
            // menuUsers
            // 
            this.menuUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserList,
            this.menuRoles});
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(214, 22);
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
            // menuJournals
            // 
            this.menuJournals.Name = "menuJournals";
            this.menuJournals.Size = new System.Drawing.Size(214, 22);
            this.menuJournals.Text = "Journals";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
            // 
            // menuChartOfAccounts
            // 
            this.menuChartOfAccounts.Name = "menuChartOfAccounts";
            this.menuChartOfAccounts.Size = new System.Drawing.Size(214, 22);
            this.menuChartOfAccounts.Text = "Chart of Accounts";
            this.menuChartOfAccounts.Click += new System.EventHandler(this.menuChartOfAccounts_Click);
            // 
            // menuAllotmentClasses
            // 
            this.menuAllotmentClasses.Name = "menuAllotmentClasses";
            this.menuAllotmentClasses.Size = new System.Drawing.Size(214, 22);
            this.menuAllotmentClasses.Text = "Allotment Classes";
            this.menuAllotmentClasses.Click += new System.EventHandler(this.menuAllotmentClasses_Click);
            // 
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(214, 22);
            this.menuFunds.Text = "Funds";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(214, 22);
            this.menuFunctionProgramProject.Text = "Function/Program/Project";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(214, 22);
            this.menuCollectingOfficer.Text = "Collecting Officers";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuDisbursingOfficer
            // 
            this.menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            this.menuDisbursingOfficer.Size = new System.Drawing.Size(214, 22);
            this.menuDisbursingOfficer.Text = "Disbursing Officers";
            this.menuDisbursingOfficer.Click += new System.EventHandler(this.MenuDisbursingOffice_Click);
            // 
            // menuBanks
            // 
            this.menuBanks.Name = "menuBanks";
            this.menuBanks.Size = new System.Drawing.Size(214, 22);
            this.menuBanks.Text = "Banks";
            this.menuBanks.Click += new System.EventHandler(this.menuBanks_Click);
            // 
            // menuAccForm
            // 
            this.menuAccForm.Name = "menuAccForm";
            this.menuAccForm.Size = new System.Drawing.Size(214, 22);
            this.menuAccForm.Text = "Accountable Form";
            this.menuAccForm.Click += new System.EventHandler(this.menuAccForm_Click);
            // 
            // menuReceipts
            // 
            this.menuReceipts.Name = "menuReceipts";
            this.menuReceipts.Size = new System.Drawing.Size(214, 22);
            this.menuReceipts.Text = "Receipts";
            this.menuReceipts.Click += new System.EventHandler(this.menureceipts_Click);
            // 
            // amortiaztionToolStripMenuItem
            // 
            this.amortiaztionToolStripMenuItem.Name = "amortiaztionToolStripMenuItem";
            this.amortiaztionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.amortiaztionToolStripMenuItem.Text = "Amortization";
            this.amortiaztionToolStripMenuItem.Click += new System.EventHandler(this.amortiaztionToolStripMenuItem_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSAAOB,
            this.menuSAAOBB,
            this.menuprintRCI,
            this.menuprintPC,
            this.menuprintGC,
            this.menuBankCashBook,
            this.menuReceiptsConsolidated,
            this.menuDailyCash});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(59, 19);
            this.menuReports.Text = "Reports";
            // 
            // menuSAAOB
            // 
            this.menuSAAOB.Name = "menuSAAOB";
            this.menuSAAOB.Size = new System.Drawing.Size(233, 22);
            this.menuSAAOB.Text = "SAAOB";
            this.menuSAAOB.Click += new System.EventHandler(this.MenuSAAOB_Click);
            // 
            // menuSAAOBB
            // 
            this.menuSAAOBB.Name = "menuSAAOBB";
            this.menuSAAOBB.Size = new System.Drawing.Size(233, 22);
            this.menuSAAOBB.Text = "SAAOBB";
            this.menuSAAOBB.Click += new System.EventHandler(this.MenuSAAOBB_Click);
            // 
            // menuprintRCI
            // 
            this.menuprintRCI.Name = "menuprintRCI";
            this.menuprintRCI.Size = new System.Drawing.Size(233, 22);
            this.menuprintRCI.Text = "RCI";
            this.menuprintRCI.Click += new System.EventHandler(this.menuprintRCI_Click);
            // 
            // menuprintPC
            // 
            this.menuprintPC.Name = "menuprintPC";
            this.menuprintPC.Size = new System.Drawing.Size(233, 22);
            this.menuprintPC.Text = "RCD";
            this.menuprintPC.Click += new System.EventHandler(this.menuprintPC_Click);
            // 
            // menuprintGC
            // 
            this.menuprintGC.Name = "menuprintGC";
            this.menuprintGC.Size = new System.Drawing.Size(233, 22);
            this.menuprintGC.Text = "Reports of General Collections";
            this.menuprintGC.Click += new System.EventHandler(this.menuprintGC_Click);
            // 
            // menuBankCashBook
            // 
            this.menuBankCashBook.Name = "menuBankCashBook";
            this.menuBankCashBook.Size = new System.Drawing.Size(233, 22);
            this.menuBankCashBook.Text = "Bank Cashbook";
            this.menuBankCashBook.Click += new System.EventHandler(this.menucashbook_Click);
            // 
            // menuReceiptsConsolidated
            // 
            this.menuReceiptsConsolidated.Name = "menuReceiptsConsolidated";
            this.menuReceiptsConsolidated.Size = new System.Drawing.Size(233, 22);
            this.menuReceiptsConsolidated.Text = "Consolidated Receipts";
            this.menuReceiptsConsolidated.Click += new System.EventHandler(this.menuReceiptsConsolidated_Click);
            // 
            // menuDailyCash
            // 
            this.menuDailyCash.Name = "menuDailyCash";
            this.menuDailyCash.Size = new System.Drawing.Size(233, 22);
            this.menuDailyCash.Text = "Daily Cash Position Report";
            this.menuDailyCash.Click += new System.EventHandler(this.menuDailyCash_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserFullName,
            this.lblUserRole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1199, 24);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.radBtnBudget);
            this.flowLayoutPanel1.Controls.Add(this.radBtnAccounting);
            this.flowLayoutPanel1.Controls.Add(this.radBtnTreasury);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1199, 31);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radBtnBudget
            // 
            this.radBtnBudget.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnBudget.AutoSize = true;
            this.radBtnBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnBudget.Location = new System.Drawing.Point(3, 3);
            this.radBtnBudget.Name = "radBtnBudget";
            this.radBtnBudget.Size = new System.Drawing.Size(55, 25);
            this.radBtnBudget.TabIndex = 0;
            this.radBtnBudget.Text = "Budget";
            this.radBtnBudget.UseVisualStyleBackColor = true;
            this.radBtnBudget.Visible = false;
            this.radBtnBudget.CheckedChanged += new System.EventHandler(this.radBtnBudget_CheckedChanged);
            // 
            // radBtnAccounting
            // 
            this.radBtnAccounting.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnAccounting.AutoSize = true;
            this.radBtnAccounting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnAccounting.Location = new System.Drawing.Point(64, 3);
            this.radBtnAccounting.Name = "radBtnAccounting";
            this.radBtnAccounting.Size = new System.Drawing.Size(79, 25);
            this.radBtnAccounting.TabIndex = 1;
            this.radBtnAccounting.Text = "Accounting";
            this.radBtnAccounting.UseVisualStyleBackColor = true;
            this.radBtnAccounting.Visible = false;
            this.radBtnAccounting.CheckedChanged += new System.EventHandler(this.radBtnAccounting_CheckedChanged);
            // 
            // radBtnTreasury
            // 
            this.radBtnTreasury.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnTreasury.AutoSize = true;
            this.radBtnTreasury.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnTreasury.Location = new System.Drawing.Point(149, 3);
            this.radBtnTreasury.Name = "radBtnTreasury";
            this.radBtnTreasury.Size = new System.Drawing.Size(60, 25);
            this.radBtnTreasury.TabIndex = 2;
            this.radBtnTreasury.Text = "Treasury";
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
            this.tabControlDashboard.Location = new System.Drawing.Point(0, 56);
            this.tabControlDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlDashboard.Name = "tabControlDashboard";
            this.tabControlDashboard.Padding = new System.Drawing.Point(0, 0);
            this.tabControlDashboard.SelectedIndex = 0;
            this.tabControlDashboard.Size = new System.Drawing.Size(1199, 482);
            this.tabControlDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDashboard.TabIndex = 9;
            // 
            // tabPageBudget
            // 
            this.tabPageBudget.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudget.Controls.Add(this.tabControlBudget);
            this.tabPageBudget.Controls.Add(this.chkbxDetailed);
            this.tabPageBudget.Controls.Add(this.toolStrip1);
            this.tabPageBudget.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageBudget.Name = "tabPageBudget";
            this.tabPageBudget.Size = new System.Drawing.Size(1191, 473);
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
            this.tabControlBudget.Location = new System.Drawing.Point(0, 64);
            this.tabControlBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlBudget.Name = "tabControlBudget";
            this.tabControlBudget.SelectedIndex = 0;
            this.tabControlBudget.Size = new System.Drawing.Size(1191, 408);
            this.tabControlBudget.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlBudget.TabIndex = 8;
            // 
            // tabPageBudgetSummary
            // 
            this.tabPageBudgetSummary.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudgetSummary.Controls.Add(this.ucBudgetSummary1);
            this.tabPageBudgetSummary.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudgetSummary.Name = "tabPageBudgetSummary";
            this.tabPageBudgetSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetSummary.Size = new System.Drawing.Size(1183, 399);
            this.tabPageBudgetSummary.TabIndex = 0;
            this.tabPageBudgetSummary.Text = "Budget Summary";
            // 
            // ucBudgetSummary1
            // 
            this.ucBudgetSummary1.AutoScroll = true;
            this.ucBudgetSummary1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetSummary1.Location = new System.Drawing.Point(3, 3);
            this.ucBudgetSummary1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBudgetSummary1.Name = "ucBudgetSummary1";
            this.ucBudgetSummary1.Size = new System.Drawing.Size(1177, 393);
            this.ucBudgetSummary1.TabIndex = 0;
            // 
            // tabPageBudgetDetailed
            // 
            this.tabPageBudgetDetailed.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageBudgetDetailed.Controls.Add(this.ucBudgetDetailed1);
            this.tabPageBudgetDetailed.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudgetDetailed.Name = "tabPageBudgetDetailed";
            this.tabPageBudgetDetailed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetDetailed.Size = new System.Drawing.Size(1183, 399);
            this.tabPageBudgetDetailed.TabIndex = 1;
            this.tabPageBudgetDetailed.Text = "Budget Detailed";
            // 
            // ucBudgetDetailed1
            // 
            this.ucBudgetDetailed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetDetailed1.Location = new System.Drawing.Point(3, 3);
            this.ucBudgetDetailed1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucBudgetDetailed1.Name = "ucBudgetDetailed1";
            this.ucBudgetDetailed1.Size = new System.Drawing.Size(1177, 393);
            this.ucBudgetDetailed1.TabIndex = 0;
            // 
            // chkbxDetailed
            // 
            this.chkbxDetailed.AutoSize = true;
            this.chkbxDetailed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkbxDetailed.Location = new System.Drawing.Point(4, 45);
            this.chkbxDetailed.Margin = new System.Windows.Forms.Padding(0);
            this.chkbxDetailed.Name = "chkbxDetailed";
            this.chkbxDetailed.Size = new System.Drawing.Size(69, 19);
            this.chkbxDetailed.TabIndex = 7;
            this.chkbxDetailed.Text = "Detailed";
            this.chkbxDetailed.UseVisualStyleBackColor = true;
            this.chkbxDetailed.CheckedChanged += new System.EventHandler(this.chkbxDetailed_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBudgetAppropriations,
            this.btnAllotmentRelease,
            this.btnObligationRequest});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1191, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBudgetAppropriations
            // 
            this.btnBudgetAppropriations.Image = global::AccountingSystem.Properties.Resources.budget_approprations_24px;
            this.btnBudgetAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBudgetAppropriations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBudgetAppropriations.Name = "btnBudgetAppropriations";
            this.btnBudgetAppropriations.Size = new System.Drawing.Size(155, 28);
            this.btnBudgetAppropriations.Text = "Budget Appropriations";
            this.btnBudgetAppropriations.Click += new System.EventHandler(this.btnBudgetAppropriations_Click);
            // 
            // btnAllotmentRelease
            // 
            this.btnAllotmentRelease.Image = global::AccountingSystem.Properties.Resources.allotment_release_24px;
            this.btnAllotmentRelease.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAllotmentRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAllotmentRelease.Name = "btnAllotmentRelease";
            this.btnAllotmentRelease.Size = new System.Drawing.Size(130, 28);
            this.btnAllotmentRelease.Text = "Allotment Release";
            this.btnAllotmentRelease.Click += new System.EventHandler(this.btnAllotmentRelease_Click);
            // 
            // btnObligationRequest
            // 
            this.btnObligationRequest.Image = global::AccountingSystem.Properties.Resources.obligation_request_24px;
            this.btnObligationRequest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnObligationRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnObligationRequest.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnObligationRequest.Name = "btnObligationRequest";
            this.btnObligationRequest.Size = new System.Drawing.Size(80, 28);
            this.btnObligationRequest.Text = "Obligate";
            this.btnObligationRequest.Click += new System.EventHandler(this.btnObligationRequest_Click);
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.tabControlAccounting);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 5);
            this.tabPageAccounting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Size = new System.Drawing.Size(1191, 473);
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
            this.tabControlAccounting.Location = new System.Drawing.Point(0, 0);
            this.tabControlAccounting.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAccounting.Name = "tabControlAccounting";
            this.tabControlAccounting.SelectedIndex = 0;
            this.tabControlAccounting.Size = new System.Drawing.Size(1191, 473);
            this.tabControlAccounting.TabIndex = 0;
            // 
            // tabPageJournalEntryVoucher
            // 
            this.tabPageJournalEntryVoucher.Controls.Add(this.ucjevDashboard1);
            this.tabPageJournalEntryVoucher.Location = new System.Drawing.Point(4, 24);
            this.tabPageJournalEntryVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageJournalEntryVoucher.Name = "tabPageJournalEntryVoucher";
            this.tabPageJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJournalEntryVoucher.Size = new System.Drawing.Size(1183, 445);
            this.tabPageJournalEntryVoucher.TabIndex = 0;
            this.tabPageJournalEntryVoucher.Text = "Journal Entry Voucher";
            this.tabPageJournalEntryVoucher.UseVisualStyleBackColor = true;
            // 
            // ucjevDashboard1
            // 
            this.ucjevDashboard1.AutoSize = true;
            this.ucjevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucjevDashboard1.Location = new System.Drawing.Point(3, 3);
            this.ucjevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucjevDashboard1.MinimumSize = new System.Drawing.Size(782, 160);
            this.ucjevDashboard1.Name = "ucjevDashboard1";
            this.ucjevDashboard1.Size = new System.Drawing.Size(1177, 160);
            this.ucjevDashboard1.TabIndex = 0;
            // 
            // tabPageJournals
            // 
            this.tabPageJournals.Controls.Add(this.ucJournalsDashboard1);
            this.tabPageJournals.Location = new System.Drawing.Point(4, 24);
            this.tabPageJournals.Name = "tabPageJournals";
            this.tabPageJournals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJournals.Size = new System.Drawing.Size(1183, 445);
            this.tabPageJournals.TabIndex = 1;
            this.tabPageJournals.Text = "Journals";
            this.tabPageJournals.UseVisualStyleBackColor = true;
            // 
            // ucJournalsDashboard1
            // 
            this.ucJournalsDashboard1.AutoSize = true;
            this.ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucJournalsDashboard1.Location = new System.Drawing.Point(3, 3);
            this.ucJournalsDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucJournalsDashboard1.MinimumSize = new System.Drawing.Size(941, 160);
            this.ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            this.ucJournalsDashboard1.Size = new System.Drawing.Size(1177, 160);
            this.ucJournalsDashboard1.TabIndex = 0;
            // 
            // tabPageLedgers
            // 
            this.tabPageLedgers.Controls.Add(this.tabControlLedgers);
            this.tabPageLedgers.Controls.Add(this.flowLayoutPanel2);
            this.tabPageLedgers.Location = new System.Drawing.Point(4, 24);
            this.tabPageLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageLedgers.Name = "tabPageLedgers";
            this.tabPageLedgers.Size = new System.Drawing.Size(1183, 445);
            this.tabPageLedgers.TabIndex = 2;
            this.tabPageLedgers.Text = "Ledgers";
            this.tabPageLedgers.UseVisualStyleBackColor = true;
            // 
            // tabControlLedgers
            // 
            this.tabControlLedgers.Controls.Add(this.tabPageGeneralLedger);
            this.tabControlLedgers.Controls.Add(this.tabPageSubsidiaryLedger);
            this.tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLedgers.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlLedgers.Location = new System.Drawing.Point(0, 31);
            this.tabControlLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlLedgers.Multiline = true;
            this.tabControlLedgers.Name = "tabControlLedgers";
            this.tabControlLedgers.Padding = new System.Drawing.Point(0, 0);
            this.tabControlLedgers.SelectedIndex = 0;
            this.tabControlLedgers.Size = new System.Drawing.Size(1183, 414);
            this.tabControlLedgers.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlLedgers.TabIndex = 0;
            // 
            // tabPageGeneralLedger
            // 
            this.tabPageGeneralLedger.Controls.Add(this.ucGeneralLedger1);
            this.tabPageGeneralLedger.Location = new System.Drawing.Point(4, 5);
            this.tabPageGeneralLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            this.tabPageGeneralLedger.Size = new System.Drawing.Size(1175, 405);
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
            this.ucGeneralLedger1.Size = new System.Drawing.Size(1175, 405);
            this.ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageSubsidiaryLedger
            // 
            this.tabPageSubsidiaryLedger.Controls.Add(this.ucSubsidiaryLedger1);
            this.tabPageSubsidiaryLedger.Location = new System.Drawing.Point(4, 5);
            this.tabPageSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSubsidiaryLedger.Name = "tabPageSubsidiaryLedger";
            this.tabPageSubsidiaryLedger.Size = new System.Drawing.Size(1175, 405);
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
            this.ucSubsidiaryLedger1.Size = new System.Drawing.Size(1175, 405);
            this.ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Controls.Add(this.radioGeneralLedger);
            this.flowLayoutPanel2.Controls.Add(this.radioSubsidiaryLedger);
            this.flowLayoutPanel2.Controls.Add(this.radioTransactionLog);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1183, 31);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // radioGeneralLedger
            // 
            this.radioGeneralLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioGeneralLedger.Checked = true;
            this.radioGeneralLedger.Enabled = false;
            this.radioGeneralLedger.Location = new System.Drawing.Point(3, 3);
            this.radioGeneralLedger.Name = "radioGeneralLedger";
            this.radioGeneralLedger.Size = new System.Drawing.Size(122, 25);
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
            this.radioSubsidiaryLedger.Location = new System.Drawing.Point(131, 3);
            this.radioSubsidiaryLedger.Name = "radioSubsidiaryLedger";
            this.radioSubsidiaryLedger.Size = new System.Drawing.Size(122, 25);
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
            this.radioTransactionLog.Location = new System.Drawing.Point(259, 3);
            this.radioTransactionLog.Name = "radioTransactionLog";
            this.radioTransactionLog.Size = new System.Drawing.Size(122, 25);
            this.radioTransactionLog.TabIndex = 7;
            this.radioTransactionLog.Tag = "3";
            this.radioTransactionLog.Text = "Transaction Log";
            this.radioTransactionLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioTransactionLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioTransactionLog.UseVisualStyleBackColor = true;
            // 
            // tabPageTrialBalance
            // 
            this.tabPageTrialBalance.Controls.Add(this.tabControlTrialBalance);
            this.tabPageTrialBalance.Controls.Add(this.flowLayoutPanel4);
            this.tabPageTrialBalance.Location = new System.Drawing.Point(4, 24);
            this.tabPageTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTrialBalance.Name = "tabPageTrialBalance";
            this.tabPageTrialBalance.Size = new System.Drawing.Size(1183, 445);
            this.tabPageTrialBalance.TabIndex = 3;
            this.tabPageTrialBalance.Text = "Trial Balance";
            this.tabPageTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabControlTrialBalance
            // 
            this.tabControlTrialBalance.Controls.Add(this.tabPagePreTrial);
            this.tabControlTrialBalance.Controls.Add(this.tabPagePostTrial);
            this.tabControlTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTrialBalance.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlTrialBalance.Location = new System.Drawing.Point(0, 31);
            this.tabControlTrialBalance.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlTrialBalance.Name = "tabControlTrialBalance";
            this.tabControlTrialBalance.Padding = new System.Drawing.Point(0, 0);
            this.tabControlTrialBalance.SelectedIndex = 0;
            this.tabControlTrialBalance.Size = new System.Drawing.Size(1183, 414);
            this.tabControlTrialBalance.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlTrialBalance.TabIndex = 5;
            // 
            // tabPagePreTrial
            // 
            this.tabPagePreTrial.Controls.Add(this.ucPreClosingTrialBalance1);
            this.tabPagePreTrial.Location = new System.Drawing.Point(4, 5);
            this.tabPagePreTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePreTrial.Name = "tabPagePreTrial";
            this.tabPagePreTrial.Size = new System.Drawing.Size(1175, 405);
            this.tabPagePreTrial.TabIndex = 0;
            this.tabPagePreTrial.Text = "tabPage1";
            this.tabPagePreTrial.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            this.ucPreClosingTrialBalance1.BackColor = System.Drawing.Color.Transparent;
            this.ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPreClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            this.ucPreClosingTrialBalance1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            this.ucPreClosingTrialBalance1.Size = new System.Drawing.Size(1175, 405);
            this.ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePostTrial
            // 
            this.tabPagePostTrial.Controls.Add(this.ucPostClosingTrialBalance1);
            this.tabPagePostTrial.Location = new System.Drawing.Point(4, 5);
            this.tabPagePostTrial.Margin = new System.Windows.Forms.Padding(0);
            this.tabPagePostTrial.Name = "tabPagePostTrial";
            this.tabPagePostTrial.Size = new System.Drawing.Size(1175, 405);
            this.tabPagePostTrial.TabIndex = 1;
            this.tabPagePostTrial.Text = "tabPage2";
            this.tabPagePostTrial.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            this.ucPostClosingTrialBalance1.BackColor = System.Drawing.Color.Transparent;
            this.ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPostClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            this.ucPostClosingTrialBalance1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            this.ucPostClosingTrialBalance1.Size = new System.Drawing.Size(1175, 405);
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
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1183, 31);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // radioPreTB
            // 
            this.radioPreTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPreTB.Checked = true;
            this.radioPreTB.Enabled = false;
            this.radioPreTB.Location = new System.Drawing.Point(3, 3);
            this.radioPreTB.Name = "radioPreTB";
            this.radioPreTB.Size = new System.Drawing.Size(124, 25);
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
            this.radioPostTB.Location = new System.Drawing.Point(133, 3);
            this.radioPostTB.Name = "radioPostTB";
            this.radioPostTB.Size = new System.Drawing.Size(124, 25);
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
            this.tabPageFinancialStatements.Location = new System.Drawing.Point(4, 24);
            this.tabPageFinancialStatements.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageFinancialStatements.Name = "tabPageFinancialStatements";
            this.tabPageFinancialStatements.Size = new System.Drawing.Size(1183, 445);
            this.tabPageFinancialStatements.TabIndex = 4;
            this.tabPageFinancialStatements.Text = "Financial Statements";
            this.tabPageFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabControlFinancialStatements
            // 
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
            this.tabControlFinancialStatements.Size = new System.Drawing.Size(1183, 414);
            this.tabControlFinancialStatements.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlFinancialStatements.TabIndex = 4;
            // 
            // tabPageSFPosition
            // 
            this.tabPageSFPosition.Controls.Add(this.ucStatementOfFinancialPosition1);
            this.tabPageSFPosition.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPosition.Name = "tabPageSFPosition";
            this.tabPageSFPosition.Size = new System.Drawing.Size(1175, 405);
            this.tabPageSFPosition.TabIndex = 0;
            this.tabPageSFPosition.Text = "tabSFPosition";
            this.tabPageSFPosition.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPosition1
            // 
            this.ucStatementOfFinancialPosition1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPosition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPosition1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPosition1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucStatementOfFinancialPosition1.Name = "ucStatementOfFinancialPosition1";
            this.ucStatementOfFinancialPosition1.Size = new System.Drawing.Size(1175, 405);
            this.ucStatementOfFinancialPosition1.TabIndex = 0;
            // 
            // tabPageSFPerformance
            // 
            this.tabPageSFPerformance.Controls.Add(this.ucStatementOfFinancialPerformance1);
            this.tabPageSFPerformance.Location = new System.Drawing.Point(4, 5);
            this.tabPageSFPerformance.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSFPerformance.Name = "tabPageSFPerformance";
            this.tabPageSFPerformance.Size = new System.Drawing.Size(1175, 405);
            this.tabPageSFPerformance.TabIndex = 1;
            this.tabPageSFPerformance.Text = "tabSFPerformance";
            this.tabPageSFPerformance.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfFinancialPerformance1
            // 
            this.ucStatementOfFinancialPerformance1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfFinancialPerformance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfFinancialPerformance1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfFinancialPerformance1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucStatementOfFinancialPerformance1.Name = "ucStatementOfFinancialPerformance1";
            this.ucStatementOfFinancialPerformance1.Size = new System.Drawing.Size(1175, 405);
            this.ucStatementOfFinancialPerformance1.TabIndex = 0;
            // 
            // tabPageSCNAE
            // 
            this.tabPageSCNAE.Controls.Add(this.ucStatementOfChangesInNetAssetsquity1);
            this.tabPageSCNAE.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCNAE.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCNAE.Name = "tabPageSCNAE";
            this.tabPageSCNAE.Size = new System.Drawing.Size(1175, 405);
            this.tabPageSCNAE.TabIndex = 2;
            this.tabPageSCNAE.Text = "tabSCNAE";
            this.tabPageSCNAE.UseVisualStyleBackColor = true;
            // 
            // ucStatementOfChangesInNetAssetsquity1
            // 
            this.ucStatementOfChangesInNetAssetsquity1.BackColor = System.Drawing.Color.Transparent;
            this.ucStatementOfChangesInNetAssetsquity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatementOfChangesInNetAssetsquity1.Location = new System.Drawing.Point(0, 0);
            this.ucStatementOfChangesInNetAssetsquity1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucStatementOfChangesInNetAssetsquity1.Name = "ucStatementOfChangesInNetAssetsquity1";
            this.ucStatementOfChangesInNetAssetsquity1.Size = new System.Drawing.Size(1175, 405);
            this.ucStatementOfChangesInNetAssetsquity1.TabIndex = 0;
            // 
            // tabPageSCF
            // 
            this.tabPageSCF.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCF.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCF.Name = "tabPageSCF";
            this.tabPageSCF.Size = new System.Drawing.Size(1175, 405);
            this.tabPageSCF.TabIndex = 3;
            this.tabPageSCF.Text = "tabSCF";
            this.tabPageSCF.UseVisualStyleBackColor = true;
            // 
            // tabPageSCBAA
            // 
            this.tabPageSCBAA.Location = new System.Drawing.Point(4, 5);
            this.tabPageSCBAA.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSCBAA.Name = "tabPageSCBAA";
            this.tabPageSCBAA.Size = new System.Drawing.Size(1175, 405);
            this.tabPageSCBAA.TabIndex = 4;
            this.tabPageSCBAA.Text = "tabSCBAA";
            this.tabPageSCBAA.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel3.Controls.Add(this.radSFPosition);
            this.flowLayoutPanel3.Controls.Add(this.radSFPerformance);
            this.flowLayoutPanel3.Controls.Add(this.radSCNAE);
            this.flowLayoutPanel3.Controls.Add(this.radSCF);
            this.flowLayoutPanel3.Controls.Add(this.radSCBAA);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1183, 31);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // radSFPosition
            // 
            this.radSFPosition.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSFPosition.AutoSize = true;
            this.radSFPosition.Enabled = false;
            this.radSFPosition.Location = new System.Drawing.Point(3, 3);
            this.radSFPosition.Name = "radSFPosition";
            this.radSFPosition.Size = new System.Drawing.Size(181, 25);
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
            this.radSFPerformance.Location = new System.Drawing.Point(190, 3);
            this.radSFPerformance.Name = "radSFPerformance";
            this.radSFPerformance.Size = new System.Drawing.Size(206, 25);
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
            this.radSCNAE.Location = new System.Drawing.Point(402, 3);
            this.radSCNAE.Name = "radSCNAE";
            this.radSCNAE.Size = new System.Drawing.Size(243, 25);
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
            this.radSCF.Location = new System.Drawing.Point(651, 3);
            this.radSCF.Name = "radSCF";
            this.radSCF.Size = new System.Drawing.Size(147, 25);
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
            this.radSCBAA.Location = new System.Drawing.Point(804, 3);
            this.radSCBAA.Name = "radSCBAA";
            this.radSCBAA.Size = new System.Drawing.Size(320, 25);
            this.radSCBAA.TabIndex = 1;
            this.radSCBAA.Text = "Statement of Comparison of Budget and Actual Amounts";
            this.radSCBAA.UseVisualStyleBackColor = true;
            this.radSCBAA.CheckedChanged += new System.EventHandler(this.radSCBAA_CheckedChanged);
            // 
            // tabPageTreasury
            // 
            this.tabPageTreasury.Controls.Add(this.ucTreasuryDashboard1);
            this.tabPageTreasury.Location = new System.Drawing.Point(4, 5);
            this.tabPageTreasury.Name = "tabPageTreasury";
            this.tabPageTreasury.Size = new System.Drawing.Size(1191, 473);
            this.tabPageTreasury.TabIndex = 2;
            this.tabPageTreasury.Text = "Treasury";
            this.tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // ucTreasuryDashboard1
            // 
            this.ucTreasuryDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreasuryDashboard1.Location = new System.Drawing.Point(0, 0);
            this.ucTreasuryDashboard1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucTreasuryDashboard1.Name = "ucTreasuryDashboard1";
            this.ucTreasuryDashboard1.Size = new System.Drawing.Size(1191, 473);
            this.ucTreasuryDashboard1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1199, 562);
            this.Controls.Add(this.tabControlDashboard);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1196, 560);
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
            this.flowLayoutPanel1.PerformLayout();
            this.tabControlDashboard.ResumeLayout(false);
            this.tabPageBudget.ResumeLayout(false);
            this.tabPageBudget.PerformLayout();
            this.tabControlBudget.ResumeLayout(false);
            this.tabPageBudgetSummary.ResumeLayout(false);
            this.tabPageBudgetDetailed.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageAccounting.ResumeLayout(false);
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
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tabPageTreasury.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuManage;
        private System.Windows.Forms.ToolStripMenuItem menuJournals;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuAllotmentClasses;
        private System.Windows.Forms.ToolStripMenuItem menuFunds;
        private System.Windows.Forms.ToolStripMenuItem menuChartOfAccounts;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionProgramProject;
        private System.Windows.Forms.ToolStripMenuItem menuCollectingOfficer;
        private System.Windows.Forms.ToolStripMenuItem menuDisbursingOfficer;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserFullName;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripMenuItem menuBanks;
        private System.Windows.Forms.ToolStripMenuItem menuprintRCI;
        private System.Windows.Forms.ToolStripMenuItem menuAccForm;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripMenuItem menuprintPC;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOBB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.RadioButton radBtnBudget;
        private System.Windows.Forms.RadioButton radBtnAccounting;
        private System.Windows.Forms.ToolStripMenuItem menuprintGC;
        private System.Windows.Forms.ToolStripMenuItem menuReceipts;
        private System.Windows.Forms.ToolStripMenuItem menuBankCashBook;
        private System.Windows.Forms.TabControl tabControlDashboard;
        internal System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.ToolStripMenuItem menuReceiptsConsolidated;
        private System.Windows.Forms.ToolStripMenuItem menuDailyCash;
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
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPosition ucStatementOfFinancialPosition1;
        private System.Windows.Forms.TabPage tabPageSFPerformance;
        private Views.Reports.Financial_Statements.ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance1;
        private System.Windows.Forms.TabPage tabPageSCNAE;
        private Views.Reports.Financial_Statements.ucStatementOfChangesInNetAssetsquity ucStatementOfChangesInNetAssetsquity1;
        private System.Windows.Forms.TabPage tabPageSCF;
        private System.Windows.Forms.TabPage tabPageSCBAA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton radioPostTB;
        private System.Windows.Forms.RadioButton radioPreTB;
        private System.Windows.Forms.ToolStripMenuItem amortiaztionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnBudgetAppropriations;
        internal System.Windows.Forms.ToolStripButton btnAllotmentRelease;
        internal System.Windows.Forms.ToolStripButton btnObligationRequest;
        private System.Windows.Forms.CheckBox chkbxDetailed;
        private System.Windows.Forms.TabControl tabControlBudget;
        private System.Windows.Forms.TabPage tabPageBudgetSummary;
        private System.Windows.Forms.TabPage tabPageBudgetDetailed;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetDetailed ucBudgetDetailed1;
        private Views.Dashboard.BudgetDashboard.BudgetSummary.ucBudgetSummary ucBudgetSummary1;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard ucTreasuryDashboard1;
    }
}

