
namespace AccountingSystem.Views.Manage.Realignment
{
    partial class ucRealignment
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
            this.dgBudgetRealignment = new System.Windows.Forms.DataGridView();
            this.budgetAppropriationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupboxRealignToDetails = new System.Windows.Forms.GroupBox();
            this.txtAppropriationBalance = new System.Windows.Forms.TextBox();
            this.cmbAllotmentClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.cmbFunds = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbOthersFPP = new System.Windows.Forms.ComboBox();
            this.groupboxRealignToAccounts = new System.Windows.Forms.GroupBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAmountRealigned = new System.Windows.Forms.TextBox();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAllotmentClass = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTypeOfFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRemarks = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtBudgetId = new System.Windows.Forms.Label();
            this.epDgAccount = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).BeginInit();
            this.groupboxRealignToDetails.SuspendLayout();
            this.groupboxRealignToAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDgAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBudgetRealignment
            // 
            this.dgBudgetRealignment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetRealignment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.budgetAppropriationId,
            this.accountId,
            this.account,
            this.amount});
            this.dgBudgetRealignment.Location = new System.Drawing.Point(10, 75);
            this.dgBudgetRealignment.MultiSelect = false;
            this.dgBudgetRealignment.Name = "dgBudgetRealignment";
            this.dgBudgetRealignment.RowTemplate.Height = 25;
            this.dgBudgetRealignment.Size = new System.Drawing.Size(505, 105);
            this.dgBudgetRealignment.TabIndex = 22;
            this.dgBudgetRealignment.Tag = "";
            this.dgBudgetRealignment.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgBudgetRealignment_CellValidating);
            this.dgBudgetRealignment.SelectionChanged += new System.EventHandler(this.dgBudgetRealignment_SelectionChanged);
            // 
            // budgetAppropriationId
            // 
            this.budgetAppropriationId.HeaderText = "BudgetId";
            this.budgetAppropriationId.Name = "budgetAppropriationId";
            this.budgetAppropriationId.Visible = false;
            // 
            // accountId
            // 
            this.accountId.HeaderText = "AccountId";
            this.accountId.Name = "accountId";
            this.accountId.Visible = false;
            // 
            // account
            // 
            this.account.HeaderText = "Account";
            this.account.Name = "account";
            this.account.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.account.Width = 350;
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(440, 46);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add Account and Amount";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(106, 172);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(409, 23);
            this.dtDateIssued.TabIndex = 35;
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(441, 186);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 40;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(106, 201);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(410, 41);
            this.txtRemarks.TabIndex = 42;
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            this.txtRemarks.Validated += new System.EventHandler(this.txtRemarks_Validated);
            // 
            // groupboxRealignToDetails
            // 
            this.groupboxRealignToDetails.Controls.Add(this.txtAppropriationBalance);
            this.groupboxRealignToDetails.Controls.Add(this.cmbAllotmentClass);
            this.groupboxRealignToDetails.Controls.Add(this.txtRemarks);
            this.groupboxRealignToDetails.Controls.Add(this.label5);
            this.groupboxRealignToDetails.Controls.Add(this.cmbFPP);
            this.groupboxRealignToDetails.Controls.Add(this.cmbFunds);
            this.groupboxRealignToDetails.Controls.Add(this.label13);
            this.groupboxRealignToDetails.Controls.Add(this.dtDateIssued);
            this.groupboxRealignToDetails.Controls.Add(this.label6);
            this.groupboxRealignToDetails.Controls.Add(this.label2);
            this.groupboxRealignToDetails.Controls.Add(this.label7);
            this.groupboxRealignToDetails.Controls.Add(this.label8);
            this.groupboxRealignToDetails.Controls.Add(this.label9);
            this.groupboxRealignToDetails.Controls.Add(this.cmbOthersFPP);
            this.groupboxRealignToDetails.Location = new System.Drawing.Point(3, 9);
            this.groupboxRealignToDetails.Name = "groupboxRealignToDetails";
            this.groupboxRealignToDetails.Size = new System.Drawing.Size(538, 248);
            this.groupboxRealignToDetails.TabIndex = 44;
            this.groupboxRealignToDetails.TabStop = false;
            this.groupboxRealignToDetails.Text = "Realign to ";
            // 
            // txtAppropriationBalance
            // 
            this.txtAppropriationBalance.Location = new System.Drawing.Point(141, 21);
            this.txtAppropriationBalance.Name = "txtAppropriationBalance";
            this.txtAppropriationBalance.ReadOnly = true;
            this.txtAppropriationBalance.Size = new System.Drawing.Size(374, 23);
            this.txtAppropriationBalance.TabIndex = 50;
            this.txtAppropriationBalance.TabStop = false;
            this.txtAppropriationBalance.Text = "0.0";
            // 
            // cmbAllotmentClass
            // 
            this.cmbAllotmentClass.FormattingEnabled = true;
            this.cmbAllotmentClass.Location = new System.Drawing.Point(105, 143);
            this.cmbAllotmentClass.Name = "cmbAllotmentClass";
            this.cmbAllotmentClass.Size = new System.Drawing.Size(410, 23);
            this.cmbAllotmentClass.TabIndex = 48;
            this.cmbAllotmentClass.DropDownClosed += new System.EventHandler(this.cmbAllotmentClass_DropDownClosed);
            this.cmbAllotmentClass.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAllotmentClass_Validating);
            this.cmbAllotmentClass.Validated += new System.EventHandler(this.cmbAllotmentClass_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Remarks ";
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(105, 85);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(410, 23);
            this.cmbFPP.TabIndex = 47;
            this.cmbFPP.DropDownClosed += new System.EventHandler(this.cmbFPP_DropDownClosed);
            this.cmbFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFPP_Validating);
            this.cmbFPP.Validated += new System.EventHandler(this.cmbFPP_Validated);
            // 
            // cmbFunds
            // 
            this.cmbFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbFunds.FormattingEnabled = true;
            this.cmbFunds.Location = new System.Drawing.Point(105, 56);
            this.cmbFunds.Name = "cmbFunds";
            this.cmbFunds.Size = new System.Drawing.Size(410, 23);
            this.cmbFunds.TabIndex = 46;
            this.cmbFunds.DropDownClosed += new System.EventHandler(this.cmbFunds_DropDownClosed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 15);
            this.label13.TabIndex = 44;
            this.label13.Text = "Appropriation Balance ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Date Issued";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Allotment Class";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Sub FPP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Type of Fund";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "FPP";
            // 
            // cmbOthersFPP
            // 
            this.cmbOthersFPP.FormattingEnabled = true;
            this.cmbOthersFPP.Location = new System.Drawing.Point(105, 114);
            this.cmbOthersFPP.Name = "cmbOthersFPP";
            this.cmbOthersFPP.Size = new System.Drawing.Size(410, 23);
            this.cmbOthersFPP.TabIndex = 16;
            this.cmbOthersFPP.DropDownClosed += new System.EventHandler(this.cmbOthersFPP_DropDownClosed);
            // 
            // groupboxRealignToAccounts
            // 
            this.groupboxRealignToAccounts.Controls.Add(this.nudAmount);
            this.groupboxRealignToAccounts.Controls.Add(this.label11);
            this.groupboxRealignToAccounts.Controls.Add(this.label12);
            this.groupboxRealignToAccounts.Controls.Add(this.cmbAccount);
            this.groupboxRealignToAccounts.Controls.Add(this.label1);
            this.groupboxRealignToAccounts.Controls.Add(this.txtTotalAmountRealigned);
            this.groupboxRealignToAccounts.Controls.Add(this.btnAdd);
            this.groupboxRealignToAccounts.Controls.Add(this.dgBudgetRealignment);
            this.groupboxRealignToAccounts.Controls.Add(this.btnRemove);
            this.groupboxRealignToAccounts.Location = new System.Drawing.Point(3, 271);
            this.groupboxRealignToAccounts.Name = "groupboxRealignToAccounts";
            this.groupboxRealignToAccounts.Size = new System.Drawing.Size(537, 219);
            this.groupboxRealignToAccounts.TabIndex = 45;
            this.groupboxRealignToAccounts.TabStop = false;
            this.groupboxRealignToAccounts.Text = "Accounts";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(331, 46);
            this.nudAmount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(92, 23);
            this.nudAmount.TabIndex = 54;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(331, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 15);
            this.label11.TabIndex = 53;
            this.label11.Text = "Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 51;
            this.label12.Text = "Account";
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.IntegralHeight = false;
            this.cmbAccount.Location = new System.Drawing.Point(10, 46);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(303, 23);
            this.cmbAccount.TabIndex = 52;
            this.cmbAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAccount_Validating);
            this.cmbAccount.Validated += new System.EventHandler(this.cmbAccount_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "Total ";
            // 
            // txtTotalAmountRealigned
            // 
            this.txtTotalAmountRealigned.Location = new System.Drawing.Point(50, 187);
            this.txtTotalAmountRealigned.Name = "txtTotalAmountRealigned";
            this.txtTotalAmountRealigned.ReadOnly = true;
            this.txtTotalAmountRealigned.Size = new System.Drawing.Size(208, 23);
            this.txtTotalAmountRealigned.TabIndex = 49;
            this.txtTotalAmountRealigned.TabStop = false;
            this.txtTotalAmountRealigned.Text = "0.0";
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epAllotmentClass
            // 
            this.epAllotmentClass.ContainerControl = this;
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // epTypeOfFund
            // 
            this.epTypeOfFund.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // epRemarks
            // 
            this.epRemarks.ContainerControl = this;
            // 
            // txtBudgetId
            // 
            this.txtBudgetId.AutoSize = true;
            this.txtBudgetId.Location = new System.Drawing.Point(9, 47);
            this.txtBudgetId.Name = "txtBudgetId";
            this.txtBudgetId.Size = new System.Drawing.Size(21, 15);
            this.txtBudgetId.TabIndex = 49;
            this.txtBudgetId.Text = "ID ";
            this.txtBudgetId.Visible = false;
            // 
            // epDgAccount
            // 
            this.epDgAccount.ContainerControl = this;
            // 
            // ucRealignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.groupboxRealignToAccounts);
            this.Controls.Add(this.groupboxRealignToDetails);
            this.Name = "ucRealignment";
            this.Size = new System.Drawing.Size(544, 494);
            this.Load += new System.EventHandler(this.ucRealignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetRealignment)).EndInit();
            this.groupboxRealignToDetails.ResumeLayout(false);
            this.groupboxRealignToDetails.PerformLayout();
            this.groupboxRealignToAccounts.ResumeLayout(false);
            this.groupboxRealignToAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDgAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.DataGridView dgBudgetRealignment;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.ComboBox cmbOthersFPP;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbFunds;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.ComboBox cmbAllotmentClass;
        private System.Windows.Forms.ErrorProvider epFPP;
        private System.Windows.Forms.ErrorProvider epAllotmentClass;
        internal System.Windows.Forms.ErrorProvider epAccount;
        internal System.Windows.Forms.ErrorProvider epTypeOfFund;
        internal System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.ErrorProvider epRemarks;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotalAmountRealigned;
        internal System.Windows.Forms.TextBox txtAppropriationBalance;
        public System.Windows.Forms.Label txtBudgetId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.GroupBox groupboxRealignToDetails;
        internal System.Windows.Forms.GroupBox groupboxRealignToAccounts;
        internal System.Windows.Forms.ErrorProvider epDgAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn budgetAppropriationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}
