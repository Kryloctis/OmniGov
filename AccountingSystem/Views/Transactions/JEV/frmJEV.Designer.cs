
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class frmJEV
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
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSave = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            btnApprove = new System.Windows.Forms.ToolStripButton();
            btnDisapprove = new System.Windows.Forms.ToolStripButton();
            btnCancelJEV = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            btnPrint = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblJevStatus = new System.Windows.Forms.ToolStripStatusLabel();
            lblIsEdited = new System.Windows.Forms.ToolStripStatusLabel();
            lblShowMessage = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedBy = new System.Windows.Forms.ToolStripStatusLabel();
            panel1 = new System.Windows.Forms.Panel();
            ucjev1 = new ucJEV();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            statusStrip2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSave, btnDelete, toolStripSeparator2, btnApprove, btnDisapprove, btnCancelJEV, toolStripSeparator3, btnPrint });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(1089, 50);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save_filled_20px;
            btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(35, 39);
            btnSave.Text = "&Save";
            btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSave.Click += BtnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "&Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += BtnDelete_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // btnApprove
            // 
            btnApprove.Enabled = false;
            btnApprove.Image = Properties.Resources.document_color_green_ok_2_20px;
            btnApprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new System.Drawing.Size(56, 39);
            btnApprove.Text = "&Approve";
            btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnApprove.ToolTipText = "Approve";
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDisapprove
            // 
            btnDisapprove.Enabled = false;
            btnDisapprove.Image = Properties.Resources.document_color_red_cancel_2_20px;
            btnDisapprove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDisapprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new System.Drawing.Size(70, 39);
            btnDisapprove.Text = "&Disapprove";
            btnDisapprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDisapprove.Click += btnDisapprove_Click;
            // 
            // btnCancelJEV
            // 
            btnCancelJEV.Enabled = false;
            btnCancelJEV.Image = Properties.Resources.document_color_magenta_forbidden_20px;
            btnCancelJEV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnCancelJEV.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnCancelJEV.Name = "btnCancelJEV";
            btnCancelJEV.Size = new System.Drawing.Size(67, 39);
            btnCancelJEV.Text = "Cancel JEV";
            btnCancelJEV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnCancelJEV.Click += btnCancelJEV_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // btnPrint
            // 
            btnPrint.Enabled = false;
            btnPrint.Image = Properties.Resources.printer_filled_20px;
            btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(36, 39);
            btnPrint.Text = "&Print";
            btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnPrint.Click += btnPrint_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.Color.White;
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, lblJevStatus, lblIsEdited, lblShowMessage });
            statusStrip1.Location = new System.Drawing.Point(0, 50);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1089, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 14;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(1014, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(42, 22);
            toolStripStatusLabel2.Text = "Status:";
            // 
            // lblJevStatus
            // 
            lblJevStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            lblJevStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblJevStatus.Margin = new System.Windows.Forms.Padding(0);
            lblJevStatus.Name = "lblJevStatus";
            lblJevStatus.Size = new System.Drawing.Size(18, 22);
            lblJevStatus.Text = "--";
            // 
            // lblIsEdited
            // 
            lblIsEdited.Name = "lblIsEdited";
            lblIsEdited.Size = new System.Drawing.Size(48, 17);
            lblIsEdited.Text = "(Edited)";
            lblIsEdited.Visible = false;
            // 
            // lblShowMessage
            // 
            lblShowMessage.ActiveLinkColor = System.Drawing.Color.Firebrick;
            lblShowMessage.ForeColor = System.Drawing.Color.Firebrick;
            lblShowMessage.IsLink = true;
            lblShowMessage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lblShowMessage.LinkColor = System.Drawing.Color.Firebrick;
            lblShowMessage.Name = "lblShowMessage";
            lblShowMessage.Size = new System.Drawing.Size(88, 17);
            lblShowMessage.Text = "Show Message.";
            lblShowMessage.Visible = false;
            lblShowMessage.Click += lblShowMessage_Click;
            // 
            // statusStrip2
            // 
            statusStrip2.BackColor = System.Drawing.Color.White;
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel3, toolStripStatusLabel4, lblCreatedBy });
            statusStrip2.Location = new System.Drawing.Point(0, 632);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(1089, 22);
            statusStrip2.SizingGrip = false;
            statusStrip2.TabIndex = 15;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(980, 17);
            toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(67, 17);
            toolStripStatusLabel4.Text = "Created By:";
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new System.Drawing.Size(22, 17);
            lblCreatedBy.Text = "---";
            // 
            // panel1
            // 
            panel1.Controls.Add(ucjev1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 72);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1089, 560);
            panel1.TabIndex = 16;
            // 
            // ucjev1
            // 
            ucjev1.AutoSize = true;
            ucjev1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucjev1.Location = new System.Drawing.Point(4, 4);
            ucjev1.Name = "ucjev1";
            ucjev1.Size = new System.Drawing.Size(1081, 552);
            ucjev1.TabIndex = 12;
            // 
            // frmJEV
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(1089, 654);
            Controls.Add(panel1);
            Controls.Add(statusStrip2);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmJEV";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Journal Entry Voucher";
            Load += frmJEV_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        internal System.Windows.Forms.ToolStripButton btnPrint;
        internal System.Windows.Forms.ToolStripButton btnApprove;
        internal System.Windows.Forms.ToolStripButton btnDisapprove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        internal System.Windows.Forms.ToolStripStatusLabel lblJevStatus;
        internal System.Windows.Forms.ToolStripStatusLabel lblShowMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripButton btnCancelJEV;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedBy;
        internal System.Windows.Forms.ToolStripStatusLabel lblIsEdited;
        private System.Windows.Forms.Panel panel1;
        internal ucJEV ucjev1;
    }
}