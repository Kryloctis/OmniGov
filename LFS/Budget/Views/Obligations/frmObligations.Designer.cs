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
            panel7 = new System.Windows.Forms.Panel();
            dgvMain = new System.Windows.Forms.DataGridView();
            panel6 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnReview = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnView = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnCreate = new System.Windows.Forms.ToolStripButton();
            panel4 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            txtSearch = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            radCancelled = new System.Windows.Forms.RadioButton();
            radDisapproved = new System.Windows.Forms.RadioButton();
            radApproved = new System.Windows.Forms.RadioButton();
            radPending = new System.Windows.Forms.RadioButton();
            dtPckrTo = new System.Windows.Forms.DateTimePicker();
            dtPckrFrom = new System.Windows.Forms.DateTimePicker();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tbPgCrud = new System.Windows.Forms.TabPage();
            ucObligationsCrud = new ucObligations();
            panel2 = new System.Windows.Forms.Panel();
            btnCrudSubmit = new System.Windows.Forms.Button();
            toolStrip3 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnCrudBack = new System.Windows.Forms.ToolStripButton();
            panel5 = new System.Windows.Forms.Panel();
            lblCrudStat = new System.Windows.Forms.Label();
            tbPgView = new System.Windows.Forms.TabPage();
            ucObligationsView = new ucObligations();
            toolStrip4 = new System.Windows.Forms.ToolStrip();
            tlsStrpBtnBckView = new System.Windows.Forms.ToolStripButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tbPgReview = new System.Windows.Forms.TabPage();
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
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            panel6.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tbPgCrud.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip3.SuspendLayout();
            panel5.SuspendLayout();
            tbPgView.SuspendLayout();
            toolStrip4.SuspendLayout();
            tbPgReview.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            toolStrip5.SuspendLayout();
            SuspendLayout();
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgMain);
            customTabControl1.Controls.Add(tbPgCrud);
            customTabControl1.Controls.Add(tbPgView);
            customTabControl1.Controls.Add(tbPgReview);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.Location = new System.Drawing.Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(882, 623);
            customTabControl1.TabIndex = 0;
            // 
            // tbPgMain
            // 
            tbPgMain.BackColor = System.Drawing.SystemColors.Control;
            tbPgMain.Controls.Add(panel7);
            tbPgMain.Controls.Add(toolStrip1);
            tbPgMain.Controls.Add(panel4);
            tbPgMain.Controls.Add(panel1);
            tbPgMain.Location = new System.Drawing.Point(4, 24);
            tbPgMain.Name = "tbPgMain";
            tbPgMain.Size = new System.Drawing.Size(874, 595);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            // 
            // panel7
            // 
            panel7.Controls.Add(dgvMain);
            panel7.Controls.Add(panel6);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(227, 75);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(20, 4, 20, 20);
            panel7.Size = new System.Drawing.Size(647, 520);
            panel7.TabIndex = 9;
            // 
            // dgvMain
            // 
            dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMain.Location = new System.Drawing.Point(20, 6);
            dgvMain.Margin = new System.Windows.Forms.Padding(1);
            dgvMain.Name = "dgvMain";
            dgvMain.Size = new System.Drawing.Size(607, 462);
            dgvMain.TabIndex = 7;
            dgvMain.SelectionChanged += dgvMain_SelectionChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(label7);
            panel6.Controls.Add(button2);
            panel6.Controls.Add(button1);
            panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel6.Location = new System.Drawing.Point(20, 468);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(607, 32);
            panel6.TabIndex = 26;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label7.Location = new System.Drawing.Point(475, 8);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 15);
            label7.TabIndex = 1;
            label7.Text = "Page 1 of 3";
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            button2.Location = new System.Drawing.Point(546, 4);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(26, 23);
            button2.TabIndex = 0;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            button1.Location = new System.Drawing.Point(578, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(26, 23);
            button1.TabIndex = 0;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(20, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(607, 2);
            pbLoadRecords.TabIndex = 25;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnReview, toolStripSeparator2, tlStrpBtnDelete, tlStrpBtnView, tlStrpBtnUpdate, tlStrpBtnCreate });
            toolStrip1.Location = new System.Drawing.Point(227, 40);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4, 4, 20, 4);
            toolStrip1.Size = new System.Drawing.Size(647, 35);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnReview
            // 
            tlStrpBtnReview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnReview.Image = Properties.Resources.document_text_ok_filled_20px;
            tlStrpBtnReview.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnReview.Name = "tlStrpBtnReview";
            tlStrpBtnReview.Size = new System.Drawing.Size(113, 24);
            tlStrpBtnReview.Text = "Review Request";
            tlStrpBtnReview.Click += tlStrpBtnAudit_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnDelete.AutoToolTip = false;
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new System.Drawing.Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
            tlStrpBtnDelete.Click += tlStrpBtnDelete_Click;
            // 
            // tlStrpBtnView
            // 
            tlStrpBtnView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnView.Image = Properties.Resources.details_20px;
            tlStrpBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnView.Name = "tlStrpBtnView";
            tlStrpBtnView.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnView.Text = "View";
            tlStrpBtnView.Click += tlStrpBtnView_Click;
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnUpdate.AutoToolTip = false;
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new System.Drawing.Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            tlStrpBtnUpdate.Click += tlStrpBtnUpdate_Click;
            // 
            // tlStrpBtnCreate
            // 
            tlStrpBtnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnCreate.AutoToolTip = false;
            tlStrpBtnCreate.Image = Properties.Resources.button_rounded_add_20px;
            tlStrpBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnCreate.Name = "tlStrpBtnCreate";
            tlStrpBtnCreate.Size = new System.Drawing.Size(65, 24);
            tlStrpBtnCreate.Text = "Create";
            tlStrpBtnCreate.Click += tlStrpBtnCreate_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(227, 0);
            panel4.Name = "panel4";
            panel4.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            panel4.Size = new System.Drawing.Size(647, 40);
            panel4.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Left;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label3.Location = new System.Drawing.Point(20, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(158, 21);
            label3.TabIndex = 0;
            label3.Text = "Obligation Requests";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(dtPckrTo);
            panel1.Controls.Add(dtPckrFrom);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(227, 595);
            panel1.TabIndex = 13;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(23, 38);
            txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(180, 23);
            txtSearch.TabIndex = 39;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(23, 255);
            label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 15);
            label2.TabIndex = 38;
            label2.Text = "Date Range";
            // 
            // panel3
            // 
            panel3.Controls.Add(radCancelled);
            panel3.Controls.Add(radDisapproved);
            panel3.Controls.Add(radApproved);
            panel3.Controls.Add(radPending);
            panel3.Location = new System.Drawing.Point(23, 101);
            panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(180, 124);
            panel3.TabIndex = 37;
            // 
            // radCancelled
            // 
            radCancelled.Appearance = System.Windows.Forms.Appearance.Button;
            radCancelled.Dock = System.Windows.Forms.DockStyle.Top;
            radCancelled.FlatAppearance.BorderSize = 0;
            radCancelled.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonFace;
            radCancelled.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            radCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radCancelled.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radCancelled.Image = Properties.Resources.symbolForbidden16px;
            radCancelled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radCancelled.Location = new System.Drawing.Point(0, 90);
            radCancelled.Name = "radCancelled";
            radCancelled.Padding = new System.Windows.Forms.Padding(3);
            radCancelled.Size = new System.Drawing.Size(180, 30);
            radCancelled.TabIndex = 0;
            radCancelled.Text = " Cancelled";
            radCancelled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radCancelled.UseVisualStyleBackColor = true;
            radCancelled.CheckedChanged += radCancelled_CheckedChanged;
            // 
            // radDisapproved
            // 
            radDisapproved.Appearance = System.Windows.Forms.Appearance.Button;
            radDisapproved.Dock = System.Windows.Forms.DockStyle.Top;
            radDisapproved.FlatAppearance.BorderSize = 0;
            radDisapproved.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonFace;
            radDisapproved.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            radDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radDisapproved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radDisapproved.Image = Properties.Resources.button_cancel_16px;
            radDisapproved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radDisapproved.Location = new System.Drawing.Point(0, 60);
            radDisapproved.Name = "radDisapproved";
            radDisapproved.Padding = new System.Windows.Forms.Padding(3);
            radDisapproved.Size = new System.Drawing.Size(180, 30);
            radDisapproved.TabIndex = 0;
            radDisapproved.Text = " Disapproved";
            radDisapproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radDisapproved.UseVisualStyleBackColor = true;
            radDisapproved.CheckedChanged += radDisapproved_CheckedChanged;
            // 
            // radApproved
            // 
            radApproved.Appearance = System.Windows.Forms.Appearance.Button;
            radApproved.Dock = System.Windows.Forms.DockStyle.Top;
            radApproved.FlatAppearance.BorderSize = 0;
            radApproved.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonFace;
            radApproved.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            radApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radApproved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radApproved.Image = Properties.Resources.button_ok_16px;
            radApproved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radApproved.Location = new System.Drawing.Point(0, 30);
            radApproved.Name = "radApproved";
            radApproved.Padding = new System.Windows.Forms.Padding(3);
            radApproved.Size = new System.Drawing.Size(180, 30);
            radApproved.TabIndex = 0;
            radApproved.Text = " Approved";
            radApproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radApproved.UseVisualStyleBackColor = true;
            radApproved.CheckedChanged += radApproved_CheckedChanged;
            // 
            // radPending
            // 
            radPending.Appearance = System.Windows.Forms.Appearance.Button;
            radPending.Checked = true;
            radPending.Dock = System.Windows.Forms.DockStyle.Top;
            radPending.FlatAppearance.BorderSize = 0;
            radPending.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ButtonFace;
            radPending.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            radPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPending.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radPending.Image = Properties.Resources.time_16px;
            radPending.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            radPending.Location = new System.Drawing.Point(0, 0);
            radPending.Name = "radPending";
            radPending.Padding = new System.Windows.Forms.Padding(3);
            radPending.Size = new System.Drawing.Size(180, 30);
            radPending.TabIndex = 0;
            radPending.TabStop = true;
            radPending.Text = " Pending";
            radPending.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            radPending.UseVisualStyleBackColor = true;
            radPending.CheckedChanged += radPending_CheckedChanged;
            // 
            // dtPckrTo
            // 
            dtPckrTo.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dtPckrTo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dtPckrTo.CustomFormat = "MMM dd, yyyy";
            dtPckrTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrTo.Location = new System.Drawing.Point(23, 359);
            dtPckrTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            dtPckrTo.Name = "dtPckrTo";
            dtPckrTo.Size = new System.Drawing.Size(180, 23);
            dtPckrTo.TabIndex = 36;
            dtPckrTo.ValueChanged += dtPckrTo_ValueChanged;
            // 
            // dtPckrFrom
            // 
            dtPckrFrom.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dtPckrFrom.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dtPckrFrom.CustomFormat = "MMM dd, yyyy";
            dtPckrFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrFrom.Location = new System.Drawing.Point(23, 303);
            dtPckrFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dtPckrFrom.Name = "dtPckrFrom";
            dtPckrFrom.Size = new System.Drawing.Size(180, 23);
            dtPckrFrom.TabIndex = 36;
            dtPckrFrom.ValueChanged += dtPckrFrom_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label6.Location = new System.Drawing.Point(23, 341);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(19, 15);
            label6.TabIndex = 33;
            label6.Text = "To";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Location = new System.Drawing.Point(23, 285);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 15);
            label4.TabIndex = 33;
            label4.Text = "From";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(23, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 15);
            label5.TabIndex = 31;
            label5.Text = "Search";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(23, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 31;
            label1.Text = "Status";
            // 
            // tbPgCrud
            // 
            tbPgCrud.BackColor = System.Drawing.SystemColors.Control;
            tbPgCrud.Controls.Add(ucObligationsCrud);
            tbPgCrud.Controls.Add(panel2);
            tbPgCrud.Controls.Add(toolStrip3);
            tbPgCrud.Controls.Add(panel5);
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new System.Drawing.Size(874, 595);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            // 
            // ucObligationsCrud
            // 
            ucObligationsCrud.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucObligationsCrud.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsCrud.Location = new System.Drawing.Point(0, 75);
            ucObligationsCrud.Name = "ucObligationsCrud";
            ucObligationsCrud.Size = new System.Drawing.Size(874, 477);
            ucObligationsCrud.TabIndex = 24;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCrudSubmit);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 552);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(874, 43);
            panel2.TabIndex = 23;
            // 
            // btnCrudSubmit
            // 
            btnCrudSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCrudSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCrudSubmit.Location = new System.Drawing.Point(666, 7);
            btnCrudSubmit.Name = "btnCrudSubmit";
            btnCrudSubmit.Size = new System.Drawing.Size(200, 30);
            btnCrudSubmit.TabIndex = 1;
            btnCrudSubmit.Text = "Submit";
            btnCrudSubmit.UseVisualStyleBackColor = true;
            btnCrudSubmit.Click += btnCrudSubmit_Click;
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = System.Drawing.SystemColors.Control;
            toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnCrudBack });
            toolStrip3.Location = new System.Drawing.Point(0, 40);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Padding = new System.Windows.Forms.Padding(4);
            toolStrip3.Size = new System.Drawing.Size(874, 35);
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
            // panel5
            // 
            panel5.Controls.Add(lblCrudStat);
            panel5.Dock = System.Windows.Forms.DockStyle.Top;
            panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            panel5.Size = new System.Drawing.Size(874, 40);
            panel5.TabIndex = 25;
            // 
            // lblCrudStat
            // 
            lblCrudStat.AutoSize = true;
            lblCrudStat.Dock = System.Windows.Forms.DockStyle.Left;
            lblCrudStat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblCrudStat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCrudStat.Location = new System.Drawing.Point(20, 10);
            lblCrudStat.Name = "lblCrudStat";
            lblCrudStat.Size = new System.Drawing.Size(197, 21);
            lblCrudStat.TabIndex = 0;
            lblCrudStat.Text = "Obligation Request CRUD";
            // 
            // tbPgView
            // 
            tbPgView.BackColor = System.Drawing.SystemColors.Control;
            tbPgView.Controls.Add(ucObligationsView);
            tbPgView.Controls.Add(toolStrip4);
            tbPgView.Location = new System.Drawing.Point(4, 24);
            tbPgView.Name = "tbPgView";
            tbPgView.Size = new System.Drawing.Size(874, 595);
            tbPgView.TabIndex = 2;
            tbPgView.Text = "tbPgView";
            // 
            // ucObligationsView
            // 
            ucObligationsView.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucObligationsView.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsView.Location = new System.Drawing.Point(0, 47);
            ucObligationsView.Name = "ucObligationsView";
            ucObligationsView.Size = new System.Drawing.Size(874, 548);
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
            toolStrip4.Size = new System.Drawing.Size(874, 47);
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
            // tbPgReview
            // 
            tbPgReview.BackColor = System.Drawing.SystemColors.Control;
            tbPgReview.Controls.Add(ucObligationsAudit);
            tbPgReview.Controls.Add(flowLayoutPanel2);
            tbPgReview.Controls.Add(toolStrip5);
            tbPgReview.Location = new System.Drawing.Point(4, 24);
            tbPgReview.Name = "tbPgReview";
            tbPgReview.Size = new System.Drawing.Size(874, 595);
            tbPgReview.TabIndex = 3;
            tbPgReview.Text = "tbPgReview";
            // 
            // ucObligationsAudit
            // 
            ucObligationsAudit.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            ucObligationsAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            ucObligationsAudit.Location = new System.Drawing.Point(0, 47);
            ucObligationsAudit.Name = "ucObligationsAudit";
            ucObligationsAudit.Size = new System.Drawing.Size(874, 505);
            ucObligationsAudit.TabIndex = 26;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnApprove);
            flowLayoutPanel2.Controls.Add(btnDisapprove);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 552);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            flowLayoutPanel2.Size = new System.Drawing.Size(874, 43);
            flowLayoutPanel2.TabIndex = 25;
            // 
            // btnApprove
            // 
            btnApprove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnApprove.Image = Properties.Resources.button_ok_16px;
            btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnApprove.Location = new System.Drawing.Point(763, 7);
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
            btnDisapprove.Location = new System.Drawing.Point(657, 7);
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
            btnCancel.Image = Properties.Resources.symbolForbidden16px;
            btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnCancel.Location = new System.Drawing.Point(551, 7);
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
            toolStrip5.Size = new System.Drawing.Size(874, 47);
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
            toolStripLabel2.Size = new System.Drawing.Size(207, 24);
            toolStripLabel2.Text = "Review Obligation Request";
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
            ClientSize = new System.Drawing.Size(882, 623);
            Controls.Add(customTabControl1);
            MinimizeBox = false;
            Name = "frmObligations";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmObligations";
            Load += frmObligations_Load;
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            tbPgMain.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            tbPgCrud.ResumeLayout(false);
            tbPgCrud.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tbPgView.ResumeLayout(false);
            tbPgView.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            tbPgReview.ResumeLayout(false);
            tbPgReview.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            toolStrip5.ResumeLayout(false);
            toolStrip5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgMain;
        private System.Windows.Forms.TabPage tbPgCrud;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCreate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnUpdate;
        private System.Windows.Forms.ToolStripButton tlStrpBtnView;
        private System.Windows.Forms.ToolStripButton tlStrpBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlStrpBtnReview;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radPending;
        private System.Windows.Forms.RadioButton radApproved;
        private System.Windows.Forms.RadioButton radDisapproved;
        private System.Windows.Forms.RadioButton radCancelled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbPgView;
        private System.Windows.Forms.TabPage tbPgReview;
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblCrudStat;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tlStrpBtnCrudBack;
    }
}
