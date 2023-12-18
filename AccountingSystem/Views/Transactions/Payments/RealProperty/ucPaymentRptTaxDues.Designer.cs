namespace AccountingSystem.Views.Transactions.Payments.RealProperty
{
    partial class ucPaymentRptTaxDues
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            chckBoxProperties = new System.Windows.Forms.CheckBox();
            dgProperties = new System.Windows.Forms.DataGridView();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            chckBxCancelled = new System.Windows.Forms.CheckBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            panel4 = new System.Windows.Forms.Panel();
            chckBxTaxDues = new System.Windows.Forms.CheckBox();
            dgTaxDues = new System.Windows.Forms.DataGridView();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            chckShowPaidUnpaid = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            txtTotalDue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            groupBox3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTaxDues).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Size = new System.Drawing.Size(975, 407);
            splitContainer1.SplitterDistance = 368;
            splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel3);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox1.Location = new System.Drawing.Point(4, 3);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(360, 401);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Properties";
            // 
            // panel3
            // 
            panel3.Controls.Add(chckBoxProperties);
            panel3.Controls.Add(dgProperties);
            panel3.Controls.Add(flowLayoutPanel4);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel3.Location = new System.Drawing.Point(2, 22);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(356, 377);
            panel3.TabIndex = 0;
            // 
            // chckBoxProperties
            // 
            chckBoxProperties.AutoSize = true;
            chckBoxProperties.BackColor = System.Drawing.Color.Transparent;
            chckBoxProperties.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            chckBoxProperties.FlatAppearance.BorderSize = 0;
            chckBoxProperties.Location = new System.Drawing.Point(5, 36);
            chckBoxProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chckBoxProperties.Name = "chckBoxProperties";
            chckBoxProperties.Size = new System.Drawing.Size(15, 14);
            chckBoxProperties.TabIndex = 8;
            chckBoxProperties.UseVisualStyleBackColor = false;
            chckBoxProperties.MouseClick += chckBoxProperties_MouseClick;
            // 
            // dgProperties
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgProperties.DefaultCellStyle = dataGridViewCellStyle2;
            dgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            dgProperties.Location = new System.Drawing.Point(0, 30);
            dgProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgProperties.Name = "dgProperties";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgProperties.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgProperties.RowTemplate.Height = 25;
            dgProperties.Size = new System.Drawing.Size(356, 347);
            dgProperties.TabIndex = 7;
            dgProperties.CellValueChanged += dgProperties_CellValueChanged;
            dgProperties.ColumnAdded += dgProperties_ColumnAdded;
            dgProperties.CurrentCellDirtyStateChanged += dgProperties_CurrentCellDirtyStateChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(chckBxCancelled);
            flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(356, 30);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // chckBxCancelled
            // 
            chckBxCancelled.Location = new System.Drawing.Point(242, 5);
            chckBxCancelled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 3);
            chckBxCancelled.Name = "chckBxCancelled";
            chckBxCancelled.Size = new System.Drawing.Size(110, 20);
            chckBxCancelled.TabIndex = 0;
            chckBxCancelled.Text = "Show Cancelled";
            chckBxCancelled.UseVisualStyleBackColor = true;
            chckBxCancelled.CheckedChanged += chckBxCancelled_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel4);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox3.Location = new System.Drawing.Point(4, 3);
            groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(2);
            groupBox3.Size = new System.Drawing.Size(595, 401);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tax Dues";
            // 
            // panel4
            // 
            panel4.Controls.Add(chckBxTaxDues);
            panel4.Controls.Add(dgTaxDues);
            panel4.Controls.Add(flowLayoutPanel5);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel4.Location = new System.Drawing.Point(2, 22);
            panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(591, 377);
            panel4.TabIndex = 0;
            // 
            // chckBxTaxDues
            // 
            chckBxTaxDues.AutoSize = true;
            chckBxTaxDues.BackColor = System.Drawing.Color.Transparent;
            chckBxTaxDues.Location = new System.Drawing.Point(4, 36);
            chckBxTaxDues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chckBxTaxDues.Name = "chckBxTaxDues";
            chckBxTaxDues.Size = new System.Drawing.Size(15, 14);
            chckBxTaxDues.TabIndex = 3;
            chckBxTaxDues.UseVisualStyleBackColor = false;
            chckBxTaxDues.MouseClick += chckBxTaxDues_MouseClick;
            // 
            // dgTaxDues
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgTaxDues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgTaxDues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgTaxDues.DefaultCellStyle = dataGridViewCellStyle5;
            dgTaxDues.Dock = System.Windows.Forms.DockStyle.Fill;
            dgTaxDues.Location = new System.Drawing.Point(0, 30);
            dgTaxDues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgTaxDues.Name = "dgTaxDues";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgTaxDues.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgTaxDues.RowTemplate.Height = 25;
            dgTaxDues.Size = new System.Drawing.Size(591, 347);
            dgTaxDues.TabIndex = 2;
            dgTaxDues.CellValueChanged += dgTaxDues_CellValueChanged;
            dgTaxDues.ColumnAdded += dgTaxDues_ColumnAdded;
            dgTaxDues.CurrentCellDirtyStateChanged += dgTaxDues_CurrentCellDirtyStateChanged;
            dgTaxDues.RowsAdded += dgTaxDues_RowsAdded;
            dgTaxDues.Validating += dgTaxDues_Validating;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(chckShowPaidUnpaid);
            flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new System.Drawing.Size(591, 30);
            flowLayoutPanel5.TabIndex = 1;
            // 
            // chckShowPaidUnpaid
            // 
            chckShowPaidUnpaid.AutoSize = true;
            chckShowPaidUnpaid.Location = new System.Drawing.Point(477, 5);
            chckShowPaidUnpaid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 3);
            chckShowPaidUnpaid.Name = "chckShowPaidUnpaid";
            chckShowPaidUnpaid.Size = new System.Drawing.Size(110, 19);
            chckShowPaidUnpaid.TabIndex = 3;
            chckShowPaidUnpaid.Text = "Show Paid Dues";
            chckShowPaidUnpaid.UseVisualStyleBackColor = true;
            chckShowPaidUnpaid.CheckedChanged += chckShowPaidUnpaid_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtTotalDue);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 407);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(975, 36);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(697, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Total Due";
            // 
            // txtTotalDue
            // 
            txtTotalDue.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            txtTotalDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotalDue.Location = new System.Drawing.Point(759, 6);
            txtTotalDue.Name = "txtTotalDue";
            txtTotalDue.ReadOnly = true;
            txtTotalDue.Size = new System.Drawing.Size(208, 23);
            txtTotalDue.TabIndex = 0;
            txtTotalDue.Text = "0.00";
            txtTotalDue.Validating += txtTotalDue_Validating;
            // 
            // ucPaymentRptTaxDues
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "ucPaymentRptTaxDues";
            Size = new System.Drawing.Size(975, 443);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgProperties).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgTaxDues).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        internal System.Windows.Forms.CheckBox chckBxCancelled;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.CheckBox chckBxTaxDues;
        internal System.Windows.Forms.DataGridView dgTaxDues;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotalDue;
        private System.Windows.Forms.CheckBox chckShowPaidUnpaid;
        internal System.Windows.Forms.CheckBox chckBoxProperties;
        internal System.Windows.Forms.DataGridView dgProperties;
    }
}
