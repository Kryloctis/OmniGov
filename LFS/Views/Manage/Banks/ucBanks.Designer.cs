
namespace LFS.Views.Manage.Banks
{
    partial class ucBanks
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
            txtBankBranch = new System.Windows.Forms.TextBox();
            txtBankName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtBankCode = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 3;
            label1.Text = "Branch";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Name*";
            // 
            // txtBankBranch
            // 
            txtBankBranch.Location = new System.Drawing.Point(58, 56);
            txtBankBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtBankBranch.MaxLength = 45;
            txtBankBranch.Name = "txtBankBranch";
            txtBankBranch.Size = new System.Drawing.Size(250, 23);
            txtBankBranch.TabIndex = 2;
            // 
            // txtBankName
            // 
            txtBankName.Location = new System.Drawing.Point(58, 29);
            txtBankName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtBankName.MaxLength = 99;
            txtBankName.Name = "txtBankName";
            txtBankName.Size = new System.Drawing.Size(250, 23);
            txtBankName.TabIndex = 1;
            txtBankName.Validating += txtbankname_Validating;
            txtBankName.Validated += txtbankname_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 5);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 15);
            label3.TabIndex = 5;
            label3.Text = "Code";
            // 
            // txtBankCode
            // 
            txtBankCode.Location = new System.Drawing.Point(58, 2);
            txtBankCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtBankCode.MaxLength = 99;
            txtBankCode.Name = "txtBankCode";
            txtBankCode.Size = new System.Drawing.Size(250, 23);
            txtBankCode.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucBanks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtBankCode);
            Controls.Add(txtBankName);
            Controls.Add(txtBankBranch);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucBanks";
            Size = new System.Drawing.Size(328, 85);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtBankBranch;
        internal System.Windows.Forms.TextBox txtBankName;
        internal System.Windows.Forms.TextBox txtBankCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
