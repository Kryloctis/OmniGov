
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chckBxAll = new System.Windows.Forms.CheckBox();
            this.dgProperties = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarangay = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPostSelected = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarLoadRecords = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPostingAssessments = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgrsBarPostingAssessments = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPostedAt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPostedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmbxBarangays = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.bgwLoadAsessmentPosts = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.chckBxAll);
            this.panel2.Controls.Add(this.dgProperties);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(1039, 425);
            this.panel2.TabIndex = 10;
            // 
            // chckBxAll
            // 
            this.chckBxAll.AutoSize = true;
            this.chckBxAll.Location = new System.Drawing.Point(8, 41);
            this.chckBxAll.Name = "chckBxAll";
            this.chckBxAll.Size = new System.Drawing.Size(15, 14);
            this.chckBxAll.TabIndex = 16;
            this.chckBxAll.UseVisualStyleBackColor = true;
            this.chckBxAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkAll_MouseClick);
            // 
            // dgProperties
            // 
            this.dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProperties.Location = new System.Drawing.Point(4, 35);
            this.dgProperties.Name = "dgProperties";
            this.dgProperties.RowTemplate.Height = 25;
            this.dgProperties.Size = new System.Drawing.Size(1031, 386);
            this.dgProperties.TabIndex = 15;
            this.dgProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProperties_CellValueChanged);
            this.dgProperties.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgProperties_ColumnAdded);
            this.dgProperties.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgProperties_CurrentCellDirtyStateChanged);
            this.dgProperties.SelectionChanged += new System.EventHandler(this.dgProperties_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBarangay);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 31);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Note: Make sure to post previous year/s.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Currently Viewing";
            // 
            // txtBarangay
            // 
            this.txtBarangay.BackColor = System.Drawing.SystemColors.Control;
            this.txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarangay.Location = new System.Drawing.Point(110, 3);
            this.txtBarangay.Name = "txtBarangay";
            this.txtBarangay.Size = new System.Drawing.Size(188, 23);
            this.txtBarangay.TabIndex = 17;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.Control;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(304, 3);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(77, 23);
            this.txtYear.TabIndex = 17;
            // 
            // nudYear
            // 
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Location = new System.Drawing.Point(482, 20);
            this.nudYear.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(73, 23);
            this.nudYear.TabIndex = 14;
            this.nudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudYear.Value = new decimal(new int[] {
            1971,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPostSelected});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Size = new System.Drawing.Size(1039, 58);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPostSelected
            // 
            this.btnPostSelected.Enabled = false;
            this.btnPostSelected.Image = global::AccountingSystem.Properties.Resources.task_list_pin_28px;
            this.btnPostSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPostSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPostSelected.Name = "btnPostSelected";
            this.btnPostSelected.Size = new System.Drawing.Size(34, 47);
            this.btnPostSelected.Text = "Post";
            this.btnPostSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPostSelected.Click += new System.EventHandler(this.btnPostSelected_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordCount,
            this.progressBarLoadRecords,
            this.toolStripStatusLabel2,
            this.lblPostingAssessments,
            this.prgrsBarPostingAssessments,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.lblPostedAt,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel5,
            this.lblPostedBy});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 17);
            this.lblRecordCount.Text = "0";
            // 
            // progressBarLoadRecords
            // 
            this.progressBarLoadRecords.Name = "progressBarLoadRecords";
            this.progressBarLoadRecords.Size = new System.Drawing.Size(100, 16);
            this.progressBarLoadRecords.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(566, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // lblPostingAssessments
            // 
            this.lblPostingAssessments.Name = "lblPostingAssessments";
            this.lblPostingAssessments.Size = new System.Drawing.Size(126, 17);
            this.lblPostingAssessments.Text = "Posting Assessments...";
            // 
            // prgrsBarPostingAssessments
            // 
            this.prgrsBarPostingAssessments.Name = "prgrsBarPostingAssessments";
            this.prgrsBarPostingAssessments.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel3.Text = "Posted at:";
            // 
            // lblPostedAt
            // 
            this.lblPostedAt.Name = "lblPostedAt";
            this.lblPostedAt.Size = new System.Drawing.Size(12, 17);
            this.lblPostedAt.Text = "-";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel6.Text = "|";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabel5.Text = "Posted by:";
            // 
            // lblPostedBy
            // 
            this.lblPostedBy.Name = "lblPostedBy";
            this.lblPostedBy.Size = new System.Drawing.Size(12, 17);
            this.lblPostedBy.Text = "-";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cmbxBarangays
            // 
            this.cmbxBarangays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxBarangays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxBarangays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxBarangays.FormattingEnabled = true;
            this.cmbxBarangays.Location = new System.Drawing.Point(561, 20);
            this.cmbxBarangays.Name = "cmbxBarangays";
            this.cmbxBarangays.Size = new System.Drawing.Size(166, 23);
            this.cmbxBarangays.TabIndex = 16;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(733, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 23);
            this.txtSearch.TabIndex = 17;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieve.Location = new System.Drawing.Point(960, 19);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 18;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // bgwLoadAsessmentPosts
            // 
            this.bgwLoadAsessmentPosts.WorkerReportsProgress = true;
            this.bgwLoadAsessmentPosts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadAsessmentPosts_DoWork);
            this.bgwLoadAsessmentPosts.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwLoadAsessmentPosts_ProgressChanged);
            this.bgwLoadAsessmentPosts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadAsessmentPosts_RunWorkerCompleted);
            // 
            // frmAssessmentPosting
            // 
            this.AcceptButton = this.btnRetrieve;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1039, 505);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.cmbxBarangays);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "frmAssessmentPosting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Payments > Assessment Posting";
            this.Load += new System.EventHandler(this.frmAssessmentPosting_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.ComponentModel.BackgroundWorker bgwLoadAsessmentPosts;
        private System.Windows.Forms.ToolStripProgressBar progressBarLoadRecords;
        private System.Windows.Forms.Label label2;
    }
}