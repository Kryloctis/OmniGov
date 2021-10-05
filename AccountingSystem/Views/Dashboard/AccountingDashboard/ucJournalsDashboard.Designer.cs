
namespace AccountingSystem.Views.Dashboard.AccountingDashboard
{
    partial class ucJournalsDashboard
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblProcurementReceivedJournalCount = new System.Windows.Forms.Label();
            this.pnlPendingJEV = new System.Windows.Forms.Panel();
            this.lnkPending = new System.Windows.Forms.LinkLabel();
            this.lblCashDisbursementsJournalCount = new System.Windows.Forms.Label();
            this.pnlApprovedJEV = new System.Windows.Forms.Panel();
            this.lnkApproved = new System.Windows.Forms.LinkLabel();
            this.lblGeneralJournalCount = new System.Windows.Forms.Label();
            this.pnlJEV = new System.Windows.Forms.Panel();
            this.lnkJEV = new System.Windows.Forms.LinkLabel();
            this.lblCashReceiptsJournalCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkDisapproved = new System.Windows.Forms.LinkLabel();
            this.lblCheckDisbursementsJournalCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkCancelled = new System.Windows.Forms.LinkLabel();
            this.lblADADisbursementsJournal = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlPendingJEV.SuspendLayout();
            this.pnlApprovedJEV.SuspendLayout();
            this.pnlJEV.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.cmbxFunds);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(941, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(3, 3);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(208, 23);
            this.cmbxFunds.TabIndex = 0;
            this.cmbxFunds.SelectedValueChanged += new System.EventHandler(this.cmbxFunds_SelectedValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM-  yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(217, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(211, 23);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(941, 131);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.lblProcurementReceivedJournalCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(315, 13);
            this.panel3.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 115);
            this.panel3.TabIndex = 30;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(0, 61);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Padding = new System.Windows.Forms.Padding(2);
            this.linkLabel1.Size = new System.Drawing.Size(150, 42);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Procurement Received Journal";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProcurementReceivedJournalCount
            // 
            this.lblProcurementReceivedJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcurementReceivedJournalCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProcurementReceivedJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProcurementReceivedJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblProcurementReceivedJournalCount.Name = "lblProcurementReceivedJournalCount";
            this.lblProcurementReceivedJournalCount.Size = new System.Drawing.Size(150, 61);
            this.lblProcurementReceivedJournalCount.TabIndex = 6;
            this.lblProcurementReceivedJournalCount.Text = "0";
            this.lblProcurementReceivedJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlPendingJEV
            // 
            this.pnlPendingJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPendingJEV.Controls.Add(this.lnkPending);
            this.pnlPendingJEV.Controls.Add(this.lblCashDisbursementsJournalCount);
            this.pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendingJEV.Location = new System.Drawing.Point(471, 13);
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
            this.lnkPending.Padding = new System.Windows.Forms.Padding(2);
            this.lnkPending.Size = new System.Drawing.Size(150, 42);
            this.lnkPending.TabIndex = 15;
            this.lnkPending.TabStop = true;
            this.lnkPending.Text = "Cash Disbursements Journal";
            this.lnkPending.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCashDisbursementsJournalCount
            // 
            this.lblCashDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCashDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCashDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCashDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCashDisbursementsJournalCount.Name = "lblCashDisbursementsJournalCount";
            this.lblCashDisbursementsJournalCount.Size = new System.Drawing.Size(150, 61);
            this.lblCashDisbursementsJournalCount.TabIndex = 6;
            this.lblCashDisbursementsJournalCount.Text = "0";
            this.lblCashDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            this.pnlApprovedJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlApprovedJEV.Controls.Add(this.lnkApproved);
            this.pnlApprovedJEV.Controls.Add(this.lblGeneralJournalCount);
            this.pnlApprovedJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApprovedJEV.Location = new System.Drawing.Point(3, 13);
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
            this.lnkApproved.Padding = new System.Windows.Forms.Padding(2);
            this.lnkApproved.Size = new System.Drawing.Size(150, 42);
            this.lnkApproved.TabIndex = 14;
            this.lnkApproved.TabStop = true;
            this.lnkApproved.Text = "General Journal";
            this.lnkApproved.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblGeneralJournalCount
            // 
            this.lblGeneralJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGeneralJournalCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGeneralJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGeneralJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblGeneralJournalCount.Name = "lblGeneralJournalCount";
            this.lblGeneralJournalCount.Size = new System.Drawing.Size(150, 61);
            this.lblGeneralJournalCount.TabIndex = 6;
            this.lblGeneralJournalCount.Text = "0";
            this.lblGeneralJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            this.pnlJEV.BackColor = System.Drawing.SystemColors.Control;
            this.pnlJEV.Controls.Add(this.lnkJEV);
            this.pnlJEV.Controls.Add(this.lblCashReceiptsJournalCount);
            this.pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJEV.Location = new System.Drawing.Point(159, 13);
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
            this.lnkJEV.Padding = new System.Windows.Forms.Padding(2);
            this.lnkJEV.Size = new System.Drawing.Size(150, 42);
            this.lnkJEV.TabIndex = 15;
            this.lnkJEV.TabStop = true;
            this.lnkJEV.Text = "Cash Receipts Journal";
            this.lnkJEV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCashReceiptsJournalCount
            // 
            this.lblCashReceiptsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCashReceiptsJournalCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCashReceiptsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCashReceiptsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCashReceiptsJournalCount.Name = "lblCashReceiptsJournalCount";
            this.lblCashReceiptsJournalCount.Size = new System.Drawing.Size(150, 61);
            this.lblCashReceiptsJournalCount.TabIndex = 6;
            this.lblCashReceiptsJournalCount.Text = "0";
            this.lblCashReceiptsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.linkDisapproved);
            this.panel1.Controls.Add(this.lblCheckDisbursementsJournalCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(627, 13);
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
            this.linkDisapproved.Padding = new System.Windows.Forms.Padding(2);
            this.linkDisapproved.Size = new System.Drawing.Size(150, 42);
            this.linkDisapproved.TabIndex = 16;
            this.linkDisapproved.TabStop = true;
            this.linkDisapproved.Text = "Check Disbursements Journal";
            this.linkDisapproved.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCheckDisbursementsJournalCount
            // 
            this.lblCheckDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCheckDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCheckDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCheckDisbursementsJournalCount.Name = "lblCheckDisbursementsJournalCount";
            this.lblCheckDisbursementsJournalCount.Size = new System.Drawing.Size(150, 61);
            this.lblCheckDisbursementsJournalCount.TabIndex = 6;
            this.lblCheckDisbursementsJournalCount.Text = "0";
            this.lblCheckDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lnkCancelled);
            this.panel2.Controls.Add(this.lblADADisbursementsJournal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(783, 13);
            this.panel2.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 115);
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
            this.lnkCancelled.Padding = new System.Windows.Forms.Padding(2);
            this.lnkCancelled.Size = new System.Drawing.Size(155, 42);
            this.lnkCancelled.TabIndex = 15;
            this.lnkCancelled.TabStop = true;
            this.lnkCancelled.Text = "ADA Disbursements Journal";
            this.lnkCancelled.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblADADisbursementsJournal
            // 
            this.lblADADisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblADADisbursementsJournal.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblADADisbursementsJournal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblADADisbursementsJournal.Location = new System.Drawing.Point(0, 0);
            this.lblADADisbursementsJournal.Name = "lblADADisbursementsJournal";
            this.lblADADisbursementsJournal.Size = new System.Drawing.Size(155, 61);
            this.lblADADisbursementsJournal.TabIndex = 6;
            this.lblADADisbursementsJournal.Text = "0";
            this.lblADADisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ucJournalsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(941, 160);
            this.Name = "ucJournalsDashboard";
            this.Size = new System.Drawing.Size(941, 160);
            this.Load += new System.EventHandler(this.ucJournalsDashboard_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlPendingJEV.ResumeLayout(false);
            this.pnlApprovedJEV.ResumeLayout(false);
            this.pnlJEV.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPendingJEV;
        private System.Windows.Forms.LinkLabel lnkPending;
        internal System.Windows.Forms.Label lblCashDisbursementsJournalCount;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        private System.Windows.Forms.LinkLabel lnkApproved;
        internal System.Windows.Forms.Label lblGeneralJournalCount;
        private System.Windows.Forms.Panel pnlJEV;
        private System.Windows.Forms.LinkLabel lnkJEV;
        internal System.Windows.Forms.Label lblCashReceiptsJournalCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkDisapproved;
        internal System.Windows.Forms.Label lblCheckDisbursementsJournalCount;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.LinkLabel lnkCancelled;
        internal System.Windows.Forms.Label lblADADisbursementsJournal;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.LinkLabel linkLabel1;
        internal System.Windows.Forms.Label lblProcurementReceivedJournalCount;
    }
}
