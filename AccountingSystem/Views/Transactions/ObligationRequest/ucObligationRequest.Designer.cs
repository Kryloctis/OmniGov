
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
            this.label4 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUnobligatedBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxBudgetAppropriations = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(128, 58);
            this.nudAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(419, 23);
            this.nudAmount.TabIndex = 9;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epAccount
            // 
            this.epAccount.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // txtUnobligatedBalance
            // 
            this.txtUnobligatedBalance.Location = new System.Drawing.Point(128, 29);
            this.txtUnobligatedBalance.Name = "txtUnobligatedBalance";
            this.txtUnobligatedBalance.ReadOnly = true;
            this.txtUnobligatedBalance.Size = new System.Drawing.Size(419, 23);
            this.txtUnobligatedBalance.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Unobligated Balance";
            // 
            // cmbxBudgetAppropriations
            // 
            this.cmbxBudgetAppropriations.DropDownHeight = 200;
            this.cmbxBudgetAppropriations.FormattingEnabled = true;
            this.cmbxBudgetAppropriations.IntegralHeight = false;
            this.cmbxBudgetAppropriations.Location = new System.Drawing.Point(128, 0);
            this.cmbxBudgetAppropriations.Name = "cmbxBudgetAppropriations";
            this.cmbxBudgetAppropriations.Size = new System.Drawing.Size(419, 23);
            this.cmbxBudgetAppropriations.TabIndex = 11;
            this.cmbxBudgetAppropriations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxBudgetAppropriations_KeyDown);
            this.cmbxBudgetAppropriations.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccount_Validating);
            this.cmbxBudgetAppropriations.Validated += new System.EventHandler(this.cmbxAccount_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Remaining Balance";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(419, 23);
            this.textBox1.TabIndex = 17;
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnobligatedBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbxBudgetAppropriations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label4);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(569, 113);
            this.Load += new System.EventHandler(this.ucObligationRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.ErrorProvider epAccount;
        internal System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.TextBox txtUnobligatedBalance;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbxBudgetAppropriations;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}
