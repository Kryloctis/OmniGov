namespace LFS.Views.Reports.Ledgers
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
            tabControlLedgers = new System.Windows.Forms.TabControl();
            tabPageGeneralLedger = new System.Windows.Forms.TabPage();
            ucGeneralLedger1 = new ucGeneralLedger();
            tabPageSubLedger = new System.Windows.Forms.TabPage();
            ucSubsidiaryLedger1 = new ucSubsidiaryLedger();
            tabPageSumSubLedger = new System.Windows.Forms.TabPage();
            ucSummarySubsidiaryLedger1 = new ucSummarySubsidiaryLedger();
            tabPageTransactionLog = new System.Windows.Forms.TabPage();
            ucTransactionLog1 = new ucTransactionLog();
            tabControlLedgers.SuspendLayout();
            tabPageGeneralLedger.SuspendLayout();
            tabPageSubLedger.SuspendLayout();
            tabPageSumSubLedger.SuspendLayout();
            tabPageTransactionLog.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(886, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControlLedgers
            // 
            tabControlLedgers.Controls.Add(tabPageGeneralLedger);
            tabControlLedgers.Controls.Add(tabPageSubLedger);
            tabControlLedgers.Controls.Add(tabPageSumSubLedger);
            tabControlLedgers.Controls.Add(tabPageTransactionLog);
            tabControlLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlLedgers.Location = new System.Drawing.Point(0, 0);
            tabControlLedgers.Name = "tabControlLedgers";
            tabControlLedgers.SelectedIndex = 0;
            tabControlLedgers.Size = new System.Drawing.Size(886, 454);
            tabControlLedgers.TabIndex = 1;
            tabControlLedgers.SelectedIndexChanged += tabControlLedgers_SelectedIndexChanged;
            // 
            // tabPageGeneralLedger
            // 
            tabPageGeneralLedger.Controls.Add(ucGeneralLedger1);
            tabPageGeneralLedger.Location = new System.Drawing.Point(4, 24);
            tabPageGeneralLedger.Name = "tabPageGeneralLedger";
            tabPageGeneralLedger.Size = new System.Drawing.Size(878, 426);
            tabPageGeneralLedger.TabIndex = 0;
            tabPageGeneralLedger.Text = "General Ledger";
            tabPageGeneralLedger.UseVisualStyleBackColor = true;
            // 
            // ucGeneralLedger1
            // 
            ucGeneralLedger1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucGeneralLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGeneralLedger1.Location = new System.Drawing.Point(0, 0);
            ucGeneralLedger1.Name = "ucGeneralLedger1";
            ucGeneralLedger1.Size = new System.Drawing.Size(878, 426);
            ucGeneralLedger1.TabIndex = 0;
            // 
            // tabPageSubLedger
            // 
            tabPageSubLedger.Controls.Add(ucSubsidiaryLedger1);
            tabPageSubLedger.Location = new System.Drawing.Point(4, 24);
            tabPageSubLedger.Name = "tabPageSubLedger";
            tabPageSubLedger.Size = new System.Drawing.Size(878, 426);
            tabPageSubLedger.TabIndex = 1;
            tabPageSubLedger.Text = "Subsidiary Ledger";
            tabPageSubLedger.UseVisualStyleBackColor = true;
            // 
            // ucSubsidiaryLedger1
            // 
            ucSubsidiaryLedger1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucSubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSubsidiaryLedger1.Location = new System.Drawing.Point(0, 0);
            ucSubsidiaryLedger1.Name = "ucSubsidiaryLedger1";
            ucSubsidiaryLedger1.Size = new System.Drawing.Size(878, 426);
            ucSubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageSumSubLedger
            // 
            tabPageSumSubLedger.Controls.Add(ucSummarySubsidiaryLedger1);
            tabPageSumSubLedger.Location = new System.Drawing.Point(4, 24);
            tabPageSumSubLedger.Name = "tabPageSumSubLedger";
            tabPageSumSubLedger.Size = new System.Drawing.Size(878, 426);
            tabPageSumSubLedger.TabIndex = 2;
            tabPageSumSubLedger.Text = "Summary Subsidiary Ledger";
            tabPageSumSubLedger.UseVisualStyleBackColor = true;
            // 
            // ucSummarySubsidiaryLedger1
            // 
            ucSummarySubsidiaryLedger1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucSummarySubsidiaryLedger1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSummarySubsidiaryLedger1.Location = new System.Drawing.Point(0, 0);
            ucSummarySubsidiaryLedger1.Name = "ucSummarySubsidiaryLedger1";
            ucSummarySubsidiaryLedger1.Size = new System.Drawing.Size(878, 426);
            ucSummarySubsidiaryLedger1.TabIndex = 0;
            // 
            // tabPageTransactionLog
            // 
            tabPageTransactionLog.Controls.Add(ucTransactionLog1);
            tabPageTransactionLog.Location = new System.Drawing.Point(4, 24);
            tabPageTransactionLog.Name = "tabPageTransactionLog";
            tabPageTransactionLog.Size = new System.Drawing.Size(878, 426);
            tabPageTransactionLog.TabIndex = 3;
            tabPageTransactionLog.Text = "Transaction Log";
            tabPageTransactionLog.UseVisualStyleBackColor = true;
            // 
            // ucTransactionLog1
            // 
            ucTransactionLog1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucTransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTransactionLog1.Location = new System.Drawing.Point(0, 0);
            ucTransactionLog1.Name = "ucTransactionLog1";
            ucTransactionLog1.Size = new System.Drawing.Size(878, 426);
            ucTransactionLog1.TabIndex = 0;
            // 
            // frmLedgers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(886, 476);
            Controls.Add(tabControlLedgers);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmLedgers";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Ledgers";
            Load += frmLedgers_Load;
            tabControlLedgers.ResumeLayout(false);
            tabPageGeneralLedger.ResumeLayout(false);
            tabPageSubLedger.ResumeLayout(false);
            tabPageSumSubLedger.ResumeLayout(false);
            tabPageTransactionLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlLedgers;
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
