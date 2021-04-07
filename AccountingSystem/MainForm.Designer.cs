
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
            this.menuTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuJEV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObligationRequest = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuBeginningBalances = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBudgetAppropriation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportGJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCRJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportPRJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCDJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportCkDJ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportADADJ = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeneralLedgerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSubsidiaryLedgerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSAAOB = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1110, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 19);
            this.menuFile.Text = "&File";
            // 
            // menuTransactions
            // 
            this.menuTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuJEV,
            this.menuObligationRequest});
            this.menuTransactions.Name = "menuTransactions";
            this.menuTransactions.Size = new System.Drawing.Size(84, 19);
            this.menuTransactions.Text = "Transactions";
            // 
            // menuJEV
            // 
            this.menuJEV.Name = "menuJEV";
            this.menuJEV.Size = new System.Drawing.Size(197, 22);
            this.menuJEV.Text = "Journal Entry Voucher...";
            this.menuJEV.Click += new System.EventHandler(this.menuJEV_Click);
            // 
            // menuObligationRequest
            // 
            this.menuObligationRequest.Name = "menuObligationRequest";
            this.menuObligationRequest.Size = new System.Drawing.Size(197, 22);
            this.menuObligationRequest.Text = "Obligation Request...";
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
            this.menuBeginningBalances,
            this.toolStripSeparator1,
            this.menuBudgetAppropriation});
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
            // menuBeginningBalances
            // 
            this.menuBeginningBalances.Name = "menuBeginningBalances";
            this.menuBeginningBalances.Size = new System.Drawing.Size(223, 22);
            this.menuBeginningBalances.Text = "Beginning Balances...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // menuBudgetAppropriation
            // 
            this.menuBudgetAppropriation.Name = "menuBudgetAppropriation";
            this.menuBudgetAppropriation.Size = new System.Drawing.Size(223, 22);
            this.menuBudgetAppropriation.Text = "Budget Appropriations...";
            this.menuBudgetAppropriation.Click += new System.EventHandler(this.menuBudgetAppropriation_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.menuSAAOB});
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(59, 19);
            this.menuReports.Text = "Reports";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReportGJ,
            this.menuReportCRJ,
            this.menuReportPRJ,
            this.menuReportCDJ,
            this.menuReportCkDJ,
            this.menuReportADADJ});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem1.Text = "Journals";
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGeneralLedgerReport,
            this.menuSubsidiaryLedgerReport});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem2.Text = "Ledgers";
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
            this.menuSAAOB.Size = new System.Drawing.Size(117, 22);
            this.menuSAAOB.Text = "SAAOB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dashboard";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1110, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Finance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem menuFunds;
        private System.Windows.Forms.ToolStripMenuItem menuChartOfAccounts;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuRoles;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionProgramProject;
        private System.Windows.Forms.ToolStripMenuItem menuCollectingOfficer;
        private System.Windows.Forms.ToolStripMenuItem menuBudgetAppropriation;
        private System.Windows.Forms.ToolStripMenuItem menuJEV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuReportJournals;
        private System.Windows.Forms.ToolStripMenuItem menuReportGJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCRJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportPRJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCDJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportCkDJ;
        private System.Windows.Forms.ToolStripMenuItem menuReportADADJ;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem menuObligationRequest;
        private System.Windows.Forms.ToolStripMenuItem menuBeginningBalances;
        internal System.Windows.Forms.ToolStripMenuItem menuSAAOB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuGeneralLedgerReport;
        private System.Windows.Forms.ToolStripMenuItem menuSubsidiaryLedgerReport;
    }
}

