namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    partial class ucOtherPaymentRates
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
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cmbxTaxType = new System.Windows.Forms.ComboBox();
            txtDescription = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            nudAmount = new System.Windows.Forms.NumericUpDown();
            nudStartingYear = new System.Windows.Forms.NumericUpDown();
            cbIsRateEditable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStartingYear).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 13);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Tax Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 41);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(67, 15);
            label3.TabIndex = 2;
            label3.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 99);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 15);
            label4.TabIndex = 3;
            label4.Text = "Amount";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 147);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = "Starting Year";
            // 
            // cmbxTaxType
            // 
            cmbxTaxType.DropDownHeight = 100;
            cmbxTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxTaxType.FormattingEnabled = true;
            cmbxTaxType.IntegralHeight = false;
            cmbxTaxType.Location = new System.Drawing.Point(90, 13);
            cmbxTaxType.Name = "cmbxTaxType";
            cmbxTaxType.Size = new System.Drawing.Size(202, 23);
            cmbxTaxType.TabIndex = 1;
            cmbxTaxType.Validating += cmbxTaxType_Validating;
            cmbxTaxType.Validated += cmbxTaxType_Validated;
            // 
            // txtDescription
            // 
            txtDescription.Location = new System.Drawing.Point(90, 42);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(202, 48);
            txtDescription.TabIndex = 2;
            txtDescription.Validating += txtDescription_Validating;
            txtDescription.Validated += txtDescription_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 1;
            nudAmount.Location = new System.Drawing.Point(90, 97);
            nudAmount.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(202, 23);
            nudAmount.TabIndex = 3;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // nudStartingYear
            // 
            nudStartingYear.Location = new System.Drawing.Point(90, 145);
            nudStartingYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudStartingYear.Minimum = new decimal(new int[] { 1901, 0, 0, 0 });
            nudStartingYear.Name = "nudStartingYear";
            nudStartingYear.Size = new System.Drawing.Size(202, 23);
            nudStartingYear.TabIndex = 4;
            nudStartingYear.Value = new decimal(new int[] { 2023, 0, 0, 0 });
            // 
            // cbIsRateEditable
            // 
            cbIsRateEditable.AutoSize = true;
            cbIsRateEditable.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbIsRateEditable.Location = new System.Drawing.Point(204, 124);
            cbIsRateEditable.Name = "cbIsRateEditable";
            cbIsRateEditable.Size = new System.Drawing.Size(94, 17);
            cbIsRateEditable.TabIndex = 5;
            cbIsRateEditable.Text = "Editable Rate";
            cbIsRateEditable.UseVisualStyleBackColor = true;
            // 
            // ucOtherPaymentRates
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cbIsRateEditable);
            Controls.Add(nudStartingYear);
            Controls.Add(nudAmount);
            Controls.Add(cmbxTaxType);
            Controls.Add(txtDescription);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Name = "ucOtherPaymentRates";
            Size = new System.Drawing.Size(305, 180);
            Load += ucOtherPaymentRates_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStartingYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.ComboBox cmbxTaxType;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.NumericUpDown nudStartingYear;
        internal System.Windows.Forms.CheckBox cbIsRateEditable;
    }
}
