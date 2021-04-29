
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
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epAccount = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAllotmentBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(61, 4);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(299, 23);
            this.cmbxAccount.TabIndex = 1;
            this.cmbxAccount.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxAccount_Validating);
            this.cmbxAccount.Validated += new System.EventHandler(this.cmbxAccount_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(73, 92);
            this.nudAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(299, 23);
            this.nudAmount.TabIndex = 3;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allotment Release Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAllotmentBalance);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbxAccount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 64);
            this.panel1.TabIndex = 0;
            // 
            // txtAllotmentBalance
            // 
            this.txtAllotmentBalance.Location = new System.Drawing.Point(61, 33);
            this.txtAllotmentBalance.MaxLength = 999999999;
            this.txtAllotmentBalance.Name = "txtAllotmentBalance";
            this.txtAllotmentBalance.ReadOnly = true;
            this.txtAllotmentBalance.Size = new System.Drawing.Size(299, 23);
            this.txtAllotmentBalance.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balance";
            // 
            // ucObligationRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label2);
            this.Name = "ucObligationRequest";
            this.Size = new System.Drawing.Size(398, 126);
            this.Load += new System.EventHandler(this.ucObligationRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ErrorProvider epAccount;
        internal System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.ComboBox cmbxAccount;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAllotmentBalance;
    }
}
