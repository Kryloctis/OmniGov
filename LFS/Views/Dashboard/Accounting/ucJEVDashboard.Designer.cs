
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
            btnRefresh = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pnlPendingJEV = new System.Windows.Forms.Panel();
            lnkPending = new System.Windows.Forms.LinkLabel();
            lblPendingJEVCounter = new System.Windows.Forms.Label();
            pnlApprovedJEV = new System.Windows.Forms.Panel();
            lnkApproved = new System.Windows.Forms.LinkLabel();
            lblApprovedJEVCounter = new System.Windows.Forms.Label();
            pnlJEV = new System.Windows.Forms.Panel();
            lnkJEV = new System.Windows.Forms.LinkLabel();
            lblJEVCounter = new System.Windows.Forms.Label();
            pnlDisapproved = new System.Windows.Forms.Panel();
            linkDisapproved = new System.Windows.Forms.LinkLabel();
            lblDisapprovedJEVCounter = new System.Windows.Forms.Label();
            pnlCancelled = new System.Windows.Forms.Panel();
            lnkCancelled = new System.Windows.Forms.LinkLabel();
            lblCancelledJEVCounter = new System.Windows.Forms.Label();
            cmbxJournals = new System.Windows.Forms.ComboBox();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxMonth = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            panel1 = new System.Windows.Forms.Panel();
            btnAdd = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            pnlPendingJEV.SuspendLayout();
            pnlApprovedJEV.SuspendLayout();
            pnlJEV.SuspendLayout();
            pnlDisapproved.SuspendLayout();
            pnlCancelled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRefresh.Location = new System.Drawing.Point(1009, 7);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(150, 23);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefreshCounter_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pnlPendingJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlApprovedJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlDisapproved, 3, 0);
            tableLayoutPanel1.Controls.Add(pnlCancelled, 4, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.MinimumSize = new System.Drawing.Size(781, 121);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(1166, 131);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // pnlPendingJEV
            // 
            pnlPendingJEV.BackColor = System.Drawing.Color.White;
            pnlPendingJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlPendingJEV.Controls.Add(lnkPending);
            pnlPendingJEV.Controls.Add(lblPendingJEVCounter);
            pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlPendingJEV.Location = new System.Drawing.Point(469, 13);
            pnlPendingJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlPendingJEV.Name = "pnlPendingJEV";
            pnlPendingJEV.Size = new System.Drawing.Size(227, 116);
            pnlPendingJEV.TabIndex = 29;
            // 
            // lnkPending
            // 
            lnkPending.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkPending.BackColor = System.Drawing.Color.Transparent;
            lnkPending.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkPending.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkPending.Dock = System.Windows.Forms.DockStyle.Top;
            lnkPending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            lnkPending.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkPending.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkPending.Location = new System.Drawing.Point(0, 61);
            lnkPending.Name = "lnkPending";
            lnkPending.Size = new System.Drawing.Size(225, 23);
            lnkPending.TabIndex = 15;
            lnkPending.TabStop = true;
            lnkPending.Text = "Pending";
            lnkPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkPending.LinkClicked += lnkPending_LinkClicked;
            // 
            // lblPendingJEVCounter
            // 
            lblPendingJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblPendingJEVCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblPendingJEVCounter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblPendingJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblPendingJEVCounter.Name = "lblPendingJEVCounter";
            lblPendingJEVCounter.Size = new System.Drawing.Size(225, 61);
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
            pnlApprovedJEV.Location = new System.Drawing.Point(236, 13);
            pnlApprovedJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlApprovedJEV.Name = "pnlApprovedJEV";
            pnlApprovedJEV.Size = new System.Drawing.Size(227, 116);
            pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkApproved
            // 
            lnkApproved.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkApproved.BackColor = System.Drawing.Color.Transparent;
            lnkApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkApproved.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkApproved.Dock = System.Windows.Forms.DockStyle.Top;
            lnkApproved.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            lnkApproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkApproved.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkApproved.Location = new System.Drawing.Point(0, 61);
            lnkApproved.Name = "lnkApproved";
            lnkApproved.Size = new System.Drawing.Size(225, 23);
            lnkApproved.TabIndex = 14;
            lnkApproved.TabStop = true;
            lnkApproved.Text = "Approved";
            lnkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkApproved.LinkClicked += lnkApproved_LinkClicked;
            // 
            // lblApprovedJEVCounter
            // 
            lblApprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblApprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblApprovedJEVCounter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblApprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblApprovedJEVCounter.Name = "lblApprovedJEVCounter";
            lblApprovedJEVCounter.Size = new System.Drawing.Size(225, 61);
            lblApprovedJEVCounter.TabIndex = 6;
            lblApprovedJEVCounter.Text = "0";
            lblApprovedJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            pnlJEV.BackColor = System.Drawing.Color.White;
            pnlJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlJEV.Controls.Add(lnkJEV);
            pnlJEV.Controls.Add(lblJEVCounter);
            pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlJEV.Location = new System.Drawing.Point(3, 13);
            pnlJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlJEV.Name = "pnlJEV";
            pnlJEV.Size = new System.Drawing.Size(227, 116);
            pnlJEV.TabIndex = 26;
            // 
            // lnkJEV
            // 
            lnkJEV.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkJEV.BackColor = System.Drawing.Color.Transparent;
            lnkJEV.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkJEV.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkJEV.Dock = System.Windows.Forms.DockStyle.Top;
            lnkJEV.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            lnkJEV.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkJEV.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkJEV.Location = new System.Drawing.Point(0, 61);
            lnkJEV.Name = "lnkJEV";
            lnkJEV.Size = new System.Drawing.Size(225, 23);
            lnkJEV.TabIndex = 15;
            lnkJEV.TabStop = true;
            lnkJEV.Text = "Total";
            lnkJEV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkJEV.LinkClicked += lnkJEV_LinkClicked;
            // 
            // lblJEVCounter
            // 
            lblJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblJEVCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblJEVCounter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblJEVCounter.Name = "lblJEVCounter";
            lblJEVCounter.Size = new System.Drawing.Size(225, 61);
            lblJEVCounter.TabIndex = 6;
            lblJEVCounter.Text = "0";
            lblJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlDisapproved
            // 
            pnlDisapproved.BackColor = System.Drawing.Color.White;
            pnlDisapproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlDisapproved.Controls.Add(linkDisapproved);
            pnlDisapproved.Controls.Add(lblDisapprovedJEVCounter);
            pnlDisapproved.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDisapproved.Location = new System.Drawing.Point(702, 13);
            pnlDisapproved.MinimumSize = new System.Drawing.Size(150, 113);
            pnlDisapproved.Name = "pnlDisapproved";
            pnlDisapproved.Size = new System.Drawing.Size(227, 116);
            pnlDisapproved.TabIndex = 22;
            // 
            // linkDisapproved
            // 
            linkDisapproved.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            linkDisapproved.BackColor = System.Drawing.Color.Transparent;
            linkDisapproved.Cursor = System.Windows.Forms.Cursors.Hand;
            linkDisapproved.DisabledLinkColor = System.Drawing.Color.Silver;
            linkDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            linkDisapproved.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            linkDisapproved.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkDisapproved.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            linkDisapproved.Location = new System.Drawing.Point(0, 61);
            linkDisapproved.Name = "linkDisapproved";
            linkDisapproved.Size = new System.Drawing.Size(225, 23);
            linkDisapproved.TabIndex = 16;
            linkDisapproved.TabStop = true;
            linkDisapproved.Text = "Disapproved";
            linkDisapproved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            linkDisapproved.LinkClicked += linkDisapproved_LinkClicked;
            // 
            // lblDisapprovedJEVCounter
            // 
            lblDisapprovedJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblDisapprovedJEVCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblDisapprovedJEVCounter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblDisapprovedJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblDisapprovedJEVCounter.Name = "lblDisapprovedJEVCounter";
            lblDisapprovedJEVCounter.Size = new System.Drawing.Size(225, 61);
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
            pnlCancelled.Location = new System.Drawing.Point(935, 13);
            pnlCancelled.MinimumSize = new System.Drawing.Size(150, 113);
            pnlCancelled.Name = "pnlCancelled";
            pnlCancelled.Size = new System.Drawing.Size(228, 116);
            pnlCancelled.TabIndex = 23;
            // 
            // lnkCancelled
            // 
            lnkCancelled.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCancelled.BackColor = System.Drawing.Color.Transparent;
            lnkCancelled.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkCancelled.DisabledLinkColor = System.Drawing.Color.Silver;
            lnkCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            lnkCancelled.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            lnkCancelled.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkCancelled.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCancelled.Location = new System.Drawing.Point(0, 61);
            lnkCancelled.Name = "lnkCancelled";
            lnkCancelled.Size = new System.Drawing.Size(226, 23);
            lnkCancelled.TabIndex = 15;
            lnkCancelled.TabStop = true;
            lnkCancelled.Text = "Cancelled";
            lnkCancelled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lnkCancelled.LinkClicked += lnkCancelled_LinkClicked;
            // 
            // lblCancelledJEVCounter
            // 
            lblCancelledJEVCounter.Dock = System.Windows.Forms.DockStyle.Top;
            lblCancelledJEVCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblCancelledJEVCounter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblCancelledJEVCounter.Location = new System.Drawing.Point(0, 0);
            lblCancelledJEVCounter.Name = "lblCancelledJEVCounter";
            lblCancelledJEVCounter.Size = new System.Drawing.Size(226, 61);
            lblCancelledJEVCounter.TabIndex = 6;
            lblCancelledJEVCounter.Text = "0";
            lblCancelledJEVCounter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cmbxJournals
            // 
            cmbxJournals.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new System.Drawing.Point(348, 7);
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
            cmbxFunds.Location = new System.Drawing.Point(554, 7);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(189, 23);
            cmbxFunds.TabIndex = 32;
            cmbxFunds.SelectionChangeCommitted += cmbxFunds_SelectionChangeCommitted;
            // 
            // cmbxMonth
            // 
            cmbxMonth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxMonth.FormattingEnabled = true;
            cmbxMonth.Location = new System.Drawing.Point(749, 7);
            cmbxMonth.Name = "cmbxMonth";
            cmbxMonth.Size = new System.Drawing.Size(139, 23);
            cmbxMonth.TabIndex = 28;
            cmbxMonth.SelectedIndexChanged += cbMonth_SelectedIndexChanged;
            // 
            // nudYear
            // 
            nudYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudYear.BackColor = System.Drawing.Color.White;
            nudYear.Location = new System.Drawing.Point(894, 7);
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
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(cmbxJournals);
            panel1.Controls.Add(cmbxFunds);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(cmbxMonth);
            panel1.Controls.Add(nudYear);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1166, 39);
            panel1.TabIndex = 16;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.Location = new System.Drawing.Point(192, 7);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(150, 23);
            btnAdd.TabIndex = 33;
            btnAdd.Text = "Add...";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // ucJevDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(0);
            MinimumSize = new System.Drawing.Size(782, 160);
            Name = "ucJevDashboard";
            Size = new System.Drawing.Size(1166, 192);
            tableLayoutPanel1.ResumeLayout(false);
            pnlPendingJEV.ResumeLayout(false);
            pnlApprovedJEV.ResumeLayout(false);
            pnlJEV.ResumeLayout(false);
            pnlDisapproved.ResumeLayout(false);
            pnlCancelled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlDisapproved;
        internal System.Windows.Forms.Label lblDisapprovedJEVCounter;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cmbxMonth;
        private System.Windows.Forms.ComboBox cmbxJournals;
        private System.Windows.Forms.Panel pnlCancelled;
        internal System.Windows.Forms.LinkLabel lnkCancelled;
        internal System.Windows.Forms.Label lblCancelledJEVCounter;
        private System.Windows.Forms.Panel pnlPendingJEV;
        internal System.Windows.Forms.Label lblPendingJEVCounter;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        internal System.Windows.Forms.Label lblApprovedJEVCounter;
        private System.Windows.Forms.Panel pnlJEV;
        internal System.Windows.Forms.Label lblJEVCounter;
        internal System.Windows.Forms.LinkLabel linkDisapproved;
        internal System.Windows.Forms.LinkLabel lnkPending;
        internal System.Windows.Forms.LinkLabel lnkApproved;
        internal System.Windows.Forms.LinkLabel lnkJEV;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
    }
}
