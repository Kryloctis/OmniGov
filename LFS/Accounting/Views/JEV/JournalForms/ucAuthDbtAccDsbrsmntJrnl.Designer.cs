namespace LFS.Views.Transactions.JEV.JournalForms
{
    partial class ucAuthDbtAccDsbrsmntJrnl
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
            txtDvNo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtAdaNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtDvNo
            // 
            txtDvNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDvNo.Location = new System.Drawing.Point(85, 59);
            txtDvNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtDvNo.Name = "txtDvNo";
            txtDvNo.Size = new System.Drawing.Size(236, 23);
            txtDvNo.TabIndex = 42;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(26, 63);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 15);
            label6.TabIndex = 36;
            label6.Text = "DV No.";
            // 
            // txtAdaNo
            // 
            txtAdaNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAdaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAdaNo.Location = new System.Drawing.Point(85, 23);
            txtAdaNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtAdaNo.Name = "txtAdaNo";
            txtAdaNo.Size = new System.Drawing.Size(236, 23);
            txtAdaNo.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(26, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 37;
            label5.Text = "ADA No.";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucAuthDbtAccDsbrsmntJrnl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtDvNo);
            Controls.Add(label6);
            Controls.Add(txtAdaNo);
            Controls.Add(label5);
            Name = "ucAuthDbtAccDsbrsmntJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(344, 96);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtDvNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdaNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
