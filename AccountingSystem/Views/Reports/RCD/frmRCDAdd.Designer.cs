
namespace AccountingSystem.Views.Reports.RCD
{
    partial class frmRCDAdd
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgCollectorsReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCollector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbfunds = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCollectorsReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOkay);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 441);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 28);
            this.panel2.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(913, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOkay
            // 
            this.btnOkay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkay.Location = new System.Drawing.Point(825, 3);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOkay.Size = new System.Drawing.Size(82, 22);
            this.btnOkay.TabIndex = 6;
            this.btnOkay.Text = "Select";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1526, -69);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(82, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(1438, -69);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSelect.Size = new System.Drawing.Size(82, 22);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // dgCollectorsReport
            // 
            this.dgCollectorsReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCollectorsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCollectorsReport.Location = new System.Drawing.Point(12, 38);
            this.dgCollectorsReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgCollectorsReport.Name = "dgCollectorsReport";
            this.dgCollectorsReport.RowHeadersWidth = 51;
            this.dgCollectorsReport.RowTemplate.Height = 29;
            this.dgCollectorsReport.Size = new System.Drawing.Size(974, 401);
            this.dgCollectorsReport.TabIndex = 19;
            this.dgCollectorsReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCollectorsReport_CellContentClick);
            this.dgCollectorsReport.SelectionChanged += new System.EventHandler(this.dgCollectorsReport_SelectionChanged);
            this.dgCollectorsReport.DoubleClick += new System.EventHandler(this.dgCollectorsReport_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCollector);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbfunds);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 33);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4);
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Collector";
            // 
            // cmbCollector
            // 
            this.cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollector.FormattingEnabled = true;
            this.cmbCollector.Items.AddRange(new object[] {
            "All"});
            this.cmbCollector.Location = new System.Drawing.Point(70, 5);
            this.cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCollector.Name = "cmbCollector";
            this.cmbCollector.Size = new System.Drawing.Size(209, 23);
            this.cmbCollector.TabIndex = 9;
            this.cmbCollector.SelectedValueChanged += new System.EventHandler(this.cmbCollector_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 5);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4);
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Funds";
            // 
            // cmbfunds
            // 
            this.cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfunds.FormattingEnabled = true;
            this.cmbfunds.Location = new System.Drawing.Point(335, 5);
            this.cmbfunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbfunds.Name = "cmbfunds";
            this.cmbfunds.Size = new System.Drawing.Size(124, 23);
            this.cmbfunds.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 5);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4);
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Search";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(518, 5);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(203, 23);
            this.txtsearch.TabIndex = 12;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // frmRCDAdd
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(998, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgCollectorsReport);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRCDAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Report of Collection";
            this.Load += new System.EventHandler(this.frmRCDAdd_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCollectorsReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.DataGridView dgCollectorsReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCollector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbfunds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsearch;
    }
}