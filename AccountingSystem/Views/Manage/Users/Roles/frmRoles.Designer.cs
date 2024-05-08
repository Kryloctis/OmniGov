
namespace AccountingSystem.Views.Manage.Users.Roles
{
    partial class frmRoles
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
            searchTstripBtn = new System.Windows.Forms.ToolStripButton();
            searchTstripTxtbx = new System.Windows.Forms.ToolStripTextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            groupBox2 = new System.Windows.Forms.GroupBox();
            dgRoles = new System.Windows.Forms.DataGridView();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lstboxAuthorize = new System.Windows.Forms.ListBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRoles).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, searchTstripBtn, searchTstripTxtbx });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(911, 35);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_24px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(62, 24);
            btnAdd.Text = "Add...";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_24px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(60, 24);
            btnEdit.Text = "Edit...";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources.button_rounded_remove_24px;
            btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(64, 24);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // searchTstripBtn
            // 
            searchTstripBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            searchTstripBtn.Image = Properties.Resources.find_20px;
            searchTstripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            searchTstripBtn.Name = "searchTstripBtn";
            searchTstripBtn.Size = new System.Drawing.Size(66, 24);
            searchTstripBtn.Text = "Search";
            searchTstripBtn.Click += searchTstripBtn_Click;
            // 
            // searchTstripTxtbx
            // 
            searchTstripTxtbx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            searchTstripTxtbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchTstripTxtbx.Name = "searchTstripTxtbx";
            searchTstripTxtbx.Size = new System.Drawing.Size(200, 27);
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 440);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            statusStrip1.Size = new System.Drawing.Size(911, 22);
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(703, 17);
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
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
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
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 70);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(911, 370);
            splitContainer1.SplitterDistance = 594;
            splitContainer1.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgRoles);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Location = new System.Drawing.Point(4, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(586, 362);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "List";
            // 
            // dgRoles
            // 
            dgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            dgRoles.Location = new System.Drawing.Point(3, 19);
            dgRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgRoles.Name = "dgRoles";
            dgRoles.RowHeadersWidth = 51;
            dgRoles.RowTemplate.Height = 29;
            dgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgRoles.Size = new System.Drawing.Size(580, 340);
            dgRoles.TabIndex = 5;
            dgRoles.SelectionChanged += dgRoles_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstboxAuthorize);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(305, 362);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Access:";
            // 
            // lstboxAuthorize
            // 
            lstboxAuthorize.Dock = System.Windows.Forms.DockStyle.Fill;
            lstboxAuthorize.FormattingEnabled = true;
            lstboxAuthorize.ItemHeight = 15;
            lstboxAuthorize.Location = new System.Drawing.Point(3, 19);
            lstboxAuthorize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            lstboxAuthorize.Name = "lstboxAuthorize";
            lstboxAuthorize.Size = new System.Drawing.Size(299, 340);
            lstboxAuthorize.TabIndex = 7;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 65);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(911, 5);
            progressBar1.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbxRowLimit);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(911, 30);
            panel1.TabIndex = 10;
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
            // frmRoles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(911, 462);
            Controls.Add(splitContainer1);
            Controls.Add(progressBar1);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(927, 501);
            Name = "frmRoles";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Roles";
            Load += frmRoles_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRoles).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstboxAuthorize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.ToolStripButton searchTstripBtn;
        private System.Windows.Forms.ToolStripTextBox searchTstripTxtbx;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}