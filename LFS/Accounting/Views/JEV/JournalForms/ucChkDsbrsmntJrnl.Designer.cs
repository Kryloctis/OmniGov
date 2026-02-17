namespace LFS.Views.Transactions.JEV.JournalForms
{
    partial class ucChkDsbrsmntJrnl
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
            dtChkDate = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            txtDvNo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtRciNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            txtChkNo = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // dtChkDate
            // 
            dtChkDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtChkDate.Location = new System.Drawing.Point(99, 59);
            dtChkDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtChkDate.Name = "dtChkDate";
            dtChkDate.Size = new System.Drawing.Size(221, 23);
            dtChkDate.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 63);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 18;
            label2.Text = "Check Date";
            // 
            // txtDvNo
            // 
            txtDvNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDvNo.Location = new System.Drawing.Point(99, 131);
            txtDvNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtDvNo.Name = "txtDvNo";
            txtDvNo.Size = new System.Drawing.Size(221, 23);
            txtDvNo.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 134);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 15);
            label6.TabIndex = 22;
            label6.Text = "DV No.";
            // 
            // txtRciNo
            // 
            txtRciNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRciNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRciNo.Location = new System.Drawing.Point(99, 95);
            txtRciNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtRciNo.Name = "txtRciNo";
            txtRciNo.Size = new System.Drawing.Size(221, 23);
            txtRciNo.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 99);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(47, 15);
            label5.TabIndex = 23;
            label5.Text = "RCI No.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(23, 27);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(62, 15);
            label9.TabIndex = 24;
            label9.Text = "Check No.";
            // 
            // txtChkNo
            // 
            txtChkNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtChkNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtChkNo.Location = new System.Drawing.Point(99, 23);
            txtChkNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtChkNo.Name = "txtChkNo";
            txtChkNo.Size = new System.Drawing.Size(221, 23);
            txtChkNo.TabIndex = 29;
            // 
            // ucChkDsbrsmntJrnl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(dtChkDate);
            Controls.Add(label2);
            Controls.Add(txtDvNo);
            Controls.Add(label6);
            Controls.Add(txtRciNo);
            Controls.Add(label5);
            Controls.Add(txtChkNo);
            Controls.Add(label9);
            Name = "ucChkDsbrsmntJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(343, 180);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtChkDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDvNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRciNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChkNo;
    }
}
