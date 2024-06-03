using AccountingSystem.Views.Reports.Rcd;
namespace AccountingSystem.Views.Reports.Rcd
{
    partial class frmRcd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnPrint = new System.Windows.Forms.ToolStripButton();
            tabPageForm = new System.Windows.Forms.TabPage();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnBack = new System.Windows.Forms.ToolStripButton();
            tabPagePrint = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            ucRcdReport1 = new ucRcdReport();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel3 = new System.Windows.Forms.Panel();
            statusStrip3 = new System.Windows.Forms.StatusStrip();
            panel4 = new System.Windows.Forms.Panel();
            btnSave = new System.Windows.Forms.Button();
            ucRcd1 = new ucRcd();
            tabControl1.SuspendLayout();
            tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabPageForm.SuspendLayout();
            toolStrip2.SuspendLayout();
            tabPagePrint.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip3.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageList);
            tabControl1.Controls.Add(tabPageForm);
            tabControl1.Controls.Add(tabPagePrint);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.ItemSize = new System.Drawing.Size(93, 20);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(840, 428);
            tabControl1.TabIndex = 8;
            // 
            // tabPageList
            // 
            tabPageList.Controls.Add(dataGridView1);
            tabPageList.Controls.Add(statusStrip1);
            tabPageList.Controls.Add(progressBar1);
            tabPageList.Controls.Add(panel2);
            tabPageList.Controls.Add(toolStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 24);
            tabPageList.Margin = new System.Windows.Forms.Padding(0);
            tabPageList.Name = "tabPageList";
            tabPageList.Size = new System.Drawing.Size(832, 400);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "List";
            tabPageList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 70);
            dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(832, 308);
            dataGridView1.TabIndex = 1;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRowCount });
            statusStrip1.Location = new System.Drawing.Point(0, 378);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(832, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRowCount
            // 
            lblRowCount.Name = "lblRowCount";
            lblRowCount.Size = new System.Drawing.Size(13, 17);
            lblRowCount.Text = "0";
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 65);
            progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(832, 5);
            progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowFilter);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(832, 30);
            panel2.TabIndex = 3;
            // 
            // cmbxRowFilter
            // 
            cmbxRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxRowFilter.FormattingEnabled = true;
            cmbxRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxRowFilter.Name = "cmbxRowFilter";
            cmbxRowFilter.Size = new System.Drawing.Size(121, 23);
            cmbxRowFilter.TabIndex = 1;
            cmbxRowFilter.SelectionChangeCommitted += cmbxRowFilter_SelectionChangeCommitted;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMM dd, yyyy";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new System.Drawing.Point(130, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(116, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch, toolStripSeparator1, btnPrint });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(832, 35);
            toolStrip1.TabIndex = 2;
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
            txtSearch.Size = new System.Drawing.Size(150, 27);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPrint
            // 
            btnPrint.Image = Properties.Resources.printer_filled_20px;
            btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(56, 24);
            btnPrint.Text = "Print";
            btnPrint.Click += btnPrint_Click;
            // 
            // tabPageForm
            // 
            tabPageForm.Controls.Add(panel3);
            tabPageForm.Controls.Add(statusStrip3);
            tabPageForm.Controls.Add(toolStrip2);
            tabPageForm.Location = new System.Drawing.Point(4, 24);
            tabPageForm.Margin = new System.Windows.Forms.Padding(0);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Size = new System.Drawing.Size(832, 400);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "Form";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnBack });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(832, 35);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnBack
            // 
            btnBack.Image = Properties.Resources.arrow_left_20px;
            btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(56, 24);
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // tabPagePrint
            // 
            tabPagePrint.Controls.Add(panel1);
            tabPagePrint.Controls.Add(toolStrip3);
            tabPagePrint.Location = new System.Drawing.Point(4, 24);
            tabPagePrint.Margin = new System.Windows.Forms.Padding(0);
            tabPagePrint.Name = "tabPagePrint";
            tabPagePrint.Size = new System.Drawing.Size(832, 400);
            tabPagePrint.TabIndex = 2;
            tabPagePrint.Text = "tabPagePrint";
            tabPagePrint.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucRcdReport1);
            panel1.Controls.Add(statusStrip2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 35);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(832, 365);
            panel1.TabIndex = 1;
            // 
            // ucRcdReport1
            // 
            ucRcdReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRcdReport1.Location = new System.Drawing.Point(0, 0);
            ucRcdReport1.Name = "ucRcdReport1";
            ucRcdReport1.Size = new System.Drawing.Size(832, 343);
            ucRcdReport1.TabIndex = 3;
            // 
            // statusStrip2
            // 
            statusStrip2.Location = new System.Drawing.Point(0, 343);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(832, 22);
            statusStrip2.TabIndex = 2;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = System.Drawing.Color.Transparent;
            toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton8 });
            toolStrip3.Location = new System.Drawing.Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new System.Windows.Forms.Padding(4);
            toolStrip3.Size = new System.Drawing.Size(832, 35);
            toolStrip3.TabIndex = 0;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton8
            // 
            toolStripButton8.Image = Properties.Resources.arrow_left_20px;
            toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new System.Drawing.Size(56, 24);
            toolStripButton8.Text = "Back";
            toolStripButton8.Click += toolStripButton8_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(ucRcd1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 35);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(832, 343);
            panel3.TabIndex = 1;
            // 
            // statusStrip3
            // 
            statusStrip3.Location = new System.Drawing.Point(0, 378);
            statusStrip3.Name = "statusStrip3";
            statusStrip3.Size = new System.Drawing.Size(832, 22);
            statusStrip3.TabIndex = 2;
            statusStrip3.Text = "statusStrip3";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnSave);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(4, 469);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(4);
            panel4.Size = new System.Drawing.Size(807, 77);
            panel4.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(650, 7);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(150, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save (Ctrl + S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ucRcd1
            // 
            ucRcd1.Dock = System.Windows.Forms.DockStyle.Top;
            ucRcd1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucRcd1.Location = new System.Drawing.Point(4, 4);
            ucRcd1.Margin = new System.Windows.Forms.Padding(0);
            ucRcd1.Name = "ucRcd1";
            ucRcd1.Size = new System.Drawing.Size(807, 465);
            ucRcd1.TabIndex = 14;
            // 
            // frmRcd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(840, 428);
            Controls.Add(tabControl1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(856, 467);
            Name = "frmRcd";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Reports > Report of Collections and Deposits";
            Load += frmRcd_Load;
            KeyDown += frmRcd_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageForm.ResumeLayout(false);
            tabPageForm.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tabPagePrint.ResumeLayout(false);
            tabPagePrint.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.TabPage tabPagePrint;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRowCount;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private ucRcdReport ucRcdReport1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
        private ucRcd ucRcd1;
        private System.Windows.Forms.StatusStrip statusStrip3;
    }
}
