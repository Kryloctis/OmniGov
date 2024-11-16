namespace AccountingSystem.Views.Transactions.Payments
{
    partial class frmPaymentRpt
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
            panel1 = new System.Windows.Forms.Panel();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageTaxpayer = new System.Windows.Forms.TabPage();
            panel2 = new System.Windows.Forms.Panel();
            ucPaymentTaxpayers1 = new RealProperty.ucPaymentTaxpayers();
            tabPageTaxDues = new System.Windows.Forms.TabPage();
            ucPaymentRptTaxDues1 = new RealProperty.ucPaymentRptTaxDues();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabPageReceipt = new System.Windows.Forms.TabPage();
            ucPrintReceipt1 = new BurialPermit.ucPrintReceipt();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radTaxpayer = new System.Windows.Forms.RadioButton();
            radTaxDues = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            radReceipt = new System.Windows.Forms.RadioButton();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panel1.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageTaxpayer.SuspendLayout();
            panel2.SuspendLayout();
            tabPageTaxDues.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabPageReceipt.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tabControlMain);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1027, 496);
            panel1.TabIndex = 1;
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
            tabControlMain.Size = new System.Drawing.Size(832, 465);
            tabControlMain.TabIndex = 0;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageTaxpayer
            // 
            tabPageTaxpayer.BackColor = System.Drawing.Color.Transparent;
            tabPageTaxpayer.Controls.Add(panel2);
            tabPageTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxpayer.Location = new System.Drawing.Point(4, 26);
            tabPageTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxpayer.Name = "tabPageTaxpayer";
            tabPageTaxpayer.Size = new System.Drawing.Size(824, 435);
            tabPageTaxpayer.TabIndex = 0;
            tabPageTaxpayer.Text = "tabPageTaxpayer";
            // 
            // panel2
            // 
            panel2.Controls.Add(ucPaymentTaxpayers1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Size = new System.Drawing.Size(824, 435);
            panel2.TabIndex = 0;
            // 
            // ucPaymentTaxpayers1
            // 
            ucPaymentTaxpayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentTaxpayers1.Location = new System.Drawing.Point(4, 3);
            ucPaymentTaxpayers1.Margin = new System.Windows.Forms.Padding(0);
            ucPaymentTaxpayers1.Name = "ucPaymentTaxpayers1";
            ucPaymentTaxpayers1.Size = new System.Drawing.Size(816, 429);
            ucPaymentTaxpayers1.TabIndex = 0;
            // 
            // tabPageTaxDues
            // 
            tabPageTaxDues.Controls.Add(ucPaymentRptTaxDues1);
            tabPageTaxDues.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxDues.Location = new System.Drawing.Point(4, 26);
            tabPageTaxDues.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxDues.Name = "tabPageTaxDues";
            tabPageTaxDues.Size = new System.Drawing.Size(824, 435);
            tabPageTaxDues.TabIndex = 1;
            tabPageTaxDues.Text = "tabPageTaxDues";
            tabPageTaxDues.UseVisualStyleBackColor = true;
            // 
            // ucPaymentRptTaxDues1
            // 
            ucPaymentRptTaxDues1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentRptTaxDues1.Location = new System.Drawing.Point(0, 0);
            ucPaymentRptTaxDues1.Name = "ucPaymentRptTaxDues1";
            ucPaymentRptTaxDues1.Size = new System.Drawing.Size(824, 435);
            ucPaymentRptTaxDues1.TabIndex = 0;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPagePayment.Location = new System.Drawing.Point(4, 26);
            tabPagePayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Size = new System.Drawing.Size(824, 435);
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
            ucPayment1.Size = new System.Drawing.Size(816, 429);
            ucPayment1.TabIndex = 0;
            // 
            // tabPageReceipt
            // 
            tabPageReceipt.Controls.Add(ucPrintReceipt1);
            tabPageReceipt.Location = new System.Drawing.Point(4, 26);
            tabPageReceipt.Name = "tabPageReceipt";
            tabPageReceipt.Padding = new System.Windows.Forms.Padding(3);
            tabPageReceipt.Size = new System.Drawing.Size(824, 435);
            tabPageReceipt.TabIndex = 3;
            tabPageReceipt.Text = "tabPageReceipt";
            tabPageReceipt.UseVisualStyleBackColor = true;
            // 
            // ucPrintReceipt1
            // 
            ucPrintReceipt1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPrintReceipt1.Location = new System.Drawing.Point(3, 3);
            ucPrintReceipt1.Name = "ucPrintReceipt1";
            ucPrintReceipt1.Size = new System.Drawing.Size(818, 429);
            ucPrintReceipt1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnBackMain);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 465);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(832, 31);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(694, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new System.Drawing.Point(552, 3);
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
            btnBackMain.Location = new System.Drawing.Point(410, 3);
            btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBackMain.Name = "btnBackMain";
            btnBackMain.Size = new System.Drawing.Size(134, 23);
            btnBackMain.TabIndex = 0;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBack_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(radTaxpayer);
            flowLayoutPanel2.Controls.Add(radTaxDues);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Controls.Add(radReceipt);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 496);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // radTaxpayer
            // 
            radTaxpayer.Appearance = System.Windows.Forms.Appearance.Button;
            radTaxpayer.FlatAppearance.BorderSize = 0;
            radTaxpayer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radTaxpayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radTaxpayer.Location = new System.Drawing.Point(0, 0);
            radTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            radTaxpayer.Name = "radTaxpayer";
            radTaxpayer.Size = new System.Drawing.Size(195, 37);
            radTaxpayer.TabIndex = 5;
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
            // reportViewer1
            // 
            reportViewer1.Location = new System.Drawing.Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new System.Drawing.Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmPaymentRpt
            // 
            AcceptButton = btnNext;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            BackColor = System.Drawing.Color.White;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "frmPaymentRpt";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payments > AF 56 - Real Property Tax Receipts";
            FormClosing += frmPaymentRpt_FormClosing;
            Load += frmRptPayments_Load;
            panel1.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageTaxpayer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPageTaxDues.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabPageReceipt.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTaxpayer;
        private System.Windows.Forms.TabPage tabPageTaxDues;
        private System.Windows.Forms.TabPage tabPagePayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radTaxpayer;
        private System.Windows.Forms.RadioButton radTaxDues;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private ucPayment ucPayment1;
        private RealProperty.ucPaymentTaxpayers ucPaymentTaxpayers1;
        private RealProperty.ucPaymentRptTaxDues ucPaymentRptTaxDues1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPageReceipt;
        private System.Windows.Forms.RadioButton radReceipt;
        private BurialPermit.ucPrintReceipt ucPrintReceipt1;
    }
}