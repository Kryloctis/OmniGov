namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    partial class frmCattleOwnership
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
            bgwSavingPayment = new System.ComponentModel.BackgroundWorker();
            radPayee = new System.Windows.Forms.RadioButton();
            radFees = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            btnCancel = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            bgwPayee = new System.ComponentModel.BackgroundWorker();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPagePayee = new System.Windows.Forms.TabPage();
            tabControlPayee = new System.Windows.Forms.TabControl();
            tabPayeeList = new System.Windows.Forms.TabPage();
            dgPayees = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            btnNew = new System.Windows.Forms.ToolStripButton();
            tabNewPayee = new System.Windows.Forms.TabPage();
            ucTaxPayers1 = new Manage.TaxPayers.ucTaxPayers();
            panel1 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            btnBack = new System.Windows.Forms.ToolStripButton();
            tabPageFees = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ucCattleOwnership1 = new ucCattleOwnership();
            ucOtherCharges1 = new ucOtherCharges();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPagePayee.SuspendLayout();
            tabControlPayee.SuspendLayout();
            tabPayeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgPayees).BeginInit();
            toolStrip1.SuspendLayout();
            tabNewPayee.SuspendLayout();
            panel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            tabPageFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // bgwSavingPayment
            // 
            bgwSavingPayment.WorkerReportsProgress = true;
            bgwSavingPayment.WorkerSupportsCancellation = true;
            bgwSavingPayment.DoWork += bgwSavingPayment_DoWork;
            bgwSavingPayment.ProgressChanged += bgwSavingPayment_ProgressChanged;
            bgwSavingPayment.RunWorkerCompleted += bgwSavingPayment_RunWorkerCompleted;
            // 
            // radPayee
            // 
            radPayee.Appearance = System.Windows.Forms.Appearance.Button;
            radPayee.Checked = true;
            radPayee.FlatAppearance.BorderSize = 0;
            radPayee.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayee.Location = new System.Drawing.Point(0, 0);
            radPayee.Margin = new System.Windows.Forms.Padding(0);
            radPayee.Name = "radPayee";
            radPayee.Size = new System.Drawing.Size(195, 37);
            radPayee.TabIndex = 5;
            radPayee.TabStop = true;
            radPayee.Text = "Payee";
            radPayee.UseVisualStyleBackColor = true;
            // 
            // radFees
            // 
            radFees.Appearance = System.Windows.Forms.Appearance.Button;
            radFees.FlatAppearance.BorderSize = 0;
            radFees.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFees.Location = new System.Drawing.Point(0, 37);
            radFees.Margin = new System.Windows.Forms.Padding(0);
            radFees.Name = "radFees";
            radFees.Size = new System.Drawing.Size(195, 37);
            radFees.TabIndex = 5;
            radFees.Text = "Fees && Charges";
            radFees.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            radPayment.FlatAppearance.BorderSize = 0;
            radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayment.Location = new System.Drawing.Point(0, 74);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(832, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNextMain
            // 
            btnNextMain.Location = new System.Drawing.Point(690, 3);
            btnNextMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNextMain.Name = "btnNextMain";
            btnNextMain.Size = new System.Drawing.Size(134, 23);
            btnNextMain.TabIndex = 0;
            btnNextMain.Text = "Next";
            btnNextMain.UseVisualStyleBackColor = true;
            btnNextMain.Click += btnNextMain_Click;
            // 
            // btnBackMain
            // 
            btnBackMain.Location = new System.Drawing.Point(548, 3);
            btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBackMain.Name = "btnBackMain";
            btnBackMain.Size = new System.Drawing.Size(134, 23);
            btnBackMain.TabIndex = 0;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBackMain_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNextMain);
            flowLayoutPanel1.Controls.Add(btnBackMain);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 526);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(970, 31);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // bgwPayee
            // 
            bgwPayee.WorkerReportsProgress = true;
            bgwPayee.WorkerSupportsCancellation = true;
            bgwPayee.DoWork += bgwPayee_DoWork;
            bgwPayee.ProgressChanged += bgwPayee_ProgressChanged;
            bgwPayee.RunWorkerCompleted += bgwPayee_RunWorkerCompleted;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(3);
            tabPagePayment.Size = new System.Drawing.Size(962, 548);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = "tabPagePayment";
            tabPagePayment.UseVisualStyleBackColor = true;
            tabPagePayment.Enter += tabPagePayment_Enter;
            // 
            // ucPayment1
            // 
            ucPayment1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Location = new System.Drawing.Point(3, 3);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(956, 515);
            ucPayment1.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPagePayee);
            tabControlMain.Controls.Add(tabPageFees);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new System.Drawing.Point(0, 0);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(970, 557);
            tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlMain.TabIndex = 12;
            // 
            // tabPagePayee
            // 
            tabPagePayee.Controls.Add(tabControlPayee);
            tabPagePayee.Location = new System.Drawing.Point(4, 5);
            tabPagePayee.Margin = new System.Windows.Forms.Padding(0);
            tabPagePayee.Name = "tabPagePayee";
            tabPagePayee.Size = new System.Drawing.Size(962, 548);
            tabPagePayee.TabIndex = 0;
            tabPagePayee.Text = "tabPagePayee";
            tabPagePayee.UseVisualStyleBackColor = true;
            tabPagePayee.Enter += tabPagePayee_Enter;
            // 
            // tabControlPayee
            // 
            tabControlPayee.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlPayee.Controls.Add(tabPayeeList);
            tabControlPayee.Controls.Add(tabNewPayee);
            tabControlPayee.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPayee.ItemSize = new System.Drawing.Size(0, 1);
            tabControlPayee.Location = new System.Drawing.Point(0, 0);
            tabControlPayee.Margin = new System.Windows.Forms.Padding(0);
            tabControlPayee.Name = "tabControlPayee";
            tabControlPayee.Padding = new System.Drawing.Point(0, 0);
            tabControlPayee.SelectedIndex = 0;
            tabControlPayee.Size = new System.Drawing.Size(962, 548);
            tabControlPayee.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlPayee.TabIndex = 1;
            // 
            // tabPayeeList
            // 
            tabPayeeList.Controls.Add(dgPayees);
            tabPayeeList.Controls.Add(progressBar1);
            tabPayeeList.Controls.Add(toolStrip1);
            tabPayeeList.Location = new System.Drawing.Point(4, 5);
            tabPayeeList.Margin = new System.Windows.Forms.Padding(0);
            tabPayeeList.Name = "tabPayeeList";
            tabPayeeList.Size = new System.Drawing.Size(954, 539);
            tabPayeeList.TabIndex = 0;
            tabPayeeList.Text = "tabPayeeList";
            tabPayeeList.UseVisualStyleBackColor = true;
            tabPayeeList.Enter += tabPayeeList_Enter;
            // 
            // dgPayees
            // 
            dgPayees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPayees.Dock = System.Windows.Forms.DockStyle.Fill;
            dgPayees.Location = new System.Drawing.Point(0, 43);
            dgPayees.Name = "dgPayees";
            dgPayees.RowTemplate.Height = 25;
            dgPayees.Size = new System.Drawing.Size(954, 496);
            dgPayees.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(0, 38);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(954, 5);
            progressBar1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.Transparent;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSearch, txtSearch, btnNew });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(954, 38);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.user_browse_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(46, 35);
            btnSearch.Text = "Search";
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.MaxLength = 999999999;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 38);
            // 
            // btnNew
            // 
            btnNew.Image = Properties.Resources.create_new_20px;
            btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new System.Drawing.Size(35, 35);
            btnNew.Text = "New";
            btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnNew.Click += btnNew_Click;
            // 
            // tabNewPayee
            // 
            tabNewPayee.Controls.Add(ucTaxPayers1);
            tabNewPayee.Controls.Add(panel1);
            tabNewPayee.Controls.Add(toolStrip2);
            tabNewPayee.Location = new System.Drawing.Point(4, 5);
            tabNewPayee.Margin = new System.Windows.Forms.Padding(0);
            tabNewPayee.Name = "tabNewPayee";
            tabNewPayee.Size = new System.Drawing.Size(954, 539);
            tabNewPayee.TabIndex = 1;
            tabNewPayee.Text = "tabNewPayee";
            tabNewPayee.UseVisualStyleBackColor = true;
            tabNewPayee.Enter += tabNewPayee_Enter;
            // 
            // ucTaxPayers1
            // 
            ucTaxPayers1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucTaxPayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxPayers1.Location = new System.Drawing.Point(0, 233);
            ucTaxPayers1.Name = "ucTaxPayers1";
            ucTaxPayers1.Padding = new System.Windows.Forms.Padding(50, 10, 50, 50);
            ucTaxPayers1.Size = new System.Drawing.Size(954, 306);
            ucTaxPayers1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 38);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            panel1.Size = new System.Drawing.Size(954, 195);
            panel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(137, 151);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(109, 25);
            label4.TabIndex = 4;
            label4.Text = "New Payee";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(137, 176);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(148, 15);
            label3.TabIndex = 4;
            label3.Text = "Provide information below";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(2752, 178);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(205, 17);
            label2.TabIndex = 2;
            label2.Text = "Provide payee details to proceed.";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(2893, 153);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 25);
            label1.TabIndex = 3;
            label1.Text = "Payee";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.Color.Transparent;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnBack });
            toolStrip2.Location = new System.Drawing.Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new System.Drawing.Size(954, 38);
            toolStrip2.TabIndex = 2;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnBack
            // 
            btnBack.Image = Properties.Resources.arrow_left_20px;
            btnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(36, 35);
            btnBack.Text = "Back";
            btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnBack.Click += btnBack_Click;
            // 
            // tabPageFees
            // 
            tabPageFees.Controls.Add(splitContainer1);
            tabPageFees.Location = new System.Drawing.Point(4, 5);
            tabPageFees.Name = "tabPageFees";
            tabPageFees.Padding = new System.Windows.Forms.Padding(3);
            tabPageFees.Size = new System.Drawing.Size(962, 548);
            tabPageFees.TabIndex = 1;
            tabPageFees.Text = "tabPageFees";
            tabPageFees.UseVisualStyleBackColor = true;
            tabPageFees.Enter += tabPageFees_Enter;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.Location = new System.Drawing.Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ucCattleOwnership1);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ucOtherCharges1);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            splitContainer1.Size = new System.Drawing.Size(956, 512);
            splitContainer1.SplitterDistance = 171;
            splitContainer1.TabIndex = 3;
            // 
            // ucCattleOwnership1
            // 
            ucCattleOwnership1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ucCattleOwnership1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucCattleOwnership1.Location = new System.Drawing.Point(3, 3);
            ucCattleOwnership1.Name = "ucCattleOwnership1";
            ucCattleOwnership1.Size = new System.Drawing.Size(950, 165);
            ucCattleOwnership1.TabIndex = 0;
            // 
            // ucOtherCharges1
            // 
            ucOtherCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucOtherCharges1.Location = new System.Drawing.Point(3, 3);
            ucOtherCharges1.Margin = new System.Windows.Forms.Padding(0);
            ucOtherCharges1.Name = "ucOtherCharges1";
            ucOtherCharges1.Size = new System.Drawing.Size(950, 331);
            ucOtherCharges1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(radPayee);
            flowLayoutPanel2.Controls.Add(radFees);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 557);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // frmCattleOwnership
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1165, 557);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel2);
            MinimizeBox = false;
            Name = "frmCattleOwnership";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payment > AF 33 - Cattle Ownership";
            Load += frmCattleOwnership_Load;
            flowLayoutPanel1.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPagePayee.ResumeLayout(false);
            tabControlPayee.ResumeLayout(false);
            tabPayeeList.ResumeLayout(false);
            tabPayeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgPayees).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabNewPayee.ResumeLayout(false);
            tabNewPayee.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            tabPageFees.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwSavingPayment;
        private System.Windows.Forms.RadioButton radPayee;
        private System.Windows.Forms.RadioButton radFees;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker bgwPayee;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePayee;
        private System.Windows.Forms.TabControl tabControlPayee;
        private System.Windows.Forms.TabPage tabPayeeList;
        private System.Windows.Forms.DataGridView dgPayees;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.TabPage tabNewPayee;
        private Manage.TaxPayers.ucTaxPayers ucTaxPayers1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnBack;
        private System.Windows.Forms.TabPage tabPageFees;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucOtherCharges ucOtherCharges1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        internal ucCattleOwnership ucCattleOwnership1;
    }
}