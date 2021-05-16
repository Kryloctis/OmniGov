
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class ucJEV
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupFunds = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.groupJournals = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelJournals = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblCollectingDisbursingOfficer = new System.Windows.Forms.Label();
            this.txtRCIORADA = new System.Windows.Forms.TextBox();
            this.lblRciOrADANo = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.FPPId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeneralLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubsidiaryLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subsidiary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJEVNo = new System.Windows.Forms.MaskedTextBox();
            this.txtFundsJevNo = new System.Windows.Forms.TextBox();
            this.epJEV = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtDebitTotal = new System.Windows.Forms.TextBox();
            this.txtCreditTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.epRefNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCollectingOfficerPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbCollectingDisbursingOfficer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCheckORPaidDate = new System.Windows.Forms.Label();
            this.dtpCheckORPaid = new System.Windows.Forms.DateTimePicker();
            this.txtDVRCDNo = new System.Windows.Forms.TextBox();
            this.lblDVRCDNo = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.lblCheckNo = new System.Windows.Forms.Label();
            this.groupFunds.SuspendLayout();
            this.groupJournals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJEV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRefNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficerPayee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFunds
            // 
            this.groupFunds.AutoSize = true;
            this.groupFunds.Controls.Add(this.flowLayoutPanelFunds);
            this.groupFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupFunds.Location = new System.Drawing.Point(3, 0);
            this.groupFunds.Name = "groupFunds";
            this.groupFunds.Size = new System.Drawing.Size(857, 61);
            this.groupFunds.TabIndex = 9;
            this.groupFunds.TabStop = false;
            this.groupFunds.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.AutoSize = true;
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(851, 39);
            this.flowLayoutPanelFunds.TabIndex = 0;
            // 
            // groupJournals
            // 
            this.groupJournals.AutoSize = true;
            this.groupJournals.Controls.Add(this.flowLayoutPanelJournals);
            this.groupJournals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupJournals.Location = new System.Drawing.Point(3, 67);
            this.groupJournals.Name = "groupJournals";
            this.groupJournals.Size = new System.Drawing.Size(857, 94);
            this.groupJournals.TabIndex = 10;
            this.groupJournals.TabStop = false;
            this.groupJournals.Text = "Journals";
            // 
            // flowLayoutPanelJournals
            // 
            this.flowLayoutPanelJournals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelJournals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelJournals.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelJournals.Name = "flowLayoutPanelJournals";
            this.flowLayoutPanelJournals.Size = new System.Drawing.Size(851, 72);
            this.flowLayoutPanelJournals.TabIndex = 0;
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Location = new System.Drawing.Point(783, 525);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAccount.TabIndex = 12;
            this.btnRemoveAccount.Text = "Remove";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(702, 525);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 23);
            this.btnEditAccount.TabIndex = 11;
            this.btnEditAccount.Text = "Edit...";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(621, 525);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 10;
            this.btnAddAccount.Text = "Add...";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // lblCollectingDisbursingOfficer
            // 
            this.lblCollectingDisbursingOfficer.AutoSize = true;
            this.lblCollectingDisbursingOfficer.Location = new System.Drawing.Point(423, 316);
            this.lblCollectingDisbursingOfficer.Name = "lblCollectingDisbursingOfficer";
            this.lblCollectingDisbursingOfficer.Size = new System.Drawing.Size(161, 15);
            this.lblCollectingDisbursingOfficer.TabIndex = 41;
            this.lblCollectingDisbursingOfficer.Text = "Collecting/Disbursing Officer";
            // 
            // txtRCIORADA
            // 
            this.txtRCIORADA.Location = new System.Drawing.Point(542, 255);
            this.txtRCIORADA.MaxLength = 30;
            this.txtRCIORADA.Name = "txtRCIORADA";
            this.txtRCIORADA.Size = new System.Drawing.Size(315, 23);
            this.txtRCIORADA.TabIndex = 7;
            this.txtRCIORADA.Validating += new System.ComponentModel.CancelEventHandler(this.txtRefNo_Validating);
            this.txtRCIORADA.Validated += new System.EventHandler(this.txtRefNo_Validated);
            // 
            // lblRciOrADANo
            // 
            this.lblRciOrADANo.AutoSize = true;
            this.lblRciOrADANo.Location = new System.Drawing.Point(423, 258);
            this.lblRciOrADANo.Name = "lblRciOrADANo";
            this.lblRciOrADANo.Size = new System.Drawing.Size(97, 15);
            this.lblRciOrADANo.TabIndex = 39;
            this.lblRciOrADANo.Text = "RCI/OR/ADA No.";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(81, 226);
            this.txtPayee.MaxLength = 99;
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(315, 23);
            this.txtPayee.TabIndex = 2;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayeeCollectingOfficer_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayeeCollectingOfficer_Validated);
            // 
            // dgAccounts
            // 
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FPPId,
            this.GeneralLedgerId,
            this.SubsidiaryLedgerId,
            this.IsDebit,
            this.IsDeposit,
            this.FPP,
            this.AccountName,
            this.AccountCode,
            this.Subsidiary,
            this.Debit,
            this.Credit});
            this.dgAccounts.Location = new System.Drawing.Point(4, 346);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowTemplate.Height = 25;
            this.dgAccounts.Size = new System.Drawing.Size(854, 173);
            this.dgAccounts.TabIndex = 37;
            this.dgAccounts.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgAccounts_RowHeaderMouseDoubleClick);
            this.dgAccounts.SelectionChanged += new System.EventHandler(this.dgAccounts_SelectionChanged);
            // 
            // FPPId
            // 
            this.FPPId.HeaderText = "FPPId";
            this.FPPId.Name = "FPPId";
            this.FPPId.ReadOnly = true;
            this.FPPId.Visible = false;
            // 
            // GeneralLedgerId
            // 
            this.GeneralLedgerId.HeaderText = "GeneralLedgerId";
            this.GeneralLedgerId.Name = "GeneralLedgerId";
            this.GeneralLedgerId.ReadOnly = true;
            this.GeneralLedgerId.Visible = false;
            // 
            // SubsidiaryLedgerId
            // 
            this.SubsidiaryLedgerId.HeaderText = "SubsidiaryLedgerId";
            this.SubsidiaryLedgerId.Name = "SubsidiaryLedgerId";
            this.SubsidiaryLedgerId.ReadOnly = true;
            this.SubsidiaryLedgerId.Visible = false;
            // 
            // IsDebit
            // 
            this.IsDebit.HeaderText = "IsDebit";
            this.IsDebit.Name = "IsDebit";
            this.IsDebit.ReadOnly = true;
            this.IsDebit.Visible = false;
            // 
            // IsDeposit
            // 
            this.IsDeposit.HeaderText = "IsDeposit";
            this.IsDeposit.Name = "IsDeposit";
            this.IsDeposit.ReadOnly = true;
            this.IsDeposit.Visible = false;
            // 
            // FPP
            // 
            this.FPP.HeaderText = "FPP";
            this.FPP.Name = "FPP";
            this.FPP.ReadOnly = true;
            this.FPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AccountName
            // 
            this.AccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AccountCode
            // 
            this.AccountCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AccountCode.HeaderText = "Account Code";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.ReadOnly = true;
            this.AccountCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AccountCode.Width = 89;
            // 
            // Subsidiary
            // 
            this.Subsidiary.HeaderText = "Subsidiary";
            this.Subsidiary.Name = "Subsidiary";
            this.Subsidiary.ReadOnly = true;
            this.Subsidiary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Subsidiary.Width = 200;
            // 
            // Debit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Credit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(81, 255);
            this.txtExplanation.MaxLength = 250;
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(315, 81);
            this.txtExplanation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Explanation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date of Entry";
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Location = new System.Drawing.Point(542, 168);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(315, 23);
            this.dtpDateEntry.TabIndex = 4;
            this.dtpDateEntry.ValueChanged += new System.EventHandler(this.dtpDateEntry_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "JEV No.";
            // 
            // txtJEVNo
            // 
            this.txtJEVNo.Location = new System.Drawing.Point(159, 168);
            this.txtJEVNo.Mask = "0000";
            this.txtJEVNo.Name = "txtJEVNo";
            this.txtJEVNo.Size = new System.Drawing.Size(39, 23);
            this.txtJEVNo.TabIndex = 0;
            this.txtJEVNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtJEVNo_Validating);
            this.txtJEVNo.Validated += new System.EventHandler(this.txtJEVNo_Validated);
            // 
            // txtFundsJevNo
            // 
            this.txtFundsJevNo.Location = new System.Drawing.Point(81, 168);
            this.txtFundsJevNo.Name = "txtFundsJevNo";
            this.txtFundsJevNo.ReadOnly = true;
            this.txtFundsJevNo.Size = new System.Drawing.Size(72, 23);
            this.txtFundsJevNo.TabIndex = 45;
            this.txtFundsJevNo.Text = "00-0000-00";
            // 
            // epJEV
            // 
            this.epJEV.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 529);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 46;
            this.label5.Text = "Debit";
            // 
            // txtDebitTotal
            // 
            this.txtDebitTotal.Location = new System.Drawing.Point(48, 525);
            this.txtDebitTotal.Name = "txtDebitTotal";
            this.txtDebitTotal.ReadOnly = true;
            this.txtDebitTotal.Size = new System.Drawing.Size(100, 23);
            this.txtDebitTotal.TabIndex = 47;
            this.txtDebitTotal.TabStop = false;
            this.txtDebitTotal.Text = "0.00";
            this.txtDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditTotal
            // 
            this.txtCreditTotal.Location = new System.Drawing.Point(201, 524);
            this.txtCreditTotal.Name = "txtCreditTotal";
            this.txtCreditTotal.ReadOnly = true;
            this.txtCreditTotal.Size = new System.Drawing.Size(100, 23);
            this.txtCreditTotal.TabIndex = 49;
            this.txtCreditTotal.TabStop = false;
            this.txtCreditTotal.Text = "0.00";
            this.txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 528);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 48;
            this.label6.Text = "Credit";
            // 
            // epRefNo
            // 
            this.epRefNo.ContainerControl = this;
            // 
            // epCollectingOfficerPayee
            // 
            this.epCollectingOfficerPayee.ContainerControl = this;
            // 
            // cmbCollectingDisbursingOfficer
            // 
            this.cmbCollectingDisbursingOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollectingDisbursingOfficer.FormattingEnabled = true;
            this.cmbCollectingDisbursingOfficer.Location = new System.Drawing.Point(542, 313);
            this.cmbCollectingDisbursingOfficer.Name = "cmbCollectingDisbursingOfficer";
            this.cmbCollectingDisbursingOfficer.Size = new System.Drawing.Size(315, 23);
            this.cmbCollectingDisbursingOfficer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Payee";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(81, 197);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(315, 23);
            this.txtRefNo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "Ref No.";
            // 
            // lblCheckORPaidDate
            // 
            this.lblCheckORPaidDate.AutoSize = true;
            this.lblCheckORPaidDate.Location = new System.Drawing.Point(423, 203);
            this.lblCheckORPaidDate.Name = "lblCheckORPaidDate";
            this.lblCheckORPaidDate.Size = new System.Drawing.Size(116, 15);
            this.lblCheckORPaidDate.TabIndex = 55;
            this.lblCheckORPaidDate.Text = "Check/OR/Paid Date";
            // 
            // dtpCheckORPaid
            // 
            this.dtpCheckORPaid.Location = new System.Drawing.Point(542, 197);
            this.dtpCheckORPaid.Name = "dtpCheckORPaid";
            this.dtpCheckORPaid.Size = new System.Drawing.Size(315, 23);
            this.dtpCheckORPaid.TabIndex = 5;
            // 
            // txtDVRCDNo
            // 
            this.txtDVRCDNo.Location = new System.Drawing.Point(542, 284);
            this.txtDVRCDNo.MaxLength = 30;
            this.txtDVRCDNo.Name = "txtDVRCDNo";
            this.txtDVRCDNo.Size = new System.Drawing.Size(315, 23);
            this.txtDVRCDNo.TabIndex = 8;
            // 
            // lblDVRCDNo
            // 
            this.lblDVRCDNo.AutoSize = true;
            this.lblDVRCDNo.Location = new System.Drawing.Point(423, 287);
            this.lblDVRCDNo.Name = "lblDVRCDNo";
            this.lblDVRCDNo.Size = new System.Drawing.Size(72, 15);
            this.lblDVRCDNo.TabIndex = 57;
            this.lblDVRCDNo.Text = "DV/RCD No.";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Location = new System.Drawing.Point(542, 226);
            this.txtCheckNo.MaxLength = 30;
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(315, 23);
            this.txtCheckNo.TabIndex = 6;
            // 
            // lblCheckNo
            // 
            this.lblCheckNo.AutoSize = true;
            this.lblCheckNo.Location = new System.Drawing.Point(423, 229);
            this.lblCheckNo.Name = "lblCheckNo";
            this.lblCheckNo.Size = new System.Drawing.Size(62, 15);
            this.lblCheckNo.TabIndex = 61;
            this.lblCheckNo.Text = "Check No.";
            // 
            // ucJEV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.lblCheckNo);
            this.Controls.Add(this.txtDVRCDNo);
            this.Controls.Add(this.lblDVRCDNo);
            this.Controls.Add(this.lblCheckORPaidDate);
            this.Controls.Add(this.dtpCheckORPaid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCollectingDisbursingOfficer);
            this.Controls.Add(this.txtCreditTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDebitTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFundsJevNo);
            this.Controls.Add(this.btnRemoveAccount);
            this.Controls.Add(this.btnEditAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.lblCollectingDisbursingOfficer);
            this.Controls.Add(this.txtRCIORADA);
            this.Controls.Add(this.lblRciOrADANo);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJEVNo);
            this.Controls.Add(this.groupJournals);
            this.Controls.Add(this.groupFunds);
            this.Name = "ucJEV";
            this.Size = new System.Drawing.Size(886, 566);
            this.Load += new System.EventHandler(this.ucJEV_Load);
            this.groupFunds.ResumeLayout(false);
            this.groupFunds.PerformLayout();
            this.groupJournals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJEV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRefNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCollectingOfficerPayee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label lblCollectingDisbursingOfficer;
        private System.Windows.Forms.Label lblRciOrADANo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtRCIORADA;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.DataGridView dgAccounts;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.DateTimePicker dtpDateEntry;
        internal System.Windows.Forms.MaskedTextBox txtJEVNo;
        private System.Windows.Forms.ErrorProvider epJEV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtFundsJevNo;
        private System.Windows.Forms.ErrorProvider epRefNo;
        private System.Windows.Forms.ErrorProvider epCollectingOfficerPayee;
        internal System.Windows.Forms.TextBox txtCreditTotal;
        internal System.Windows.Forms.TextBox txtDebitTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPPId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeneralLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubsidiaryLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subsidiary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        internal System.Windows.Forms.GroupBox groupJournals;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelJournals;
        private System.Windows.Forms.GroupBox groupFunds;
        internal System.Windows.Forms.ComboBox cmbCollectingDisbursingOfficer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCheckORPaidDate;
        internal System.Windows.Forms.DateTimePicker dtpCheckORPaid;
        internal System.Windows.Forms.TextBox txtDVRCDNo;
        private System.Windows.Forms.Label lblDVRCDNo;
        internal System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label lblCheckNo;
        internal System.Windows.Forms.TextBox txtRefNo;
    }
}
