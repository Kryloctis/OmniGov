
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJEV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObligationRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRCI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeposits = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJournalsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportGJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCRJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportPRJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCDJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCkDJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportADADJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLedgersReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeneralLedgerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSubsidiaryLedgerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOBB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprintRCI = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprintPC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBudgetAppropriations = new System.Windows.Forms.ToolStripButton();
            this.btnAllotmentRelease = new System.Windows.Forms.ToolStripButton();
            this.btnObligationRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnJournalEntry = new System.Windows.Forms.ToolStripButton();
            this.btnRCI = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radBtnBudget = new System.Windows.Forms.RadioButton();
            this.radBtnAccouting = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(971, 25);
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
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(157, 22);
            this.menuExitApp.Text = "Exit Application";
            // 
            // menuTransactions
            // 
            this.menuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJEV,
            this.menuObligationRequest,
            this.menuRCI,
            this.menuPayments,
            this.menuDeposits});
            this.menuTransactions.Name = "menuTransactions";
            this.menuTransactions.Size = new System.Drawing.Size(84, 19);
            this.menuTransactions.Text = "Transactions";
            // 
            // menuJEV
            // 
            this.menuJEV.Name = "menuJEV";
            this.menuJEV.Size = new System.Drawing.Size(178, 22);
            this.menuJEV.Text = "JEV...";
            this.menuJEV.Click += new System.EventHandler(this.menuJEV_Click);
            // 
            // menuObligationRequest
            // 
            this.menuObligationRequest.Name = "menuObligationRequest";
            this.menuObligationRequest.Size = new System.Drawing.Size(178, 22);
            this.menuObligationRequest.Text = "CAFOA...";
            // 
            // menuRCI
            // 
            this.menuRCI.Name = "menuRCI";
            this.menuRCI.Size = new System.Drawing.Size(178, 22);
            this.menuRCI.Text = "RCI...";
            this.menuRCI.Click += new System.EventHandler(this.menuRCI_Click);
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
            this.menuAccForm});
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
            // menuJournals
            // 
            this.menuJournals.Name = "menuJournals";
            this.menuJournals.Size = new System.Drawing.Size(223, 22);
            this.menuJournals.Text = "Journals...";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
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
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(223, 22);
            this.menuFunds.Text = "Funds...";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(223, 22);
            this.menuFunctionProgramProject.Text = "Function/Program/Project...";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(223, 22);
            this.menuCollectingOfficer.Text = "Collecting Officer...";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuDisbursingOfficer
            // 
            this.menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            this.menuDisbursingOfficer.Size = new System.Drawing.Size(223, 22);
            this.menuDisbursingOfficer.Text = "Disbursing Officers...";
            // 
            // menuBanks
            // 
            this.menuBanks.Name = "menuBanks";
            this.menuBanks.Size = new System.Drawing.Size(223, 22);
            this.menuBanks.Text = "Banks...";
            this.menuBanks.Click += new System.EventHandler(this.menuBanks_Click);
            // 
            // menuAccForm
            // 
            this.menuAccForm.Name = "menuAccForm";
            this.menuAccForm.Size = new System.Drawing.Size(223, 22);
            this.menuAccForm.Text = "Accountable Form";
            this.menuAccForm.Click += new System.EventHandler(this.menuAccForm_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJournalsReport,
            this.menuLedgersReport,
            this.menuSAAOB,
            this.menuSAAOBB,
            this.menuprintRCI,
            this.menuprintPC});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(59, 19);
            this.menuReports.Text = "Reports";
            // 
            // menuJournalsReport
            // 
            this.menuJournalsReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReportGJ,
            this.menuReportCRJ,
            this.menuReportPRJ,
            this.menuReportCDJ,
            this.menuReportCkDJ,
            this.menuReportADADJ});
            this.menuJournalsReport.Name = "menuJournalsReport";
            this.menuJournalsReport.Size = new System.Drawing.Size(223, 22);
            this.menuJournalsReport.Text = "Journals";
            // 
            // menuReportGJ
            // 
            this.menuReportGJ.Name = "menuReportGJ";
            this.menuReportGJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportGJ.Text = "General Journal...";
            // 
            // menuReportCRJ
            // 
            this.menuReportCRJ.Name = "menuReportCRJ";
            this.menuReportCRJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportCRJ.Text = "Cash Receipts Journal...";
            // 
            // menuReportPRJ
            // 
            this.menuReportPRJ.Name = "menuReportPRJ";
            this.menuReportPRJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportPRJ.Text = "Procurement Received Journal...";
            // 
            // menuReportCDJ
            // 
            this.menuReportCDJ.Name = "menuReportCDJ";
            this.menuReportCDJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportCDJ.Text = "Cash Disbursements Journal...";
            // 
            // menuReportCkDJ
            // 
            this.menuReportCkDJ.Name = "menuReportCkDJ";
            this.menuReportCkDJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportCkDJ.Text = "Check Disbursements Journal...";
            // 
            // menuReportADADJ
            // 
            this.menuReportADADJ.Name = "menuReportADADJ";
            this.menuReportADADJ.Size = new System.Drawing.Size(348, 22);
            this.menuReportADADJ.Text = "Authority to Debit Account Disbursements Journal...";
            // 
            // menuLedgersReport
            // 
            this.menuLedgersReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGeneralLedgerReport,
            this.menuSubsidiaryLedgerReport});
            this.menuLedgersReport.Name = "menuLedgersReport";
            this.menuLedgersReport.Size = new System.Drawing.Size(223, 22);
            this.menuLedgersReport.Text = "Ledgers";
            // 
            // menuGeneralLedgerReport
            // 
            this.menuGeneralLedgerReport.Name = "menuGeneralLedgerReport";
            this.menuGeneralLedgerReport.Size = new System.Drawing.Size(176, 22);
            this.menuGeneralLedgerReport.Text = "General Ledger...";
            // 
            // menuSubsidiaryLedgerReport
            // 
            this.menuSubsidiaryLedgerReport.Name = "menuSubsidiaryLedgerReport";
            this.menuSubsidiaryLedgerReport.Size = new System.Drawing.Size(176, 22);
            this.menuSubsidiaryLedgerReport.Text = "Subsidiary Ledger...";
            // 
            // menuSAAOB
            // 
            this.menuSAAOB.Name = "menuSAAOB";
            this.menuSAAOB.Size = new System.Drawing.Size(223, 22);
            this.menuSAAOB.Text = "SAAOB";
            // 
            // menuSAAOBB
            // 
            this.menuSAAOBB.Name = "menuSAAOBB";
            this.menuSAAOBB.Size = new System.Drawing.Size(223, 22);
            this.menuSAAOBB.Text = "SAAOBB";
            // 
            // menuprintRCI
            // 
            this.menuprintRCI.Name = "menuprintRCI";
            this.menuprintRCI.Size = new System.Drawing.Size(223, 22);
            this.menuprintRCI.Text = "Report of Checks Issued";
            this.menuprintRCI.Click += new System.EventHandler(this.menuprintRCI_Click);
            // 
            // menuprintPC
            // 
            this.menuprintPC.Name = "menuprintPC";
            this.menuprintPC.Size = new System.Drawing.Size(223, 22);
            this.menuprintPC.Text = "Report of General Collection";
            this.menuprintPC.Click += new System.EventHandler(this.menuprintPC_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBudgetAppropriations,
            this.btnAllotmentRelease,
            this.btnObligationRequest,
            this.toolStripSeparator1,
            this.btnJournalEntry,
            this.btnRCI});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(971, 31);
            this.toolStrip1.TabIndex = 4;
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnJournalEntry
            // 
            this.btnJournalEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnJournalEntry.Image")));
            this.btnJournalEntry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnJournalEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJournalEntry.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnJournalEntry.Name = "btnJournalEntry";
            this.btnJournalEntry.Size = new System.Drawing.Size(52, 28);
            this.btnJournalEntry.Text = "JEV";
            // 
            // btnRCI
            // 
            this.btnRCI.Image = ((System.Drawing.Image)(resources.GetObject("btnRCI.Image")));
            this.btnRCI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRCI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRCI.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnRCI.Name = "btnRCI";
            this.btnRCI.Size = new System.Drawing.Size(97, 28);
            this.btnRCI.Text = "Issue Check";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 346);
            this.panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserFullName,
            this.lblUserRole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(971, 24);
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
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(971, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.radBtnBudget);
            this.flowLayoutPanel1.Controls.Add(this.radBtnAccouting);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 93);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(971, 25);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radBtnBudget
            // 
            this.radBtnBudget.AutoSize = true;
            this.radBtnBudget.Checked = true;
            this.radBtnBudget.Location = new System.Drawing.Point(8, 3);
            this.radBtnBudget.Name = "radBtnBudget";
            this.radBtnBudget.Size = new System.Drawing.Size(63, 19);
            this.radBtnBudget.TabIndex = 0;
            this.radBtnBudget.TabStop = true;
            this.radBtnBudget.Text = "Budget";
            this.radBtnBudget.UseVisualStyleBackColor = true;
            // 
            // radBtnAccouting
            // 
            this.radBtnAccouting.AutoSize = true;
            this.radBtnAccouting.Location = new System.Drawing.Point(77, 3);
            this.radBtnAccouting.Name = "radBtnAccouting";
            this.radBtnAccouting.Size = new System.Drawing.Size(87, 19);
            this.radBtnAccouting.TabIndex = 1;
            this.radBtnAccouting.Text = "Accounting";
            this.radBtnAccouting.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(971, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(986, 456);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Finance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.ToolStripMenuItem menuReportGJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCRJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportPRJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCDJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCkDJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportADADJ;
        private System.Windows.Forms.ToolStripMenuItem menuJournalsReport;
        internal System.Windows.Forms.ToolStripMenuItem menuObligationRequest;
        private System.Windows.Forms.ToolStripMenuItem menuDisbursingOfficer;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOB;
        private System.Windows.Forms.ToolStripMenuItem menuLedgersReport;
        private System.Windows.Forms.ToolStripMenuItem menuGeneralLedgerReport;
        private System.Windows.Forms.ToolStripMenuItem menuSubsidiaryLedgerReport;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnJournalEntry;
        private System.Windows.Forms.ToolStripButton btnObligationRequest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserFullName;
        private System.Windows.Forms.ToolStripStatusLabel lblUserRole;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuBanks;
        private System.Windows.Forms.ToolStripMenuItem menuRCI;
        private System.Windows.Forms.ToolStripMenuItem menuprintRCI;
        private System.Windows.Forms.ToolStripButton btnRCI;
        private System.Windows.Forms.ToolStripMenuItem menuAccForm;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripMenuItem menuprintPC;
        private System.Windows.Forms.ToolStripMenuItem menuPayments;
        private System.Windows.Forms.ToolStripMenuItem menuDeposits;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOBB;
        internal System.Windows.Forms.ToolStripButton btnBudgetAppropriations;
        internal System.Windows.Forms.ToolStripButton btnAllotmentRelease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.RadioButton radBtnBudget;
        private System.Windows.Forms.RadioButton radBtnAccouting;
    }
}

