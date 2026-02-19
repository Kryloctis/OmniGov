using OmniGov.App.Accounting.Views.Reports.Journals;
namespace OmniGov.App.Accounting.Views.Reports.Journals
{
    partial class frmJournalReports
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
            tabControlJournals = new System.Windows.Forms.TabControl();
            tabPageGenJrnl = new System.Windows.Forms.TabPage();
            ucGenJrnlReport1 = new ucGenJrnlReport();
            tabPageCashReceiptsJrnl = new System.Windows.Forms.TabPage();
            ucCashReceiptsJournalReport1 = new ucCashReceiptsJrnlReport();
            tabPageProcReceivedJrnl = new System.Windows.Forms.TabPage();
            ucProcurementReceivedJrnlReport1 = new ucProcurementReceivedJrnlReport();
            tabPageCashDisbursementJrnl = new System.Windows.Forms.TabPage();
            ucCashDisbursementJrnlReport1 = new ucCashDisbursementJrnlReport();
            tabPageChckDisbursementJrnl = new System.Windows.Forms.TabPage();
            ucCheckDisbursementsJrnlReport1 = new ucCheckDisbursementsJrnlReport();
            tabPageAdaDisbursementJrnl = new System.Windows.Forms.TabPage();
            ucAdadDisbursementJrnlReport1 = new ucAdadDisbursementJrnlReport();
            tabControlJournals.SuspendLayout();
            tabPageGenJrnl.SuspendLayout();
            tabPageCashReceiptsJrnl.SuspendLayout();
            tabPageProcReceivedJrnl.SuspendLayout();
            tabPageCashDisbursementJrnl.SuspendLayout();
            tabPageChckDisbursementJrnl.SuspendLayout();
            tabPageAdaDisbursementJrnl.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControlJournals
            // 
            tabControlJournals.Controls.Add(tabPageGenJrnl);
            tabControlJournals.Controls.Add(tabPageCashReceiptsJrnl);
            tabControlJournals.Controls.Add(tabPageProcReceivedJrnl);
            tabControlJournals.Controls.Add(tabPageCashDisbursementJrnl);
            tabControlJournals.Controls.Add(tabPageChckDisbursementJrnl);
            tabControlJournals.Controls.Add(tabPageAdaDisbursementJrnl);
            tabControlJournals.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlJournals.Location = new System.Drawing.Point(0, 0);
            tabControlJournals.Name = "tabControlJournals";
            tabControlJournals.SelectedIndex = 0;
            tabControlJournals.Size = new System.Drawing.Size(800, 428);
            tabControlJournals.TabIndex = 4;
            tabControlJournals.SelectedIndexChanged += tabControlJournals_SelectedIndexChanged;
            // 
            // tabPageGenJrnl
            // 
            tabPageGenJrnl.Controls.Add(ucGenJrnlReport1);
            tabPageGenJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageGenJrnl.Name = "tabPageGenJrnl";
            tabPageGenJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageGenJrnl.TabIndex = 0;
            tabPageGenJrnl.Text = "General Journal";
            tabPageGenJrnl.UseVisualStyleBackColor = true;
            // 
            // ucGenJrnlReport1
            // 
            ucGenJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGenJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucGenJrnlReport1.Name = "ucGenJrnlReport1";
            ucGenJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucGenJrnlReport1.TabIndex = 0;
            // 
            // tabPageCashReceiptsJrnl
            // 
            tabPageCashReceiptsJrnl.Controls.Add(ucCashReceiptsJournalReport1);
            tabPageCashReceiptsJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageCashReceiptsJrnl.Name = "tabPageCashReceiptsJrnl";
            tabPageCashReceiptsJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageCashReceiptsJrnl.TabIndex = 1;
            tabPageCashReceiptsJrnl.Text = "Cash Receipts Journal";
            tabPageCashReceiptsJrnl.UseVisualStyleBackColor = true;
            // 
            // ucCashReceiptsJournalReport1
            // 
            ucCashReceiptsJournalReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCashReceiptsJournalReport1.Location = new System.Drawing.Point(0, 0);
            ucCashReceiptsJournalReport1.Name = "ucCashReceiptsJournalReport1";
            ucCashReceiptsJournalReport1.Size = new System.Drawing.Size(792, 400);
            ucCashReceiptsJournalReport1.TabIndex = 5;
            // 
            // tabPageProcReceivedJrnl
            // 
            tabPageProcReceivedJrnl.Controls.Add(ucProcurementReceivedJrnlReport1);
            tabPageProcReceivedJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageProcReceivedJrnl.Name = "tabPageProcReceivedJrnl";
            tabPageProcReceivedJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageProcReceivedJrnl.TabIndex = 2;
            tabPageProcReceivedJrnl.Text = "Procurement Received Journal";
            tabPageProcReceivedJrnl.UseVisualStyleBackColor = true;
            // 
            // ucProcurementReceivedJrnlReport1
            // 
            ucProcurementReceivedJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucProcurementReceivedJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucProcurementReceivedJrnlReport1.Name = "ucProcurementReceivedJrnlReport1";
            ucProcurementReceivedJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucProcurementReceivedJrnlReport1.TabIndex = 0;
            // 
            // tabPageCashDisbursementJrnl
            // 
            tabPageCashDisbursementJrnl.Controls.Add(ucCashDisbursementJrnlReport1);
            tabPageCashDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageCashDisbursementJrnl.Name = "tabPageCashDisbursementJrnl";
            tabPageCashDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageCashDisbursementJrnl.TabIndex = 3;
            tabPageCashDisbursementJrnl.Text = "Cash Disbursements Journal";
            tabPageCashDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // ucCashDisbursementJrnlReport1
            // 
            ucCashDisbursementJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCashDisbursementJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucCashDisbursementJrnlReport1.Name = "ucCashDisbursementJrnlReport1";
            ucCashDisbursementJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucCashDisbursementJrnlReport1.TabIndex = 0;
            // 
            // tabPageChckDisbursementJrnl
            // 
            tabPageChckDisbursementJrnl.Controls.Add(ucCheckDisbursementsJrnlReport1);
            tabPageChckDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageChckDisbursementJrnl.Name = "tabPageChckDisbursementJrnl";
            tabPageChckDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageChckDisbursementJrnl.TabIndex = 4;
            tabPageChckDisbursementJrnl.Text = "Check Disbursements Journal";
            tabPageChckDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // ucCheckDisbursementsJrnlReport1
            // 
            ucCheckDisbursementsJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCheckDisbursementsJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucCheckDisbursementsJrnlReport1.Name = "ucCheckDisbursementsJrnlReport1";
            ucCheckDisbursementsJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucCheckDisbursementsJrnlReport1.TabIndex = 0;
            // 
            // tabPageAdaDisbursementJrnl
            // 
            tabPageAdaDisbursementJrnl.Controls.Add(ucAdadDisbursementJrnlReport1);
            tabPageAdaDisbursementJrnl.Location = new System.Drawing.Point(4, 24);
            tabPageAdaDisbursementJrnl.Name = "tabPageAdaDisbursementJrnl";
            tabPageAdaDisbursementJrnl.Size = new System.Drawing.Size(792, 400);
            tabPageAdaDisbursementJrnl.TabIndex = 5;
            tabPageAdaDisbursementJrnl.Text = "ADA Disbursement Journals";
            tabPageAdaDisbursementJrnl.UseVisualStyleBackColor = true;
            // 
            // ucAdadDisbursementJrnlReport1
            // 
            ucAdadDisbursementJrnlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucAdadDisbursementJrnlReport1.Location = new System.Drawing.Point(0, 0);
            ucAdadDisbursementJrnlReport1.Name = "ucAdadDisbursementJrnlReport1";
            ucAdadDisbursementJrnlReport1.Size = new System.Drawing.Size(792, 400);
            ucAdadDisbursementJrnlReport1.TabIndex = 0;
            // 
            // frmJournalReports
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(tabControlJournals);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmJournalReports";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Journals";
            Load += frmJournalReports_Load;
            tabControlJournals.ResumeLayout(false);
            tabPageGenJrnl.ResumeLayout(false);
            tabPageCashReceiptsJrnl.ResumeLayout(false);
            tabPageProcReceivedJrnl.ResumeLayout(false);
            tabPageCashDisbursementJrnl.ResumeLayout(false);
            tabPageChckDisbursementJrnl.ResumeLayout(false);
            tabPageAdaDisbursementJrnl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlJournals;
        private System.Windows.Forms.TabPage tabPageGenJrnl;
        private System.Windows.Forms.TabPage tabPageCashReceiptsJrnl;
        private System.Windows.Forms.TabPage tabPageProcReceivedJrnl;
        private System.Windows.Forms.TabPage tabPageCashDisbursementJrnl;
        private System.Windows.Forms.TabPage tabPageChckDisbursementJrnl;
        private System.Windows.Forms.TabPage tabPageAdaDisbursementJrnl;
        private ucGenJrnlReport ucGenJrnlReport1;
        private ucCashReceiptsJrnlReport ucCashReceiptsJournalReport1;
        private ucProcurementReceivedJrnlReport ucProcurementReceivedJrnlReport1;
        private ucCashDisbursementJrnlReport ucCashDisbursementJrnlReport1;
        private ucCheckDisbursementsJrnlReport ucCheckDisbursementsJrnlReport1;
        private ucAdadDisbursementJrnlReport ucAdadDisbursementJrnlReport1;
    }
}
