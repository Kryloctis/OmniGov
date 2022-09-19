
namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount
{
    partial class frmRealPropertyTaxStatementOfAccount
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFindOwner = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFindOwner});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Size = new System.Drawing.Size(1141, 58);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFindOwner
            // 
            this.btnFindOwner.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFindOwner.Image = global::AccountingSystem.Properties.Resources.user_browse_28px;
            this.btnFindOwner.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFindOwner.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnFindOwner.Name = "btnFindOwner";
            this.btnFindOwner.Size = new System.Drawing.Size(72, 47);
            this.btnFindOwner.Text = "Find Owner";
            this.btnFindOwner.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnFindOwner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFindOwner.Click += new System.EventHandler(this.btnFindOwner_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1141, 581);
            this.panel1.TabIndex = 2;
            // 
            // frmRealPropertyTaxStatementOfAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmRealPropertyTaxStatementOfAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report > Collection/Payment > Real Property Tax Statement of Account";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFindOwner;
        private System.Windows.Forms.Panel panel1;
    }
}