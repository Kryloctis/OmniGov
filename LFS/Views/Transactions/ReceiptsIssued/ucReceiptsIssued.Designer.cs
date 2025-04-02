
namespace LFS.Views.Transactions.ReceiptsIssued
{
    partial class ucReceiptsIssued
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
            dtpDateIssued = new System.Windows.Forms.DateTimePicker();
            cmbCollector = new System.Windows.Forms.ComboBox();
            cmbReceipt = new System.Windows.Forms.ComboBox();
            txtReceiptQuantity = new System.Windows.Forms.TextBox();
            cbCollectingOfficerTypeJO = new System.Windows.Forms.CheckBox();
            txtReceiptIssuedFrom = new System.Windows.Forms.TextBox();
            txtReceiptIssuedTo = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtpDateIssued
            // 
            dtpDateIssued.CustomFormat = "MM/dd/yyyy";
            dtpDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateIssued.Location = new System.Drawing.Point(141, 60);
            dtpDateIssued.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpDateIssued.Name = "dtpDateIssued";
            dtpDateIssued.Size = new System.Drawing.Size(426, 23);
            dtpDateIssued.TabIndex = 6;
            dtpDateIssued.ValueChanged += dtpDateIssued_ValueChanged;
            // 
            // cmbCollector
            // 
            cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCollector.FormattingEnabled = true;
            cmbCollector.Location = new System.Drawing.Point(141, 33);
            cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbCollector.Name = "cmbCollector";
            cmbCollector.Size = new System.Drawing.Size(426, 23);
            cmbCollector.TabIndex = 0;
            cmbCollector.Validating += cmbcollector_Validating;
            cmbCollector.Validated += cmbcollector_Validated;
            // 
            // cmbReceipt
            // 
            cmbReceipt.DropDownHeight = 400;
            cmbReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbReceipt.FormattingEnabled = true;
            cmbReceipt.IntegralHeight = false;
            cmbReceipt.Location = new System.Drawing.Point(141, 88);
            cmbReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbReceipt.Name = "cmbReceipt";
            cmbReceipt.Size = new System.Drawing.Size(426, 23);
            cmbReceipt.TabIndex = 1;
            cmbReceipt.SelectedValueChanged += cmbReceipt_SelectedValueChanged;
            cmbReceipt.Validating += cmbreceipt_Validating;
            cmbReceipt.Validated += cmbreceipt_Validated;
            // 
            // txtReceiptQuantity
            // 
            txtReceiptQuantity.Location = new System.Drawing.Point(141, 174);
            txtReceiptQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReceiptQuantity.Name = "txtReceiptQuantity";
            txtReceiptQuantity.ReadOnly = true;
            txtReceiptQuantity.Size = new System.Drawing.Size(426, 23);
            txtReceiptQuantity.TabIndex = 5;
            txtReceiptQuantity.Validating += txtquantity_Validating;
            txtReceiptQuantity.Validated += txtquantity_Validated;
            // 
            // cbCollectingOfficerTypeJO
            // 
            cbCollectingOfficerTypeJO.AutoSize = true;
            cbCollectingOfficerTypeJO.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbCollectingOfficerTypeJO.Location = new System.Drawing.Point(142, 12);
            cbCollectingOfficerTypeJO.Name = "cbCollectingOfficerTypeJO";
            cbCollectingOfficerTypeJO.Size = new System.Drawing.Size(114, 17);
            cbCollectingOfficerTypeJO.TabIndex = 14;
            cbCollectingOfficerTypeJO.Text = "Show Job Orders";
            cbCollectingOfficerTypeJO.UseVisualStyleBackColor = true;
            cbCollectingOfficerTypeJO.CheckedChanged += cbCollector_CheckedChanged;
            // 
            // txtReceiptIssuedFrom
            // 
            txtReceiptIssuedFrom.Location = new System.Drawing.Point(141, 116);
            txtReceiptIssuedFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReceiptIssuedFrom.MaxLength = 7;
            txtReceiptIssuedFrom.Name = "txtReceiptIssuedFrom";
            txtReceiptIssuedFrom.Size = new System.Drawing.Size(426, 23);
            txtReceiptIssuedFrom.TabIndex = 3;
            txtReceiptIssuedFrom.TextChanged += txtReceiptIssuedFrom_TextChanged;
            txtReceiptIssuedFrom.KeyPress += txtReceiptIssuedFrom_KeyPress;
            txtReceiptIssuedFrom.Validating += txtReceiptNumberFrom_Validating;
            txtReceiptIssuedFrom.Validated += txtReceiptNumberFrom_Validated;
            // 
            // txtReceiptIssuedTo
            // 
            txtReceiptIssuedTo.Location = new System.Drawing.Point(141, 145);
            txtReceiptIssuedTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtReceiptIssuedTo.MaxLength = 7;
            txtReceiptIssuedTo.Name = "txtReceiptIssuedTo";
            txtReceiptIssuedTo.Size = new System.Drawing.Size(426, 23);
            txtReceiptIssuedTo.TabIndex = 4;
            txtReceiptIssuedTo.TextChanged += txtReceiptIssuedTo_TextChanged;
            txtReceiptIssuedTo.KeyPress += txtReceiptIssuedTo_KeyPress;
            txtReceiptIssuedTo.Validating += txtReceiptNumberTo_Validating;
            txtReceiptIssuedTo.Validated += txtReceiptNumberTo_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(12, 148);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(108, 15);
            label6.TabIndex = 20;
            label6.Text = "Receipt Number To";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 15;
            label1.Text = "Collecting Officer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 15);
            label2.TabIndex = 16;
            label2.Text = "Receipt ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 177);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 15);
            label5.TabIndex = 19;
            label5.Text = "Quantity ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 119);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(127, 15);
            label4.TabIndex = 18;
            label4.Text = "Receipt Number From ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 15);
            label3.TabIndex = 17;
            label3.Text = "Date Issued ";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucReceiptsIssued
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbCollector);
            Controls.Add(cbCollectingOfficerTypeJO);
            Controls.Add(cmbReceipt);
            Controls.Add(txtReceiptQuantity);
            Controls.Add(txtReceiptIssuedFrom);
            Controls.Add(txtReceiptIssuedTo);
            Controls.Add(dtpDateIssued);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucReceiptsIssued";
            Size = new System.Drawing.Size(586, 214);
            Load += ucReceiptsIssued_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.DateTimePicker dtpDateIssued;
        internal System.Windows.Forms.ComboBox cmbCollector;
        internal System.Windows.Forms.ComboBox cmbReceipt;
        internal System.Windows.Forms.TextBox txtReceiptQuantity;
        internal System.Windows.Forms.TextBox txtReceiptIssuedFrom;
        internal System.Windows.Forms.TextBox txtReceiptIssuedTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckBox cbCollectingOfficerTypeJO;
    }
}
