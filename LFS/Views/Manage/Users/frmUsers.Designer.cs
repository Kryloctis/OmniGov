using OmniGov.App.Views.Manage.Users;

namespace OmniGov.App.Views.Manage.Users
{
    partial class frmUsers
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
            tbPgUsrLst = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            dgUsers = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            panel2 = new System.Windows.Forms.Panel();
            cmbxFilter = new System.Windows.Forms.ComboBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            searchTstrpBtn = new System.Windows.Forms.ToolStripButton();
            searchTstrpTxt = new System.Windows.Forms.ToolStripTextBox();
            miniToolStrip = new System.Windows.Forms.ToolStrip();
            tabControl1 = new OmniGov.App.CustomTools.CustomTabControl();
            tbPgCrud = new System.Windows.Forms.TabPage();
            ucUsers1 = new ucUsers();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnSave = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnBack = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBck = new System.Windows.Forms.ToolStripButton();
            panel3 = new System.Windows.Forms.Panel();
            tbPgUsrLst.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsers).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tbPgCrud.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            panel3.SuspendLayout();
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
            // tbPgUsrLst
            // 
            tbPgUsrLst.BackColor = System.Drawing.SystemColors.Control;
            tbPgUsrLst.Controls.Add(panel1);
            tbPgUsrLst.Controls.Add(statusStrip1);
            tbPgUsrLst.Controls.Add(panel2);
            tbPgUsrLst.Controls.Add(toolStrip1);
            tbPgUsrLst.Location = new System.Drawing.Point(4, 24);
            tbPgUsrLst.Name = "tbPgUsrLst";
            tbPgUsrLst.Size = new System.Drawing.Size(676, 463);
            tbPgUsrLst.TabIndex = 1;
            tbPgUsrLst.Text = "tbPgUsrLst";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgUsers);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(676, 376);
            panel1.TabIndex = 20;
            // 
            // dgUsers
            // 
            dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgUsers.Location = new System.Drawing.Point(4, 9);
            dgUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgUsers.Name = "dgUsers";
            dgUsers.RowHeadersWidth = 51;
            dgUsers.RowTemplate.Height = 29;
            dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgUsers.Size = new System.Drawing.Size(668, 363);
            dgUsers.TabIndex = 7;
            dgUsers.SelectionChanged += dgUsers_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(668, 5);
            progressBar1.TabIndex = 19;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel5, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 441);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(676, 22);
            statusStrip1.TabIndex = 19;
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
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(422, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel2.Text = "Created at:";
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(17, 17);
            lblCreatedAt.Text = "--";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            toolStripStatusLabel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel3.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(17, 17);
            lblUpdatedAt.Text = "--";
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxFilter);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(676, 30);
            panel2.TabIndex = 17;
            // 
            // cmbxFilter
            // 
            cmbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFilter.FormattingEnabled = true;
            cmbxFilter.Location = new System.Drawing.Point(3, 3);
            cmbxFilter.Name = "cmbxFilter";
            cmbxFilter.Size = new System.Drawing.Size(121, 23);
            cmbxFilter.TabIndex = 0;
            cmbxFilter.SelectionChangeCommitted += cmbxFilter_SelectionChangeCommitted;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, searchTstrpBtn, searchTstrpTxt });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(676, 35);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(65, 24);
            btnAdd.Text = "Create";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(69, 24);
            btnEdit.Text = "Update";
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
            // searchTstrpBtn
            // 
            searchTstrpBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            searchTstrpBtn.Image = Properties.Resources.find_20px;
            searchTstrpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            searchTstrpBtn.Name = "searchTstrpBtn";
            searchTstrpBtn.Size = new System.Drawing.Size(66, 24);
            searchTstrpBtn.Text = "Search";
            searchTstrpBtn.Click += searchTstrpBtn_Click;
            // 
            // searchTstrpTxt
            // 
            searchTstrpTxt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            searchTstrpTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            searchTstrpTxt.Name = "searchTstrpTxt";
            searchTstrpTxt.Size = new System.Drawing.Size(200, 27);
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "New item selection";
            miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            miniToolStrip.AutoSize = false;
            miniToolStrip.BackColor = System.Drawing.SystemColors.Control;
            miniToolStrip.CanOverflow = false;
            miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            miniToolStrip.Location = new System.Drawing.Point(190, 8);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Padding = new System.Windows.Forms.Padding(4);
            miniToolStrip.Size = new System.Drawing.Size(923, 35);
            miniToolStrip.TabIndex = 13;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbPgUsrLst);
            tabControl1.Controls.Add(tbPgCrud);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(684, 491);
            tabControl1.TabIndex = 21;
            // 
            // tbPgCrud
            // 
            tbPgCrud.Controls.Add(panel3);
            tbPgCrud.Controls.Add(toolStrip2);
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Padding = new System.Windows.Forms.Padding(4);
            tbPgCrud.Size = new System.Drawing.Size(676, 463);
            tbPgCrud.TabIndex = 2;
            tbPgCrud.Text = "tbPgCrud";
            // 
            // ucUsers1
            // 
            ucUsers1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ucUsers1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucUsers1.Location = new System.Drawing.Point(100, 50);
            ucUsers1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ucUsers1.Name = "ucUsers1";
            ucUsers1.Size = new System.Drawing.Size(468, 324);
            ucUsers1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(100, 374);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(468, 30);
            flowLayoutPanel1.TabIndex = 26;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(345, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save (Ctrl + S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(219, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(120, 23);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(93, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(120, 23);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblTitle.Location = new System.Drawing.Point(100, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new System.Windows.Forms.Padding(4);
            lblTitle.Size = new System.Drawing.Size(468, 50);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnBck });
            toolStrip2.Location = new System.Drawing.Point(4, 4);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(668, 31);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlStrpBtnBck
            // 
            tlStrpBtnBck.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBck.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnBck.Name = "tlStrpBtnBck";
            tlStrpBtnBck.Size = new System.Drawing.Size(52, 20);
            tlStrpBtnBck.Text = "Back";
            tlStrpBtnBck.Click += tlStrpBtnBck_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(ucUsers1);
            panel3.Controls.Add(lblTitle);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 35);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(100, 0, 100, 20);
            panel3.Size = new System.Drawing.Size(668, 424);
            panel3.TabIndex = 27;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(684, 491);
            Controls.Add(tabControl1);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmUsers";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Users ";
            Load += frmUsers_Load;
            tbPgUsrLst.ResumeLayout(false);
            tbPgUsrLst.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgUsers).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tbPgCrud.ResumeLayout(false);
            tbPgCrud.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tbPgUsrLst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxFilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton searchTstrpBtn;
        private System.Windows.Forms.ToolStripTextBox searchTstrpTxt;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private OmniGov.App.CustomTools.CustomTabControl tabControl1;
        private System.Windows.Forms.TabPage tbPgCrud;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBck;
        private ucUsers ucUsers1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel3;
    }
}
