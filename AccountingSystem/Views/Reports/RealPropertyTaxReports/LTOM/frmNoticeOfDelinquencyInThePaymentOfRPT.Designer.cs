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
            btnRetrieve = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            // btnRetrieve
            // 
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(169, 3);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(86, 23);
            btnRetrieve.TabIndex = 14;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 60);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1141, 579);
            panel2.TabIndex = 22;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 55);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(1141, 5);
            pbLoadRecords.TabIndex = 23;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmNoticeOfDelinquencyInThePaymentOfRPT
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1141, 639);
            Controls.Add(panel2);
            Controls.Add(pbLoadRecords);
            Controls.Add(groupBox1);
            MinimizeBox = false;
            Name = "frmNoticeOfDelinquencyInThePaymentOfRPT";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Real Property Tax Reports > LTOM - Notice of Delinquency In The Payment of Real Property Tax";
            Load += frmNoticeOfDelinquencyInThePaymentOfRPT_Load;
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}