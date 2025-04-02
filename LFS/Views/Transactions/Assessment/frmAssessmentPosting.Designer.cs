
namespace LFS.Views.Transactions.Assessment
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
            nudYear = new System.Windows.Forms.NumericUpDown();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnPost = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblPost = new System.Windows.Forms.ToolStripStatusLabel();
            pbPost = new System.Windows.Forms.ToolStripProgressBar();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblPostedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            lblPostedBy = new System.Windows.Forms.ToolStripStatusLabel();
            bgwPost = new System.ComponentModel.BackgroundWorker();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            bgwLoadAsessmentPosts = new System.ComponentModel.BackgroundWorker();
            bgwAssessmentSelection = new System.ComponentModel.BackgroundWorker();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            txtBarangay = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            txtYear = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            panel1 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            statusStrip2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.Control;
            panel2.Controls.Add(chckBxAll);
            panel2.Controls.Add(dgProperties);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 92);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(915, 445);
            panel2.TabIndex = 10;
            // 
            // chckBxAll
            // 
            chckBxAll.AutoSize = true;
            chckBxAll.Location = new System.Drawing.Point(8, 9);
            chckBxAll.Name = "chckBxAll";
            chckBxAll.Size = new System.Drawing.Size(15, 14);
            chckBxAll.TabIndex = 16;
            chckBxAll.UseVisualStyleBackColor = true;
            chckBxAll.MouseClick += CheckAll_MouseClick;
            // 
            // dgProperties
            // 
            dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgProperties.Location = new System.Drawing.Point(4, 4);
            dgProperties.Name = "dgProperties";
            dgProperties.RowTemplate.Height = 25;
            dgProperties.Size = new System.Drawing.Size(907, 437);
            dgProperties.TabIndex = 15;
            dgProperties.CellEnter += dgProperties_CellEnter;
            dgProperties.CellValueChanged += dgProperties_CellValueChanged;
            dgProperties.CurrentCellDirtyStateChanged += dgProperties_CurrentCellDirtyStateChanged;
            dgProperties.SelectionChanged += DgProperties_SelectionChanged;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(302, 3);
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
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnPost, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(915, 35);
            toolStrip1.TabIndex = 14;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnPost
            // 
            btnPost.Image = Properties.Resources.task_list_pin_20px;
            btnPost.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPost.Name = "btnPost";
            btnPost.Size = new System.Drawing.Size(54, 24);
            btnPost.Text = "Post";
            btnPost.Click += BtnPost_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 39);
            btnSearch.Text = "Search";
            btnSearch.Click += BtnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 42);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblPost, pbPost, toolStripStatusLabel2, toolStripStatusLabel3, lblPostedAt, toolStripStatusLabel6, toolStripStatusLabel5, lblPostedBy });
            statusStrip1.Location = new System.Drawing.Point(0, 537);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(915, 22);
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblPost
            // 
            lblPost.Name = "lblPost";
            lblPost.Size = new System.Drawing.Size(126, 17);
            lblPost.Text = "Posting Assessments...";
            lblPost.Visible = false;
            // 
            // pbPost
            // 
            pbPost.Name = "pbPost";
            pbPost.Size = new System.Drawing.Size(100, 16);
            pbPost.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(846, 17);
            toolStripStatusLabel2.Spring = true;
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
            // bgwPost
            // 
            bgwPost.WorkerReportsProgress = true;
            bgwPost.DoWork += BgwPost_DoWork;
            bgwPost.ProgressChanged += BgwPost_ProgressChanged;
            bgwPost.RunWorkerCompleted += BgwPost_RunWorkerCompleted;
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbxBarangays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(130, 3);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(166, 23);
            cmbxBarangays.TabIndex = 16;
            // 
            // bgwLoadAsessmentPosts
            // 
            bgwLoadAsessmentPosts.WorkerReportsProgress = true;
            bgwLoadAsessmentPosts.DoWork += BgwLoadAsessmentPosts_DoWork;
            bgwLoadAsessmentPosts.ProgressChanged += BgwLoadAsessmentPosts_ProgressChanged;
            bgwLoadAsessmentPosts.RunWorkerCompleted += BgwLoadAsessmentPosts_RunWorkerCompleted;
            // 
            // bgwAssessmentSelection
            // 
            bgwAssessmentSelection.WorkerReportsProgress = true;
            bgwAssessmentSelection.DoWork += BgwAssessmentSelection_DoWork;
            bgwAssessmentSelection.ProgressChanged += BgwAssessmentSelection_ProgressChanged;
            bgwAssessmentSelection.RunWorkerCompleted += bgwAssessmentSelection_RunWorkerCompleted;
            // 
            // statusStrip2
            // 
            statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel7, txtBarangay, toolStripStatusLabel9, txtYear, toolStripStatusLabel11, toolStripStatusLabel12 });
            statusStrip2.Location = new System.Drawing.Point(0, 65);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(915, 22);
            statusStrip2.SizingGrip = false;
            statusStrip2.TabIndex = 18;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel7
            // 
            toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            toolStripStatusLabel7.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel7.Text = "Viewing:";
            // 
            // txtBarangay
            // 
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new System.Drawing.Size(56, 17);
            txtBarangay.Text = "Barangay";
            // 
            // toolStripStatusLabel9
            // 
            toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            toolStripStatusLabel9.Size = new System.Drawing.Size(12, 17);
            toolStripStatusLabel9.Text = "-";
            // 
            // txtYear
            // 
            txtYear.Name = "txtYear";
            txtYear.Size = new System.Drawing.Size(31, 17);
            txtYear.Text = "2023";
            // 
            // toolStripStatusLabel11
            // 
            toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            toolStripStatusLabel11.Size = new System.Drawing.Size(636, 17);
            toolStripStatusLabel11.Spring = true;
            // 
            // toolStripStatusLabel12
            // 
            toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            toolStripStatusLabel12.Size = new System.Drawing.Size(214, 17);
            toolStripStatusLabel12.Text = "Note: Make sure to post previous years.";
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbxRowFilter);
            panel1.Controls.Add(nudYear);
            panel1.Controls.Add(cmbxBarangays);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(915, 30);
            panel1.TabIndex = 19;
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(121, 23);
            cmbxRowFilter.TabIndex = 17;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 87);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(915, 5);
            progressBar1.TabIndex = 20;
            // 
            // frmAssessmentPosting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(915, 559);
            Controls.Add(panel2);
            Controls.Add(progressBar1);
            Controls.Add(statusStrip2);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmAssessmentPosting";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Assessment > Real Properties";
            Load += FrmAssessmentPosting_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chckBxAll;
        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnPost;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblPostedAt;
        private System.ComponentModel.BackgroundWorker bgwPost;
        private System.Windows.Forms.ComboBox cmbxBarangays;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblPostedBy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblPost;
        private System.Windows.Forms.ToolStripProgressBar pbPost;
        private System.ComponentModel.BackgroundWorker bgwLoadAsessmentPosts;
        private System.ComponentModel.BackgroundWorker bgwAssessmentSelection;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel txtBarangay;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel txtYear;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
    }
}
