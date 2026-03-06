namespace OmniGov.App.Views.Transactions.Payments.MarriageLicense
{
    partial class ucMarriageDetails
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
            dtpIssuedDate = new System.Windows.Forms.DateTimePicker();
            dtpPublishedDate = new System.Windows.Forms.DateTimePicker();
            txtRegistrationNumber = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            label2 = new System.Windows.Forms.Label();
            txtLicenseNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtpIssuedDate
            // 
            dtpIssuedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpIssuedDate.CustomFormat = "MMMM dd,  yyyy";
            dtpIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpIssuedDate.Location = new System.Drawing.Point(106, 90);
            dtpIssuedDate.Name = "dtpIssuedDate";
            dtpIssuedDate.Size = new System.Drawing.Size(250, 23);
            dtpIssuedDate.TabIndex = 9;
            // 
            // dtpPublishedDate
            // 
            dtpPublishedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpPublishedDate.CustomFormat = "MMMM dd,  yyyy";
            dtpPublishedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpPublishedDate.Location = new System.Drawing.Point(106, 61);
            dtpPublishedDate.Name = "dtpPublishedDate";
            dtpPublishedDate.Size = new System.Drawing.Size(250, 23);
            dtpPublishedDate.TabIndex = 7;
            // 
            // txtRegistrationNumber
            // 
            txtRegistrationNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRegistrationNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRegistrationNumber.Location = new System.Drawing.Point(106, 32);
            txtRegistrationNumber.Name = "txtRegistrationNumber";
            txtRegistrationNumber.Size = new System.Drawing.Size(250, 23);
            txtRegistrationNumber.TabIndex = 6;
            txtRegistrationNumber.Validating += TxtRegistrationNumber_Validating;
            txtRegistrationNumber.Validated += TxtRegistrationNumber_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(0, 94);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 15);
            label5.TabIndex = 10;
            label5.Text = "Issued on*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(0, 65);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(81, 15);
            label4.TabIndex = 8;
            label4.Text = "Published on*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 11;
            label1.Text = "Registration No. *";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 5);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 12;
            label2.Text = "License No.*";
            // 
            // txtLicenseNo
            // 
            txtLicenseNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLicenseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLicenseNo.Location = new System.Drawing.Point(106, 3);
            txtLicenseNo.Name = "txtLicenseNo";
            txtLicenseNo.Size = new System.Drawing.Size(250, 23);
            txtLicenseNo.TabIndex = 13;
            txtLicenseNo.Validating += txtLicenseNo_Validating;
            txtLicenseNo.Validated += txtLicenseNo_Validated;
            // 
            // ucMarriageDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtLicenseNo);
            Controls.Add(label2);
            Controls.Add(dtpIssuedDate);
            Controls.Add(dtpPublishedDate);
            Controls.Add(txtRegistrationNumber);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "ucMarriageDetails";
            Size = new System.Drawing.Size(378, 119);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtpIssuedDate;
        internal System.Windows.Forms.DateTimePicker dtpPublishedDate;
        internal System.Windows.Forms.TextBox txtRegistrationNumber;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtLicenseNo;
        private System.Windows.Forms.Label label2;
    }
}
