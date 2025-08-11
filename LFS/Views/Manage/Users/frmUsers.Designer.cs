
namespace LFS.Views.Manage.Users
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
            tabControl1 = new LFS.CustomTools.CustomTabControl();
            tbPgUsrAdd = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            ucUsers1 = new ucUsers();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBck = new System.Windows.Forms.ToolStripButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tbPgUsrLst.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsers).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tbPgUsrAdd.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip2.SuspendLayout();
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
            tbPgUsrLst.Size = new System.Drawing.Size(730, 406);
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
            panel1.Size = new System.Drawing.Size(730, 319);
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
            dgUsers.Size = new System.Drawing.Size(722, 306);
            dgUsers.TabIndex = 7;
            dgUsers.SelectionChanged += dgUsers_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(722, 5);
            progressBar1.TabIndex = 19;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel5, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 384);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(730, 22);
            statusStrip1.TabIndex = 19;
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(476, 17);
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
            // panel2
            // 
            panel2.Controls.Add(cmbxFilter);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(730, 30);
            panel2.TabIndex = 17;
            // 
            // cmbxFilter
            // 
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
            toolStrip1.Size = new System.Drawing.Size(730, 35);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.button_rounded_add_20px;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(53, 24);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = Properties.Resources.button_rounded_edit_20px;
            btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(51, 24);
            btnEdit.Text = "Edit";
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
            tabControl1.Controls.Add(tbPgUsrAdd);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(738, 434);
            tabControl1.TabIndex = 21;
            // 
            // tbPgUsrAdd
            // 
            tbPgUsrAdd.Controls.Add(panel3);
            tbPgUsrAdd.Controls.Add(toolStrip2);
            tbPgUsrAdd.Location = new System.Drawing.Point(4, 24);
            tbPgUsrAdd.Name = "tbPgUsrAdd";
            tbPgUsrAdd.Size = new System.Drawing.Size(730, 406);
            tbPgUsrAdd.TabIndex = 2;
            tbPgUsrAdd.Text = "tbPgUsrAdd";
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(ucUsers1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 35);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            panel3.Size = new System.Drawing.Size(730, 371);
            panel3.TabIndex = 24;
            // 
            // ucUsers1
            // 
            ucUsers1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            ucUsers1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ucUsers1.Location = new System.Drawing.Point(209, 22);
            ucUsers1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ucUsers1.Name = "ucUsers1";
            ucUsers1.Size = new System.Drawing.Size(312, 342);
            ucUsers1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnBck, toolStripLabel1 });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(730, 35);
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlStrpBtnBck
            // 
            tlStrpBtnBck.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBck.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnBck.Name = "tlStrpBtnBck";
            tlStrpBtnBck.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnBck.Text = "Back";
            tlStrpBtnBck.Click += tlStrpBtnBck_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(74, 24);
            toolStripLabel1.Text = "Add User";
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(738, 434);
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
            tbPgUsrAdd.ResumeLayout(false);
            tbPgUsrAdd.PerformLayout();
            panel3.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
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
        private LFS.CustomTools.CustomTabControl tabControl1;
        private System.Windows.Forms.TabPage tbPgUsrAdd;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBck;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel3;
        private ucUsers ucUsers1;
    }
}