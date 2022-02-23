
namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    partial class frmCollectorsRCD
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
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsApproveSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.btnDisapprove = new System.Windows.Forms.ToolStripButton();
            this.tsDisapproveSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnCancelPrint = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblReportStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblShowMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucCollectorsRCD1 = new AccountingSystem.Views.Reports.RCDCollector.ucCollectorsRCD();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnDelete,
            this.tsApproveSeparator,
            this.btnApprove,
            this.btnDisapprove,
            this.tsDisapproveSeparator,
            this.btnPrint,
            this.btnCancelPrint,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 50);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AccountingSystem.Properties.Resources.save28px;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 47);
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.TextChanged += new System.EventHandler(this.btnSave_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::AccountingSystem.Properties.Resources.delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tsApproveSeparator
            // 
            this.tsApproveSeparator.Name = "tsApproveSeparator";
            this.tsApproveSeparator.Size = new System.Drawing.Size(6, 50);
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Image = global::AccountingSystem.Properties.Resources.document_approve_28px;
            this.btnApprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(56, 47);
            this.btnApprove.Text = "&Approve";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApprove.ToolTipText = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Enabled = false;
            this.btnDisapprove.Image = global::AccountingSystem.Properties.Resources.document_disapprove_28px;
            this.btnDisapprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDisapprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(70, 47);
            this.btnDisapprove.Text = "&Disapprove";
            this.btnDisapprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // tsDisapproveSeparator
            // 
            this.tsDisapproveSeparator.Name = "tsDisapproveSeparator";
            this.tsDisapproveSeparator.Size = new System.Drawing.Size(6, 50);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::AccountingSystem.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(36, 47);
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancelPrint
            // 
            this.btnCancelPrint.Enabled = false;
            this.btnCancelPrint.Image = global::AccountingSystem.Properties.Resources.symbol_cancel_28px;
            this.btnCancelPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelPrint.Name = "btnCancelPrint";
            this.btnCancelPrint.Size = new System.Drawing.Size(47, 47);
            this.btnCancelPrint.Text = "Cancel";
            this.btnCancelPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelPrint.Click += new System.EventHandler(this.btnCancelPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Image = global::AccountingSystem.Properties.Resources.find_doc;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 47);
            this.btnSearch.Text = "S&earch";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.lblReportStatus,
            this.lblShowMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 50);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(916, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(841, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripStatusLabel2.Text = "Status:";
            // 
            // lblReportStatus
            // 
            this.lblReportStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblReportStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReportStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblReportStatus.Name = "lblReportStatus";
            this.lblReportStatus.Size = new System.Drawing.Size(18, 22);
            this.lblReportStatus.Text = "--";
            // 
            // lblShowMessage
            // 
            this.lblShowMessage.ActiveLinkColor = System.Drawing.Color.Firebrick;
            this.lblShowMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.lblShowMessage.IsLink = true;
            this.lblShowMessage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblShowMessage.Name = "lblShowMessage";
            this.lblShowMessage.Size = new System.Drawing.Size(88, 17);
            this.lblShowMessage.Text = "Show Message.";
            this.lblShowMessage.Visible = false;
            this.lblShowMessage.Click += new System.EventHandler(this.lblShowMessage_Click);
            // 
            // ucCollectorsRCD1
            // 
            this.ucCollectorsRCD1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucCollectorsRCD1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCollectorsRCD1.Location = new System.Drawing.Point(0, 72);
            this.ucCollectorsRCD1.Name = "ucCollectorsRCD1";
            this.ucCollectorsRCD1.Size = new System.Drawing.Size(916, 521);
            this.ucCollectorsRCD1.TabIndex = 16;
            // 
            // frmCollectorsRCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(916, 593);
            this.Controls.Add(this.ucCollectorsRCD1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "frmCollectorsRCD";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector\'s Report of Collections and Deposits (RCD)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CollectorsRCD_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator tsApproveSeparator;
        internal System.Windows.Forms.ToolStripButton btnApprove;
        internal System.Windows.Forms.ToolStripButton btnDisapprove;
        private System.Windows.Forms.ToolStripSeparator tsDisapproveSeparator;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblShowMessage;
        internal System.Windows.Forms.ToolStripStatusLabel lblReportStatus;
        internal RCDCollector.ucCollectorsRCD ucCollectorsRCD1;
        internal System.Windows.Forms.ToolStripButton btnCancelPrint;
    }
}