
namespace LFS.Views.Reports.Saaob
{
    partial class frmSAOB
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
            panel1 = new System.Windows.Forms.Panel();
            flwPnlCoverage = new System.Windows.Forms.FlowLayoutPanel();
            radBtn1 = new System.Windows.Forms.RadioButton();
            radBtn2 = new System.Windows.Forms.RadioButton();
            radBtn3 = new System.Windows.Forms.RadioButton();
            radBtn4 = new System.Windows.Forms.RadioButton();
            radBtn5 = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            chkbxSpecialFPP = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbxFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel3 = new System.Windows.Forms.Panel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel1.SuspendLayout();
            flwPnlCoverage.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(flwPnlCoverage);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(chkbxSpecialFPP);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(535, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(247, 515);
            panel1.TabIndex = 0;
            // 
            // flwPnlCoverage
            // 
            flwPnlCoverage.Controls.Add(radBtn1);
            flwPnlCoverage.Controls.Add(radBtn2);
            flwPnlCoverage.Controls.Add(radBtn3);
            flwPnlCoverage.Controls.Add(radBtn4);
            flwPnlCoverage.Controls.Add(radBtn5);
            flwPnlCoverage.Location = new System.Drawing.Point(24, 239);
            flwPnlCoverage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            flwPnlCoverage.Name = "flwPnlCoverage";
            flwPnlCoverage.Size = new System.Drawing.Size(200, 26);
            flwPnlCoverage.TabIndex = 19;
            // 
            // radBtn1
            // 
            radBtn1.AutoSize = true;
            radBtn1.Location = new System.Drawing.Point(3, 3);
            radBtn1.Name = "radBtn1";
            radBtn1.Size = new System.Drawing.Size(31, 19);
            radBtn1.TabIndex = 18;
            radBtn1.Text = "1";
            radBtn1.UseVisualStyleBackColor = true;
            radBtn1.CheckedChanged += radBtn1_CheckedChanged;
            // 
            // radBtn2
            // 
            radBtn2.AutoSize = true;
            radBtn2.Location = new System.Drawing.Point(40, 3);
            radBtn2.Name = "radBtn2";
            radBtn2.Size = new System.Drawing.Size(31, 19);
            radBtn2.TabIndex = 18;
            radBtn2.Text = "2";
            radBtn2.UseVisualStyleBackColor = true;
            radBtn2.CheckedChanged += radBtn2_CheckedChanged;
            // 
            // radBtn3
            // 
            radBtn3.AutoSize = true;
            radBtn3.Location = new System.Drawing.Point(77, 3);
            radBtn3.Name = "radBtn3";
            radBtn3.Size = new System.Drawing.Size(31, 19);
            radBtn3.TabIndex = 18;
            radBtn3.Text = "3";
            radBtn3.UseVisualStyleBackColor = true;
            radBtn3.CheckedChanged += radBtn3_CheckedChanged;
            // 
            // radBtn4
            // 
            radBtn4.AutoSize = true;
            radBtn4.Location = new System.Drawing.Point(114, 3);
            radBtn4.Name = "radBtn4";
            radBtn4.Size = new System.Drawing.Size(31, 19);
            radBtn4.TabIndex = 18;
            radBtn4.Text = "4";
            radBtn4.UseVisualStyleBackColor = true;
            radBtn4.CheckedChanged += radBtn4_CheckedChanged;
            // 
            // radBtn5
            // 
            radBtn5.AutoSize = true;
            radBtn5.Checked = true;
            radBtn5.Location = new System.Drawing.Point(151, 3);
            radBtn5.Name = "radBtn5";
            radBtn5.Size = new System.Drawing.Size(31, 19);
            radBtn5.TabIndex = 18;
            radBtn5.TabStop = true;
            radBtn5.Text = "5";
            radBtn5.UseVisualStyleBackColor = true;
            radBtn5.CheckedChanged += radBtn5_CheckedChanged;
            // 
            // label4
            // 
            label4.Dock = System.Windows.Forms.DockStyle.Top;
            label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Image = Properties.Resources.settings_horizontal_filled_20px;
            label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label4.Location = new System.Drawing.Point(20, 20);
            label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 40);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(207, 20);
            label4.TabIndex = 9;
            label4.Text = "Report Parameters";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(24, 158);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 15);
            label2.TabIndex = 8;
            label2.Text = "As of:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(24, 102);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 15);
            label1.TabIndex = 8;
            label1.Text = "Fund:";
            // 
            // chkbxSpecialFPP
            // 
            chkbxSpecialFPP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkbxSpecialFPP.AutoSize = true;
            chkbxSpecialFPP.Location = new System.Drawing.Point(108, 83);
            chkbxSpecialFPP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            chkbxSpecialFPP.Name = "chkbxSpecialFPP";
            chkbxSpecialFPP.Size = new System.Drawing.Size(116, 19);
            chkbxSpecialFPP.TabIndex = 7;
            chkbxSpecialFPP.Text = "Special Accounts";
            chkbxSpecialFPP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 221);
            label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 15;
            label3.Text = "Coverage:";
            // 
            // dtAsOf
            // 
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(24, 176);
            dtAsOf.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(200, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(24, 120);
            cmbxFund.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(200, 23);
            cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Location = new System.Drawing.Point(24, 298);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(200, 23);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(535, 510);
            panel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 515);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(782, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 5);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(535, 510);
            panel3.TabIndex = 5;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 0);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(535, 5);
            progressBar1.TabIndex = 7;
            // 
            // frmSAOB
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(782, 537);
            Controls.Add(panel3);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmSAOB";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Status of Apporpriations, Allotments and Obligation (SAOB)";
            Load += frmSAAOB_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flwPnlCoverage.ResumeLayout(false);
            flwPnlCoverage.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button btnRetrieve;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.RadioButton radBtn1;
        internal System.Windows.Forms.RadioButton radBtn5;
        internal System.Windows.Forms.RadioButton radBtn4;
        internal System.Windows.Forms.RadioButton radBtn3;
        internal System.Windows.Forms.RadioButton radBtn2;
        private System.Windows.Forms.CheckBox chkbxSpecialFPP;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flwPnlCoverage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
