
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class frmJEV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJEV));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelJournals = new System.Windows.Forms.FlowLayoutPanel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.FPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.AutoSize = true;
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(851, 39);
            this.flowLayoutPanelFunds.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnDelete,
            this.btnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 50);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 47);
            this.btnAdd.Text = "&Add...";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AccountingSystem.Properties.Resources.save28px;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 47);
            this.btnSave.Text = "&Save Journal";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 47);
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearch.Image = global::AccountingSystem.Properties.Resources.find_doc;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 47);
            this.btnSearch.Text = "S&earch";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 61);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funds";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.flowLayoutPanelJournals);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 94);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Journals";
            // 
            // flowLayoutPanelJournals
            // 
            this.flowLayoutPanelJournals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelJournals.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelJournals.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelJournals.Name = "flowLayoutPanelJournals";
            this.flowLayoutPanelJournals.Size = new System.Drawing.Size(851, 72);
            this.flowLayoutPanelJournals.TabIndex = 0;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(138, 222);
            this.maskedTextBox1.Mask = "00-0000-00-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(315, 23);
            this.maskedTextBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "JEV No.";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(554, 222);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(315, 23);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Date of Entry";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Explanation";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(554, 251);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(315, 52);
            this.textBox1.TabIndex = 16;
            // 
            // dgAccounts
            // 
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FPP,
            this.AccountName,
            this.AccountCode,
            this.Debit,
            this.Credit});
            this.dgAccounts.Location = new System.Drawing.Point(15, 318);
            this.dgAccounts.Name = "dgAccounts";
            this.dgAccounts.RowTemplate.Height = 25;
            this.dgAccounts.Size = new System.Drawing.Size(774, 191);
            this.dgAccounts.TabIndex = 17;
            // 
            // FPP
            // 
            this.FPP.HeaderText = "FPP";
            this.FPP.Name = "FPP";
            this.FPP.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // AccountCode
            // 
            this.AccountCode.HeaderText = "Account Code";
            this.AccountCode.Name = "AccountCode";
            this.AccountCode.ReadOnly = true;
            this.AccountCode.Width = 150;
            // 
            // Debit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Debit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.Width = 150;
            // 
            // Credit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Credit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 150;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(138, 280);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(315, 23);
            this.textBox2.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Check No.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Collecting Officer";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(138, 251);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(315, 23);
            this.textBox6.TabIndex = 26;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(795, 318);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 28;
            this.btnAddAccount.Text = "Add...";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(795, 347);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 23);
            this.btnEditAccount.TabIndex = 29;
            this.btnEditAccount.Text = "Edit...";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Location = new System.Drawing.Point(795, 376);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAccount.TabIndex = 30;
            this.btnRemoveAccount.Text = "Remove";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            // 
            // frmJEV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 521);
            this.Controls.Add(this.btnRemoveAccount);
            this.Controls.Add(this.btnEditAccount);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgAccounts);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmJEV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journal Entry Voucher";
            this.Load += new System.EventHandler(this.frmJEV_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton BtnSubsidiary;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelJournals;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPP;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnRemoveAccount;
    }
}