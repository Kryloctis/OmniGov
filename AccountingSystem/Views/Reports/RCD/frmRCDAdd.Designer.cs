
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
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            cmbCollector = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cmbfunds = new System.Windows.Forms.ComboBox();
            txtsearch = new System.Windows.Forms.TextBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnSelect = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            dgCollectorsReport = new System.Windows.Forms.DataGridView();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgCollectorsReport).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbCollector);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbfunds);
            panel1.Controls.Add(txtsearch);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(756, 33);
            panel1.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 5);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(4);
            label1.Size = new System.Drawing.Size(63, 23);
            label1.TabIndex = 8;
            label1.Text = "Collector";
            // 
            // cmbCollector
            // 
            cmbCollector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCollector.FormattingEnabled = true;
            cmbCollector.Items.AddRange(new object[] { "All" });
            cmbCollector.Location = new System.Drawing.Point(73, 5);
            cmbCollector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbCollector.Name = "cmbCollector";
            cmbCollector.Size = new System.Drawing.Size(209, 23);
            cmbCollector.TabIndex = 9;
            cmbCollector.SelectedValueChanged += cmbCollector_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(302, 5);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(4);
            label2.Size = new System.Drawing.Size(47, 23);
            label2.TabIndex = 11;
            label2.Text = "Funds";
            // 
            // cmbfunds
            // 
            cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbfunds.FormattingEnabled = true;
            cmbfunds.Location = new System.Drawing.Point(352, 5);
            cmbfunds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbfunds.Name = "cmbfunds";
            cmbfunds.Size = new System.Drawing.Size(124, 23);
            cmbfunds.TabIndex = 10;
            // 
            // txtsearch
            // 
            txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtsearch.Location = new System.Drawing.Point(897, 5);
            txtsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtsearch.Name = "txtsearch";
            txtsearch.Size = new System.Drawing.Size(203, 23);
            txtsearch.TabIndex = 12;
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSelect);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 345);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(756, 29);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(678, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Location = new System.Drawing.Point(597, 3);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(75, 23);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgCollectorsReport);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 33);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(756, 312);
            panel2.TabIndex = 22;
            // 
            // dgCollectorsReport
            // 
            dgCollectorsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCollectorsReport.Dock = System.Windows.Forms.DockStyle.Fill;
            dgCollectorsReport.Location = new System.Drawing.Point(4, 4);
            dgCollectorsReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgCollectorsReport.Name = "dgCollectorsReport";
            dgCollectorsReport.RowHeadersWidth = 51;
            dgCollectorsReport.RowTemplate.Height = 29;
            dgCollectorsReport.Size = new System.Drawing.Size(748, 304);
            dgCollectorsReport.TabIndex = 20;
            dgCollectorsReport.SelectionChanged += dgCollectorsReport_SelectionChanged;
            dgCollectorsReport.DoubleClick += dgCollectorsReport_DoubleClick;
            // 
            // frmRCDAdd
            // 
            AcceptButton = btnSelect;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(756, 374);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmRCDAdd";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = " Collecting Officer's Reports";
            Load += frmRCDAdd_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgCollectorsReport).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCollector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbfunds;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgCollectorsReport;
    }
}