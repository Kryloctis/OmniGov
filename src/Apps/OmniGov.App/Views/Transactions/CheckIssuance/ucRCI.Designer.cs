
namespace OmniGov.App.Views.Transactions.CheckIssuance
{
    partial class ucRCI
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
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            btnAddDeductions = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            cmbFPP = new System.Windows.Forms.ComboBox();
            txtDVNo = new System.Windows.Forms.TextBox();
            nudNetAmount = new System.Windows.Forms.NumericUpDown();
            txtNatureOfPayment = new System.Windows.Forms.TextBox();
            cmbBank = new System.Windows.Forms.ComboBox();
            txtPayee = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            dtCheckDate = new System.Windows.Forms.DateTimePicker();
            label7 = new System.Windows.Forms.Label();
            txtCheckNo = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            cmbFund = new System.Windows.Forms.ComboBox();
            btnAddObligation = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cmbBankAccounts = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNetAmount).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // btnAddDeductions
            // 
            btnAddDeductions.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddDeductions.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            btnAddDeductions.Image = Properties.Resources.others;
            btnAddDeductions.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnAddDeductions.Location = new System.Drawing.Point(133, 288);
            btnAddDeductions.Name = "btnAddDeductions";
            btnAddDeductions.Size = new System.Drawing.Size(302, 23);
            btnAddDeductions.TabIndex = 10;
            btnAddDeductions.Text = "Click to add deductions.";
            btnAddDeductions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddDeductions.UseVisualStyleBackColor = true;
            btnAddDeductions.Click += btnAddDeductions_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(14, 291);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(95, 15);
            label10.TabIndex = 10;
            label10.Text = "Total Deductions";
            // 
            // cmbFPP
            // 
            cmbFPP.FormattingEnabled = true;
            cmbFPP.Location = new System.Drawing.Point(133, 205);
            cmbFPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbFPP.Name = "cmbFPP";
            cmbFPP.Size = new System.Drawing.Size(302, 23);
            cmbFPP.TabIndex = 7;
            cmbFPP.Validating += cmbFPP_Validating;
            cmbFPP.Validated += cmbFPP_Validated;
            // 
            // txtDVNo
            // 
            txtDVNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDVNo.Location = new System.Drawing.Point(133, 40);
            txtDVNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtDVNo.MaxLength = 20;
            txtDVNo.Name = "txtDVNo";
            txtDVNo.Size = new System.Drawing.Size(302, 23);
            txtDVNo.TabIndex = 1;
            txtDVNo.Validating += txtdvno_Validating;
            txtDVNo.Validated += txtdvno_Validated;
            // 
            // nudNetAmount
            // 
            nudNetAmount.DecimalPlaces = 2;
            nudNetAmount.Location = new System.Drawing.Point(133, 316);
            nudNetAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nudNetAmount.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            nudNetAmount.Name = "nudNetAmount";
            nudNetAmount.Size = new System.Drawing.Size(302, 23);
            nudNetAmount.TabIndex = 11;
            nudNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudNetAmount.ThousandsSeparator = true;
            nudNetAmount.Validating += txtamount_Validating;
            nudNetAmount.Validated += txtamount_Validated;
            // 
            // txtNatureOfPayment
            // 
            txtNatureOfPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNatureOfPayment.Location = new System.Drawing.Point(133, 260);
            txtNatureOfPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtNatureOfPayment.MaxLength = 150;
            txtNatureOfPayment.Name = "txtNatureOfPayment";
            txtNatureOfPayment.Size = new System.Drawing.Size(302, 23);
            txtNatureOfPayment.TabIndex = 9;
            txtNatureOfPayment.Validating += txtnature_Validating;
            txtNatureOfPayment.Validated += txtnature_Validated;
            // 
            // cmbBank
            // 
            cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBank.FormattingEnabled = true;
            cmbBank.Location = new System.Drawing.Point(133, 96);
            cmbBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbBank.Name = "cmbBank";
            cmbBank.Size = new System.Drawing.Size(302, 23);
            cmbBank.TabIndex = 3;
            cmbBank.Validating += cmbbank_Validating;
            cmbBank.Validated += cmbbank_Validated;
            // 
            // txtPayee
            // 
            txtPayee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPayee.Location = new System.Drawing.Point(133, 232);
            txtPayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPayee.MaxLength = 150;
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(302, 23);
            txtPayee.TabIndex = 8;
            txtPayee.Validating += txtpayee_Validating;
            txtPayee.Validated += txtpayee_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(14, 14);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(95, 15);
            label6.TabIndex = 0;
            label6.Text = "Obligation No/s.";
            // 
            // dtCheckDate
            // 
            dtCheckDate.Location = new System.Drawing.Point(133, 150);
            dtCheckDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtCheckDate.Name = "dtCheckDate";
            dtCheckDate.Size = new System.Drawing.Size(302, 23);
            dtCheckDate.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(14, 43);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(47, 15);
            label7.TabIndex = 1;
            label7.Text = "DV No. ";
            // 
            // txtCheckNo
            // 
            txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCheckNo.Location = new System.Drawing.Point(133, 177);
            txtCheckNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtCheckNo.MaxLength = 15;
            txtCheckNo.Name = "txtCheckNo";
            txtCheckNo.Size = new System.Drawing.Size(302, 23);
            txtCheckNo.TabIndex = 6;
            txtCheckNo.Validating += txtcheckno_Validating;
            txtCheckNo.Validated += txtcheckno_Validated;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(14, 319);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(73, 15);
            label12.TabIndex = 11;
            label12.Text = "Net Amount";
            // 
            // cmbFund
            // 
            cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFund.FormattingEnabled = true;
            cmbFund.Location = new System.Drawing.Point(133, 68);
            cmbFund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbFund.Name = "cmbFund";
            cmbFund.Size = new System.Drawing.Size(302, 23);
            cmbFund.TabIndex = 2;
            cmbFund.Validating += cmbfund_Validating;
            cmbFund.Validated += cmbfund_Validated;
            // 
            // btnAddObligation
            // 
            btnAddObligation.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddObligation.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            btnAddObligation.Image = Properties.Resources.others;
            btnAddObligation.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnAddObligation.Location = new System.Drawing.Point(133, 12);
            btnAddObligation.Name = "btnAddObligation";
            btnAddObligation.Size = new System.Drawing.Size(302, 23);
            btnAddObligation.TabIndex = 0;
            btnAddObligation.Text = "Click to add obligation no.";
            btnAddObligation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddObligation.UseVisualStyleBackColor = true;
            btnAddObligation.Click += btnAddObligation_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 72);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 2;
            label2.Text = "Fund";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(14, 262);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(107, 15);
            label9.TabIndex = 9;
            label9.Text = "Nature of Payment";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(14, 101);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 15);
            label1.TabIndex = 3;
            label1.Text = "Bank";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(14, 234);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(38, 15);
            label8.TabIndex = 8;
            label8.Text = "Payee";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 208);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 15);
            label3.TabIndex = 7;
            label3.Text = "FPP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(14, 183);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "Check No.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(14, 156);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 15);
            label5.TabIndex = 5;
            label5.Text = "Check Date";
            // 
            // cmbBankAccounts
            // 
            cmbBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbBankAccounts.FormattingEnabled = true;
            cmbBankAccounts.Location = new System.Drawing.Point(133, 123);
            cmbBankAccounts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbBankAccounts.Name = "cmbBankAccounts";
            cmbBankAccounts.Size = new System.Drawing.Size(302, 23);
            cmbBankAccounts.TabIndex = 4;
            cmbBankAccounts.Validating += cmbBankAccounts_Validating;
            cmbBankAccounts.Validated += cmbBankAccounts_Validated;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(14, 126);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(86, 15);
            label11.TabIndex = 4;
            label11.Text = "Bank Accounts";
            // 
            // ucRCI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(cmbBankAccounts);
            Controls.Add(label11);
            Controls.Add(btnAddDeductions);
            Controls.Add(label10);
            Controls.Add(cmbFPP);
            Controls.Add(txtDVNo);
            Controls.Add(nudNetAmount);
            Controls.Add(txtNatureOfPayment);
            Controls.Add(cmbBank);
            Controls.Add(txtPayee);
            Controls.Add(label6);
            Controls.Add(dtCheckDate);
            Controls.Add(label7);
            Controls.Add(txtCheckNo);
            Controls.Add(label12);
            Controls.Add(cmbFund);
            Controls.Add(btnAddObligation);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucRCI";
            Size = new System.Drawing.Size(457, 347);
            Load += ucRCI_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNetAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAddDeductions;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.TextBox txtDVNo;
        internal System.Windows.Forms.NumericUpDown nudNetAmount;
        internal System.Windows.Forms.TextBox txtNatureOfPayment;
        internal System.Windows.Forms.ComboBox cmbBank;
        internal System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtCheckDate;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbFund;
        private System.Windows.Forms.Button btnAddObligation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbBankAccounts;
        private System.Windows.Forms.Label label11;
    }
}
