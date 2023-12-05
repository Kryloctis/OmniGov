namespace AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges
{
    partial class ucFeesCharges
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
            cbIsRateEditable = new System.Windows.Forms.CheckBox();
            nudStartingYear = new System.Windows.Forms.NumericUpDown();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            txtDescription = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudStartingYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // cbIsRateEditable
            // 
            cbIsRateEditable.AutoSize = true;
            cbIsRateEditable.Font = new System.Drawing.Font("Segoe UI", 8F);
            cbIsRateEditable.Location = new System.Drawing.Point(238, 4);
            cbIsRateEditable.Name = "cbIsRateEditable";
            cbIsRateEditable.Size = new System.Drawing.Size(94, 17);
            cbIsRateEditable.TabIndex = 14;
            cbIsRateEditable.Text = "Editable Rate";
            cbIsRateEditable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            cbIsRateEditable.UseVisualStyleBackColor = true;
            // 
            // nudStartingYear
            // 
            nudStartingYear.Location = new System.Drawing.Point(82, 85);
            nudStartingYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudStartingYear.Minimum = new decimal(new int[] { 1901, 0, 0, 0 });
            nudStartingYear.Name = "nudStartingYear";
            nudStartingYear.Size = new System.Drawing.Size(250, 23);
            nudStartingYear.TabIndex = 12;
            nudStartingYear.Value = new decimal(new int[] { 2023, 0, 0, 0 });
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 1;
            nudAmount.Location = new System.Drawing.Point(82, 56);
            nudAmount.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(250, 23);
            nudAmount.TabIndex = 10;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(82, 27);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(250, 23);
            txtDescription.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 87);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(73, 15);
            label5.TabIndex = 13;
            label5.Text = "Starting Year";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 26);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 15);
            label3.TabIndex = 9;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 58);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 15);
            label4.TabIndex = 11;
            label4.Text = "Amount";
            // 
            // ucFeesCharges
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(cbIsRateEditable);
            Controls.Add(nudStartingYear);
            Controls.Add(nudAmount);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "ucFeesCharges";
            Size = new System.Drawing.Size(350, 113);
            ((System.ComponentModel.ISupportInitialize)nudStartingYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.CheckBox cbIsRateEditable;
        internal System.Windows.Forms.NumericUpDown nudStartingYear;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
    }
}
