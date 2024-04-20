namespace AccountingSystem.Views.Reports.RCD
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
            dtCollectionsFrom = new System.Windows.Forms.DateTimePicker();
            label6 = new System.Windows.Forms.Label();
            dtCollectionsTo = new System.Windows.Forms.DateTimePicker();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            dtDepositsFrom = new System.Windows.Forms.DateTimePicker();
            dtDepositsTo = new System.Windows.Forms.DateTimePicker();
            dataGridView2 = new System.Windows.Forms.DataGridView();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            btnRefreshCollections = new System.Windows.Forms.Button();
            btnRefreshDeposits = new System.Windows.Forms.Button();
            checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            txtAccountableOfficer.Size = new System.Drawing.Size(377, 23);
            txtAccountableOfficer.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(4, 141);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(66, 15);
            label5.TabIndex = 0;
            label5.Text = "Collections";
            // 
            // dtCollectionsFrom
            // 
            dtCollectionsFrom.CustomFormat = "MMM dd, yyyy";
            dtCollectionsFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtCollectionsFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtCollectionsFrom.Location = new System.Drawing.Point(125, 137);
            dtCollectionsFrom.Margin = new System.Windows.Forms.Padding(4, 21, 4, 3);
            dtCollectionsFrom.Name = "dtCollectionsFrom";
            dtCollectionsFrom.Size = new System.Drawing.Size(123, 23);
            dtCollectionsFrom.TabIndex = 3;
            dtCollectionsFrom.ValueChanged += dtCollectionsFrom_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            label6.ForeColor = System.Drawing.Color.Black;
            label6.Location = new System.Drawing.Point(253, 141);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(15, 15);
            label6.TabIndex = 0;
            label6.Text = ">";
            // 
            // dtCollectionsTo
            // 
            dtCollectionsTo.CustomFormat = "MMM dd, yyyy";
            dtCollectionsTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtCollectionsTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtCollectionsTo.Location = new System.Drawing.Point(273, 137);
            dtCollectionsTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtCollectionsTo.Name = "dtCollectionsTo";
            dtCollectionsTo.Size = new System.Drawing.Size(123, 23);
            dtCollectionsTo.TabIndex = 3;
            dtCollectionsTo.ValueChanged += dtCollectionsTo_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new System.Drawing.Point(125, 165);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(376, 147);
            dataGridView1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            label7.ForeColor = System.Drawing.Color.Black;
            label7.Location = new System.Drawing.Point(4, 343);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(52, 15);
            label7.TabIndex = 0;
            label7.Text = "Deposits";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            label8.ForeColor = System.Drawing.Color.Black;
            label8.Location = new System.Drawing.Point(253, 341);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(15, 15);
            label8.TabIndex = 0;
            label8.Text = ">";
            // 
            // dtDepositsFrom
            // 
            dtDepositsFrom.CustomFormat = "MMM dd, yyyy";
            dtDepositsFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtDepositsFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDepositsFrom.Location = new System.Drawing.Point(125, 337);
            dtDepositsFrom.Margin = new System.Windows.Forms.Padding(4, 21, 4, 3);
            dtDepositsFrom.Name = "dtDepositsFrom";
            dtDepositsFrom.Size = new System.Drawing.Size(123, 23);
            dtDepositsFrom.TabIndex = 3;
            dtDepositsFrom.ValueChanged += dtDepositsFrom_ValueChanged;
            // 
            // dtDepositsTo
            // 
            dtDepositsTo.CustomFormat = "MMM dd, yyyy";
            dtDepositsTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtDepositsTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDepositsTo.Location = new System.Drawing.Point(273, 337);
            dtDepositsTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtDepositsTo.Name = "dtDepositsTo";
            dtDepositsTo.Size = new System.Drawing.Size(123, 23);
            dtDepositsTo.TabIndex = 3;
            dtDepositsTo.ValueChanged += dtDepositsTo_ValueChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.Location = new System.Drawing.Point(125, 365);
            dataGridView2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new System.Drawing.Size(376, 147);
            dataGridView2.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // btnRefreshCollections
            // 
            btnRefreshCollections.Image = Properties.Resources.symbol_refresh_14px;
            btnRefreshCollections.Location = new System.Drawing.Point(403, 137);
            btnRefreshCollections.Name = "btnRefreshCollections";
            btnRefreshCollections.Size = new System.Drawing.Size(100, 23);
            btnRefreshCollections.TabIndex = 5;
            btnRefreshCollections.Text = "Refresh";
            btnRefreshCollections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRefreshCollections.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnRefreshCollections.UseVisualStyleBackColor = true;
            btnRefreshCollections.Click += btnRefreshCollections_Click;
            // 
            // btnRefreshDeposits
            // 
            btnRefreshDeposits.Image = Properties.Resources.symbol_refresh_14px;
            btnRefreshDeposits.Location = new System.Drawing.Point(403, 337);
            btnRefreshDeposits.Name = "btnRefreshDeposits";
            btnRefreshDeposits.Size = new System.Drawing.Size(100, 23);
            btnRefreshDeposits.TabIndex = 5;
            btnRefreshDeposits.Text = "Refresh";
            btnRefreshDeposits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnRefreshDeposits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnRefreshDeposits.UseVisualStyleBackColor = true;
            btnRefreshDeposits.Click += btnRefreshDeposits_Click;
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
            Controls.Add(btnRefreshDeposits);
            Controls.Add(btnRefreshCollections);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(dtDepositsTo);
            Controls.Add(dtCollectionsTo);
            Controls.Add(dtDepositsFrom);
            Controls.Add(dtCollectionsFrom);
            Controls.Add(dtDate);
            Controls.Add(cmbxFunds);
            Controls.Add(txtAccountableOfficer);
            Controls.Add(txtReportNo);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ucRcd";
            Size = new System.Drawing.Size(519, 524);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtCollectionsFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtCollectionsTo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtDepositsFrom;
        private System.Windows.Forms.DateTimePicker dtDepositsTo;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRefreshCollections;
        private System.Windows.Forms.Button btnRefreshDeposits;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
