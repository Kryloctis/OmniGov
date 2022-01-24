
namespace AccountingSystem.Views.Manage.Journals.DefaultAccounts
{
    partial class frmDefaultAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radCredit = new System.Windows.Forms.RadioButton();
            this.radDebit = new System.Windows.Forms.RadioButton();
            this.txtAccounts = new System.Windows.Forms.TextBox();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.btnRemoveDefaultAccount = new System.Windows.Forms.Button();
            this.btnSetDefaultAccount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDefaultAccounts = new System.Windows.Forms.DataGridView();
            this.dgAccounts = new System.Windows.Forms.DataGridView();
            this.lblMaxAccounts = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblJournalName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefaultAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.txtAccounts);
            this.panel1.Controls.Add(this.cmbxFunds);
            this.panel1.Controls.Add(this.btnRemoveDefaultAccount);
            this.panel1.Controls.Add(this.btnSetDefaultAccount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgDefaultAccounts);
            this.panel1.Controls.Add(this.dgAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(925, 463);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.radCredit);
            this.panel4.Controls.Add(this.radDebit);
            this.panel4.Location = new System.Drawing.Point(495, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(122, 25);
            this.panel4.TabIndex = 26;
            // 
            // radCredit
            // 
            this.radCredit.AutoSize = true;
            this.radCredit.Location = new System.Drawing.Point(62, 3);
            this.radCredit.Name = "radCredit";
            this.radCredit.Size = new System.Drawing.Size(57, 19);
            this.radCredit.TabIndex = 0;
            this.radCredit.TabStop = true;
            this.radCredit.Text = "Credit";
            this.radCredit.UseVisualStyleBackColor = true;
            this.radCredit.CheckedChanged += new System.EventHandler(this.radCredit_CheckedChanged);
            // 
            // radDebit
            // 
            this.radDebit.AutoSize = true;
            this.radDebit.Checked = true;
            this.radDebit.Location = new System.Drawing.Point(3, 3);
            this.radDebit.Name = "radDebit";
            this.radDebit.Size = new System.Drawing.Size(53, 19);
            this.radDebit.TabIndex = 0;
            this.radDebit.TabStop = true;
            this.radDebit.Text = "Debit";
            this.radDebit.UseVisualStyleBackColor = true;
            this.radDebit.CheckedChanged += new System.EventHandler(this.radDebit_CheckedChanged);
            // 
            // txtAccounts
            // 
            this.txtAccounts.Location = new System.Drawing.Point(224, 28);
            this.txtAccounts.Name = "txtAccounts";
            this.txtAccounts.Size = new System.Drawing.Size(204, 23);
            this.txtAccounts.TabIndex = 25;
            this.txtAccounts.TextChanged += new System.EventHandler(this.txtAccounts_TextChanged);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(739, 28);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(178, 23);
            this.cmbxFunds.TabIndex = 24;
            this.cmbxFunds.SelectionChangeCommitted += new System.EventHandler(this.cmbxFunds_SelectionChangeCommitted);
            this.cmbxFunds.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFunds_Validating);
            this.cmbxFunds.Validated += new System.EventHandler(this.cmbxFunds_Validated);
            // 
            // btnRemoveDefaultAccount
            // 
            this.btnRemoveDefaultAccount.Location = new System.Drawing.Point(434, 239);
            this.btnRemoveDefaultAccount.Name = "btnRemoveDefaultAccount";
            this.btnRemoveDefaultAccount.Size = new System.Drawing.Size(57, 23);
            this.btnRemoveDefaultAccount.TabIndex = 23;
            this.btnRemoveDefaultAccount.Text = "x";
            this.btnRemoveDefaultAccount.UseVisualStyleBackColor = true;
            this.btnRemoveDefaultAccount.Click += new System.EventHandler(this.btnRemoveDefaultAccount_Click);
            // 
            // btnSetDefaultAccount
            // 
            this.btnSetDefaultAccount.Location = new System.Drawing.Point(434, 210);
            this.btnSetDefaultAccount.Name = "btnSetDefaultAccount";
            this.btnSetDefaultAccount.Size = new System.Drawing.Size(57, 23);
            this.btnSetDefaultAccount.TabIndex = 22;
            this.btnSetDefaultAccount.Text = ">";
            this.btnSetDefaultAccount.UseVisualStyleBackColor = true;
            this.btnSetDefaultAccount.Click += new System.EventHandler(this.btnSetDefaultAccount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Default Accounts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Accounts";
            // 
            // dgDefaultAccounts
            // 
            this.dgDefaultAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefaultAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgDefaultAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDefaultAccounts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgDefaultAccounts.Location = new System.Drawing.Point(497, 57);
            this.dgDefaultAccounts.Name = "dgDefaultAccounts";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefaultAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgDefaultAccounts.RowTemplate.Height = 25;
            this.dgDefaultAccounts.Size = new System.Drawing.Size(420, 398);
            this.dgDefaultAccounts.TabIndex = 5;
            this.dgDefaultAccounts.SelectionChanged += new System.EventHandler(this.dgDefaultAccounts_SelectionChanged);
            // 
            // dgAccounts
            // 
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccounts.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgAccounts.Location = new System.Drawing.Point(8, 57);
            this.dgAccounts.Name = "dgAccounts";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgAccounts.RowTemplate.Height = 25;
            this.dgAccounts.Size = new System.Drawing.Size(420, 398);
            this.dgAccounts.TabIndex = 4;
            this.dgAccounts.SelectionChanged += new System.EventHandler(this.dgAccounts_SelectionChanged);
            // 
            // lblMaxAccounts
            // 
            this.lblMaxAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxAccounts.Location = new System.Drawing.Point(810, 9);
            this.lblMaxAccounts.Name = "lblMaxAccounts";
            this.lblMaxAccounts.Size = new System.Drawing.Size(107, 15);
            this.lblMaxAccounts.TabIndex = 24;
            this.lblMaxAccounts.Text = "Max: --";
            this.lblMaxAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 496);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 30);
            this.panel2.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(810, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AccountingSystem.Properties.Resources.save14px;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(697, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblJournalName
            // 
            this.lblJournalName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblJournalName.Location = new System.Drawing.Point(62, 9);
            this.lblJournalName.Name = "lblJournalName";
            this.lblJournalName.Size = new System.Drawing.Size(346, 15);
            this.lblJournalName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Journal:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblMaxAccounts);
            this.panel3.Controls.Add(this.lblJournalName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(925, 33);
            this.panel3.TabIndex = 4;
            // 
            // frmDefaultAccounts
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(925, 526);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDefaultAccounts";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default Accounts";
            this.Load += new System.EventHandler(this.frmDefaultAccounts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefaultAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveDefaultAccount;
        private System.Windows.Forms.Button btnSetDefaultAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDefaultAccounts;
        private System.Windows.Forms.DataGridView dgAccounts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblJournalName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMaxAccounts;
        private System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.TextBox txtAccounts;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radCredit;
        private System.Windows.Forms.RadioButton radDebit;
    }
}