namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.LTOM
{
    partial class frmNoticeOfDelinquencyInThePaymentOfRPT
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            nudTaxYear = new System.Windows.Forms.NumericUpDown();
            chkbxTaxYear = new System.Windows.Forms.CheckBox();
            btnRetrieve = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTaxYear).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1141, 55);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(dtAsOf);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(nudTaxYear);
            flowLayoutPanel1.Controls.Add(chkbxTaxYear);
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1135, 33);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 26);
            label1.TabIndex = 9;
            label1.Text = "As of";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtAsOf
            // 
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(43, 3);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(120, 23);
            dtAsOf.TabIndex = 7;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(169, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 26);
            label2.TabIndex = 10;
            label2.Text = "Tax Year";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTaxYear
            // 
            nudTaxYear.Location = new System.Drawing.Point(224, 3);
            nudTaxYear.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudTaxYear.Name = "nudTaxYear";
            nudTaxYear.Size = new System.Drawing.Size(120, 23);
            nudTaxYear.TabIndex = 11;
            // 
            // chkbxTaxYear
            // 
            chkbxTaxYear.Location = new System.Drawing.Point(350, 3);
            chkbxTaxYear.Name = "chkbxTaxYear";
            chkbxTaxYear.Size = new System.Drawing.Size(15, 23);
            chkbxTaxYear.TabIndex = 12;
            chkbxTaxYear.UseVisualStyleBackColor = true;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(371, 3);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(86, 23);
            btnRetrieve.TabIndex = 14;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            // 
            // frmNoticeOfDelinquencyInThePaymentOfRPT
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1141, 639);
            Controls.Add(groupBox1);
            MinimizeBox = false;
            Name = "frmNoticeOfDelinquencyInThePaymentOfRPT";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Property Tax Reports > LTOM - Notice of Delinquency In The Payment of Real Property Tax";
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudTaxYear).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTaxYear;
        private System.Windows.Forms.CheckBox chkbxTaxYear;
        private System.Windows.Forms.Button btnRetrieve;
    }
}