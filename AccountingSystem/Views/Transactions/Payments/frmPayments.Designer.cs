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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTaxpayer = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgTaxpayers = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTaxpayerSearch = new System.Windows.Forms.TextBox();
            this.tabPageTaxDues = new System.Windows.Forms.TabPage();
            this.tabControlTaxDues = new System.Windows.Forms.TabControl();
            this.tabPageRpt = new System.Windows.Forms.TabPage();
            this.ucRptTaxDues1 = new AccountingSystem.Views.Transactions.Payments.RealProperty.ucRptTaxDues();
            this.tabPageBpl = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radOthers = new System.Windows.Forms.RadioButton();
            this.radBpl = new System.Windows.Forms.RadioButton();
            this.radRpt = new System.Windows.Forms.RadioButton();
            this.tabPagePayment = new System.Windows.Forms.TabPage();
            this.ucPayment1 = new AccountingSystem.Views.Transactions.Payments.ucPayment();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radTaxpayer = new System.Windows.Forms.RadioButton();
            this.radTaxDues = new System.Windows.Forms.RadioButton();
            this.radPayment = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageTaxpayer.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxpayers)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabPageTaxDues.SuspendLayout();
            this.tabControlTaxDues.SuspendLayout();
            this.tabPageRpt.SuspendLayout();
            this.tabPageBpl.SuspendLayout();
            this.tabPageOthers.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPagePayment.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 557);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPageTaxpayer);
            this.tabControl1.Controls.Add(this.tabPageTaxDues);
            this.tabControl1.Controls.Add(this.tabPagePayment);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(195, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(867, 526);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTaxpayer
            // 
            this.tabPageTaxpayer.BackColor = System.Drawing.Color.Transparent;
            this.tabPageTaxpayer.Controls.Add(this.panel2);
            this.tabPageTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageTaxpayer.Location = new System.Drawing.Point(4, 5);
            this.tabPageTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTaxpayer.Name = "tabPageTaxpayer";
            this.tabPageTaxpayer.Size = new System.Drawing.Size(859, 517);
            this.tabPageTaxpayer.TabIndex = 0;
            this.tabPageTaxpayer.Text = "Taxpayer";
            this.tabPageTaxpayer.Enter += new System.EventHandler(this.tabPageTaxpayer_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgTaxpayers);
            this.panel2.Controls.Add(this.flowLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Size = new System.Drawing.Size(859, 517);
            this.panel2.TabIndex = 0;
            // 
            // dgTaxpayers
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTaxpayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTaxpayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTaxpayers.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgTaxpayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaxpayers.Location = new System.Drawing.Point(4, 36);
            this.dgTaxpayers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgTaxpayers.Name = "dgTaxpayers";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTaxpayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgTaxpayers.RowTemplate.Height = 25;
            this.dgTaxpayers.Size = new System.Drawing.Size(851, 478);
            this.dgTaxpayers.TabIndex = 2;
            this.dgTaxpayers.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.txtTaxpayerSearch);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(4, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(851, 33);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // txtTaxpayerSearch
            // 
            this.txtTaxpayerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxpayerSearch.Location = new System.Drawing.Point(648, 3);
            this.txtTaxpayerSearch.Name = "txtTaxpayerSearch";
            this.txtTaxpayerSearch.Size = new System.Drawing.Size(200, 23);
            this.txtTaxpayerSearch.TabIndex = 1;
            this.txtTaxpayerSearch.TextChanged += new System.EventHandler(this.txtTaxpayerSearch_TextChanged);
            // 
            // tabPageTaxDues
            // 
            this.tabPageTaxDues.Controls.Add(this.tabControlTaxDues);
            this.tabPageTaxDues.Controls.Add(this.flowLayoutPanel3);
            this.tabPageTaxDues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPageTaxDues.Location = new System.Drawing.Point(4, 5);
            this.tabPageTaxDues.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageTaxDues.Name = "tabPageTaxDues";
            this.tabPageTaxDues.Size = new System.Drawing.Size(859, 517);
            this.tabPageTaxDues.TabIndex = 1;
            this.tabPageTaxDues.Text = "Get Tax Due";
            this.tabPageTaxDues.UseVisualStyleBackColor = true;
            this.tabPageTaxDues.Enter += new System.EventHandler(this.tabPageTaxDues_Enter);
            // 
            // tabControlTaxDues
            // 
            this.tabControlTaxDues.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControlTaxDues.Controls.Add(this.tabPageRpt);
            this.tabControlTaxDues.Controls.Add(this.tabPageBpl);
            this.tabControlTaxDues.Controls.Add(this.tabPageOthers);
            this.tabControlTaxDues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTaxDues.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlTaxDues.Location = new System.Drawing.Point(0, 27);
            this.tabControlTaxDues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControlTaxDues.Name = "tabControlTaxDues";
            this.tabControlTaxDues.Padding = new System.Drawing.Point(0, 1);
            this.tabControlTaxDues.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControlTaxDues.RightToLeftLayout = true;
            this.tabControlTaxDues.SelectedIndex = 0;
            this.tabControlTaxDues.Size = new System.Drawing.Size(859, 490);
            this.tabControlTaxDues.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlTaxDues.TabIndex = 0;
            // 
            // tabPageRpt
            // 
            this.tabPageRpt.Controls.Add(this.ucRptTaxDues1);
            this.tabPageRpt.Location = new System.Drawing.Point(4, 5);
            this.tabPageRpt.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageRpt.Name = "tabPageRpt";
            this.tabPageRpt.Size = new System.Drawing.Size(851, 481);
            this.tabPageRpt.TabIndex = 0;
            this.tabPageRpt.Text = "RPT";
            this.tabPageRpt.UseVisualStyleBackColor = true;
            // 
            // ucRptTaxDues1
            // 
            this.ucRptTaxDues1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucRptTaxDues1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRptTaxDues1.Location = new System.Drawing.Point(0, 0);
            this.ucRptTaxDues1.Name = "ucRptTaxDues1";
            this.ucRptTaxDues1.Size = new System.Drawing.Size(851, 481);
            this.ucRptTaxDues1.TabIndex = 0;
            // 
            // tabPageBpl
            // 
            this.tabPageBpl.Controls.Add(this.label1);
            this.tabPageBpl.Location = new System.Drawing.Point(4, 5);
            this.tabPageBpl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageBpl.Name = "tabPageBpl";
            this.tabPageBpl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageBpl.Size = new System.Drawing.Size(851, 481);
            this.tabPageBpl.TabIndex = 1;
            this.tabPageBpl.Text = "BPL";
            this.tabPageBpl.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not Available Right Now...";
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.Controls.Add(this.label2);
            this.tabPageOthers.Location = new System.Drawing.Point(4, 5);
            this.tabPageOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageOthers.Size = new System.Drawing.Size(851, 481);
            this.tabPageOthers.TabIndex = 2;
            this.tabPageOthers.Text = "Others";
            this.tabPageOthers.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Not Available Right Now...";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.radOthers);
            this.flowLayoutPanel3.Controls.Add(this.radBpl);
            this.flowLayoutPanel3.Controls.Add(this.radRpt);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(859, 27);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // radOthers
            // 
            this.radOthers.AutoSize = true;
            this.radOthers.Location = new System.Drawing.Point(795, 3);
            this.radOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radOthers.Name = "radOthers";
            this.radOthers.Size = new System.Drawing.Size(60, 19);
            this.radOthers.TabIndex = 2;
            this.radOthers.Text = "Others";
            this.radOthers.UseVisualStyleBackColor = true;
            this.radOthers.CheckedChanged += new System.EventHandler(this.radOthers_CheckedChanged);
            // 
            // radBpl
            // 
            this.radBpl.AutoSize = true;
            this.radBpl.Location = new System.Drawing.Point(742, 3);
            this.radBpl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radBpl.Name = "radBpl";
            this.radBpl.Size = new System.Drawing.Size(45, 19);
            this.radBpl.TabIndex = 2;
            this.radBpl.Text = "BPL";
            this.radBpl.UseVisualStyleBackColor = true;
            this.radBpl.CheckedChanged += new System.EventHandler(this.radBpl_CheckedChanged);
            // 
            // radRpt
            // 
            this.radRpt.AutoSize = true;
            this.radRpt.Checked = true;
            this.radRpt.Location = new System.Drawing.Point(689, 3);
            this.radRpt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radRpt.Name = "radRpt";
            this.radRpt.Size = new System.Drawing.Size(45, 19);
            this.radRpt.TabIndex = 2;
            this.radRpt.TabStop = true;
            this.radRpt.Text = "RPT";
            this.radRpt.UseVisualStyleBackColor = true;
            this.radRpt.CheckedChanged += new System.EventHandler(this.radRpt_CheckedChanged);
            // 
            // tabPagePayment
            // 
            this.tabPagePayment.Controls.Add(this.ucPayment1);
            this.tabPagePayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPagePayment.Location = new System.Drawing.Point(4, 5);
            this.tabPagePayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPagePayment.Name = "tabPagePayment";
            this.tabPagePayment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPagePayment.Size = new System.Drawing.Size(859, 517);
            this.tabPagePayment.TabIndex = 2;
            this.tabPagePayment.Text = " ";
            this.tabPagePayment.UseVisualStyleBackColor = true;
            this.tabPagePayment.Enter += new System.EventHandler(this.tabPagePayment_Enter);
            // 
            // ucPayment1
            // 
            this.ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPayment1.Location = new System.Drawing.Point(4, 3);
            this.ucPayment1.Name = "ucPayment1";
            this.ucPayment1.Size = new System.Drawing.Size(851, 511);
            this.ucPayment1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnBack);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(195, 526);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(867, 31);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(729, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(587, 3);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(445, 3);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radTaxpayer);
            this.flowLayoutPanel2.Controls.Add(this.radTaxDues);
            this.flowLayoutPanel2.Controls.Add(this.radPayment);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(195, 557);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // radTaxpayer
            // 
            this.radTaxpayer.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTaxpayer.Checked = true;
            this.radTaxpayer.FlatAppearance.BorderSize = 0;
            this.radTaxpayer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radTaxpayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTaxpayer.Location = new System.Drawing.Point(0, 0);
            this.radTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            this.radTaxpayer.Name = "radTaxpayer";
            this.radTaxpayer.Size = new System.Drawing.Size(195, 37);
            this.radTaxpayer.TabIndex = 5;
            this.radTaxpayer.TabStop = true;
            this.radTaxpayer.Text = "Taxpayer";
            this.radTaxpayer.UseVisualStyleBackColor = true;
            // 
            // radTaxDues
            // 
            this.radTaxDues.Appearance = System.Windows.Forms.Appearance.Button;
            this.radTaxDues.FlatAppearance.BorderSize = 0;
            this.radTaxDues.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radTaxDues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radTaxDues.Location = new System.Drawing.Point(0, 37);
            this.radTaxDues.Margin = new System.Windows.Forms.Padding(0);
            this.radTaxDues.Name = "radTaxDues";
            this.radTaxDues.Size = new System.Drawing.Size(195, 37);
            this.radTaxDues.TabIndex = 5;
            this.radTaxDues.Text = "Tax Dues";
            this.radTaxDues.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            this.radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            this.radPayment.FlatAppearance.BorderSize = 0;
            this.radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radPayment.Location = new System.Drawing.Point(0, 74);
            this.radPayment.Margin = new System.Windows.Forms.Padding(0);
            this.radPayment.Name = "radPayment";
            this.radPayment.Size = new System.Drawing.Size(195, 37);
            this.radPayment.TabIndex = 2;
            this.radPayment.Text = "Payment";
            this.radPayment.UseVisualStyleBackColor = true;
            // 
            // frmPayments
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1062, 557);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1078, 596);
            this.Name = "frmPayments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Payments";
            this.Load += new System.EventHandler(this.newFormPayments_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTaxpayer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxpayers)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tabPageTaxDues.ResumeLayout(false);
            this.tabControlTaxDues.ResumeLayout(false);
            this.tabPageRpt.ResumeLayout(false);
            this.tabPageBpl.ResumeLayout(false);
            this.tabPageBpl.PerformLayout();
            this.tabPageOthers.ResumeLayout(false);
            this.tabPageOthers.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tabPagePayment.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControlTaxDues;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.TabPage tabPageBpl;
        private System.Windows.Forms.TabPage tabPageRpt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radOthers;
        private System.Windows.Forms.RadioButton radBpl;
        private System.Windows.Forms.RadioButton radRpt;
        private RealProperty.ucRptTaxDues ucRptTaxDues1;
        private ucPayment ucPayment1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox txtTaxpayerSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}