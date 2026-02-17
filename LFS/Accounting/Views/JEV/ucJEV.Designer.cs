
namespace LFS.Views.Transactions.JEV
{
    partial class ucJev
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtPayee = new System.Windows.Forms.TextBox();
            dgAccounts = new System.Windows.Forms.DataGridView();
            txtExplanation = new System.Windows.Forms.TextBox();
            lblExplanation = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            lblPayee = new System.Windows.Forms.Label();
            txtRefNo = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel2 = new System.Windows.Forms.Panel();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxJournal = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            cstmTbCtrlJrnls = new LFS.CustomTools.CustomTabControl();
            tbPgCshRcptsJrnl = new System.Windows.Forms.TabPage();
            ucCshRcptsJrnl1 = new LFS.Views.Transactions.JEV.JournalForms.ucCshRcptsJrnl();
            tbPgGenJrnl = new System.Windows.Forms.TabPage();
            ucGenJrnl1 = new ucGenJrnl();
            tbPgCshDsbrsmntJrnl = new System.Windows.Forms.TabPage();
            ucCshDsbrsmntJrnl1 = new LFS.Views.Transactions.JEV.JournalForms.ucCshDsbrsmntJrnl();
            tbPgChkDsbrsmntJrnl = new System.Windows.Forms.TabPage();
            ucChkDsbrsmntJrnl1 = new LFS.Views.Transactions.JEV.JournalForms.ucChkDsbrsmntJrnl();
            tbPgAuthDbtAccDsbrsmntJrnl = new System.Windows.Forms.TabPage();
            ucAuthDbtAccDsbrsmntJrnl1 = new LFS.Views.Transactions.JEV.JournalForms.ucAuthDbtAccDsbrsmntJrnl();
            panel1 = new System.Windows.Forms.Panel();
            statusStrip2 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            tlStrpLblDebit = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            tlStrpLblCredit = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            tlStrpLblBlncIndctr = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnRemoveAcc = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnAddAcc = new System.Windows.Forms.ToolStripButton();
            mskTxtTransNo = new System.Windows.Forms.MaskedTextBox();
            panel4 = new System.Windows.Forms.Panel();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            mskTxtJevNo = new System.Windows.Forms.MaskedTextBox();
            lblStatIndctr = new System.Windows.Forms.Label();
            lblCreatedBy = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            tabControl2 = new System.Windows.Forms.TabControl();
            tbPgJevDetails = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            txtRemarks = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tbPgAccEntries = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)dgAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            cstmTbCtrlJrnls.SuspendLayout();
            tbPgCshRcptsJrnl.SuspendLayout();
            tbPgGenJrnl.SuspendLayout();
            tbPgCshDsbrsmntJrnl.SuspendLayout();
            tbPgChkDsbrsmntJrnl.SuspendLayout();
            tbPgAuthDbtAccDsbrsmntJrnl.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip2.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabControl2.SuspendLayout();
            tbPgJevDetails.SuspendLayout();
            panel3.SuspendLayout();
            tbPgAccEntries.SuspendLayout();
            SuspendLayout();
            // 
            // txtPayee
            // 
            txtPayee.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPayee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPayee.Location = new System.Drawing.Point(101, 131);
            txtPayee.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtPayee.MaxLength = 99;
            txtPayee.Name = "txtPayee";
            txtPayee.Size = new System.Drawing.Size(247, 23);
            txtPayee.TabIndex = 2;
            txtPayee.Validating += txtPayee_Validating;
            txtPayee.Validated += txtPayee_Validated;
            // 
            // dgAccounts
            // 
            dgAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgAccounts.Location = new System.Drawing.Point(15, 46);
            dgAccounts.Name = "dgAccounts";
            dgAccounts.RowHeadersWidth = 51;
            dgAccounts.Size = new System.Drawing.Size(712, 264);
            dgAccounts.TabIndex = 37;
            dgAccounts.CellEndEdit += dgAccounts_CellEndEdit;
            dgAccounts.CellValidating += dgAccounts_CellValidating;
            dgAccounts.CellValueChanged += dgAccounts_CellValueChanged;
            dgAccounts.CurrentCellDirtyStateChanged += dgAccounts_CurrentCellDirtyStateChanged;
            dgAccounts.EditingControlShowing += dgAccounts_EditingControlShowing;
            dgAccounts.SelectionChanged += dgAccounts_SelectionChanged;
            // 
            // txtExplanation
            // 
            txtExplanation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtExplanation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtExplanation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtExplanation.Location = new System.Drawing.Point(101, 7);
            txtExplanation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtExplanation.MaxLength = 250;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.Size = new System.Drawing.Size(618, 23);
            txtExplanation.TabIndex = 3;
            // 
            // lblExplanation
            // 
            lblExplanation.AutoSize = true;
            lblExplanation.Location = new System.Drawing.Point(23, 9);
            lblExplanation.Name = "lblExplanation";
            lblExplanation.Size = new System.Drawing.Size(69, 15);
            lblExplanation.TabIndex = 35;
            lblExplanation.Text = "Explanation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point(23, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(67, 15);
            label2.TabIndex = 34;
            label2.Text = "Trans. No. *";
            // 
            // dtpDateEntry
            // 
            dtpDateEntry.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtpDateEntry.CustomFormat = "MMM dd,yyyy";
            dtpDateEntry.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateEntry.Location = new System.Drawing.Point(101, 167);
            dtpDateEntry.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtpDateEntry.Name = "dtpDateEntry";
            dtpDateEntry.Size = new System.Drawing.Size(247, 23);
            dtpDateEntry.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(23, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 17);
            label1.TabIndex = 32;
            label1.Text = "JEV No.";
            // 
            // lblPayee
            // 
            lblPayee.AutoSize = true;
            lblPayee.Location = new System.Drawing.Point(23, 135);
            lblPayee.Name = "lblPayee";
            lblPayee.Size = new System.Drawing.Size(43, 15);
            lblPayee.TabIndex = 51;
            lblPayee.Text = "Payee*";
            // 
            // txtRefNo
            // 
            txtRefNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRefNo.Location = new System.Drawing.Point(101, 95);
            txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtRefNo.Name = "txtRefNo";
            txtRefNo.Size = new System.Drawing.Size(247, 23);
            txtRefNo.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(23, 99);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(46, 15);
            label7.TabIndex = 53;
            label7.Text = "Ref No.";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(cstmTbCtrlJrnls);
            splitContainer1.Size = new System.Drawing.Size(742, 202);
            splitContainer1.SplitterDistance = 371;
            splitContainer1.TabIndex = 66;
            // 
            // panel2
            // 
            panel2.Controls.Add(cmbxFunds);
            panel2.Controls.Add(cmbxJournal);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dtpDateEntry);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtRefNo);
            panel2.Controls.Add(txtPayee);
            panel2.Controls.Add(lblPayee);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(20);
            panel2.Size = new System.Drawing.Size(371, 202);
            panel2.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(101, 59);
            cmbxFunds.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(247, 23);
            cmbxFunds.TabIndex = 62;
            cmbxFunds.Validating += cmbxFunds_Validating;
            cmbxFunds.Validated += cmbxFunds_Validated;
            // 
            // cmbxJournal
            // 
            cmbxJournal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxJournal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxJournal.FormattingEnabled = true;
            cmbxJournal.Location = new System.Drawing.Point(101, 23);
            cmbxJournal.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxJournal.Name = "cmbxJournal";
            cmbxJournal.Size = new System.Drawing.Size(247, 23);
            cmbxJournal.TabIndex = 62;
            cmbxJournal.SelectedIndexChanged += cmbxJournal_SelectedIndexChanged;
            cmbxJournal.SelectionChangeCommitted += cmbxJournal_SelectionChangeCommitted;
            cmbxJournal.Validating += cmbxJournal_Validating;
            cmbxJournal.Validated += cmbxJournal_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 171);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(61, 15);
            label8.TabIndex = 61;
            label8.Text = "Date Entry";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(23, 63);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(39, 15);
            label12.TabIndex = 53;
            label12.Text = "Fund*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(23, 27);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(50, 15);
            label11.TabIndex = 53;
            label11.Text = "Journal*";
            // 
            // cstmTbCtrlJrnls
            // 
            cstmTbCtrlJrnls.Controls.Add(tbPgCshRcptsJrnl);
            cstmTbCtrlJrnls.Controls.Add(tbPgGenJrnl);
            cstmTbCtrlJrnls.Controls.Add(tbPgCshDsbrsmntJrnl);
            cstmTbCtrlJrnls.Controls.Add(tbPgChkDsbrsmntJrnl);
            cstmTbCtrlJrnls.Controls.Add(tbPgAuthDbtAccDsbrsmntJrnl);
            cstmTbCtrlJrnls.Dock = System.Windows.Forms.DockStyle.Fill;
            cstmTbCtrlJrnls.Location = new System.Drawing.Point(0, 0);
            cstmTbCtrlJrnls.Multiline = true;
            cstmTbCtrlJrnls.Name = "cstmTbCtrlJrnls";
            cstmTbCtrlJrnls.SelectedIndex = 0;
            cstmTbCtrlJrnls.Size = new System.Drawing.Size(367, 202);
            cstmTbCtrlJrnls.TabIndex = 1;
            // 
            // tbPgCshRcptsJrnl
            // 
            tbPgCshRcptsJrnl.Controls.Add(ucCshRcptsJrnl1);
            tbPgCshRcptsJrnl.Location = new System.Drawing.Point(4, 44);
            tbPgCshRcptsJrnl.Name = "tbPgCshRcptsJrnl";
            tbPgCshRcptsJrnl.Padding = new System.Windows.Forms.Padding(3);
            tbPgCshRcptsJrnl.Size = new System.Drawing.Size(359, 154);
            tbPgCshRcptsJrnl.TabIndex = 0;
            tbPgCshRcptsJrnl.Text = "tbPgCshRcptsJrnl";
            tbPgCshRcptsJrnl.UseVisualStyleBackColor = true;
            // 
            // ucCshRcptsJrnl1
            // 
            ucCshRcptsJrnl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucCshRcptsJrnl1.BackColor = System.Drawing.Color.Transparent;
            ucCshRcptsJrnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCshRcptsJrnl1.Location = new System.Drawing.Point(3, 3);
            ucCshRcptsJrnl1.Name = "ucCshRcptsJrnl1";
            ucCshRcptsJrnl1.Padding = new System.Windows.Forms.Padding(20);
            ucCshRcptsJrnl1.Size = new System.Drawing.Size(353, 148);
            ucCshRcptsJrnl1.TabIndex = 1;
            // 
            // tbPgGenJrnl
            // 
            tbPgGenJrnl.Controls.Add(ucGenJrnl1);
            tbPgGenJrnl.Location = new System.Drawing.Point(4, 44);
            tbPgGenJrnl.Name = "tbPgGenJrnl";
            tbPgGenJrnl.Padding = new System.Windows.Forms.Padding(3);
            tbPgGenJrnl.Size = new System.Drawing.Size(359, 154);
            tbPgGenJrnl.TabIndex = 1;
            tbPgGenJrnl.Text = "tbPgGenJrnl";
            tbPgGenJrnl.UseVisualStyleBackColor = true;
            // 
            // ucGenJrnl1
            // 
            ucGenJrnl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucGenJrnl1.BackColor = System.Drawing.Color.Transparent;
            ucGenJrnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucGenJrnl1.Location = new System.Drawing.Point(3, 3);
            ucGenJrnl1.Name = "ucGenJrnl1";
            ucGenJrnl1.Padding = new System.Windows.Forms.Padding(20);
            ucGenJrnl1.Size = new System.Drawing.Size(353, 148);
            ucGenJrnl1.TabIndex = 0;
            // 
            // tbPgCshDsbrsmntJrnl
            // 
            tbPgCshDsbrsmntJrnl.Controls.Add(ucCshDsbrsmntJrnl1);
            tbPgCshDsbrsmntJrnl.Location = new System.Drawing.Point(4, 44);
            tbPgCshDsbrsmntJrnl.Name = "tbPgCshDsbrsmntJrnl";
            tbPgCshDsbrsmntJrnl.Padding = new System.Windows.Forms.Padding(3);
            tbPgCshDsbrsmntJrnl.Size = new System.Drawing.Size(359, 154);
            tbPgCshDsbrsmntJrnl.TabIndex = 2;
            tbPgCshDsbrsmntJrnl.Text = "tbPgCshDsbrsmntJrnl";
            tbPgCshDsbrsmntJrnl.UseVisualStyleBackColor = true;
            // 
            // ucCshDsbrsmntJrnl1
            // 
            ucCshDsbrsmntJrnl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucCshDsbrsmntJrnl1.BackColor = System.Drawing.Color.Transparent;
            ucCshDsbrsmntJrnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCshDsbrsmntJrnl1.Location = new System.Drawing.Point(3, 3);
            ucCshDsbrsmntJrnl1.Name = "ucCshDsbrsmntJrnl1";
            ucCshDsbrsmntJrnl1.Padding = new System.Windows.Forms.Padding(20);
            ucCshDsbrsmntJrnl1.Size = new System.Drawing.Size(353, 148);
            ucCshDsbrsmntJrnl1.TabIndex = 0;
            // 
            // tbPgChkDsbrsmntJrnl
            // 
            tbPgChkDsbrsmntJrnl.Controls.Add(ucChkDsbrsmntJrnl1);
            tbPgChkDsbrsmntJrnl.Location = new System.Drawing.Point(4, 44);
            tbPgChkDsbrsmntJrnl.Name = "tbPgChkDsbrsmntJrnl";
            tbPgChkDsbrsmntJrnl.Padding = new System.Windows.Forms.Padding(3);
            tbPgChkDsbrsmntJrnl.Size = new System.Drawing.Size(359, 154);
            tbPgChkDsbrsmntJrnl.TabIndex = 3;
            tbPgChkDsbrsmntJrnl.Text = "tbPgChkDsbrsmntJrnl";
            tbPgChkDsbrsmntJrnl.UseVisualStyleBackColor = true;
            // 
            // ucChkDsbrsmntJrnl1
            // 
            ucChkDsbrsmntJrnl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucChkDsbrsmntJrnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucChkDsbrsmntJrnl1.Location = new System.Drawing.Point(3, 3);
            ucChkDsbrsmntJrnl1.Name = "ucChkDsbrsmntJrnl1";
            ucChkDsbrsmntJrnl1.Padding = new System.Windows.Forms.Padding(20);
            ucChkDsbrsmntJrnl1.Size = new System.Drawing.Size(353, 148);
            ucChkDsbrsmntJrnl1.TabIndex = 0;
            // 
            // tbPgAuthDbtAccDsbrsmntJrnl
            // 
            tbPgAuthDbtAccDsbrsmntJrnl.Controls.Add(ucAuthDbtAccDsbrsmntJrnl1);
            tbPgAuthDbtAccDsbrsmntJrnl.Location = new System.Drawing.Point(4, 44);
            tbPgAuthDbtAccDsbrsmntJrnl.Name = "tbPgAuthDbtAccDsbrsmntJrnl";
            tbPgAuthDbtAccDsbrsmntJrnl.Padding = new System.Windows.Forms.Padding(3);
            tbPgAuthDbtAccDsbrsmntJrnl.Size = new System.Drawing.Size(359, 154);
            tbPgAuthDbtAccDsbrsmntJrnl.TabIndex = 4;
            tbPgAuthDbtAccDsbrsmntJrnl.Text = "tbPgAuthDbtAccDsbrsmntJrnl";
            tbPgAuthDbtAccDsbrsmntJrnl.UseVisualStyleBackColor = true;
            // 
            // ucAuthDbtAccDsbrsmntJrnl1
            // 
            ucAuthDbtAccDsbrsmntJrnl1.BackColor = System.Drawing.Color.Transparent;
            ucAuthDbtAccDsbrsmntJrnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucAuthDbtAccDsbrsmntJrnl1.Location = new System.Drawing.Point(3, 3);
            ucAuthDbtAccDsbrsmntJrnl1.Name = "ucAuthDbtAccDsbrsmntJrnl1";
            ucAuthDbtAccDsbrsmntJrnl1.Padding = new System.Windows.Forms.Padding(20);
            ucAuthDbtAccDsbrsmntJrnl1.Size = new System.Drawing.Size(353, 148);
            ucAuthDbtAccDsbrsmntJrnl1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgAccounts);
            panel1.Controls.Add(statusStrip2);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(15);
            panel1.Size = new System.Drawing.Size(742, 361);
            panel1.TabIndex = 67;
            // 
            // statusStrip2
            // 
            statusStrip2.AutoSize = false;
            statusStrip2.BackColor = System.Drawing.Color.Transparent;
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel3, tlStrpLblDebit, toolStripStatusLabel5, toolStripStatusLabel6, tlStrpLblCredit, toolStripStatusLabel1, tlStrpLblBlncIndctr });
            statusStrip2.Location = new System.Drawing.Point(15, 310);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new System.Drawing.Size(712, 36);
            statusStrip2.SizingGrip = false;
            statusStrip2.TabIndex = 51;
            statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(46, 31);
            toolStripStatusLabel3.Text = "Debit:";
            // 
            // tlStrpLblDebit
            // 
            tlStrpLblDebit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            tlStrpLblDebit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            tlStrpLblDebit.Name = "tlStrpLblDebit";
            tlStrpLblDebit.Size = new System.Drawing.Size(33, 31);
            tlStrpLblDebit.Text = "0.00";
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new System.Drawing.Size(17, 31);
            toolStripStatusLabel5.Text = "=";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            toolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(49, 31);
            toolStripStatusLabel6.Text = "Credit:";
            // 
            // tlStrpLblCredit
            // 
            tlStrpLblCredit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            tlStrpLblCredit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            tlStrpLblCredit.Name = "tlStrpLblCredit";
            tlStrpLblCredit.Size = new System.Drawing.Size(33, 31);
            tlStrpLblCredit.Text = "0.00";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(339, 31);
            toolStripStatusLabel1.Spring = true;
            // 
            // tlStrpLblBlncIndctr
            // 
            tlStrpLblBlncIndctr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            tlStrpLblBlncIndctr.Name = "tlStrpLblBlncIndctr";
            tlStrpLblBlncIndctr.Size = new System.Drawing.Size(180, 31);
            tlStrpLblBlncIndctr.Text = "No Record of Accounting Entries";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnRemoveAcc, tlStrpBtnAddAcc });
            toolStrip1.Location = new System.Drawing.Point(15, 15);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(712, 31);
            toolStrip1.TabIndex = 50;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnRemoveAcc
            // 
            tlStrpBtnRemoveAcc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnRemoveAcc.Image = Properties.Resources.symbol_cancel_16px;
            tlStrpBtnRemoveAcc.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnRemoveAcc.Name = "tlStrpBtnRemoveAcc";
            tlStrpBtnRemoveAcc.Size = new System.Drawing.Size(70, 20);
            tlStrpBtnRemoveAcc.Text = "Remove";
            tlStrpBtnRemoveAcc.Click += tlStrpBtnRemoveAcc_Click;
            // 
            // tlStrpBtnAddAcc
            // 
            tlStrpBtnAddAcc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnAddAcc.Image = Properties.Resources.symbol_add_16px;
            tlStrpBtnAddAcc.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnAddAcc.Name = "tlStrpBtnAddAcc";
            tlStrpBtnAddAcc.Size = new System.Drawing.Size(49, 20);
            tlStrpBtnAddAcc.Text = "Add";
            tlStrpBtnAddAcc.Click += tlStrpBtnAddAcc_Click;
            // 
            // mskTxtTransNo
            // 
            mskTxtTransNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mskTxtTransNo.BackColor = System.Drawing.SystemColors.Control;
            mskTxtTransNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mskTxtTransNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            mskTxtTransNo.Location = new System.Drawing.Point(23, 43);
            mskTxtTransNo.Mask = " 00-0000";
            mskTxtTransNo.Name = "mskTxtTransNo";
            mskTxtTransNo.ReadOnly = true;
            mskTxtTransNo.Size = new System.Drawing.Size(332, 23);
            mskTxtTransNo.TabIndex = 63;
            // 
            // panel4
            // 
            panel4.Controls.Add(splitContainer2);
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(756, 99);
            panel4.TabIndex = 65;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(mskTxtTransNo);
            splitContainer2.Panel1.Controls.Add(label2);
            splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(mskTxtJevNo);
            splitContainer2.Panel2.Controls.Add(lblStatIndctr);
            splitContainer2.Panel2.Controls.Add(lblCreatedBy);
            splitContainer2.Panel2.Controls.Add(lblStatus);
            splitContainer2.Panel2.Controls.Add(label1);
            splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(20);
            splitContainer2.Size = new System.Drawing.Size(756, 99);
            splitContainer2.SplitterDistance = 378;
            splitContainer2.TabIndex = 65;
            // 
            // mskTxtJevNo
            // 
            mskTxtJevNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mskTxtJevNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            mskTxtJevNo.Location = new System.Drawing.Point(23, 43);
            mskTxtJevNo.Mask = "000-0000-00-0000";
            mskTxtJevNo.Name = "mskTxtJevNo";
            mskTxtJevNo.ReadOnly = true;
            mskTxtJevNo.Size = new System.Drawing.Size(328, 23);
            mskTxtJevNo.TabIndex = 66;
            // 
            // lblStatIndctr
            // 
            lblStatIndctr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblStatIndctr.AutoSize = true;
            lblStatIndctr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblStatIndctr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatIndctr.Location = new System.Drawing.Point(338, 23);
            lblStatIndctr.Margin = new System.Windows.Forms.Padding(0);
            lblStatIndctr.Name = "lblStatIndctr";
            lblStatIndctr.Size = new System.Drawing.Size(16, 17);
            lblStatIndctr.TabIndex = 65;
            lblStatIndctr.Text = "?";
            lblStatIndctr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCreatedBy.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblCreatedBy.Location = new System.Drawing.Point(23, 68);
            lblCreatedBy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new System.Drawing.Size(328, 13);
            lblCreatedBy.TabIndex = 34;
            lblCreatedBy.Text = "Created by: --";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            lblStatus.Location = new System.Drawing.Point(133, 26);
            lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(205, 13);
            lblStatus.TabIndex = 34;
            lblStatus.Text = "Status: Draft";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lblStatus.TextChanged += lblStatus_TextChanged;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tbPgJevDetails);
            tabControl2.Controls.Add(tbPgAccEntries);
            tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl2.HotTrack = true;
            tabControl2.Location = new System.Drawing.Point(0, 99);
            tabControl2.Name = "tabControl2";
            tabControl2.Padding = new System.Drawing.Point(30, 5);
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(756, 399);
            tabControl2.TabIndex = 68;
            // 
            // tbPgJevDetails
            // 
            tbPgJevDetails.Controls.Add(panel3);
            tbPgJevDetails.Controls.Add(splitContainer1);
            tbPgJevDetails.Location = new System.Drawing.Point(4, 28);
            tbPgJevDetails.Name = "tbPgJevDetails";
            tbPgJevDetails.Padding = new System.Windows.Forms.Padding(3);
            tbPgJevDetails.Size = new System.Drawing.Size(748, 367);
            tbPgJevDetails.TabIndex = 0;
            tbPgJevDetails.Text = "Journal Details";
            tbPgJevDetails.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtRemarks);
            panel3.Controls.Add(txtExplanation);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(lblExplanation);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(3, 205);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(20, 4, 20, 4);
            panel3.Size = new System.Drawing.Size(742, 96);
            panel3.TabIndex = 69;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Location = new System.Drawing.Point(407, 69);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(309, 15);
            label4.TabIndex = 36;
            label4.Text = "Section for approval, disapproval, or cancellation remarks.";
            // 
            // txtRemarks
            // 
            txtRemarks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtRemarks.Location = new System.Drawing.Point(101, 43);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new System.Drawing.Size(618, 23);
            txtRemarks.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 45);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 15);
            label3.TabIndex = 35;
            label3.Text = "Remarks";
            // 
            // tbPgAccEntries
            // 
            tbPgAccEntries.Controls.Add(panel1);
            tbPgAccEntries.Location = new System.Drawing.Point(4, 28);
            tbPgAccEntries.Name = "tbPgAccEntries";
            tbPgAccEntries.Padding = new System.Windows.Forms.Padding(3);
            tbPgAccEntries.Size = new System.Drawing.Size(748, 367);
            tbPgAccEntries.TabIndex = 1;
            tbPgAccEntries.Text = "Accounting Entries";
            tbPgAccEntries.UseVisualStyleBackColor = true;
            // 
            // ucJev
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            Controls.Add(tabControl2);
            Controls.Add(panel4);
            Name = "ucJev";
            Size = new System.Drawing.Size(756, 498);
            ((System.ComponentModel.ISupportInitialize)dgAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            cstmTbCtrlJrnls.ResumeLayout(false);
            tbPgCshRcptsJrnl.ResumeLayout(false);
            tbPgGenJrnl.ResumeLayout(false);
            tbPgCshDsbrsmntJrnl.ResumeLayout(false);
            tbPgChkDsbrsmntJrnl.ResumeLayout(false);
            tbPgAuthDbtAccDsbrsmntJrnl.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tbPgJevDetails.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tbPgAccEntries.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.DateTimePicker dtpDateEntry;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox mskTxtTransNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlStrpBtnAddAcc;
        private System.Windows.Forms.ToolStripButton tlStrpBtnRemoveAcc;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        internal System.Windows.Forms.ToolStripStatusLabel tlStrpLblDebit;
        internal System.Windows.Forms.ToolStripStatusLabel tlStrpLblCredit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tbPgGenJrnl;
        private System.Windows.Forms.TabPage tbPgCshDsbrsmntJrnl;
        private System.Windows.Forms.TabPage tbPgChkDsbrsmntJrnl;
        private System.Windows.Forms.TabPage tbPgAuthDbtAccDsbrsmntJrnl;
        private ucGenJrnl ucGenJrnl1;
        private JournalForms.ucCshDsbrsmntJrnl ucCshDsbrsmntJrnl1;
        private JournalForms.ucChkDsbrsmntJrnl ucChkDsbrsmntJrnl1;
        private JournalForms.ucAuthDbtAccDsbrsmntJrnl ucAuthDbtAccDsbrsmntJrnl1;
        private System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.ComboBox cmbxJournal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tbPgJevDetails;
        private System.Windows.Forms.TabPage tbPgAccEntries;
        private CustomTools.CustomTabControl cstmTbCtrlJrnls;
        private System.Windows.Forms.TabPage tbPgCshRcptsJrnl;
        private JournalForms.ucCshRcptsJrnl ucCshRcptsJrnl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tlStrpLblBlncIndctr;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatIndctr;
        private System.Windows.Forms.MaskedTextBox mskTxtJevNo;
    }
}
