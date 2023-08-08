
namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.CertifiedListOfPropertyTaxDelinquences
{
    partial class frmCertifiedListOfTaxDelinquences
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
            btnRetrieve = new System.Windows.Forms.Button();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRetrieve);
            groupBox1.Controls.Add(cmbxBarangays);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtAsOf);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1134, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // btnRetrieve
            // 
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(429, 22);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(82, 23);
            btnRetrieve.TabIndex = 5;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(73, 22);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(165, 23);
            cmbxBarangays.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 26);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 3;
            label2.Text = "Barangay";
            // 
            // dtAsOf
            // 
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(297, 22);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(120, 23);
            dtAsOf.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(257, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "As of";
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 65);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1141, 574);
            panel2.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1141, 60);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 60);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(1141, 5);
            pbLoadRecords.TabIndex = 22;
            // 
            // frmCertifiedListOfTaxDelinquences
            // 
            AcceptButton = btnRetrieve;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1141, 639);
            Controls.Add(panel2);
            Controls.Add(pbLoadRecords);
            Controls.Add(flowLayoutPanel1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1157, 678);
            Name = "frmCertifiedListOfTaxDelinquences";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Collection/Payment > Certified List of Real Property Tax Delinquencies";
            Load += frmCertifiedListOfTaxDelinquences_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxBarangays;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
    }
}