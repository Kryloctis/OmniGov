
namespace LFS.Views.Dashboard
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pnlPendingJEV = new System.Windows.Forms.Panel();
            lnkPending = new System.Windows.Forms.LinkLabel();
            lblPendingJEVCounter = new System.Windows.Forms.Label();
            pnlApprovedJEV = new System.Windows.Forms.Panel();
            lnkApproved = new System.Windows.Forms.LinkLabel();
            lblApprovedJEVCounter = new System.Windows.Forms.Label();
            pnlDisapproved = new System.Windows.Forms.Panel();
            linkDisapproved = new System.Windows.Forms.LinkLabel();
            lblDisapprovedJEVCounter = new System.Windows.Forms.Label();
            pnlCancelled = new System.Windows.Forms.Panel();
            lnkCancelled = new System.Windows.Forms.LinkLabel();
            lblCancelledJEVCounter = new System.Windows.Forms.Label();
            cmbxJournals = new System.Windows.Forms.ComboBox();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnJev = new System.Windows.Forms.ToolStripButton();
            lnkJEV = new System.Windows.Forms.LinkLabel();
            lblJEVCounter = new System.Windows.Forms.Label();
            pnlJEV = new System.Windows.Forms.Panel();
            tableLayoutPanel1.SuspendLayout();
            pnlPendingJEV.SuspendLayout();
            pnlApprovedJEV.SuspendLayout();
            pnlDisapproved.SuspendLayout();
            pnlCancelled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnlJEV.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(pnlJEV, 4, 0);
            tableLayoutPanel1.Controls.Add(pnlPendingJEV, 0, -1);
            tableLayoutPanel1.Controls.Add(pnlApprovedJEV, 0, -1);
            tableLayoutPanel1.Controls.Add(pnlDisapproved, 3, -1);
            tableLayoutPanel1.Controls.Add(pnlCancelled, 4, -1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 83);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(865, 91);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // pnlPendingJEV
            // 
            pnlPendingJEV.BackColor = System.Drawing.Color.White;
            pnlPendingJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlPendingJEV.Controls.Add(lnkPending);
            pnlPendingJEV.Controls.Add(lblPendingJEVCounter);
            pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlPendingJEV.Location = new System.Drawing.Point(3, 3);
            pnlPendingJEV.Name = "pnlPendingJEV";
            pnlPendingJEV.Size = new System.Drawing.Size(167, 85);
            pnlPendingJEV.TabIndex = 29;
            // 
            // lnkPending
            // 
            lnkPending.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkPending.BackColor = System.Drawing.Color.Transparent;
            lnkPending.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkPending.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkPending.Dock = System.Windows.Forms.DockStyle.Top;
            lnkPending.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lnkPending.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lnkPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkPending.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkPending.Location = new System.Drawing.Point(0, 40);
            lnkPending.Name = "lnkPending";
            lnkPending.Size = new System.Drawing.Size(165, 23);
            lnkPending.TabIndex = 15;
            lnkPending.TabStop = true;
            lnkPending.Text = "Pending";
            lnkPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkPending.LinkClicked += lnkPending_LinkClicked;
            // 
            // lblPendingJEVCounter
            // 
            lblPendingJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblPendingJEVCounter.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblPendingJEVCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblPendingJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblPendingJEVCounter.Name = "lblPendingJEVCounter";
            lblPendingJEVCounter.Size = new System.Drawing.Size(165, 40);
            lblPendingJEVCounter.TabIndex = 6;
            lblPendingJEVCounter.Text = "0";
            lblPendingJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            pnlApprovedJEV.BackColor = System.Drawing.Color.White;
            pnlApprovedJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlApprovedJEV.Controls.Add(lnkApproved);
            pnlApprovedJEV.Controls.Add(lblApprovedJEVCounter);
            pnlApprovedJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlApprovedJEV.Location = new System.Drawing.Point(176, 3);
            pnlApprovedJEV.Name = "pnlApprovedJEV";
            pnlApprovedJEV.Size = new System.Drawing.Size(167, 85);
            pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkApproved
            // 
            lnkApproved.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkApproved.BackColor = System.Drawing.Color.Transparent;
            lnkApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkApproved.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkApproved.Dock = System.Windows.Forms.DockStyle.Top;
            lnkApproved.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lnkApproved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lnkApproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkApproved.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkApproved.Location = new System.Drawing.Point(0, 40);
            lnkApproved.Name = "lnkApproved";
            lnkApproved.Size = new System.Drawing.Size(165, 23);
            lnkApproved.TabIndex = 14;
            lnkApproved.TabStop = true;
            lnkApproved.Text = "Approved";
            lnkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkApproved.LinkClicked += lnkApproved_LinkClicked;
            // 
            // lblApprovedJEVCounter
            // 
            lblApprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblApprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblApprovedJEVCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblApprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblApprovedJEVCounter.Name = "lblApprovedJEVCounter";
            lblApprovedJEVCounter.Size = new System.Drawing.Size(165, 40);
            lblApprovedJEVCounter.TabIndex = 6;
            lblApprovedJEVCounter.Text = "0";
            lblApprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlDisapproved
            // 
            pnlDisapproved.BackColor = System.Drawing.Color.White;
            pnlDisapproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlDisapproved.Controls.Add(linkDisapproved);
            pnlDisapproved.Controls.Add(lblDisapprovedJEVCounter);
            pnlDisapproved.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDisapproved.Location = new System.Drawing.Point(349, 3);
            pnlDisapproved.Name = "pnlDisapproved";
            pnlDisapproved.Size = new System.Drawing.Size(167, 85);
            pnlDisapproved.TabIndex = 22;
            // 
            // linkDisapproved
            // 
            linkDisapproved.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            linkDisapproved.BackColor = System.Drawing.Color.Transparent;
            linkDisapproved.Cursor = System.Windows.Forms.Cursors.Hand;
            linkDisapproved.DisabledLinkColor = System.Drawing.Color.Silver;
            linkDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            linkDisapproved.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            linkDisapproved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            linkDisapproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkDisapproved.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            linkDisapproved.Location = new System.Drawing.Point(0, 40);
            linkDisapproved.Name = "linkDisapproved";
            linkDisapproved.Size = new System.Drawing.Size(165, 23);
            linkDisapproved.TabIndex = 16;
            linkDisapproved.TabStop = true;
            linkDisapproved.Text = "Disapproved";
            linkDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            linkDisapproved.LinkClicked += linkDisapproved_LinkClicked;
            // 
            // lblDisapprovedJEVCounter
            // 
            lblDisapprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblDisapprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblDisapprovedJEVCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblDisapprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblDisapprovedJEVCounter.Name = "lblDisapprovedJEVCounter";
            lblDisapprovedJEVCounter.Size = new System.Drawing.Size(165, 40);
            lblDisapprovedJEVCounter.TabIndex = 6;
            lblDisapprovedJEVCounter.Text = "0";
            lblDisapprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlCancelled
            // 
            pnlCancelled.BackColor = System.Drawing.Color.White;
            pnlCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCancelled.Controls.Add(lnkCancelled);
            pnlCancelled.Controls.Add(lblCancelledJEVCounter);
            pnlCancelled.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCancelled.Location = new System.Drawing.Point(522, 3);
            pnlCancelled.Name = "pnlCancelled";
            pnlCancelled.Size = new System.Drawing.Size(167, 85);
            pnlCancelled.TabIndex = 23;
            // 
            // lnkCancelled
            // 
            lnkCancelled.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCancelled.BackColor = System.Drawing.Color.Transparent;
            lnkCancelled.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkCancelled.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            lnkCancelled.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lnkCancelled.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lnkCancelled.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkCancelled.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCancelled.Location = new System.Drawing.Point(0, 40);
            lnkCancelled.Name = "lnkCancelled";
            lnkCancelled.Size = new System.Drawing.Size(165, 23);
            lnkCancelled.TabIndex = 15;
            lnkCancelled.TabStop = true;
            lnkCancelled.Text = "Cancelled";
            lnkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkCancelled.LinkClicked += lnkCancelled_LinkClicked;
            // 
            // lblCancelledJEVCounter
            // 
            lblCancelledJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblCancelledJEVCounter.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblCancelledJEVCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCancelledJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblCancelledJEVCounter.Name = "lblCancelledJEVCounter";
            lblCancelledJEVCounter.Size = new System.Drawing.Size(165, 40);
            lblCancelledJEVCounter.TabIndex = 6;
            lblCancelledJEVCounter.Text = "0";
            lblCancelledJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbxJournals
            // 
            cmbxJournals.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new System.Drawing.Point(348, 6);
            cmbxJournals.Name = "cmbxJournals";
            cmbxJournals.Size = new System.Drawing.Size(200, 23);
            cmbxJournals.TabIndex = 30;
            cmbxJournals.SelectionChangeCommitted += cmbxJournals_SelectionChangeCommitted;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(554, 6);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(189, 23);
            cmbxFunds.TabIndex = 32;
            cmbxFunds.SelectionChangeCommitted += cmbxFunds_SelectionChangeCommitted;
            // 
            // nudYear
            // 
            nudYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudYear.BackColor = System.Drawing.Color.White;
            nudYear.Location = new System.Drawing.Point(749, 6);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(109, 23);
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
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 47);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(865, 36);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(7, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(177, 17);
            label1.TabIndex = 33;
            label1.Text = "JOURNAL ENTRY VOUCHER";
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnJev });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 20);
            toolStrip1.Size = new System.Drawing.Size(865, 47);
            toolStrip1.TabIndex = 17;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnJev
            // 
            tlStrpBtnJev.Image = Properties.Resources.folder_filled_20px;
            tlStrpBtnJev.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnJev.Name = "tlStrpBtnJev";
            tlStrpBtnJev.Size = new System.Drawing.Size(84, 20);
            tlStrpBtnJev.Text = "Record JEV";
            tlStrpBtnJev.Click += tlStrpBtnJev_Click;
            // 
            // lnkJEV
            // 
            lnkJEV.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkJEV.BackColor = System.Drawing.Color.Transparent;
            lnkJEV.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkJEV.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkJEV.Dock = System.Windows.Forms.DockStyle.Top;
            lnkJEV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lnkJEV.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lnkJEV.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkJEV.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkJEV.Location = new System.Drawing.Point(0, 40);
            lnkJEV.Name = "lnkJEV";
            lnkJEV.Size = new System.Drawing.Size(165, 23);
            lnkJEV.TabIndex = 15;
            lnkJEV.TabStop = true;
            lnkJEV.Text = "Total";
            lnkJEV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJEVCounter
            // 
            lblJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblJEVCounter.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            lblJEVCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblJEVCounter.Name = "lblJEVCounter";
            lblJEVCounter.Size = new System.Drawing.Size(165, 40);
            lblJEVCounter.TabIndex = 6;
            lblJEVCounter.Text = "0";
            lblJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            pnlJEV.BackColor = System.Drawing.Color.White;
            pnlJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlJEV.Controls.Add(lnkJEV);
            pnlJEV.Controls.Add(lblJEVCounter);
            pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlJEV.Location = new System.Drawing.Point(695, 3);
            pnlJEV.Name = "pnlJEV";
            pnlJEV.Size = new System.Drawing.Size(167, 85);
            pnlJEV.TabIndex = 30;
            // 
            // ucJevDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "ucJevDashboard";
            Size = new System.Drawing.Size(865, 186);
            tableLayoutPanel1.ResumeLayout(false);
            pnlPendingJEV.ResumeLayout(false);
            pnlApprovedJEV.ResumeLayout(false);
            pnlDisapproved.ResumeLayout(false);
            pnlCancelled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlJEV.ResumeLayout(false);
            ResumeLayout(false);
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
