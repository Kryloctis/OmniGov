
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.epBank = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFund = new System.Windows.Forms.ComboBox();
            this.epFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epReferenceNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank";
            // 
            // epBank
            // 
            this.epBank.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Reference";
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(88, 72);
            this.txtReferenceNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferenceNumber.MaxLength = 99;
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(350, 23);
            this.txtReferenceNumber.TabIndex = 2;
            this.txtReferenceNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            this.txtReferenceNumber.Validated += new System.EventHandler(this.txtreference_Validated);
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(88, 103);
            this.dtDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(350, 23);
            this.dtDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(88, 134);
            this.nudAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(350, 23);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(88, 10);
            this.cmbBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(350, 23);
            this.cmbBank.TabIndex = 1;
            this.cmbBank.Validating += new System.ComponentModel.CancelEventHandler(this.cmbbanks_Validating);
            this.cmbBank.Validated += new System.EventHandler(this.cmbbanks_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fund";
            // 
            // cmbFund
            // 
            this.cmbFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFund.FormattingEnabled = true;
            this.cmbFund.Location = new System.Drawing.Point(88, 41);
            this.cmbFund.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFund.Name = "cmbFund";
            this.cmbFund.Size = new System.Drawing.Size(350, 23);
            this.cmbFund.TabIndex = 26;
            this.cmbFund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfunds_Validating);
            this.cmbFund.Validated += new System.EventHandler(this.cmbfunds_Validated);
            // 
            // epFund
            // 
            this.epFund.ContainerControl = this;
            // 
            // epReferenceNumber
            // 
            this.epReferenceNumber.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // ucBankDeposits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.cmbFund);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.txtReferenceNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucBankDeposits";
            this.Size = new System.Drawing.Size(466, 168);
            this.Load += new System.EventHandler(this.ucBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epBank;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtDate;
        internal System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbBank;
        internal System.Windows.Forms.ComboBox cmbFund;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epFund;
        private System.Windows.Forms.ErrorProvider epReferenceNumber;
        private System.Windows.Forms.ErrorProvider epAmount;
    }
}
