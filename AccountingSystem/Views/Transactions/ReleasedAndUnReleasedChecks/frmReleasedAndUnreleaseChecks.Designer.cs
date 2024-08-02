namespace AccountingSystem.Views.Transactions.ReleasedAndUnReleasedChecks
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
            toolStrip = new System.Windows.Forms.ToolStrip();
            btnAdd = new System.Windows.Forms.ToolStripButton();
            btnSearch = new System.Windows.Forms.ToolStripButton();
            txtSearch = new System.Windows.Forms.ToolStripTextBox();
            cmbxFunds = new System.Windows.Forms.ToolStripComboBox();
            cmbxBankAccounts = new System.Windows.Forms.ToolStripComboBox();
            cmbxBanks = new System.Windows.Forms.ToolStripComboBox();
            panel1 = new System.Windows.Forms.Panel();
            dgReleasedAndUnreleaseCheques = new System.Windows.Forms.DataGridView();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            lblRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            lblCreatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            lblUpdatedAt = new System.Windows.Forms.ToolStripStatusLabel();
            cbxShowReleasedChecks = new System.Windows.Forms.CheckBox();
            toolStrip.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgReleasedAndUnreleaseCheques).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = System.Drawing.SystemColors.Control;
            toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnAdd, btnSearch, txtSearch, cmbxFunds, cmbxBankAccounts, cmbxBanks });
            toolStrip.Location = new System.Drawing.Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new System.Windows.Forms.Padding(4);
            toolStrip.Size = new System.Drawing.Size(874, 39);
            toolStrip.TabIndex = 8;
            toolStrip.Text = "toolStrip1";
            toolStrip.ItemClicked += toolStrip_ItemClicked;
            // 
            // btnAdd
            // 
            btnAdd.Image = Properties.Resources.obligation_request_24px;
            btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(74, 28);
            btnAdd.Text = "Release";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnSearch.Image = Properties.Resources.find_20px;
            btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(66, 28);
            btnSearch.Text = "Search";
            btnSearch.ToolTipText = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(200, 31);
            // 
            // cmbxFunds
            // 
            cmbxFunds.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(100, 31);
            // 
            // cmbxBankAccounts
            // 
            cmbxBankAccounts.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            cmbxBankAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBankAccounts.Name = "cmbxBankAccounts";
            cmbxBankAccounts.Size = new System.Drawing.Size(200, 31);
            // 
            // cmbxBanks
            // 
            cmbxBanks.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            cmbxBanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxBanks.Name = "cmbxBanks";
            cmbxBanks.Size = new System.Drawing.Size(200, 31);
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.Controls.Add(dgReleasedAndUnreleaseCheques);
            panel1.Location = new System.Drawing.Point(0, 67);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(874, 339);
            panel1.TabIndex = 18;
            // 
            // dgReleasedAndUnreleaseCheques
            // 
            dgReleasedAndUnreleaseCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReleasedAndUnreleaseCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            dgReleasedAndUnreleaseCheques.Location = new System.Drawing.Point(4, 4);
            dgReleasedAndUnreleaseCheques.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgReleasedAndUnreleaseCheques.Name = "dgReleasedAndUnreleaseCheques";
            dgReleasedAndUnreleaseCheques.RowHeadersWidth = 51;
            dgReleasedAndUnreleaseCheques.RowTemplate.Height = 29;
            dgReleasedAndUnreleaseCheques.Size = new System.Drawing.Size(866, 331);
            dgReleasedAndUnreleaseCheques.TabIndex = 9;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1, lblRecordCount, toolStripStatusLabel4, lblCreatedAt, lblUpdatedAt });
            statusStrip.Location = new System.Drawing.Point(0, 406);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(874, 22);
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
            toolStripStatusLabel4.Size = new System.Drawing.Size(796, 17);
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
            cbxShowReleasedChecks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbxShowReleasedChecks.AutoSize = true;
            cbxShowReleasedChecks.Location = new System.Drawing.Point(725, 42);
            cbxShowReleasedChecks.Name = "cbxShowReleasedChecks";
            cbxShowReleasedChecks.Size = new System.Drawing.Size(145, 19);
            cbxShowReleasedChecks.TabIndex = 20;
            cbxShowReleasedChecks.Text = "Show Released Checks";
            cbxShowReleasedChecks.UseVisualStyleBackColor = true;
            cbxShowReleasedChecks.CheckedChanged += cbxShowReleasedChecks_CheckedChanged;
            // 
            // frmReleasedAndUnreleaseChecks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(874, 428);
            Controls.Add(panel1);
            Controls.Add(cbxShowReleasedChecks);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(890, 467);
            Name = "frmReleasedAndUnreleaseChecks";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transaction > List of Schedule of Released and Unreleased Checks";
            Load += frmReleasedAndUnreleaseChecks_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgReleasedAndUnreleaseCheques).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ComboBox cmbxFund;
        private System.Windows.Forms.ComboBox cmbxBank;
        private System.Windows.Forms.ComboBox cmbxBankAccountNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgReleasedAndUnreleaseCheques;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedAt;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedAt;
        private System.Windows.Forms.CheckBox cbxShowReleasedChecks;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripComboBox cmbxBanks;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripComboBox cmbxFunds;
        private System.Windows.Forms.ToolStripComboBox cmbxBankAccounts;
    }
}