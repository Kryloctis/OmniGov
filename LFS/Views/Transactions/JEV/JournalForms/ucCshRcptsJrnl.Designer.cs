namespace LFS.Views.Transactions.JEV.JournalForms
{
    partial class ucCshRcptsJrnl
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
            txtRcdNo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtOrNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dtOrDate = new System.Windows.Forms.DateTimePicker();
            cmbxCollctngOffcr = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtRcdNo
            // 
            txtRcdNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRcdNo.Location = new System.Drawing.Point(23, 150);
            txtRcdNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtRcdNo.Name = "txtRcdNo";
            txtRcdNo.Size = new System.Drawing.Size(229, 23);
            txtRcdNo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 132);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 15);
            label6.TabIndex = 5;
            label6.Text = "RCD No.";
            // 
            // txtOrNo
            // 
            txtOrNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOrNo.Location = new System.Drawing.Point(23, 38);
            txtOrNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtOrNo.Name = "txtOrNo";
            txtOrNo.Size = new System.Drawing.Size(229, 23);
            txtOrNo.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(45, 15);
            label5.TabIndex = 6;
            label5.Text = "OR No.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 76);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "OR Date:";
            // 
            // dtOrDate
            // 
            dtOrDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtOrDate.Location = new System.Drawing.Point(23, 94);
            dtOrDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtOrDate.Name = "dtOrDate";
            dtOrDate.Size = new System.Drawing.Size(229, 23);
            dtOrDate.TabIndex = 16;
            // 
            // cmbxCollctngOffcr
            // 
            cmbxCollctngOffcr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxCollctngOffcr.FormattingEnabled = true;
            cmbxCollctngOffcr.Location = new System.Drawing.Point(23, 206);
            cmbxCollctngOffcr.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxCollctngOffcr.Name = "cmbxCollctngOffcr";
            cmbxCollctngOffcr.Size = new System.Drawing.Size(229, 23);
            cmbxCollctngOffcr.TabIndex = 17;
            cmbxCollctngOffcr.Validating += cmbxCollctngOffcr_Validating;
            cmbxCollctngOffcr.Validated += cmbxCollctngOffcr_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 188);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(103, 15);
            label8.TabIndex = 4;
            label8.Text = "Collecting Officer:";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucCshRcptsJrnl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbxCollctngOffcr);
            Controls.Add(dtOrDate);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(txtRcdNo);
            Controls.Add(label6);
            Controls.Add(txtOrNo);
            Controls.Add(label5);
            Name = "ucCshRcptsJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(278, 259);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtRcdNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtOrDate;
        private System.Windows.Forms.ComboBox cmbxCollctngOffcr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
