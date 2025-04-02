
namespace LFS.Views.Manage.AllotmentClasses
{
    partial class frmAllotmentClasses
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
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            panel1 = new System.Windows.Forms.Panel();
            dgAllotmentClasses = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAllotmentClasses).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(634, 35);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_20px;
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
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel5, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 389);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(634, 22);
            statusStrip1.SizingGrip = false;
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
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(383, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(17, 17);
            lblCreatedAt.Text = "--";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(17, 17);
            lblUpdatedAt.Text = "--";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgAllotmentClasses);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(634, 324);
            panel1.TabIndex = 6;
            // 
            // dgAllotmentClasses
            // 
            dgAllotmentClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAllotmentClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAllotmentClasses.Location = new System.Drawing.Point(4, 9);
            dgAllotmentClasses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgAllotmentClasses.Name = "dgAllotmentClasses";
            dgAllotmentClasses.RowHeadersWidth = 51;
            dgAllotmentClasses.RowTemplate.Height = 29;
            dgAllotmentClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgAllotmentClasses.Size = new System.Drawing.Size(626, 311);
            dgAllotmentClasses.TabIndex = 4;
            dgAllotmentClasses.SelectionChanged += dgAllotmentClasses_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(626, 5);
            progressBar1.TabIndex = 18;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowLimit);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(634, 30);
            panel2.TabIndex = 17;
            // 
            // cmbxRowLimit
            // 
            cmbxRowLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowLimit.FormattingEnabled = true;
            cmbxRowLimit.Location = new System.Drawing.Point(3, 3);
            cmbxRowLimit.Name = "cmbxRowLimit";
            cmbxRowLimit.Size = new System.Drawing.Size(120, 23);
            cmbxRowLimit.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmAllotmentClasses
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(634, 411);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(650, 450);
            Name = "frmAllotmentClasses";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Allotment Classes";
            Load += frmAllotmentClasses_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgAllotmentClasses).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgAllotmentClasses;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
    }
}