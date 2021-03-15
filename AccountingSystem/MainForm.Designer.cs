
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
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuBudgetAppropriation = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuTransactions.Name = "menuTransactions";
            this.menuTransactions.Size = new System.Drawing.Size(84, 19);
            this.menuTransactions.Text = "Transactions";
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
            this.menuUsers.Size = new System.Drawing.Size(235, 22);
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
            this.menuJournals.Size = new System.Drawing.Size(235, 22);
            this.menuJournals.Text = "Journals...";
            this.menuJournals.Click += new System.EventHandler(this.menuJournals_Click);
            // 
            // menuChartOfAccounts
            // 
            this.menuChartOfAccounts.Name = "menuChartOfAccounts";
            this.menuChartOfAccounts.Size = new System.Drawing.Size(235, 22);
            this.menuChartOfAccounts.Text = "Chart of Accounts...";
            this.menuChartOfAccounts.Click += new System.EventHandler(this.menuChartOfAccounts_Click);
            // 
            // menuAllotmentClasses
            // 
            this.menuAllotmentClasses.Name = "menuAllotmentClasses";
            this.menuAllotmentClasses.Size = new System.Drawing.Size(235, 22);
            this.menuAllotmentClasses.Text = "Allotment Classes...";
            this.menuAllotmentClasses.Click += new System.EventHandler(this.menuAllotmentClasses_Click);
            // 
            // menuFunds
            // 
            this.menuFunds.Name = "menuFunds";
            this.menuFunds.Size = new System.Drawing.Size(235, 22);
            this.menuFunds.Text = "Funds...";
            this.menuFunds.Click += new System.EventHandler(this.menuFunds_Click);
            // 
            // menuFunctionProgramProject
            // 
            this.menuFunctionProgramProject.Name = "menuFunctionProgramProject";
            this.menuFunctionProgramProject.Size = new System.Drawing.Size(235, 22);
            this.menuFunctionProgramProject.Text = "Function, Program && Project...";
            this.menuFunctionProgramProject.Click += new System.EventHandler(this.menuFunctionProgramProject_Click);
            // 
            // menuCollectingOfficer
            // 
            this.menuCollectingOfficer.Name = "menuCollectingOfficer";
            this.menuCollectingOfficer.Size = new System.Drawing.Size(235, 22);
            this.menuCollectingOfficer.Text = "Collecting Officer...";
            this.menuCollectingOfficer.Click += new System.EventHandler(this.menuCollectingOfficer_Click);
            // 
            // menuReports
            // 
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(59, 19);
            this.menuReports.Text = "Reports";
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
            // menuBudgetAppropriation
            // 
            this.menuBudgetAppropriation.Name = "menuBudgetAppropriation";
            this.menuBudgetAppropriation.Size = new System.Drawing.Size(235, 22);
            this.menuBudgetAppropriation.Text = "Budget Appropriations";
            this.menuBudgetAppropriation.Click += new System.EventHandler(this.menuBudgetAppropriation_Click);
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
            this.Text = "Accounting System";
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
    }
}

