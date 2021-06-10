
namespace BudgetSystem.Views.BudgetAppropriations
{
    partial class ucBudgetAppropriations
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
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxLedgerAccount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epOthersFunctionProgramProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epGeneralLedgerAcc = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chckbxContinuing = new System.Windows.Forms.CheckBox();
            this.txtFPP = new System.Windows.Forms.TextBox();
            this.txtFund = new System.Windows.Forms.TextBox();
            this.txtAllotmentClass = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPP";
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(96, 116);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(436, 23);
            this.cmbxOthersFPP.TabIndex = 4;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sub FPP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Allotment Class";
            // 
            // cmbxLedgerAccount
            // 
            this.cmbxLedgerAccount.FormattingEnabled = true;
            this.cmbxLedgerAccount.IntegralHeight = false;
            this.cmbxLedgerAccount.Location = new System.Drawing.Point(96, 174);
            this.cmbxLedgerAccount.Name = "cmbxLedgerAccount";
            this.cmbxLedgerAccount.Size = new System.Drawing.Size(436, 23);
            this.cmbxLedgerAccount.TabIndex = 6;
            this.cmbxLedgerAccount.TextChanged += new System.EventHandler(this.cmbxLedgerAccount_TextChanged);
            this.cmbxLedgerAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxLedgerAccount_KeyDown);
            this.cmbxLedgerAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxLedgerAccount_Validating);
            this.cmbxLedgerAccount.Validated += new System.EventHandler(this.cmbxLedgerAccount_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(96, 203);
            this.nudAmount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(436, 23);
            this.nudAmount.TabIndex = 7;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epOthersFunctionProgramProject
            // 
            this.epOthersFunctionProgramProject.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // epGeneralLedgerAcc
            // 
            this.epGeneralLedgerAcc.ContainerControl = this;
            // 
            // dtDateEntry
            // 
            this.dtDateEntry.Location = new System.Drawing.Point(96, 0);
            this.dtDateEntry.Name = "dtDateEntry";
            this.dtDateEntry.Size = new System.Drawing.Size(436, 23);
            this.dtDateEntry.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Date Entry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Type of Fund";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Year";
            // 
            // chckbxContinuing
            // 
            this.chckbxContinuing.AutoSize = true;
            this.chckbxContinuing.Location = new System.Drawing.Point(369, 261);
            this.chckbxContinuing.Name = "chckbxContinuing";
            this.chckbxContinuing.Size = new System.Drawing.Size(163, 19);
            this.chckbxContinuing.TabIndex = 8;
            this.chckbxContinuing.Text = "Continuing Appropriation";
            this.chckbxContinuing.UseVisualStyleBackColor = true;
            // 
            // txtFPP
            // 
            this.txtFPP.Location = new System.Drawing.Point(96, 87);
            this.txtFPP.Name = "txtFPP";
            this.txtFPP.ReadOnly = true;
            this.txtFPP.Size = new System.Drawing.Size(436, 23);
            this.txtFPP.TabIndex = 9;
            // 
            // txtFund
            // 
            this.txtFund.Location = new System.Drawing.Point(96, 58);
            this.txtFund.Name = "txtFund";
            this.txtFund.ReadOnly = true;
            this.txtFund.Size = new System.Drawing.Size(436, 23);
            this.txtFund.TabIndex = 10;
            // 
            // txtAllotmentClass
            // 
            this.txtAllotmentClass.Location = new System.Drawing.Point(96, 145);
            this.txtAllotmentClass.Name = "txtAllotmentClass";
            this.txtAllotmentClass.ReadOnly = true;
            this.txtAllotmentClass.Size = new System.Drawing.Size(436, 23);
            this.txtAllotmentClass.TabIndex = 11;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(96, 29);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(436, 23);
            this.txtYear.TabIndex = 12;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(96, 232);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(436, 23);
            this.txtRemarks.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Remarks";
            // 
            // ucBudgetAppropriations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtAllotmentClass);
            this.Controls.Add(this.txtFund);
            this.Controls.Add(this.txtFPP);
            this.Controls.Add(this.chckbxContinuing);
            this.Controls.Add(this.dtDateEntry);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxLedgerAccount);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Name = "ucBudgetAppropriations";
            this.Size = new System.Drawing.Size(554, 284);
            this.Load += new System.EventHandler(this.ucBudgetAppropriations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epOthersFunctionProgramProject;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.ErrorProvider epGeneralLedgerAcc;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.ComboBox cmbxLedgerAccount;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtDateEntry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.CheckBox chckbxContinuing;
        internal System.Windows.Forms.TextBox txtFPP;
        internal System.Windows.Forms.TextBox txtFund;
        internal System.Windows.Forms.TextBox t;
        internal System.Windows.Forms.TextBox txtAllotmentClass;
        internal System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtRemarks;
    }
}
