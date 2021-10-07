
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
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJEVS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrialBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.financialStatementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ucBudgetDashboard1 = new AccountingSystem.Views.Dashboard.ucBudgetDashboard();
            this.tabPageAccounting = new System.Windows.Forms.TabPage();
            this.tabControlAccounting = new System.Windows.Forms.TabControl();
            this.tabJournalEntryVoucher = new System.Windows.Forms.TabPage();
            this.ucjevDashboard1 = new AccountingSystem.Views.Dashboard.ucJEVDashboard();
            this.tabJournals = new System.Windows.Forms.TabPage();
            this.ucJournalsDashboard1 = new AccountingSystem.Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            this.tabLedgers = new System.Windows.Forms.TabPage();
            this.tabControlLedgers = new System.Windows.Forms.TabControl();
            this.tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            this.ucGeneralLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucGeneralLedger();
            this.tabPageSubsidiaryLedger = new System.Windows.Forms.TabPage();
            this.ucSubsidiaryLedger1 = new AccountingSystem.Views.Reports.Ledgers.ucSubsidiaryLedger();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioGeneralLedger = new System.Windows.Forms.RadioButton();
            this.radioSubsidiaryLedger = new System.Windows.Forms.RadioButton();
            this.radioTransactionLog = new System.Windows.Forms.RadioButton();
            this.tabTrialBalance = new System.Windows.Forms.TabPage();
            this.tabFinancialStatements = new System.Windows.Forms.TabPage();
            this.tabPageTreasury = new System.Windows.Forms.TabPage();
            this.ucTreasuryDashboard1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabPageBudget.SuspendLayout();
            this.tabPageAccounting.SuspendLayout();
            this.tabControlAccounting.SuspendLayout();
            this.tabJournalEntryVoucher.SuspendLayout();
            this.tabJournals.SuspendLayout();
            this.tabLedgers.SuspendLayout();
            this.tabControlLedgers.SuspendLayout();
            this.tabPageGeneralLedger.SuspendLayout();
            this.tabPageSubsidiaryLedger.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1180, 25);
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
            this.menuReceipts});
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
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSAAOB,
            this.menuSAAOBB,
            this.menuJEVS,
            this.menuTrialBalance,
            this.financialStatementsToolStripMenuItem,
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
            // menuJEVS
            // 
            this.menuJEVS.Name = "menuJEVS";
            this.menuJEVS.Size = new System.Drawing.Size(233, 22);
            this.menuJEVS.Text = "JEVs";
            this.menuJEVS.Click += new System.EventHandler(this.menuJEVS_Click_1);
            // 
            // menuTrialBalance
            // 
            this.menuTrialBalance.Name = "menuTrialBalance";
            this.menuTrialBalance.Size = new System.Drawing.Size(233, 22);
            this.menuTrialBalance.Text = "Trial Balance";
            this.menuTrialBalance.Click += new System.EventHandler(this.menuTrialBalance_Click);
            // 
            // financialStatementsToolStripMenuItem
            // 
            this.financialStatementsToolStripMenuItem.Name = "financialStatementsToolStripMenuItem";
            this.financialStatementsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.financialStatementsToolStripMenuItem.Text = "Financial Statements";
            this.financialStatementsToolStripMenuItem.Click += new System.EventHandler(this.financialStatementsToolStripMenuItem_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1180, 24);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1180, 31);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radBtnBudget
            // 
            this.radBtnBudget.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnBudget.AutoSize = true;
            this.radBtnBudget.Checked = true;
            this.radBtnBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnBudget.Location = new System.Drawing.Point(3, 3);
            this.radBtnBudget.Name = "radBtnBudget";
            this.radBtnBudget.Size = new System.Drawing.Size(55, 25);
            this.radBtnBudget.TabIndex = 0;
            this.radBtnBudget.TabStop = true;
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
            this.tabControlDashboard.Size = new System.Drawing.Size(1180, 606);
            this.tabControlDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDashboard.TabIndex = 9;
            // 
            // tabPageBudget
            // 
            this.tabPageBudget.Controls.Add(this.ucBudgetDashboard1);
            this.tabPageBudget.Location = new System.Drawing.Point(4, 5);
            this.tabPageBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageBudget.Name = "tabPageBudget";
            this.tabPageBudget.Size = new System.Drawing.Size(1172, 597);
            this.tabPageBudget.TabIndex = 0;
            this.tabPageBudget.Text = "Budget";
            this.tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // ucBudgetDashboard1
            // 
            this.ucBudgetDashboard1.AutoSize = true;
            this.ucBudgetDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBudgetDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBudgetDashboard1.Location = new System.Drawing.Point(0, 0);
            this.ucBudgetDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBudgetDashboard1.Name = "ucBudgetDashboard1";
            this.ucBudgetDashboard1.Size = new System.Drawing.Size(1172, 597);
            this.ucBudgetDashboard1.TabIndex = 1;
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.tabControlAccounting);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 5);
            this.tabPageAccounting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Size = new System.Drawing.Size(1172, 597);
            this.tabPageAccounting.TabIndex = 1;
            this.tabPageAccounting.Text = "Accounting";
            this.tabPageAccounting.UseVisualStyleBackColor = true;
            // 
            // tabControlAccounting
            // 
            this.tabControlAccounting.Controls.Add(this.tabJournalEntryVoucher);
            this.tabControlAccounting.Controls.Add(this.tabJournals);
            this.tabControlAccounting.Controls.Add(this.tabLedgers);
            this.tabControlAccounting.Controls.Add(this.tabTrialBalance);
            this.tabControlAccounting.Controls.Add(this.tabFinancialStatements);
            this.tabControlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccounting.Location = new System.Drawing.Point(0, 0);
            this.tabControlAccounting.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAccounting.Name = "tabControlAccounting";
            this.tabControlAccounting.SelectedIndex = 0;
            this.tabControlAccounting.Size = new System.Drawing.Size(1172, 597);
            this.tabControlAccounting.TabIndex = 0;
            // 
            // tabJournalEntryVoucher
            // 
            this.tabJournalEntryVoucher.Controls.Add(this.ucjevDashboard1);
            this.tabJournalEntryVoucher.Location = new System.Drawing.Point(4, 24);
            this.tabJournalEntryVoucher.Margin = new System.Windows.Forms.Padding(0);
            this.tabJournalEntryVoucher.Name = "tabJournalEntryVoucher";
            this.tabJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabJournalEntryVoucher.Size = new System.Drawing.Size(1164, 569);
            this.tabJournalEntryVoucher.TabIndex = 0;
            this.tabJournalEntryVoucher.Text = "Journal Entry Voucher";
            this.tabJournalEntryVoucher.UseVisualStyleBackColor = true;
            // 
            // ucjevDashboard1
            // 
            this.ucjevDashboard1.AutoSize = true;
            this.ucjevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucjevDashboard1.Location = new System.Drawing.Point(3, 3);
            this.ucjevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            this.ucjevDashboard1.MinimumSize = new System.Drawing.Size(782, 160);
            this.ucjevDashboard1.Name = "ucjevDashboard1";
            this.ucjevDashboard1.Size = new System.Drawing.Size(1158, 160);
            this.ucjevDashboard1.TabIndex = 0;
            // 
            // tabJournals
            // 
            this.tabJournals.Controls.Add(this.ucJournalsDashboard1);
            this.tabJournals.Location = new System.Drawing.Point(4, 24);
            this.tabJournals.Name = "tabJournals";
            this.tabJournals.Padding = new System.Windows.Forms.Padding(3);
            this.tabJournals.Size = new System.Drawing.Size(1164, 569);
            this.tabJournals.TabIndex = 1;
            this.tabJournals.Text = "Journals";
            this.tabJournals.UseVisualStyleBackColor = true;
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
            this.ucJournalsDashboard1.Size = new System.Drawing.Size(1158, 160);
            this.ucJournalsDashboard1.TabIndex = 0;
            // 
            // tabLedgers
            // 
            this.tabLedgers.Controls.Add(this.tabControlLedgers);
            this.tabLedgers.Controls.Add(this.flowLayoutPanel2);
            this.tabLedgers.Location = new System.Drawing.Point(4, 24);
            this.tabLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabLedgers.Name = "tabLedgers";
            this.tabLedgers.Size = new System.Drawing.Size(1164, 569);
            this.tabLedgers.TabIndex = 2;
            this.tabLedgers.Text = "Ledgers";
            this.tabLedgers.UseVisualStyleBackColor = true;
            // 
            // tabControlLedgers
            // 
            this.tabControlLedgers.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlLedgers.Controls.Add(this.tabPageGeneralLedger);
            this.tabControlLedgers.Controls.Add(this.tabPageSubsidiaryLedger);
            this.tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLedgers.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlLedgers.Location = new System.Drawing.Point(0, 31);
            this.tabControlLedgers.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlLedgers.Multiline = true;
            this.tabControlLedgers.Name = "tabControlLedgers";
            this.tabControlLedgers.SelectedIndex = 0;
            this.tabControlLedgers.Size = new System.Drawing.Size(1164, 538);
            this.tabControlLedgers.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlLedgers.TabIndex = 0;
            // 
            // tabPageGeneralLedger
            // 
            this.tabPageGeneralLedger.Controls.Add(this.ucGeneralLedger1);
            this.tabPageGeneralLedger.Location = new System.Drawing.Point(4, 4);
            this.tabPageGeneralLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            this.tabPageGeneralLedger.Size = new System.Drawing.Size(1156, 529);
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
            this.ucGeneralLedger1.Size = new System.Drawing.Size(1156, 529);
            this.ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageSubsidiaryLedger
            // 
            this.tabPageSubsidiaryLedger.Controls.Add(this.ucSubsidiaryLedger1);
            this.tabPageSubsidiaryLedger.Location = new System.Drawing.Point(4, 4);
            this.tabPageSubsidiaryLedger.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSubsidiaryLedger.Name = "tabPageSubsidiaryLedger";
            this.tabPageSubsidiaryLedger.Size = new System.Drawing.Size(1156, 529);
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
            this.ucSubsidiaryLedger1.Size = new System.Drawing.Size(1156, 529);
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
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1164, 31);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // radioGeneralLedger
            // 
            this.radioGeneralLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioGeneralLedger.Checked = true;
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
            // tabTrialBalance
            // 
            this.tabTrialBalance.Location = new System.Drawing.Point(4, 24);
            this.tabTrialBalance.Name = "tabTrialBalance";
            this.tabTrialBalance.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrialBalance.Size = new System.Drawing.Size(1164, 569);
            this.tabTrialBalance.TabIndex = 3;
            this.tabTrialBalance.Text = "Trial Balance";
            this.tabTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabFinancialStatements
            // 
            this.tabFinancialStatements.Location = new System.Drawing.Point(4, 24);
            this.tabFinancialStatements.Name = "tabFinancialStatements";
            this.tabFinancialStatements.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinancialStatements.Size = new System.Drawing.Size(1164, 569);
            this.tabFinancialStatements.TabIndex = 4;
            this.tabFinancialStatements.Text = "Financial Statements";
            this.tabFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabPageTreasury
            // 
            this.tabPageTreasury.Controls.Add(this.ucTreasuryDashboard1);
            this.tabPageTreasury.Location = new System.Drawing.Point(4, 5);
            this.tabPageTreasury.Name = "tabPageTreasury";
            this.tabPageTreasury.Size = new System.Drawing.Size(1172, 597);
            this.tabPageTreasury.TabIndex = 2;
            this.tabPageTreasury.Text = "Treasury";
            this.tabPageTreasury.UseVisualStyleBackColor = true;
            // 
            // ucTreasuryDashboard1
            // 
            this.ucTreasuryDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreasuryDashboard1.Location = new System.Drawing.Point(0, 0);
            this.ucTreasuryDashboard1.Name = "ucTreasuryDashboard1";
            this.ucTreasuryDashboard1.Size = new System.Drawing.Size(1172, 597);
            this.ucTreasuryDashboard1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1180, 686);
            this.Controls.Add(this.tabControlDashboard);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1196, 725);
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
            this.tabPageAccounting.ResumeLayout(false);
            this.tabControlAccounting.ResumeLayout(false);
            this.tabJournalEntryVoucher.ResumeLayout(false);
            this.tabJournalEntryVoucher.PerformLayout();
            this.tabJournals.ResumeLayout(false);
            this.tabJournals.PerformLayout();
            this.tabLedgers.ResumeLayout(false);
            this.tabLedgers.PerformLayout();
            this.tabControlLedgers.ResumeLayout(false);
            this.tabPageGeneralLedger.ResumeLayout(false);
            this.tabPageSubsidiaryLedger.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPageTreasury.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuObligationRequest;
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
        private System.Windows.Forms.ToolStripMenuItem menuReportJournals;
        private System.Windows.Forms.ToolStripMenuItem menuDisbursingOfficer;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserFullName;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
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
        private System.Windows.Forms.ToolStripMenuItem menuJEVS;
        private System.Windows.Forms.TabControl tabControlDashboard;
        internal System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem menuReceiptsConsolidated;
        private System.Windows.Forms.ToolStripMenuItem menuTrialBalance;
        private System.Windows.Forms.ToolStripMenuItem menuDailyCash;
        private System.Windows.Forms.ToolStripMenuItem financialStatementsToolStripMenuItem;
        internal System.Windows.Forms.TabPage tabPageBudget;
        private Views.Dashboard.ucBudgetDashboard ucBudgetDashboard1;
        private System.Windows.Forms.TabControl tabControlAccounting;
        private System.Windows.Forms.TabPage tabJournalEntryVoucher;
        private System.Windows.Forms.TabPage tabJournals;
        private System.Windows.Forms.TabPage tabLedgers;
        private System.Windows.Forms.TabPage tabTrialBalance;
        private System.Windows.Forms.TabPage tabFinancialStatements;
        private Views.Dashboard.ucJEVDashboard ucjevDashboard1;
        private System.Windows.Forms.RadioButton radBtnTreasury;
        private System.Windows.Forms.TabPage tabPageTreasury;
        private Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard ucTreasuryDashboard1;
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
    }
}

