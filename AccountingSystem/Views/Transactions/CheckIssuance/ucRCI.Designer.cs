
namespace AccountingSystem.Views.Transactions.RCI
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
            this.components = new System.ComponentModel.Container();
            this.epObligations = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddDeductions = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFPP = new System.Windows.Forms.ComboBox();
            this.txtDVNo = new System.Windows.Forms.TextBox();
            this.nudNetAmount = new System.Windows.Forms.NumericUpDown();
            this.txtNature = new System.Windows.Forms.TextBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtCheckDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbfund = new System.Windows.Forms.ComboBox();
            this.btnAddObligation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.epDVNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epBank = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCheckNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFpp = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCheckDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNatureOfPayment = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTotalDeductions = new System.Windows.Forms.ErrorProvider(this.components);
            this.epNetAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbBankAccounts = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epObligations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDVNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFpp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNatureOfPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTotalDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNetAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // epObligations
            // 
            this.epObligations.ContainerControl = this;
            // 
            // btnAddDeductions
            // 
            this.btnAddDeductions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDeductions.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnAddDeductions.Image = global::AccountingSystem.Properties.Resources.others;
            this.btnAddDeductions.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAddDeductions.Location = new System.Drawing.Point(133, 288);
            this.btnAddDeductions.Name = "btnAddDeductions";
            this.btnAddDeductions.Size = new System.Drawing.Size(302, 23);
            this.btnAddDeductions.TabIndex = 9;
            this.btnAddDeductions.Text = "Click to add deductions.";
            this.btnAddDeductions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDeductions.UseVisualStyleBackColor = true;
            this.btnAddDeductions.Click += new System.EventHandler(this.btnAddDeductions_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 54;
            this.label10.Text = "Total Deductions";
            // 
            // cmbFPP
            // 
            this.cmbFPP.FormattingEnabled = true;
            this.cmbFPP.Location = new System.Drawing.Point(133, 205);
            this.cmbFPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFPP.Name = "cmbFPP";
            this.cmbFPP.Size = new System.Drawing.Size(302, 23);
            this.cmbFPP.TabIndex = 6;
            // 
            // txtDVNo
            // 
            this.txtDVNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDVNo.Location = new System.Drawing.Point(133, 40);
            this.txtDVNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDVNo.MaxLength = 20;
            this.txtDVNo.Name = "txtDVNo";
            this.txtDVNo.Size = new System.Drawing.Size(302, 23);
            this.txtDVNo.TabIndex = 1;
            this.txtDVNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtdvno_Validating);
            this.txtDVNo.Validated += new System.EventHandler(this.txtdvno_Validated);
            // 
            // nudNetAmount
            // 
            this.nudNetAmount.DecimalPlaces = 2;
            this.nudNetAmount.Location = new System.Drawing.Point(133, 316);
            this.nudNetAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudNetAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudNetAmount.Name = "nudNetAmount";
            this.nudNetAmount.Size = new System.Drawing.Size(302, 23);
            this.nudNetAmount.TabIndex = 10;
            this.nudNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNetAmount.ThousandsSeparator = true;
            this.nudNetAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtamount_Validating);
            this.nudNetAmount.Validated += new System.EventHandler(this.txtamount_Validated);
            // 
            // txtNature
            // 
            this.txtNature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNature.Location = new System.Drawing.Point(133, 260);
            this.txtNature.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNature.MaxLength = 150;
            this.txtNature.Name = "txtNature";
            this.txtNature.Size = new System.Drawing.Size(302, 23);
            this.txtNature.TabIndex = 8;
            this.txtNature.Validating += new System.ComponentModel.CancelEventHandler(this.txtnature_Validating);
            this.txtNature.Validated += new System.EventHandler(this.txtnature_Validated);
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(133, 96);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(302, 23);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.SelectionChangeCommitted += new System.EventHandler(this.cmbBank_SelectionChangeCommitted);
            this.cmbBank.Validating += new System.ComponentModel.CancelEventHandler(this.cmbbank_Validating);
            this.cmbBank.Validated += new System.EventHandler(this.cmbbank_Validated);
            // 
            // txtPayee
            // 
            this.txtPayee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayee.Location = new System.Drawing.Point(133, 232);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPayee.MaxLength = 150;
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(302, 23);
            this.txtPayee.TabIndex = 7;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtpayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtpayee_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Obligation No/s.";
            // 
            // dtCheckDate
            // 
            this.dtCheckDate.Location = new System.Drawing.Point(133, 150);
            this.dtCheckDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtCheckDate.Name = "dtCheckDate";
            this.dtCheckDate.Size = new System.Drawing.Size(302, 23);
            this.dtCheckDate.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 47;
            this.label7.Text = "DV No. ";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckNo.Location = new System.Drawing.Point(133, 177);
            this.txtCheckNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCheckNo.MaxLength = 15;
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(302, 23);
            this.txtCheckNo.TabIndex = 5;
            this.txtCheckNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtcheckno_Validating);
            this.txtCheckNo.Validated += new System.EventHandler(this.txtcheckno_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 50;
            this.label12.Text = "Amount";
            // 
            // cmbfund
            // 
            this.cmbfund.FormattingEnabled = true;
            this.cmbfund.Location = new System.Drawing.Point(133, 68);
            this.cmbfund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfund.Name = "cmbfund";
            this.cmbfund.Size = new System.Drawing.Size(302, 23);
            this.cmbfund.TabIndex = 2;
            this.cmbfund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfund_Validating);
            this.cmbfund.Validated += new System.EventHandler(this.cmbfund_Validated);
            // 
            // btnAddObligation
            // 
            this.btnAddObligation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddObligation.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnAddObligation.Image = global::AccountingSystem.Properties.Resources.others;
            this.btnAddObligation.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAddObligation.Location = new System.Drawing.Point(133, 12);
            this.btnAddObligation.Name = "btnAddObligation";
            this.btnAddObligation.Size = new System.Drawing.Size(302, 23);
            this.btnAddObligation.TabIndex = 0;
            this.btnAddObligation.Text = "Click to add obligation no.";
            this.btnAddObligation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddObligation.UseVisualStyleBackColor = true;
            this.btnAddObligation.Click += new System.EventHandler(this.btnAddObligation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Fund";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 49;
            this.label9.Text = "Nature of Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Bank";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 15);
            this.label8.TabIndex = 48;
            this.label8.Text = "Payee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "FPP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Check No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 45;
            this.label5.Text = "Check Date";
            // 
            // epDVNo
            // 
            this.epDVNo.ContainerControl = this;
            // 
            // epFund
            // 
            this.epFund.ContainerControl = this;
            // 
            // epBank
            // 
            this.epBank.ContainerControl = this;
            // 
            // epCheckNo
            // 
            this.epCheckNo.ContainerControl = this;
            // 
            // epFpp
            // 
            this.epFpp.ContainerControl = this;
            // 
            // epCheckDate
            // 
            this.epCheckDate.ContainerControl = this;
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // epNatureOfPayment
            // 
            this.epNatureOfPayment.ContainerControl = this;
            // 
            // epTotalDeductions
            // 
            this.epTotalDeductions.ContainerControl = this;
            // 
            // epNetAmount
            // 
            this.epNetAmount.ContainerControl = this;
            // 
            // cmbBankAccounts
            // 
            this.cmbBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankAccounts.FormattingEnabled = true;
            this.cmbBankAccounts.Location = new System.Drawing.Point(133, 123);
            this.cmbBankAccounts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBankAccounts.Name = "cmbBankAccounts";
            this.cmbBankAccounts.Size = new System.Drawing.Size(302, 23);
            this.cmbBankAccounts.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 15);
            this.label11.TabIndex = 55;
            this.label11.Text = "Bank Accounts";
            // 
            // ucRCI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbBankAccounts);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddDeductions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbFPP);
            this.Controls.Add(this.txtDVNo);
            this.Controls.Add(this.nudNetAmount);
            this.Controls.Add(this.txtNature);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtCheckDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbfund);
            this.Controls.Add(this.btnAddObligation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucRCI";
            this.Size = new System.Drawing.Size(457, 347);
            this.Load += new System.EventHandler(this.ucRCI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epObligations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDVNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFpp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCheckDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNatureOfPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTotalDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epNetAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epObligations;
        private System.Windows.Forms.Button btnAddDeductions;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ComboBox cmbFPP;
        internal System.Windows.Forms.TextBox txtDVNo;
        internal System.Windows.Forms.NumericUpDown nudNetAmount;
        internal System.Windows.Forms.TextBox txtNature;
        internal System.Windows.Forms.ComboBox cmbBank;
        internal System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtCheckDate;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbfund;
        private System.Windows.Forms.Button btnAddObligation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epDVNo;
        private System.Windows.Forms.ErrorProvider epFund;
        private System.Windows.Forms.ErrorProvider epBank;
        private System.Windows.Forms.ErrorProvider epCheckNo;
        private System.Windows.Forms.ErrorProvider epFpp;
        private System.Windows.Forms.ErrorProvider epCheckDate;
        private System.Windows.Forms.ErrorProvider epPayee;
        private System.Windows.Forms.ErrorProvider epNatureOfPayment;
        private System.Windows.Forms.ErrorProvider epTotalDeductions;
        private System.Windows.Forms.ErrorProvider epNetAmount;
        internal System.Windows.Forms.ComboBox cmbBankAccounts;
        private System.Windows.Forms.Label label11;
    }
}
