namespace AccountingSystem.Views.Transactions.Payments
{
    partial class frmPayments
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
            panel1 = new System.Windows.Forms.Panel();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageTaxpayer = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            dgTaxpayers = new System.Windows.Forms.DataGridView();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            txtTaxpayerSearch = new System.Windows.Forms.TextBox();
            tabPageTaxDues = new System.Windows.Forms.TabPage();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            radOthers = new System.Windows.Forms.RadioButton();
            radBpl = new System.Windows.Forms.RadioButton();
            radRpt = new System.Windows.Forms.RadioButton();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnBack = new System.Windows.Forms.Button();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radTaxpayer = new System.Windows.Forms.RadioButton();
            radTaxDues = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ucRptTaxDues1 = new RealProperty.ucRptTaxDues();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageTaxpayer.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            tabPageTaxDues.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tabPagePayment.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1062, 557);
            panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPageTaxpayer);
            tabControl1.Controls.Add(tabPageTaxDues);
            tabControl1.Controls.Add(tabPagePayment);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.Location = new System.Drawing.Point(195, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new System.Drawing.Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(867, 526);
            tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl1.TabIndex = 0;
            // 
            // tabPageTaxpayer
            // 
            tabPageTaxpayer.BackColor = System.Drawing.Color.Transparent;
            tabPageTaxpayer.Controls.Add(panel2);
            tabPageTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPageTaxpayer.Location = new System.Drawing.Point(4, 5);
            tabPageTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxpayer.Name = "tabPageTaxpayer";
            tabPageTaxpayer.Size = new System.Drawing.Size(859, 517);
            tabPageTaxpayer.TabIndex = 0;
            tabPageTaxpayer.Text = "Taxpayer";
            tabPageTaxpayer.Enter += tabPageTaxpayer_Enter;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgTaxpayers);
            panel2.Controls.Add(flowLayoutPanel4);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Size = new System.Drawing.Size(859, 517);
            panel2.TabIndex = 0;
            // 
            // dgTaxpayers
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgTaxpayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgTaxpayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgTaxpayers.DefaultCellStyle = dataGridViewCellStyle8;
            dgTaxpayers.Dock = System.Windows.Forms.DockStyle.Fill;
            dgTaxpayers.Location = new System.Drawing.Point(4, 36);
            dgTaxpayers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgTaxpayers.Name = "dgTaxpayers";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgTaxpayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgTaxpayers.RowTemplate.Height = 25;
            dgTaxpayers.Size = new System.Drawing.Size(851, 478);
            dgTaxpayers.TabIndex = 2;
            dgTaxpayers.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(txtTaxpayerSearch);
            flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel4.Location = new System.Drawing.Point(4, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(851, 33);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // txtTaxpayerSearch
            // 
            txtTaxpayerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTaxpayerSearch.Location = new System.Drawing.Point(648, 3);
            txtTaxpayerSearch.Name = "txtTaxpayerSearch";
            txtTaxpayerSearch.Size = new System.Drawing.Size(200, 23);
            txtTaxpayerSearch.TabIndex = 1;
            txtTaxpayerSearch.TextChanged += txtTaxpayerSearch_TextChanged;
            // 
            // tabPageTaxDues
            // 
            tabPageTaxDues.Controls.Add(ucRptTaxDues1);
            tabPageTaxDues.Controls.Add(flowLayoutPanel3);
            tabPageTaxDues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPageTaxDues.Location = new System.Drawing.Point(4, 5);
            tabPageTaxDues.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxDues.Name = "tabPageTaxDues";
            tabPageTaxDues.Size = new System.Drawing.Size(859, 517);
            tabPageTaxDues.TabIndex = 1;
            tabPageTaxDues.Text = "Get Tax Due";
            tabPageTaxDues.UseVisualStyleBackColor = true;
            tabPageTaxDues.Enter += tabPageTaxDues_Enter;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(radOthers);
            flowLayoutPanel3.Controls.Add(radBpl);
            flowLayoutPanel3.Controls.Add(radRpt);
            flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new System.Drawing.Size(859, 27);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // radOthers
            // 
            radOthers.AutoSize = true;
            radOthers.Location = new System.Drawing.Point(795, 3);
            radOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radOthers.Name = "radOthers";
            radOthers.Size = new System.Drawing.Size(60, 19);
            radOthers.TabIndex = 2;
            radOthers.Text = "Others";
            radOthers.UseVisualStyleBackColor = true;
            radOthers.CheckedChanged += radOthers_CheckedChanged;
            // 
            // radBpl
            // 
            radBpl.AutoSize = true;
            radBpl.Location = new System.Drawing.Point(742, 3);
            radBpl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radBpl.Name = "radBpl";
            radBpl.Size = new System.Drawing.Size(45, 19);
            radBpl.TabIndex = 2;
            radBpl.Text = "BPL";
            radBpl.UseVisualStyleBackColor = true;
            radBpl.CheckedChanged += radBpl_CheckedChanged;
            // 
            // radRpt
            // 
            radRpt.AutoSize = true;
            radRpt.Checked = true;
            radRpt.Location = new System.Drawing.Point(689, 3);
            radRpt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radRpt.Name = "radRpt";
            radRpt.Size = new System.Drawing.Size(45, 19);
            radRpt.TabIndex = 2;
            radRpt.TabStop = true;
            radRpt.Text = "RPT";
            radRpt.UseVisualStyleBackColor = true;
            radRpt.CheckedChanged += radRpt_CheckedChanged;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Size = new System.Drawing.Size(859, 517);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = " ";
            tabPagePayment.UseVisualStyleBackColor = true;
            tabPagePayment.Enter += tabPagePayment_Enter;
            // 
            // ucPayment1
            // 
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPayment1.Location = new System.Drawing.Point(4, 3);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(851, 511);
            ucPayment1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnBack);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 526);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(867, 31);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(729, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(587, 3);
            btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(134, 23);
            btnNext.TabIndex = 0;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(445, 3);
            btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(134, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(radTaxpayer);
            flowLayoutPanel2.Controls.Add(radTaxDues);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 557);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // radTaxpayer
            // 
            radTaxpayer.Appearance = System.Windows.Forms.Appearance.Button;
            radTaxpayer.Checked = true;
            radTaxpayer.FlatAppearance.BorderSize = 0;
            radTaxpayer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radTaxpayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radTaxpayer.Location = new System.Drawing.Point(0, 0);
            radTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            radTaxpayer.Name = "radTaxpayer";
            radTaxpayer.Size = new System.Drawing.Size(195, 37);
            radTaxpayer.TabIndex = 5;
            radTaxpayer.TabStop = true;
            radTaxpayer.Text = "Taxpayer";
            radTaxpayer.UseVisualStyleBackColor = true;
            // 
            // radTaxDues
            // 
            radTaxDues.Appearance = System.Windows.Forms.Appearance.Button;
            radTaxDues.FlatAppearance.BorderSize = 0;
            radTaxDues.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radTaxDues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radTaxDues.Location = new System.Drawing.Point(0, 37);
            radTaxDues.Margin = new System.Windows.Forms.Padding(0);
            radTaxDues.Name = "radTaxDues";
            radTaxDues.Size = new System.Drawing.Size(195, 37);
            radTaxDues.TabIndex = 5;
            radTaxDues.Text = "Tax Dues";
            radTaxDues.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            radPayment.FlatAppearance.BorderSize = 0;
            radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayment.Location = new System.Drawing.Point(0, 74);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // ucRptTaxDues1
            // 
            ucRptTaxDues1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRptTaxDues1.Location = new System.Drawing.Point(0, 27);
            ucRptTaxDues1.Name = "ucRptTaxDues1";
            ucRptTaxDues1.Size = new System.Drawing.Size(859, 490);
            ucRptTaxDues1.TabIndex = 2;
            // 
            // frmPayments
            // 
            AcceptButton = btnNext;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            BackColor = System.Drawing.Color.White;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1062, 557);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(1078, 596);
            Name = "frmPayments";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transaction > Payments";
            Load += newFormPayments_Load;
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageTaxpayer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgTaxpayers).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            tabPageTaxDues.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            tabPagePayment.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTaxpayer;
        private System.Windows.Forms.TabPage tabPageTaxDues;
        private System.Windows.Forms.TabPage tabPagePayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radTaxpayer;
        private System.Windows.Forms.RadioButton radTaxDues;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgTaxpayers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radOthers;
        private System.Windows.Forms.RadioButton radBpl;
        private System.Windows.Forms.RadioButton radRpt;
        private ucPayment ucPayment1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox txtTaxpayerSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RealProperty.ucRptTaxDues ucRptTaxDues1;
    }
}