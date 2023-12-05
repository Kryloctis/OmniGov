namespace AccountingSystem.Views.Manage.FeesChargesConfig
{
    partial class ucFeesChargesClassification
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
            cmbxFund = new System.Windows.Forms.ComboBox();
            txtBLFGAccountCode = new System.Windows.Forms.TextBox();
            txtCOAAccountCode = new System.Windows.Forms.TextBox();
            txtDesciption = new System.Windows.Forms.TextBox();
            txtCode = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            chckBxFund = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxFund
            // 
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(122, 61);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(234, 23);
            cmbxFund.TabIndex = 16;
            // 
            // txtBLFGAccountCode
            // 
            txtBLFGAccountCode.Location = new System.Drawing.Point(122, 119);
            txtBLFGAccountCode.MaxLength = 99;
            txtBLFGAccountCode.Name = "txtBLFGAccountCode";
            txtBLFGAccountCode.Size = new System.Drawing.Size(255, 23);
            txtBLFGAccountCode.TabIndex = 18;
            // 
            // txtCOAAccountCode
            // 
            txtCOAAccountCode.Location = new System.Drawing.Point(122, 90);
            txtCOAAccountCode.MaxLength = 99;
            txtCOAAccountCode.Name = "txtCOAAccountCode";
            txtCOAAccountCode.Size = new System.Drawing.Size(255, 23);
            txtCOAAccountCode.TabIndex = 17;
            // 
            // txtDesciption
            // 
            txtDesciption.Location = new System.Drawing.Point(122, 32);
            txtDesciption.MaxLength = 99;
            txtDesciption.Name = "txtDesciption";
            txtDesciption.Size = new System.Drawing.Size(255, 23);
            txtDesciption.TabIndex = 14;
            txtDesciption.Validating += txtDesciption_Validating;
            txtDesciption.Validated += txtDesciption_Validated;
            // 
            // txtCode
            // 
            txtCode.Location = new System.Drawing.Point(122, 3);
            txtCode.MaxLength = 45;
            txtCode.Name = "txtCode";
            txtCode.Size = new System.Drawing.Size(255, 23);
            txtCode.TabIndex = 13;
            txtCode.Validating += txtCode_Validating;
            txtCode.Validated += txtCode_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 122);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(113, 15);
            label6.TabIndex = 7;
            label6.Text = "BLGF Account Code";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(111, 15);
            label5.TabIndex = 8;
            label5.Text = "COA Account Code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 67);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 15);
            label4.TabIndex = 9;
            label4.Text = "Fund ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 15);
            label2.TabIndex = 11;
            label2.Text = "Description *";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 12;
            label1.Text = "Code *";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // chckBxFund
            // 
            chckBxFund.AutoSize = true;
            chckBxFund.Checked = true;
            chckBxFund.CheckState = System.Windows.Forms.CheckState.Checked;
            chckBxFund.Location = new System.Drawing.Point(362, 65);
            chckBxFund.Name = "chckBxFund";
            chckBxFund.Size = new System.Drawing.Size(15, 14);
            chckBxFund.TabIndex = 19;
            chckBxFund.UseVisualStyleBackColor = true;
            chckBxFund.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ucFeesChargesClassification
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chckBxFund);
            Controls.Add(cmbxFund);
            Controls.Add(txtBLFGAccountCode);
            Controls.Add(txtCOAAccountCode);
            Controls.Add(txtDesciption);
            Controls.Add(txtCode);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucFeesChargesClassification";
            Size = new System.Drawing.Size(394, 144);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.TextBox txtBLFGAccountCode;
        internal System.Windows.Forms.TextBox txtCOAAccountCode;
        internal System.Windows.Forms.TextBox txtDesciption;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chckBxFund;
    }
}
