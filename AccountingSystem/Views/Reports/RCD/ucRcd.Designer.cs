namespace LFS.Views.Reports.Rcd
{
    partial class ucRcd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            label1 = new System.Windows.Forms.Label();
            txtReportNo = new System.Windows.Forms.TextBox();
            cmbxFunds = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            dtDate = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtAccountableOfficer = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            dgvCollections = new System.Windows.Forms.DataGridView();
            label7 = new System.Windows.Forms.Label();
            dgvDeposits = new System.Windows.Forms.DataGridView();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvCollections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeposits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(4, 38);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Report No.*";
            // 
            // txtReportNo
            // 
            txtReportNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtReportNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtReportNo.Location = new System.Drawing.Point(125, 31);
            txtReportNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtReportNo.Name = "txtReportNo";
            txtReportNo.Size = new System.Drawing.Size(376, 23);
            txtReportNo.TabIndex = 1;
            txtReportNo.Validating += txtReportNo_Validating;
            txtReportNo.Validated += txtReportNo_Validated;
            // 
            // cmbxFunds
            // 
            cmbxFunds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFunds.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbxFunds.FormattingEnabled = true;
            cmbxFunds.Location = new System.Drawing.Point(125, 60);
            cmbxFunds.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbxFunds.Name = "cmbxFunds";
            cmbxFunds.Size = new System.Drawing.Size(354, 23);
            cmbxFunds.TabIndex = 2;
            cmbxFunds.Validating += cmbxFunds_Validating;
            cmbxFunds.Validated += cmbxFunds_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Location = new System.Drawing.Point(4, 66);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 0;
            label2.Text = "Fund";
            // 
            // dtDate
            // 
            dtDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDate.CustomFormat = "MMM dd, yyyy";
            dtDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            dtDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDate.Location = new System.Drawing.Point(125, 89);
            dtDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtDate.Name = "dtDate";
            dtDate.Size = new System.Drawing.Size(376, 23);
            dtDate.TabIndex = 3;
            dtDate.ValueChanged += dtDate_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(4, 95);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 15);
            label3.TabIndex = 0;
            label3.Text = "Date*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Location = new System.Drawing.Point(4, 6);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(113, 15);
            label4.TabIndex = 0;
            label4.Text = "Accountable Officer";
            // 
            // txtAccountableOfficer
            // 
            txtAccountableOfficer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAccountableOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAccountableOfficer.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtAccountableOfficer.Location = new System.Drawing.Point(125, 3);
            txtAccountableOfficer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAccountableOfficer.Name = "txtAccountableOfficer";
            txtAccountableOfficer.ReadOnly = true;
            txtAccountableOfficer.Size = new System.Drawing.Size(376, 23);
            txtAccountableOfficer.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(4, 135);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 15);
            label5.TabIndex = 0;
            label5.Text = "Collections";
            // 
            // dgvCollections
            // 
            dgvCollections.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvCollections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCollections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvCollections.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCollections.Location = new System.Drawing.Point(125, 135);
            dgvCollections.Margin = new System.Windows.Forms.Padding(4, 20, 4, 3);
            dgvCollections.Name = "dgvCollections";
            dgvCollections.RowTemplate.Height = 25;
            dgvCollections.Size = new System.Drawing.Size(376, 147);
            dgvCollections.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            label7.ForeColor = System.Drawing.Color.Black;
            label7.Location = new System.Drawing.Point(4, 305);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 15);
            label7.TabIndex = 0;
            label7.Text = "Deposits";
            // 
            // dgvDeposits
            // 
            dgvDeposits.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvDeposits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDeposits.DefaultCellStyle = dataGridViewCellStyle4;
            dgvDeposits.Location = new System.Drawing.Point(125, 305);
            dgvDeposits.Margin = new System.Windows.Forms.Padding(4, 20, 4, 3);
            dgvDeposits.Name = "dgvDeposits";
            dgvDeposits.RowTemplate.Height = 25;
            dgvDeposits.Size = new System.Drawing.Size(376, 147);
            dgvDeposits.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox1.Location = new System.Drawing.Point(486, 64);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(15, 14);
            checkBox1.TabIndex = 6;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ucRcd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(checkBox1);
            Controls.Add(dgvDeposits);
            Controls.Add(dgvCollections);
            Controls.Add(dtDate);
            Controls.Add(cmbxFunds);
            Controls.Add(txtAccountableOfficer);
            Controls.Add(txtReportNo);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ucRcd";
            Size = new System.Drawing.Size(519, 461);
            ((System.ComponentModel.ISupportInitialize)dgvCollections).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDeposits).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReportNo;
        private System.Windows.Forms.ComboBox cmbxFunds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccountableOfficer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCollections;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDeposits;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
