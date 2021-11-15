
namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    partial class ucTreasuryDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnReceipts = new System.Windows.Forms.ToolStripButton();
            this.btnIssueReceipt = new System.Windows.Forms.ToolStripButton();
            this.btnIssueCheck = new System.Windows.Forms.ToolStripButton();
            this.btnPaymentCollection = new System.Windows.Forms.ToolStripButton();
            this.btnBankDeposit = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateRCD = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnCollectorsReport = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 360);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // btnReceipts
            // 
            this.btnReceipts.Image = global::AccountingSystem.Properties.Resources.document_delivery_receipt_signed_24px;
            this.btnReceipts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReceipts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceipts.Name = "btnReceipts";
            this.btnReceipts.Size = new System.Drawing.Size(79, 28);
            this.btnReceipts.Text = "Receipts";
            this.btnReceipts.Click += new System.EventHandler(this.btnReceipts_Click);
            // 
            // btnIssueReceipt
            // 
            this.btnIssueReceipt.Image = global::AccountingSystem.Properties.Resources.document_delivery_receipt_user_24px;
            this.btnIssueReceipt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIssueReceipt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIssueReceipt.Name = "btnIssueReceipt";
            this.btnIssueReceipt.Size = new System.Drawing.Size(108, 28);
            this.btnIssueReceipt.Text = "Issue Receipts";
            this.btnIssueReceipt.Click += new System.EventHandler(this.btnIssueReceipt_Click);
            // 
            // btnIssueCheck
            // 
            this.btnIssueCheck.Image = global::AccountingSystem.Properties.Resources.check_24px;
            this.btnIssueCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIssueCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIssueCheck.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnIssueCheck.Name = "btnIssueCheck";
            this.btnIssueCheck.Size = new System.Drawing.Size(97, 28);
            this.btnIssueCheck.Text = "Issue Check";
            this.btnIssueCheck.Click += new System.EventHandler(this.BtnRCI_Click);
            // 
            // btnPaymentCollection
            // 
            this.btnPaymentCollection.Image = global::AccountingSystem.Properties.Resources.money_banknote_archive_24px;
            this.btnPaymentCollection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPaymentCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaymentCollection.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnPaymentCollection.Name = "btnPaymentCollection";
            this.btnPaymentCollection.Size = new System.Drawing.Size(139, 28);
            this.btnPaymentCollection.Text = "Payment Collection";
            this.btnPaymentCollection.Click += new System.EventHandler(this.btnPaymentCollection_Click);
            // 
            // btnBankDeposit
            // 
            this.btnBankDeposit.Image = global::AccountingSystem.Properties.Resources.bank_deposit_24px;
            this.btnBankDeposit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBankDeposit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBankDeposit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnBankDeposit.Name = "btnBankDeposit";
            this.btnBankDeposit.Size = new System.Drawing.Size(104, 28);
            this.btnBankDeposit.Text = "Bank Deposit";
            this.btnBankDeposit.Click += new System.EventHandler(this.btnBankDeposit_Click);
            // 
            // btnGenerateRCD
            // 
            this.btnGenerateRCD.Image = global::AccountingSystem.Properties.Resources.report_24px;
            this.btnGenerateRCD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGenerateRCD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateRCD.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnGenerateRCD.Name = "btnGenerateRCD";
            this.btnGenerateRCD.Size = new System.Drawing.Size(108, 28);
            this.btnGenerateRCD.Text = "Generate RCD";
            this.btnGenerateRCD.Click += new System.EventHandler(this.btnGenerateRCD_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReceipts,
            this.btnIssueReceipt,
            this.btnIssueCheck,
            this.btnPaymentCollection,
            this.btnCollectorsReport,
            this.btnBankDeposit,
            this.btnGenerateRCD});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(797, 31);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnCollectorsReport
            // 
            this.btnCollectorsReport.Image = global::AccountingSystem.Properties.Resources.budget_approprations_24px;
            this.btnCollectorsReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCollectorsReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollectorsReport.Name = "btnCollectorsReport";
            this.btnCollectorsReport.Size = new System.Drawing.Size(129, 28);
            this.btnCollectorsReport.Text = "Collector\'s Report";
            // 
            // ucTreasuryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ucTreasuryDashboard";
            this.Size = new System.Drawing.Size(797, 391);
            this.Load += new System.EventHandler(this.ucTreasuryDashboard_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        internal System.Windows.Forms.ToolStripButton btnIssueCheck;
        internal System.Windows.Forms.ToolStripButton btnPaymentCollection;
        internal System.Windows.Forms.ToolStripButton btnBankDeposit;
        internal System.Windows.Forms.ToolStripButton btnGenerateRCD;
        internal System.Windows.Forms.ToolStripButton btnIssueReceipt;
        internal System.Windows.Forms.ToolStripButton btnReceipts;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.ToolStripButton btnCollectorsReport;
    }
}
