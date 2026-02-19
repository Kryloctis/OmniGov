
namespace OmniGov.App.Accounting.Views.Dashboard
{
    partial class ucJevDashboard
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlJEV = new Panel();
            lnkJEV = new LinkLabel();
            lblJEVCounter = new Label();
            pnlPendingJEV = new Panel();
            lnkPending = new LinkLabel();
            lblPendingJEVCounter = new Label();
            pnlApprovedJEV = new Panel();
            lnkApproved = new LinkLabel();
            lblApprovedJEVCounter = new Label();
            pnlDisapproved = new Panel();
            linkDisapproved = new LinkLabel();
            lblDisapprovedJEVCounter = new Label();
            pnlCancelled = new Panel();
            lnkCancelled = new LinkLabel();
            lblCancelledJEVCounter = new Label();
            cmbxJournals = new ComboBox();
            cmbxFunds = new ComboBox();
            nudYear = new NumericUpDown();
            panel1 = new Panel();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            tlStrpBtnJev = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            pnlJEV.SuspendLayout();
            pnlPendingJEV.SuspendLayout();
            pnlApprovedJEV.SuspendLayout();
            pnlDisapproved.SuspendLayout();
            pnlCancelled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(pnlJEV, 4, 0);
            tableLayoutPanel1.Controls.Add(pnlPendingJEV, 0, -1);
            tableLayoutPanel1.Controls.Add(pnlApprovedJEV, 0, -1);
            tableLayoutPanel1.Controls.Add(pnlDisapproved, 3, -1);
            tableLayoutPanel1.Controls.Add(pnlCancelled, 4, -1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 83);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(865, 91);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // pnlJEV
            // 
            pnlJEV.BackColor = Color.White;
            pnlJEV.BorderStyle = BorderStyle.FixedSingle;
            pnlJEV.Controls.Add(lnkJEV);
            pnlJEV.Controls.Add(lblJEVCounter);
            pnlJEV.Dock = DockStyle.Fill;
            pnlJEV.Location = new Point(695, 3);
            pnlJEV.Name = "pnlJEV";
            pnlJEV.Size = new Size(167, 85);
            pnlJEV.TabIndex = 30;
            // 
            // lnkJEV
            // 
            lnkJEV.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            lnkJEV.BackColor = Color.Transparent;
            lnkJEV.Cursor = Cursors.Hand;
            lnkJEV.DisabledLinkColor = Color.Silver;
            lnkJEV.Dock = DockStyle.Top;
            lnkJEV.Font = new Font("Segoe UI", 9.75F);
            lnkJEV.ForeColor = SystemColors.ControlDarkDark;
            lnkJEV.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkJEV.LinkColor = Color.FromArgb(64, 64, 64);
            lnkJEV.Location = new Point(0, 40);
            lnkJEV.Name = "lnkJEV";
            lnkJEV.Size = new Size(165, 23);
            lnkJEV.TabIndex = 15;
            lnkJEV.TabStop = true;
            lnkJEV.Text = "Total";
            lnkJEV.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblJEVCounter
            // 
            lblJEVCounter.Dock = DockStyle.Top;
            lblJEVCounter.Font = new Font("Segoe UI", 15.75F);
            lblJEVCounter.ForeColor = SystemColors.ControlDarkDark;
            lblJEVCounter.Location = new Point(0, 0);
            lblJEVCounter.Name = "lblJEVCounter";
            lblJEVCounter.Size = new Size(165, 40);
            lblJEVCounter.TabIndex = 6;
            lblJEVCounter.Text = "0";
            lblJEVCounter.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlPendingJEV
            // 
            pnlPendingJEV.BackColor = Color.White;
            pnlPendingJEV.BorderStyle = BorderStyle.FixedSingle;
            pnlPendingJEV.Controls.Add(lnkPending);
            pnlPendingJEV.Controls.Add(lblPendingJEVCounter);
            pnlPendingJEV.Dock = DockStyle.Fill;
            pnlPendingJEV.Location = new Point(3, 3);
            pnlPendingJEV.Name = "pnlPendingJEV";
            pnlPendingJEV.Size = new Size(167, 85);
            pnlPendingJEV.TabIndex = 29;
            // 
            // lnkPending
            // 
            lnkPending.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            lnkPending.BackColor = Color.Transparent;
            lnkPending.Cursor = Cursors.Hand;
            lnkPending.DisabledLinkColor = Color.Silver;
            lnkPending.Dock = DockStyle.Top;
            lnkPending.Font = new Font("Segoe UI", 9.75F);
            lnkPending.ForeColor = SystemColors.ControlDarkDark;
            lnkPending.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkPending.LinkColor = Color.FromArgb(64, 64, 64);
            lnkPending.Location = new Point(0, 40);
            lnkPending.Name = "lnkPending";
            lnkPending.Size = new Size(165, 23);
            lnkPending.TabIndex = 15;
            lnkPending.TabStop = true;
            lnkPending.Text = "Pending";
            lnkPending.TextAlign = ContentAlignment.MiddleCenter;
            lnkPending.LinkClicked += lnkPending_LinkClicked;
            // 
            // lblPendingJEVCounter
            // 
            lblPendingJEVCounter.Dock = DockStyle.Top;
            lblPendingJEVCounter.Font = new Font("Segoe UI", 15.75F);
            lblPendingJEVCounter.ForeColor = SystemColors.ControlDarkDark;
            lblPendingJEVCounter.Location = new Point(0, 0);
            lblPendingJEVCounter.Name = "lblPendingJEVCounter";
            lblPendingJEVCounter.Size = new Size(165, 40);
            lblPendingJEVCounter.TabIndex = 6;
            lblPendingJEVCounter.Text = "0";
            lblPendingJEVCounter.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            pnlApprovedJEV.BackColor = Color.White;
            pnlApprovedJEV.BorderStyle = BorderStyle.FixedSingle;
            pnlApprovedJEV.Controls.Add(lnkApproved);
            pnlApprovedJEV.Controls.Add(lblApprovedJEVCounter);
            pnlApprovedJEV.Dock = DockStyle.Fill;
            pnlApprovedJEV.Location = new Point(176, 3);
            pnlApprovedJEV.Name = "pnlApprovedJEV";
            pnlApprovedJEV.Size = new Size(167, 85);
            pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkApproved
            // 
            lnkApproved.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            lnkApproved.BackColor = Color.Transparent;
            lnkApproved.Cursor = Cursors.Hand;
            lnkApproved.DisabledLinkColor = Color.Silver;
            lnkApproved.Dock = DockStyle.Top;
            lnkApproved.Font = new Font("Segoe UI", 9.75F);
            lnkApproved.ForeColor = SystemColors.ControlDarkDark;
            lnkApproved.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkApproved.LinkColor = Color.FromArgb(64, 64, 64);
            lnkApproved.Location = new Point(0, 40);
            lnkApproved.Name = "lnkApproved";
            lnkApproved.Size = new Size(165, 23);
            lnkApproved.TabIndex = 14;
            lnkApproved.TabStop = true;
            lnkApproved.Text = "Approved";
            lnkApproved.TextAlign = ContentAlignment.MiddleCenter;
            lnkApproved.LinkClicked += lnkApproved_LinkClicked;
            // 
            // lblApprovedJEVCounter
            // 
            lblApprovedJEVCounter.Dock = DockStyle.Top;
            lblApprovedJEVCounter.Font = new Font("Segoe UI", 15.75F);
            lblApprovedJEVCounter.ForeColor = SystemColors.ControlDarkDark;
            lblApprovedJEVCounter.Location = new Point(0, 0);
            lblApprovedJEVCounter.Name = "lblApprovedJEVCounter";
            lblApprovedJEVCounter.Size = new Size(165, 40);
            lblApprovedJEVCounter.TabIndex = 6;
            lblApprovedJEVCounter.Text = "0";
            lblApprovedJEVCounter.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlDisapproved
            // 
            pnlDisapproved.BackColor = Color.White;
            pnlDisapproved.BorderStyle = BorderStyle.FixedSingle;
            pnlDisapproved.Controls.Add(linkDisapproved);
            pnlDisapproved.Controls.Add(lblDisapprovedJEVCounter);
            pnlDisapproved.Dock = DockStyle.Fill;
            pnlDisapproved.Location = new Point(349, 3);
            pnlDisapproved.Name = "pnlDisapproved";
            pnlDisapproved.Size = new Size(167, 85);
            pnlDisapproved.TabIndex = 22;
            // 
            // linkDisapproved
            // 
            linkDisapproved.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            linkDisapproved.BackColor = Color.Transparent;
            linkDisapproved.Cursor = Cursors.Hand;
            linkDisapproved.DisabledLinkColor = Color.Silver;
            linkDisapproved.Dock = DockStyle.Top;
            linkDisapproved.Font = new Font("Segoe UI", 9.75F);
            linkDisapproved.ForeColor = SystemColors.ControlDarkDark;
            linkDisapproved.LinkBehavior = LinkBehavior.HoverUnderline;
            linkDisapproved.LinkColor = Color.FromArgb(64, 64, 64);
            linkDisapproved.Location = new Point(0, 40);
            linkDisapproved.Name = "linkDisapproved";
            linkDisapproved.Size = new Size(165, 23);
            linkDisapproved.TabIndex = 16;
            linkDisapproved.TabStop = true;
            linkDisapproved.Text = "Disapproved";
            linkDisapproved.TextAlign = ContentAlignment.MiddleCenter;
            linkDisapproved.LinkClicked += linkDisapproved_LinkClicked;
            // 
            // lblDisapprovedJEVCounter
            // 
            lblDisapprovedJEVCounter.Dock = DockStyle.Top;
            lblDisapprovedJEVCounter.Font = new Font("Segoe UI", 15.75F);
            lblDisapprovedJEVCounter.ForeColor = SystemColors.ControlDarkDark;
            lblDisapprovedJEVCounter.Location = new Point(0, 0);
            lblDisapprovedJEVCounter.Name = "lblDisapprovedJEVCounter";
            lblDisapprovedJEVCounter.Size = new Size(165, 40);
            lblDisapprovedJEVCounter.TabIndex = 6;
            lblDisapprovedJEVCounter.Text = "0";
            lblDisapprovedJEVCounter.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlCancelled
            // 
            pnlCancelled.BackColor = Color.White;
            pnlCancelled.BorderStyle = BorderStyle.FixedSingle;
            pnlCancelled.Controls.Add(lnkCancelled);
            pnlCancelled.Controls.Add(lblCancelledJEVCounter);
            pnlCancelled.Dock = DockStyle.Fill;
            pnlCancelled.Location = new Point(522, 3);
            pnlCancelled.Name = "pnlCancelled";
            pnlCancelled.Size = new Size(167, 85);
            pnlCancelled.TabIndex = 23;
            // 
            // lnkCancelled
            // 
            lnkCancelled.ActiveLinkColor = Color.FromArgb(64, 64, 64);
            lnkCancelled.BackColor = Color.Transparent;
            lnkCancelled.Cursor = Cursors.Hand;
            lnkCancelled.DisabledLinkColor = Color.Silver;
            lnkCancelled.Dock = DockStyle.Top;
            lnkCancelled.Font = new Font("Segoe UI", 9.75F);
            lnkCancelled.ForeColor = SystemColors.ControlDarkDark;
            lnkCancelled.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkCancelled.LinkColor = Color.FromArgb(64, 64, 64);
            lnkCancelled.Location = new Point(0, 40);
            lnkCancelled.Name = "lnkCancelled";
            lnkCancelled.Size = new Size(165, 23);
            lnkCancelled.TabIndex = 15;
            lnkCancelled.TabStop = true;
            lnkCancelled.Text = "Cancelled";
            lnkCancelled.TextAlign = ContentAlignment.MiddleCenter;
            lnkCancelled.LinkClicked += lnkCancelled_LinkClicked;
            // 
            // lblCancelledJEVCounter
            // 
            lblCancelledJEVCounter.Dock = DockStyle.Top;
            lblCancelledJEVCounter.Font = new Font("Segoe UI", 15.75F);
            lblCancelledJEVCounter.ForeColor = SystemColors.ControlDarkDark;
            lblCancelledJEVCounter.Location = new Point(0, 0);
            lblCancelledJEVCounter.Name = "lblCancelledJEVCounter";
            lblCancelledJEVCounter.Size = new Size(165, 40);
            lblCancelledJEVCounter.TabIndex = 6;
            lblCancelledJEVCounter.Text = "0";
            lblCancelledJEVCounter.TextAlign = ContentAlignment.BottomCenter;
            // 
            // cmbxJournals
            // 
            cmbxJournals.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbxJournals.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new Point(348, 6);
            cmbxJournals.Name = "cmbxJournals";
            cmbxJournals.Size = new Size(200, 23);
            cmbxJournals.TabIndex = 30;
            cmbxJournals.SelectionChangeCommitted += cmbxJournals_SelectionChangeCommitted;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbxFunds.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new Point(554, 6);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new Size(189, 23);
            cmbxFunds.TabIndex = 32;
            cmbxFunds.SelectionChangeCommitted += cmbxFunds_SelectionChangeCommitted;
            // 
            // nudYear
            // 
            nudYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudYear.BackColor = Color.White;
            nudYear.Location = new Point(749, 6);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new Size(109, 23);
            nudYear.TabIndex = 29;
            nudYear.Value = new decimal(new int[] { 2021, 0, 0, 0 });
            nudYear.ValueChanged += nudYear_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbxJournals);
            panel1.Controls.Add(cmbxFunds);
            panel1.Controls.Add(nudYear);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 47);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4);
            panel1.Size = new Size(865, 36);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(7, 9);
            label1.Name = "label1";
            label1.Size = new Size(177, 17);
            label1.TabIndex = 33;
            label1.Text = "JOURNAL ENTRY VOUCHER";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlStrpBtnJev });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(4, 4, 4, 20);
            toolStrip1.Size = new Size(865, 47);
            toolStrip1.TabIndex = 17;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnJev
            // 
            tlStrpBtnJev.Image = Properties.Resources.folder_filled_20px;
            tlStrpBtnJev.ImageTransparentColor = Color.Magenta;
            tlStrpBtnJev.Name = "tlStrpBtnJev";
            tlStrpBtnJev.Size = new Size(84, 36);
            tlStrpBtnJev.Text = "Record JEV";
            tlStrpBtnJev.Click += tlStrpBtnJev_Click;
            // 
            // ucJevDashboard
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Margin = new Padding(0);
            Name = "ucJevDashboard";
            Size = new Size(865, 186);
            tableLayoutPanel1.ResumeLayout(false);
            pnlJEV.ResumeLayout(false);
            pnlPendingJEV.ResumeLayout(false);
            pnlApprovedJEV.ResumeLayout(false);
            pnlDisapproved.ResumeLayout(false);
            pnlCancelled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlDisapproved;
        internal System.Windows.Forms.Label lblDisapprovedJEVCounter;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cmbxJournals;
        private System.Windows.Forms.Panel pnlCancelled;
        internal System.Windows.Forms.LinkLabel lnkCancelled;
        internal System.Windows.Forms.Label lblCancelledJEVCounter;
        private System.Windows.Forms.Panel pnlPendingJEV;
        internal System.Windows.Forms.Label lblPendingJEVCounter;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        internal System.Windows.Forms.Label lblApprovedJEVCounter;
        internal System.Windows.Forms.LinkLabel linkDisapproved;
        internal System.Windows.Forms.LinkLabel lnkPending;
        internal System.Windows.Forms.LinkLabel lnkApproved;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnJev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlJEV;
        internal System.Windows.Forms.LinkLabel lnkJEV;
        internal System.Windows.Forms.Label lblJEVCounter;
    }
}
