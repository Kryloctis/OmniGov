
namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies
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
            groupBox1 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            cmbxLoadBy = new System.Windows.Forms.ComboBox();
            btnFindTaxPayer = new System.Windows.Forms.Button();
            cmbxMunicipality = new System.Windows.Forms.ComboBox();
            cmbxBarangay = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            nudTaxYear = new System.Windows.Forms.NumericUpDown();
            chkbxTaxYear = new System.Windows.Forms.CheckBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            taxpayerNamePanel = new System.Windows.Forms.Panel();
            txtTaxpayerName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTaxYear).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            taxpayerNamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1138, 55);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cmbxLoadBy);
            flowLayoutPanel1.Controls.Add(btnFindTaxPayer);
            flowLayoutPanel1.Controls.Add(cmbxMunicipality);
            flowLayoutPanel1.Controls.Add(cmbxBarangay);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(dtAsOf);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(nudTaxYear);
            flowLayoutPanel1.Controls.Add(chkbxTaxYear);
            flowLayoutPanel1.Controls.Add(btnRetrieve);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1132, 33);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(3, 3);
            label3.Margin = new System.Windows.Forms.Padding(3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 23);
            label3.TabIndex = 8;
            label3.Text = "Load By";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbxLoadBy
            // 
            cmbxLoadBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxLoadBy.FormattingEnabled = true;
            cmbxLoadBy.Items.AddRange(new object[] { "Taxpayer", "Municipality", "Barangay" });
            cmbxLoadBy.Location = new System.Drawing.Point(58, 3);
            cmbxLoadBy.Name = "cmbxLoadBy";
            cmbxLoadBy.Size = new System.Drawing.Size(137, 23);
            cmbxLoadBy.TabIndex = 13;
            cmbxLoadBy.SelectedValueChanged += cmbxLoadBy_SelectedValueChanged;
            // 
            // btnFindTaxPayer
            // 
            btnFindTaxPayer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFindTaxPayer.Image = Properties.Resources.user_browse_14px;
            btnFindTaxPayer.Location = new System.Drawing.Point(201, 3);
            btnFindTaxPayer.Name = "btnFindTaxPayer";
            btnFindTaxPayer.Size = new System.Drawing.Size(39, 23);
            btnFindTaxPayer.TabIndex = 15;
            btnFindTaxPayer.UseVisualStyleBackColor = true;
            btnFindTaxPayer.Visible = false;
            btnFindTaxPayer.Click += btnFindTaxPayer_Click;
            // 
            // cmbxMunicipality
            // 
            cmbxMunicipality.FormattingEnabled = true;
            cmbxMunicipality.Location = new System.Drawing.Point(246, 3);
            cmbxMunicipality.Name = "cmbxMunicipality";
            cmbxMunicipality.Size = new System.Drawing.Size(146, 23);
            cmbxMunicipality.TabIndex = 16;
            cmbxMunicipality.Visible = false;
            // 
            // cmbxBarangay
            // 
            cmbxBarangay.FormattingEnabled = true;
            cmbxBarangay.Location = new System.Drawing.Point(398, 3);
            cmbxBarangay.Name = "cmbxBarangay";
            cmbxBarangay.Size = new System.Drawing.Size(137, 23);
            cmbxBarangay.TabIndex = 16;
            cmbxBarangay.Visible = false;
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(541, 0);
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
            dtAsOf.Location = new System.Drawing.Point(581, 3);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(120, 23);
            dtAsOf.TabIndex = 7;
            dtAsOf.ValueChanged += dtAsOf_ValueChanged;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(707, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 26);
            label2.TabIndex = 10;
            label2.Text = "Tax Year";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTaxYear
            // 
            nudTaxYear.Location = new System.Drawing.Point(762, 3);
            nudTaxYear.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudTaxYear.Name = "nudTaxYear";
            nudTaxYear.Size = new System.Drawing.Size(120, 23);
            nudTaxYear.TabIndex = 11;
            // 
            // chkbxTaxYear
            // 
            chkbxTaxYear.Location = new System.Drawing.Point(888, 3);
            chkbxTaxYear.Name = "chkbxTaxYear";
            chkbxTaxYear.Size = new System.Drawing.Size(15, 23);
            chkbxTaxYear.TabIndex = 12;
            chkbxTaxYear.UseVisualStyleBackColor = true;
            chkbxTaxYear.CheckedChanged += chkbxTaxYear_CheckedChanged;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRetrieve.Location = new System.Drawing.Point(909, 3);
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
            panel2.Location = new System.Drawing.Point(0, 102);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1141, 537);
            panel2.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(groupBox1);
            flowLayoutPanel2.Controls.Add(taxpayerNamePanel);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(1141, 97);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // taxpayerNamePanel
            // 
            taxpayerNamePanel.Controls.Add(txtTaxpayerName);
            taxpayerNamePanel.Controls.Add(label4);
            taxpayerNamePanel.Location = new System.Drawing.Point(3, 64);
            taxpayerNamePanel.Name = "taxpayerNamePanel";
            taxpayerNamePanel.Size = new System.Drawing.Size(246, 29);
            taxpayerNamePanel.TabIndex = 2;
            // 
            // txtTaxpayerName
            // 
            txtTaxpayerName.Location = new System.Drawing.Point(61, 3);
            txtTaxpayerName.Name = "txtTaxpayerName";
            txtTaxpayerName.ReadOnly = true;
            txtTaxpayerName.Size = new System.Drawing.Size(182, 23);
            txtTaxpayerName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(5, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 0;
            label4.Text = "Name";
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 97);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(1141, 5);
            progressBar1.TabIndex = 21;
            // 
            // frmListOfRealPropertyTaxDelinquenciesReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1141, 639);
            Controls.Add(panel2);
            Controls.Add(progressBar1);
            Controls.Add(flowLayoutPanel2);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1157, 678);
            Name = "frmListOfRealPropertyTaxDelinquenciesReport";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Report > Collection/Payment > List of Real Property Tax Delinquencies";
            Load += frmListOfRealPropertyTaxDelinquenciesReport_Load;
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudTaxYear).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            taxpayerNamePanel.ResumeLayout(false);
            taxpayerNamePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxLoadBy;
        private System.Windows.Forms.Button btnFindTaxPayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTaxYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.CheckBox chkbxTaxYear;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ComboBox cmbxMunicipality;
        private System.Windows.Forms.ComboBox cmbxBarangay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTaxpayerName;
        private System.Windows.Forms.Panel taxpayerNamePanel;
    }
}