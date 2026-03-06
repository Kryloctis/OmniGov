namespace OmniGov.App.Views.Manage.BankAccounts
{
    partial class ucBankAccounts
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            cmbxBank = new System.Windows.Forms.ComboBox();
            txtAccountNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Bank Name*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 0;
            label2.Text = "Account No.*";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // cmbxBank
            // 
            cmbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBank.FormattingEnabled = true;
            cmbxBank.Location = new System.Drawing.Point(88, 3);
            cmbxBank.Name = "cmbxBank";
            cmbxBank.Size = new System.Drawing.Size(250, 23);
            cmbxBank.TabIndex = 1;
            // 
            // txtAccountNo
            // 
            txtAccountNo.Location = new System.Drawing.Point(88, 32);
            txtAccountNo.Name = "txtAccountNo";
            txtAccountNo.Size = new System.Drawing.Size(250, 23);
            txtAccountNo.TabIndex = 0;
            txtAccountNo.Validating += txtAccountNo_Validating;
            txtAccountNo.Validated += txtAccountNo_Validated;
            // 
            // ucBankAccounts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtAccountNo);
            Controls.Add(cmbxBank);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucBankAccounts";
            Size = new System.Drawing.Size(362, 59);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.TextBox txtAccountNo;
        internal System.Windows.Forms.ComboBox cmbxBank;
    }
}
