namespace LFS.Views.Transactions.JEV
{
    partial class ucGenJrnl
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
            txtChckNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtOrNo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtDvNo = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "Check No.";
            // 
            // txtChckNo
            // 
            txtChckNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtChckNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtChckNo.Location = new System.Drawing.Point(91, 23);
            txtChckNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtChckNo.Name = "txtChckNo";
            txtChckNo.Size = new System.Drawing.Size(236, 23);
            txtChckNo.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 63);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(45, 15);
            label5.TabIndex = 0;
            label5.Text = "OR No.";
            // 
            // txtOrNo
            // 
            txtOrNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOrNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOrNo.Location = new System.Drawing.Point(91, 59);
            txtOrNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtOrNo.Name = "txtOrNo";
            txtOrNo.Size = new System.Drawing.Size(236, 23);
            txtOrNo.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 99);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 15);
            label6.TabIndex = 0;
            label6.Text = "DV No.";
            // 
            // txtDvNo
            // 
            txtDvNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDvNo.Location = new System.Drawing.Point(91, 95);
            txtDvNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtDvNo.Name = "txtDvNo";
            txtDvNo.Size = new System.Drawing.Size(236, 23);
            txtDvNo.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucGenJrnl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtDvNo);
            Controls.Add(label6);
            Controls.Add(txtOrNo);
            Controls.Add(label5);
            Controls.Add(txtChckNo);
            Controls.Add(label2);
            Name = "ucGenJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(350, 139);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChckNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDvNo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
