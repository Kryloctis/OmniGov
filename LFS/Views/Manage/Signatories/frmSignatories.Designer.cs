
namespace LFS.Views.Manage.Signatories
{
    partial class frmSignatories
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            btnSave = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            dgSignatories = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            rchTxtDocuments = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            btnShowSidePanel = new System.Windows.Forms.Button();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSignatories).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = System.Drawing.Color.White;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel2, toolStripStatusLabel3, lblCreatedAt, toolStripStatusLabel5, toolStripStatusLabel6, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(634, 22);
            statusStrip1.TabIndex = 5;
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
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(376, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel3.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(17, 17);
            lblCreatedAt.Text = "--";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64, 64);
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(70, 17);
            toolStripStatusLabel6.Text = "Updated At:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(17, 17);
            lblUpdatedAt.Text = "--";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.button_rounded_add_20px;
            btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(62, 24);
            btnSave.Text = "Add...";
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSave, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(634, 35);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
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
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 65);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgSignatories);
            splitContainer1.Panel1.Controls.Add(progressBar1);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rchTxtDocuments);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(634, 324);
            splitContainer1.SplitterDistance = 402;
            splitContainer1.TabIndex = 8;
            // 
            // dgSignatories
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgSignatories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgSignatories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgSignatories.DefaultCellStyle = dataGridViewCellStyle8;
            dgSignatories.Dock = System.Windows.Forms.DockStyle.Fill;
            dgSignatories.Location = new System.Drawing.Point(4, 9);
            dgSignatories.Name = "dgSignatories";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgSignatories.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgSignatories.RowTemplate.Height = 25;
            dgSignatories.Size = new System.Drawing.Size(394, 311);
            dgSignatories.TabIndex = 4;
            dgSignatories.SelectionChanged += dgSignatories_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(394, 5);
            progressBar1.TabIndex = 5;
            // 
            // rchTxtDocuments
            // 
            rchTxtDocuments.BackColor = System.Drawing.SystemColors.Control;
            rchTxtDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rchTxtDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            rchTxtDocuments.Location = new System.Drawing.Point(4, 35);
            rchTxtDocuments.Name = "rchTxtDocuments";
            rchTxtDocuments.ReadOnly = true;
            rchTxtDocuments.Size = new System.Drawing.Size(220, 285);
            rchTxtDocuments.TabIndex = 2;
            rchTxtDocuments.Text = "";
            rchTxtDocuments.WordWrap = false;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            label1.Location = new System.Drawing.Point(4, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(220, 31);
            label1.TabIndex = 3;
            label1.Text = "▾Documents";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnShowSidePanel);
            panel2.Controls.Add(cmbxRowLimit);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(634, 30);
            panel2.TabIndex = 17;
            // 
            // btnShowSidePanel
            // 
            btnShowSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            btnShowSidePanel.FlatAppearance.BorderSize = 0;
            btnShowSidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnShowSidePanel.Location = new System.Drawing.Point(604, 0);
            btnShowSidePanel.Name = "btnShowSidePanel";
            btnShowSidePanel.Size = new System.Drawing.Size(30, 30);
            btnShowSidePanel.TabIndex = 1;
            btnShowSidePanel.Text = "✕";
            btnShowSidePanel.UseVisualStyleBackColor = true;
            btnShowSidePanel.Click += btnShowSidePanel_Click;
            // 
            // cmbxRowLimit
            // 
            cmbxRowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowLimit.FormattingEnabled = true;
            cmbxRowLimit.Location = new System.Drawing.Point(3, 3);
            cmbxRowLimit.Name = "cmbxRowLimit";
            cmbxRowLimit.Size = new System.Drawing.Size(120, 23);
            cmbxRowLimit.TabIndex = 0;
            cmbxRowLimit.SelectionChangeCommitted += cmbxRowLimit_SelectionChangeCommitted;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmSignatories
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(634, 411);
            Controls.Add(splitContainer1);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(650, 450);
            Name = "frmSignatories";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Signatories";
            Load += frmSignatories_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSignatories).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        internal System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        internal System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton btnEdit;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowSidePanel;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.DataGridView dgSignatories;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox rchTxtDocuments;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}