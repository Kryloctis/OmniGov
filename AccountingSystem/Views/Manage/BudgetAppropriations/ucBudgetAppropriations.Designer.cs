
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
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxAllotmentClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxLedgerAccount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epFunctionProgramProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOthersFunctionProgramProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAllotmentClass = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epGeneralLedgerAcc = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtDateEntry = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbxTypeOfFund = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.epTypeOfFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.chckbxContinuing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunctionProgramProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(140, 87);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(436, 23);
            this.cmbxFPP.TabIndex = 3;
            this.cmbxFPP.SelectedValueChanged += new System.EventHandler(this.cmbxFPP_SelectedValueChanged);
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
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
            this.cmbxOthersFPP.Location = new System.Drawing.Point(140, 116);
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
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Others FPP";
            // 
            // cmbxAllotmentClass
            // 
            this.cmbxAllotmentClass.FormattingEnabled = true;
            this.cmbxAllotmentClass.Location = new System.Drawing.Point(140, 145);
            this.cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            this.cmbxAllotmentClass.Size = new System.Drawing.Size(436, 23);
            this.cmbxAllotmentClass.TabIndex = 5;
            this.cmbxAllotmentClass.SelectedValueChanged += new System.EventHandler(this.cmbxAllotmentClass_SelectedValueChanged);
            this.cmbxAllotmentClass.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAllotmentClass_Validating);
            this.cmbxAllotmentClass.Validated += new System.EventHandler(this.cmbxAllotmentClass_Validated);
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
            this.cmbxLedgerAccount.Location = new System.Drawing.Point(140, 174);
            this.cmbxLedgerAccount.Name = "cmbxLedgerAccount";
            this.cmbxLedgerAccount.Size = new System.Drawing.Size(436, 23);
            this.cmbxLedgerAccount.TabIndex = 6;
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
            this.label5.Location = new System.Drawing.Point(0, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(140, 203);
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
            // epFunctionProgramProject
            // 
            this.epFunctionProgramProject.ContainerControl = this;
            // 
            // epOthersFunctionProgramProject
            // 
            this.epOthersFunctionProgramProject.ContainerControl = this;
            // 
            // epAllotmentClass
            // 
            this.epAllotmentClass.ContainerControl = this;
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
            this.dtDateEntry.Location = new System.Drawing.Point(140, 0);
            this.dtDateEntry.Name = "dtDateEntry";
            this.dtDateEntry.Size = new System.Drawing.Size(436, 23);
            this.dtDateEntry.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 6);
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
            // cmbxTypeOfFund
            // 
            this.cmbxTypeOfFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTypeOfFund.FormattingEnabled = true;
            this.cmbxTypeOfFund.Location = new System.Drawing.Point(140, 58);
            this.cmbxTypeOfFund.Name = "cmbxTypeOfFund";
            this.cmbxTypeOfFund.Size = new System.Drawing.Size(436, 23);
            this.cmbxTypeOfFund.TabIndex = 2;
            this.cmbxTypeOfFund.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxTypeOfFund_Validating);
            this.cmbxTypeOfFund.Validated += new System.EventHandler(this.cmbxTypeOfFund_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Year";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(140, 29);
            this.nudYear.Maximum = new decimal(new int[] {
            9998,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(436, 23);
            this.nudYear.TabIndex = 1;
            this.nudYear.Value = new decimal(new int[] {
            1753,
            0,
            0,
            0});
            this.nudYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudYear_Validating);
            this.nudYear.Validated += new System.EventHandler(this.nudYear_Validated);
            // 
            // epTypeOfFund
            // 
            this.epTypeOfFund.ContainerControl = this;
            // 
            // epYear
            // 
            this.epYear.ContainerControl = this;
            // 
            // chckbxContinuing
            // 
            this.chckbxContinuing.AutoSize = true;
            this.chckbxContinuing.Location = new System.Drawing.Point(413, 232);
            this.chckbxContinuing.Name = "chckbxContinuing";
            this.chckbxContinuing.Size = new System.Drawing.Size(163, 19);
            this.chckbxContinuing.TabIndex = 8;
            this.chckbxContinuing.Text = "Continuing Appropriation";
            this.chckbxContinuing.UseVisualStyleBackColor = true;
            // 
            // ucBudgetAppropriations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.chckbxContinuing);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.cmbxTypeOfFund);
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
            this.Controls.Add(this.cmbxAllotmentClass);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.cmbxFPP);
            this.Name = "ucBudgetAppropriations";
            this.Size = new System.Drawing.Size(600, 252);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunctionProgramProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider epFunctionProgramProject;
        private System.Windows.Forms.ErrorProvider epOthersFunctionProgramProject;
        private System.Windows.Forms.ErrorProvider epAllotmentClass;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.ErrorProvider epGeneralLedgerAcc;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.ComboBox cmbxAllotmentClass;
        internal System.Windows.Forms.ComboBox cmbxLedgerAccount;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtDateEntry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider epTypeOfFund;
        private System.Windows.Forms.ErrorProvider epYear;
        internal System.Windows.Forms.NumericUpDown nudYear;
        internal System.Windows.Forms.ComboBox cmbxTypeOfFund;
        internal System.Windows.Forms.CheckBox chckbxContinuing;
    }
}
