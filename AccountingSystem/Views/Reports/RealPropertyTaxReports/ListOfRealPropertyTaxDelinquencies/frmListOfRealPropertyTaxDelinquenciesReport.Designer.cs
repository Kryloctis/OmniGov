
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbxLoadBy = new System.Windows.Forms.ComboBox();
            this.btnFindTaxPayer = new System.Windows.Forms.Button();
            this.cmbxMunicipality = new System.Windows.Forms.ComboBox();
            this.cmbxBarangay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTaxYear = new System.Windows.Forms.NumericUpDown();
            this.chkbxTaxYear = new System.Windows.Forms.CheckBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.taxPayerStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTaxPayerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxYear)).BeginInit();
            this.taxPayerStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1141, 64);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cmbxLoadBy);
            this.flowLayoutPanel1.Controls.Add(this.btnFindTaxPayer);
            this.flowLayoutPanel1.Controls.Add(this.cmbxMunicipality);
            this.flowLayoutPanel1.Controls.Add(this.cmbxBarangay);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.dtAsOf);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.nudTaxYear);
            this.flowLayoutPanel1.Controls.Add(this.chkbxTaxYear);
            this.flowLayoutPanel1.Controls.Add(this.btnRetrieve);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1127, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Load By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbxLoadBy
            // 
            this.cmbxLoadBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxLoadBy.FormattingEnabled = true;
            this.cmbxLoadBy.Items.AddRange(new object[] {
            "Taxpayer",
            "Municipality",
            "Barangay"});
            this.cmbxLoadBy.Location = new System.Drawing.Point(58, 3);
            this.cmbxLoadBy.Name = "cmbxLoadBy";
            this.cmbxLoadBy.Size = new System.Drawing.Size(137, 23);
            this.cmbxLoadBy.TabIndex = 13;
            this.cmbxLoadBy.SelectedValueChanged += new System.EventHandler(this.cmbxLoadBy_SelectedValueChanged);
            // 
            // btnFindTaxPayer
            // 
            this.btnFindTaxPayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindTaxPayer.Image = global::AccountingSystem.Properties.Resources.user_browse_14px;
            this.btnFindTaxPayer.Location = new System.Drawing.Point(201, 3);
            this.btnFindTaxPayer.Name = "btnFindTaxPayer";
            this.btnFindTaxPayer.Size = new System.Drawing.Size(39, 23);
            this.btnFindTaxPayer.TabIndex = 15;
            this.btnFindTaxPayer.UseVisualStyleBackColor = true;
            this.btnFindTaxPayer.Visible = false;
            this.btnFindTaxPayer.Click += new System.EventHandler(this.btnFindTaxPayer_Click);
            // 
            // cmbxMunicipality
            // 
            this.cmbxMunicipality.FormattingEnabled = true;
            this.cmbxMunicipality.Location = new System.Drawing.Point(246, 3);
            this.cmbxMunicipality.Name = "cmbxMunicipality";
            this.cmbxMunicipality.Size = new System.Drawing.Size(146, 23);
            this.cmbxMunicipality.TabIndex = 16;
            this.cmbxMunicipality.Visible = false;
            // 
            // cmbxBarangay
            // 
            this.cmbxBarangay.FormattingEnabled = true;
            this.cmbxBarangay.Location = new System.Drawing.Point(398, 3);
            this.cmbxBarangay.Name = "cmbxBarangay";
            this.cmbxBarangay.Size = new System.Drawing.Size(137, 23);
            this.cmbxBarangay.TabIndex = 16;
            this.cmbxBarangay.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(541, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "As of";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtAsOf
            // 
            this.dtAsOf.CustomFormat = "MMM dd, yyyy";
            this.dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAsOf.Location = new System.Drawing.Point(581, 3);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(120, 23);
            this.dtAsOf.TabIndex = 7;
            this.dtAsOf.ValueChanged += new System.EventHandler(this.dtAsOf_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(707, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tax Year";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudTaxYear
            // 
            this.nudTaxYear.Location = new System.Drawing.Point(762, 3);
            this.nudTaxYear.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTaxYear.Name = "nudTaxYear";
            this.nudTaxYear.Size = new System.Drawing.Size(120, 23);
            this.nudTaxYear.TabIndex = 11;
            // 
            // chkbxTaxYear
            // 
            this.chkbxTaxYear.Location = new System.Drawing.Point(888, 3);
            this.chkbxTaxYear.Name = "chkbxTaxYear";
            this.chkbxTaxYear.Size = new System.Drawing.Size(15, 23);
            this.chkbxTaxYear.TabIndex = 12;
            this.chkbxTaxYear.UseVisualStyleBackColor = true;
            this.chkbxTaxYear.CheckedChanged += new System.EventHandler(this.chkbxTaxYear_CheckedChanged);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrieve.Location = new System.Drawing.Point(909, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(86, 23);
            this.btnRetrieve.TabIndex = 14;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1141, 531);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 617);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // taxPayerStatusStrip
            // 
            this.taxPayerStatusStrip.BackColor = System.Drawing.Color.Transparent;
            this.taxPayerStatusStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.taxPayerStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTaxPayerName});
            this.taxPayerStatusStrip.Location = new System.Drawing.Point(0, 64);
            this.taxPayerStatusStrip.Name = "taxPayerStatusStrip";
            this.taxPayerStatusStrip.Size = new System.Drawing.Size(1141, 22);
            this.taxPayerStatusStrip.SizingGrip = false;
            this.taxPayerStatusStrip.TabIndex = 3;
            this.taxPayerStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "Taxpayer Name:";
            // 
            // lblTaxPayerName
            // 
            this.lblTaxPayerName.Name = "lblTaxPayerName";
            this.lblTaxPayerName.Size = new System.Drawing.Size(17, 17);
            this.lblTaxPayerName.Text = "--";
            // 
            // frmListOfRealPropertyTaxDelinquenciesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1141, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.taxPayerStatusStrip);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1157, 678);
            this.Name = "frmListOfRealPropertyTaxDelinquenciesReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report > Collection/Payment > List of Real Property Tax Delinquencies";
            this.Load += new System.EventHandler(this.frmListOfRealPropertyTaxDelinquenciesReport_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxYear)).EndInit();
            this.taxPayerStatusStrip.ResumeLayout(false);
            this.taxPayerStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        internal System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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
        private System.Windows.Forms.StatusStrip taxPayerStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTaxPayerName;
    }
}