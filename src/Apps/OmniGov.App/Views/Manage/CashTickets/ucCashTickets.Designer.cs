namespace OmniGov.App.Views.Manage.CashTickets
{
    partial class ucCashTickets
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
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            label4 = new System.Windows.Forms.Label();
            txtRemark = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            nudQuantity = new System.Windows.Forms.NumericUpDown();
            txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 35);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 15);
            label5.TabIndex = 22;
            label5.Text = "Quantity*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(4, 92);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 15);
            label6.TabIndex = 23;
            label6.Text = "Remarks ";
            // 
            // dtpReceivedDate
            // 
            dtpReceivedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpReceivedDate.CustomFormat = "MMM dd, yyyy";
            dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpReceivedDate.Location = new System.Drawing.Point(94, 60);
            dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpReceivedDate.Name = "dtpReceivedDate";
            dtpReceivedDate.Size = new System.Drawing.Size(200, 23);
            dtpReceivedDate.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(4, 66);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 15);
            label4.TabIndex = 21;
            label4.Text = "Received Date ";
            // 
            // txtRemark
            // 
            txtRemark.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRemark.Location = new System.Drawing.Point(94, 87);
            txtRemark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtRemark.MaxLength = 500;
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new System.Drawing.Size(200, 46);
            txtRemark.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(72, 15);
            label3.TabIndex = 24;
            label3.Text = "Description*";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // nudQuantity
            // 
            nudQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudQuantity.Location = new System.Drawing.Point(94, 32);
            nudQuantity.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new System.Drawing.Size(200, 23);
            nudQuantity.TabIndex = 1;
            nudQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDescription.Location = new System.Drawing.Point(94, 3);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(200, 23);
            txtDescription.TabIndex = 0;
            // 
            // ucCashTickets
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtDescription);
            Controls.Add(nudQuantity);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtRemark);
            Controls.Add(label4);
            Controls.Add(dtpReceivedDate);
            Name = "ucCashTickets";
            Size = new System.Drawing.Size(313, 140);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtDescription;
    }
}
