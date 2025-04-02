namespace LFS.Views.Transactions.ReleasedAndUnReleasedChecks
{
    partial class frmReleasedAndUnreleaseChecks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleasedAndUnreleaseChecks));
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnToggleFilter = new System.Windows.Forms.ToolStripButton();
            panel1 = new System.Windows.Forms.Panel();
            dgReleasedAndUnreleaseCheques = new System.Windows.Forms.DataGridView();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            cbxShowReleasedChecks = new System.Windows.Forms.CheckBox();
            pnlFilter = new System.Windows.Forms.Panel();
            cmbxBankAccountNo = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cmbxBank = new System.Windows.Forms.ComboBox();
            cmbxFund = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            btnApplyFilter = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            toolStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgReleasedAndUnreleaseCheques).BeginInit();
            statusStrip.SuspendLayout();
            pnlFilter.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnToggleFilter });
            toolStrip.Location = new System.Drawing.Point(225, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(661, 39);
            toolStrip.TabIndex = 8;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnAdd.Image = Properties.Resources.obligation_request_24px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(74, 28);
            btnAdd.Text = "Release";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnToggleFilter
            // 
            btnToggleFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            btnToggleFilter.Image = (System.Drawing.Image)resources.GetObject("btnToggleFilter.Image");
            btnToggleFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnToggleFilter.Name = "btnToggleFilter";
            btnToggleFilter.Size = new System.Drawing.Size(23, 28);
            btnToggleFilter.Text = "✕";
            btnToggleFilter.Click += btnToggleFilter_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgReleasedAndUnreleaseCheques);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(225, 39);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(661, 426);
            panel1.TabIndex = 18;
            // 
            // dgReleasedAndUnreleaseCheques
            // 
            dgReleasedAndUnreleaseCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReleasedAndUnreleaseCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            dgReleasedAndUnreleaseCheques.Location = new System.Drawing.Point(4, 9);
            dgReleasedAndUnreleaseCheques.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgReleasedAndUnreleaseCheques.Name = "dgReleasedAndUnreleaseCheques";
            dgReleasedAndUnreleaseCheques.RowHeadersWidth = 51;
            dgReleasedAndUnreleaseCheques.RowTemplate.Height = 29;
            dgReleasedAndUnreleaseCheques.Size = new System.Drawing.Size(653, 413);
            dgReleasedAndUnreleaseCheques.TabIndex = 9;
            dgReleasedAndUnreleaseCheques.SelectionChanged += dgReleasedAndUnreleaseCheques_SelectionChanged;
            // 
            // progressBar1
            // 
            progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            progressBar1.Location = new System.Drawing.Point(4, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(653, 5);
            progressBar1.TabIndex = 10;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, lblCreatedAt, lblUpdatedAt });
            statusStrip.Location = new System.Drawing.Point(0, 465);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(886, 22);
            statusStrip.TabIndex = 19;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            toolStripStatusLabel1.Text = "Records:";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(13, 17);
            lblRecordCount.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            toolStripStatusLabel4.Size = new System.Drawing.Size(808, 17);
            toolStripStatusLabel4.Spring = true;
            // 
            // lblCreatedAt
            // 
            lblCreatedAt.Name = "lblCreatedAt";
            lblCreatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // lblUpdatedAt
            // 
            lblUpdatedAt.Name = "lblUpdatedAt";
            lblUpdatedAt.Size = new System.Drawing.Size(0, 17);
            // 
            // cbxShowReleasedChecks
            // 
            cbxShowReleasedChecks.AutoSize = true;
            cbxShowReleasedChecks.Location = new System.Drawing.Point(7, 257);
            cbxShowReleasedChecks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cbxShowReleasedChecks.Name = "cbxShowReleasedChecks";
            cbxShowReleasedChecks.Size = new System.Drawing.Size(145, 19);
            cbxShowReleasedChecks.TabIndex = 20;
            cbxShowReleasedChecks.Text = "Show Released Checks";
            cbxShowReleasedChecks.UseVisualStyleBackColor = true;
            cbxShowReleasedChecks.CheckedChanged += cbxShowReleasedChecks_CheckedChanged;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(cmbxBankAccountNo);
            pnlFilter.Controls.Add(label5);
            pnlFilter.Controls.Add(cbxShowReleasedChecks);
            pnlFilter.Controls.Add(label4);
            pnlFilter.Controls.Add(label3);
            pnlFilter.Controls.Add(label2);
            pnlFilter.Controls.Add(cmbxBank);
            pnlFilter.Controls.Add(cmbxFund);
            pnlFilter.Controls.Add(label1);
            pnlFilter.Controls.Add(btnApplyFilter);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            pnlFilter.Location = new System.Drawing.Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new System.Windows.Forms.Padding(4);
            pnlFilter.Size = new System.Drawing.Size(225, 465);
            pnlFilter.TabIndex = 22;
            // 
            // cmbxBankAccountNo
            // 
            cmbxBankAccountNo.FormattingEnabled = true;
            cmbxBankAccountNo.Location = new System.Drawing.Point(7, 221);
            cmbxBankAccountNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxBankAccountNo.Name = "cmbxBankAccountNo";
            cmbxBankAccountNo.Size = new System.Drawing.Size(200, 23);
            cmbxBankAccountNo.TabIndex = 22;
            // 
            // label5
            // 
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(4, 4);
            label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(217, 36);
            label5.TabIndex = 21;
            label5.Text = "Filter";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 203);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(103, 15);
            label4.TabIndex = 4;
            label4.Text = "Bank Account No.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 152);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 15);
            label3.TabIndex = 4;
            label3.Text = "Bank";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 101);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 4;
            label2.Text = "Fund";
            // 
            // cmbxBank
            // 
            cmbxBank.FormattingEnabled = true;
            cmbxBank.Location = new System.Drawing.Point(7, 170);
            cmbxBank.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxBank.Name = "cmbxBank";
            cmbxBank.Size = new System.Drawing.Size(200, 23);
            cmbxBank.TabIndex = 3;
            cmbxBank.SelectionChangeCommitted += cmbxBank_SelectionChangeCommitted;
            // 
            // cmbxFund
            // 
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(7, 119);
            cmbxFund.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(200, 23);
            cmbxFund.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 15);
            label1.TabIndex = 2;
            label1.Text = "Search";
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new System.Drawing.Point(7, 289);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new System.Drawing.Size(200, 23);
            btnApplyFilter.TabIndex = 1;
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(7, 68);
            txtSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 23);
            txtSearch.TabIndex = 0;
            // 
            // frmReleasedAndUnreleaseChecks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(886, 487);
            Controls.Add(panel1);
            Controls.Add(toolStrip);
            Controls.Add(pnlFilter);
            Controls.Add(statusStrip);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(890, 467);
            Name = "frmReleasedAndUnreleaseChecks";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > List of Schedule of Released and Unreleased Checks";
            Load += frmReleasedAndUnreleaseChecks_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgReleasedAndUnreleaseCheques).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgReleasedAndUnreleaseCheques;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.CheckBox cbxShowReleasedChecks;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbxBank;
        private System.Windows.Forms.ComboBox cmbxFund;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton btnToggleFilter;
        private System.Windows.Forms.ComboBox cmbxBankAccountNo;
    }
}