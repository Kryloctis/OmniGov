
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
            this.menuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJEV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIssueCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeposits = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGenerateRCD = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIssueReceipts = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuJournalsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLedgersReport = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabBudget = new System.Windows.Forms.TabPage();
            this.ucBudgetDashboard1 = new AccountingSystem.Views.Dashboard.ucBudgetDashboard();
            this.tabAccounting = new System.Windows.Forms.TabPage();
            this.tabControlAccounting = new System.Windows.Forms.TabControl();
            this.tabJournalEntryVoucher = new System.Windows.Forms.TabPage();
            this.ucjevDashboard1 = new AccountingSystem.Views.Dashboard.ucJEVDashboard();
            this.tabJournals = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabTrialBalance = new System.Windows.Forms.TabPage();
            this.tabFinancialStatements = new System.Windows.Forms.TabPage();
            this.tabTreasury = new System.Windows.Forms.TabPage();
            this.ucTreasuryDashboard1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard();
            this.ucJournalsDashboard1 = new AccountingSystem.Views.Dashboard.AccountingDashboard.ucJournalsDashboard();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabBudget.SuspendLayout();
            this.tabAccounting.SuspendLayout();
            this.tabControlAccounting.SuspendLayout();
            this.tabJournalEntryVoucher.SuspendLayout();
            this.tabJournals.SuspendLayout();
            this.tabTreasury.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTransactions,
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
            // menuTransactions
            // 
            this.menuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJEV,
            this.menuIssueCheck,
            this.menuPayments,
            this.menuDeposits,
            this.menuGenerateRCD,
            this.menuIssueReceipts});
            this.menuTransactions.Name = "menuTransactions";
            this.menuTransactions.Size = new System.Drawing.Size(84, 19);
            this.menuTransactions.Text = "Transactions";
            // 
            // menuJEV
            // 
            this.menuJEV.Name = "menuJEV";
            this.menuJEV.Size = new System.Drawing.Size(178, 22);
            this.menuJEV.Text = "JEV";
            this.menuJEV.Click += new System.EventHandler(this.menuJEV_Click);
            // 
            // menuIssueCheck
            // 
            this.menuIssueCheck.Name = "menuIssueCheck";
            this.menuIssueCheck.Size = new System.Drawing.Size(178, 22);
            this.menuIssueCheck.Text = "Issue Check";
            this.menuIssueCheck.Click += new System.EventHandler(this.menuRCI_Click);
            // 
            // menuPayments
            // 
            this.menuPayments.Name = "menuPayments";
            this.menuPayments.Size = new System.Drawing.Size(178, 22);
            this.menuPayments.Text = "Payment Collection";
            this.menuPayments.Click += new System.EventHandler(this.menuPayments_Click);
            // 
            // menuDeposits
            // 
            this.menuDeposits.Name = "menuDeposits";
            this.menuDeposits.Size = new System.Drawing.Size(178, 22);
            this.menuDeposits.Text = "Bank Deposits";
            this.menuDeposits.Click += new System.EventHandler(this.menuDeposits_Click);
            // 
            // menuGenerateRCD
            // 
            this.menuGenerateRCD.Name = "menuGenerateRCD";
            this.menuGenerateRCD.Size = new System.Drawing.Size(178, 22);
            this.menuGenerateRCD.Text = "Generate RCD";
            this.menuGenerateRCD.Click += new System.EventHandler(this.menuGenerateRCD_Click);
            // 
            // menuIssueReceipts
            // 
            this.menuIssueReceipts.Name = "menuIssueReceipts";
            this.menuIssueReceipts.Size = new System.Drawing.Size(178, 22);
            this.menuIssueReceipts.Text = "Issue Receipts";
            this.menuIssueReceipts.Click += new System.EventHandler(this.menureceiptsissued_Click);
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
            this.menuJournalsReport,
            this.menuLedgersReport,
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
            // menuJournalsReport
            // 
            this.menuJournalsReport.Name = "menuJournalsReport";
            this.menuJournalsReport.Size = new System.Drawing.Size(233, 22);
            this.menuJournalsReport.Text = "Journals";
            this.menuJournalsReport.Click += new System.EventHandler(this.menuJournalsReport_Click);
            // 
            // menuLedgersReport
            // 
            this.menuLedgersReport.Name = "menuLedgersReport";
            this.menuLedgersReport.Size = new System.Drawing.Size(233, 22);
            this.menuLedgersReport.Text = "Ledgers";
            this.menuLedgersReport.Click += new System.EventHandler(this.menuLedgersReport_Click);
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
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1180, 31);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radBtnBudget
            // 
            this.radBtnBudget.Appearance = System.Windows.Forms.Appearance.Button;
            this.radBtnBudget.AutoSize = true;
            this.radBtnBudget.Checked = true;
            this.radBtnBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radBtnBudget.Location = new System.Drawing.Point(8, 3);
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
            this.radBtnAccounting.Location = new System.Drawing.Point(69, 3);
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
            this.radBtnTreasury.Location = new System.Drawing.Point(154, 3);
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
            this.tabControlDashboard.Controls.Add(this.tabBudget);
            this.tabControlDashboard.Controls.Add(this.tabAccounting);
            this.tabControlDashboard.Controls.Add(this.tabTreasury);
            this.tabControlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDashboard.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlDashboard.Location = new System.Drawing.Point(0, 56);
            this.tabControlDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlDashboard.Multiline = true;
            this.tabControlDashboard.Name = "tabControlDashboard";
            this.tabControlDashboard.Padding = new System.Drawing.Point(0, 0);
            this.tabControlDashboard.SelectedIndex = 0;
            this.tabControlDashboard.Size = new System.Drawing.Size(1180, 606);
            this.tabControlDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDashboard.TabIndex = 9;
            // 
            // tabBudget
            // 
            this.tabBudget.Controls.Add(this.ucBudgetDashboard1);
            this.tabBudget.Location = new System.Drawing.Point(4, 5);
            this.tabBudget.Margin = new System.Windows.Forms.Padding(0);
            this.tabBudget.Name = "tabBudget";
            this.tabBudget.Size = new System.Drawing.Size(1172, 597);
            this.tabBudget.TabIndex = 0;
            this.tabBudget.Text = "Budget";
            this.tabBudget.UseVisualStyleBackColor = true;
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
            // tabAccounting
            // 
            this.tabAccounting.Controls.Add(this.tabControlAccounting);
            this.tabAccounting.Location = new System.Drawing.Point(4, 5);
            this.tabAccounting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAccounting.Name = "tabAccounting";
            this.tabAccounting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAccounting.Size = new System.Drawing.Size(1172, 597);
            this.tabAccounting.TabIndex = 1;
            this.tabAccounting.Text = "Accounting";
            this.tabAccounting.UseVisualStyleBackColor = true;
            // 
            // tabControlAccounting
            // 
            this.tabControlAccounting.Controls.Add(this.tabJournalEntryVoucher);
            this.tabControlAccounting.Controls.Add(this.tabJournals);
            this.tabControlAccounting.Controls.Add(this.tabPage3);
            this.tabControlAccounting.Controls.Add(this.tabTrialBalance);
            this.tabControlAccounting.Controls.Add(this.tabFinancialStatements);
            this.tabControlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccounting.Location = new System.Drawing.Point(3, 2);
            this.tabControlAccounting.Name = "tabControlAccounting";
            this.tabControlAccounting.SelectedIndex = 0;
            this.tabControlAccounting.Size = new System.Drawing.Size(1166, 593);
            this.tabControlAccounting.TabIndex = 0;
            // 
            // tabJournalEntryVoucher
            // 
            this.tabJournalEntryVoucher.Controls.Add(this.ucjevDashboard1);
            this.tabJournalEntryVoucher.Location = new System.Drawing.Point(4, 24);
            this.tabJournalEntryVoucher.Name = "tabJournalEntryVoucher";
            this.tabJournalEntryVoucher.Padding = new System.Windows.Forms.Padding(3);
            this.tabJournalEntryVoucher.Size = new System.Drawing.Size(1158, 565);
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
            this.ucjevDashboard1.Size = new System.Drawing.Size(1152, 160);
            this.ucjevDashboard1.TabIndex = 0;
            // 
            // tabJournals
            // 
            this.tabJournals.Controls.Add(this.ucJournalsDashboard1);
            this.tabJournals.Location = new System.Drawing.Point(4, 24);
            this.tabJournals.Name = "tabJournals";
            this.tabJournals.Padding = new System.Windows.Forms.Padding(3);
            this.tabJournals.Size = new System.Drawing.Size(1158, 565);
            this.tabJournals.TabIndex = 1;
            this.tabJournals.Text = "Journals";
            this.tabJournals.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1158, 565);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ledgers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabTrialBalance
            // 
            this.tabTrialBalance.Location = new System.Drawing.Point(4, 24);
            this.tabTrialBalance.Name = "tabTrialBalance";
            this.tabTrialBalance.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrialBalance.Size = new System.Drawing.Size(1158, 565);
            this.tabTrialBalance.TabIndex = 3;
            this.tabTrialBalance.Text = "Trial Balance";
            this.tabTrialBalance.UseVisualStyleBackColor = true;
            // 
            // tabFinancialStatements
            // 
            this.tabFinancialStatements.Location = new System.Drawing.Point(4, 24);
            this.tabFinancialStatements.Name = "tabFinancialStatements";
            this.tabFinancialStatements.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinancialStatements.Size = new System.Drawing.Size(1158, 565);
            this.tabFinancialStatements.TabIndex = 4;
            this.tabFinancialStatements.Text = "Financial Statements";
            this.tabFinancialStatements.UseVisualStyleBackColor = true;
            // 
            // tabTreasury
            // 
            this.tabTreasury.Controls.Add(this.ucTreasuryDashboard1);
            this.tabTreasury.Location = new System.Drawing.Point(4, 5);
            this.tabTreasury.Name = "tabTreasury";
            this.tabTreasury.Size = new System.Drawing.Size(1172, 597);
            this.tabTreasury.TabIndex = 2;
            this.tabTreasury.Text = "Treasury";
            this.tabTreasury.UseVisualStyleBackColor = true;
            // 
            // ucTreasuryDashboard1
            // 
            this.ucTreasuryDashboard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTreasuryDashboard1.Location = new System.Drawing.Point(0, 0);
            this.ucTreasuryDashboard1.Name = "ucTreasuryDashboard1";
            this.ucTreasuryDashboard1.Size = new System.Drawing.Size(1172, 597);
            this.ucTreasuryDashboard1.TabIndex = 0;
            // 
            // ucJournalsDashboard1
            // 
            this.ucJournalsDashboard1.AutoSize = true;
            this.ucJournalsDashboard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucJournalsDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucJournalsDashboard1.Location = new System.Drawing.Point(3, 3);
            this.ucJournalsDashboard1.MinimumSize = new System.Drawing.Size(941, 160);
            this.ucJournalsDashboard1.Name = "ucJournalsDashboard1";
            this.ucJournalsDashboard1.Size = new System.Drawing.Size(1152, 160);
            this.ucJournalsDashboard1.TabIndex = 0;
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
            this.tabBudget.ResumeLayout(false);
            this.tabBudget.PerformLayout();
            this.tabAccounting.ResumeLayout(false);
            this.tabControlAccounting.ResumeLayout(false);
            this.tabJournalEntryVoucher.ResumeLayout(false);
            this.tabJournalEntryVoucher.PerformLayout();
            this.tabJournals.ResumeLayout(false);
            this.tabJournals.PerformLayout();
            this.tabTreasury.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuObligationRequest;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuManage;
        private System.Windows.Forms.ToolStripMenuItem menuJournals;
        private System.Windows.Forms.ToolStripMenuItem menuTransactions;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuAllotmentClasses;
        private System.Windows.Forms.ToolStripMenuItem menuFunds;
        private System.Windows.Forms.ToolStripMenuItem menuChartOfAccounts;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionProgramProject;
        private System.Windows.Forms.ToolStripMenuItem menuCollectingOfficer;
        private System.Windows.Forms.ToolStripMenuItem menuJEV;
        private System.Windows.Forms.ToolStripMenuItem menuReportJournals;
        private System.Windows.Forms.ToolStripMenuItem menuJournalsReport;
        private System.Windows.Forms.ToolStripMenuItem menuDisbursingOfficer;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOB;
        private System.Windows.Forms.ToolStripMenuItem menuLedgersReport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserFullName;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuBanks;
        private System.Windows.Forms.ToolStripMenuItem menuIssueCheck;
        private System.Windows.Forms.ToolStripMenuItem menuprintRCI;
        private System.Windows.Forms.ToolStripMenuItem menuAccForm;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripMenuItem menuprintPC;
        private System.Windows.Forms.ToolStripMenuItem menuPayments;
        private System.Windows.Forms.ToolStripMenuItem menuDeposits;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOBB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.RadioButton radBtnBudget;
        private System.Windows.Forms.RadioButton radBtnAccounting;
        private System.Windows.Forms.ToolStripMenuItem menuGenerateRCD;
        private System.Windows.Forms.ToolStripMenuItem menuprintGC;
        private System.Windows.Forms.ToolStripMenuItem menuIssueReceipts;
        private System.Windows.Forms.ToolStripMenuItem menuReceipts;
        private System.Windows.Forms.ToolStripMenuItem menuBankCashBook;
        private System.Windows.Forms.ToolStripMenuItem menuJEVS;
        private System.Windows.Forms.TabControl tabControlDashboard;
        internal System.Windows.Forms.TabPage tabAccounting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem menuReceiptsConsolidated;
        private System.Windows.Forms.ToolStripMenuItem menuTrialBalance;
        private System.Windows.Forms.ToolStripMenuItem menuDailyCash;
        private System.Windows.Forms.ToolStripMenuItem financialStatementsToolStripMenuItem;
        internal System.Windows.Forms.TabPage tabBudget;
        private Views.Dashboard.ucBudgetDashboard ucBudgetDashboard1;
        private System.Windows.Forms.TabControl tabControlAccounting;
        private System.Windows.Forms.TabPage tabJournalEntryVoucher;
        private System.Windows.Forms.TabPage tabJournals;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabTrialBalance;
        private System.Windows.Forms.TabPage tabFinancialStatements;
        private Views.Dashboard.ucJEVDashboard ucjevDashboard1;
        private System.Windows.Forms.RadioButton radBtnTreasury;
        private System.Windows.Forms.TabPage tabTreasury;
        private Views.Dashboard.TreasuryDashboard.ucTreasuryDashboard ucTreasuryDashboard1;
        private Views.Dashboard.AccountingDashboard.ucJournalsDashboard ucJournalsDashboard1;
    }
}

