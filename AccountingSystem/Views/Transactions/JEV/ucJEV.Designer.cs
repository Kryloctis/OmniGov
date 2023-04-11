
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            groupFunds = new System.Windows.Forms.GroupBox();
            flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            groupJournals = new System.Windows.Forms.GroupBox();
            flowLayoutPanelJournals = new System.Windows.Forms.FlowLayoutPanel();
            btnRemoveAccount = new System.Windows.Forms.Button();
            btnEditAccount = new System.Windows.Forms.Button();
            btnAddAccount = new System.Windows.Forms.Button();
            lblCollectingDisbursingOfficer = new System.Windows.Forms.Label();
            txtRCIORADA = new System.Windows.Forms.TextBox();
            lblRciOrADANo = new System.Windows.Forms.Label();
            txtPayee = new System.Windows.Forms.TextBox();
            dgAccounts = new System.Windows.Forms.DataGridView();
            FPPId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            GeneralLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SubsidiaryLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            IsDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            FPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Subsidiary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            obligationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            IsDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            txtExplanation = new System.Windows.Forms.TextBox();
            lblExplanation = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            txtJEVNo = new System.Windows.Forms.MaskedTextBox();
            txtFundsJevNo = new System.Windows.Forms.TextBox();
            epJEV = new System.Windows.Forms.ErrorProvider(components);
            label5 = new System.Windows.Forms.Label();
            txtDebitTotal = new System.Windows.Forms.TextBox();
            txtCreditTotal = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            epPayee = new System.Windows.Forms.ErrorProvider(components);
            cmbCollectingDisbursingOfficer = new System.Windows.Forms.ComboBox();
            lblPayee = new System.Windows.Forms.Label();
            txtRefNo = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            lblCheckORPaidDate = new System.Windows.Forms.Label();
            dtpCheckORPaid = new System.Windows.Forms.DateTimePicker();
            txtDVRCDNo = new System.Windows.Forms.TextBox();
            lblDVRCDNo = new System.Windows.Forms.Label();
            lblCheckNo = new System.Windows.Forms.Label();
            epExplanation = new System.Windows.Forms.ErrorProvider(components);
            txtCheckNo = new System.Windows.Forms.TextBox();
            epCollectingDisbursing = new System.Windows.Forms.ErrorProvider(components);
            groupFunds.SuspendLayout();
            groupJournals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epJEV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epPayee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epExplanation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epCollectingDisbursing).BeginInit();
            SuspendLayout();
            // 
            // groupFunds
            // 
            groupFunds.AutoSize = true;
            groupFunds.Controls.Add(flowLayoutPanelFunds);
            groupFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupFunds.Location = new System.Drawing.Point(3, 0);
            groupFunds.Name = "groupFunds";
            groupFunds.Size = new System.Drawing.Size(1071, 61);
            groupFunds.TabIndex = 9;
            groupFunds.TabStop = false;
            groupFunds.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            flowLayoutPanelFunds.AutoSize = true;
            flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            flowLayoutPanelFunds.Size = new System.Drawing.Size(1065, 39);
            flowLayoutPanelFunds.TabIndex = 0;
            // 
            // groupJournals
            // 
            groupJournals.AutoSize = true;
            groupJournals.Controls.Add(flowLayoutPanelJournals);
            groupJournals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupJournals.Location = new System.Drawing.Point(3, 67);
            groupJournals.Name = "groupJournals";
            groupJournals.Size = new System.Drawing.Size(1071, 94);
            groupJournals.TabIndex = 10;
            groupJournals.TabStop = false;
            groupJournals.Text = "Journals";
            // 
            // flowLayoutPanelJournals
            // 
            flowLayoutPanelJournals.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanelJournals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanelJournals.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanelJournals.Name = "flowLayoutPanelJournals";
            flowLayoutPanelJournals.Size = new System.Drawing.Size(1065, 72);
            flowLayoutPanelJournals.TabIndex = 0;
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.Location = new System.Drawing.Point(999, 521);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new System.Drawing.Size(75, 23);
            btnRemoveAccount.TabIndex = 12;
            btnRemoveAccount.Text = "Remove";
            btnRemoveAccount.UseVisualStyleBackColor = true;
            btnRemoveAccount.Click += btnRemoveAccount_Click;
            // 
            // btnEditAccount
            // 
            btnEditAccount.Location = new System.Drawing.Point(918, 521);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.Size = new System.Drawing.Size(75, 23);
            btnEditAccount.TabIndex = 11;
            btnEditAccount.Text = "Edit...";
            btnEditAccount.UseVisualStyleBackColor = true;
            btnEditAccount.Click += btnEditAccount_Click;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Location = new System.Drawing.Point(837, 521);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new System.Drawing.Size(75, 23);
            btnAddAccount.TabIndex = 10;
            btnAddAccount.Text = "Add...";
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // lblCollectingDisbursingOfficer
            // 
            lblCollectingDisbursingOfficer.AutoSize = true;
            lblCollectingDisbursingOfficer.Location = new System.Drawing.Point(548, 316);
            lblCollectingDisbursingOfficer.Name = "lblCollectingDisbursingOfficer";
            lblCollectingDisbursingOfficer.Size = new System.Drawing.Size(161, 15);
            lblCollectingDisbursingOfficer.TabIndex = 41;
            lblCollectingDisbursingOfficer.Text = "Collecting/Disbursing Officer";
            // 
            // txtRCIORADA
            // 
            txtRCIORADA.Location = new System.Drawing.Point(696, 255);
            txtRCIORADA.MaxLength = 30;
            txtRCIORADA.Name = "txtRCIORADA";
            txtRCIORADA.Size = new System.Drawing.Size(378, 23);
            txtRCIORADA.TabIndex = 7;
            // 
            // lblRciOrADANo
            // 
            lblRciOrADANo.AutoSize = true;
            lblRciOrADANo.Location = new System.Drawing.Point(548, 258);
            lblRciOrADANo.Name = "lblRciOrADANo";
            lblRciOrADANo.Size = new System.Drawing.Size(97, 15);
            lblRciOrADANo.TabIndex = 39;
            lblRciOrADANo.Text = "RCI/OR/ADA No.";
            // 
            // txtPayee
            // 
            txtPayee.Location = new System.Drawing.Point(81, 226);
            txtPayee.MaxLength = 99;
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(378, 23);
            txtPayee.TabIndex = 2;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // dgAccounts
            // 
            dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { FPPId, GeneralLedgerId, SubsidiaryLedgerId, IsDebit, FPP, AccountName, AccountCode, Subsidiary, obligationNo, Debit, Credit, IsDeposit });
            dgAccounts.Location = new System.Drawing.Point(3, 342);
            dgAccounts.Name = "dgAccounts";
            dgAccounts.RowHeadersWidth = 51;
            dgAccounts.RowTemplate.Height = 25;
            dgAccounts.Size = new System.Drawing.Size(1071, 173);
            dgAccounts.TabIndex = 37;
            dgAccounts.CellFormatting += dgAccounts_CellFormatting;
            // 
            // FPPId
            // 
            FPPId.HeaderText = "FPPId";
            FPPId.MinimumWidth = 6;
            FPPId.Name = "FPPId";
            FPPId.ReadOnly = true;
            FPPId.Visible = false;
            FPPId.Width = 125;
            // 
            // GeneralLedgerId
            // 
            GeneralLedgerId.HeaderText = "GeneralLedgerId";
            GeneralLedgerId.MinimumWidth = 6;
            GeneralLedgerId.Name = "GeneralLedgerId";
            GeneralLedgerId.ReadOnly = true;
            GeneralLedgerId.Visible = false;
            GeneralLedgerId.Width = 125;
            // 
            // SubsidiaryLedgerId
            // 
            SubsidiaryLedgerId.HeaderText = "SubsidiaryLedgerId";
            SubsidiaryLedgerId.MinimumWidth = 6;
            SubsidiaryLedgerId.Name = "SubsidiaryLedgerId";
            SubsidiaryLedgerId.ReadOnly = true;
            SubsidiaryLedgerId.Visible = false;
            SubsidiaryLedgerId.Width = 125;
            // 
            // IsDebit
            // 
            IsDebit.HeaderText = "IsDebit";
            IsDebit.MinimumWidth = 6;
            IsDebit.Name = "IsDebit";
            IsDebit.ReadOnly = true;
            IsDebit.Visible = false;
            IsDebit.Width = 125;
            // 
            // FPP
            // 
            FPP.HeaderText = "FPP";
            FPP.MinimumWidth = 6;
            FPP.Name = "FPP";
            FPP.ReadOnly = true;
            FPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            FPP.Width = 125;
            // 
            // AccountName
            // 
            AccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            AccountName.HeaderText = "AccountName";
            AccountName.MinimumWidth = 238;
            AccountName.Name = "AccountName";
            AccountName.ReadOnly = true;
            AccountName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AccountCode
            // 
            AccountCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            AccountCode.HeaderText = "Account Code";
            AccountCode.MinimumWidth = 6;
            AccountCode.Name = "AccountCode";
            AccountCode.ReadOnly = true;
            AccountCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            AccountCode.Width = 89;
            // 
            // Subsidiary
            // 
            Subsidiary.HeaderText = "Subsidiary";
            Subsidiary.MinimumWidth = 6;
            Subsidiary.Name = "Subsidiary";
            Subsidiary.ReadOnly = true;
            Subsidiary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Subsidiary.Width = 200;
            // 
            // obligationNo
            // 
            obligationNo.HeaderText = "Obligation No.";
            obligationNo.MinimumWidth = 6;
            obligationNo.Name = "obligationNo";
            obligationNo.ReadOnly = true;
            obligationNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            obligationNo.Width = 125;
            // 
            // Debit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Debit.DefaultCellStyle = dataGridViewCellStyle1;
            Debit.HeaderText = "Debit";
            Debit.MinimumWidth = 6;
            Debit.Name = "Debit";
            Debit.ReadOnly = true;
            Debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Debit.Width = 125;
            // 
            // Credit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Credit.DefaultCellStyle = dataGridViewCellStyle2;
            Credit.HeaderText = "Credit";
            Credit.MinimumWidth = 6;
            Credit.Name = "Credit";
            Credit.ReadOnly = true;
            Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            Credit.Width = 125;
            // 
            // IsDeposit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            IsDeposit.DefaultCellStyle = dataGridViewCellStyle3;
            IsDeposit.HeaderText = "Type of Transaction";
            IsDeposit.MinimumWidth = 6;
            IsDeposit.Name = "IsDeposit";
            IsDeposit.ReadOnly = true;
            IsDeposit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            IsDeposit.Visible = false;
            IsDeposit.Width = 125;
            // 
            // txtExplanation
            // 
            epExplanation.SetIconAlignment(txtExplanation, System.Windows.Forms.ErrorIconAlignment.TopRight);
            txtExplanation.Location = new System.Drawing.Point(81, 255);
            txtExplanation.MaxLength = 250;
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.Size = new System.Drawing.Size(378, 81);
            txtExplanation.TabIndex = 3;
            txtExplanation.Validating += txtExplanation_Validating;
            txtExplanation.Validated += txtExplanation_Validated;
            // 
            // lblExplanation
            // 
            lblExplanation.AutoSize = true;
            lblExplanation.Location = new System.Drawing.Point(0, 258);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new System.Drawing.Size(69, 15);
            lblExplanation.TabIndex = 35;
            lblExplanation.Text = "Explanation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(548, 174);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 15);
            label2.TabIndex = 34;
            label2.Text = "Date of Entry";
            // 
            // dtpDateEntry
            // 
            dtpDateEntry.Location = new System.Drawing.Point(696, 168);
            dtpDateEntry.Name = "dtpDateEntry";
            dtpDateEntry.Size = new System.Drawing.Size(378, 23);
            dtpDateEntry.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 174);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 32;
            label1.Text = "JEV No.";
            // 
            // txtJEVNo
            // 
            txtJEVNo.Location = new System.Drawing.Point(164, 168);
            txtJEVNo.Mask = "0000";
            txtJEVNo.Name = "txtJEVNo";
            txtJEVNo.ReadOnly = true;
            txtJEVNo.Size = new System.Drawing.Size(39, 23);
            txtJEVNo.TabIndex = 0;
            txtJEVNo.Validating += txtJEVNo_Validating;
            txtJEVNo.Validated += txtJEVNo_Validated;
            // 
            // txtFundsJevNo
            // 
            txtFundsJevNo.Location = new System.Drawing.Point(81, 168);
            txtFundsJevNo.Name = "txtFundsJevNo";
            txtFundsJevNo.ReadOnly = true;
            txtFundsJevNo.Size = new System.Drawing.Size(79, 23);
            txtFundsJevNo.TabIndex = 45;
            // 
            // epJEV
            // 
            epJEV.ContainerControl = this;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 525);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 15);
            label5.TabIndex = 46;
            label5.Text = "Debit";
            // 
            // txtDebitTotal
            // 
            txtDebitTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDebitTotal.Location = new System.Drawing.Point(44, 521);
            txtDebitTotal.Name = "txtDebitTotal";
            txtDebitTotal.ReadOnly = true;
            txtDebitTotal.Size = new System.Drawing.Size(100, 23);
            txtDebitTotal.TabIndex = 47;
            txtDebitTotal.TabStop = false;
            txtDebitTotal.Text = "0.00";
            txtDebitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditTotal
            // 
            txtCreditTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCreditTotal.Location = new System.Drawing.Point(197, 520);
            txtCreditTotal.Name = "txtCreditTotal";
            txtCreditTotal.ReadOnly = true;
            txtCreditTotal.Size = new System.Drawing.Size(100, 23);
            txtCreditTotal.TabIndex = 49;
            txtCreditTotal.TabStop = false;
            txtCreditTotal.Text = "0.00";
            txtCreditTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(156, 524);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(39, 15);
            label6.TabIndex = 48;
            label6.Text = "Credit";
            // 
            // epPayee
            // 
            epPayee.ContainerControl = this;
            // 
            // cmbCollectingDisbursingOfficer
            // 
            cmbCollectingDisbursingOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCollectingDisbursingOfficer.FormattingEnabled = true;
            cmbCollectingDisbursingOfficer.Location = new System.Drawing.Point(696, 313);
            cmbCollectingDisbursingOfficer.Name = "cmbCollectingDisbursingOfficer";
            cmbCollectingDisbursingOfficer.Size = new System.Drawing.Size(378, 23);
            cmbCollectingDisbursingOfficer.TabIndex = 9;
            cmbCollectingDisbursingOfficer.Validating += cmbCollectingDisbursingOfficer_Validating;
            cmbCollectingDisbursingOfficer.Validated += cmbCollectingDisbursingOfficer_Validated;
            // 
            // lblPayee
            // 
            lblPayee.AutoSize = true;
            lblPayee.Location = new System.Drawing.Point(0, 229);
            lblPayee.Name = "lblPayee";
            lblPayee.Size = new System.Drawing.Size(38, 15);
            lblPayee.TabIndex = 51;
            lblPayee.Text = "Payee";
            // 
            // txtRefNo
            // 
            txtRefNo.Location = new System.Drawing.Point(81, 197);
            txtRefNo.Name = "txtRefNo";
            txtRefNo.Size = new System.Drawing.Size(378, 23);
            txtRefNo.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(0, 200);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(46, 15);
            label7.TabIndex = 53;
            label7.Text = "Ref No.";
            // 
            // lblCheckORPaidDate
            // 
            lblCheckORPaidDate.AutoSize = true;
            lblCheckORPaidDate.Location = new System.Drawing.Point(548, 203);
            lblCheckORPaidDate.Name = "lblCheckORPaidDate";
            lblCheckORPaidDate.Size = new System.Drawing.Size(116, 15);
            lblCheckORPaidDate.TabIndex = 55;
            lblCheckORPaidDate.Text = "Check/OR/Paid Date";
            // 
            // dtpCheckORPaid
            // 
            dtpCheckORPaid.Location = new System.Drawing.Point(696, 197);
            dtpCheckORPaid.Name = "dtpCheckORPaid";
            dtpCheckORPaid.Size = new System.Drawing.Size(378, 23);
            dtpCheckORPaid.TabIndex = 5;
            // 
            // txtDVRCDNo
            // 
            txtDVRCDNo.Location = new System.Drawing.Point(696, 284);
            txtDVRCDNo.MaxLength = 30;
            txtDVRCDNo.Name = "txtDVRCDNo";
            txtDVRCDNo.Size = new System.Drawing.Size(378, 23);
            txtDVRCDNo.TabIndex = 8;
            // 
            // lblDVRCDNo
            // 
            lblDVRCDNo.AutoSize = true;
            lblDVRCDNo.Location = new System.Drawing.Point(548, 287);
            lblDVRCDNo.Name = "lblDVRCDNo";
            lblDVRCDNo.Size = new System.Drawing.Size(72, 15);
            lblDVRCDNo.TabIndex = 57;
            lblDVRCDNo.Text = "DV/RCD No.";
            // 
            // lblCheckNo
            // 
            lblCheckNo.AutoSize = true;
            lblCheckNo.Location = new System.Drawing.Point(548, 229);
            lblCheckNo.Name = "lblCheckNo";
            lblCheckNo.Size = new System.Drawing.Size(62, 15);
            lblCheckNo.TabIndex = 61;
            lblCheckNo.Text = "Check No.";
            // 
            // epExplanation
            // 
            epExplanation.ContainerControl = this;
            // 
            // txtCheckNo
            // 
            txtCheckNo.Location = new System.Drawing.Point(696, 226);
            txtCheckNo.Name = "txtCheckNo";
            txtCheckNo.Size = new System.Drawing.Size(378, 23);
            txtCheckNo.TabIndex = 62;
            // 
            // epCollectingDisbursing
            // 
            epCollectingDisbursing.ContainerControl = this;
            // 
            // ucJEV
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(txtCheckNo);
            Controls.Add(lblCheckNo);
            Controls.Add(txtDVRCDNo);
            Controls.Add(lblDVRCDNo);
            Controls.Add(lblCheckORPaidDate);
            Controls.Add(dtpCheckORPaid);
            Controls.Add(label7);
            Controls.Add(txtRefNo);
            Controls.Add(lblPayee);
            Controls.Add(cmbCollectingDisbursingOfficer);
            Controls.Add(txtCreditTotal);
            Controls.Add(label6);
            Controls.Add(txtDebitTotal);
            Controls.Add(label5);
            Controls.Add(txtFundsJevNo);
            Controls.Add(btnRemoveAccount);
            Controls.Add(btnEditAccount);
            Controls.Add(btnAddAccount);
            Controls.Add(lblCollectingDisbursingOfficer);
            Controls.Add(txtRCIORADA);
            Controls.Add(lblRciOrADANo);
            Controls.Add(txtPayee);
            Controls.Add(dgAccounts);
            Controls.Add(txtExplanation);
            Controls.Add(lblExplanation);
            Controls.Add(label2);
            Controls.Add(dtpDateEntry);
            Controls.Add(label1);
            Controls.Add(txtJEVNo);
            Controls.Add(groupJournals);
            Controls.Add(groupFunds);
            Name = "ucJEV";
            Size = new System.Drawing.Size(1091, 551);
            Load += ucJEV_Load;
            groupFunds.ResumeLayout(false);
            groupFunds.PerformLayout();
            groupJournals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)epJEV).EndInit();
            ((System.ComponentModel.ISupportInitialize)epPayee).EndInit();
            ((System.ComponentModel.ISupportInitialize)epExplanation).EndInit();
            ((System.ComponentModel.ISupportInitialize)epCollectingDisbursing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblCollectingDisbursingOfficer;
        private System.Windows.Forms.Label lblRciOrADANo;
        private System.Windows.Forms.Label lblExplanation;
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
        private System.Windows.Forms.ErrorProvider epPayee;
        internal System.Windows.Forms.TextBox txtCreditTotal;
        internal System.Windows.Forms.TextBox txtDebitTotal;
        internal System.Windows.Forms.GroupBox groupJournals;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelJournals;
        private System.Windows.Forms.GroupBox groupFunds;
        internal System.Windows.Forms.ComboBox cmbCollectingDisbursingOfficer;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCheckORPaidDate;
        internal System.Windows.Forms.DateTimePicker dtpCheckORPaid;
        internal System.Windows.Forms.TextBox txtDVRCDNo;
        private System.Windows.Forms.Label lblDVRCDNo;
        private System.Windows.Forms.Label lblCheckNo;
        internal System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.ErrorProvider epExplanation;
        internal System.Windows.Forms.TextBox txtCheckNo;
        internal System.Windows.Forms.ErrorProvider epCollectingDisbursing;
        internal System.Windows.Forms.Button btnRemoveAccount;
        internal System.Windows.Forms.Button btnEditAccount;
        internal System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPPId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeneralLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubsidiaryLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subsidiary;
        private System.Windows.Forms.DataGridViewTextBoxColumn obligationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeposit;
    }
}
