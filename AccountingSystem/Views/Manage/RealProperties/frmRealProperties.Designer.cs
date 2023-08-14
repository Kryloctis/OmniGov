namespace AccountingSystem.Views.Manage.RealProperties
{
    partial class frmRealProperties
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
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            panel1 = new System.Windows.Forms.Panel();
            dgRealProperties = new System.Windows.Forms.DataGridView();
            cbxShowCanclled = new System.Windows.Forms.CheckBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            panel2 = new System.Windows.Forms.Panel();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            toolStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRealProperties).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            toolStrip.Size = new System.Drawing.Size(1016, 50);
            toolStrip.TabIndex = 8;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(39, 39);
            btnAdd.Text = "&Add..";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.ToolTipText = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(37, 39);
            btnEdit.Text = "&Edit..";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 39);
            btnDelete.Text = "&Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgRealProperties);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 78);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(1016, 484);
            panel1.TabIndex = 12;
            // 
            // dgRealProperties
            // 
            dgRealProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRealProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgRealProperties.Location = new System.Drawing.Point(4, 4);
            dgRealProperties.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgRealProperties.Name = "dgRealProperties";
            dgRealProperties.RowHeadersWidth = 51;
            dgRealProperties.RowTemplate.Height = 29;
            dgRealProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgRealProperties.Size = new System.Drawing.Size(1008, 476);
            dgRealProperties.TabIndex = 9;
            dgRealProperties.SelectionChanged += dgRealProperties_SelectionChanged;
            // 
            // cbxShowCanclled
            // 
            cbxShowCanclled.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbxShowCanclled.AutoSize = true;
            cbxShowCanclled.Location = new System.Drawing.Point(905, 4);
            cbxShowCanclled.Name = "cbxShowCanclled";
            cbxShowCanclled.Size = new System.Drawing.Size(108, 19);
            cbxShowCanclled.TabIndex = 10;
            cbxShowCanclled.Text = "Show cancelled";
            cbxShowCanclled.UseVisualStyleBackColor = true;
            cbxShowCanclled.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelRecordCount, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabelCreatedAt, toolStripStatusLabel5, toolStripStatusLabel6, toolStripStatusLabelUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 562);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(1016, 22);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            toolStripStatusLabel1.Text = "Records: ";
            // 
            // toolStripStatusLabelRecordCount
            // 
            toolStripStatusLabelRecordCount.Name = "toolStripStatusLabelRecordCount";
            toolStripStatusLabelRecordCount.Size = new System.Drawing.Size(13, 17);
            toolStripStatusLabelRecordCount.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(761, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            toolStripStatusLabel3.Text = "Created at: ";
            // 
            // toolStripStatusLabelCreatedAt
            // 
            toolStripStatusLabelCreatedAt.Name = "toolStripStatusLabelCreatedAt";
            toolStripStatusLabelCreatedAt.Size = new System.Drawing.Size(12, 17);
            toolStripStatusLabelCreatedAt.Text = "-";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(71, 17);
            toolStripStatusLabel6.Text = "Updated at: ";
            // 
            // toolStripStatusLabelUpdatedAt
            // 
            toolStripStatusLabelUpdatedAt.Name = "toolStripStatusLabelUpdatedAt";
            toolStripStatusLabelUpdatedAt.Size = new System.Drawing.Size(12, 17);
            toolStripStatusLabelUpdatedAt.Text = "-";
            // 
            // panel2
            // 
            panel2.Controls.Add(pbLoadRecords);
            panel2.Controls.Add(cbxShowCanclled);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1016, 28);
            panel2.TabIndex = 11;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Bottom;
            pbLoadRecords.Location = new System.Drawing.Point(0, 23);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(1016, 5);
            pbLoadRecords.TabIndex = 24;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(729, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.TabIndex = 15;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Location = new System.Drawing.Point(935, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(75, 23);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmRealProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1016, 584);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(toolStrip);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmRealProperties";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Real Properties";
            Load += frmRealProperties_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRealProperties).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgRealProperties;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdatedAt;
        private System.Windows.Forms.CheckBox cbxShowCanclled;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}