
namespace AccountingSystem.Views.Transactions.BankDeposits
{
    partial class ucBankDeposits
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtReferenceNumber = new System.Windows.Forms.TextBox();
            dtDate = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            cmbBank = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            cmbFund = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            cmbBankAccounts = new System.Windows.Forms.ComboBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Bank";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(59, 15);
            label2.TabIndex = 20;
            label2.Text = "Reference";
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtReferenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtReferenceNumber.Location = new System.Drawing.Point(95, 83);
            txtReferenceNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReferenceNumber.MaxLength = 99;
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.Size = new System.Drawing.Size(250, 23);
            txtReferenceNumber.TabIndex = 2;
            txtReferenceNumber.Validating += txtreference_Validating;
            txtReferenceNumber.Validated += txtreference_Validated;
            // 
            // dtDate
            // 
            dtDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDate.Location = new System.Drawing.Point(95, 110);
            dtDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtDate.Name = "dtDate";
            dtDate.Size = new System.Drawing.Size(250, 23);
            dtDate.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 116);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 23;
            label3.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 139);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 15);
            label4.TabIndex = 24;
            label4.Text = "Amount";
            // 
            // nudAmount
            // 
            nudAmount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new System.Drawing.Point(95, 137);
            nudAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nudAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(250, 23);
            nudAmount.TabIndex = 4;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // cmbBank
            // 
            cmbBank.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new System.Drawing.Point(95, 2);
            cmbBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new System.Drawing.Size(250, 23);
            cmbBank.TabIndex = 1;
            cmbBank.SelectionChangeCommitted += cmbBank_SelectionChangeCommitted;
            cmbBank.Validating += cmbbanks_Validating;
            cmbBank.Validated += cmbbanks_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 59);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(34, 15);
            label5.TabIndex = 25;
            label5.Text = "Fund";
            // 
            // cmbFund
            // 
            cmbFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFund.FormattingEnabled = true;
            cmbFund.Location = new System.Drawing.Point(95, 56);
            cmbFund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbFund.Name = "cmbFund";
            cmbFund.Size = new System.Drawing.Size(250, 23);
            cmbFund.TabIndex = 26;
            cmbFund.Validating += cmbfunds_Validating;
            cmbFund.Validated += cmbfunds_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 32);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 15);
            label6.TabIndex = 0;
            label6.Text = "Bank Accounts";
            // 
            // cmbBankAccounts
            // 
            cmbBankAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBankAccounts.FormattingEnabled = true;
            cmbBankAccounts.Location = new System.Drawing.Point(95, 29);
            cmbBankAccounts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbBankAccounts.Name = "cmbBankAccounts";
            cmbBankAccounts.Size = new System.Drawing.Size(250, 23);
            cmbBankAccounts.TabIndex = 1;
            cmbBankAccounts.Validating += cmbbanks_Validating;
            cmbBankAccounts.Validated += cmbbanks_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucBankDeposits
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbFund);
            Controls.Add(label5);
            Controls.Add(cmbBankAccounts);
            Controls.Add(cmbBank);
            Controls.Add(nudAmount);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtDate);
            Controls.Add(txtReferenceNumber);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucBankDeposits";
            Size = new System.Drawing.Size(366, 165);
            Load += ucBankDeposit_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtDate;
        internal System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbBank;
        internal System.Windows.Forms.ComboBox cmbFund;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbBankAccounts;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
