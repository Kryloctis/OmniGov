
namespace LFS.Budget.Views.Realignment
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
            components = new System.ComponentModel.Container();
            btnAdd = new System.Windows.Forms.Button();
            dtDateIssued = new System.Windows.Forms.DateTimePicker();
            btnRemove = new System.Windows.Forms.Button();
            txtRemarks = new System.Windows.Forms.TextBox();
            groupboxRealignToDetails = new System.Windows.Forms.GroupBox();
            txtAppropriationBalance = new System.Windows.Forms.TextBox();
            cmbAllotmentClass = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbFPP = new System.Windows.Forms.ComboBox();
            cmbFunds = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            cmbOthersFPP = new System.Windows.Forms.ComboBox();
            groupboxRealignToAccounts = new System.Windows.Forms.GroupBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            cmbAccount = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            txtTotalAmountRealigned = new System.Windows.Forms.TextBox();
            txtBudgetId = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupboxRealignToDetails.SuspendLayout();
            groupboxRealignToAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(440, 46);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(76, 23);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add Account and Amount";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dtDateIssued
            // 
            dtDateIssued.Location = new System.Drawing.Point(142, 172);
            dtDateIssued.Name = "dtDateIssued";
            dtDateIssued.Size = new System.Drawing.Size(373, 23);
            dtDateIssued.TabIndex = 35;
            // 
            // btnRemove
            // 
            btnRemove.Enabled = false;
            btnRemove.Location = new System.Drawing.Point(456, 217);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 23);
            btnRemove.TabIndex = 40;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new System.Drawing.Point(142, 201);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new System.Drawing.Size(374, 41);
            txtRemarks.TabIndex = 42;
            txtRemarks.Validating += txtRemarks_Validating;
            txtRemarks.Validated += txtRemarks_Validated;
            // 
            // groupboxRealignToDetails
            // 
            groupboxRealignToDetails.Controls.Add(txtAppropriationBalance);
            groupboxRealignToDetails.Controls.Add(cmbAllotmentClass);
            groupboxRealignToDetails.Controls.Add(txtRemarks);
            groupboxRealignToDetails.Controls.Add(label5);
            groupboxRealignToDetails.Controls.Add(cmbFPP);
            groupboxRealignToDetails.Controls.Add(cmbFunds);
            groupboxRealignToDetails.Controls.Add(label13);
            groupboxRealignToDetails.Controls.Add(dtDateIssued);
            groupboxRealignToDetails.Controls.Add(label6);
            groupboxRealignToDetails.Controls.Add(label2);
            groupboxRealignToDetails.Controls.Add(label7);
            groupboxRealignToDetails.Controls.Add(label8);
            groupboxRealignToDetails.Controls.Add(label9);
            groupboxRealignToDetails.Controls.Add(cmbOthersFPP);
            groupboxRealignToDetails.Location = new System.Drawing.Point(3, 9);
            groupboxRealignToDetails.Name = "groupboxRealignToDetails";
            groupboxRealignToDetails.Size = new System.Drawing.Size(535, 248);
            groupboxRealignToDetails.TabIndex = 44;
            groupboxRealignToDetails.TabStop = false;
            groupboxRealignToDetails.Text = "Realign to ";
            // 
            // txtAppropriationBalance
            // 
            txtAppropriationBalance.Location = new System.Drawing.Point(141, 21);
            txtAppropriationBalance.Name = "txtAppropriationBalance";
            txtAppropriationBalance.ReadOnly = true;
            txtAppropriationBalance.Size = new System.Drawing.Size(374, 23);
            txtAppropriationBalance.TabIndex = 50;
            txtAppropriationBalance.TabStop = false;
            txtAppropriationBalance.Text = "0.0";
            // 
            // cmbAllotmentClass
            // 
            cmbAllotmentClass.FormattingEnabled = true;
            cmbAllotmentClass.Location = new System.Drawing.Point(141, 143);
            cmbAllotmentClass.Name = "cmbAllotmentClass";
            cmbAllotmentClass.Size = new System.Drawing.Size(374, 23);
            cmbAllotmentClass.TabIndex = 48;
            cmbAllotmentClass.DropDownClosed += cmbAllotmentClass_DropDownClosed;
            cmbAllotmentClass.Validating += cmbAllotmentClass_Validating;
            cmbAllotmentClass.Validated += cmbAllotmentClass_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 201);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 15);
            label5.TabIndex = 41;
            label5.Text = "Remarks ";
            // 
            // cmbFPP
            // 
            cmbFPP.FormattingEnabled = true;
            cmbFPP.Location = new System.Drawing.Point(141, 85);
            cmbFPP.Name = "cmbFPP";
            cmbFPP.Size = new System.Drawing.Size(374, 23);
            cmbFPP.TabIndex = 47;
            cmbFPP.DropDownClosed += cmbFPP_DropDownClosed;
            cmbFPP.Validating += cmbFPP_Validating;
            cmbFPP.Validated += cmbFPP_Validated;
            // 
            // cmbFunds
            // 
            cmbFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFunds.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            cmbFunds.FormattingEnabled = true;
            cmbFunds.Location = new System.Drawing.Point(141, 56);
            cmbFunds.Name = "cmbFunds";
            cmbFunds.Size = new System.Drawing.Size(374, 23);
            cmbFunds.TabIndex = 46;
            cmbFunds.DropDownClosed += cmbFunds_DropDownClosed;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(7, 24);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(128, 15);
            label13.TabIndex = 44;
            label13.Text = "Appropriation Balance ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 172);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 15);
            label6.TabIndex = 36;
            label6.Text = "Date Issued";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 146);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(90, 15);
            label2.TabIndex = 12;
            label2.Text = "Allotment Class";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 117);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(50, 15);
            label7.TabIndex = 13;
            label7.Text = "Sub FPP";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(10, 59);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(75, 15);
            label8.TabIndex = 14;
            label8.Text = "Type of Fund";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(10, 88);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(27, 15);
            label9.TabIndex = 15;
            label9.Text = "FPP";
            // 
            // cmbOthersFPP
            // 
            cmbOthersFPP.FormattingEnabled = true;
            cmbOthersFPP.Location = new System.Drawing.Point(141, 114);
            cmbOthersFPP.Name = "cmbOthersFPP";
            cmbOthersFPP.Size = new System.Drawing.Size(374, 23);
            cmbOthersFPP.TabIndex = 16;
            cmbOthersFPP.DropDownClosed += cmbOthersFPP_DropDownClosed;
            cmbOthersFPP.TextChanged += cmbOthersFPP_TextChanged;
            // 
            // groupboxRealignToAccounts
            // 
            groupboxRealignToAccounts.Controls.Add(dataGridView1);
            groupboxRealignToAccounts.Controls.Add(nudAmount);
            groupboxRealignToAccounts.Controls.Add(label11);
            groupboxRealignToAccounts.Controls.Add(label12);
            groupboxRealignToAccounts.Controls.Add(cmbAccount);
            groupboxRealignToAccounts.Controls.Add(label1);
            groupboxRealignToAccounts.Controls.Add(txtTotalAmountRealigned);
            groupboxRealignToAccounts.Controls.Add(btnAdd);
            groupboxRealignToAccounts.Controls.Add(btnRemove);
            groupboxRealignToAccounts.Location = new System.Drawing.Point(554, 9);
            groupboxRealignToAccounts.Name = "groupboxRealignToAccounts";
            groupboxRealignToAccounts.Size = new System.Drawing.Size(537, 248);
            groupboxRealignToAccounts.TabIndex = 45;
            groupboxRealignToAccounts.TabStop = false;
            groupboxRealignToAccounts.Text = "Accounts";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(10, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(521, 121);
            dataGridView1.TabIndex = 55;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new System.Drawing.Point(331, 46);
            nudAmount.Maximum = new decimal(new int[] { -1530494976, 232830, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(92, 23);
            nudAmount.TabIndex = 54;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(331, 28);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(51, 15);
            label11.TabIndex = 53;
            label11.Text = "Amount";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(10, 28);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(52, 15);
            label12.TabIndex = 51;
            label12.Text = "Account";
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.IntegralHeight = false;
            cmbAccount.Location = new System.Drawing.Point(10, 46);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new System.Drawing.Size(303, 23);
            cmbAccount.TabIndex = 52;
            cmbAccount.Validating += cmbAccount_Validating;
            cmbAccount.Validated += cmbAccount_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 221);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 50;
            label1.Text = "Total ";
            // 
            // txtTotalAmountRealigned
            // 
            txtTotalAmountRealigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalAmountRealigned.Location = new System.Drawing.Point(50, 219);
            txtTotalAmountRealigned.Name = "txtTotalAmountRealigned";
            txtTotalAmountRealigned.ReadOnly = true;
            txtTotalAmountRealigned.Size = new System.Drawing.Size(208, 23);
            txtTotalAmountRealigned.TabIndex = 49;
            txtTotalAmountRealigned.TabStop = false;
            txtTotalAmountRealigned.Text = "0.0";
            // 
            // txtBudgetId
            // 
            txtBudgetId.AutoSize = true;
            txtBudgetId.Location = new System.Drawing.Point(9, 47);
            txtBudgetId.Name = "txtBudgetId";
            txtBudgetId.Size = new System.Drawing.Size(21, 15);
            txtBudgetId.TabIndex = 49;
            txtBudgetId.Text = "ID ";
            txtBudgetId.Visible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucRealignment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(groupboxRealignToAccounts);
            Controls.Add(groupboxRealignToDetails);
            Name = "ucRealignment";
            Size = new System.Drawing.Size(1120, 262);
            Load += ucRealignment_Load;
            groupboxRealignToDetails.ResumeLayout(false);
            groupboxRealignToDetails.PerformLayout();
            groupboxRealignToAccounts.ResumeLayout(false);
            groupboxRealignToAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.TextBox txtRemarks;
        internal System.Windows.Forms.ComboBox cmbOthersFPP;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ComboBox cmbFunds;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.ComboBox cmbAllotmentClass;
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
