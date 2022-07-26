
namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    partial class frmPaymentPosting
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPay = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTransactions = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTaxpayer = new System.Windows.Forms.TextBox();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.txtMunicipality = new System.Windows.Forms.TextBox();
            this.txtBarangay = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCollector = new System.Windows.Forms.TextBox();
            this.txtDatePaid = new System.Windows.Forms.TextBox();
            this.txtTimePaid = new System.Windows.Forms.TextBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtAccountableForm = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTotalDue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnGetTaxDue = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPay,
            this.btnNew,
            this.toolStripSeparator1,
            this.btnTransactions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(945, 60);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPay
            // 
            this.btnPay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPay.Enabled = false;
            this.btnPay.Image = global::AccountingSystem.Properties.Resources.give_money_2_28px;
            this.btnPay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(104, 47);
            this.btnPay.Text = "Proceed Payment";
            this.btnPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::AccountingSystem.Properties.Resources.create_new_28px;
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(35, 47);
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Image = global::AccountingSystem.Properties.Resources.list_money_banknotes_28px;
            this.btnTransactions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTransactions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(99, 47);
            this.btnTransactions.Text = "Payment History";
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(935, 429);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainer2.Size = new System.Drawing.Size(378, 429);
            this.splitContainer2.SplitterDistance = 211;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(1, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 209);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Taxpayer Info.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTaxpayer);
            this.panel2.Controls.Add(this.txtProvince);
            this.panel2.Controls.Add(this.txtMunicipality);
            this.panel2.Controls.Add(this.txtBarangay);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtTin);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(370, 187);
            this.panel2.TabIndex = 0;
            // 
            // txtTaxpayer
            // 
            this.txtTaxpayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxpayer.Location = new System.Drawing.Point(94, 36);
            this.txtTaxpayer.Name = "txtTaxpayer";
            this.txtTaxpayer.ReadOnly = true;
            this.txtTaxpayer.Size = new System.Drawing.Size(260, 23);
            this.txtTaxpayer.TabIndex = 2;
            // 
            // txtProvince
            // 
            this.txtProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProvince.Location = new System.Drawing.Point(94, 123);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.ReadOnly = true;
            this.txtProvince.Size = new System.Drawing.Size(260, 23);
            this.txtProvince.TabIndex = 5;
            // 
            // txtMunicipality
            // 
            this.txtMunicipality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMunicipality.Location = new System.Drawing.Point(94, 94);
            this.txtMunicipality.Name = "txtMunicipality";
            this.txtMunicipality.ReadOnly = true;
            this.txtMunicipality.Size = new System.Drawing.Size(260, 23);
            this.txtMunicipality.TabIndex = 4;
            // 
            // txtBarangay
            // 
            this.txtBarangay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarangay.Location = new System.Drawing.Point(94, 65);
            this.txtBarangay.Name = "txtBarangay";
            this.txtBarangay.ReadOnly = true;
            this.txtBarangay.Size = new System.Drawing.Size(260, 23);
            this.txtBarangay.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(94, 152);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(260, 23);
            this.txtAddress.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 15);
            this.label13.TabIndex = 3;
            this.label13.Text = "Province";
            // 
            // txtTin
            // 
            this.txtTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTin.Location = new System.Drawing.Point(94, 7);
            this.txtTin.Name = "txtTin";
            this.txtTin.ReadOnly = true;
            this.txtTin.Size = new System.Drawing.Size(260, 23);
            this.txtTin.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Municipality";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Taxpayer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Barangay";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "TIN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(1, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 212);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment Info.";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtCollector);
            this.panel3.Controls.Add(this.txtDatePaid);
            this.panel3.Controls.Add(this.txtTimePaid);
            this.panel3.Controls.Add(this.txtPayee);
            this.panel3.Controls.Add(this.txtReceiptNo);
            this.panel3.Controls.Add(this.txtAccountableForm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(370, 190);
            this.panel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Collector";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Date Paid";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Time Paid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Payee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Receipt No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Acc. Form";
            // 
            // txtCollector
            // 
            this.txtCollector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCollector.Location = new System.Drawing.Point(94, 65);
            this.txtCollector.Name = "txtCollector";
            this.txtCollector.ReadOnly = true;
            this.txtCollector.Size = new System.Drawing.Size(260, 23);
            this.txtCollector.TabIndex = 9;
            // 
            // txtDatePaid
            // 
            this.txtDatePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatePaid.Location = new System.Drawing.Point(94, 151);
            this.txtDatePaid.Name = "txtDatePaid";
            this.txtDatePaid.ReadOnly = true;
            this.txtDatePaid.Size = new System.Drawing.Size(260, 23);
            this.txtDatePaid.TabIndex = 12;
            // 
            // txtTimePaid
            // 
            this.txtTimePaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimePaid.Location = new System.Drawing.Point(94, 123);
            this.txtTimePaid.Name = "txtTimePaid";
            this.txtTimePaid.ReadOnly = true;
            this.txtTimePaid.Size = new System.Drawing.Size(260, 23);
            this.txtTimePaid.TabIndex = 11;
            // 
            // txtPayee
            // 
            this.txtPayee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayee.Location = new System.Drawing.Point(94, 94);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.ReadOnly = true;
            this.txtPayee.Size = new System.Drawing.Size(260, 23);
            this.txtPayee.TabIndex = 10;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReceiptNo.Location = new System.Drawing.Point(94, 36);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(260, 23);
            this.txtReceiptNo.TabIndex = 8;
            // 
            // txtAccountableForm
            // 
            this.txtAccountableForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountableForm.Location = new System.Drawing.Point(94, 7);
            this.txtAccountableForm.Name = "txtAccountableForm";
            this.txtAccountableForm.ReadOnly = true;
            this.txtAccountableForm.Size = new System.Drawing.Size(260, 23);
            this.txtAccountableForm.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 429);
            this.panel4.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Real Property";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTotalDue);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.toolStrip2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(3, 19);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(4);
            this.panel5.Size = new System.Drawing.Size(547, 407);
            this.panel5.TabIndex = 0;
            // 
            // txtTotalDue
            // 
            this.txtTotalDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDue.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotalDue.Location = new System.Drawing.Point(366, 373);
            this.txtTotalDue.Name = "txtTotalDue";
            this.txtTotalDue.ReadOnly = true;
            this.txtTotalDue.Size = new System.Drawing.Size(178, 27);
            this.txtTotalDue.TabIndex = 14;
            this.txtTotalDue.Text = "0.00";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(284, 376);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Total Due";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(539, 323);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGetTaxDue});
            this.toolStrip2.Location = new System.Drawing.Point(4, 4);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(539, 40);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnGetTaxDue
            // 
            this.btnGetTaxDue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGetTaxDue.Image = global::AccountingSystem.Properties.Resources.document_color_blue_time_18px;
            this.btnGetTaxDue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetTaxDue.Name = "btnGetTaxDue";
            this.btnGetTaxDue.Size = new System.Drawing.Size(73, 37);
            this.btnGetTaxDue.Text = "Get Tax Due";
            this.btnGetTaxDue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGetTaxDue.Click += new System.EventHandler(this.btnGetTaxDue_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(945, 439);
            this.panel1.TabIndex = 2;
            // 
            // frmPaymentPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(961, 538);
            this.Name = "frmPaymentPosting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPT Payment Posting";
            this.Load += new System.EventHandler(this.frmPaymentPosting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton btnPay;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnGetTaxDue;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnTransactions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTaxpayer;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCollector;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtAccountableForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTimePaid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDatePaid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalDue;
        private System.Windows.Forms.TextBox txtBarangay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.TextBox txtMunicipality;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}