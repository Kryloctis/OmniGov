
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
            this.btnReportCollections = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucrcdDashboard1 = new AccountingSystem.Views.Dashboard.TreasuryDashboard.ucRCDSummary();
            this.SuspendLayout();
            // 
            // btnReportCollections
            // 
            this.btnReportCollections.Enabled = false;
            this.btnReportCollections.Image = global::AccountingSystem.Properties.Resources.money_banknotes_document_text_28px;
            this.btnReportCollections.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportCollections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportCollections.Name = "btnReportCollections";
            this.btnReportCollections.Size = new System.Drawing.Size(150, 32);
            this.btnReportCollections.Text = "Report of Collections";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1074, 0);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // ucrcdDashboard1
            // 
            this.ucrcdDashboard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucrcdDashboard1.Location = new System.Drawing.Point(3, 0);
            this.ucrcdDashboard1.Name = "ucrcdDashboard1";
            this.ucrcdDashboard1.Size = new System.Drawing.Size(1063, 147);
            this.ucrcdDashboard1.TabIndex = 3;
            // 
            // ucTreasuryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucrcdDashboard1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucTreasuryDashboard";
            this.Size = new System.Drawing.Size(1074, 498);
            this.Load += new System.EventHandler(this.ucTreasuryDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ToolStripButton btnReportCollections;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ucRCDSummary ucrcdDashboard1;
    }
}
