
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
            this.epBudgetAppropriation = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunctionProgramProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriation)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(140, 0);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(436, 23);
            this.cmbxFPP.TabIndex = 0;
            this.cmbxFPP.TextChanged += new System.EventHandler(this.cmbxFunctionProgramProject_TextChanged);
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPP";
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(140, 29);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(436, 23);
            this.cmbxOthersFPP.TabIndex = 1;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Others FPP";
            // 
            // cmbxAllotmentClass
            // 
            this.cmbxAllotmentClass.FormattingEnabled = true;
            this.cmbxAllotmentClass.Location = new System.Drawing.Point(140, 58);
            this.cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            this.cmbxAllotmentClass.Size = new System.Drawing.Size(436, 23);
            this.cmbxAllotmentClass.TabIndex = 2;
            this.cmbxAllotmentClass.TextChanged += new System.EventHandler(this.cmbxAllotmentClass_TextChanged);
            this.cmbxAllotmentClass.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAllotmentClass_Validating);
            this.cmbxAllotmentClass.Validated += new System.EventHandler(this.cmbxAllotmentClass_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Allotment Class";
            // 
            // cmbxLedgerAccount
            // 
            this.cmbxLedgerAccount.FormattingEnabled = true;
            this.cmbxLedgerAccount.IntegralHeight = false;
            this.cmbxLedgerAccount.Location = new System.Drawing.Point(140, 87);
            this.cmbxLedgerAccount.Name = "cmbxLedgerAccount";
            this.cmbxLedgerAccount.Size = new System.Drawing.Size(436, 23);
            this.cmbxLedgerAccount.TabIndex = 3;
            this.cmbxLedgerAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxLedgerAccount_Validating);
            this.cmbxLedgerAccount.Validated += new System.EventHandler(this.cmbxLedgerAccount_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "General Ledger Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(140, 116);
            this.nudAmount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(436, 23);
            this.nudAmount.TabIndex = 4;
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
            // epBudgetAppropriation
            // 
            this.epBudgetAppropriation.ContainerControl = this;
            // 
            // ucBudgetAppropriations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxLedgerAccount);
            this.Controls.Add(this.cmbxAllotmentClass);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.cmbxFPP);
            this.Name = "ucBudgetAppropriations";
            this.Size = new System.Drawing.Size(601, 143);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFunctionProgramProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFunctionProgramProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriation)).EndInit();
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
        private System.Windows.Forms.ErrorProvider epBudgetAppropriation;
    }
}
