namespace LFS.Views.Transactions.Payments.CommunityTaxCertificate
{
    partial class ucTaxDue
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
            components = new System.ComponentModel.Container();
            nudAdditionalBasicTax = new System.Windows.Forms.NumericUpDown();
            nudBasicTax = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            nudGrossReceipt = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            nudSalary = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            nudIncomeFromRpt = new System.Windows.Forms.NumericUpDown();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudAdditionalBasicTax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBasicTax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGrossReceipt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudIncomeFromRpt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // nudAdditionalBasicTax
            // 
            nudAdditionalBasicTax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAdditionalBasicTax.DecimalPlaces = 2;
            nudAdditionalBasicTax.Location = new System.Drawing.Point(168, 46);
            nudAdditionalBasicTax.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudAdditionalBasicTax.Name = "nudAdditionalBasicTax";
            nudAdditionalBasicTax.Size = new System.Drawing.Size(186, 23);
            nudAdditionalBasicTax.TabIndex = 1;
            // 
            // nudBasicTax
            // 
            nudBasicTax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudBasicTax.DecimalPlaces = 2;
            nudBasicTax.Location = new System.Drawing.Point(168, 17);
            nudBasicTax.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudBasicTax.Name = "nudBasicTax";
            nudBasicTax.Size = new System.Drawing.Size(186, 23);
            nudBasicTax.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(13, 17);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(121, 15);
            label6.TabIndex = 56;
            label6.Text = "Basic Community Tax";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(13, 48);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(149, 15);
            label4.TabIndex = 57;
            label4.Text = "Additional Community Tax";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 15);
            label1.TabIndex = 57;
            label1.Text = "Gross Receipt";
            // 
            // nudGrossReceipt
            // 
            nudGrossReceipt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudGrossReceipt.DecimalPlaces = 2;
            nudGrossReceipt.Location = new System.Drawing.Point(168, 75);
            nudGrossReceipt.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudGrossReceipt.Name = "nudGrossReceipt";
            nudGrossReceipt.Size = new System.Drawing.Size(186, 23);
            nudGrossReceipt.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 106);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(140, 15);
            label2.TabIndex = 57;
            label2.Text = "Salaries / Grocess Receipt";
            // 
            // nudSalary
            // 
            nudSalary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudSalary.DecimalPlaces = 2;
            nudSalary.Location = new System.Drawing.Point(168, 104);
            nudSalary.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudSalary.Name = "nudSalary";
            nudSalary.Size = new System.Drawing.Size(186, 23);
            nudSalary.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 135);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(149, 15);
            label3.TabIndex = 57;
            label3.Text = "Income from Real Property";
            // 
            // nudIncomeFromRpt
            // 
            nudIncomeFromRpt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudIncomeFromRpt.DecimalPlaces = 2;
            nudIncomeFromRpt.Location = new System.Drawing.Point(168, 133);
            nudIncomeFromRpt.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudIncomeFromRpt.Name = "nudIncomeFromRpt";
            nudIncomeFromRpt.Size = new System.Drawing.Size(186, 23);
            nudIncomeFromRpt.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucTaxDue
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(nudIncomeFromRpt);
            Controls.Add(nudSalary);
            Controls.Add(nudGrossReceipt);
            Controls.Add(label3);
            Controls.Add(nudAdditionalBasicTax);
            Controls.Add(label2);
            Controls.Add(nudBasicTax);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label4);
            Name = "ucTaxDue";
            Size = new System.Drawing.Size(380, 168);
            Load += ucTaxDue_Load;
            ((System.ComponentModel.ISupportInitialize)nudAdditionalBasicTax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBasicTax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGrossReceipt).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudIncomeFromRpt).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.NumericUpDown nudAdditionalBasicTax;
        internal System.Windows.Forms.NumericUpDown nudBasicTax;
        internal System.Windows.Forms.NumericUpDown nudGrossReceipt;
        internal System.Windows.Forms.NumericUpDown nudSalary;
        internal System.Windows.Forms.NumericUpDown nudIncomeFromRpt;
    }
}
