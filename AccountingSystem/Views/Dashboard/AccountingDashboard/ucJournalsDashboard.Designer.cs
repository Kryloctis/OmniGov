
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
            this.lnkProcurementReceivedJournal = new System.Windows.Forms.LinkLabel();
            this.lblProcurementReceivedJournalCount = new System.Windows.Forms.Label();
            this.pnlPendingJEV = new System.Windows.Forms.Panel();
            this.lnkCashDisbursementJournal = new System.Windows.Forms.LinkLabel();
            this.lblCashDisbursementsJournalCount = new System.Windows.Forms.Label();
            this.pnlApprovedJEV = new System.Windows.Forms.Panel();
            this.lnkGeneralJournal = new System.Windows.Forms.LinkLabel();
            this.lblGeneralJournalCount = new System.Windows.Forms.Label();
            this.pnlJEV = new System.Windows.Forms.Panel();
            this.lnkCashReceiptJournal = new System.Windows.Forms.LinkLabel();
            this.lblCashReceiptsJournalCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkCheckDisbursementsJournal = new System.Windows.Forms.LinkLabel();
            this.lblCheckDisbursementsJournalCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkADAdisbursementsJournal = new System.Windows.Forms.LinkLabel();
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
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lnkProcurementReceivedJournal);
            this.panel3.Controls.Add(this.lblProcurementReceivedJournalCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(315, 13);
            this.panel3.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 115);
            this.panel3.TabIndex = 30;
            // 
            // lnkProcurementReceivedJournal
            // 
            this.lnkProcurementReceivedJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkProcurementReceivedJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkProcurementReceivedJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkProcurementReceivedJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkProcurementReceivedJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkProcurementReceivedJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkProcurementReceivedJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkProcurementReceivedJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkProcurementReceivedJournal.Name = "lnkProcurementReceivedJournal";
            this.lnkProcurementReceivedJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkProcurementReceivedJournal.Size = new System.Drawing.Size(148, 42);
            this.lnkProcurementReceivedJournal.TabIndex = 15;
            this.lnkProcurementReceivedJournal.TabStop = true;
            this.lnkProcurementReceivedJournal.Text = "Procurement Received Journal";
            this.lnkProcurementReceivedJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkProcurementReceivedJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcurementReceivedJournal_LinkClicked);
            // 
            // lblProcurementReceivedJournalCount
            // 
            this.lblProcurementReceivedJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcurementReceivedJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProcurementReceivedJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProcurementReceivedJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblProcurementReceivedJournalCount.Name = "lblProcurementReceivedJournalCount";
            this.lblProcurementReceivedJournalCount.Size = new System.Drawing.Size(148, 61);
            this.lblProcurementReceivedJournalCount.TabIndex = 6;
            this.lblProcurementReceivedJournalCount.Text = "0";
            this.lblProcurementReceivedJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlPendingJEV
            // 
            this.pnlPendingJEV.BackColor = System.Drawing.Color.White;
            this.pnlPendingJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPendingJEV.Controls.Add(this.lnkCashDisbursementJournal);
            this.pnlPendingJEV.Controls.Add(this.lblCashDisbursementsJournalCount);
            this.pnlPendingJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPendingJEV.Location = new System.Drawing.Point(471, 13);
            this.pnlPendingJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlPendingJEV.Name = "pnlPendingJEV";
            this.pnlPendingJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlPendingJEV.TabIndex = 29;
            // 
            // lnkCashDisbursementJournal
            // 
            this.lnkCashDisbursementJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCashDisbursementJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkCashDisbursementJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCashDisbursementJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkCashDisbursementJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkCashDisbursementJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashDisbursementJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCashDisbursementJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkCashDisbursementJournal.Name = "lnkCashDisbursementJournal";
            this.lnkCashDisbursementJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkCashDisbursementJournal.Size = new System.Drawing.Size(148, 42);
            this.lnkCashDisbursementJournal.TabIndex = 15;
            this.lnkCashDisbursementJournal.TabStop = true;
            this.lnkCashDisbursementJournal.Text = "Cash Disbursements Journal";
            this.lnkCashDisbursementJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkCashDisbursementJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCashDisbursementJournal_LinkClicked);
            // 
            // lblCashDisbursementsJournalCount
            // 
            this.lblCashDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCashDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCashDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCashDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCashDisbursementsJournalCount.Name = "lblCashDisbursementsJournalCount";
            this.lblCashDisbursementsJournalCount.Size = new System.Drawing.Size(148, 61);
            this.lblCashDisbursementsJournalCount.TabIndex = 6;
            this.lblCashDisbursementsJournalCount.Text = "0";
            this.lblCashDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlApprovedJEV
            // 
            this.pnlApprovedJEV.BackColor = System.Drawing.Color.White;
            this.pnlApprovedJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlApprovedJEV.Controls.Add(this.lnkGeneralJournal);
            this.pnlApprovedJEV.Controls.Add(this.lblGeneralJournalCount);
            this.pnlApprovedJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApprovedJEV.Location = new System.Drawing.Point(3, 13);
            this.pnlApprovedJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlApprovedJEV.Name = "pnlApprovedJEV";
            this.pnlApprovedJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlApprovedJEV.TabIndex = 28;
            // 
            // lnkGeneralJournal
            // 
            this.lnkGeneralJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkGeneralJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkGeneralJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkGeneralJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkGeneralJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkGeneralJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGeneralJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkGeneralJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkGeneralJournal.Name = "lnkGeneralJournal";
            this.lnkGeneralJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkGeneralJournal.Size = new System.Drawing.Size(148, 42);
            this.lnkGeneralJournal.TabIndex = 14;
            this.lnkGeneralJournal.TabStop = true;
            this.lnkGeneralJournal.Text = "General Journal";
            this.lnkGeneralJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkGeneralJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGeneralJournal_LinkClicked);
            // 
            // lblGeneralJournalCount
            // 
            this.lblGeneralJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGeneralJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGeneralJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGeneralJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblGeneralJournalCount.Name = "lblGeneralJournalCount";
            this.lblGeneralJournalCount.Size = new System.Drawing.Size(148, 61);
            this.lblGeneralJournalCount.TabIndex = 6;
            this.lblGeneralJournalCount.Text = "0";
            this.lblGeneralJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlJEV
            // 
            this.pnlJEV.BackColor = System.Drawing.Color.White;
            this.pnlJEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJEV.Controls.Add(this.lnkCashReceiptJournal);
            this.pnlJEV.Controls.Add(this.lblCashReceiptsJournalCount);
            this.pnlJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJEV.Location = new System.Drawing.Point(159, 13);
            this.pnlJEV.MinimumSize = new System.Drawing.Size(150, 113);
            this.pnlJEV.Name = "pnlJEV";
            this.pnlJEV.Size = new System.Drawing.Size(150, 115);
            this.pnlJEV.TabIndex = 26;
            // 
            // lnkCashReceiptJournal
            // 
            this.lnkCashReceiptJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCashReceiptJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkCashReceiptJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCashReceiptJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkCashReceiptJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkCashReceiptJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCashReceiptJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCashReceiptJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkCashReceiptJournal.Name = "lnkCashReceiptJournal";
            this.lnkCashReceiptJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkCashReceiptJournal.Size = new System.Drawing.Size(148, 42);
            this.lnkCashReceiptJournal.TabIndex = 15;
            this.lnkCashReceiptJournal.TabStop = true;
            this.lnkCashReceiptJournal.Text = "Cash Receipts Journal";
            this.lnkCashReceiptJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkCashReceiptJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCashReceiptJournal_LinkClicked);
            // 
            // lblCashReceiptsJournalCount
            // 
            this.lblCashReceiptsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCashReceiptsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCashReceiptsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCashReceiptsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCashReceiptsJournalCount.Name = "lblCashReceiptsJournalCount";
            this.lblCashReceiptsJournalCount.Size = new System.Drawing.Size(148, 61);
            this.lblCashReceiptsJournalCount.TabIndex = 6;
            this.lblCashReceiptsJournalCount.Text = "0";
            this.lblCashReceiptsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lnkCheckDisbursementsJournal);
            this.panel1.Controls.Add(this.lblCheckDisbursementsJournalCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(627, 13);
            this.panel1.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 115);
            this.panel1.TabIndex = 22;
            // 
            // lnkCheckDisbursementsJournal
            // 
            this.lnkCheckDisbursementsJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCheckDisbursementsJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkCheckDisbursementsJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkCheckDisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkCheckDisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkCheckDisbursementsJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCheckDisbursementsJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkCheckDisbursementsJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkCheckDisbursementsJournal.Name = "lnkCheckDisbursementsJournal";
            this.lnkCheckDisbursementsJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkCheckDisbursementsJournal.Size = new System.Drawing.Size(148, 42);
            this.lnkCheckDisbursementsJournal.TabIndex = 16;
            this.lnkCheckDisbursementsJournal.TabStop = true;
            this.lnkCheckDisbursementsJournal.Text = "Check Disbursements Journal";
            this.lnkCheckDisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkCheckDisbursementsJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCheckDisbursementsJournal_LinkClicked);
            // 
            // lblCheckDisbursementsJournalCount
            // 
            this.lblCheckDisbursementsJournalCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckDisbursementsJournalCount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCheckDisbursementsJournalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCheckDisbursementsJournalCount.Location = new System.Drawing.Point(0, 0);
            this.lblCheckDisbursementsJournalCount.Name = "lblCheckDisbursementsJournalCount";
            this.lblCheckDisbursementsJournalCount.Size = new System.Drawing.Size(148, 61);
            this.lblCheckDisbursementsJournalCount.TabIndex = 6;
            this.lblCheckDisbursementsJournalCount.Text = "0";
            this.lblCheckDisbursementsJournalCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lnkADAdisbursementsJournal);
            this.panel2.Controls.Add(this.lblADADisbursementsJournal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(783, 13);
            this.panel2.MinimumSize = new System.Drawing.Size(150, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 115);
            this.panel2.TabIndex = 23;
            // 
            // lnkADAdisbursementsJournal
            // 
            this.lnkADAdisbursementsJournal.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkADAdisbursementsJournal.BackColor = System.Drawing.Color.Transparent;
            this.lnkADAdisbursementsJournal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkADAdisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lnkADAdisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lnkADAdisbursementsJournal.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkADAdisbursementsJournal.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkADAdisbursementsJournal.Location = new System.Drawing.Point(0, 61);
            this.lnkADAdisbursementsJournal.Name = "lnkADAdisbursementsJournal";
            this.lnkADAdisbursementsJournal.Padding = new System.Windows.Forms.Padding(2);
            this.lnkADAdisbursementsJournal.Size = new System.Drawing.Size(153, 42);
            this.lnkADAdisbursementsJournal.TabIndex = 15;
            this.lnkADAdisbursementsJournal.TabStop = true;
            this.lnkADAdisbursementsJournal.Text = "ADA Disbursements Journal";
            this.lnkADAdisbursementsJournal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkADAdisbursementsJournal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkADAdisbursementsJournal_LinkClicked);
            // 
            // lblADADisbursementsJournal
            // 
            this.lblADADisbursementsJournal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblADADisbursementsJournal.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblADADisbursementsJournal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblADADisbursementsJournal.Location = new System.Drawing.Point(0, 0);
            this.lblADADisbursementsJournal.Name = "lblADADisbursementsJournal";
            this.lblADADisbursementsJournal.Size = new System.Drawing.Size(153, 61);
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
