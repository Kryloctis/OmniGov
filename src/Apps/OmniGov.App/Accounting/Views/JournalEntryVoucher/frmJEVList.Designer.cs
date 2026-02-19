using OmniGov.App.Accounting.Views.JournalEntryVoucher;

namespace OmniGov.App.Accounting.Views.JournalEntryVoucher
{
    partial class frmJevList
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
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxJournals = new System.Windows.Forms.ComboBox();
            nudYear = new System.Windows.Forms.NumericUpDown();
            panel7 = new System.Windows.Forms.Panel();
            dgJEV = new System.Windows.Forms.DataGridView();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnCreate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnView = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnSearch = new System.Windows.Forms.ToolStripButton();
            tlStrpTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tlStrpBtnAudit = new System.Windows.Forms.ToolStripButton();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.Panel();
            btnApplyFltr = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radPending = new System.Windows.Forms.RadioButton();
            radApproved = new System.Windows.Forms.RadioButton();
            radDisapproved = new System.Windows.Forms.RadioButton();
            radCancelled = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpCmbxLimit = new System.Windows.Forms.ToolStripComboBox();
            customTabControl1 = new OmniGov.App.CustomTools.CustomTabControl();
            tbPgMain = new System.Windows.Forms.TabPage();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tbPgCrud = new System.Windows.Forms.TabPage();
            ucJev1 = new ucJev();
            panel2 = new System.Windows.Forms.Panel();
            btnSubmit = new System.Windows.Forms.Button();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBack = new System.Windows.Forms.ToolStripButton();
            lblCrudStat = new System.Windows.Forms.ToolStripLabel();
            tbPgView = new System.Windows.Forms.TabPage();
            ucJev2 = new ucJev();
            toolStrip4 = new System.Windows.Forms.ToolStrip();
            tlsStrpBtnBckView = new System.Windows.Forms.ToolStripButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tbPgAudit = new System.Windows.Forms.TabPage();
            ucJevAudit = new ucJev();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            btnApprove = new System.Windows.Forms.Button();
            btnDisapprove = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            toolStrip5 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBckAudit = new System.Windows.Forms.ToolStripButton();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgJEV).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            customTabControl1.SuspendLayout();
            tbPgMain.SuspendLayout();
            tbPgCrud.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip3.SuspendLayout();
            tbPgView.SuspendLayout();
            toolStrip4.SuspendLayout();
            tbPgAudit.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            toolStrip5.SuspendLayout();
            SuspendLayout();
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(23, 178);
            cmbxFunds.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(209, 23);
            cmbxFunds.TabIndex = 30;
            // 
            // cmbxJournals
            // 
            cmbxJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new System.Drawing.Point(23, 122);
            cmbxJournals.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxJournals.Name = "cmbxJournals";
            cmbxJournals.Size = new System.Drawing.Size(209, 23);
            cmbxJournals.TabIndex = 29;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(23, 234);
            nudYear.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new System.Drawing.Size(209, 23);
            nudYear.TabIndex = 27;
            nudYear.Value = new decimal(new int[] { 2021, 0, 0, 0 });
            // 
            // panel7
            // 
            panel7.Controls.Add(dgJEV);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4);
            panel7.Size = new System.Drawing.Size(560, 446);
            panel7.TabIndex = 9;
            // 
            // dgJEV
            // 
            dgJEV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            dgJEV.Location = new System.Drawing.Point(4, 9);
            dgJEV.Margin = new System.Windows.Forms.Padding(1);
            dgJEV.Name = "dgJEV";
            dgJEV.Size = new System.Drawing.Size(552, 433);
            dgJEV.TabIndex = 7;
            dgJEV.ColumnAdded += dgJEV_ColumnAdded;
            dgJEV.SelectionChanged += dgJEV_SelectionChanged;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(552, 5);
            pbLoadRecords.TabIndex = 25;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnView, tlStrpBtnDelete, tlStrpBtnSearch, tlStrpTxtSearch, toolStripSeparator2, tlStrpBtnAudit });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(818, 35);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnCreate
            // 
            tlStrpBtnCreate.AutoToolTip = false;
            tlStrpBtnCreate.Image = Properties.Resources.button_rounded_add_20px;
            tlStrpBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnCreate.Name = "tlStrpBtnCreate";
            tlStrpBtnCreate.Size = new System.Drawing.Size(65, 24);
            tlStrpBtnCreate.Text = "Create";
            tlStrpBtnCreate.Click += tlStrpBtnCreate_Click;
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.AutoToolTip = false;
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new System.Drawing.Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            tlStrpBtnUpdate.Click += tlStrpBtnUpdate_Click;
            // 
            // tlStrpBtnView
            // 
            tlStrpBtnView.Image = Properties.Resources.details_20px;
            tlStrpBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnView.Name = "tlStrpBtnView";
            tlStrpBtnView.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnView.Text = "View";
            tlStrpBtnView.Click += tlStrpBtnView_Click;
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.AutoToolTip = false;
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new System.Drawing.Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;
            // 
            // tlStrpBtnSearch
            // 
            tlStrpBtnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tlStrpBtnSearch.Image = Properties.Resources.find_20px;
            tlStrpBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnSearch.Name = "tlStrpBtnSearch";
            tlStrpBtnSearch.Size = new System.Drawing.Size(24, 24);
            tlStrpBtnSearch.Text = "Search";
            tlStrpBtnSearch.Click += tlStrpBtnSearch_Click;
            // 
            // tlStrpTxtSearch
            // 
            tlStrpTxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tlStrpTxtSearch.Name = "tlStrpTxtSearch";
            tlStrpTxtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tlStrpBtnAudit
            // 
            tlStrpBtnAudit.Image = Properties.Resources.document_text_ok_filled_20px;
            tlStrpBtnAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnAudit.Name = "tlStrpBtnAudit";
            tlStrpBtnAudit.Size = new System.Drawing.Size(68, 24);
            tlStrpBtnAudit.Text = "Review";
            tlStrpBtnAudit.Click += tlStrpBtnAudit_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 66);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel7);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new System.Drawing.Size(818, 446);
            splitContainer1.SplitterDistance = 560;
            splitContainer1.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnApplyFltr);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nudYear);
            panel1.Controls.Add(cmbxFunds);
            panel1.Controls.Add(cmbxJournals);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 31);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(254, 415);
            panel1.TabIndex = 13;
            // 
            // btnApplyFltr
            // 
            btnApplyFltr.Cursor = System.Windows.Forms.Cursors.Hand;
            btnApplyFltr.Location = new System.Drawing.Point(23, 280);
            btnApplyFltr.Name = "btnApplyFltr";
            btnApplyFltr.Size = new System.Drawing.Size(209, 23);
            btnApplyFltr.TabIndex = 35;
            btnApplyFltr.Text = "Apply Filter";
            btnApplyFltr.UseVisualStyleBackColor = true;
            btnApplyFltr.Click += btnApplyFltr_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radPending);
            flowLayoutPanel1.Controls.Add(radApproved);
            flowLayoutPanel1.Controls.Add(radDisapproved);
            flowLayoutPanel1.Controls.Add(radCancelled);
            flowLayoutPanel1.Location = new System.Drawing.Point(23, 38);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(209, 51);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // radPending
            // 
            radPending.AutoSize = true;
            radPending.Checked = true;
            radPending.Location = new System.Drawing.Point(3, 3);
            radPending.Name = "radPending";
            radPending.Size = new System.Drawing.Size(69, 19);
            radPending.TabIndex = 0;
            radPending.TabStop = true;
            radPending.Text = "Pending";
            radPending.UseVisualStyleBackColor = true;
            // 
            // radApproved
            // 
            radApproved.AutoSize = true;
            radApproved.Location = new System.Drawing.Point(78, 3);
            radApproved.Name = "radApproved";
            radApproved.Size = new System.Drawing.Size(77, 19);
            radApproved.TabIndex = 0;
            radApproved.Text = "Approved";
            radApproved.UseVisualStyleBackColor = true;
            // 
            // radDisapproved
            // 
            radDisapproved.AutoSize = true;
            radDisapproved.Location = new System.Drawing.Point(3, 28);
            radDisapproved.Name = "radDisapproved";
            radDisapproved.Size = new System.Drawing.Size(89, 19);
            radDisapproved.TabIndex = 0;
            radDisapproved.Text = "Dissaproved";
            radDisapproved.UseVisualStyleBackColor = true;
            // 
            // radCancelled
            // 
            radCancelled.AutoSize = true;
            radCancelled.Location = new System.Drawing.Point(98, 28);
            radCancelled.Name = "radCancelled";
            radCancelled.Size = new System.Drawing.Size(77, 19);
            radCancelled.TabIndex = 0;
            radCancelled.Text = "Cancelled";
            radCancelled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(23, 216);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 15);
            label4.TabIndex = 33;
            label4.Text = "Year:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 160);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(78, 15);
            label3.TabIndex = 33;
            label3.Text = "Type of Fund:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 104);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 15);
            label2.TabIndex = 32;
            label2.Text = "Journal:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 31;
            label1.Text = "Status:";
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(4);
            label5.Size = new System.Drawing.Size(254, 31);
            label5.TabIndex = 32;
            label5.Text = "Filter Records";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpCmbxLimit });
            toolStrip2.Location = new System.Drawing.Point(0, 35);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(818, 31);
            toolStrip2.TabIndex = 17;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlStrpCmbxLimit
            // 
            tlStrpCmbxLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tlStrpCmbxLimit.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            tlStrpCmbxLimit.Name = "tlStrpCmbxLimit";
            tlStrpCmbxLimit.Size = new System.Drawing.Size(121, 23);
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgMain);
            customTabControl1.Controls.Add(tbPgCrud);
            customTabControl1.Controls.Add(tbPgView);
            customTabControl1.Controls.Add(tbPgAudit);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.Location = new System.Drawing.Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(826, 562);
            customTabControl1.TabIndex = 18;
            // 
            // tbPgMain
            // 
            tbPgMain.Controls.Add(splitContainer1);
            tbPgMain.Controls.Add(toolStrip2);
            tbPgMain.Controls.Add(toolStrip1);
            tbPgMain.Controls.Add(statusStrip1);
            tbPgMain.Location = new System.Drawing.Point(4, 24);
            tbPgMain.Name = "tbPgMain";
            tbPgMain.Size = new System.Drawing.Size(818, 534);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            tbPgMain.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 512);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(818, 22);
            statusStrip1.TabIndex = 20;
            statusStrip1.Text = "statusStrip1";
            // 
            // tbPgCrud
            // 
            tbPgCrud.Controls.Add(ucJev1);
            tbPgCrud.Controls.Add(panel2);
            tbPgCrud.Controls.Add(toolStrip3);
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new System.Drawing.Size(818, 534);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            tbPgCrud.UseVisualStyleBackColor = true;
            // 
            // ucJev1
            // 
            ucJev1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucJev1.BackColor = System.Drawing.SystemColors.Control;
            ucJev1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucJev1.Location = new System.Drawing.Point(0, 47);
            ucJev1.Name = "ucJev1";
            ucJev1.Size = new System.Drawing.Size(818, 444);
            ucJev1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSubmit);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 491);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(818, 43);
            panel2.TabIndex = 21;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.Location = new System.Drawing.Point(610, 7);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(200, 30);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnBack, lblCrudStat });
            toolStrip3.Location = new System.Drawing.Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            toolStrip3.Size = new System.Drawing.Size(818, 47);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // tlStrpBtnBack
            // 
            tlStrpBtnBack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnBack.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBack.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            tlStrpBtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnBack.Name = "tlStrpBtnBack";
            tlStrpBtnBack.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnBack.Text = "Back";
            tlStrpBtnBack.Click += tlStrpBtnBack_Click;
            // 
            // lblCrudStat
            // 
            lblCrudStat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCrudStat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCrudStat.Name = "lblCrudStat";
            lblCrudStat.Size = new System.Drawing.Size(220, 24);
            lblCrudStat.Text = "Create Journal Entry Voucher";
            // 
            // tbPgView
            // 
            tbPgView.BackColor = System.Drawing.SystemColors.Control;
            tbPgView.Controls.Add(ucJev2);
            tbPgView.Controls.Add(toolStrip4);
            tbPgView.Location = new System.Drawing.Point(4, 24);
            tbPgView.Name = "tbPgView";
            tbPgView.Size = new System.Drawing.Size(818, 534);
            tbPgView.TabIndex = 2;
            tbPgView.Text = "tbPgView";
            // 
            // ucJev2
            // 
            ucJev2.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucJev2.BackColor = System.Drawing.SystemColors.Control;
            ucJev2.Dock = System.Windows.Forms.DockStyle.Fill;
            ucJev2.Location = new System.Drawing.Point(0, 47);
            ucJev2.Name = "ucJev2";
            ucJev2.Size = new System.Drawing.Size(818, 487);
            ucJev2.TabIndex = 22;
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = System.Drawing.SystemColors.Control;
            toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlsStrpBtnBckView, toolStripLabel1 });
            toolStrip4.Location = new System.Drawing.Point(0, 0);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            toolStrip4.Size = new System.Drawing.Size(818, 47);
            toolStrip4.TabIndex = 2;
            toolStrip4.Text = "toolStrip4";
            // 
            // tlsStrpBtnBckView
            // 
            tlsStrpBtnBckView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlsStrpBtnBckView.Image = Properties.Resources.arrow_left_20px;
            tlsStrpBtnBckView.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            tlsStrpBtnBckView.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlsStrpBtnBckView.Name = "tlsStrpBtnBckView";
            tlsStrpBtnBckView.Size = new System.Drawing.Size(56, 24);
            tlsStrpBtnBckView.Text = "Back";
            tlsStrpBtnBckView.Click += tlsStrpBtnBckView_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(168, 24);
            toolStripLabel1.Text = "Journal Entry Voucher";
            // 
            // tbPgAudit
            // 
            tbPgAudit.BackColor = System.Drawing.SystemColors.Control;
            tbPgAudit.Controls.Add(ucJevAudit);
            tbPgAudit.Controls.Add(flowLayoutPanel2);
            tbPgAudit.Controls.Add(toolStrip5);
            tbPgAudit.Location = new System.Drawing.Point(4, 24);
            tbPgAudit.Name = "tbPgAudit";
            tbPgAudit.Size = new System.Drawing.Size(818, 534);
            tbPgAudit.TabIndex = 3;
            tbPgAudit.Text = "tbPgAudit";
            // 
            // ucJevAudit
            // 
            ucJevAudit.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucJevAudit.BackColor = System.Drawing.SystemColors.Control;
            ucJevAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            ucJevAudit.Location = new System.Drawing.Point(0, 47);
            ucJevAudit.Name = "ucJevAudit";
            ucJevAudit.Size = new System.Drawing.Size(818, 444);
            ucJevAudit.TabIndex = 23;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnApprove);
            flowLayoutPanel2.Controls.Add(btnDisapprove);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 491);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel2.Size = new System.Drawing.Size(818, 43);
            flowLayoutPanel2.TabIndex = 24;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnApprove.Image = Properties.Resources.button_ok_16px;
            btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnApprove.Location = new System.Drawing.Point(707, 7);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new System.Drawing.Size(100, 30);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "Approve";
            btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDisapprove
            // 
            btnDisapprove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDisapprove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDisapprove.Image = Properties.Resources.button_cancel_16px;
            btnDisapprove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnDisapprove.Location = new System.Drawing.Point(601, 7);
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new System.Drawing.Size(100, 30);
            btnDisapprove.TabIndex = 0;
            btnDisapprove.Text = "Disapprove";
            btnDisapprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnDisapprove.UseVisualStyleBackColor = true;
            btnDisapprove.Click += btnDisapprove_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Image = Properties.Resources.symbolForbidden16px;
            btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnCancel.Location = new System.Drawing.Point(495, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // toolStrip5
            // 
            toolStrip5.BackColor = System.Drawing.SystemColors.Control;
            toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnBckAudit, toolStripLabel2 });
            toolStrip5.Location = new System.Drawing.Point(0, 0);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            toolStrip5.Size = new System.Drawing.Size(818, 47);
            toolStrip5.TabIndex = 3;
            toolStrip5.Text = "toolStrip5";
            // 
            // tlStrpBtnBckAudit
            // 
            tlStrpBtnBckAudit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnBckAudit.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBckAudit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            tlStrpBtnBckAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnBckAudit.Name = "tlStrpBtnBckAudit";
            tlStrpBtnBckAudit.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnBckAudit.Text = "Back";
            tlStrpBtnBckAudit.Click += tlStrpBtnBckAudit_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(212, 24);
            toolStripLabel2.Text = "Audit Journal Entry Voucher";
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmJevList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(826, 562);
            Controls.Add(customTabControl1);
            MinimizeBox = false;
            Name = "frmJevList";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Accounting > Transactions > Journal Entry Voucher (JEV)";
            FormClosed += frmJEVList_FormClosed;
            Load += frmJEVList_Load;
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgJEV).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            tbPgMain.PerformLayout();
            tbPgCrud.ResumeLayout(false);
            tbPgCrud.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            tbPgView.ResumeLayout(false);
            tbPgView.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            tbPgAudit.ResumeLayout(false);
            tbPgAudit.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.NumericUpDown nudYear;
        internal System.Windows.Forms.ComboBox cmbxJournals;
        private System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgJEV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCreate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private System.Windows.Forms.ToolStripButton tlStrpBtnSearch;
        private System.Windows.Forms.ToolStripTextBox tlStrpTxtSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radPending;
        private System.Windows.Forms.RadioButton radApproved;
        private System.Windows.Forms.RadioButton radDisapproved;
        private System.Windows.Forms.RadioButton radCancelled;
        private System.Windows.Forms.Button btnApplyFltr;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox tlStrpCmbxLimit;
        private System.Windows.Forms.Label label5;
        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgMain;
        private System.Windows.Forms.TabPage tbPgCrud;
        private ucJev ucJev1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBack;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnView;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAudit;
        private System.Windows.Forms.TabPage tbPgView;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tlsStrpBtnBckView;
        private System.Windows.Forms.TabPage tbPgAudit;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBckAudit;
        private ucJev ucJev2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ucJev ucJevAudit;
        private System.Windows.Forms.ToolStripLabel lblCrudStat;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDisapprove;
        private System.Windows.Forms.Button btnCancel;
    }
}
