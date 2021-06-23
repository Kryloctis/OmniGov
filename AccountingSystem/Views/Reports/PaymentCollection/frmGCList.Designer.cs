
namespace AccountingSystem.Views.Reports.PaymentCollection
{
    partial class frmGCList
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
            this.dgvgc = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnDeposit = new System.Windows.Forms.ToolStripButton();
            this.btnRCD = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgc)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvgc
            // 
            this.dgvgc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvgc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgc.Location = new System.Drawing.Point(12, 68);
            this.dgvgc.Name = "dgvgc";
            this.dgvgc.RowHeadersWidth = 51;
            this.dgvgc.RowTemplate.Height = 29;
            this.dgvgc.Size = new System.Drawing.Size(1012, 460);
            this.dgvgc.TabIndex = 0;
            this.dgvgc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvgc_CellContentClick);
            this.dgvgc.SelectionChanged += new System.EventHandler(this.dgvgc_SelectionChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeposit,
            this.btnRCD});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip.Size = new System.Drawing.Size(1036, 65);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnDeposit
            // 
            this.btnDeposit.Enabled = false;
            this.btnDeposit.Image = global::AccountingSystem.Properties.Resources.deposit;
            this.btnDeposit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeposit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(65, 52);
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnRCD
            // 
            this.btnRCD.Enabled = false;
            this.btnRCD.Image = global::AccountingSystem.Properties.Resources.printer;
            this.btnRCD.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRCD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRCD.Name = "btnRCD";
            this.btnRCD.Size = new System.Drawing.Size(211, 52);
            this.btnRCD.Text = "Print Collections and Deposits";
            this.btnRCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRCD.ToolTipText = "Print Collections and Deposits";
            this.btnRCD.Click += new System.EventHandler(this.btnRCD_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCount,
            this.toolStripStatusLabel4});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1036, 26);
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 20);
            this.toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(17, 20);
            this.lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(939, 20);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(708, 21);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderText = "Search...";
            this.txtsearch.Size = new System.Drawing.Size(316, 27);
            this.txtsearch.TabIndex = 16;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // frmGCList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 566);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvgc);
            this.MaximizeBox = false;
            this.Name = "frmGCList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report of Collections and Deposits";
            this.Load += new System.EventHandler(this.frmGCList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvgc)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvgc;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRCD;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton btnDeposit;
        private System.Windows.Forms.TextBox txtsearch;
    }
}