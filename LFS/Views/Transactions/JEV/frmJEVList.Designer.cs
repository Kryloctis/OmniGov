
namespace LFS.Views.Transactions.JEV
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
            tlStrpBtnDelete = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            tlStrpTxtSearch = new System.Windows.Forms.ToolStripTextBox();
            tlStrpBtnSearch = new System.Windows.Forms.ToolStripButton();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
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
            toolStrip2 = new System.Windows.Forms.ToolStrip();
            tlStrpCmbxLimit = new System.Windows.Forms.ToolStripComboBox();
            tlStrpBtnFilter = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgJEV).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbxFunds
            // 
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(23, 178);
            cmbxFunds.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(200, 23);
            cmbxFunds.TabIndex = 30;
            cmbxFunds.SelectionChangeCommitted += cmbxFunds_SelectionChangeCommitted;
            // 
            // cmbxJournals
            // 
            cmbxJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxJournals.FormattingEnabled = true;
            cmbxJournals.Location = new System.Drawing.Point(23, 122);
            cmbxJournals.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            cmbxJournals.Name = "cmbxJournals";
            cmbxJournals.Size = new System.Drawing.Size(200, 23);
            cmbxJournals.TabIndex = 29;
            cmbxJournals.SelectionChangeCommitted += cmbxJournals_SelectionChangeCommitted;
            // 
            // nudYear
            // 
            nudYear.Location = new System.Drawing.Point(23, 234);
            nudYear.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            nudYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1987, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.ReadOnly = true;
            nudYear.Size = new System.Drawing.Size(200, 23);
            nudYear.TabIndex = 27;
            nudYear.Value = new decimal(new int[] { 2021, 0, 0, 0 });
            nudYear.ValueChanged += nudYear_ValueChanged;
            // 
            // panel7
            // 
            panel7.Controls.Add(dgJEV);
            panel7.Controls.Add(pbLoadRecords);
            panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(0, 0);
            panel7.Name = "panel7";
            panel7.Padding = new System.Windows.Forms.Padding(4);
            panel7.Size = new System.Drawing.Size(629, 389);
            panel7.TabIndex = 9;
            // 
            // dgJEV
            // 
            dgJEV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgJEV.Dock = System.Windows.Forms.DockStyle.Fill;
            dgJEV.Location = new System.Drawing.Point(4, 9);
            dgJEV.Margin = new System.Windows.Forms.Padding(1);
            dgJEV.Name = "dgJEV";
            dgJEV.Size = new System.Drawing.Size(621, 376);
            dgJEV.TabIndex = 7;
            dgJEV.ColumnAdded += dgJEV_ColumnAdded;
            dgJEV.SelectionChanged += dgJEV_SelectionChanged;
            // 
            // pbLoadRecords
            // 
            pbLoadRecords.Dock = System.Windows.Forms.DockStyle.Top;
            pbLoadRecords.Location = new System.Drawing.Point(4, 4);
            pbLoadRecords.Name = "pbLoadRecords";
            pbLoadRecords.Size = new System.Drawing.Size(621, 5);
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
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpBtnCreate, tlStrpBtnUpdate, tlStrpBtnDelete, toolStripSeparator1, tlStrpTxtSearch, tlStrpBtnSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(882, 35);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // tlStrpBtnCreate
            // 
            tlStrpBtnCreate.Image = Properties.Resources.button_rounded_add_20px;
            tlStrpBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnCreate.Name = "tlStrpBtnCreate";
            tlStrpBtnCreate.Size = new System.Drawing.Size(65, 24);
            tlStrpBtnCreate.Text = "Create";
            // 
            // tlStrpBtnUpdate
            // 
            tlStrpBtnUpdate.Image = Properties.Resources.button_rounded_edit_20px;
            tlStrpBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnUpdate.Name = "tlStrpBtnUpdate";
            tlStrpBtnUpdate.Size = new System.Drawing.Size(69, 24);
            tlStrpBtnUpdate.Text = "Update";
            // 
            // tlStrpBtnDelete
            // 
            tlStrpBtnDelete.Image = Properties.Resources.button_rounded_remove_20px;
            tlStrpBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnDelete.Name = "tlStrpBtnDelete";
            tlStrpBtnDelete.Size = new System.Drawing.Size(64, 24);
            tlStrpBtnDelete.Text = "Delete";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tlStrpTxtSearch
            // 
            tlStrpTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tlStrpTxtSearch.Name = "tlStrpTxtSearch";
            tlStrpTxtSearch.Size = new System.Drawing.Size(200, 27);
            // 
            // tlStrpBtnSearch
            // 
            tlStrpBtnSearch.Image = Properties.Resources.find_20px;
            tlStrpBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnSearch.Name = "tlStrpBtnSearch";
            tlStrpBtnSearch.Size = new System.Drawing.Size(66, 24);
            tlStrpBtnSearch.Text = "Search";
            tlStrpBtnSearch.Click += tlStrpBtnSearch_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel4, toolStripStatusLabel11, toolStripStatusLabel6, toolStripStatusLabel10, toolStripStatusLabel8, toolStripStatusLabel12, toolStripStatusLabel9 });
            statusStrip1.Location = new System.Drawing.Point(0, 455);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(882, 22);
            statusStrip1.TabIndex = 13;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Legend: ";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
            toolStripStatusLabel2.Text = "   ";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(68, 17);
            toolStripStatusLabel4.Text = "Approved   ";
            // 
            // toolStripStatusLabel11
            // 
            toolStripStatusLabel11.BackColor = System.Drawing.Color.FromArgb(246, 169, 169);
            toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            toolStripStatusLabel11.Size = new System.Drawing.Size(16, 17);
            toolStripStatusLabel11.Text = "   ";
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new System.Drawing.Size(82, 17);
            toolStripStatusLabel6.Text = "Disapproved   ";
            // 
            // toolStripStatusLabel10
            // 
            toolStripStatusLabel10.ActiveLinkColor = System.Drawing.Color.Red;
            toolStripStatusLabel10.BackColor = System.Drawing.Color.FromArgb(255, 230, 153);
            toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            toolStripStatusLabel10.Size = new System.Drawing.Size(16, 17);
            toolStripStatusLabel10.Text = "   ";
            // 
            // toolStripStatusLabel8
            // 
            toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            toolStripStatusLabel8.Size = new System.Drawing.Size(60, 17);
            toolStripStatusLabel8.Text = "Pending   ";
            // 
            // toolStripStatusLabel12
            // 
            toolStripStatusLabel12.BackColor = System.Drawing.Color.FromArgb(200, 198, 198);
            toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            toolStripStatusLabel12.Size = new System.Drawing.Size(16, 17);
            toolStripStatusLabel12.Text = "   ";
            // 
            // toolStripStatusLabel9
            // 
            toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            toolStripStatusLabel9.Size = new System.Drawing.Size(59, 17);
            toolStripStatusLabel9.Text = "Cancelled";
            // 
            // splitContainer1
            // 
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
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new System.Drawing.Size(882, 389);
            splitContainer1.SplitterDistance = 629;
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
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20);
            panel1.Size = new System.Drawing.Size(249, 389);
            panel1.TabIndex = 13;
            // 
            // btnApplyFltr
            // 
            btnApplyFltr.Location = new System.Drawing.Point(23, 290);
            btnApplyFltr.Name = "btnApplyFltr";
            btnApplyFltr.Size = new System.Drawing.Size(200, 23);
            btnApplyFltr.TabIndex = 35;
            btnApplyFltr.Text = "Apply";
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
            flowLayoutPanel1.Size = new System.Drawing.Size(200, 51);
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
            // toolStrip2
            // 
            toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tlStrpCmbxLimit, tlStrpBtnFilter });
            toolStrip2.Location = new System.Drawing.Point(0, 35);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new System.Windows.Forms.Padding(4);
            toolStrip2.Size = new System.Drawing.Size(882, 31);
            toolStrip2.TabIndex = 15;
            toolStrip2.Text = "toolStrip2";
            // 
            // tlStrpCmbxLimit
            // 
            tlStrpCmbxLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            tlStrpCmbxLimit.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            tlStrpCmbxLimit.Name = "tlStrpCmbxLimit";
            tlStrpCmbxLimit.Size = new System.Drawing.Size(121, 23);
            // 
            // tlStrpBtnFilter
            // 
            tlStrpBtnFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tlStrpBtnFilter.Image = Properties.Resources.filter_20px;
            tlStrpBtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            tlStrpBtnFilter.Name = "tlStrpBtnFilter";
            tlStrpBtnFilter.Size = new System.Drawing.Size(56, 20);
            tlStrpBtnFilter.Text = " Filter";
            tlStrpBtnFilter.Click += tlStrpBtnFilter_Click;
            // 
            // frmJevList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(882, 477);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip2);
            Controls.Add(toolStrip1);
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
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel12;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
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
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox tlStrpCmbxLimit;
        private System.Windows.Forms.ToolStripButton tlStrpBtnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnApplyFltr;
    }
}