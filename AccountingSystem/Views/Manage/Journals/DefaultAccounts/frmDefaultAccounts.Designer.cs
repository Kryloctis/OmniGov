
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgDefaultAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccounts)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            // txtAccounts
            // 
            this.txtAccounts.Location = new System.Drawing.Point(224, 8);
            this.txtAccounts.Name = "txtAccounts";
            this.txtAccounts.Size = new System.Drawing.Size(204, 23);
            this.txtAccounts.TabIndex = 25;
            this.txtAccounts.TextChanged += new System.EventHandler(this.txtAccounts_TextChanged);
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(739, 8);
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
            this.label2.Location = new System.Drawing.Point(497, 11);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefaultAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDefaultAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDefaultAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDefaultAccounts.Location = new System.Drawing.Point(497, 37);
            this.dgDefaultAccounts.Name = "dgDefaultAccounts";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefaultAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgDefaultAccounts.RowTemplate.Height = 25;
            this.dgDefaultAccounts.Size = new System.Drawing.Size(420, 418);
            this.dgDefaultAccounts.TabIndex = 5;
            this.dgDefaultAccounts.SelectionChanged += new System.EventHandler(this.dgDefaultAccounts_SelectionChanged);
            // 
            // dgAccounts
            // 
            this.dgAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAccounts.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgAccounts.Location = new System.Drawing.Point(8, 37);
            this.dgAccounts.Name = "dgAccounts";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgAccounts.RowTemplate.Height = 25;
            this.dgAccounts.Size = new System.Drawing.Size(420, 418);
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
    }
}