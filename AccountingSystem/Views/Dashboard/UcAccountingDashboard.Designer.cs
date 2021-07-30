
namespace AccountingSystem.Views.Dashboard
{
    partial class UcAccountingDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAccountingDashboard));
            this.tlpJournals = new System.Windows.Forms.TableLayoutPanel();
            this.pnlJEV = new System.Windows.Forms.Panel();
            this.lnkJEV = new System.Windows.Forms.LinkLabel();
            this.lblJEVCounter = new System.Windows.Forms.Label();
            this.pnlPendingJEV = new System.Windows.Forms.Panel();
            this.lnkPending = new System.Windows.Forms.LinkLabel();
            this.lblPendingJEVCounter = new System.Windows.Forms.Label();
            this.pnlApprovedJEV = new System.Windows.Forms.Panel();
            this.lnkApproved = new System.Windows.Forms.LinkLabel();
            this.lblApprovedJEVCounter = new System.Windows.Forms.Label();
            this.btnRefreshCounter = new System.Windows.Forms.Button();
            this.tlpJournals.SuspendLayout();
            this.pnlJEV.SuspendLayout();
            this.pnlPendingJEV.SuspendLayout();
            this.pnlApprovedJEV.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpJournals
            // 
            this.tlpJournals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpJournals.AutoSize = true;
            this.tlpJournals.ColumnCount = 3;
            this.tlpJournals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpJournals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpJournals.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpJournals.Controls.Add(this.pnlJEV, 0, 0);
            this.tlpJournals.Controls.Add(this.pnlPendingJEV, 1, 0);
            this.tlpJournals.Controls.Add(this.pnlApprovedJEV, 2, 0);
            this.tlpJournals.Location = new System.Drawing.Point(2, 32);
            this.tlpJournals.Name = "tlpJournals";
            this.tlpJournals.RowCount = 1;
            this.tlpJournals.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJournals.Size = new System.Drawing.Size(1093, 119);
            this.tlpJournals.TabIndex = 12;
            // 
            // pnlJEV
            // 
            this.pnlJEV.BackColor = System.Drawing.Color.White;
            this.pnlJEV.Controls.Add(this.lnkJEV);
            this.pnlJEV.Controls.Add(this.lblJEVCounter);
            this.pnlJEV.Location = new System.Drawing.Point(3, 3);
            this.pnlJEV.MaximumSize = new System.Drawing.Size(150, 113);
            this.pnlJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlJEV.Name = "pnlJEV";
            this.pnlJEV.Size = new System.Drawing.Size(150, 113);
            this.pnlJEV.TabIndex = 18;
            // 
            // lnkJEV
            // 
            this.lnkJEV.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkJEV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkJEV.AutoSize = true;
            this.lnkJEV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkJEV.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkJEV.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkJEV.Location = new System.Drawing.Point(62, 68);
            this.lnkJEV.Name = "lnkJEV";
            this.lnkJEV.Size = new System.Drawing.Size(24, 15);
            this.lnkJEV.TabIndex = 15;
            this.lnkJEV.TabStop = true;
            this.lnkJEV.Text = "JEV";
            this.lnkJEV.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJEV_LinkClicked);
            // 
            // lblJEVCounter
            // 
            this.lblJEVCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJEVCounter.Location = new System.Drawing.Point(0, 15);
            this.lblJEVCounter.Name = "lblJEVCounter";
            this.lblJEVCounter.Size = new System.Drawing.Size(153, 40);
            this.lblJEVCounter.TabIndex = 6;
            this.lblJEVCounter.Text = "0";
            this.lblJEVCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlPendingJEV
            // 
            this.pnlPendingJEV.BackColor = System.Drawing.Color.White;
            this.pnlPendingJEV.Controls.Add(this.lnkPending);
            this.pnlPendingJEV.Controls.Add(this.lblPendingJEVCounter);
            this.pnlPendingJEV.Location = new System.Drawing.Point(159, 3);
            this.pnlPendingJEV.MaximumSize = new System.Drawing.Size(150, 113);
            this.pnlPendingJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlPendingJEV.Name = "pnlPendingJEV";
            this.pnlPendingJEV.Size = new System.Drawing.Size(150, 113);
            this.pnlPendingJEV.TabIndex = 17;
            // 
            // lnkPending
            // 
            this.lnkPending.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkPending.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkPending.AutoSize = true;
            this.lnkPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPending.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkPending.Location = new System.Drawing.Point(38, 68);
            this.lnkPending.Name = "lnkPending";
            this.lnkPending.Size = new System.Drawing.Size(76, 15);
            this.lnkPending.TabIndex = 15;
            this.lnkPending.TabStop = true;
            this.lnkPending.Text = "Pending JEVs";
            this.lnkPending.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPending_LinkClicked);
            // 
            // lblPendingJEVCounter
            // 
            this.lblPendingJEVCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPendingJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPendingJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPendingJEVCounter.Location = new System.Drawing.Point(0, 15);
            this.lblPendingJEVCounter.Name = "lblPendingJEVCounter";
            this.lblPendingJEVCounter.Size = new System.Drawing.Size(153, 40);
            this.lblPendingJEVCounter.TabIndex = 6;
            this.lblPendingJEVCounter.Text = "0";
            this.lblPendingJEVCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlApprovedJEV
            // 
            this.pnlApprovedJEV.BackColor = System.Drawing.Color.White;
            this.pnlApprovedJEV.Controls.Add(this.lnkApproved);
            this.pnlApprovedJEV.Controls.Add(this.lblApprovedJEVCounter);
            this.pnlApprovedJEV.Location = new System.Drawing.Point(315, 3);
            this.pnlApprovedJEV.MaximumSize = new System.Drawing.Size(150, 113);
            this.pnlApprovedJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlApprovedJEV.Name = "pnlApprovedJEV";
            this.pnlApprovedJEV.Size = new System.Drawing.Size(150, 113);
            this.pnlApprovedJEV.TabIndex = 16;
            // 
            // lnkApproved
            // 
            this.lnkApproved.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkApproved.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkApproved.AutoSize = true;
            this.lnkApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkApproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkApproved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkApproved.Location = new System.Drawing.Point(33, 68);
            this.lnkApproved.Name = "lnkApproved";
            this.lnkApproved.Size = new System.Drawing.Size(84, 15);
            this.lnkApproved.TabIndex = 14;
            this.lnkApproved.TabStop = true;
            this.lnkApproved.Text = "Approved JEVs";
            this.lnkApproved.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkApproved_LinkClicked);
            // 
            // lblApprovedJEVCounter
            // 
            this.lblApprovedJEVCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApprovedJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApprovedJEVCounter.Location = new System.Drawing.Point(0, 15);
            this.lblApprovedJEVCounter.Name = "lblApprovedJEVCounter";
            this.lblApprovedJEVCounter.Size = new System.Drawing.Size(153, 40);
            this.lblApprovedJEVCounter.TabIndex = 6;
            this.lblApprovedJEVCounter.Text = "0";
            this.lblApprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRefreshCounter
            // 
            this.btnRefreshCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshCounter.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshCounter.Image")));
            this.btnRefreshCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshCounter.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshCounter.Name = "btnRefreshCounter";
            this.btnRefreshCounter.Size = new System.Drawing.Size(135, 23);
            this.btnRefreshCounter.TabIndex = 13;
            this.btnRefreshCounter.Text = "Refresh Counter";
            this.btnRefreshCounter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshCounter.UseVisualStyleBackColor = true;
            this.btnRefreshCounter.Click += new System.EventHandler(this.btnRefreshCounter_Click);
            // 
            // UcAccountingDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnRefreshCounter);
            this.Controls.Add(this.tlpJournals);
            this.Name = "UcAccountingDashboard";
            this.Size = new System.Drawing.Size(1098, 154);
            this.Load += new System.EventHandler(this.UcAccountingDashboard_Load);
            this.tlpJournals.ResumeLayout(false);
            this.pnlJEV.ResumeLayout(false);
            this.pnlJEV.PerformLayout();
            this.pnlPendingJEV.ResumeLayout(false);
            this.pnlPendingJEV.PerformLayout();
            this.pnlApprovedJEV.ResumeLayout(false);
            this.pnlApprovedJEV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpJournals;
        internal System.Windows.Forms.Label lblPSAllotmentRelease;
        internal System.Windows.Forms.Label lblPSunobligatedBalance;
        private System.Windows.Forms.Button btnRefreshCounter;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        internal System.Windows.Forms.Label lblApprovedJEVCounter;
        private System.Windows.Forms.Panel pnlPendingJEV;
        internal System.Windows.Forms.Label lblPendingJEVCounter;
        private System.Windows.Forms.Panel pnlJEV;
        internal System.Windows.Forms.Label lblJEVCounter;
        private System.Windows.Forms.LinkLabel lnkApproved;
        private System.Windows.Forms.LinkLabel lnkPending;
        private System.Windows.Forms.LinkLabel lnkJEV;
    }
}
