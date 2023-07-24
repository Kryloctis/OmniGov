
namespace AccountingSystem.Views.Transactions.AssessmentPosting
{
    partial class frmAssessmentPosting
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
            panel2 = new System.Windows.Forms.Panel();
            chckBxAll = new System.Windows.Forms.CheckBox();
            dgProperties = new System.Windows.Forms.DataGridView();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtBarangay = new System.Windows.Forms.TextBox();
            txtYear = new System.Windows.Forms.TextBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnPostSelected = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            progressBarLoadRecords = new System.Windows.Forms.ToolStripProgressBar();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblPostingAssessments = new System.Windows.Forms.ToolStripStatusLabel();
            prgrsBarPostingAssessments = new System.Windows.Forms.ToolStripProgressBar();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblPostedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            lblPostedBy = new System.Windows.Forms.ToolStripStatusLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            txtSearch = new System.Windows.Forms.TextBox();
            btnRetrieve = new System.Windows.Forms.Button();
            bgwLoadAsessmentPosts = new System.ComponentModel.BackgroundWorker();
            bgwAssessmentPostSelectAll = new System.ComponentModel.BackgroundWorker();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(chckBxAll);
            panel2.Controls.Add(dgProperties);
            panel2.Controls.Add(panel1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 50);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(1039, 433);
            panel2.TabIndex = 10;
            // 
            // chckBxAll
            // 
            chckBxAll.AutoSize = true;
            chckBxAll.Location = new System.Drawing.Point(8, 41);
            chckBxAll.Name = "chckBxAll";
            chckBxAll.Size = new System.Drawing.Size(15, 14);
            chckBxAll.TabIndex = 16;
            chckBxAll.UseVisualStyleBackColor = true;
            chckBxAll.MouseClick += checkAll_MouseClick;
            // 
            // dgProperties
            // 
            dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgProperties.Location = new System.Drawing.Point(4, 35);
            dgProperties.Name = "dgProperties";
            dgProperties.RowTemplate.Height = 25;
            dgProperties.Size = new System.Drawing.Size(1031, 394);
            dgProperties.TabIndex = 15;
            dgProperties.CellValueChanged += dgProperties_CellValueChanged;
            dgProperties.ColumnAdded += dgProperties_ColumnAdded;
            dgProperties.CurrentCellDirtyStateChanged += dgProperties_CurrentCellDirtyStateChanged;
            dgProperties.SelectionChanged += dgProperties_SelectionChanged;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtBarangay);
            panel1.Controls.Add(txtYear);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1031, 31);
            panel1.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(804, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(219, 15);
            label2.TabIndex = 19;
            label2.Text = "Note: Make sure to post previous year/s.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 15);
            label1.TabIndex = 18;
            label1.Text = "Currently Viewing";
            // 
            // txtBarangay
            // 
            txtBarangay.BackColor = System.Drawing.SystemColors.Control;
            txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBarangay.Location = new System.Drawing.Point(110, 3);
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new System.Drawing.Size(188, 23);
            txtBarangay.TabIndex = 17;
            // 
            // txtYear
            // 
            txtYear.BackColor = System.Drawing.SystemColors.Control;
            txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtYear.Location = new System.Drawing.Point(304, 3);
            txtYear.Name = "txtYear";
            txtYear.Size = new System.Drawing.Size(77, 23);
            txtYear.TabIndex = 17;
            // 
            // nudYear
            // 
            nudYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudYear.Location = new System.Drawing.Point(482, 20);
            nudYear.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1500, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new System.Drawing.Size(73, 23);
            nudYear.TabIndex = 14;
            nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nudYear.Value = new decimal(new int[] { 1971, 0, 0, 0 });
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.White;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnPostSelected });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(1039, 50);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnPostSelected
            // 
            btnPostSelected.Enabled = false;
            btnPostSelected.Image = Properties.Resources.task_list_pin_20px;
            btnPostSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnPostSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPostSelected.Name = "btnPostSelected";
            btnPostSelected.Size = new System.Drawing.Size(34, 39);
            btnPostSelected.Text = "Post";
            btnPostSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnPostSelected.Click += btnPostSelected_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, progressBarLoadRecords, toolStripStatusLabel2, lblPostingAssessments, prgrsBarPostingAssessments, toolStripStatusLabel4, toolStripStatusLabel3, lblPostedAt, toolStripStatusLabel6, toolStripStatusLabel5, lblPostedBy });
            statusStrip1.Location = new System.Drawing.Point(0, 483);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1039, 22);
            statusStrip1.TabIndex = 15;
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
            // progressBarLoadRecords
            // 
            progressBarLoadRecords.Name = "progressBarLoadRecords";
            progressBarLoadRecords.Size = new System.Drawing.Size(100, 16);
            progressBarLoadRecords.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(433, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // lblPostingAssessments
            // 
            lblPostingAssessments.Name = "lblPostingAssessments";
            lblPostingAssessments.Size = new System.Drawing.Size(126, 17);
            lblPostingAssessments.Text = "Posting Assessments...";
            // 
            // prgrsBarPostingAssessments
            // 
            prgrsBarPostingAssessments.Name = "prgrsBarPostingAssessments";
            prgrsBarPostingAssessments.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel4.Text = "|";
            toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            toolStripStatusLabel3.Text = "Posted at:";
            // 
            // lblPostedAt
            // 
            lblPostedAt.Name = "lblPostedAt";
            lblPostedAt.Size = new System.Drawing.Size(12, 17);
            lblPostedAt.Text = "-";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel6.Text = "|";
            toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(62, 17);
            toolStripStatusLabel5.Text = "Posted by:";
            // 
            // lblPostedBy
            // 
            lblPostedBy.Name = "lblPostedBy";
            lblPostedBy.Size = new System.Drawing.Size(12, 17);
            lblPostedBy.Text = "-";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxBarangays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbxBarangays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(561, 20);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(166, 23);
            cmbxBarangays.TabIndex = 16;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(733, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(221, 23);
            txtSearch.TabIndex = 17;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Location = new System.Drawing.Point(960, 19);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(75, 23);
            btnRetrieve.TabIndex = 18;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // bgwLoadAsessmentPosts
            // 
            bgwLoadAsessmentPosts.WorkerReportsProgress = true;
            bgwLoadAsessmentPosts.DoWork += bgwLoadAsessmentPosts_DoWork;
            bgwLoadAsessmentPosts.ProgressChanged += bgwLoadAsessmentPosts_ProgressChanged;
            bgwLoadAsessmentPosts.RunWorkerCompleted += bgwLoadAsessmentPosts_RunWorkerCompleted;
            // 
            // bgwAssessmentPostSelectAll
            // 
            bgwAssessmentPostSelectAll.WorkerReportsProgress = true;
            bgwAssessmentPostSelectAll.DoWork += bgwAssessmentPostSelectAll_DoWork;
            bgwAssessmentPostSelectAll.ProgressChanged += bgwAssessmentPostSelectAll_ProgressChanged;
            bgwAssessmentPostSelectAll.RunWorkerCompleted += bgwAssessmentPostSelectAll_RunWorkerCompleted;
            // 
            // frmAssessmentPosting
            // 
            AcceptButton = btnRetrieve;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(1039, 505);
            Controls.Add(btnRetrieve);
            Controls.Add(txtSearch);
            Controls.Add(nudYear);
            Controls.Add(cmbxBarangays);
            Controls.Add(panel2);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmAssessmentPosting";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Assessment Posting";
            Load += frmAssessmentPosting_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chckBxAll;
        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPostSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblPostedAt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cmbxBarangays;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarangay;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblPostedBy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblPostingAssessments;
        private System.Windows.Forms.ToolStripProgressBar prgrsBarPostingAssessments;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripProgressBar progressBarLoadRecords;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgwLoadAsessmentPosts;
        private System.ComponentModel.BackgroundWorker bgwAssessmentPostSelectAll;
    }
}