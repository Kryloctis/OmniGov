
namespace AccountingSystem.Views.Dashboard.TreasuryDashboard.RCDSummary
{
    partial class ucRCDDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRCDDashboard));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRCD = new System.Windows.Forms.Button();
            this.cmbcollector = new System.Windows.Forms.ComboBox();
            this.cmbfunds = new System.Windows.Forms.ComboBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tRCDpanel = new System.Windows.Forms.Panel();
            this.linkRCD = new System.Windows.Forms.LinkLabel();
            this.lblRCD = new System.Windows.Forms.Label();
            this.approvedRCDpanel = new System.Windows.Forms.Panel();
            this.linkApproved = new System.Windows.Forms.LinkLabel();
            this.lblApproved = new System.Windows.Forms.Label();
            this.pendingRCDpanel = new System.Windows.Forms.Panel();
            this.linkPending = new System.Windows.Forms.LinkLabel();
            this.lblPending = new System.Windows.Forms.Label();
            this.disapprovedRCDpanel = new System.Windows.Forms.Panel();
            this.linkDisapproved = new System.Windows.Forms.LinkLabel();
            this.lblDisapproved = new System.Windows.Forms.Label();
            this.cancelledRCDpanel = new System.Windows.Forms.Panel();
            this.linkCancelled = new System.Windows.Forms.LinkLabel();
            this.lblCancelled = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tRCDpanel.SuspendLayout();
            this.approvedRCDpanel.SuspendLayout();
            this.pendingRCDpanel.SuspendLayout();
            this.disapprovedRCDpanel.SuspendLayout();
            this.cancelledRCDpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddRCD);
            this.flowLayoutPanel1.Controls.Add(this.cmbcollector);
            this.flowLayoutPanel1.Controls.Add(this.cmbfunds);
            this.flowLayoutPanel1.Controls.Add(this.nudYear);
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(876, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnAddRCD
            // 
            this.btnAddRCD.Image = global::AccountingSystem.Properties.Resources.symbol_add_14px;
            this.btnAddRCD.Location = new System.Drawing.Point(8, 9);
            this.btnAddRCD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddRCD.Name = "btnAddRCD";
            this.btnAddRCD.Size = new System.Drawing.Size(105, 31);
            this.btnAddRCD.TabIndex = 32;
            this.btnAddRCD.Text = "Add";
            this.btnAddRCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddRCD.UseVisualStyleBackColor = true;
            this.btnAddRCD.Click += new System.EventHandler(this.btnAddRCD_Click);
            // 
            // cmbcollector
            // 
            this.cmbcollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcollector.FormattingEnabled = true;
            this.cmbcollector.Location = new System.Drawing.Point(119, 9);
            this.cmbcollector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbcollector.Name = "cmbcollector";
            this.cmbcollector.Size = new System.Drawing.Size(314, 28);
            this.cmbcollector.TabIndex = 33;
            this.cmbcollector.SelectionChangeCommitted += new System.EventHandler(this.cmbcollector_SelectionChangeCommitted);
            // 
            // cmbfunds
            // 
            this.cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfunds.FormattingEnabled = true;
            this.cmbfunds.Location = new System.Drawing.Point(439, 9);
            this.cmbfunds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbfunds.Name = "cmbfunds";
            this.cmbfunds.Size = new System.Drawing.Size(154, 28);
            this.cmbfunds.TabIndex = 34;
            this.cmbfunds.SelectionChangeCommitted += new System.EventHandler(this.cmbfunds_SelectionChangeCommitted);
            // 
            // nudYear
            // 
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Location = new System.Drawing.Point(599, 9);
            this.nudYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.nudYear.Size = new System.Drawing.Size(125, 27);
            this.nudYear.TabIndex = 35;
            this.nudYear.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(730, 9);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 31);
            this.btnRefresh.TabIndex = 36;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tRCDpanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.approvedRCDpanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pendingRCDpanel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.disapprovedRCDpanel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancelledRCDpanel, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 157);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tRCDpanel
            // 
            this.tRCDpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tRCDpanel.Controls.Add(this.linkRCD);
            this.tRCDpanel.Controls.Add(this.lblRCD);
            this.tRCDpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tRCDpanel.Location = new System.Drawing.Point(3, 3);
            this.tRCDpanel.Name = "tRCDpanel";
            this.tRCDpanel.Size = new System.Drawing.Size(169, 151);
            this.tRCDpanel.TabIndex = 0;
            // 
            // linkRCD
            // 
            this.linkRCD.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkRCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkRCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkRCD.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkRCD.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkRCD.Location = new System.Drawing.Point(0, 81);
            this.linkRCD.Name = "linkRCD";
            this.linkRCD.Size = new System.Drawing.Size(167, 31);
            this.linkRCD.TabIndex = 17;
            this.linkRCD.TabStop = true;
            this.linkRCD.Text = "Total RCDs";
            this.linkRCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRCD
            // 
            this.lblRCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRCD.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRCD.Location = new System.Drawing.Point(0, 0);
            this.lblRCD.Name = "lblRCD";
            this.lblRCD.Size = new System.Drawing.Size(167, 81);
            this.lblRCD.TabIndex = 16;
            this.lblRCD.Text = "0";
            this.lblRCD.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // approvedRCDpanel
            // 
            this.approvedRCDpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.approvedRCDpanel.Controls.Add(this.linkApproved);
            this.approvedRCDpanel.Controls.Add(this.lblApproved);
            this.approvedRCDpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.approvedRCDpanel.Location = new System.Drawing.Point(178, 3);
            this.approvedRCDpanel.Name = "approvedRCDpanel";
            this.approvedRCDpanel.Size = new System.Drawing.Size(169, 151);
            this.approvedRCDpanel.TabIndex = 1;
            // 
            // linkApproved
            // 
            this.linkApproved.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkApproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkApproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkApproved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkApproved.Location = new System.Drawing.Point(0, 81);
            this.linkApproved.Name = "linkApproved";
            this.linkApproved.Size = new System.Drawing.Size(167, 31);
            this.linkApproved.TabIndex = 19;
            this.linkApproved.TabStop = true;
            this.linkApproved.Text = "Approved RCDs";
            this.linkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApproved
            // 
            this.lblApproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblApproved.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblApproved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblApproved.Location = new System.Drawing.Point(0, 0);
            this.lblApproved.Name = "lblApproved";
            this.lblApproved.Size = new System.Drawing.Size(167, 81);
            this.lblApproved.TabIndex = 18;
            this.lblApproved.Text = "0";
            this.lblApproved.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pendingRCDpanel
            // 
            this.pendingRCDpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pendingRCDpanel.Controls.Add(this.linkPending);
            this.pendingRCDpanel.Controls.Add(this.lblPending);
            this.pendingRCDpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pendingRCDpanel.Location = new System.Drawing.Point(353, 3);
            this.pendingRCDpanel.Name = "pendingRCDpanel";
            this.pendingRCDpanel.Size = new System.Drawing.Size(169, 151);
            this.pendingRCDpanel.TabIndex = 2;
            // 
            // linkPending
            // 
            this.linkPending.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkPending.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkPending.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkPending.Location = new System.Drawing.Point(0, 81);
            this.linkPending.Name = "linkPending";
            this.linkPending.Size = new System.Drawing.Size(167, 31);
            this.linkPending.TabIndex = 19;
            this.linkPending.TabStop = true;
            this.linkPending.Text = "Pending RCDs";
            this.linkPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPending
            // 
            this.lblPending.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPending.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPending.Location = new System.Drawing.Point(0, 0);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(167, 81);
            this.lblPending.TabIndex = 18;
            this.lblPending.Text = "0";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // disapprovedRCDpanel
            // 
            this.disapprovedRCDpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disapprovedRCDpanel.Controls.Add(this.linkDisapproved);
            this.disapprovedRCDpanel.Controls.Add(this.lblDisapproved);
            this.disapprovedRCDpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disapprovedRCDpanel.Location = new System.Drawing.Point(528, 3);
            this.disapprovedRCDpanel.Name = "disapprovedRCDpanel";
            this.disapprovedRCDpanel.Size = new System.Drawing.Size(169, 151);
            this.disapprovedRCDpanel.TabIndex = 3;
            // 
            // linkDisapproved
            // 
            this.linkDisapproved.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkDisapproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkDisapproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkDisapproved.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkDisapproved.Location = new System.Drawing.Point(0, 81);
            this.linkDisapproved.Name = "linkDisapproved";
            this.linkDisapproved.Size = new System.Drawing.Size(167, 31);
            this.linkDisapproved.TabIndex = 19;
            this.linkDisapproved.TabStop = true;
            this.linkDisapproved.Text = "Disapproved RCDs";
            this.linkDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisapproved
            // 
            this.lblDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDisapproved.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDisapproved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDisapproved.Location = new System.Drawing.Point(0, 0);
            this.lblDisapproved.Name = "lblDisapproved";
            this.lblDisapproved.Size = new System.Drawing.Size(167, 81);
            this.lblDisapproved.TabIndex = 18;
            this.lblDisapproved.Text = "0";
            this.lblDisapproved.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cancelledRCDpanel
            // 
            this.cancelledRCDpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cancelledRCDpanel.Controls.Add(this.linkCancelled);
            this.cancelledRCDpanel.Controls.Add(this.lblCancelled);
            this.cancelledRCDpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelledRCDpanel.Location = new System.Drawing.Point(703, 3);
            this.cancelledRCDpanel.Name = "cancelledRCDpanel";
            this.cancelledRCDpanel.Size = new System.Drawing.Size(170, 151);
            this.cancelledRCDpanel.TabIndex = 4;
            // 
            // linkCancelled
            // 
            this.linkCancelled.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkCancelled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkCancelled.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkCancelled.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkCancelled.Location = new System.Drawing.Point(0, 81);
            this.linkCancelled.Name = "linkCancelled";
            this.linkCancelled.Size = new System.Drawing.Size(168, 31);
            this.linkCancelled.TabIndex = 19;
            this.linkCancelled.TabStop = true;
            this.linkCancelled.Text = "Cancelled RCDs";
            this.linkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCancelled
            // 
            this.lblCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCancelled.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCancelled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCancelled.Location = new System.Drawing.Point(0, 0);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(168, 81);
            this.lblCancelled.TabIndex = 18;
            this.lblCancelled.Text = "0";
            this.lblCancelled.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ucRCDDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ucRCDDashboard";
            this.Size = new System.Drawing.Size(876, 207);
            this.Load += new System.EventHandler(this.ucRCDDashboard_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tRCDpanel.ResumeLayout(false);
            this.approvedRCDpanel.ResumeLayout(false);
            this.pendingRCDpanel.ResumeLayout(false);
            this.disapprovedRCDpanel.ResumeLayout(false);
            this.cancelledRCDpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnAddRCD;
        private System.Windows.Forms.ComboBox cmbcollector;
        private System.Windows.Forms.ComboBox cmbfunds;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel tRCDpanel;
        private System.Windows.Forms.Panel approvedRCDpanel;
        private System.Windows.Forms.Panel pendingRCDpanel;
        private System.Windows.Forms.Panel disapprovedRCDpanel;
        private System.Windows.Forms.Panel cancelledRCDpanel;
        internal System.Windows.Forms.LinkLabel linkRCD;
        internal System.Windows.Forms.Label lblRCD;
        internal System.Windows.Forms.LinkLabel linkApproved;
        internal System.Windows.Forms.Label lblApproved;
        internal System.Windows.Forms.LinkLabel linkPending;
        internal System.Windows.Forms.Label lblPending;
        internal System.Windows.Forms.LinkLabel linkDisapproved;
        internal System.Windows.Forms.Label lblDisapproved;
        internal System.Windows.Forms.LinkLabel linkCancelled;
        internal System.Windows.Forms.Label lblCancelled;
    }
}
