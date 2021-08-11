
namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class frmLedger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioTransactionLog = new System.Windows.Forms.RadioButton();
            this.radioSubsidiaryLedger = new System.Windows.Forms.RadioButton();
            this.radioGeneralLedger = new System.Windows.Forms.RadioButton();
            this.panelReport = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radioTransactionLog);
            this.panel1.Controls.Add(this.radioSubsidiaryLedger);
            this.panel1.Controls.Add(this.radioGeneralLedger);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 47);
            this.panel1.TabIndex = 2;
            // 
            // radioTransactionLog
            // 
            this.radioTransactionLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioTransactionLog.Location = new System.Drawing.Point(268, 11);
            this.radioTransactionLog.Name = "radioTransactionLog";
            this.radioTransactionLog.Size = new System.Drawing.Size(122, 25);
            this.radioTransactionLog.TabIndex = 7;
            this.radioTransactionLog.Tag = "3";
            this.radioTransactionLog.Text = "Transaction Log";
            this.radioTransactionLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioTransactionLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioTransactionLog.UseVisualStyleBackColor = true;
            this.radioTransactionLog.CheckedChanged += new System.EventHandler(this.radioTransactionLog_CheckedChanged);
            // 
            // radioSubsidiaryLedger
            // 
            this.radioSubsidiaryLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioSubsidiaryLedger.Location = new System.Drawing.Point(140, 11);
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
            // radioGeneralLedger
            // 
            this.radioGeneralLedger.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioGeneralLedger.Checked = true;
            this.radioGeneralLedger.Location = new System.Drawing.Point(12, 11);
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
            // panelReport
            // 
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 47);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(915, 638);
            this.panelReport.TabIndex = 5;
            // 
            // frmLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 685);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ledgers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLedger_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioGeneralLedger;
        private System.Windows.Forms.RadioButton radioTransactionLog;
        private System.Windows.Forms.RadioButton radioSubsidiaryLedger;
        internal System.Windows.Forms.Panel panelReport;
    }
}