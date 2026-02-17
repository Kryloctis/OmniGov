namespace LFS.Budget.Views.AllotmentRelease
{
    partial class frmAllotmentRelease
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
            customTabControl1 = new LFS.CustomTools.CustomTabControl();
            tbPgMain = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            panel10 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            dgvMain = new System.Windows.Forms.DataGridView();
            panel6 = new System.Windows.Forms.Panel();
            label9 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnCreate = new System.Windows.Forms.ToolStripButton();
            panel4 = new System.Windows.Forms.Panel();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            dtPckrTo = new System.Windows.Forms.DateTimePicker();
            dtPckrFrom = new System.Windows.Forms.DateTimePicker();
            label6 = new System.Windows.Forms.Label();
            cmbxAlltmntClass = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            cmbxFund = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            tbPgCrud = new System.Windows.Forms.TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            customTabControl1.SuspendLayout();
            tbPgMain.SuspendLayout();
            panel2.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            panel6.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgMain);
            customTabControl1.Controls.Add(tbPgCrud);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.Location = new System.Drawing.Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(882, 623);
            customTabControl1.TabIndex = 0;
            // 
            // tbPgMain
            // 
            tbPgMain.Controls.Add(panel2);
            tbPgMain.Controls.Add(panel1);
            tbPgMain.Location = new System.Drawing.Point(4, 24);
            tbPgMain.Name = "tbPgMain";
            tbPgMain.Size = new System.Drawing.Size(874, 595);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            tbPgMain.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel10);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(200, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(20);
            panel2.Size = new System.Drawing.Size(674, 595);
            panel2.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.Controls.Add(panel7);
            panel10.Controls.Add(toolStrip1);
            panel10.Controls.Add(panel4);
            panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            panel10.Location = new System.Drawing.Point(20, 20);
            panel10.Name = "panel10";
            panel10.Padding = new System.Windows.Forms.Padding(20);
            panel10.Size = new System.Drawing.Size(634, 555);
            panel10.TabIndex = 16;
            // 
            // panel7
            // 
            panel7.Controls.Add(dgvMain);
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(20, 106);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4);
            panel7.Size = new System.Drawing.Size(594, 429);
            panel7.TabIndex = 9;
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMain.Location = new System.Drawing.Point(4, 6);
            dgvMain.Margin = new System.Windows.Forms.Padding(1);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new System.Drawing.Size(586, 387);
            dgvMain.TabIndex = 7;
            // 
            // panel6
            // 
            panel6.Controls.Add(label9);
            panel6.Controls.Add(button3);
            panel6.Controls.Add(button4);
            panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel6.Location = new System.Drawing.Point(4, 393);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(586, 32);
            panel6.TabIndex = 26;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label9.Location = new System.Drawing.Point(454, 8);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(65, 15);
            label9.TabIndex = 4;
            label9.Text = "Page 1 of 3";
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            button3.Location = new System.Drawing.Point(525, 4);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(26, 23);
            button3.TabIndex = 2;
            button3.Text = "<";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            button4.Location = new System.Drawing.Point(557, 4);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(26, 23);
            button4.TabIndex = 3;
            button4.Text = ">";
            button4.UseVisualStyleBackColor = true;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(586, 2);
            pbLoadRecords.TabIndex = 25;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnDelete, tlStrpBtnUpdate, tlStrpBtnCreate });
            toolStrip1.Location = new System.Drawing.Point(20, 71);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(594, 35);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnDelete.AutoToolTip = false;
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new System.Drawing.Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnUpdate.AutoToolTip = false;
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new System.Drawing.Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            // 
            // tlStrpBtnCreate
            // 
            tlStrpBtnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnCreate.AutoToolTip = false;
            tlStrpBtnCreate.Image = Properties.Resources.button_rounded_add_20px;
            tlStrpBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnCreate.Name = "tlStrpBtnCreate";
            tlStrpBtnCreate.Size = new System.Drawing.Size(65, 24);
            tlStrpBtnCreate.Text = "Create";
            // 
            // panel4
            // 
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label8);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(20, 20);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            panel4.Size = new System.Drawing.Size(594, 51);
            panel4.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label10.Location = new System.Drawing.Point(3, 21);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(297, 15);
            label10.TabIndex = 1;
            label10.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(143, 21);
            label8.TabIndex = 0;
            label8.Text = "Allotment Release";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            panel1.Controls.Add(dtPckrTo);
            panel1.Controls.Add(dtPckrFrom);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cmbxAlltmntClass);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(200, 595);
            panel1.TabIndex = 0;
            // 
            // dtPckrTo
            // 
            dtPckrTo.CustomFormat = "MMM dd, yyyy";
            dtPckrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrTo.Location = new System.Drawing.Point(23, 300);
            dtPckrTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            dtPckrTo.Name = "dtPckrTo";
            dtPckrTo.Size = new System.Drawing.Size(154, 23);
            dtPckrTo.TabIndex = 1;
            // 
            // dtPckrFrom
            // 
            dtPckrFrom.CustomFormat = "MMM dd, yyyy";
            dtPckrFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrFrom.Location = new System.Drawing.Point(23, 239);
            dtPckrFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            dtPckrFrom.Name = "dtPckrFrom";
            dtPckrFrom.Size = new System.Drawing.Size(154, 23);
            dtPckrFrom.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label6.Location = new System.Drawing.Point(23, 282);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(19, 15);
            label6.TabIndex = 1;
            label6.Text = "To";
            // 
            // cmbxAlltmntClass
            // 
            cmbxAlltmntClass.FormattingEnabled = true;
            cmbxAlltmntClass.Location = new System.Drawing.Point(23, 160);
            cmbxAlltmntClass.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            cmbxAlltmntClass.Name = "cmbxAlltmntClass";
            cmbxAlltmntClass.Size = new System.Drawing.Size(154, 23);
            cmbxAlltmntClass.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(23, 221);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 15);
            label5.TabIndex = 1;
            label5.Text = "From";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Location = new System.Drawing.Point(23, 203);
            label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(69, 15);
            label4.TabIndex = 1;
            label4.Text = "Date Issued";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label3.Location = new System.Drawing.Point(23, 142);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 15);
            label3.TabIndex = 1;
            label3.Text = "Allotment Class";
            // 
            // cmbxFund
            // 
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(23, 99);
            cmbxFund.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(154, 23);
            cmbxFund.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(23, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 15);
            label2.TabIndex = 1;
            label2.Text = "Type of Fund";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(23, 38);
            txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(154, 23);
            txtSearch.TabIndex = 1;
            // 
            // tbPgCrud
            // 
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Padding = new System.Windows.Forms.Padding(3);
            tbPgCrud.Size = new System.Drawing.Size(874, 595);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            tbPgCrud.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmAllotmentRelease
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(882, 623);
            Controls.Add(customTabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAllotmentRelease";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Budget System > Allotment Release";
            Load += frmAllotmentRelease_Load;
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgMain;
        private System.Windows.Forms.TabPage tbPgCrud;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxAlltmntClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbxFund;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPckrFrom;
        private System.Windows.Forms.DateTimePicker dtPckrTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private System.Windows.Forms.ToolStripButton tlStrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCreate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
