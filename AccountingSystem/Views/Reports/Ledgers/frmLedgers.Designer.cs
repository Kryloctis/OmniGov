namespace AccountingSystem.Views.Reports.Ledgers
{
    partial class frmLedgers
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            tabPageSubLedger = new System.Windows.Forms.TabPage();
            tabPageSumSubLedger = new System.Windows.Forms.TabPage();
            tabPageTransactionLog = new System.Windows.Forms.TabPage();
            ucGeneralLedger1 = new ucGeneralLedger();
            ucSubsidiaryLedger1 = new ucSubsidiaryLedger();
            ucSummarySubsidiaryLedger1 = new ucSummarySubsidiaryLedger();
            ucTransactionLog1 = new ucTransactionLog();
            tabControl1.SuspendLayout();
            tabPageGeneralLedger.SuspendLayout();
            tabPageSubLedger.SuspendLayout();
            tabPageSumSubLedger.SuspendLayout();
            tabPageTransactionLog.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 466);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(761, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageGeneralLedger);
            tabControl1.Controls.Add(tabPageSubLedger);
            tabControl1.Controls.Add(tabPageSumSubLedger);
            tabControl1.Controls.Add(tabPageTransactionLog);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(761, 466);
            tabControl1.TabIndex = 1;
            // 
            // tabPageGeneralLedger
            // 
            tabPageGeneralLedger.Controls.Add(ucGeneralLedger1);
            tabPageGeneralLedger.Location = new System.Drawing.Point(4, 24);
            tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            tabPageGeneralLedger.Padding = new System.Windows.Forms.Padding(3);
            tabPageGeneralLedger.Size = new System.Drawing.Size(753, 438);
            tabPageGeneralLedger.TabIndex = 0;
            tabPageGeneralLedger.Text = "General Ledger";
            tabPageGeneralLedger.UseVisualStyleBackColor = true;
            // 
            // tabPageSubLedger
            // 
            tabPageSubLedger.Controls.Add(ucSubsidiaryLedger1);
            tabPageSubLedger.Location = new System.Drawing.Point(4, 24);
            tabPageSubLedger.Name = "tabPageSubLedger";
            tabPageSubLedger.Padding = new System.Windows.Forms.Padding(3);
            tabPageSubLedger.Size = new System.Drawing.Size(753, 438);
            tabPageSubLedger.TabIndex = 1;
            tabPageSubLedger.Text = "Subsidiary Ledger";
            tabPageSubLedger.UseVisualStyleBackColor = true;
            // 
            // tabPageSumSubLedger
            // 
            tabPageSumSubLedger.Controls.Add(ucSummarySubsidiaryLedger1);
            tabPageSumSubLedger.Location = new System.Drawing.Point(4, 24);
            tabPageSumSubLedger.Name = "tabPageSumSubLedger";
            tabPageSumSubLedger.Padding = new System.Windows.Forms.Padding(3);
            tabPageSumSubLedger.Size = new System.Drawing.Size(753, 438);
            tabPageSumSubLedger.TabIndex = 2;
            tabPageSumSubLedger.Text = "Summary Subsidiary Ledger";
            tabPageSumSubLedger.UseVisualStyleBackColor = true;
            // 
            // tabPageTransactionLog
            // 
            tabPageTransactionLog.Controls.Add(ucTransactionLog1);
            tabPageTransactionLog.Location = new System.Drawing.Point(4, 24);
            tabPageTransactionLog.Name = "tabPageTransactionLog";
            tabPageTransactionLog.Padding = new System.Windows.Forms.Padding(3);
            tabPageTransactionLog.Size = new System.Drawing.Size(753, 438);
            tabPageTransactionLog.TabIndex = 3;
            tabPageTransactionLog.Text = "Transaction Log";
            tabPageTransactionLog.UseVisualStyleBackColor = true;
            // 
            // ucGeneralLedger1
            // 
            ucGeneralLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGeneralLedger1.Location = new System.Drawing.Point(3, 3);
            ucGeneralLedger1.Name = "ucGeneralLedger1";
            ucGeneralLedger1.Size = new System.Drawing.Size(747, 432);
            ucGeneralLedger1.TabIndex = 0;
            // 
            // ucSubsidiaryLedger1
            // 
            ucSubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSubsidiaryLedger1.Location = new System.Drawing.Point(3, 3);
            ucSubsidiaryLedger1.Name = "ucSubsidiaryLedger1";
            ucSubsidiaryLedger1.Size = new System.Drawing.Size(747, 432);
            ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // ucSummarySubsidiaryLedger1
            // 
            ucSummarySubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSummarySubsidiaryLedger1.Location = new System.Drawing.Point(3, 3);
            ucSummarySubsidiaryLedger1.Name = "ucSummarySubsidiaryLedger1";
            ucSummarySubsidiaryLedger1.Size = new System.Drawing.Size(747, 432);
            ucSummarySubsidiaryLedger1.TabIndex = 0;
            // 
            // ucTransactionLog1
            // 
            ucTransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTransactionLog1.Location = new System.Drawing.Point(3, 3);
            ucTransactionLog1.Name = "ucTransactionLog1";
            ucTransactionLog1.Size = new System.Drawing.Size(747, 432);
            ucTransactionLog1.TabIndex = 0;
            // 
            // frmLedgers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(761, 488);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmLedgers";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Reports > Ledgers";
            tabControl1.ResumeLayout(false);
            tabPageGeneralLedger.ResumeLayout(false);
            tabPageSubLedger.ResumeLayout(false);
            tabPageSumSubLedger.ResumeLayout(false);
            tabPageTransactionLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneralLedger;
        private System.Windows.Forms.TabPage tabPageSubLedger;
        private System.Windows.Forms.TabPage tabPageSumSubLedger;
        private System.Windows.Forms.TabPage tabPageTransactionLog;
        private ucGeneralLedger ucGeneralLedger1;
        private ucSubsidiaryLedger ucSubsidiaryLedger1;
        private ucSummarySubsidiaryLedger ucSummarySubsidiaryLedger1;
        private ucTransactionLog ucTransactionLog1;
    }
}