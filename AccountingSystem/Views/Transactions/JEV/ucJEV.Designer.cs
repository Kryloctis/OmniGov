
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelJournals = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayeeCollectingOfficer = new System.Windows.Forms.TextBox();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJEVNo = new System.Windows.Forms.MaskedTextBox();
            this.FPPId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GeneralLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubsidiaryLedgerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 61);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funds";
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
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.flowLayoutPanelJournals);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 94);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Journals";
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
            this.btnRemoveAccount.Location = new System.Drawing.Point(782, 461);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAccount.TabIndex = 44;
            this.btnRemoveAccount.Text = "Remove";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(701, 461);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 23);
            this.btnEditAccount.TabIndex = 43;
            this.btnEditAccount.Text = "Edit...";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(620, 461);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 42;
            this.btnAddAccount.Text = "Add...";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.TabIndex = 41;
            this.label8.Text = "Collecting Officer";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(106, 197);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(315, 23);
            this.txtRefNo.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Check No.";
            // 
            // txtPayeeCollectingOfficer
            // 
            this.txtPayeeCollectingOfficer.Location = new System.Drawing.Point(106, 226);
            this.txtPayeeCollectingOfficer.Name = "txtPayeeCollectingOfficer";
            this.txtPayeeCollectingOfficer.Size = new System.Drawing.Size(315, 23);
            this.txtPayeeCollectingOfficer.TabIndex = 38;
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
            this.Debit,
            this.Credit});
            this.dgAccounts.Location = new System.Drawing.Point(3, 264);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowTemplate.Height = 25;
            this.dgAccounts.Size = new System.Drawing.Size(854, 191);
            this.dgAccounts.TabIndex = 37;
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(542, 197);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(315, 52);
            this.txtExplanation.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Explanation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date of Entry";
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEntry.Location = new System.Drawing.Point(542, 168);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(315, 23);
            this.dtpDateEntry.TabIndex = 33;
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
            this.txtJEVNo.Location = new System.Drawing.Point(106, 168);
            this.txtJEVNo.Mask = "00-0000-00-0000";
            this.txtJEVNo.Name = "txtJEVNo";
            this.txtJEVNo.Size = new System.Drawing.Size(315, 23);
            this.txtJEVNo.TabIndex = 31;
            // 
            // FPPId
            // 
            this.FPPId.HeaderText = "FPPId";
            this.FPPId.Name = "FPPId";
            this.FPPId.ReadOnly = true;
            // 
            // GeneralLedgerId
            // 
            this.GeneralLedgerId.HeaderText = "GeneralLedgerId";
            this.GeneralLedgerId.Name = "GeneralLedgerId";
            this.GeneralLedgerId.ReadOnly = true;
            // 
            // SubsidiaryLedgerId
            // 
            this.SubsidiaryLedgerId.HeaderText = "SubsidiaryLedgerId";
            this.SubsidiaryLedgerId.Name = "SubsidiaryLedgerId";
            this.SubsidiaryLedgerId.ReadOnly = true;
            // 
            // IsDebit
            // 
            this.IsDebit.HeaderText = "IsDebit";
            this.IsDebit.Name = "IsDebit";
            this.IsDebit.ReadOnly = true;
            // 
            // IsDeposit
            // 
            this.IsDeposit.HeaderText = "IsDeposit";
            this.IsDeposit.Name = "IsDeposit";
            this.IsDeposit.ReadOnly = true;
            // 
            // FPP
            // 
            this.FPP.HeaderText = "FPP";
            this.FPP.Name = "FPP";
            this.FPP.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            this.AccountName.Width = 403;
            // 
            // AccountCode
            // 
            this.AccountCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AccountCode.HeaderText = "Account Code";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.ReadOnly = true;
            this.AccountCode.Width = 108;
            // 
            // Debit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            // 
            // Credit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            // 
            // ucJEV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveAccount);
            this.Controls.Add(this.btnEditAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPayeeCollectingOfficer);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateEntry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJEVNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucJEV";
            this.Size = new System.Drawing.Size(886, 497);
            this.Load += new System.EventHandler(this.ucJEV_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelJournals;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtRefNo;
        internal System.Windows.Forms.TextBox txtPayeeCollectingOfficer;
        internal System.Windows.Forms.DataGridView dgAccounts;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.DateTimePicker dtpDateEntry;
        internal System.Windows.Forms.MaskedTextBox txtJEVNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPPId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GeneralLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubsidiaryLedgerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
    }
}
