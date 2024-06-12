namespace AccountingSystem.Views.Transactions.Biddings
{
    partial class ucBiddings
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
            txtOrdinanceNo = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            cmbxAuctionSchedule = new System.Windows.Forms.ComboBox();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            nudBidAmount = new System.Windows.Forms.NumericUpDown();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudBidAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Auction Schedule* ";
            // 
            // txtOrdinanceNo
            // 
            txtOrdinanceNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOrdinanceNo.Location = new System.Drawing.Point(116, 34);
            txtOrdinanceNo.Name = "txtOrdinanceNo";
            txtOrdinanceNo.Size = new System.Drawing.Size(436, 23);
            txtOrdinanceNo.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 15);
            label3.TabIndex = 0;
            label3.Text = "Ordinance No.*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(5, 64);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(36, 15);
            label4.TabIndex = 0;
            label4.Text = "Date*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 94);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(76, 15);
            label5.TabIndex = 0;
            label5.Text = "Bid Amount*";
            // 
            // cmbxAuctionSchedule
            // 
            cmbxAuctionSchedule.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxAuctionSchedule.BackColor = System.Drawing.SystemColors.Window;
            cmbxAuctionSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxAuctionSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbxAuctionSchedule.FormattingEnabled = true;
            cmbxAuctionSchedule.Location = new System.Drawing.Point(116, 5);
            cmbxAuctionSchedule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxAuctionSchedule.Name = "cmbxAuctionSchedule";
            cmbxAuctionSchedule.Size = new System.Drawing.Size(436, 23);
            cmbxAuctionSchedule.TabIndex = 3;
            // 
            // dtpDate
            // 
            dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDate.CustomFormat = "MMM dd, yyyy";
            dtpDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDate.Location = new System.Drawing.Point(116, 63);
            dtpDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new System.Drawing.Size(436, 23);
            dtpDate.TabIndex = 4;
            // 
            // nudBidAmount
            // 
            nudBidAmount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudBidAmount.DecimalPlaces = 2;
            nudBidAmount.Location = new System.Drawing.Point(116, 92);
            nudBidAmount.Name = "nudBidAmount";
            nudBidAmount.Size = new System.Drawing.Size(436, 23);
            nudBidAmount.TabIndex = 5;
            nudBidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ucBiddings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(nudBidAmount);
            Controls.Add(dtpDate);
            Controls.Add(cmbxAuctionSchedule);
            Controls.Add(txtOrdinanceNo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "ucBiddings";
            Size = new System.Drawing.Size(573, 120);
            ((System.ComponentModel.ISupportInitialize)nudBidAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrdinanceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbxAuctionSchedule;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown nudBidAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
