
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindTaxPayer = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.cmbxLoadBy = new System.Windows.Forms.ComboBox();
            this.nudTaxYear = new System.Windows.Forms.NumericUpDown();
            this.chkbxTaxYear = new System.Windows.Forms.CheckBox();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxYear)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(1141, 88);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(4, 62);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1133, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "Taxpayer:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel2.Text = "owner_name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindTaxPayer);
            this.groupBox1.Controls.Add(this.btnRetrieve);
            this.groupBox1.Controls.Add(this.cmbxLoadBy);
            this.groupBox1.Controls.Add(this.nudTaxYear);
            this.groupBox1.Controls.Add(this.chkbxTaxYear);
            this.groupBox1.Controls.Add(this.dtAsOf);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnFindTaxPayer
            // 
            this.btnFindTaxPayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindTaxPayer.Image = global::AccountingSystem.Properties.Resources.user_browse_14px;
            this.btnFindTaxPayer.Location = new System.Drawing.Point(204, 24);
            this.btnFindTaxPayer.Name = "btnFindTaxPayer";
            this.btnFindTaxPayer.Size = new System.Drawing.Size(39, 23);
            this.btnFindTaxPayer.TabIndex = 6;
            this.btnFindTaxPayer.UseVisualStyleBackColor = true;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetrieve.Location = new System.Drawing.Point(661, 24);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(86, 23);
            this.btnRetrieve.TabIndex = 5;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            // 
            // cmbxLoadBy
            // 
            this.cmbxLoadBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxLoadBy.FormattingEnabled = true;
            this.cmbxLoadBy.Items.AddRange(new object[] {
            "Municipality",
            "Taxpayer",
            "Barangay",
            "Section"});
            this.cmbxLoadBy.Location = new System.Drawing.Point(61, 24);
            this.cmbxLoadBy.Name = "cmbxLoadBy";
            this.cmbxLoadBy.Size = new System.Drawing.Size(137, 23);
            this.cmbxLoadBy.TabIndex = 4;
            this.cmbxLoadBy.SelectedValueChanged += new System.EventHandler(this.cmbxLoadBy_SelectedValueChanged);
            // 
            // nudTaxYear
            // 
            this.nudTaxYear.Location = new System.Drawing.Point(492, 24);
            this.nudTaxYear.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudTaxYear.Name = "nudTaxYear";
            this.nudTaxYear.Size = new System.Drawing.Size(120, 23);
            this.nudTaxYear.TabIndex = 2;
            // 
            // chkbxTaxYear
            // 
            this.chkbxTaxYear.AutoSize = true;
            this.chkbxTaxYear.Location = new System.Drawing.Point(618, 28);
            this.chkbxTaxYear.Name = "chkbxTaxYear";
            this.chkbxTaxYear.Size = new System.Drawing.Size(15, 14);
            this.chkbxTaxYear.TabIndex = 3;
            this.chkbxTaxYear.UseVisualStyleBackColor = true;
            this.chkbxTaxYear.CheckedChanged += new System.EventHandler(this.chkbxTaxYear_CheckedChanged);
            // 
            // dtAsOf
            // 
            this.dtAsOf.CustomFormat = "MMM dd, yyyy";
            this.dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAsOf.Location = new System.Drawing.Point(301, 24);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(120, 23);
            this.dtAsOf.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Load By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "As of";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tax Year";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1141, 529);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3});
            this.statusStrip2.Location = new System.Drawing.Point(0, 617);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel3.Text = "Report Status...";
            // 
            // frmListOfRealPropertyTaxDelinquenciesReport
            // 
            this.AcceptButton = this.btnRetrieve;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1141, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1157, 678);
            this.Name = "frmListOfRealPropertyTaxDelinquenciesReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report > Collection/Payment > List of Real Property Tax Delinquencies";
            this.Load += new System.EventHandler(this.frmListOfRealPropertyTaxDelinquenciesReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTaxYear)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtAsOf;
        private System.Windows.Forms.CheckBox chkbxTaxYear;
        private System.Windows.Forms.NumericUpDown nudTaxYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbxLoadBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnFindTaxPayer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}