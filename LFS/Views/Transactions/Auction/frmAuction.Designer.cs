namespace LFS.Views.Transactions.Auction
{
    partial class frmAuction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageListOfAuction = new System.Windows.Forms.TabPage();
            dgAuctionList = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            dtpAuctionSchedule = new System.Windows.Forms.DateTimePicker();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnRptSchedules = new System.Windows.Forms.ToolStripButton();
            tabPageAuctionForm = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            btnSave = new System.Windows.Forms.Button();
            ucAuctionEvents2 = new ucAuctionEvents();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnBack = new System.Windows.Forms.ToolStripButton();
            tabPageListOfRptSchedule = new System.Windows.Forms.TabPage();
            dgRptSchedule = new System.Windows.Forms.DataGridView();
            statusStrip3 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar2 = new System.Windows.Forms.ProgressBar();
            panel6 = new System.Windows.Forms.Panel();
            cmbxSchedulePropertyRowFilter = new System.Windows.Forms.ComboBox();
            dtpRptSchedule = new System.Windows.Forms.DateTimePicker();
            toolStrip4 = new System.Windows.Forms.ToolStrip();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            btnAddScheduledProperty = new System.Windows.Forms.ToolStripButton();
            btnEditScheduledProperty = new System.Windows.Forms.ToolStripButton();
            btnDeleteScheduledProperty = new System.Windows.Forms.ToolStripButton();
            btnSearchRptSched = new System.Windows.Forms.ToolStripButton();
            toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            tabPageRptScheduleForm = new System.Windows.Forms.TabPage();
            panel5 = new System.Windows.Forms.Panel();
            btnSaveRptAuctionSchedule = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ucRptScheduling2 = new ucRptScheduling();
            toolStrip5 = new System.Windows.Forms.ToolStrip();
            toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPageListOfAuction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgAuctionList).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabPageAuctionForm.SuspendLayout();
            panel3.SuspendLayout();
            toolStrip2.SuspendLayout();
            tabPageListOfRptSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgRptSchedule).BeginInit();
            statusStrip3.SuspendLayout();
            panel6.SuspendLayout();
            toolStrip4.SuspendLayout();
            tabPageRptScheduleForm.SuspendLayout();
            panel5.SuspendLayout();
            toolStrip5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageListOfAuction);
            tabControl1.Controls.Add(tabPageAuctionForm);
            tabControl1.Controls.Add(tabPageListOfRptSchedule);
            tabControl1.Controls.Add(tabPageRptScheduleForm);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(769, 428);
            tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl1.TabIndex = 9;
            // 
            // tabPageListOfAuction
            // 
            tabPageListOfAuction.Controls.Add(dgAuctionList);
            tabPageListOfAuction.Controls.Add(statusStrip1);
            tabPageListOfAuction.Controls.Add(progressBar1);
            tabPageListOfAuction.Controls.Add(panel2);
            tabPageListOfAuction.Controls.Add(toolStrip1);
            tabPageListOfAuction.Location = new System.Drawing.Point(4, 5);
            tabPageListOfAuction.Margin = new System.Windows.Forms.Padding(0);
            tabPageListOfAuction.Name = "tabPageListOfAuction";
            tabPageListOfAuction.Size = new System.Drawing.Size(761, 419);
            tabPageListOfAuction.TabIndex = 0;
            tabPageListOfAuction.Text = "Auction";
            tabPageListOfAuction.UseVisualStyleBackColor = true;
            // 
            // dgAuctionList
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgAuctionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgAuctionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgAuctionList.DefaultCellStyle = dataGridViewCellStyle2;
            dgAuctionList.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAuctionList.Location = new System.Drawing.Point(0, 70);
            dgAuctionList.Margin = new System.Windows.Forms.Padding(0);
            dgAuctionList.Name = "dgAuctionList";
            dgAuctionList.RowTemplate.Height = 25;
            dgAuctionList.Size = new System.Drawing.Size(761, 327);
            dgAuctionList.TabIndex = 1;
            dgAuctionList.SelectionChanged += dgAuctionList_SelectionChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRowCount });
            statusStrip1.Location = new System.Drawing.Point(0, 397);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(761, 22);
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
            progressBar1.Size = new System.Drawing.Size(761, 5);
            progressBar1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxRowFilter);
            panel2.Controls.Add(dtpAuctionSchedule);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(761, 30);
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
            // dtpAuctionSchedule
            // 
            dtpAuctionSchedule.CustomFormat = "MMM dd, yyyy";
            dtpAuctionSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpAuctionSchedule.Location = new System.Drawing.Point(130, 3);
            dtpAuctionSchedule.Name = "dtpAuctionSchedule";
            dtpAuctionSchedule.Size = new System.Drawing.Size(116, 23);
            dtpAuctionSchedule.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch, toolStripSeparator1, btnRptSchedules });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(761, 35);
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
            txtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRptSchedules
            // 
            btnRptSchedules.Image = Properties.Resources.schedule_filled_28px;
            btnRptSchedules.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnRptSchedules.Name = "btnRptSchedules";
            btnRptSchedules.Size = new System.Drawing.Size(105, 24);
            btnRptSchedules.Text = "Rpt Schedules";
            btnRptSchedules.Click += btnRptSchedules_Click;
            // 
            // tabPageAuctionForm
            // 
            tabPageAuctionForm.Controls.Add(panel3);
            tabPageAuctionForm.Controls.Add(ucAuctionEvents2);
            tabPageAuctionForm.Controls.Add(toolStrip2);
            tabPageAuctionForm.Location = new System.Drawing.Point(4, 5);
            tabPageAuctionForm.Margin = new System.Windows.Forms.Padding(0);
            tabPageAuctionForm.Name = "tabPageAuctionForm";
            tabPageAuctionForm.Size = new System.Drawing.Size(761, 419);
            tabPageAuctionForm.TabIndex = 1;
            tabPageAuctionForm.Text = "Auction > Form";
            tabPageAuctionForm.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSave);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 166);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(761, 30);
            panel3.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(593, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(150, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save (Ctrl + S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ucAuctionEvents2
            // 
            ucAuctionEvents2.Dock = System.Windows.Forms.DockStyle.Top;
            ucAuctionEvents2.Location = new System.Drawing.Point(0, 35);
            ucAuctionEvents2.Name = "ucAuctionEvents2";
            ucAuctionEvents2.Size = new System.Drawing.Size(761, 131);
            ucAuctionEvents2.TabIndex = 14;
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
            toolStrip2.Size = new System.Drawing.Size(761, 35);
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
            // tabPageListOfRptSchedule
            // 
            tabPageListOfRptSchedule.Controls.Add(dgRptSchedule);
            tabPageListOfRptSchedule.Controls.Add(statusStrip3);
            tabPageListOfRptSchedule.Controls.Add(progressBar2);
            tabPageListOfRptSchedule.Controls.Add(panel6);
            tabPageListOfRptSchedule.Controls.Add(toolStrip4);
            tabPageListOfRptSchedule.Location = new System.Drawing.Point(4, 5);
            tabPageListOfRptSchedule.Margin = new System.Windows.Forms.Padding(0);
            tabPageListOfRptSchedule.Name = "tabPageListOfRptSchedule";
            tabPageListOfRptSchedule.Size = new System.Drawing.Size(761, 419);
            tabPageListOfRptSchedule.TabIndex = 3;
            tabPageListOfRptSchedule.Text = "Auction > Rpt Schedule";
            tabPageListOfRptSchedule.UseVisualStyleBackColor = true;
            // 
            // dgRptSchedule
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgRptSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgRptSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgRptSchedule.DefaultCellStyle = dataGridViewCellStyle4;
            dgRptSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            dgRptSchedule.Location = new System.Drawing.Point(0, 70);
            dgRptSchedule.Margin = new System.Windows.Forms.Padding(0);
            dgRptSchedule.Name = "dgRptSchedule";
            dgRptSchedule.RowTemplate.Height = 25;
            dgRptSchedule.Size = new System.Drawing.Size(761, 327);
            dgRptSchedule.TabIndex = 6;
            dgRptSchedule.SelectionChanged += dgRptSchedule_SelectionChanged;
            // 
            // statusStrip3
            // 
            statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip3.Location = new System.Drawing.Point(0, 397);
            statusStrip3.Name = "statusStrip3";
            statusStrip3.Size = new System.Drawing.Size(761, 22);
            statusStrip3.TabIndex = 11;
            statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel2.Text = "Records:";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            toolStripStatusLabel3.Text = "0";
            // 
            // progressBar2
            // 
            progressBar2.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar2.Location = new System.Drawing.Point(0, 65);
            progressBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new System.Drawing.Size(761, 5);
            progressBar2.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.Controls.Add(cmbxSchedulePropertyRowFilter);
            panel6.Controls.Add(dtpRptSchedule);
            panel6.Dock = System.Windows.Forms.DockStyle.Top;
            panel6.Location = new System.Drawing.Point(0, 35);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(761, 30);
            panel6.TabIndex = 4;
            // 
            // cmbxSchedulePropertyRowFilter
            // 
            cmbxSchedulePropertyRowFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxSchedulePropertyRowFilter.FormattingEnabled = true;
            cmbxSchedulePropertyRowFilter.Location = new System.Drawing.Point(3, 3);
            cmbxSchedulePropertyRowFilter.Name = "cmbxSchedulePropertyRowFilter";
            cmbxSchedulePropertyRowFilter.Size = new System.Drawing.Size(121, 23);
            cmbxSchedulePropertyRowFilter.TabIndex = 1;
            // 
            // dtpRptSchedule
            // 
            dtpRptSchedule.CustomFormat = "MMM dd, yyyy";
            dtpRptSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpRptSchedule.Location = new System.Drawing.Point(130, 3);
            dtpRptSchedule.Name = "dtpRptSchedule";
            dtpRptSchedule.Size = new System.Drawing.Size(116, 23);
            dtpRptSchedule.TabIndex = 0;
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = System.Drawing.Color.Transparent;
            toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton1, toolStripSeparator3, btnAddScheduledProperty, btnEditScheduledProperty, btnDeleteScheduledProperty, btnSearchRptSched, toolStripTextBox1 });
            toolStrip4.Location = new System.Drawing.Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Padding = new System.Windows.Forms.Padding(4);
            toolStrip4.Size = new System.Drawing.Size(761, 35);
            toolStrip4.TabIndex = 1;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.arrow_left_20px;
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(56, 24);
            toolStripButton1.Text = "Back";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAddScheduledProperty
            // 
            btnAddScheduledProperty.Image = Properties.Resources.add;
            btnAddScheduledProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddScheduledProperty.Name = "btnAddScheduledProperty";
            btnAddScheduledProperty.Size = new System.Drawing.Size(53, 24);
            btnAddScheduledProperty.Text = "Add";
            btnAddScheduledProperty.Click += toolStripButton3_Click;
            // 
            // btnEditScheduledProperty
            // 
            btnEditScheduledProperty.Image = Properties.Resources.button_rounded_edit_16px;
            btnEditScheduledProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnEditScheduledProperty.Name = "btnEditScheduledProperty";
            btnEditScheduledProperty.Size = new System.Drawing.Size(51, 24);
            btnEditScheduledProperty.Text = "Edit";
            btnEditScheduledProperty.Click += toolStripButton4_Click;
            // 
            // btnDeleteScheduledProperty
            // 
            btnDeleteScheduledProperty.Image = Properties.Resources.button_rounded_remove_16px;
            btnDeleteScheduledProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDeleteScheduledProperty.Name = "btnDeleteScheduledProperty";
            btnDeleteScheduledProperty.Size = new System.Drawing.Size(64, 24);
            btnDeleteScheduledProperty.Text = "Delete";
            btnDeleteScheduledProperty.Click += btnDeleteScheduledProperty_Click;
            // 
            // btnSearchRptSched
            // 
            btnSearchRptSched.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearchRptSched.Image = Properties.Resources.find_20px;
            btnSearchRptSched.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearchRptSched.Name = "btnSearchRptSched";
            btnSearchRptSched.Size = new System.Drawing.Size(66, 24);
            btnSearchRptSched.Text = "Search";
            btnSearchRptSched.Click += btnSearchRptSched_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new System.Drawing.Size(200, 27);
            // 
            // tabPageRptScheduleForm
            // 
            tabPageRptScheduleForm.Controls.Add(panel5);
            tabPageRptScheduleForm.Controls.Add(ucRptScheduling2);
            tabPageRptScheduleForm.Controls.Add(toolStrip5);
            tabPageRptScheduleForm.Location = new System.Drawing.Point(4, 5);
            tabPageRptScheduleForm.Margin = new System.Windows.Forms.Padding(0);
            tabPageRptScheduleForm.Name = "tabPageRptScheduleForm";
            tabPageRptScheduleForm.Size = new System.Drawing.Size(761, 419);
            tabPageRptScheduleForm.TabIndex = 4;
            tabPageRptScheduleForm.Text = "Auction > Rpt Schedule > Form";
            tabPageRptScheduleForm.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnSaveRptAuctionSchedule);
            panel5.Controls.Add(button1);
            panel5.Dock = System.Windows.Forms.DockStyle.Top;
            panel5.Location = new System.Drawing.Point(0, 102);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(761, 30);
            panel5.TabIndex = 13;
            // 
            // btnSaveRptAuctionSchedule
            // 
            btnSaveRptAuctionSchedule.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSaveRptAuctionSchedule.Location = new System.Drawing.Point(593, 4);
            btnSaveRptAuctionSchedule.Name = "btnSaveRptAuctionSchedule";
            btnSaveRptAuctionSchedule.Size = new System.Drawing.Size(150, 23);
            btnSaveRptAuctionSchedule.TabIndex = 1;
            btnSaveRptAuctionSchedule.Text = "Save (Ctrl + S)";
            btnSaveRptAuctionSchedule.UseVisualStyleBackColor = true;
            btnSaveRptAuctionSchedule.Click += btnSaveRptAuctionSchedule_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(1104, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 23);
            button1.TabIndex = 0;
            button1.Text = "Save (Ctrl + S)";
            button1.UseVisualStyleBackColor = true;
            // 
            // ucRptScheduling2
            // 
            ucRptScheduling2.Dock = System.Windows.Forms.DockStyle.Top;
            ucRptScheduling2.Location = new System.Drawing.Point(0, 35);
            ucRptScheduling2.Name = "ucRptScheduling2";
            ucRptScheduling2.Size = new System.Drawing.Size(761, 67);
            ucRptScheduling2.TabIndex = 14;
            // 
            // toolStrip5
            // 
            toolStrip5.BackColor = System.Drawing.Color.Transparent;
            toolStrip5.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButton7 });
            toolStrip5.Location = new System.Drawing.Point(0, 0);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Padding = new System.Windows.Forms.Padding(4);
            toolStrip5.Size = new System.Drawing.Size(761, 35);
            toolStrip5.TabIndex = 0;
            toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton7
            // 
            toolStripButton7.Image = Properties.Resources.arrow_left_20px;
            toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new System.Drawing.Size(56, 24);
            toolStripButton7.Text = "Back";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // backgroundWorker2
            // 
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            backgroundWorker2.ProgressChanged += backgroundWorker2_ProgressChanged;
            backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;
            // 
            // frmAuction
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(769, 428);
            Controls.Add(tabControl1);
            KeyPreview = true;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(785, 467);
            Name = "frmAuction";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Transactions > Auction";
            Load += frmAuction_Load;
            KeyDown += frmAuction_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPageListOfAuction.ResumeLayout(false);
            tabPageListOfAuction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgAuctionList).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageAuctionForm.ResumeLayout(false);
            tabPageAuctionForm.PerformLayout();
            panel3.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tabPageListOfRptSchedule.ResumeLayout(false);
            tabPageListOfRptSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgRptSchedule).EndInit();
            statusStrip3.ResumeLayout(false);
            statusStrip3.PerformLayout();
            panel6.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            tabPageRptScheduleForm.ResumeLayout(false);
            tabPageRptScheduleForm.PerformLayout();
            panel5.ResumeLayout(false);
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageListOfAuction;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRowCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.DateTimePicker dtpAuctionSchedule;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPageAuctionForm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private ucAuctionEvents ucAuctionEvents1;
        private System.Windows.Forms.TabPage tabPageListOfRptSchedule;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnRptSchedules;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAddScheduledProperty;
        private System.Windows.Forms.ToolStripButton btnEditScheduledProperty;
        private System.Windows.Forms.ToolStripButton btnDeleteScheduledProperty;
        private System.Windows.Forms.TabPage tabPageRptScheduleForm;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private ucRptScheduling ucRptScheduling1;
        private System.Windows.Forms.Button btnSaveRptAuctionSchedule;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton btnSearchRptSched;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbxSchedulePropertyRowFilter;
        private System.Windows.Forms.DateTimePicker dtpRptSchedule;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private ucNoticeOfAuctionSaleOfDelinquentRealProperties ucNoticeOfAuctionReport1;
        private System.Windows.Forms.DataGridView dgAuctionList;
        private System.Windows.Forms.DataGridView dgRptScheduleList;
        private System.Windows.Forms.DataGridView dgRptSchedule;
        private ucAuctionEvents ucAuctionEvents2;
        private ucRptScheduling ucRptScheduling2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
