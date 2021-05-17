
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
            this.menuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJEV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObligationRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRCI = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuBudgetAppropriation = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuprintRCI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnJournalEntry = new System.Windows.Forms.ToolStripButton();
            this.btnObligationRequest = new System.Windows.Forms.ToolStripButton();
            this.btnRCI = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUserFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuprintPC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1110, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 24);
            this.menuFile.Text = "&File";
            // 
            // menuTransactions
            // 
            this.menuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJEV,
            this.menuObligationRequest,
            this.menuRCI});
            this.menuTransactions.Name = "menuTransactions";
            this.menuTransactions.Size = new System.Drawing.Size(104, 24);
            this.menuTransactions.Text = "Transactions";
            // 
            // menuJEV
            // 
            this.menuJEV.Name = "menuJEV";
            this.menuJEV.Size = new System.Drawing.Size(148, 26);
            this.menuJEV.Text = "JEV...";
            this.menuJEV.Click += new System.EventHandler(this.menuJEV_Click);
            // 
            // menuObligationRequest
            // 
            this.menuObligationRequest.Name = "menuObligationRequest";
            this.menuObligationRequest.Size = new System.Drawing.Size(148, 26);
            this.menuObligationRequest.Text = "CAFOA...";
            // 
            // menuRCI
            // 
            this.menuRCI.Name = "menuRCI";
            this.menuRCI.Size = new System.Drawing.Size(148, 26);
            this.menuRCI.Text = "RCI...";
            this.menuRCI.Click += new System.EventHandler(this.menuRCI_Click);
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
            this.menuBudgetAppropriation,
            this.menuBanks,
            this.menuAccForm});
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
            this.menuUsers.Size = new System.Drawing.Size(272, 26);
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
            // menuJournals
            // 
            this.menuJournals.Name = "menuJournals";
            this.menuJournals.Size = new System.Drawing.Size(272, 26);
            this.menuJournals.Text = "Journals...";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
            // 
            // menuChartOfAccounts
            // 
            this.menuChartOfAccounts.Name = "menuChartOfAccounts";
            this.menuChartOfAccounts.Size = new System.Drawing.Size(272, 26);
            this.menuChartOfAccounts.Text = "Chart of Accounts...";
            this.menuChartOfAccounts.Click += new System.EventHandler(this.menuChartOfAccounts_Click);
            // 
            // menuAllotmentClasses
            // 
            this.menuAllotmentClasses.Name = "menuAllotmentClasses";
            this.menuAllotmentClasses.Size = new System.Drawing.Size(272, 26);
            this.menuAllotmentClasses.Text = "Allotment Classes...";
            this.menuAllotmentClasses.Click += new System.EventHandler(this.menuAllotmentClasses_Click);
            // 
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(272, 26);
            this.menuFunds.Text = "Funds...";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(272, 26);
            this.menuFunctionProgramProject.Text = "Function/Program/Project...";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(272, 26);
            this.menuCollectingOfficer.Text = "Collecting Officer...";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuDisbursingOfficer
            // 
            this.menuDisbursingOfficer.Name = "menuDisbursingOfficer";
            this.menuDisbursingOfficer.Size = new System.Drawing.Size(272, 26);
            this.menuDisbursingOfficer.Text = "Disbursing Officers...";
            // 
            // menuBudgetAppropriation
            // 
            this.menuBudgetAppropriation.Name = "menuBudgetAppropriation";
            this.menuBudgetAppropriation.Size = new System.Drawing.Size(272, 26);
            this.menuBudgetAppropriation.Text = "Budget Appropriations...";
            this.menuBudgetAppropriation.Click += new System.EventHandler(this.menuBudgetAppropriation_Click);
            // 
            // menuBanks
            // 
            this.menuBanks.Name = "menuBanks";
            this.menuBanks.Size = new System.Drawing.Size(272, 26);
            this.menuBanks.Text = "Banks...";
            this.menuBanks.Click += new System.EventHandler(this.menuBanks_Click);
            // 
            // menuAccForm
            // 
            this.menuAccForm.Name = "menuAccForm";
            this.menuAccForm.Size = new System.Drawing.Size(272, 26);
            this.menuAccForm.Text = "Accountable Form";
            this.menuAccForm.Click += new System.EventHandler(this.menuAccForm_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJournalsReport,
            this.menuLedgersReport,
            this.menuSAAOB,
            this.menuprintRCI,
            this.menuprintPC});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(74, 24);
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
            this.menuJournalsReport.Size = new System.Drawing.Size(281, 26);
            this.menuJournalsReport.Text = "Journals";
            // 
            // menuReportGJ
            // 
            this.menuReportGJ.Name = "menuReportGJ";
            this.menuReportGJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportGJ.Text = "General Journal...";
            // 
            // menuReportCRJ
            // 
            this.menuReportCRJ.Name = "menuReportCRJ";
            this.menuReportCRJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportCRJ.Text = "Cash Receipts Journal...";
            // 
            // menuReportPRJ
            // 
            this.menuReportPRJ.Name = "menuReportPRJ";
            this.menuReportPRJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportPRJ.Text = "Procurement Received Journal...";
            // 
            // menuReportCDJ
            // 
            this.menuReportCDJ.Name = "menuReportCDJ";
            this.menuReportCDJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportCDJ.Text = "Cash Disbursements Journal...";
            // 
            // menuReportCkDJ
            // 
            this.menuReportCkDJ.Name = "menuReportCkDJ";
            this.menuReportCkDJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportCkDJ.Text = "Check Disbursements Journal...";
            // 
            // menuReportADADJ
            // 
            this.menuReportADADJ.Name = "menuReportADADJ";
            this.menuReportADADJ.Size = new System.Drawing.Size(431, 26);
            this.menuReportADADJ.Text = "Authority to Debit Account Disbursements Journal...";
            // 
            // menuLedgersReport
            // 
            this.menuLedgersReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGeneralLedgerReport,
            this.menuSubsidiaryLedgerReport});
            this.menuLedgersReport.Name = "menuLedgersReport";
            this.menuLedgersReport.Size = new System.Drawing.Size(281, 26);
            this.menuLedgersReport.Text = "Ledgers";
            // 
            // menuGeneralLedgerReport
            // 
            this.menuGeneralLedgerReport.Name = "menuGeneralLedgerReport";
            this.menuGeneralLedgerReport.Size = new System.Drawing.Size(219, 26);
            this.menuGeneralLedgerReport.Text = "General Ledger...";
            // 
            // menuSubsidiaryLedgerReport
            // 
            this.menuSubsidiaryLedgerReport.Name = "menuSubsidiaryLedgerReport";
            this.menuSubsidiaryLedgerReport.Size = new System.Drawing.Size(219, 26);
            this.menuSubsidiaryLedgerReport.Text = "Subsidiary Ledger...";
            // 
            // menuSAAOB
            // 
            this.menuSAAOB.Name = "menuSAAOB";
            this.menuSAAOB.Size = new System.Drawing.Size(281, 26);
            this.menuSAAOB.Text = "SAAOB";
            // 
            // menuprintRCI
            // 
            this.menuprintRCI.Name = "menuprintRCI";
            this.menuprintRCI.Size = new System.Drawing.Size(281, 26);
            this.menuprintRCI.Text = "Report of Checks Issued";
            this.menuprintRCI.Click += new System.EventHandler(this.menuprintRCI_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnJournalEntry,
            this.btnObligationRequest,
            this.btnRCI});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1110, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnJournalEntry
            // 
            this.btnJournalEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnJournalEntry.Image")));
            this.btnJournalEntry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnJournalEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJournalEntry.Name = "btnJournalEntry";
            this.btnJournalEntry.Size = new System.Drawing.Size(76, 36);
            this.btnJournalEntry.Text = "JEV...";
            // 
            // btnObligationRequest
            // 
            this.btnObligationRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnObligationRequest.Image")));
            this.btnObligationRequest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnObligationRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnObligationRequest.Name = "btnObligationRequest";
            this.btnObligationRequest.Size = new System.Drawing.Size(101, 36);
            this.btnObligationRequest.Text = "CAFOA...";
            // 
            // btnRCI
            // 
            this.btnRCI.Image = ((System.Drawing.Image)(resources.GetObject("btnRCI.Image")));
            this.btnRCI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRCI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRCI.Name = "btnRCI";
            this.btnRCI.Size = new System.Drawing.Size(76, 36);
            this.btnRCI.Text = "RCI...";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 490);
            this.panel1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserFullName,
            this.lblUserRole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1110, 30);
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
            // menuprintPC
            // 
            this.menuprintPC.Name = "menuprintPC";
            this.menuprintPC.Size = new System.Drawing.Size(281, 26);
            this.menuprintPC.Text = "Report of General Collection";
            this.menuprintPC.Click += new System.EventHandler(this.menuprintPC_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1110, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1125, 598);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Finance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem menuBudgetAppropriation;
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
        private System.Windows.Forms.ToolStripMenuItem menuprintPC;
    }
}

