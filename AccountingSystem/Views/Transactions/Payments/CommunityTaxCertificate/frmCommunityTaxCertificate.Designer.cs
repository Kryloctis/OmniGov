namespace AccountingSystem.Views.Transactions.Payments.CommunityTaxCertificate
{
    partial class frmCommunityTaxCertificate
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
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageTaxpayer = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucTaxPayerDetails1 = new ucTaxPayerDetails();
            tabPageTaxDues = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucTaxDue1 = new ucTaxDue();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabPageReceipt = new System.Windows.Forms.TabPage();
            ucPrintReceipt1 = new BurialPermit.ucPrintReceipt();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radTaxpayer = new System.Windows.Forms.RadioButton();
            radTaxDues = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            radReceipt = new System.Windows.Forms.RadioButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            tabControlMain.SuspendLayout();
            tabPageTaxpayer.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageTaxDues.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabPageReceipt.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageTaxpayer);
            tabControlMain.Controls.Add(tabPageTaxDues);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Controls.Add(tabPageReceipt);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new System.Drawing.Point(0, 0);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(713, 560);
            tabControlMain.TabIndex = 1;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageTaxpayer
            // 
            tabPageTaxpayer.AutoScroll = true;
            tabPageTaxpayer.BackColor = System.Drawing.Color.Transparent;
            tabPageTaxpayer.Controls.Add(panel2);
            tabPageTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxpayer.Location = new System.Drawing.Point(4, 26);
            tabPageTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxpayer.Name = "tabPageTaxpayer";
            tabPageTaxpayer.Size = new System.Drawing.Size(705, 530);
            tabPageTaxpayer.TabIndex = 0;
            tabPageTaxpayer.Text = "tabPageTaxpayer";
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(groupBox1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Size = new System.Drawing.Size(705, 530);
            panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucTaxPayerDetails1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox1.Location = new System.Drawing.Point(4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(697, 524);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tax Payer Info.";
            // 
            // ucTaxPayerDetails1
            // 
            ucTaxPayerDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxPayerDetails1.Font = new System.Drawing.Font("Segoe UI", 9F);
            ucTaxPayerDetails1.Location = new System.Drawing.Point(3, 23);
            ucTaxPayerDetails1.Name = "ucTaxPayerDetails1";
            ucTaxPayerDetails1.Size = new System.Drawing.Size(691, 498);
            ucTaxPayerDetails1.TabIndex = 1;
            // 
            // tabPageTaxDues
            // 
            tabPageTaxDues.Controls.Add(groupBox2);
            tabPageTaxDues.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxDues.Location = new System.Drawing.Point(4, 26);
            tabPageTaxDues.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxDues.Name = "tabPageTaxDues";
            tabPageTaxDues.Size = new System.Drawing.Size(192, 70);
            tabPageTaxDues.TabIndex = 1;
            tabPageTaxDues.Text = "tabPageTaxDues";
            tabPageTaxDues.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ucTaxDue1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(192, 70);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tax Dues";
            // 
            // ucTaxDue1
            // 
            ucTaxDue1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucTaxDue1.Font = new System.Drawing.Font("Segoe UI", 9F);
            ucTaxDue1.Location = new System.Drawing.Point(3, 23);
            ucTaxDue1.Name = "ucTaxDue1";
            ucTaxDue1.Size = new System.Drawing.Size(186, 44);
            ucTaxDue1.TabIndex = 0;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPagePayment.Location = new System.Drawing.Point(4, 26);
            tabPagePayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Size = new System.Drawing.Size(192, 70);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = " tabPagePayment";
            tabPagePayment.UseVisualStyleBackColor = true;
            // 
            // ucPayment1
            // 
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPayment1.Location = new System.Drawing.Point(4, 3);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(184, 64);
            ucPayment1.TabIndex = 0;
            // 
            // tabPageReceipt
            // 
            tabPageReceipt.Controls.Add(ucPrintReceipt1);
            tabPageReceipt.Location = new System.Drawing.Point(4, 26);
            tabPageReceipt.Name = "tabPageReceipt";
            tabPageReceipt.Padding = new System.Windows.Forms.Padding(3);
            tabPageReceipt.Size = new System.Drawing.Size(192, 70);
            tabPageReceipt.TabIndex = 3;
            tabPageReceipt.Text = "tabPageReceipt";
            tabPageReceipt.UseVisualStyleBackColor = true;
            // 
            // ucPrintReceipt1
            // 
            ucPrintReceipt1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPrintReceipt1.Location = new System.Drawing.Point(3, 3);
            ucPrintReceipt1.Name = "ucPrintReceipt1";
            ucPrintReceipt1.Size = new System.Drawing.Size(186, 64);
            ucPrintReceipt1.TabIndex = 0;
            ucPrintReceipt1.Load += ucPrintReceipt1_Load;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(radTaxpayer);
            flowLayoutPanel2.Controls.Add(radTaxDues);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Controls.Add(radReceipt);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 591);
            flowLayoutPanel2.TabIndex = 4;
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
            radTaxpayer.Text = "Tax Payer";
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
            // radReceipt
            // 
            radReceipt.Appearance = System.Windows.Forms.Appearance.Button;
            radReceipt.FlatAppearance.BorderSize = 0;
            radReceipt.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radReceipt.Location = new System.Drawing.Point(0, 111);
            radReceipt.Margin = new System.Windows.Forms.Padding(0);
            radReceipt.Name = "radReceipt";
            radReceipt.Size = new System.Drawing.Size(195, 37);
            radReceipt.TabIndex = 6;
            radReceipt.Text = "Receipt";
            radReceipt.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnBackMain);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 560);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(713, 31);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(575, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(433, 3);
            btnNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(134, 23);
            btnNext.TabIndex = 0;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnBackMain
            // 
            btnBackMain.Location = new System.Drawing.Point(291, 3);
            btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBackMain.Name = "btnBackMain";
            btnBackMain.Size = new System.Drawing.Size(134, 23);
            btnBackMain.TabIndex = 0;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBackMain_Click;
            // 
            // frmCommunityTaxCertificate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(908, 591);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCommunityTaxCertificate";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Payments > AF 15 - Community Tax Certificate";
            FormClosing += frmCommunityTaxCertificate_FormClosing;
            Load += frmCommunityTaxCertificate_Load;
            tabControlMain.ResumeLayout(false);
            tabPageTaxpayer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageTaxDues.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabPageReceipt.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTaxpayer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.TabPage tabPageReceipt;
        private BurialPermit.ucPrintReceipt ucPrintReceipt1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radTaxpayer;
        private System.Windows.Forms.RadioButton radTaxDues;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.RadioButton radReceipt;
        private System.Windows.Forms.TabPage tabPageTaxDues;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBackMain;
        private ucTaxDue ucTaxDue1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ucTaxPayerDetails ucTaxPayerDetails1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}