namespace AccountingSystem.Views.Transactions.Payments.CommunityTaxCertificate
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
            nudMonths = new System.Windows.Forms.NumericUpDown();
            nudAge = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // nudMonths
            // 
            nudMonths.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudMonths.DecimalPlaces = 2;
            nudMonths.Location = new System.Drawing.Point(168, 46);
            nudMonths.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudMonths.Name = "nudMonths";
            nudMonths.Size = new System.Drawing.Size(186, 23);
            nudMonths.TabIndex = 55;
            // 
            // nudAge
            // 
            nudAge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAge.DecimalPlaces = 2;
            nudAge.Location = new System.Drawing.Point(168, 17);
            nudAge.Name = "nudAge";
            nudAge.Size = new System.Drawing.Size(186, 23);
            nudAge.TabIndex = 54;
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
            // numericUpDown1
            // 
            numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new System.Drawing.Point(168, 75);
            numericUpDown1.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(186, 23);
            numericUpDown1.TabIndex = 55;
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
            // numericUpDown2
            // 
            numericUpDown2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Location = new System.Drawing.Point(168, 104);
            numericUpDown2.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(186, 23);
            numericUpDown2.TabIndex = 55;
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
            // numericUpDown3
            // 
            numericUpDown3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Location = new System.Drawing.Point(168, 133);
            numericUpDown3.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new System.Drawing.Size(186, 23);
            numericUpDown3.TabIndex = 55;
            // 
            // ucTaxDue
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(nudMonths);
            Controls.Add(label2);
            Controls.Add(nudAge);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label4);
            Name = "ucTaxDue";
            Size = new System.Drawing.Size(380, 168);
            Load += ucTaxDue_Load;
            ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudMonths;
        private System.Windows.Forms.NumericUpDown nudAge;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
    }
}
