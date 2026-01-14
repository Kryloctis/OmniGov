
namespace LFS.Budget.Views.Obligations
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
            this.label4 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epObjectOfExpenditure = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUnobligatedBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxObjectOfExpenditure = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemainingBalance = new System.Windows.Forms.TextBox();
            this.cmbxSubFPP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.epSubFPP = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObjectOfExpenditure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubFPP)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(127, 87);
            this.nudAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(419, 23);
            this.nudAmount.TabIndex = 3;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epObjectOfExpenditure
            // 
            this.epObjectOfExpenditure.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // txtUnobligatedBalance
            // 
            this.txtUnobligatedBalance.Location = new System.Drawing.Point(127, 58);
            this.txtUnobligatedBalance.Name = "txtUnobligatedBalance";
            this.txtUnobligatedBalance.ReadOnly = true;
            this.txtUnobligatedBalance.Size = new System.Drawing.Size(419, 23);
            this.txtUnobligatedBalance.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Unobligated Balance";
            // 
            // cmbxObjectOfExpenditure
            // 
            this.cmbxObjectOfExpenditure.DropDownHeight = 200;
            this.cmbxObjectOfExpenditure.FormattingEnabled = true;
            this.cmbxObjectOfExpenditure.IntegralHeight = false;
            this.cmbxObjectOfExpenditure.Location = new System.Drawing.Point(127, 29);
            this.cmbxObjectOfExpenditure.Name = "cmbxObjectOfExpenditure";
            this.cmbxObjectOfExpenditure.Size = new System.Drawing.Size(419, 23);
            this.cmbxObjectOfExpenditure.TabIndex = 1;
            this.cmbxObjectOfExpenditure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxObjectOfExpenditure_KeyDown);
            this.cmbxObjectOfExpenditure.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxObjectOfExpenditure_Validating);
            this.cmbxObjectOfExpenditure.Validated += new System.EventHandler(this.cmbxObjectOfExpenditure_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Object of Expenditure";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Remaining Balance";
            // 
            // txtRemainingBalance
            // 
            this.txtRemainingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemainingBalance.Location = new System.Drawing.Point(127, 116);
            this.txtRemainingBalance.Name = "txtRemainingBalance";
            this.txtRemainingBalance.ReadOnly = true;
            this.txtRemainingBalance.Size = new System.Drawing.Size(419, 23);
            this.txtRemainingBalance.TabIndex = 4;
            // 
            // cmbxSubFPP
            // 
            this.cmbxSubFPP.FormattingEnabled = true;
            this.cmbxSubFPP.Location = new System.Drawing.Point(127, 0);
            this.cmbxSubFPP.Name = "cmbxSubFPP";
            this.cmbxSubFPP.Size = new System.Drawing.Size(419, 23);
            this.cmbxSubFPP.TabIndex = 0;
            this.cmbxSubFPP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxSubFPP_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sub FPP";
            // 
            // epSubFPP
            // 
            this.epSubFPP.ContainerControl = this;
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cmbxSubFPP);
            this.Controls.Add(this.txtRemainingBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnobligatedBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxObjectOfExpenditure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label4);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(563, 142);
            this.Load += new System.EventHandler(this.ucObligationRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObjectOfExpenditure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSubFPP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.ErrorProvider epObjectOfExpenditure;
        internal System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.TextBox txtUnobligatedBalance;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbxObjectOfExpenditure;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtRemainingBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ErrorProvider epSubFPP;
        internal System.Windows.Forms.ComboBox cmbxSubFPP;
    }
}
