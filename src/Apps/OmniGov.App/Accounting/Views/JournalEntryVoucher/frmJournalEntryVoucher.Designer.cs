using OmniGov.App.Accounting.Views.JournalEntryVoucher;

namespace OmniGov.App.Accounting.Views.JournalEntryVoucher
{
    partial class frmJournalEntryVoucher
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
            panel7 = new Panel();
            dgJEV = new DataGridView();
            panel6 = new Panel();
            lblPagination = new Label();
            btnPrevPagination = new Button();
            btnFrwdPagination = new Button();
            pbLoadRecords = new ProgressBar();
            toolStrip1 = new ToolStrip();
            tlStrpBtnReview = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tlStrpBtnDelete = new ToolStripButton();
            tlStrpBtnView = new ToolStripButton();
            tlStrpBtnUpdate = new ToolStripButton();
            tlStrpBtnCreate = new ToolStripButton();
            panel4 = new Panel();
            label10 = new Label();
            label8 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            customTabControl1 = new OmniGov.App.CustomTools.CustomTabControl();
            tbPgMain = new TabPage();
            panel1 = new Panel();
            txtSearch = new TextBox();
            flwLyoutPanelStatus = new FlowLayoutPanel();
            radPending = new RadioButton();
            radApproved = new RadioButton();
            radDisapproved = new RadioButton();
            radCancelled = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label5 = new Label();
            label1 = new Label();
            nudYear = new NumericUpDown();
            cmbxFunds = new ComboBox();
            cmbxJournals = new ComboBox();
            tbPgCrud = new TabPage();
            ucJev1 = new ucJournalEntryVoucher();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnSubmit = new Button();
            toolStrip3 = new ToolStrip();
            tlStrpBtnBack = new ToolStripButton();
            panel3 = new Panel();
            label11 = new Label();
            lblCrudStat = new Label();
            tbPgView = new TabPage();
            ucJev2 = new ucJournalEntryVoucher();
            toolStrip4 = new ToolStrip();
            tlsStrpBtnBckView = new ToolStripButton();
            panel5 = new Panel();
            label12 = new Label();
            label6 = new Label();
            tbPgReview = new TabPage();
            ucJevAudit = new ucJournalEntryVoucher();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnApprove = new Button();
            btnDisapprove = new Button();
            btnCancel = new Button();
            toolStrip5 = new ToolStrip();
            tlStrpBtnBckReview = new ToolStripButton();
            panel8 = new Panel();
            label13 = new Label();
            label7 = new Label();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgJEV).BeginInit();
            panel6.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel4.SuspendLayout();
            customTabControl1.SuspendLayout();
            tbPgMain.SuspendLayout();
            panel1.SuspendLayout();
            flwLyoutPanelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            tbPgCrud.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            toolStrip3.SuspendLayout();
            panel3.SuspendLayout();
            tbPgView.SuspendLayout();
            toolStrip4.SuspendLayout();
            panel5.SuspendLayout();
            tbPgReview.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            toolStrip5.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Control;
            panel7.Controls.Add(dgJEV);
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Controls.Add(toolStrip1);
            panel7.Controls.Add(panel4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(248, 0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(20);
            panel7.Size = new Size(570, 595);
            panel7.TabIndex = 9;
            // 
            // dgJEV
            // 
            dgJEV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgJEV.Dock = DockStyle.Fill;
            dgJEV.Location = new Point(20, 108);
            dgJEV.Margin = new Padding(1);
            dgJEV.Name = "dgJEV";
            dgJEV.Size = new Size(530, 430);
            dgJEV.TabIndex = 7;
            dgJEV.ColumnAdded += dgJEV_ColumnAdded;
            dgJEV.SelectionChanged += dgJEV_SelectionChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(lblPagination);
            panel6.Controls.Add(btnPrevPagination);
            panel6.Controls.Add(btnFrwdPagination);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(20, 538);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(4);
            panel6.Size = new Size(530, 37);
            panel6.TabIndex = 27;
            // 
            // lblPagination
            // 
            lblPagination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPagination.AutoSize = true;
            lblPagination.ForeColor = SystemColors.ControlDarkDark;
            lblPagination.Location = new Point(394, 11);
            lblPagination.Name = "lblPagination";
            lblPagination.Size = new Size(65, 15);
            lblPagination.TabIndex = 4;
            lblPagination.Text = "Page 1 of 3";
            // 
            // btnPrevPagination
            // 
            btnPrevPagination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevPagination.ForeColor = SystemColors.ControlDarkDark;
            btnPrevPagination.Location = new Point(465, 7);
            btnPrevPagination.Name = "btnPrevPagination";
            btnPrevPagination.Size = new Size(26, 23);
            btnPrevPagination.TabIndex = 2;
            btnPrevPagination.Text = "<";
            btnPrevPagination.UseVisualStyleBackColor = true;
            btnPrevPagination.Click += btnPrevPagination_Click;
            // 
            // btnFrwdPagination
            // 
            btnFrwdPagination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFrwdPagination.ForeColor = SystemColors.ControlDarkDark;
            btnFrwdPagination.Location = new Point(497, 7);
            btnFrwdPagination.Name = "btnFrwdPagination";
            btnFrwdPagination.Size = new Size(26, 23);
            btnFrwdPagination.TabIndex = 3;
            btnFrwdPagination.Text = ">";
            btnFrwdPagination.UseVisualStyleBackColor = true;
            btnFrwdPagination.Click += btnFrwdPagination_Click;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = DockStyle.Top;
            pbLoadRecords.Location = new Point(20, 106);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new Size(530, 2);
            pbLoadRecords.TabIndex = 25;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tlStrpBtnReview, toolStripSeparator2, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnUpdate, tlStrpBtnCreate });
            toolStrip1.Location = new Point(20, 71);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(4);
            toolStrip1.Size = new Size(530, 35);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnReview
            // 
            tlStrpBtnReview.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnReview.Image = Properties.Resources.document_text_ok_filled_20px;
            tlStrpBtnReview.ImageTransparentColor = Color.Magenta;
            tlStrpBtnReview.Name = "tlStrpBtnReview";
            tlStrpBtnReview.Size = new Size(68, 24);
            tlStrpBtnReview.Text = "Review";
            tlStrpBtnReview.Click += tlStrpBtnReview_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnDelete.AutoToolTip = false;
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;
            // 
            // tlStrpBtnView
            // 
            tlStrpBtnView.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnView.Image = Properties.Resources.details_20px;
            tlStrpBtnView.ImageTransparentColor = Color.Magenta;
            tlStrpBtnView.Name = "tlStrpBtnView";
            tlStrpBtnView.Size = new Size(56, 24);
            tlStrpBtnView.Text = "View";
            tlStrpBtnView.Click += tlStrpBtnView_Click;
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnUpdate.AutoToolTip = false;
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            tlStrpBtnUpdate.Click += tlStrpBtnUpdate_Click;
            // 
            // tlStrpBtnCreate
            // 
            tlStrpBtnCreate.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnCreate.AutoToolTip = false;
            tlStrpBtnCreate.Image = Properties.Resources.button_rounded_add_20px;
            tlStrpBtnCreate.ImageTransparentColor = Color.Magenta;
            tlStrpBtnCreate.Name = "tlStrpBtnCreate";
            tlStrpBtnCreate.Size = new Size(65, 24);
            tlStrpBtnCreate.Text = "Create";
            tlStrpBtnCreate.Click += tlStrpBtnCreate_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label8);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(20, 20);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(0, 0, 0, 15);
            panel4.Size = new Size(530, 51);
            panel4.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.ControlDarkDark;
            label10.Location = new Point(3, 21);
            label10.Name = "label10";
            label10.Size = new Size(297, 15);
            label10.TabIndex = 1;
            label10.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(168, 21);
            label8.TabIndex = 0;
            label8.Text = "Journal Entry Voucher";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgMain);
            customTabControl1.Controls.Add(tbPgCrud);
            customTabControl1.Controls.Add(tbPgView);
            customTabControl1.Controls.Add(tbPgReview);
            customTabControl1.Dock = DockStyle.Fill;
            customTabControl1.Location = new Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new Size(826, 623);
            customTabControl1.TabIndex = 18;
            // 
            // tbPgMain
            // 
            tbPgMain.Controls.Add(panel7);
            tbPgMain.Controls.Add(panel1);
            tbPgMain.Location = new Point(4, 24);
            tbPgMain.Name = "tbPgMain";
            tbPgMain.Size = new Size(818, 595);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            tbPgMain.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(flwLyoutPanelStatus);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nudYear);
            panel1.Controls.Add(cmbxFunds);
            panel1.Controls.Add(cmbxJournals);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(248, 595);
            panel1.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(23, 38);
            txtSearch.Margin = new Padding(3, 3, 3, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 36;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // flwLyoutPanelStatus
            // 
            flwLyoutPanelStatus.Controls.Add(radPending);
            flwLyoutPanelStatus.Controls.Add(radApproved);
            flwLyoutPanelStatus.Controls.Add(radDisapproved);
            flwLyoutPanelStatus.Controls.Add(radCancelled);
            flwLyoutPanelStatus.Location = new Point(23, 99);
            flwLyoutPanelStatus.Margin = new Padding(3, 3, 3, 20);
            flwLyoutPanelStatus.Name = "flwLyoutPanelStatus";
            flwLyoutPanelStatus.Size = new Size(200, 51);
            flwLyoutPanelStatus.TabIndex = 34;
            // 
            // radPending
            // 
            radPending.AutoSize = true;
            radPending.Checked = true;
            radPending.Location = new Point(3, 3);
            radPending.Name = "radPending";
            radPending.Size = new Size(69, 19);
            radPending.TabIndex = 0;
            radPending.TabStop = true;
            radPending.Text = "Pending";
            radPending.UseVisualStyleBackColor = true;
            radPending.CheckedChanged += radPending_CheckedChanged;
            // 
            // radApproved
            // 
            radApproved.AutoSize = true;
            radApproved.Location = new Point(78, 3);
            radApproved.Name = "radApproved";
            radApproved.Size = new Size(77, 19);
            radApproved.TabIndex = 0;
            radApproved.Text = "Approved";
            radApproved.UseVisualStyleBackColor = true;
            radApproved.CheckedChanged += radApproved_CheckedChanged;
            // 
            // radDisapproved
            // 
            radDisapproved.AutoSize = true;
            radDisapproved.Location = new Point(3, 28);
            radDisapproved.Name = "radDisapproved";
            radDisapproved.Size = new Size(89, 19);
            radDisapproved.TabIndex = 0;
            radDisapproved.Text = "Dissaproved";
            radDisapproved.UseVisualStyleBackColor = true;
            radDisapproved.CheckedChanged += radDisapproved_CheckedChanged;
            // 
            // radCancelled
            // 
            radCancelled.AutoSize = true;
            radCancelled.Location = new Point(98, 28);
            radCancelled.Name = "radCancelled";
            radCancelled.Size = new Size(77, 19);
            radCancelled.TabIndex = 0;
            radCancelled.Text = "Cancelled";
            radCancelled.UseVisualStyleBackColor = true;
            radCancelled.CheckedChanged += radCancelled_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(23, 292);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 33;
            label4.Text = "Year";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(23, 231);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 33;
            label3.Text = "Type of Fund";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(23, 170);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 32;
            label2.Text = "Journal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(23, 20);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 31;
            label5.Text = "Search";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(23, 81);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 31;
            label1.Text = "Status";
            // 
            // nudYear
            // 
            nudYear.Location = new Point(23, 310);
            nudYear.Margin = new Padding(3, 3, 3, 20);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(200, 23);
            nudYear.TabIndex = 27;
            nudYear.Value = new decimal(new int[] { 2021, 0, 0, 0 });
            nudYear.ValueChanged += nudYear_ValueChanged;
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new Point(23, 249);
            cmbxFunds.Margin = new Padding(3, 3, 3, 20);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new Size(200, 23);
            cmbxFunds.TabIndex = 30;
            cmbxFunds.SelectionChangeCommitted += cmbxFunds_SelectionChangeCommitted;
            // 
            // cmbxJournals
            // 
            cmbxJournals.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new Point(23, 188);
            cmbxJournals.Margin = new Padding(3, 3, 3, 20);
            cmbxJournals.Name = "cmbxJournals";
            cmbxJournals.Size = new Size(200, 23);
            cmbxJournals.TabIndex = 29;
            cmbxJournals.SelectionChangeCommitted += cmbxJournals_SelectionChangeCommitted;
            // 
            // tbPgCrud
            // 
            tbPgCrud.BackColor = Color.FromArgb(249, 249, 249);
            tbPgCrud.Controls.Add(ucJev1);
            tbPgCrud.Controls.Add(flowLayoutPanel3);
            tbPgCrud.Controls.Add(toolStrip3);
            tbPgCrud.Controls.Add(panel3);
            tbPgCrud.Location = new Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new Size(818, 595);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            // 
            // ucJev1
            // 
            ucJev1.AutoValidate = AutoValidate.Disable;
            ucJev1.BackColor = SystemColors.Control;
            ucJev1.Dock = DockStyle.Fill;
            ucJev1.Location = new Point(0, 106);
            ucJev1.Name = "ucJev1";
            ucJev1.Size = new Size(818, 429);
            ucJev1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(btnSubmit);
            flowLayoutPanel3.Dock = DockStyle.Bottom;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(0, 535);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(0, 5, 20, 20);
            flowLayoutPanel3.Size = new Size(818, 60);
            flowLayoutPanel3.TabIndex = 24;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Location = new Point(595, 8);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(200, 30);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = SystemColors.Control;
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new Size(20, 20);
            toolStrip3.Items.AddRange(new ToolStripItem[] { tlStrpBtnBack });
            toolStrip3.Location = new Point(0, 71);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new Padding(4, 4, 20, 4);
            toolStrip3.Size = new Size(818, 35);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // tlStrpBtnBack
            // 
            tlStrpBtnBack.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnBack.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBack.ImageAlign = ContentAlignment.BottomCenter;
            tlStrpBtnBack.ImageTransparentColor = Color.Magenta;
            tlStrpBtnBack.Name = "tlStrpBtnBack";
            tlStrpBtnBack.Size = new Size(56, 24);
            tlStrpBtnBack.Text = "Back";
            tlStrpBtnBack.Click += tlStrpBtnBack_Click;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(lblCrudStat);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20, 20, 20, 15);
            panel3.Size = new Size(818, 71);
            panel3.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.ControlDarkDark;
            label11.Location = new Point(23, 41);
            label11.Name = "label11";
            label11.Size = new Size(297, 15);
            label11.TabIndex = 24;
            label11.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // lblCrudStat
            // 
            lblCrudStat.AutoSize = true;
            lblCrudStat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCrudStat.ForeColor = SystemColors.ControlDarkDark;
            lblCrudStat.Location = new Point(23, 20);
            lblCrudStat.Name = "lblCrudStat";
            lblCrudStat.Size = new Size(95, 21);
            lblCrudStat.TabIndex = 23;
            lblCrudStat.Text = "CRUD Label";
            // 
            // tbPgView
            // 
            tbPgView.BackColor = SystemColors.Control;
            tbPgView.Controls.Add(ucJev2);
            tbPgView.Controls.Add(toolStrip4);
            tbPgView.Controls.Add(panel5);
            tbPgView.Location = new Point(4, 24);
            tbPgView.Name = "tbPgView";
            tbPgView.Size = new Size(818, 595);
            tbPgView.TabIndex = 2;
            tbPgView.Text = "tbPgView";
            // 
            // ucJev2
            // 
            ucJev2.AutoValidate = AutoValidate.Disable;
            ucJev2.BackColor = SystemColors.Control;
            ucJev2.Dock = DockStyle.Fill;
            ucJev2.Location = new Point(0, 98);
            ucJev2.Name = "ucJev2";
            ucJev2.Size = new Size(818, 497);
            ucJev2.TabIndex = 22;
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = SystemColors.Control;
            toolStrip4.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip4.ImageScalingSize = new Size(20, 20);
            toolStrip4.Items.AddRange(new ToolStripItem[] { tlsStrpBtnBckView });
            toolStrip4.Location = new Point(0, 71);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Padding = new Padding(0, 0, 20, 0);
            toolStrip4.Size = new Size(818, 27);
            toolStrip4.TabIndex = 2;
            toolStrip4.Text = "toolStrip4";
            // 
            // tlsStrpBtnBckView
            // 
            tlsStrpBtnBckView.Alignment = ToolStripItemAlignment.Right;
            tlsStrpBtnBckView.Image = Properties.Resources.arrow_left_20px;
            tlsStrpBtnBckView.ImageAlign = ContentAlignment.BottomCenter;
            tlsStrpBtnBckView.ImageTransparentColor = Color.Magenta;
            tlsStrpBtnBckView.Name = "tlsStrpBtnBckView";
            tlsStrpBtnBckView.Size = new Size(56, 24);
            tlsStrpBtnBckView.Text = "Back";
            tlsStrpBtnBckView.Click += tlsStrpBtnBckView_Click;
            // 
            // panel5
            // 
            panel5.AutoSize = true;
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20, 20, 20, 15);
            panel5.Size = new Size(818, 71);
            panel5.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(23, 41);
            label12.Name = "label12";
            label12.Size = new Size(297, 15);
            label12.TabIndex = 25;
            label12.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlDarkDark;
            label6.Location = new Point(23, 20);
            label6.Name = "label6";
            label6.Size = new Size(168, 21);
            label6.TabIndex = 23;
            label6.Text = "Journal Entry Voucher";
            // 
            // tbPgReview
            // 
            tbPgReview.BackColor = Color.FromArgb(249, 249, 249);
            tbPgReview.Controls.Add(ucJevAudit);
            tbPgReview.Controls.Add(flowLayoutPanel2);
            tbPgReview.Controls.Add(toolStrip5);
            tbPgReview.Controls.Add(panel8);
            tbPgReview.Location = new Point(4, 24);
            tbPgReview.Name = "tbPgReview";
            tbPgReview.Size = new Size(818, 595);
            tbPgReview.TabIndex = 3;
            tbPgReview.Text = "tbPgReview";
            // 
            // ucJevAudit
            // 
            ucJevAudit.AutoValidate = AutoValidate.Disable;
            ucJevAudit.BackColor = SystemColors.Control;
            ucJevAudit.Dock = DockStyle.Fill;
            ucJevAudit.Location = new Point(0, 98);
            ucJevAudit.Name = "ucJevAudit";
            ucJevAudit.Size = new Size(818, 437);
            ucJevAudit.TabIndex = 23;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnApprove);
            flowLayoutPanel2.Controls.Add(btnDisapprove);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(0, 535);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(0, 5, 20, 20);
            flowLayoutPanel2.Size = new Size(818, 60);
            flowLayoutPanel2.TabIndex = 24;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.Image = Properties.Resources.button_ok_16px;
            btnApprove.ImageAlign = ContentAlignment.MiddleRight;
            btnApprove.Location = new Point(695, 8);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(100, 30);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "Approve";
            btnApprove.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDisapprove
            // 
            btnDisapprove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisapprove.Cursor = Cursors.Hand;
            btnDisapprove.Image = Properties.Resources.button_cancel_16px;
            btnDisapprove.ImageAlign = ContentAlignment.MiddleRight;
            btnDisapprove.Location = new Point(589, 8);
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new Size(100, 30);
            btnDisapprove.TabIndex = 0;
            btnDisapprove.Text = "Disapprove";
            btnDisapprove.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDisapprove.UseVisualStyleBackColor = true;
            btnDisapprove.Click += btnDisapprove_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Image = Properties.Resources.symbolForbidden16px;
            btnCancel.ImageAlign = ContentAlignment.MiddleRight;
            btnCancel.Location = new Point(483, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // toolStrip5
            // 
            toolStrip5.BackColor = SystemColors.Control;
            toolStrip5.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip5.ImageScalingSize = new Size(20, 20);
            toolStrip5.Items.AddRange(new ToolStripItem[] { tlStrpBtnBckReview });
            toolStrip5.Location = new Point(0, 71);
            toolStrip5.Name = "toolStrip5";
            toolStrip5.Padding = new Padding(0, 0, 20, 0);
            toolStrip5.Size = new Size(818, 27);
            toolStrip5.TabIndex = 3;
            toolStrip5.Text = "toolStrip5";
            // 
            // tlStrpBtnBckReview
            // 
            tlStrpBtnBckReview.Alignment = ToolStripItemAlignment.Right;
            tlStrpBtnBckReview.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnBckReview.ImageAlign = ContentAlignment.BottomCenter;
            tlStrpBtnBckReview.ImageTransparentColor = Color.Magenta;
            tlStrpBtnBckReview.Name = "tlStrpBtnBckReview";
            tlStrpBtnBckReview.Size = new Size(56, 24);
            tlStrpBtnBckReview.Text = "Back";
            tlStrpBtnBckReview.Click += tlStrpBtnBckReview_Click;
            // 
            // panel8
            // 
            panel8.AutoSize = true;
            panel8.BackColor = SystemColors.Control;
            panel8.Controls.Add(label13);
            panel8.Controls.Add(label7);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(20, 20, 20, 15);
            panel8.Size = new Size(818, 71);
            panel8.TabIndex = 25;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.ControlDarkDark;
            label13.Location = new Point(23, 41);
            label13.Name = "label13";
            label13.Size = new Size(297, 15);
            label13.TabIndex = 26;
            label13.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlDarkDark;
            label7.Location = new Point(23, 20);
            label7.Name = "label7";
            label7.Size = new Size(224, 21);
            label7.TabIndex = 23;
            label7.Text = "Review Journal Entry Voucher";
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmJournalEntryVoucher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 623);
            Controls.Add(customTabControl1);
            MinimizeBox = false;
            Name = "frmJournalEntryVoucher";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Accounting > Transactions > Journal Entry Voucher (JEV)";
            FormClosed += frmJEVList_FormClosed;
            Load += frmJEVList_Load;
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgJEV).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flwLyoutPanelStatus.ResumeLayout(false);
            flwLyoutPanelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            tbPgCrud.ResumeLayout(false);
            tbPgCrud.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tbPgView.ResumeLayout(false);
            tbPgView.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tbPgReview.ResumeLayout(false);
            tbPgReview.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgJEV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCreate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgMain;
        private System.Windows.Forms.TabPage tbPgCrud;
        private ucJournalEntryVoucher ucJev1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnView;
        private System.Windows.Forms.ToolStripButton tlStrpBtnReview;
        private System.Windows.Forms.TabPage tbPgView;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tlsStrpBtnBckView;
        private System.Windows.Forms.TabPage tbPgReview;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBckReview;
        private ucJournalEntryVoucher ucJev2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ucJournalEntryVoucher ucJevAudit;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDisapprove;
        private System.Windows.Forms.Button btnCancel;
        private Panel panel1;
        private FlowLayoutPanel flwLyoutPanelStatus;
        private RadioButton radPending;
        private RadioButton radApproved;
        private RadioButton radDisapproved;
        private RadioButton radCancelled;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        internal NumericUpDown nudYear;
        private ComboBox cmbxFunds;
        internal ComboBox cmbxJournals;
        private TextBox txtSearch;
        private Label label5;
        private Panel panel4;
        private Label label10;
        private Label label8;
        private Panel panel6;
        private Label lblPagination;
        private Button btnPrevPagination;
        private Button btnFrwdPagination;
        private Panel panel3;
        private Label lblCrudStat;
        private Panel panel5;
        private Label label6;
        private Panel panel8;
        private Label label7;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnSubmit;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}
