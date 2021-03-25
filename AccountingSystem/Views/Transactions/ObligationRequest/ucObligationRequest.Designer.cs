
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class ucObligationRequest
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbxTypeOfFund = new System.Windows.Forms.ComboBox();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.cmbxAllotmentClass = new System.Windows.Forms.ComboBox();
            this.cmbxGenLedgerAcc = new System.Windows.Forms.ComboBox();
            this.nudObligationAmount = new System.Windows.Forms.NumericUpDown();
            this.txtObligationNum = new System.Windows.Forms.TextBox();
            this.epTypeOfFund = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOthersFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAllotmentClass = new System.Windows.Forms.ErrorProvider(this.components);
            this.epGeneralLedgerAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationAmount = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudObligationAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type of Fund";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "FPP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Others FPP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Allotment Class";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "General Ledger Account";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Obligation No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Obligation Amount";
            // 
            // cmbxTypeOfFund
            // 
            this.cmbxTypeOfFund.FormattingEnabled = true;
            this.cmbxTypeOfFund.Location = new System.Drawing.Point(140, 0);
            this.cmbxTypeOfFund.Name = "cmbxTypeOfFund";
            this.cmbxTypeOfFund.Size = new System.Drawing.Size(304, 23);
            this.cmbxTypeOfFund.TabIndex = 1;
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(140, 29);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(304, 23);
            this.cmbxFPP.TabIndex = 1;
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(140, 58);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(304, 23);
            this.cmbxOthersFPP.TabIndex = 1;
            // 
            // cmbxAllotmentClass
            // 
            this.cmbxAllotmentClass.FormattingEnabled = true;
            this.cmbxAllotmentClass.Location = new System.Drawing.Point(140, 87);
            this.cmbxAllotmentClass.Name = "cmbxAllotmentClass";
            this.cmbxAllotmentClass.Size = new System.Drawing.Size(304, 23);
            this.cmbxAllotmentClass.TabIndex = 1;
            // 
            // cmbxGenLedgerAcc
            // 
            this.cmbxGenLedgerAcc.FormattingEnabled = true;
            this.cmbxGenLedgerAcc.Location = new System.Drawing.Point(140, 116);
            this.cmbxGenLedgerAcc.Name = "cmbxGenLedgerAcc";
            this.cmbxGenLedgerAcc.Size = new System.Drawing.Size(304, 23);
            this.cmbxGenLedgerAcc.TabIndex = 1;
            // 
            // nudObligationAmount
            // 
            this.nudObligationAmount.Location = new System.Drawing.Point(140, 174);
            this.nudObligationAmount.Name = "nudObligationAmount";
            this.nudObligationAmount.Size = new System.Drawing.Size(304, 23);
            this.nudObligationAmount.TabIndex = 2;
            // 
            // txtObligationNum
            // 
            this.txtObligationNum.Location = new System.Drawing.Point(140, 145);
            this.txtObligationNum.Name = "txtObligationNum";
            this.txtObligationNum.Size = new System.Drawing.Size(304, 23);
            this.txtObligationNum.TabIndex = 3;
            // 
            // epTypeOfFund
            // 
            this.epTypeOfFund.ContainerControl = this;
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOthersFPP
            // 
            this.epOthersFPP.ContainerControl = this;
            // 
            // epAllotmentClass
            // 
            this.epAllotmentClass.ContainerControl = this;
            // 
            // epGeneralLedgerAccount
            // 
            this.epGeneralLedgerAccount.ContainerControl = this;
            // 
            // epObligationNo
            // 
            this.epObligationNo.ContainerControl = this;
            // 
            // epObligationAmount
            // 
            this.epObligationAmount.ContainerControl = this;
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtObligationNum);
            this.Controls.Add(this.nudObligationAmount);
            this.Controls.Add(this.cmbxGenLedgerAcc);
            this.Controls.Add(this.cmbxAllotmentClass);
            this.Controls.Add(this.cmbxOthersFPP);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.cmbxTypeOfFund);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(467, 200);
            ((System.ComponentModel.ISupportInitialize)(this.nudObligationAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTypeOfFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epGeneralLedgerAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbxTypeOfFund;
        private System.Windows.Forms.ComboBox cmbxFPP;
        private System.Windows.Forms.ComboBox cmbxOthersFPP;
        private System.Windows.Forms.ComboBox cmbxAllotmentClass;
        private System.Windows.Forms.ComboBox cmbxGenLedgerAcc;
        private System.Windows.Forms.NumericUpDown nudObligationAmount;
        private System.Windows.Forms.TextBox txtObligationNum;
        private System.Windows.Forms.ErrorProvider epTypeOfFund;
        private System.Windows.Forms.ErrorProvider epFPP;
        private System.Windows.Forms.ErrorProvider epOthersFPP;
        private System.Windows.Forms.ErrorProvider epAllotmentClass;
        private System.Windows.Forms.ErrorProvider epGeneralLedgerAccount;
        private System.Windows.Forms.ErrorProvider epObligationNo;
        private System.Windows.Forms.ErrorProvider epObligationAmount;
    }
}
