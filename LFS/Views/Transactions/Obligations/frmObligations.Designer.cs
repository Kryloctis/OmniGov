namespace LFS.Views.Transactions.Obligations
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
            tbPgCrud = new System.Windows.Forms.TabPage();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            tlStrpBtnCreate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnUpdate = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnView = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            tlStrpBtnSearch = new System.Windows.Forms.ToolStripButton();
            tlStrpTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tlStrpBtnAudit = new System.Windows.Forms.ToolStripButton();
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpCmbxLimit = new System.Windows.Forms.ToolStripComboBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel7 = new System.Windows.Forms.Panel();
            dgJEV = new System.Windows.Forms.DataGridView();
            pbLoadRecords = new System.Windows.Forms.ProgressBar();
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
            nudYear = new System.Windows.Forms.NumericUpDown();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            cmbxJournals = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            tbPgView = new System.Windows.Forms.TabPage();
            tbPgAudit = new System.Windows.Forms.TabPage();
            customTabControl1.SuspendLayout();
            tbPgMain.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgJEV).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
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
            customTabControl1.Size = new System.Drawing.Size(826, 562);
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
            tbPgMain.Size = new System.Drawing.Size(818, 534);
            tbPgMain.TabIndex = 0;
            tbPgMain.Text = "tbPgMain";
            tbPgMain.UseVisualStyleBackColor = true;
            // 
            // tbPgCrud
            // 
            tbPgCrud.Location = new System.Drawing.Point(4, 24);
            tbPgCrud.Name = "tbPgCrud";
            tbPgCrud.Size = new System.Drawing.Size(818, 534);
            tbPgCrud.TabIndex = 1;
            tbPgCrud.Text = "tbPgCrud";
            tbPgCrud.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 512);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(818, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
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
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.AutoToolTip = false;
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new System.Drawing.Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            // 
            // tlStrpBtnView
            // 
            tlStrpBtnView.Image = Properties.Resources.details_20px;
            tlStrpBtnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnView.Name = "tlStrpBtnView";
            tlStrpBtnView.Size = new System.Drawing.Size(56, 24);
            tlStrpBtnView.Text = "View";
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.AutoToolTip = false;
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new System.Drawing.Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
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
            splitContainer1.TabIndex = 19;
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
            label2.Size = new System.Drawing.Size(93, 15);
            label2.TabIndex = 32;
            label2.Text = "Allotment Class:";
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
            // tbPgView
            // 
            tbPgView.Location = new System.Drawing.Point(4, 24);
            tbPgView.Name = "tbPgView";
            tbPgView.Size = new System.Drawing.Size(818, 534);
            tbPgView.TabIndex = 2;
            tbPgView.Text = "tbPgView";
            tbPgView.UseVisualStyleBackColor = true;
            // 
            // tbPgAudit
            // 
            tbPgAudit.Location = new System.Drawing.Point(4, 24);
            tbPgAudit.Name = "tbPgAudit";
            tbPgAudit.Size = new System.Drawing.Size(818, 534);
            tbPgAudit.TabIndex = 3;
            tbPgAudit.Text = "tbPgAudit";
            tbPgAudit.UseVisualStyleBackColor = true;
            // 
            // frmObligations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(826, 562);
            Controls.Add(customTabControl1);
            MinimizeBox = false;
            Name = "frmObligations";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Budget > Obligations";
            customTabControl1.ResumeLayout(false);
            tbPgMain.ResumeLayout(false);
            tbPgMain.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgJEV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
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
        internal System.Windows.Forms.DataGridView dgJEV;
        private System.Windows.Forms.ProgressBar pbLoadRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplyFltr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radPending;
        private System.Windows.Forms.RadioButton radApproved;
        private System.Windows.Forms.RadioButton radDisapproved;
        private System.Windows.Forms.RadioButton radCancelled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.ComboBox cmbxJournals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tbPgView;
        private System.Windows.Forms.TabPage tbPgAudit;
    }
}