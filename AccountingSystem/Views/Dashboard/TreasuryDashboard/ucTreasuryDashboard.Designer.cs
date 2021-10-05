
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTreasuryDashboard));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnIssueCheck = new System.Windows.Forms.ToolStripButton();
            this.btnPaymentCollection = new System.Windows.Forms.ToolStripButton();
            this.btnBankDeposit = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateRCD = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIssueCheck,
            this.btnPaymentCollection,
            this.btnBankDeposit,
            this.btnGenerateRCD});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(771, 31);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnIssueCheck
            // 
            this.btnIssueCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnIssueCheck.Image")));
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
            this.btnPaymentCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentCollection.Image")));
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
            this.btnBankDeposit.Image = ((System.Drawing.Image)(resources.GetObject("btnBankDeposit.Image")));
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
            this.btnGenerateRCD.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateRCD.Image")));
            this.btnGenerateRCD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGenerateRCD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateRCD.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.btnGenerateRCD.Name = "btnGenerateRCD";
            this.btnGenerateRCD.Size = new System.Drawing.Size(108, 28);
            this.btnGenerateRCD.Text = "Generate RCD";
            this.btnGenerateRCD.Click += new System.EventHandler(this.btnGenerateRCD_Click);
            // 
            // ucTreasuryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip2);
            this.Name = "ucTreasuryDashboard";
            this.Size = new System.Drawing.Size(771, 391);
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
    }
}
