
namespace OmniGov.App.Views.Manage.TaxPayers
{
    partial class frmTaxpayers
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
            dgTaxpayers = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabelUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            chckBxInactiveTaxpayers = new System.Windows.Forms.CheckBox();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgTaxpayers);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 86);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(934, 403);
            panel1.TabIndex = 1;
            // 
            // dgTaxpayers
            // 
            dgTaxpayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTaxpayers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgTaxpayers.Location = new System.Drawing.Point(4, 4);
            dgTaxpayers.Name = "dgTaxpayers";
            dgTaxpayers.RowHeadersWidth = 51;
            dgTaxpayers.RowTemplate.Height = 25;
            dgTaxpayers.Size = new System.Drawing.Size(926, 395);
            dgTaxpayers.TabIndex = 1;
            dgTaxpayers.SelectionChanged += dgTaxpayers_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(934, 51);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(42, 40);
            btnAdd.Text = "Add...";
            btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(40, 40);
            btnEdit.Text = "Edit...";
            btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(44, 40);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(24, 40);
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 43);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelRecordCount, toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabelCreatedAt, toolStripStatusLabel5, toolStripStatusLabel6, toolStripStatusLabelUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 489);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(934, 22);
            statusStrip1.TabIndex = 7;
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
            toolStripStatusLabel2.Size = new System.Drawing.Size(679, 17);
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
            // chckBxInactiveTaxpayers
            // 
            chckBxInactiveTaxpayers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chckBxInactiveTaxpayers.AutoSize = true;
            chckBxInactiveTaxpayers.Location = new System.Drawing.Point(778, 5);
            chckBxInactiveTaxpayers.Name = "chckBxInactiveTaxpayers";
            chckBxInactiveTaxpayers.Size = new System.Drawing.Size(152, 19);
            chckBxInactiveTaxpayers.TabIndex = 0;
            chckBxInactiveTaxpayers.Text = "Show Inactive taxpayers";
            chckBxInactiveTaxpayers.UseVisualStyleBackColor = true;
            chckBxInactiveTaxpayers.CheckedChanged += chckBxInactiveTaxpayers_CheckedChanged;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(0, 81);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(934, 5);
            pbLoadRecords.TabIndex = 24;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowFilter);
            panel2.Controls.Add(chckBxInactiveTaxpayers);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 51);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(934, 30);
            panel2.TabIndex = 25;
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(120, 23);
            cmbxRowFilter.TabIndex = 1;
            cmbxRowFilter.SelectionChangeCommitted += cmbxRowFilter_SelectionChangeCommitted;
            // 
            // frmTaxpayers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(934, 511);
            Controls.Add(panel1);
            Controls.Add(pbLoadRecords);
            Controls.Add(panel2);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmTaxpayers";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Taxpayers";
            Load += frmTaxPayers_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgTaxpayers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdatedAt;
        private System.Windows.Forms.CheckBox chckBxInactiveTaxpayers;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
    }
}
