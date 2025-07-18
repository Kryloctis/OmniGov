
namespace LFS.Views.Dashboard.AccountingDashboard
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel3 = new System.Windows.Forms.Panel();
            lnkProcurementReceivedJournal = new System.Windows.Forms.LinkLabel();
            lblProcurementReceivedJournalCount = new System.Windows.Forms.Label();
            pnlPendingJEV = new System.Windows.Forms.Panel();
            lnkCashDisbursementJournal = new System.Windows.Forms.LinkLabel();
            lblCashDisbursementsJournalCount = new System.Windows.Forms.Label();
            pnlApprovedJEV = new System.Windows.Forms.Panel();
            lnkGeneralJournal = new System.Windows.Forms.LinkLabel();
            lblGeneralJournalCount = new System.Windows.Forms.Label();
            pnlJEV = new System.Windows.Forms.Panel();
            lnkCashReceiptJournal = new System.Windows.Forms.LinkLabel();
            lblCashReceiptsJournalCount = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            lnkCheckDisbursementsJournal = new System.Windows.Forms.LinkLabel();
            lblCheckDisbursementsJournalCount = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            lnkADAdisbursementsJournal = new System.Windows.Forms.LinkLabel();
            lblADADisbursementsJournal = new System.Windows.Forms.Label();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            pnlPendingJEV.SuspendLayout();
            pnlApprovedJEV.SuspendLayout();
            pnlJEV.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(cmbxFunds);
            flowLayoutPanel1.Controls.Add(dateTimePicker1);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(941, 29);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(3, 3);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(208, 23);
            cmbxFunds.TabIndex = 0;
            cmbxFunds.SelectedValueChanged += cmbxFunds_SelectedValueChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMMM-  yyyy";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new System.Drawing.Point(217, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(211, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlPendingJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlApprovedJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlJEV, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 3, 0);
            tableLayoutPanel1.Controls.Add(panel2, 4, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.MinimumSize = new System.Drawing.Size(781, 121);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(941, 131);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.White;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(lnkProcurementReceivedJournal);
            panel3.Controls.Add(lblProcurementReceivedJournalCount);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(315, 13);
            panel3.MinimumSize = new System.Drawing.Size(150, 113);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(150, 115);
            panel3.TabIndex = 30;
            // 
            // lnkProcurementReceivedJournal
            // 
            lnkProcurementReceivedJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkProcurementReceivedJournal.BackColor = System.Drawing.Color.Transparent;
            lnkProcurementReceivedJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkProcurementReceivedJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkProcurementReceivedJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkProcurementReceivedJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkProcurementReceivedJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkProcurementReceivedJournal.Location = new System.Drawing.Point(0, 61);
            lnkProcurementReceivedJournal.Name = "lnkProcurementReceivedJournal";
            lnkProcurementReceivedJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkProcurementReceivedJournal.Size = new System.Drawing.Size(148, 42);
            lnkProcurementReceivedJournal.TabIndex = 15;
            lnkProcurementReceivedJournal.TabStop = true;
            lnkProcurementReceivedJournal.Text = "Procurement Received Journal";
            lnkProcurementReceivedJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkProcurementReceivedJournal.LinkClicked += lnkProcurementReceivedJournal_LinkClicked;
            // 
            // lblProcurementReceivedJournalCount
            // 
            lblProcurementReceivedJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            lblProcurementReceivedJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblProcurementReceivedJournalCount.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblProcurementReceivedJournalCount.Location = new System.Drawing.Point(0, 0);
            lblProcurementReceivedJournalCount.Name = "lblProcurementReceivedJournalCount";
            lblProcurementReceivedJournalCount.Size = new System.Drawing.Size(148, 61);
            lblProcurementReceivedJournalCount.TabIndex = 6;
            lblProcurementReceivedJournalCount.Text = "0";
            lblProcurementReceivedJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlPendingJEV
            // 
            pnlPendingJEV.BackColor = System.Drawing.Color.White;
            pnlPendingJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlPendingJEV.Controls.Add(lnkCashDisbursementJournal);
            pnlPendingJEV.Controls.Add(lblCashDisbursementsJournalCount);
            pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlPendingJEV.Location = new System.Drawing.Point(471, 13);
            pnlPendingJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlPendingJEV.Name = "pnlPendingJEV";
            pnlPendingJEV.Size = new System.Drawing.Size(150, 115);
            pnlPendingJEV.TabIndex = 29;
            // 
            // lnkCashDisbursementJournal
            // 
            lnkCashDisbursementJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCashDisbursementJournal.BackColor = System.Drawing.Color.Transparent;
            lnkCashDisbursementJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkCashDisbursementJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkCashDisbursementJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkCashDisbursementJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkCashDisbursementJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCashDisbursementJournal.Location = new System.Drawing.Point(0, 61);
            lnkCashDisbursementJournal.Name = "lnkCashDisbursementJournal";
            lnkCashDisbursementJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkCashDisbursementJournal.Size = new System.Drawing.Size(148, 42);
            lnkCashDisbursementJournal.TabIndex = 15;
            lnkCashDisbursementJournal.TabStop = true;
            lnkCashDisbursementJournal.Text = "Cash Disbursements Journal";
            lnkCashDisbursementJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkCashDisbursementJournal.LinkClicked += lnkCashDisbursementJournal_LinkClicked;
            // 
            // lblCashDisbursementsJournalCount
            // 
            lblCashDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            lblCashDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblCashDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblCashDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            lblCashDisbursementsJournalCount.Name = "lblCashDisbursementsJournalCount";
            lblCashDisbursementsJournalCount.Size = new System.Drawing.Size(148, 61);
            lblCashDisbursementsJournalCount.TabIndex = 6;
            lblCashDisbursementsJournalCount.Text = "0";
            lblCashDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            pnlApprovedJEV.BackColor = System.Drawing.Color.White;
            pnlApprovedJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlApprovedJEV.Controls.Add(lnkGeneralJournal);
            pnlApprovedJEV.Controls.Add(lblGeneralJournalCount);
            pnlApprovedJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlApprovedJEV.Location = new System.Drawing.Point(3, 13);
            pnlApprovedJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlApprovedJEV.Name = "pnlApprovedJEV";
            pnlApprovedJEV.Size = new System.Drawing.Size(150, 115);
            pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkGeneralJournal
            // 
            lnkGeneralJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkGeneralJournal.BackColor = System.Drawing.Color.Transparent;
            lnkGeneralJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkGeneralJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkGeneralJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkGeneralJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkGeneralJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkGeneralJournal.Location = new System.Drawing.Point(0, 61);
            lnkGeneralJournal.Name = "lnkGeneralJournal";
            lnkGeneralJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkGeneralJournal.Size = new System.Drawing.Size(148, 42);
            lnkGeneralJournal.TabIndex = 14;
            lnkGeneralJournal.TabStop = true;
            lnkGeneralJournal.Text = "General Journal";
            lnkGeneralJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkGeneralJournal.LinkClicked += lnkGeneralJournal_LinkClicked;
            // 
            // lblGeneralJournalCount
            // 
            lblGeneralJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            lblGeneralJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblGeneralJournalCount.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblGeneralJournalCount.Location = new System.Drawing.Point(0, 0);
            lblGeneralJournalCount.Name = "lblGeneralJournalCount";
            lblGeneralJournalCount.Size = new System.Drawing.Size(148, 61);
            lblGeneralJournalCount.TabIndex = 6;
            lblGeneralJournalCount.Text = "0";
            lblGeneralJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            pnlJEV.BackColor = System.Drawing.Color.White;
            pnlJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlJEV.Controls.Add(lnkCashReceiptJournal);
            pnlJEV.Controls.Add(lblCashReceiptsJournalCount);
            pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlJEV.Location = new System.Drawing.Point(159, 13);
            pnlJEV.MinimumSize = new System.Drawing.Size(150, 113);
            pnlJEV.Name = "pnlJEV";
            pnlJEV.Size = new System.Drawing.Size(150, 115);
            pnlJEV.TabIndex = 26;
            // 
            // lnkCashReceiptJournal
            // 
            lnkCashReceiptJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCashReceiptJournal.BackColor = System.Drawing.Color.Transparent;
            lnkCashReceiptJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkCashReceiptJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkCashReceiptJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkCashReceiptJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkCashReceiptJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCashReceiptJournal.Location = new System.Drawing.Point(0, 61);
            lnkCashReceiptJournal.Name = "lnkCashReceiptJournal";
            lnkCashReceiptJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkCashReceiptJournal.Size = new System.Drawing.Size(148, 42);
            lnkCashReceiptJournal.TabIndex = 15;
            lnkCashReceiptJournal.TabStop = true;
            lnkCashReceiptJournal.Text = "Cash Receipts Journal";
            lnkCashReceiptJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkCashReceiptJournal.LinkClicked += lnkCashReceiptJournal_LinkClicked;
            // 
            // lblCashReceiptsJournalCount
            // 
            lblCashReceiptsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            lblCashReceiptsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblCashReceiptsJournalCount.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblCashReceiptsJournalCount.Location = new System.Drawing.Point(0, 0);
            lblCashReceiptsJournalCount.Name = "lblCashReceiptsJournalCount";
            lblCashReceiptsJournalCount.Size = new System.Drawing.Size(148, 61);
            lblCashReceiptsJournalCount.TabIndex = 6;
            lblCashReceiptsJournalCount.Text = "0";
            lblCashReceiptsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(lnkCheckDisbursementsJournal);
            panel1.Controls.Add(lblCheckDisbursementsJournalCount);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(627, 13);
            panel1.MinimumSize = new System.Drawing.Size(150, 113);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(150, 115);
            panel1.TabIndex = 22;
            // 
            // lnkCheckDisbursementsJournal
            // 
            lnkCheckDisbursementsJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCheckDisbursementsJournal.BackColor = System.Drawing.Color.Transparent;
            lnkCheckDisbursementsJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkCheckDisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkCheckDisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkCheckDisbursementsJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkCheckDisbursementsJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkCheckDisbursementsJournal.Location = new System.Drawing.Point(0, 61);
            lnkCheckDisbursementsJournal.Name = "lnkCheckDisbursementsJournal";
            lnkCheckDisbursementsJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkCheckDisbursementsJournal.Size = new System.Drawing.Size(148, 42);
            lnkCheckDisbursementsJournal.TabIndex = 16;
            lnkCheckDisbursementsJournal.TabStop = true;
            lnkCheckDisbursementsJournal.Text = "Check Disbursements Journal";
            lnkCheckDisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkCheckDisbursementsJournal.LinkClicked += lnkCheckDisbursementsJournal_LinkClicked;
            // 
            // lblCheckDisbursementsJournalCount
            // 
            lblCheckDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            lblCheckDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblCheckDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblCheckDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            lblCheckDisbursementsJournalCount.Name = "lblCheckDisbursementsJournalCount";
            lblCheckDisbursementsJournalCount.Size = new System.Drawing.Size(148, 61);
            lblCheckDisbursementsJournalCount.TabIndex = 6;
            lblCheckDisbursementsJournalCount.Text = "0";
            lblCheckDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.White;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(lnkADAdisbursementsJournal);
            panel2.Controls.Add(lblADADisbursementsJournal);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(783, 13);
            panel2.MinimumSize = new System.Drawing.Size(150, 113);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(155, 115);
            panel2.TabIndex = 23;
            // 
            // lnkADAdisbursementsJournal
            // 
            lnkADAdisbursementsJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkADAdisbursementsJournal.BackColor = System.Drawing.Color.Transparent;
            lnkADAdisbursementsJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            lnkADAdisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lnkADAdisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            lnkADAdisbursementsJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            lnkADAdisbursementsJournal.LinkColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lnkADAdisbursementsJournal.Location = new System.Drawing.Point(0, 61);
            lnkADAdisbursementsJournal.Name = "lnkADAdisbursementsJournal";
            lnkADAdisbursementsJournal.Padding = new System.Windows.Forms.Padding(2);
            lnkADAdisbursementsJournal.Size = new System.Drawing.Size(153, 42);
            lnkADAdisbursementsJournal.TabIndex = 15;
            lnkADAdisbursementsJournal.TabStop = true;
            lnkADAdisbursementsJournal.Text = "ADA Disbursements Journal";
            lnkADAdisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lnkADAdisbursementsJournal.LinkClicked += lnkADAdisbursementsJournal_LinkClicked;
            // 
            // lblADADisbursementsJournal
            // 
            lblADADisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            lblADADisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold);
            lblADADisbursementsJournal.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblADADisbursementsJournal.Location = new System.Drawing.Point(0, 0);
            lblADADisbursementsJournal.Name = "lblADADisbursementsJournal";
            lblADADisbursementsJournal.Size = new System.Drawing.Size(153, 61);
            lblADADisbursementsJournal.TabIndex = 6;
            lblADADisbursementsJournal.Text = "0";
            lblADADisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ucJournalsDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            MinimumSize = new System.Drawing.Size(941, 160);
            Name = "ucJournalsDashboard";
            Size = new System.Drawing.Size(941, 160);
            Load += ucJournalsDashboard_Load;
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            pnlPendingJEV.ResumeLayout(false);
            pnlApprovedJEV.ResumeLayout(false);
            pnlJEV.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlPendingJEV;
        internal System.Windows.Forms.Label lblCashDisbursementsJournalCount;
        private System.Windows.Forms.Panel pnlApprovedJEV;
        internal System.Windows.Forms.Label lblGeneralJournalCount;
        private System.Windows.Forms.Panel pnlJEV;
        internal System.Windows.Forms.Label lblCashReceiptsJournalCount;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblCheckDisbursementsJournalCount;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.LinkLabel lnkADAdisbursementsJournal;
        internal System.Windows.Forms.Label lblADADisbursementsJournal;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.LinkLabel lnkProcurementReceivedJournal;
        internal System.Windows.Forms.Label lblProcurementReceivedJournalCount;
        internal System.Windows.Forms.LinkLabel lnkCashDisbursementJournal;
        internal System.Windows.Forms.LinkLabel lnkGeneralJournal;
        internal System.Windows.Forms.LinkLabel lnkCashReceiptJournal;
        internal System.Windows.Forms.LinkLabel lnkCheckDisbursementsJournal;
    }
}
