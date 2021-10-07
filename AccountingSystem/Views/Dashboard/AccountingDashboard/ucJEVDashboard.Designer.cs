
namespace AccountingSystem.Views.Dashboard
{
    partial class ucJEVDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucJEVDashboard));
            this.btnRefreshCounter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPendingJEV = new System.Windows.Forms.Panel();
            this.lnkPending = new System.Windows.Forms.LinkLabel();
            this.lblPendingJEVCounter = new System.Windows.Forms.Label();
            this.pnlApprovedJEV = new System.Windows.Forms.Panel();
            this.lnkApproved = new System.Windows.Forms.LinkLabel();
            this.lblApprovedJEVCounter = new System.Windows.Forms.Label();
            this.pnlJEV = new System.Windows.Forms.Panel();
            this.lnkJEV = new System.Windows.Forms.LinkLabel();
            this.lblJEVCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkDisapproved = new System.Windows.Forms.LinkLabel();
            this.lblDisapprovedJEVCounter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkCancelled = new System.Windows.Forms.LinkLabel();
            this.lblCancelledJEVCounter = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddJEV = new System.Windows.Forms.Button();
            this.cmbxJournals = new System.Windows.Forms.ComboBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPendingJEV.SuspendLayout();
            this.pnlApprovedJEV.SuspendLayout();
            this.pnlJEV.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshCounter
            // 
            this.btnRefreshCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefreshCounter.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshCounter.Image")));
            this.btnRefreshCounter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshCounter.Location = new System.Drawing.Point(657, 3);
            this.btnRefreshCounter.Name = "btnRefreshCounter";
            this.btnRefreshCounter.Size = new System.Drawing.Size(92, 23);
            this.btnRefreshCounter.TabIndex = 13;
            this.btnRefreshCounter.Text = "Refresh";
            this.btnRefreshCounter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshCounter.UseVisualStyleBackColor = true;
            this.btnRefreshCounter.Click += new System.EventHandler(this.btnRefreshCounter_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlPendingJEV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlApprovedJEV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlJEV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(781, 121);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 131);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // pnlPendingJEV
            // 
            this.pnlPendingJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPendingJEV.Controls.Add(this.lnkPending);
            this.pnlPendingJEV.Controls.Add(this.lblPendingJEVCounter);
            this.pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendingJEV.Location = new System.Drawing.Point(315, 13);
            this.pnlPendingJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlPendingJEV.Name = "pnlPendingJEV";
            this.pnlPendingJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlPendingJEV.TabIndex = 29;
            // 
            // lnkPending
            // 
            this.lnkPending.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPending.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPending.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkPending.Location = new System.Drawing.Point(0, 61);
            this.lnkPending.Name = "lnkPending";
            this.lnkPending.Size = new System.Drawing.Size(150, 23);
            this.lnkPending.TabIndex = 15;
            this.lnkPending.TabStop = true;
            this.lnkPending.Text = "Pending JEVs";
            this.lnkPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkPending.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPending_LinkClicked);
            // 
            // lblPendingJEVCounter
            // 
            this.lblPendingJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPendingJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPendingJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPendingJEVCounter.Location = new System.Drawing.Point(0, 0);
            this.lblPendingJEVCounter.Name = "lblPendingJEVCounter";
            this.lblPendingJEVCounter.Size = new System.Drawing.Size(150, 61);
            this.lblPendingJEVCounter.TabIndex = 6;
            this.lblPendingJEVCounter.Text = "0";
            this.lblPendingJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            this.pnlApprovedJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlApprovedJEV.Controls.Add(this.lnkApproved);
            this.pnlApprovedJEV.Controls.Add(this.lblApprovedJEVCounter);
            this.pnlApprovedJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApprovedJEV.Location = new System.Drawing.Point(159, 13);
            this.pnlApprovedJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlApprovedJEV.Name = "pnlApprovedJEV";
            this.pnlApprovedJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkApproved
            // 
            this.lnkApproved.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkApproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkApproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkApproved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkApproved.Location = new System.Drawing.Point(0, 61);
            this.lnkApproved.Name = "lnkApproved";
            this.lnkApproved.Size = new System.Drawing.Size(150, 23);
            this.lnkApproved.TabIndex = 14;
            this.lnkApproved.TabStop = true;
            this.lnkApproved.Text = "Approved JEVs";
            this.lnkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkApproved.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkApproved_LinkClicked);
            // 
            // lblApprovedJEVCounter
            // 
            this.lblApprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblApprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApprovedJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            this.lblApprovedJEVCounter.Name = "lblApprovedJEVCounter";
            this.lblApprovedJEVCounter.Size = new System.Drawing.Size(150, 61);
            this.lblApprovedJEVCounter.TabIndex = 6;
            this.lblApprovedJEVCounter.Text = "0";
            this.lblApprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            this.pnlJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlJEV.Controls.Add(this.lnkJEV);
            this.pnlJEV.Controls.Add(this.lblJEVCounter);
            this.pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJEV.Location = new System.Drawing.Point(3, 13);
            this.pnlJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlJEV.Name = "pnlJEV";
            this.pnlJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlJEV.TabIndex = 26;
            // 
            // lnkJEV
            // 
            this.lnkJEV.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkJEV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkJEV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkJEV.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkJEV.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkJEV.Location = new System.Drawing.Point(0, 61);
            this.lnkJEV.Name = "lnkJEV";
            this.lnkJEV.Size = new System.Drawing.Size(150, 23);
            this.lnkJEV.TabIndex = 15;
            this.lnkJEV.TabStop = true;
            this.lnkJEV.Text = "JEV";
            this.lnkJEV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJEVCounter
            // 
            this.lblJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJEVCounter.Location = new System.Drawing.Point(0, 0);
            this.lblJEVCounter.Name = "lblJEVCounter";
            this.lblJEVCounter.Size = new System.Drawing.Size(150, 61);
            this.lblJEVCounter.TabIndex = 6;
            this.lblJEVCounter.Text = "0";
            this.lblJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.linkDisapproved);
            this.panel1.Controls.Add(this.lblDisapprovedJEVCounter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(471, 13);
            this.panel1.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 115);
            this.panel1.TabIndex = 22;
            // 
            // linkDisapproved
            // 
            this.linkDisapproved.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkDisapproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkDisapproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDisapproved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkDisapproved.Location = new System.Drawing.Point(0, 61);
            this.linkDisapproved.Name = "linkDisapproved";
            this.linkDisapproved.Size = new System.Drawing.Size(150, 23);
            this.linkDisapproved.TabIndex = 16;
            this.linkDisapproved.TabStop = true;
            this.linkDisapproved.Text = "Disapproved";
            this.linkDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkDisapproved.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDisapproved_LinkClicked);
            // 
            // lblDisapprovedJEVCounter
            // 
            this.lblDisapprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisapprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDisapprovedJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDisapprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            this.lblDisapprovedJEVCounter.Name = "lblDisapprovedJEVCounter";
            this.lblDisapprovedJEVCounter.Size = new System.Drawing.Size(150, 61);
            this.lblDisapprovedJEVCounter.TabIndex = 6;
            this.lblDisapprovedJEVCounter.Text = "0";
            this.lblDisapprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lnkCancelled);
            this.panel2.Controls.Add(this.lblCancelledJEVCounter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(627, 13);
            this.panel2.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 115);
            this.panel2.TabIndex = 23;
            // 
            // lnkCancelled
            // 
            this.lnkCancelled.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnkCancelled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkCancelled.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCancelled.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCancelled.Location = new System.Drawing.Point(0, 61);
            this.lnkCancelled.Name = "lnkCancelled";
            this.lnkCancelled.Size = new System.Drawing.Size(152, 23);
            this.lnkCancelled.TabIndex = 15;
            this.lnkCancelled.TabStop = true;
            this.lnkCancelled.Text = "Cancelled JEVs";
            this.lnkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkCancelled.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCancelled_LinkClicked);
            // 
            // lblCancelledJEVCounter
            // 
            this.lblCancelledJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCancelledJEVCounter.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCancelledJEVCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCancelledJEVCounter.Location = new System.Drawing.Point(0, 0);
            this.lblCancelledJEVCounter.Name = "lblCancelledJEVCounter";
            this.lblCancelledJEVCounter.Size = new System.Drawing.Size(152, 61);
            this.lblCancelledJEVCounter.TabIndex = 6;
            this.lblCancelledJEVCounter.Text = "0";
            this.lblCancelledJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddJEV);
            this.flowLayoutPanel1.Controls.Add(this.cmbxJournals);
            this.flowLayoutPanel1.Controls.Add(this.cbMonth);
            this.flowLayoutPanel1.Controls.Add(this.nudYear);
            this.flowLayoutPanel1.Controls.Add(this.btnRefreshCounter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(782, 29);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnAddJEV
            // 
            this.btnAddJEV.Image = global::AccountingSystem.Properties.Resources.symbol_add_14px;
            this.btnAddJEV.Location = new System.Drawing.Point(3, 3);
            this.btnAddJEV.Name = "btnAddJEV";
            this.btnAddJEV.Size = new System.Drawing.Size(92, 23);
            this.btnAddJEV.TabIndex = 31;
            this.btnAddJEV.Text = "Add";
            this.btnAddJEV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddJEV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddJEV.UseVisualStyleBackColor = true;
            this.btnAddJEV.Click += new System.EventHandler(this.btnAddJEV_Click);
            // 
            // cmbxJournals
            // 
            this.cmbxJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxJournals.FormattingEnabled = true;
            this.cmbxJournals.Location = new System.Drawing.Point(101, 3);
            this.cmbxJournals.Name = "cmbxJournals";
            this.cmbxJournals.Size = new System.Drawing.Size(275, 23);
            this.cmbxJournals.TabIndex = 30;
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(382, 3);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(154, 23);
            this.cbMonth.TabIndex = 28;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // nudYear
            // 
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Location = new System.Drawing.Point(542, 3);
            this.nudYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1987,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.ReadOnly = true;
            this.nudYear.Size = new System.Drawing.Size(109, 23);
            this.nudYear.TabIndex = 29;
            this.nudYear.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);
            // 
            // ucJEVDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(782, 160);
            this.Name = "ucJEVDashboard";
            this.Size = new System.Drawing.Size(782, 160);
            this.Load += new System.EventHandler(this.UcAccountingDashboard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlPendingJEV.ResumeLayout(false);
            this.pnlApprovedJEV.ResumeLayout(false);
            this.pnlJEV.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lblPSAllotmentRelease;
        internal System.Windows.Forms.Label lblPSunobligatedBalance;
        private System.Windows.Forms.Button btnRefreshCounter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblDisapprovedJEVCounter;
        private System.Windows.Forms.LinkLabel linkDisapproved;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cmbxJournals;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.LinkLabel lnkCancelled;
        internal System.Windows.Forms.Label lblCancelledJEVCounter;
        private System.Windows.Forms.Panel pnlPendingJEV;
        private System.Windows.Forms.LinkLabel lnkPending;
        internal System.Windows.Forms.Label lblPendingJEVCounter;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        private System.Windows.Forms.LinkLabel lnkApproved;
        internal System.Windows.Forms.Label lblApprovedJEVCounter;
        private System.Windows.Forms.Panel pnlJEV;
        private System.Windows.Forms.LinkLabel lnkJEV;
        internal System.Windows.Forms.Label lblJEVCounter;
        internal System.Windows.Forms.Button btnAddJEV;
    }
}
