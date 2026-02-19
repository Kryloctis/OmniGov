namespace OmniGov.App.Views.Manage.CashTicketIssuance
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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cmbCollector = new System.Windows.Forms.ComboBox();
            cbCollectingOfficerTypeJO = new System.Windows.Forms.CheckBox();
            cmbxCashTickets = new System.Windows.Forms.ComboBox();
            dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            nudQuantity = new System.Windows.Forms.NumericUpDown();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            lblCashTcktStat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 15);
            label1.TabIndex = 28;
            label1.Text = "Collecting Officer*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 132);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 29;
            label2.Text = "Cash Ticket*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 188);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 15);
            label5.TabIndex = 32;
            label5.Text = "Quantity*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 15);
            label3.TabIndex = 30;
            label3.Text = "Date Issued *";
            // 
            // cmbCollector
            // 
            cmbCollector.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCollector.FormattingEnabled = true;
            cmbCollector.Location = new System.Drawing.Point(23, 38);
            cmbCollector.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbCollector.Name = "cmbCollector";
            cmbCollector.Size = new System.Drawing.Size(200, 23);
            cmbCollector.TabIndex = 21;
            // 
            // cbCollectingOfficerTypeJO
            // 
            cbCollectingOfficerTypeJO.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbCollectingOfficerTypeJO.AutoSize = true;
            cbCollectingOfficerTypeJO.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            cbCollectingOfficerTypeJO.Location = new System.Drawing.Point(182, 20);
            cbCollectingOfficerTypeJO.Name = "cbCollectingOfficerTypeJO";
            cbCollectingOfficerTypeJO.Size = new System.Drawing.Size(42, 17);
            cbCollectingOfficerTypeJO.TabIndex = 27;
            cbCollectingOfficerTypeJO.Text = "J.O";
            cbCollectingOfficerTypeJO.UseVisualStyleBackColor = true;
            cbCollectingOfficerTypeJO.CheckedChanged += cbCollectingOfficerTypeJO_CheckedChanged;
            // 
            // cmbxCashTickets
            // 
            cmbxCashTickets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxCashTickets.DropDownHeight = 400;
            cmbxCashTickets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxCashTickets.FormattingEnabled = true;
            cmbxCashTickets.IntegralHeight = false;
            cmbxCashTickets.Location = new System.Drawing.Point(23, 150);
            cmbxCashTickets.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxCashTickets.Name = "cmbxCashTickets";
            cmbxCashTickets.Size = new System.Drawing.Size(200, 23);
            cmbxCashTickets.TabIndex = 22;
            cmbxCashTickets.SelectedIndexChanged += cmbxCashTickets_SelectedIndexChanged;
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDateIssued.CustomFormat = "MMM dd, yyyy";
            dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateIssued.Location = new System.Drawing.Point(23, 94);
            dtpDateIssued.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new System.Drawing.Size(200, 23);
            dtpDateIssued.TabIndex = 26;
            // 
            // nudQuantity
            // 
            nudQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudQuantity.Location = new System.Drawing.Point(23, 206);
            nudQuantity.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new System.Drawing.Size(200, 23);
            nudQuantity.TabIndex = 33;
            nudQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudQuantity.ThousandsSeparator = true;
            nudQuantity.Validating += nudQuantity_Validating;
            nudQuantity.Validated += nudQuantity_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // lblCashTcktStat
            // 
            lblCashTcktStat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblCashTcktStat.AutoSize = true;
            lblCashTcktStat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblCashTcktStat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCashTcktStat.Location = new System.Drawing.Point(120, 188);
            lblCashTcktStat.Name = "lblCashTcktStat";
            lblCashTcktStat.Size = new System.Drawing.Size(104, 15);
            lblCashTcktStat.TabIndex = 34;
            lblCashTcktStat.Text = "used:0     unused:0";
            // 
            // ucCashTicketIssuance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblCashTcktStat);
            Controls.Add(nudQuantity);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(cmbCollector);
            Controls.Add(cbCollectingOfficerTypeJO);
            Controls.Add(cmbxCashTickets);
            Controls.Add(dtpDateIssued);
            Name = "ucCashTicketIssuance";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(248, 256);
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        internal System.Windows.Forms.ComboBox cmbxCashTickets;
        internal System.Windows.Forms.DateTimePicker dtpDateIssued;
        internal System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblCashTcktStat;
    }
}
