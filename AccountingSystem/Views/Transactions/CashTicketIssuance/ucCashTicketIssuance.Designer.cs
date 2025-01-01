namespace AccountingSystem.Views.Transactions.CashTicketIssuance
{
    partial class ucCashTicketIssuance
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cmbCollector = new System.Windows.Forms.ComboBox();
            cbCollectingOfficerTypeJO = new System.Windows.Forms.CheckBox();
            cmbReceipt = new System.Windows.Forms.ComboBox();
            dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 28;
            label1.Text = "Collecting Officer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 29;
            label2.Text = "Cash Ticket";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 114);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 15);
            label5.TabIndex = 32;
            label5.Text = "Quantity ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 15);
            label3.TabIndex = 30;
            label3.Text = "Date Issued ";
            // 
            // cmbCollector
            // 
            cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCollector.FormattingEnabled = true;
            cmbCollector.Location = new System.Drawing.Point(126, 29);
            cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbCollector.Name = "cmbCollector";
            cmbCollector.Size = new System.Drawing.Size(200, 23);
            cmbCollector.TabIndex = 21;
            // 
            // cbCollectingOfficerTypeJO
            // 
            cbCollectingOfficerTypeJO.AutoSize = true;
            cbCollectingOfficerTypeJO.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            cbCollectingOfficerTypeJO.Location = new System.Drawing.Point(127, 8);
            cbCollectingOfficerTypeJO.Name = "cbCollectingOfficerTypeJO";
            cbCollectingOfficerTypeJO.Size = new System.Drawing.Size(114, 17);
            cbCollectingOfficerTypeJO.TabIndex = 27;
            cbCollectingOfficerTypeJO.Text = "Show Job Orders";
            cbCollectingOfficerTypeJO.UseVisualStyleBackColor = true;
            // 
            // cmbReceipt
            // 
            cmbReceipt.DropDownHeight = 400;
            cmbReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbReceipt.FormattingEnabled = true;
            cmbReceipt.IntegralHeight = false;
            cmbReceipt.Location = new System.Drawing.Point(126, 84);
            cmbReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbReceipt.Name = "cmbReceipt";
            cmbReceipt.Size = new System.Drawing.Size(200, 23);
            cmbReceipt.TabIndex = 22;
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.CustomFormat = "MM/dd/yyyy";
            dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateIssued.Location = new System.Drawing.Point(126, 56);
            dtpDateIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new System.Drawing.Size(200, 23);
            dtpDateIssued.TabIndex = 26;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(127, 112);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(199, 23);
            numericUpDown1.TabIndex = 33;
            numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ucCashTicketIssuance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(cmbCollector);
            Controls.Add(cbCollectingOfficerTypeJO);
            Controls.Add(cmbReceipt);
            Controls.Add(dtpDateIssued);
            Name = "ucCashTicketIssuance";
            Size = new System.Drawing.Size(343, 146);
            Load += ucCashTicketIssuance_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbCollector;
        internal System.Windows.Forms.CheckBox cbCollectingOfficerTypeJO;
        internal System.Windows.Forms.ComboBox cmbReceipt;
        internal System.Windows.Forms.DateTimePicker dtpDateIssued;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
