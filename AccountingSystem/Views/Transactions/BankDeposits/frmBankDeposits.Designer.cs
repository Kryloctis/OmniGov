
namespace AccountingSystem.Views.Transactions.BankDeposits
{
    partial class frmBankDeposits
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            dgbankdeposits = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel3 = new System.Windows.Forms.Panel();
            dtDate = new System.Windows.Forms.DateTimePicker();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            tabPageForm = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            ucBankDeposits1 = new ucBankDeposits();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            tabControl1.SuspendLayout();
            tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgbankdeposits).BeginInit();
            panel3.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabPageForm.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageList);
            tabControl1.Controls.Add(tabPageForm);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(838, 526);
            tabControl1.TabIndex = 0;
            // 
            // tabPageList
            // 
            tabPageList.Controls.Add(dgbankdeposits);
            tabPageList.Controls.Add(progressBar1);
            tabPageList.Controls.Add(panel3);
            tabPageList.Controls.Add(toolStrip);
            tabPageList.Controls.Add(statusStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 24);
            tabPageList.Name = "tabPageList";
            tabPageList.Padding = new System.Windows.Forms.Padding(3);
            tabPageList.Size = new System.Drawing.Size(830, 498);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "tabPageList";
            tabPageList.UseVisualStyleBackColor = true;
            // 
            // dgbankdeposits
            // 
            dgbankdeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgbankdeposits.Dock = System.Windows.Forms.DockStyle.Fill;
            dgbankdeposits.Location = new System.Drawing.Point(3, 73);
            dgbankdeposits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgbankdeposits.Name = "dgbankdeposits";
            dgbankdeposits.RowHeadersWidth = 51;
            dgbankdeposits.RowTemplate.Height = 29;
            dgbankdeposits.Size = new System.Drawing.Size(824, 400);
            dgbankdeposits.TabIndex = 20;
            dgbankdeposits.SelectionChanged += dgbankdeposits_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(3, 68);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(824, 5);
            progressBar1.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.Controls.Add(dtDate);
            panel3.Controls.Add(cmbxRowFilter);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(3, 38);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(824, 30);
            panel3.TabIndex = 21;
            // 
            // dtDate
            // 
            dtDate.CustomFormat = "MMM dd, yyyy";
            dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDate.Location = new System.Drawing.Point(130, 3);
            dtDate.Name = "dtDate";
            dtDate.Size = new System.Drawing.Size(112, 23);
            dtDate.TabIndex = 1;
            dtDate.ValueChanged += dtDate_ValueChanged;
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(121, 23);
            cmbxRowFilter.TabIndex = 0;
            cmbxRowFilter.SelectionChangeCommitted += cmbxRowFilter_SelectionChangeCommitted;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.Color.Transparent;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip.Location = new System.Drawing.Point(3, 3);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(824, 35);
            toolStrip.TabIndex = 16;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.add;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.edit;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.delete;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 24);
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.MaxLength = 9999999;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount });
            statusStrip1.Location = new System.Drawing.Point(3, 473);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(824, 22);
            statusStrip1.TabIndex = 19;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // tabPageForm
            // 
            tabPageForm.Controls.Add(panel2);
            tabPageForm.Controls.Add(toolStrip1);
            tabPageForm.Controls.Add(panel1);
            tabPageForm.Location = new System.Drawing.Point(4, 24);
            tabPageForm.Margin = new System.Windows.Forms.Padding(0);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Size = new System.Drawing.Size(830, 498);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "tabPageForm";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(ucBankDeposits1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(830, 434);
            panel2.TabIndex = 2;
            // 
            // ucBankDeposits1
            // 
            ucBankDeposits1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucBankDeposits1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBankDeposits1.Location = new System.Drawing.Point(4, 4);
            ucBankDeposits1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ucBankDeposits1.Name = "ucBankDeposits1";
            ucBankDeposits1.Size = new System.Drawing.Size(822, 426);
            ucBankDeposits1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(830, 35);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.arrow_left_20px;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(56, 24);
            toolStripButton1.Text = "Back";
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 469);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(830, 29);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(677, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 23);
            button1.TabIndex = 0;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmBankDeposits
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(838, 526);
            Controls.Add(tabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmBankDeposits";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Bank Deposits";
            Load += frmBankDeposits_Load;
            tabControl1.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgbankdeposits).EndInit();
            panel3.ResumeLayout(false);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabPageForm.ResumeLayout(false);
            tabPageForm.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.DataGridView dgbankdeposits;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel2;
        private ucBankDeposits ucBankDeposits1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}