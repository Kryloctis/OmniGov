namespace LFS.Views.Transactions.Assessment
{
    partial class frmRptDelinquencyNotices
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
            tabPageMain = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowLimit = new System.Windows.Forms.ComboBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            tabPageForm = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            btnSave = new System.Windows.Forms.Button();
            ucDelinquenyNotice1 = new ucDelinquenyNotice();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPageMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabPageForm.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControl1.Controls.Add(tabPageMain);
            tabControl1.Controls.Add(tabPageForm);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(769, 428);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageMain
            // 
            tabPageMain.Controls.Add(panel1);
            tabPageMain.Controls.Add(panel2);
            tabPageMain.Controls.Add(toolStrip1);
            tabPageMain.Controls.Add(statusStrip1);
            tabPageMain.Location = new System.Drawing.Point(4, 27);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Size = new System.Drawing.Size(761, 397);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "tabPageMain";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 65);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(761, 310);
            panel1.TabIndex = 29;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(4, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(753, 297);
            dataGridView1.TabIndex = 1;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(753, 5);
            progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowLimit);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(761, 30);
            panel2.TabIndex = 28;
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
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSearch, txtSearch, btnAdd, btnEdit, btnDelete });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(761, 35);
            toolStrip1.TabIndex = 27;
            toolStrip1.Text = "toolStrip1";
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
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel2, toolStripStatusLabel3, lblCreatedAt, toolStripStatusLabel5, toolStripStatusLabel6, lblUpdatedAt });
            statusStrip1.Location = new System.Drawing.Point(0, 375);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(761, 22);
            statusStrip1.TabIndex = 30;
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
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(505, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(64, 17);
            toolStripStatusLabel3.Text = "Created at:";
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
            toolStripStatusLabel5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel5.Text = "|";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel6.Text = "Updated at:";
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(17, 17);
            lblUpdatedAt.Text = "--";
            // 
            // tabPageForm
            // 
            tabPageForm.Controls.Add(panel3);
            tabPageForm.Controls.Add(toolStrip2);
            tabPageForm.Controls.Add(statusStrip2);
            tabPageForm.Location = new System.Drawing.Point(4, 27);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Size = new System.Drawing.Size(761, 397);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "tabPageForm";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(ucDelinquenyNotice1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 35);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(761, 340);
            panel3.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnSave);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(4, 515);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(4);
            panel4.Size = new System.Drawing.Size(736, 50);
            panel4.TabIndex = 36;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(579, 7);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(150, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save (Ctrl + S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ucDelinquenyNotice1
            // 
            ucDelinquenyNotice1.Dock = System.Windows.Forms.DockStyle.Top;
            ucDelinquenyNotice1.Location = new System.Drawing.Point(4, 4);
            ucDelinquenyNotice1.Name = "ucDelinquenyNotice1";
            ucDelinquenyNotice1.Size = new System.Drawing.Size(736, 511);
            ucDelinquenyNotice1.TabIndex = 35;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton2 });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(761, 35);
            toolStrip2.TabIndex = 28;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = Properties.Resources.arrow_left_20px;
            toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new System.Drawing.Size(56, 24);
            toolStripButton2.Text = "Back";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // statusStrip2
            // 
            statusStrip2.Location = new System.Drawing.Point(0, 375);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(761, 22);
            statusStrip2.TabIndex = 30;
            statusStrip2.Text = "statusStrip2";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmRptDelinquencyNotices
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(769, 428);
            Controls.Add(tabControl1);
            KeyPreview = true;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(785, 467);
            Name = "frmRptDelinquencyNotices";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Delinquency Notices";
            Load += frnRptAssessment_Load;
            KeyDown += frmRptDelinquencyNotices_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageMain.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabPageForm.ResumeLayout(false);
            tabPageForm.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowLimit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private ucDelinquenyNotice ucDelinquenyNotice1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
    }
}