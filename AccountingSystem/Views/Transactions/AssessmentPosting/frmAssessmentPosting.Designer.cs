
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
            this.dgProperties = new System.Windows.Forms.DataGridView();
            this.btnPost = new System.Windows.Forms.Button();
            this.checkFilterCancelledProp = new System.Windows.Forms.CheckBox();
            this.btnManualPosting = new System.Windows.Forms.Button();
            this.cmbBarangays = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProperties
            // 
            this.dgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProperties.Location = new System.Drawing.Point(12, 72);
            this.dgProperties.Name = "dgProperties";
            this.dgProperties.RowTemplate.Height = 25;
            this.dgProperties.Size = new System.Drawing.Size(852, 387);
            this.dgProperties.TabIndex = 11;
            this.dgProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProperties_CellValueChanged);
            this.dgProperties.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgProperties_ColumnAdded);
            this.dgProperties.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgProperties_CurrentCellDirtyStateChanged);
            this.dgProperties.SelectionChanged += new System.EventHandler(this.dgProperties_SelectionChanged);
            // 
            // btnPost
            // 
            this.btnPost.Enabled = false;
            this.btnPost.Location = new System.Drawing.Point(12, 37);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(126, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post Selected";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // checkFilterCancelledProp
            // 
            this.checkFilterCancelledProp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkFilterCancelledProp.AutoSize = true;
            this.checkFilterCancelledProp.Location = new System.Drawing.Point(754, 41);
            this.checkFilterCancelledProp.Name = "checkFilterCancelledProp";
            this.checkFilterCancelledProp.Size = new System.Drawing.Size(110, 19);
            this.checkFilterCancelledProp.TabIndex = 13;
            this.checkFilterCancelledProp.Text = "Show Cancelled";
            this.checkFilterCancelledProp.UseVisualStyleBackColor = true;
            this.checkFilterCancelledProp.CheckedChanged += new System.EventHandler(this.checkFilterCancelledProp_CheckedChanged);
            // 
            // btnManualPosting
            // 
            this.btnManualPosting.Location = new System.Drawing.Point(12, 12);
            this.btnManualPosting.Name = "btnManualPosting";
            this.btnManualPosting.Size = new System.Drawing.Size(126, 23);
            this.btnManualPosting.TabIndex = 1;
            this.btnManualPosting.Text = "Manual Posting";
            this.btnManualPosting.UseVisualStyleBackColor = true;
            this.btnManualPosting.Click += new System.EventHandler(this.btnManualPosting_Click);
            // 
            // cmbBarangays
            // 
            this.cmbBarangays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBarangays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarangays.FormattingEnabled = true;
            this.cmbBarangays.Location = new System.Drawing.Point(507, 12);
            this.cmbBarangays.Name = "cmbBarangays";
            this.cmbBarangays.Size = new System.Drawing.Size(160, 23);
            this.cmbBarangays.TabIndex = 7;
            this.cmbBarangays.SelectionChangeCommitted += new System.EventHandler(this.cmbBarangays_SelectionChangeCommitted);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(673, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 23);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(16, 77);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(15, 14);
            this.checkAll.TabIndex = 14;
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            this.checkAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkAll_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudYear);
            this.panel1.Controls.Add(this.checkFilterCancelledProp);
            this.panel1.Controls.Add(this.btnManualPosting);
            this.panel1.Controls.Add(this.btnPost);
            this.panel1.Controls.Add(this.cmbBarangays);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 66);
            this.panel1.TabIndex = 9;
            // 
            // nudYear
            // 
            this.nudYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYear.Location = new System.Drawing.Point(381, 12);
            this.nudYear.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(120, 23);
            this.nudYear.TabIndex = 15;
            this.nudYear.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // frmAssessmentPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 471);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.dgProperties);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmAssessmentPosting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Payments > Assessment Posting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAssessmentPosting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProperties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProperties;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.ComboBox cmbBarangays;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox checkFilterCancelledProp;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Button btnManualPosting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudYear;
    }
}