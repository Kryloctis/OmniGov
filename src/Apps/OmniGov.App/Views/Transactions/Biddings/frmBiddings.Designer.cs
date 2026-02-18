using OmniGov.App.Views.Transactions.Biddings;
namespace OmniGov.App.Views.Transactions.Biddings
{
    partial class frmBiddings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageList = new System.Windows.Forms.TabPage();
            dgBiddings = new System.Windows.Forms.DataGridView();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRowCount = new System.Windows.Forms.ToolStripStatusLabel();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            panel2 = new System.Windows.Forms.Panel();
            cmbxRowFilter = new System.Windows.Forms.ComboBox();
            dtpBiddingDate = new System.Windows.Forms.DateTimePicker();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnEdit = new System.Windows.Forms.ToolStripButton();
            btnDelete = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            tabPageForm = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            btnProceedToPayment = new System.Windows.Forms.Button();
            btnPayment = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            cbxNewTaxpayer = new System.Windows.Forms.CheckBox();
            ucTaxPayers1 = new OmniGov.App.Views.Manage.TaxPayers.ucTaxPayers();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucBiddings1 = new ucBiddings();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnBack = new System.Windows.Forms.ToolStripButton();
            tabPagePayment = new System.Windows.Forms.TabPage();
            panel4 = new System.Windows.Forms.Panel();
            btnConfirmPayment = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ucPayment1 = new Payments.ucPayment();
            toolStrip4 = new System.Windows.Forms.ToolStrip();
            btnPaymentBack = new System.Windows.Forms.ToolStripButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPageList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgBiddings).BeginInit();
            statusStrip1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabPageForm.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            toolStrip2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            panel4.SuspendLayout();
            toolStrip4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageList);
            tabControl1.Controls.Add(tabPageForm);
            tabControl1.Controls.Add(tabPagePayment);
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
            // tabPageList
            // 
            tabPageList.Controls.Add(dgBiddings);
            tabPageList.Controls.Add(statusStrip1);
            tabPageList.Controls.Add(progressBar1);
            tabPageList.Controls.Add(panel2);
            tabPageList.Controls.Add(toolStrip1);
            tabPageList.Location = new System.Drawing.Point(4, 5);
            tabPageList.Margin = new System.Windows.Forms.Padding(0);
            tabPageList.Name = "tabPageList";
            tabPageList.Size = new System.Drawing.Size(761, 419);
            tabPageList.TabIndex = 0;
            tabPageList.Text = "Biddings > List";
            tabPageList.UseVisualStyleBackColor = true;
            // 
            // dgBiddings
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgBiddings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgBiddings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgBiddings.DefaultCellStyle = dataGridViewCellStyle8;
            dgBiddings.Dock = System.Windows.Forms.DockStyle.Fill;
            dgBiddings.Location = new System.Drawing.Point(0, 70);
            dgBiddings.Margin = new System.Windows.Forms.Padding(0);
            dgBiddings.Name = "dgBiddings";
            dgBiddings.RowTemplate.Height = 25;
            dgBiddings.Size = new System.Drawing.Size(761, 327);
            dgBiddings.TabIndex = 1;
            dgBiddings.SelectionChanged += dgBiddings_SelectionChanged;
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
            panel2.Controls.Add(dtpBiddingDate);
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
            // 
            // dtpBiddingDate
            // 
            dtpBiddingDate.CustomFormat = "MMM dd, yyyy";
            dtpBiddingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpBiddingDate.Location = new System.Drawing.Point(130, 3);
            dtpBiddingDate.Name = "dtpBiddingDate";
            dtpBiddingDate.Size = new System.Drawing.Size(137, 23);
            dtpBiddingDate.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnSearch, txtSearch });
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
            // tabPageForm
            // 
            tabPageForm.Controls.Add(panel3);
            tabPageForm.Controls.Add(splitContainer1);
            tabPageForm.Controls.Add(toolStrip2);
            tabPageForm.Location = new System.Drawing.Point(4, 5);
            tabPageForm.Margin = new System.Windows.Forms.Padding(0);
            tabPageForm.Name = "tabPageForm";
            tabPageForm.Size = new System.Drawing.Size(761, 419);
            tabPageForm.TabIndex = 1;
            tabPageForm.Text = "Biddings > Form";
            tabPageForm.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnProceedToPayment);
            panel3.Controls.Add(btnPayment);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 353);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(761, 29);
            panel3.TabIndex = 15;
            // 
            // btnProceedToPayment
            // 
            btnProceedToPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnProceedToPayment.Location = new System.Drawing.Point(616, 3);
            btnProceedToPayment.Name = "btnProceedToPayment";
            btnProceedToPayment.Size = new System.Drawing.Size(143, 23);
            btnProceedToPayment.TabIndex = 17;
            btnProceedToPayment.Text = "Proceed to Payment";
            btnProceedToPayment.UseVisualStyleBackColor = true;
            btnProceedToPayment.Click += button3_Click;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPayment.Location = new System.Drawing.Point(973, 3);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new System.Drawing.Size(144, 23);
            btnPayment.TabIndex = 0;
            btnPayment.Text = "Proceed to Payment";
            btnPayment.UseVisualStyleBackColor = true;
            btnPayment.Click += btnPayment_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1MinSize = 437;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new System.Drawing.Size(761, 318);
            splitContainer1.SplitterDistance = 437;
            splitContainer1.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(ucTaxPayers1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(437, 318);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bidder Info.";
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(cbxNewTaxpayer);
            panel1.Location = new System.Drawing.Point(8, 26);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(423, 25);
            panel1.TabIndex = 2;
            // 
            // cbxNewTaxpayer
            // 
            cbxNewTaxpayer.AutoSize = true;
            cbxNewTaxpayer.Checked = true;
            cbxNewTaxpayer.CheckState = System.Windows.Forms.CheckState.Checked;
            cbxNewTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            cbxNewTaxpayer.Location = new System.Drawing.Point(93, 3);
            cbxNewTaxpayer.Name = "cbxNewTaxpayer";
            cbxNewTaxpayer.Size = new System.Drawing.Size(144, 19);
            cbxNewTaxpayer.TabIndex = 0;
            cbxNewTaxpayer.Text = "New Bidder / Taxpayer";
            cbxNewTaxpayer.UseVisualStyleBackColor = true;
            cbxNewTaxpayer.CheckedChanged += cbxNewTaxpayer_CheckedChanged;
            // 
            // ucTaxPayers1
            // 
            ucTaxPayers1.AutoSize = true;
            ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucTaxPayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxPayers1.Font = new System.Drawing.Font("Segoe UI", 9F);
            ucTaxPayers1.Location = new System.Drawing.Point(3, 23);
            ucTaxPayers1.Name = "ucTaxPayers1";
            ucTaxPayers1.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            ucTaxPayers1.Size = new System.Drawing.Size(431, 292);
            ucTaxPayers1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ucBiddings1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 30, 3, 3);
            groupBox2.Size = new System.Drawing.Size(320, 318);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bidding Details";
            // 
            // ucBiddings1
            // 
            ucBiddings1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucBiddings1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBiddings1.Font = new System.Drawing.Font("Segoe UI", 9F);
            ucBiddings1.Location = new System.Drawing.Point(3, 50);
            ucBiddings1.Name = "ucBiddings1";
            ucBiddings1.Size = new System.Drawing.Size(314, 265);
            ucBiddings1.TabIndex = 0;
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
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(panel4);
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Controls.Add(toolStrip4);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Margin = new System.Windows.Forms.Padding(0);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Size = new System.Drawing.Size(761, 419);
            tabPagePayment.TabIndex = 3;
            tabPagePayment.Text = "Biddings > Payment";
            tabPagePayment.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnConfirmPayment);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(0, 379);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(761, 30);
            panel4.TabIndex = 18;
            // 
            // btnConfirmPayment
            // 
            btnConfirmPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnConfirmPayment.Location = new System.Drawing.Point(614, 3);
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.Size = new System.Drawing.Size(144, 23);
            btnConfirmPayment.TabIndex = 2;
            btnConfirmPayment.Text = "Confirm Payment";
            btnConfirmPayment.UseVisualStyleBackColor = true;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(1113, 4);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(150, 23);
            button2.TabIndex = 1;
            button2.Text = "Confirm Payment";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(1609, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 23);
            button1.TabIndex = 0;
            button1.Text = "Proceed to Payment";
            button1.UseVisualStyleBackColor = true;
            // 
            // ucPayment1
            // 
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Dock = System.Windows.Forms.DockStyle.Top;
            ucPayment1.Location = new System.Drawing.Point(0, 35);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(761, 344);
            ucPayment1.TabIndex = 17;
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = System.Drawing.Color.Transparent;
            toolStrip4.Font = new System.Drawing.Font("Segoe UI", 9F);
            toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnPaymentBack });
            toolStrip4.Location = new System.Drawing.Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Padding = new System.Windows.Forms.Padding(4);
            toolStrip4.Size = new System.Drawing.Size(761, 35);
            toolStrip4.TabIndex = 1;
            toolStrip4.Text = "toolStrip4";
            // 
            // btnPaymentBack
            // 
            btnPaymentBack.Image = Properties.Resources.arrow_left_20px;
            btnPaymentBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnPaymentBack.Name = "btnPaymentBack";
            btnPaymentBack.Size = new System.Drawing.Size(56, 24);
            btnPaymentBack.Text = "Back";
            btnPaymentBack.Click += btnPaymentBack_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmBiddings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(769, 428);
            Controls.Add(tabControl1);
            MinimizeBox = false;
            Name = "frmBiddings";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Transactions > Bid";
            Load += frmBiddings_Load;
            tabControl1.ResumeLayout(false);
            tabPageList.ResumeLayout(false);
            tabPageList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgBiddings).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPageForm.ResumeLayout(false);
            tabPageForm.PerformLayout();
            panel3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tabPagePayment.ResumeLayout(false);
            tabPagePayment.PerformLayout();
            panel4.ResumeLayout(false);
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageList;
        private System.Windows.Forms.DataGridView dgBiddings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRowCount;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbxRowFilter;
        private System.Windows.Forms.DateTimePicker dtpBiddingDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.TabPage tabPageForm;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.TabPage tabPagePayment;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnPaymentBack;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Payments.ucPayment ucPayment1;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private OmniGov.App.Views.Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnProceedToPayment;
        private ucBiddings ucBiddings1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxNewTaxpayer;
    }
}
