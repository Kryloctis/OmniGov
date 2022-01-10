
namespace AccountingSystem.Views.Manage.ReturnedReceipts
{
    partial class frmReturnedReceipts
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
            this.dgReturnedReceipts = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCounts = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgReturnedReceipts)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgReturnedReceipts
            // 
            this.dgReturnedReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgReturnedReceipts.Location = new System.Drawing.Point(12, 11);
            this.dgReturnedReceipts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgReturnedReceipts.Name = "dgReturnedReceipts";
            this.dgReturnedReceipts.RowHeadersWidth = 51;
            this.dgReturnedReceipts.RowTemplate.Height = 29;
            this.dgReturnedReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReturnedReceipts.Size = new System.Drawing.Size(814, 386);
            this.dgReturnedReceipts.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCounts,
            this.toolStripStatusLabel2,
            this.lblCreatedAt,
            this.lblUpdatedAt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(838, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCounts
            // 
            this.lblRecordCounts.Name = "lblRecordCounts";
            this.lblRecordCounts.Size = new System.Drawing.Size(13, 17);
            this.lblRecordCounts.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(748, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // lblUpdatedAt
            // 
            this.lblUpdatedAt.Name = "lblUpdatedAt";
            this.lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            this.lblUpdatedAt.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // frmReturnedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(838, 421);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgReturnedReceipts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmReturnedReceipts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Returned Receipts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReturnedReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReturnedReceipts)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgReturnedReceipts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCounts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
    }
}