namespace AccountingSystem.Views.Transactions.Payments
{
    partial class newFormPayments
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTaxpayer = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgTaxpayers = new System.Windows.Forms.DataGridView();
            this.tabPageTaxDues = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageRpt = new System.Windows.Forms.TabPage();
            this.ucRptTaxDues1 = new AccountingSystem.Views.Transactions.Payments.RealProperty.ucRptTaxDues();
            this.tabPageBpl = new System.Windows.Forms.TabPage();
            this.tabPageOthers = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radOthers = new System.Windows.Forms.RadioButton();
            this.radBpl = new System.Windows.Forms.RadioButton();
            this.radRpt = new System.Windows.Forms.RadioButton();
            this.tabPagePayment = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtCollectingOfficer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbxAccountableForm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceipts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gpBxChequeDetails = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgCheques = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.radPaymentCashCheque = new System.Windows.Forms.RadioButton();
            this.radPaymentCheque = new System.Windows.Forms.RadioButton();
            this.radPaymentCash = new System.Windows.Forms.RadioButton();
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
            this.tabPageTaxDues.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageRpt.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tabPagePayment.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gpBxChequeDetails.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
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
            this.tabControl1.TabIndex = 2;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTaxpayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTaxpayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTaxpayers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTaxpayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTaxpayers.Location = new System.Drawing.Point(4, 3);
            this.dgTaxpayers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgTaxpayers.Name = "dgTaxpayers";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTaxpayers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTaxpayers.RowTemplate.Height = 25;
            this.dgTaxpayers.Size = new System.Drawing.Size(851, 511);
            this.dgTaxpayers.TabIndex = 2;
            this.dgTaxpayers.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // tabPageTaxDues
            // 
            this.tabPageTaxDues.Controls.Add(this.tabControl2);
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
            // tabControl2
            // 
            this.tabControl2.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl2.Controls.Add(this.tabPageRpt);
            this.tabControl2.Controls.Add(this.tabPageBpl);
            this.tabControl2.Controls.Add(this.tabPageOthers);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl2.Location = new System.Drawing.Point(0, 27);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(0, 1);
            this.tabControl2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(859, 490);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 0;
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
            this.ucRptTaxDues1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRptTaxDues1.Location = new System.Drawing.Point(0, 0);
            this.ucRptTaxDues1.Name = "ucRptTaxDues1";
            this.ucRptTaxDues1.Size = new System.Drawing.Size(851, 481);
            this.ucRptTaxDues1.TabIndex = 0;
            // 
            // tabPageBpl
            // 
            this.tabPageBpl.Location = new System.Drawing.Point(4, 5);
            this.tabPageBpl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageBpl.Name = "tabPageBpl";
            this.tabPageBpl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageBpl.Size = new System.Drawing.Size(851, 481);
            this.tabPageBpl.TabIndex = 1;
            this.tabPageBpl.Text = "BPL";
            this.tabPageBpl.UseVisualStyleBackColor = true;
            // 
            // tabPageOthers
            // 
            this.tabPageOthers.Location = new System.Drawing.Point(4, 5);
            this.tabPageOthers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageOthers.Name = "tabPageOthers";
            this.tabPageOthers.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageOthers.Size = new System.Drawing.Size(851, 481);
            this.tabPageOthers.TabIndex = 2;
            this.tabPageOthers.Text = "Others";
            this.tabPageOthers.UseVisualStyleBackColor = true;
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
            this.tabPagePayment.Controls.Add(this.groupBox5);
            this.tabPagePayment.Controls.Add(this.groupBox6);
            this.tabPagePayment.Controls.Add(this.gpBxChequeDetails);
            this.tabPagePayment.Controls.Add(this.groupBox2);
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
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.panel7);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(436, 218);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(415, 293);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Payment Details";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtCollectingOfficer);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.cmbxAccountableForm);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.txtReceipts);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.txtPayee);
            this.panel7.Controls.Add(this.dtPaymentDate);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel7.Location = new System.Drawing.Point(4, 23);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel7.Size = new System.Drawing.Size(407, 267);
            this.panel7.TabIndex = 0;
            // 
            // txtCollectingOfficer
            // 
            this.txtCollectingOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollectingOfficer.Location = new System.Drawing.Point(118, 12);
            this.txtCollectingOfficer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCollectingOfficer.Name = "txtCollectingOfficer";
            this.txtCollectingOfficer.ReadOnly = true;
            this.txtCollectingOfficer.Size = new System.Drawing.Size(272, 23);
            this.txtCollectingOfficer.TabIndex = 49;
            this.txtCollectingOfficer.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "Collecting Officer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "Accountable Form";
            // 
            // cmbxAccountableForm
            // 
            this.cmbxAccountableForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccountableForm.FormattingEnabled = true;
            this.cmbxAccountableForm.Location = new System.Drawing.Point(118, 42);
            this.cmbxAccountableForm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbxAccountableForm.Name = "cmbxAccountableForm";
            this.cmbxAccountableForm.Size = new System.Drawing.Size(272, 23);
            this.cmbxAccountableForm.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 44;
            this.label3.Text = "Receipt No.";
            // 
            // txtReceipts
            // 
            this.txtReceipts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtReceipts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReceipts.Location = new System.Drawing.Point(118, 99);
            this.txtReceipts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtReceipts.Name = "txtReceipts";
            this.txtReceipts.Size = new System.Drawing.Size(272, 23);
            this.txtReceipts.TabIndex = 50;
            this.txtReceipts.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "Payment Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Payee";
            // 
            // txtPayee
            // 
            this.txtPayee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayee.Location = new System.Drawing.Point(118, 128);
            this.txtPayee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(272, 23);
            this.txtPayee.TabIndex = 48;
            this.txtPayee.WordWrap = false;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(118, 70);
            this.dtPaymentDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(272, 23);
            this.dtPaymentDate.TabIndex = 47;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.panel5);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox6.Location = new System.Drawing.Point(9, 7);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(842, 205);
            this.groupBox6.TabIndex = 48;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Payment";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotalPayment);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(4, 23);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(834, 179);
            this.panel5.TabIndex = 0;
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPayment.Location = new System.Drawing.Point(334, 51);
            this.lblTotalPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(116, 65);
            this.lblTotalPayment.TabIndex = 1;
            this.lblTotalPayment.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Payment";
            // 
            // gpBxChequeDetails
            // 
            this.gpBxChequeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpBxChequeDetails.Controls.Add(this.panel9);
            this.gpBxChequeDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gpBxChequeDetails.Location = new System.Drawing.Point(6, 279);
            this.gpBxChequeDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpBxChequeDetails.Name = "gpBxChequeDetails";
            this.gpBxChequeDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpBxChequeDetails.Size = new System.Drawing.Size(424, 232);
            this.gpBxChequeDetails.TabIndex = 47;
            this.gpBxChequeDetails.TabStop = false;
            this.gpBxChequeDetails.Text = "Cheque Details";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dgCheques);
            this.panel9.Controls.Add(this.toolStrip1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel9.Location = new System.Drawing.Point(4, 19);
            this.panel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel9.Size = new System.Drawing.Size(416, 210);
            this.panel9.TabIndex = 0;
            // 
            // dgCheques
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCheques.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheques.Location = new System.Drawing.Point(4, 28);
            this.dgCheques.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgCheques.Name = "dgCheques";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgCheques.RowTemplate.Height = 25;
            this.dgCheques.Size = new System.Drawing.Size(408, 179);
            this.dgCheques.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDelete,
            this.toolStripButtonAdd});
            this.toolStrip1.Location = new System.Drawing.Point(4, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(408, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::AccountingSystem.Properties.Resources.waste_bin_filled_14px;
            this.toolStripButtonDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "Delete";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::AccountingSystem.Properties.Resources.symbol_add_14px;
            this.toolStripButtonAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Add";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flowLayoutPanel6);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(6, 218);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(424, 57);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Methods";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCashCheque);
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCheque);
            this.flowLayoutPanel6.Controls.Add(this.radPaymentCash);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(4, 23);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel6.Size = new System.Drawing.Size(416, 31);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // radPaymentCashCheque
            // 
            this.radPaymentCashCheque.AutoSize = true;
            this.radPaymentCashCheque.Location = new System.Drawing.Point(296, 6);
            this.radPaymentCashCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCashCheque.Name = "radPaymentCashCheque";
            this.radPaymentCashCheque.Size = new System.Drawing.Size(108, 19);
            this.radPaymentCashCheque.TabIndex = 47;
            this.radPaymentCashCheque.Text = "Cash && Cheque";
            this.radPaymentCashCheque.UseVisualStyleBackColor = true;
            this.radPaymentCashCheque.CheckedChanged += new System.EventHandler(this.radPaymentCashCheque_CheckedChanged);
            // 
            // radPaymentCheque
            // 
            this.radPaymentCheque.AutoSize = true;
            this.radPaymentCheque.Location = new System.Drawing.Point(222, 6);
            this.radPaymentCheque.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCheque.Name = "radPaymentCheque";
            this.radPaymentCheque.Size = new System.Drawing.Size(66, 19);
            this.radPaymentCheque.TabIndex = 48;
            this.radPaymentCheque.Text = "Cheque";
            this.radPaymentCheque.UseVisualStyleBackColor = true;
            this.radPaymentCheque.CheckedChanged += new System.EventHandler(this.radPaymentCheque_CheckedChanged);
            // 
            // radPaymentCash
            // 
            this.radPaymentCash.AutoSize = true;
            this.radPaymentCash.Checked = true;
            this.radPaymentCash.Location = new System.Drawing.Point(163, 6);
            this.radPaymentCash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radPaymentCash.Name = "radPaymentCash";
            this.radPaymentCash.Size = new System.Drawing.Size(51, 19);
            this.radPaymentCash.TabIndex = 49;
            this.radPaymentCash.TabStop = true;
            this.radPaymentCash.Text = "Cash";
            this.radPaymentCash.UseVisualStyleBackColor = true;
            this.radPaymentCash.CheckedChanged += new System.EventHandler(this.radPaymentCash_CheckedChanged);
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
            this.radTaxpayer.TabIndex = 0;
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
            this.radTaxDues.TabIndex = 1;
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
            // newFormPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1062, 557);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1078, 596);
            this.Name = "newFormPayments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction > Payments";
            this.Load += new System.EventHandler(this.newFormPayments_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTaxpayer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxpayers)).EndInit();
            this.tabPageTaxDues.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPageRpt.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tabPagePayment.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.gpBxChequeDetails.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPageOthers;
        private System.Windows.Forms.TabPage tabPageBpl;
        private System.Windows.Forms.TabPage tabPageRpt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton radOthers;
        private System.Windows.Forms.RadioButton radBpl;
        private System.Windows.Forms.RadioButton radRpt;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.TextBox txtCollectingOfficer;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbxAccountableForm;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtReceipts;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.DateTimePicker dtPaymentDate;
        private RealProperty.ucRptTaxDues ucRptTaxDues1;
        private System.Windows.Forms.GroupBox gpBxChequeDetails;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgCheques;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.RadioButton radPaymentCashCheque;
        private System.Windows.Forms.RadioButton radPaymentCheque;
        private System.Windows.Forms.RadioButton radPaymentCash;
    }
}