namespace LFS.Budget.Views.Obligations
{
    partial class frmObligations
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
            customTabControl1 = new LFS.CustomTools.CustomTabControl();
            tbPgMain = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel7 = new System.Windows.Forms.Panel();
            dgvMain = new System.Windows.Forms.DataGridView();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            dtPckrTo = new System.Windows.Forms.DateTimePicker();
            dtPckrFrom = new System.Windows.Forms.DateTimePicker();
            btnApplyFltr = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            radPending = new System.Windows.Forms.RadioButton();
            radApproved = new System.Windows.Forms.RadioButton();
            radDisapproved = new System.Windows.Forms.RadioButton();
            radCancelled = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpCmbxLimit = new System.Windows.Forms.ToolStripComboBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnCreate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnView = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnSearch = new System.Windows.Forms.ToolStripButton();
            tlStrpTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tlStrpBtnAudit = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tbPgCrud = new System.Windows.Forms.TabPage();
            ucObligationsCrud = new ucObligations();
            panel2 = new System.Windows.Forms.Panel();
            btnCrudSubmit = new System.Windows.Forms.Button();
            btnSubmit = new System.Windows.Forms.Button();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnCrudBack = new System.Windows.Forms.ToolStripButton();
            lblCrudStat = new System.Windows.Forms.ToolStripLabel();
            tbPgView = new System.Windows.Forms.TabPage();
            ucObligationsView = new ucObligations();
            toolStrip4 = new System.Windows.Forms.ToolStrip();
            tlsStrpBtnBckView = new System.Windows.Forms.ToolStripButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tbPgAudit = new System.Windows.Forms.TabPage();
            ucObligationsAudit = new ucObligations();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            btnApprove = new System.Windows.Forms.Button();
            btnDisapprove = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            toolStrip5 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnBckAudit = new System.Windows.Forms.ToolStripButton();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            customTabControl1.SuspendLayout();
            tbPgMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip1.SuspendLayout();
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
            customTabControl1.Size = new System.Drawing.Size(826, 558);
            customTabControl1.TabIndex = 0;
            // 
            // tbPgMain
            // 
            tbPgMain.Controls.Add(splitContainer1);
            tbPgMain.Controls.Add(toolStrip2);
            tbPgMain.Controls.Add(toolStrip1);
            tbPgMain.Controls.Add(statusStrip1);
            tbPgMain.Location = new System.Drawing.Point(4, 24);
            tbPgMain.Name = "tbPgMain";
            tbPgMain.Size = new System.Drawing.Size(818, 530);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            tbPgMain.UseVisualStyleBackColor = true;
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
            splitContainer1.Size = new System.Drawing.Size(818, 442);
            splitContainer1.SplitterDistance = 560;
            splitContainer1.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.Controls.Add(dgvMain);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4);
            panel7.Size = new System.Drawing.Size(560, 442);
            panel7.TabIndex = 9;
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMain.Location = new System.Drawing.Point(4, 9);
            dgvMain.Margin = new System.Windows.Forms.Padding(1);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new System.Drawing.Size(552, 429);
            dgvMain.TabIndex = 7;
            dgvMain.SelectionChanged += dgJEV_SelectionChanged;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(552, 5);
            pbLoadRecords.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.Controls.Add(dtPckrTo);
            panel1.Controls.Add(dtPckrFrom);
            panel1.Controls.Add(btnApplyFltr);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 31);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(254, 411);
            panel1.TabIndex = 13;
            // 
            // dtPckrTo
            // 
            dtPckrTo.CustomFormat = "MMM dd, yyyy";
            dtPckrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrTo.Location = new System.Drawing.Point(23, 163);
            dtPckrTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            dtPckrTo.Name = "dtPckrTo";
            dtPckrTo.Size = new System.Drawing.Size(209, 23);
            dtPckrTo.TabIndex = 36;
            // 
            // dtPckrFrom
            // 
            dtPckrFrom.CustomFormat = "MMM dd, yyyy";
            dtPckrFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrFrom.Location = new System.Drawing.Point(23, 107);
            dtPckrFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtPckrFrom.Name = "dtPckrFrom";
            dtPckrFrom.Size = new System.Drawing.Size(209, 23);
            dtPckrFrom.TabIndex = 36;
            dtPckrFrom.ValueChanged += dtPckrFrom_ValueChanged;
            // 
            // btnApplyFltr
            // 
            btnApplyFltr.Cursor = System.Windows.Forms.Cursors.Hand;
            btnApplyFltr.Location = new System.Drawing.Point(23, 209);
            btnApplyFltr.Name = "btnApplyFltr";
            btnApplyFltr.Size = new System.Drawing.Size(209, 23);
            btnApplyFltr.TabIndex = 35;
            btnApplyFltr.Text = "Apply Filter";
            btnApplyFltr.UseVisualStyleBackColor = true;
            btnApplyFltr.Click += btnApplyFltr_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(23, 145);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(48, 15);
            label6.TabIndex = 33;
            label6.Text = "Date to:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radPending);
            flowLayoutPanel1.Controls.Add(radApproved);
            flowLayoutPanel1.Controls.Add(radDisapproved);
            flowLayoutPanel1.Controls.Add(radCancelled);
            flowLayoutPanel1.Location = new System.Drawing.Point(23, 23);
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
            label4.Location = new System.Drawing.Point(23, 89);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 15);
            label4.TabIndex = 33;
            label4.Text = "Date from:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(43, 40);
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
            toolStrip2.TabIndex = 18;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlStrpCmbxLimit
            // 
            tlStrpCmbxLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tlStrpCmbxLimit.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            tlStrpCmbxLimit.Name = "tlStrpCmbxLimit";
            tlStrpCmbxLimit.Size = new System.Drawing.Size(121, 23);
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
            toolStrip1.TabIndex = 12;
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
            tlStrpBtnAudit.Size = new System.Drawing.Size(60, 24);
            tlStrpBtnAudit.Text = "Audit";
            tlStrpBtnAudit.Click += tlStrpBtnAudit_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 508);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(818, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tbPgCrud
            // 
            tbPgCrud.BackColor = System.Drawing.SystemColors.Control;
            tbPgCrud.Controls.Add(ucObligationsCrud);
            tbPgCrud.Controls.Add(panel2);
            tbPgCrud.Controls.Add(toolStrip3);
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new System.Drawing.Size(818, 530);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            // 
            // ucObligationsCrud
            // 
            ucObligationsCrud.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucObligationsCrud.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsCrud.Location = new System.Drawing.Point(0, 47);
            ucObligationsCrud.Name = "ucObligationsCrud";
            ucObligationsCrud.Size = new System.Drawing.Size(818, 440);
            ucObligationsCrud.TabIndex = 24;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCrudSubmit);
            panel2.Controls.Add(btnSubmit);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 487);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(818, 43);
            panel2.TabIndex = 23;
            // 
            // btnCrudSubmit
            // 
            btnCrudSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCrudSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCrudSubmit.Location = new System.Drawing.Point(610, 7);
            btnCrudSubmit.Name = "btnCrudSubmit";
            btnCrudSubmit.Size = new System.Drawing.Size(200, 30);
            btnCrudSubmit.TabIndex = 1;
            btnCrudSubmit.Text = "Submit";
            btnCrudSubmit.UseVisualStyleBackColor = true;
            btnCrudSubmit.Click += btnCrudSubmit_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.Location = new System.Drawing.Point(1224, 11);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(200, 30);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnCrudBack, lblCrudStat });
            toolStrip3.Location = new System.Drawing.Point(0, 0);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            toolStrip3.Size = new System.Drawing.Size(818, 47);
            toolStrip3.TabIndex = 22;
            toolStrip3.Text = "toolStrip3";
            // 
            // tlStrpBtnCrudBack
            // 
            tlStrpBtnCrudBack.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnCrudBack.Image = Properties.Resources.arrow_left_20px;
            tlStrpBtnCrudBack.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            tlStrpBtnCrudBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnCrudBack.Name = "tlStrpBtnCrudBack";
            tlStrpBtnCrudBack.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnCrudBack.Text = "Back";
            tlStrpBtnCrudBack.Click += tlStrpBtnCrudBack_Click;
            // 
            // lblCrudStat
            // 
            lblCrudStat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCrudStat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCrudStat.Name = "lblCrudStat";
            lblCrudStat.Size = new System.Drawing.Size(203, 24);
            lblCrudStat.Text = "Create Obligation Request";
            // 
            // tbPgView
            // 
            tbPgView.BackColor = System.Drawing.SystemColors.Control;
            tbPgView.Controls.Add(ucObligationsView);
            tbPgView.Controls.Add(toolStrip4);
            tbPgView.Location = new System.Drawing.Point(4, 24);
            tbPgView.Name = "tbPgView";
            tbPgView.Size = new System.Drawing.Size(818, 530);
            tbPgView.TabIndex = 2;
            tbPgView.Text = "tbPgView";
            // 
            // ucObligationsView
            // 
            ucObligationsView.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucObligationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsView.Location = new System.Drawing.Point(0, 47);
            ucObligationsView.Name = "ucObligationsView";
            ucObligationsView.Size = new System.Drawing.Size(818, 483);
            ucObligationsView.TabIndex = 25;
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
            toolStrip4.TabIndex = 3;
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
            toolStripLabel1.Size = new System.Drawing.Size(151, 24);
            toolStripLabel1.Text = "Obligation Request";
            // 
            // tbPgAudit
            // 
            tbPgAudit.BackColor = System.Drawing.SystemColors.Control;
            tbPgAudit.Controls.Add(ucObligationsAudit);
            tbPgAudit.Controls.Add(flowLayoutPanel2);
            tbPgAudit.Controls.Add(toolStrip5);
            tbPgAudit.Location = new System.Drawing.Point(4, 24);
            tbPgAudit.Name = "tbPgAudit";
            tbPgAudit.Size = new System.Drawing.Size(818, 530);
            tbPgAudit.TabIndex = 3;
            tbPgAudit.Text = "tbPgAudit";
            // 
            // ucObligationsAudit
            // 
            ucObligationsAudit.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucObligationsAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsAudit.Location = new System.Drawing.Point(0, 47);
            ucObligationsAudit.Name = "ucObligationsAudit";
            ucObligationsAudit.Size = new System.Drawing.Size(818, 440);
            ucObligationsAudit.TabIndex = 26;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnApprove);
            flowLayoutPanel2.Controls.Add(btnDisapprove);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 487);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel2.Size = new System.Drawing.Size(818, 43);
            flowLayoutPanel2.TabIndex = 25;
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
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Image = Properties.Resources.symbol_forbidden_16px;
            btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnCancel.Location = new System.Drawing.Point(495, 7);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
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
            toolStrip5.TabIndex = 4;
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
            toolStripLabel2.Size = new System.Drawing.Size(195, 24);
            toolStripLabel2.Text = "Audit Obligation Request";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // frmObligations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(826, 558);
            Controls.Add(customTabControl1);
            MinimizeBox = false;
            Name = "frmObligations";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Budget > Obligations";
            Load += frmObligations_Load;
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            tbPgMain.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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

        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgMain;
        private System.Windows.Forms.TabPage tbPgCrud;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCreate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnView;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private System.Windows.Forms.ToolStripButton tlStrpBtnSearch;
        private System.Windows.Forms.ToolStripTextBox tlStrpTxtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAudit;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox tlStrpCmbxLimit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplyFltr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radPending;
        private System.Windows.Forms.RadioButton radApproved;
        private System.Windows.Forms.RadioButton radDisapproved;
        private System.Windows.Forms.RadioButton radCancelled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbPgView;
        private System.Windows.Forms.TabPage tbPgAudit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCrudBack;
        private System.Windows.Forms.ToolStripLabel lblCrudStat;
        private System.Windows.Forms.Button btnCrudSubmit;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tlsStrpBtnBckView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ucObligations ucObligationsView;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton tlStrpBtnBckAudit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDisapprove;
        private System.Windows.Forms.Button btnCancel;
        private ucObligations ucObligationsAudit;
        private System.Windows.Forms.DateTimePicker dtPckrFrom;
        private System.Windows.Forms.DateTimePicker dtPckrTo;
        private System.Windows.Forms.Label label6;
        private ucObligations ucObligationsCrud;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
