
namespace AccountingSystem.Views.Manage.Users.List
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
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            dgUsers = new System.Windows.Forms.DataGridView();
            panel2 = new System.Windows.Forms.Panel();
            cmbxFilter = new System.Windows.Forms.ComboBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            searchTstrpBtn = new System.Windows.Forms.ToolStripButton();
            searchTstrpTxt = new System.Windows.Forms.ToolStripTextBox();
            tabPageForm = new System.Windows.Forms.TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPageList.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsers).BeginInit();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageList);
            tabControl1.Controls.Add(tabPageForm);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(911, 462);
            tabControl1.TabIndex = 0;
            // 
            // tabPageList
            // 
            tabPageList.Controls.Add(panel1);
            tabPageList.Controls.Add(panel2);
            tabPageList.Controls.Add(progressBar1);
            tabPageList.Controls.Add(statusStrip1);
            tabPageList.Controls.Add(toolStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 24);
            tabPageList.Margin = new System.Windows.Forms.Padding(0);
            tabPageList.Name = "tabPageList";
            tabPageList.Size = new System.Drawing.Size(903, 434);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "List";
            tabPageList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgUsers);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 70);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(903, 342);
            panel1.TabIndex = 14;
            // 
            // dgUsers
            // 
            dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgUsers.Location = new System.Drawing.Point(4, 4);
            dgUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgUsers.Name = "dgUsers";
            dgUsers.RowHeadersWidth = 51;
            dgUsers.RowTemplate.Height = 29;
            dgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgUsers.Size = new System.Drawing.Size(895, 334);
            dgUsers.TabIndex = 7;
            dgUsers.SelectionChanged += dgUsers_SelectionChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxFilter);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(903, 30);
            panel2.TabIndex = 16;
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
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 35);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(903, 5);
            progressBar1.TabIndex = 15;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, toolStripStatusLabel2, lblCreatedAt, toolStripStatusLabel3, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 412);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip1.Size = new System.Drawing.Size(903, 22);
            statusStrip1.TabIndex = 13;
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(693, 17);
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
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, searchTstrpBtn, searchTstrpTxt });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(903, 35);
            toolStrip1.TabIndex = 12;
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
            searchTstrpTxt.Size = new System.Drawing.Size(150, 27);
            // 
            // tabPageForm
            // 
            tabPageForm.Location = new System.Drawing.Point(4, 24);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Padding = new System.Windows.Forms.Padding(3);
            tabPageForm.Size = new System.Drawing.Size(903, 434);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "Form";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(911, 462);
            Controls.Add(tabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmUsers";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Settings > Users ";
            Load += frmUsers_Load;
            tabControl1.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgUsers).EndInit();
            panel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxFilter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgUsers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton searchTstrpBtn;
        private System.Windows.Forms.ToolStripTextBox searchTstrpTxt;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}