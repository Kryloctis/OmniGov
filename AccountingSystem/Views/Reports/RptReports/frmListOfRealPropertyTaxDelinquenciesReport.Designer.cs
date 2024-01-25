
namespace AccountingSystem.Views.Reports.RptReports
{
    partial class frmListOfRealPropertyTaxDelinquenciesReport
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
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dtTo = new System.Windows.Forms.DateTimePicker();
            btnRetrieve = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            radOwner = new System.Windows.Forms.RadioButton();
            radBarangay = new System.Windows.Forms.RadioButton();
            panel1 = new System.Windows.Forms.Panel();
            cmbxLoadBy = new System.Windows.Forms.ComboBox();
            dtFrom = new System.Windows.Forms.DateTimePicker();
            label5 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(12, 7);
            label3.Margin = new System.Windows.Forms.Padding(3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 23);
            label3.TabIndex = 8;
            label3.Text = "Load By";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(634, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 15);
            label1.TabIndex = 9;
            label1.Text = ">";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtTo
            // 
            dtTo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtTo.CustomFormat = "MMM dd, yyyy";
            dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTo.Location = new System.Drawing.Point(655, 7);
            dtTo.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            dtTo.Name = "dtTo";
            dtTo.Size = new System.Drawing.Size(120, 23);
            dtTo.TabIndex = 7;
            dtTo.ValueChanged += dtAsOf_ValueChanged;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(788, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(100, 23);
            btnRetrieve.TabIndex = 14;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 42);
            panel2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(895, 437);
            panel2.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 37);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(895, 5);
            pbLoadRecords.TabIndex = 21;
            // 
            // radOwner
            // 
            radOwner.AutoSize = true;
            radOwner.Checked = true;
            radOwner.Location = new System.Drawing.Point(67, 9);
            radOwner.Name = "radOwner";
            radOwner.Size = new System.Drawing.Size(60, 19);
            radOwner.TabIndex = 0;
            radOwner.TabStop = true;
            radOwner.Text = "Owner";
            radOwner.UseVisualStyleBackColor = true;
            // 
            // radBarangay
            // 
            radBarangay.AutoSize = true;
            radBarangay.Location = new System.Drawing.Point(133, 9);
            radBarangay.Name = "radBarangay";
            radBarangay.Size = new System.Drawing.Size(74, 19);
            radBarangay.TabIndex = 0;
            radBarangay.Text = "Barangay";
            radBarangay.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtTo);
            panel1.Controls.Add(cmbxLoadBy);
            panel1.Controls.Add(dtFrom);
            panel1.Controls.Add(btnRetrieve);
            panel1.Controls.Add(radOwner);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(radBarangay);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(895, 37);
            panel1.TabIndex = 23;
            // 
            // cmbxLoadBy
            // 
            cmbxLoadBy.FormattingEnabled = true;
            cmbxLoadBy.Location = new System.Drawing.Point(213, 7);
            cmbxLoadBy.Name = "cmbxLoadBy";
            cmbxLoadBy.Size = new System.Drawing.Size(200, 23);
            cmbxLoadBy.TabIndex = 9;
            // 
            // dtFrom
            // 
            dtFrom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtFrom.CustomFormat = "MMM dd, yyyy";
            dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtFrom.Location = new System.Drawing.Point(508, 7);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new System.Drawing.Size(120, 23);
            dtFrom.TabIndex = 7;
            dtFrom.ValueChanged += dtAsOf_ValueChanged;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(461, 11);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 15);
            label5.TabIndex = 9;
            label5.Text = "Period";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(895, 22);
            statusStrip1.TabIndex = 24;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmListOfRealPropertyTaxDelinquenciesReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(895, 501);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(pbLoadRecords);
            Controls.Add(panel1);
            MinimizeBox = false;
            Name = "frmListOfRealPropertyTaxDelinquenciesReport";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Properties > List of Real Property Tax Delinquencies";
            Load += frmListOfRealPropertyTaxDelinquenciesReport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.RadioButton radOwner;
        private System.Windows.Forms.RadioButton radBarangay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbxLoadBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
