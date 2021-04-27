
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class ucObligationRequestOld
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
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.mskTxtTemplateNo = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.epObligationNum = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.dtPickerDateIssued = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbxAllotmentClasses = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOthersFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFunds = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAllotmentClass = new System.Windows.Forms.ErrorProvider(this.components);
            this.mskObligationSeriesNo = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(104, 215);
            this.nudAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(274, 23);
            this.nudAmount.TabIndex = 7;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Amount";
            // 
            // mskTxtTemplateNo
            // 
            this.mskTxtTemplateNo.Location = new System.Drawing.Point(151, 186);
            this.mskTxtTemplateNo.Mask = "00-00-000";
            this.mskTxtTemplateNo.Name = "mskTxtTemplateNo";
            this.mskTxtTemplateNo.ReadOnly = true;
            this.mskTxtTemplateNo.Size = new System.Drawing.Size(227, 23);
            this.mskTxtTemplateNo.TabIndex = 6;
            this.mskTxtTemplateNo.Text = "0000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Obligation No.";
            // 
            // epObligationNum
            // 
            this.epObligationNum.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Date Entry";
            // 
            // dtPickerDateIssued
            // 
            this.dtPickerDateIssued.CustomFormat = "";
            this.dtPickerDateIssued.Location = new System.Drawing.Point(104, 157);
            this.dtPickerDateIssued.Name = "dtPickerDateIssued";
            this.dtPickerDateIssued.Size = new System.Drawing.Size(274, 23);
            this.dtPickerDateIssued.TabIndex = 5;
            this.dtPickerDateIssued.ValueChanged += new System.EventHandler(this.dtPickerDateIssued_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Type of Fund";
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(104, 13);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(274, 23);
            this.cmbxFunds.TabIndex = 0;
            this.cmbxFunds.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFunds_Validating);
            this.cmbxFunds.Validated += new System.EventHandler(this.cmbxFunds_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "FPP";
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(104, 41);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(274, 23);
            this.cmbxFPP.TabIndex = 1;
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(104, 70);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(274, 23);
            this.cmbxOthersFPP.TabIndex = 2;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Others FPP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Allotment Class";
            // 
            // cmbxAllotmentClasses
            // 
            this.cmbxAllotmentClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAllotmentClasses.FormattingEnabled = true;
            this.cmbxAllotmentClasses.Location = new System.Drawing.Point(104, 99);
            this.cmbxAllotmentClasses.Name = "cmbxAllotmentClasses";
            this.cmbxAllotmentClasses.Size = new System.Drawing.Size(274, 23);
            this.cmbxAllotmentClasses.TabIndex = 3;
            this.cmbxAllotmentClasses.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAllotmentClasses_Validating);
            this.cmbxAllotmentClasses.Validated += new System.EventHandler(this.cmbxAllotmentClasses_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Account";
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(104, 128);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(274, 23);
            this.cmbxAccount.TabIndex = 4;
            this.cmbxAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccount_Validating);
            this.cmbxAccount.Validated += new System.EventHandler(this.cmbxAccount_Validated);
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOthersFPP
            // 
            this.epOthersFPP.ContainerControl = this;
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // epFunds
            // 
            this.epFunds.ContainerControl = this;
            // 
            // epAllotmentClass
            // 
            this.epAllotmentClass.ContainerControl = this;
            // 
            // mskObligationSeriesNo
            // 
            this.mskObligationSeriesNo.Location = new System.Drawing.Point(104, 186);
            this.mskObligationSeriesNo.Mask = "0000";
            this.mskObligationSeriesNo.Name = "mskObligationSeriesNo";
            this.mskObligationSeriesNo.Size = new System.Drawing.Size(41, 23);
            this.mskObligationSeriesNo.TabIndex = 15;
            this.mskObligationSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mskObligationSeriesNo);
            this.Controls.Add(this.cmbxAccount);
            this.Controls.Add(this.cmbxAllotmentClasses);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbxFunds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPickerDateIssued);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mskTxtTemplateNo);
            this.Controls.Add(this.label8);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(409, 246);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.MaskedTextBox mskTxtTemplateNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider epObligationNum;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DateTimePicker dtPickerDateIssued;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClasses;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.ErrorProvider epFPP;
        private System.Windows.Forms.ErrorProvider epOthersFPP;
        private System.Windows.Forms.ErrorProvider epAccount;
        private System.Windows.Forms.ErrorProvider epFunds;
        private System.Windows.Forms.ErrorProvider epAllotmentClass;
        internal System.Windows.Forms.MaskedTextBox mskObligationSeriesNo;
    }
}
