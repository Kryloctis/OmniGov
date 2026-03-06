using OmniGov.App.Views.Manage.Roles;

namespace OmniGov.App.Views.Manage.Roles
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            dgRoles = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            rchTxtBxPrivileges = new System.Windows.Forms.RichTextBox();
            label1 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            panel1 = new System.Windows.Forms.Panel();
            btnShowSidePanel = new System.Windows.Forms.Button();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            customTabControl1 = new OmniGov.App.CustomTools.CustomTabControl();
            tbPgList = new System.Windows.Forms.TabPage();
            tbPgCrud = new System.Windows.Forms.TabPage();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnSave = new System.Windows.Forms.Button();
            ucRoles1 = new ucRoles();
            lblTitle = new System.Windows.Forms.Label();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBack = new System.Windows.Forms.ToolStripButton();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRoles).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            customTabControl1.SuspendLayout();
            tbPgList.SuspendLayout();
            tbPgCrud.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip3.SuspendLayout();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel3, toolStripStatusLabel4, lblCreatedAt, toolStripStatusLabel6, toolStripStatusLabel7, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 441);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(676, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(420, 17);
            toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel4.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(17, 17);
            lblCreatedAt.Text = "--";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel6.Text = "|";
            toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel7
            // 
            toolStripStatusLabel7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            toolStripStatusLabel7.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel7.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(17, 17);
            lblUpdatedAt.Text = "--";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 65);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgRoles);
            splitContainer1.Panel1.Controls.Add(progressBar1);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rchTxtBxPrivileges);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4);
            splitContainer1.Size = new System.Drawing.Size(676, 376);
            splitContainer1.SplitterDistance = 359;
            splitContainer1.TabIndex = 12;
            // 
            // dgRoles
            // 
            dgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            dgRoles.Location = new System.Drawing.Point(4, 9);
            dgRoles.Name = "dgRoles";
            dgRoles.RowHeadersWidth = 51;
            dgRoles.RowTemplate.Height = 29;
            dgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgRoles.Size = new System.Drawing.Size(351, 363);
            dgRoles.TabIndex = 8;
            dgRoles.SelectionChanged += dgRoles_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(351, 5);
            progressBar1.TabIndex = 10;
            // 
            // rchTxtBxPrivileges
            // 
            rchTxtBxPrivileges.BackColor = System.Drawing.SystemColors.Control;
            rchTxtBxPrivileges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rchTxtBxPrivileges.Dock = System.Windows.Forms.DockStyle.Fill;
            rchTxtBxPrivileges.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            rchTxtBxPrivileges.HideSelection = false;
            rchTxtBxPrivileges.Location = new System.Drawing.Point(4, 34);
            rchTxtBxPrivileges.Name = "rchTxtBxPrivileges";
            rchTxtBxPrivileges.ReadOnly = true;
            rchTxtBxPrivileges.Size = new System.Drawing.Size(305, 338);
            rchTxtBxPrivileges.TabIndex = 4;
            rchTxtBxPrivileges.Text = "- No Privileges";
            rchTxtBxPrivileges.WordWrap = false;
            // 
            // label1
            // 
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(4, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(305, 30);
            label1.TabIndex = 3;
            label1.Text = "Privileges";
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
            toolStrip1.Size = new System.Drawing.Size(676, 35);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_24px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(65, 24);
            btnAdd.Text = "Create";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_24px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(69, 24);
            btnEdit.Text = "Update";
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
            // panel1
            // 
            panel1.Controls.Add(btnShowSidePanel);
            panel1.Controls.Add(cmbxRowLimit);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(676, 30);
            panel1.TabIndex = 16;
            // 
            // btnShowSidePanel
            // 
            btnShowSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            btnShowSidePanel.FlatAppearance.BorderSize = 0;
            btnShowSidePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnShowSidePanel.Location = new System.Drawing.Point(646, 0);
            btnShowSidePanel.Name = "btnShowSidePanel";
            btnShowSidePanel.Size = new System.Drawing.Size(30, 30);
            btnShowSidePanel.TabIndex = 1;
            btnShowSidePanel.Text = "?";
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
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgList);
            customTabControl1.Controls.Add(tbPgCrud);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.Location = new System.Drawing.Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(684, 491);
            customTabControl1.TabIndex = 17;
            // 
            // tbPgList
            // 
            tbPgList.Controls.Add(splitContainer1);
            tbPgList.Controls.Add(panel1);
            tbPgList.Controls.Add(statusStrip1);
            tbPgList.Controls.Add(toolStrip1);
            tbPgList.Location = new System.Drawing.Point(4, 24);
            tbPgList.Name = "tbPgList";
            tbPgList.Size = new System.Drawing.Size(676, 463);
            tbPgList.TabIndex = 0;
            tbPgList.Text = "tbPgList";
            // 
            // tbPgCrud
            // 
            tbPgCrud.BackColor = System.Drawing.SystemColors.Control;
            tbPgCrud.Controls.Add(flowLayoutPanel1);
            tbPgCrud.Controls.Add(ucRoles1);
            tbPgCrud.Controls.Add(lblTitle);
            tbPgCrud.Controls.Add(toolStrip3);
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new System.Drawing.Size(676, 463);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 385);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 110, 20);
            flowLayoutPanel1.Size = new System.Drawing.Size(676, 52);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(443, 23);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save (Ctrl + S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ucRoles1
            // 
            ucRoles1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucRoles1.Dock = System.Windows.Forms.DockStyle.Top;
            ucRoles1.Location = new System.Drawing.Point(0, 81);
            ucRoles1.Name = "ucRoles1";
            ucRoles1.Padding = new System.Windows.Forms.Padding(100, 20, 100, 4);
            ucRoles1.Size = new System.Drawing.Size(676, 304);
            ucRoles1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F);
            lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblTitle.Location = new System.Drawing.Point(0, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new System.Windows.Forms.Padding(4);
            lblTitle.Size = new System.Drawing.Size(676, 50);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnBack });
            toolStrip3.Location = new System.Drawing.Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new System.Windows.Forms.Padding(4, 4, 110, 4);
            toolStrip3.Size = new System.Drawing.Size(676, 31);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // tlStrpBtnBack
            // 
            tlStrpBtnBack.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnBack.Name = "tlStrpBtnBack";
            tlStrpBtnBack.Size = new System.Drawing.Size(52, 20);
            tlStrpBtnBack.Text = "Back";
            tlStrpBtnBack.Click += tlStrpBtnBack_Click;
            // 
            // frmRoles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(684, 491);
            Controls.Add(customTabControl1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmRoles";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Manage > Roles";
            Load += frmRoles_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgRoles).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            customTabControl1.ResumeLayout(false);
            tbPgList.ResumeLayout(false);
            tbPgList.PerformLayout();
            tbPgCrud.ResumeLayout(false);
            tbPgCrud.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgRoles;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowSidePanel;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.RichTextBox rchTxtBxPrivileges;
        private System.Windows.Forms.Label label1;
        private OmniGov.App.CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgList;
        private System.Windows.Forms.TabPage tbPgCrud;
        private ucRoles ucRoles1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
    }
}
