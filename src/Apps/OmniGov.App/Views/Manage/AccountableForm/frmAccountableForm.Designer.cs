
namespace OmniGov.App.Views.Manage.AccountableForm
{
    partial class frmAccountableForm
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
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            dgAccountableForm = new System.Windows.Forms.DataGridView();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            dgfacevalue = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAddFV = new System.Windows.Forms.ToolStripButton();
            btnEditFV = new System.Windows.Forms.ToolStripButton();
            btnDeleteFV = new System.Windows.Forms.ToolStripButton();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAccountableForm).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgfacevalue).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(944, 35);
            toolStrip.TabIndex = 7;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Enabled = false;
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
            btnDelete.Enabled = false;
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4 });
            statusStrip.Location = new System.Drawing.Point(0, 390);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(944, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 8;
            statusStrip.Text = "statusStrip1";
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
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(866, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(944, 355);
            splitContainer1.SplitterDistance = 586;
            splitContainer1.TabIndex = 27;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            groupBox1.Location = new System.Drawing.Point(4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(578, 347);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Forms";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgAccountableForm);
            panel1.Controls.Add(pbLoadRecords);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel1.Location = new System.Drawing.Point(3, 19);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(572, 325);
            panel1.TabIndex = 25;
            // 
            // dgAccountableForm
            // 
            dgAccountableForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAccountableForm.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAccountableForm.Location = new System.Drawing.Point(4, 9);
            dgAccountableForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgAccountableForm.Name = "dgAccountableForm";
            dgAccountableForm.RowHeadersWidth = 51;
            dgAccountableForm.RowTemplate.Height = 29;
            dgAccountableForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgAccountableForm.Size = new System.Drawing.Size(564, 312);
            dgAccountableForm.TabIndex = 10;
            dgAccountableForm.SelectionChanged += dgAccountableForm_SelectionChanged;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(564, 5);
            pbLoadRecords.TabIndex = 27;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel2);
            groupBox2.Controls.Add(toolStrip1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            groupBox2.Location = new System.Drawing.Point(4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(346, 347);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Face Values";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgfacevalue);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.Location = new System.Drawing.Point(3, 44);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(340, 300);
            panel2.TabIndex = 0;
            // 
            // dgfacevalue
            // 
            dgfacevalue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgfacevalue.Dock = System.Windows.Forms.DockStyle.Fill;
            dgfacevalue.Location = new System.Drawing.Point(4, 4);
            dgfacevalue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgfacevalue.Name = "dgfacevalue";
            dgfacevalue.RowHeadersWidth = 51;
            dgfacevalue.RowTemplate.Height = 29;
            dgfacevalue.Size = new System.Drawing.Size(332, 292);
            dgfacevalue.TabIndex = 1;
            dgfacevalue.SelectionChanged += dgfacevalue_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAddFV, btnEditFV, btnDeleteFV });
            toolStrip1.Location = new System.Drawing.Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(340, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAddFV
            // 
            btnAddFV.Image = Properties.Resources.symbol_add_14px;
            btnAddFV.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddFV.Name = "btnAddFV";
            btnAddFV.Size = new System.Drawing.Size(58, 22);
            btnAddFV.Text = "Add...";
            btnAddFV.Click += btnAddFV_Click;
            // 
            // btnEditFV
            // 
            btnEditFV.Image = Properties.Resources.tool_pencil_filled_16px;
            btnEditFV.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEditFV.Name = "btnEditFV";
            btnEditFV.Size = new System.Drawing.Size(56, 22);
            btnEditFV.Text = "Edit...";
            btnEditFV.Click += btnEditFV_Click;
            // 
            // btnDeleteFV
            // 
            btnDeleteFV.Image = Properties.Resources.waste_bin_filled_16px;
            btnDeleteFV.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDeleteFV.Name = "btnDeleteFV";
            btnDeleteFV.Size = new System.Drawing.Size(60, 22);
            btnDeleteFV.Text = "Delete";
            btnDeleteFV.Click += btnDeleteFV_Click;
            // 
            // frmAccountableForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(944, 412);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAccountableForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Accountable Forms";
            Load += frmAccountable_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAccountableForm).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgfacevalue).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgAccountableForm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgfacevalue;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddFV;
        private System.Windows.Forms.ToolStripButton btnEditFV;
        private System.Windows.Forms.ToolStripButton btnDeleteFV;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
    }
}
