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
            ucPaymentTaxpayers1 = new RealProperty.ucPaymentTaxpayers();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabPageReceipt = new System.Windows.Forms.TabPage();
            ucPrintReceipt1 = new BurialPermit.ucPrintReceipt();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radTaxpayer = new System.Windows.Forms.RadioButton();
            radTaxDues = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            radReceipt = new System.Windows.Forms.RadioButton();
            tabPageTaxDues = new System.Windows.Forms.TabPage();
            tabControlMain.SuspendLayout();
            tabPageTaxpayer.SuspendLayout();
            panel2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabPageReceipt.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
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
            tabControlMain.Size = new System.Drawing.Size(832, 496);
            tabControlMain.TabIndex = 1;
            // 
            // tabPageTaxpayer
            // 
            tabPageTaxpayer.BackColor = System.Drawing.Color.Transparent;
            tabPageTaxpayer.Controls.Add(panel2);
            tabPageTaxpayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxpayer.Location = new System.Drawing.Point(4, 26);
            tabPageTaxpayer.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxpayer.Name = "tabPageTaxpayer";
            tabPageTaxpayer.Size = new System.Drawing.Size(824, 466);
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
            panel2.Size = new System.Drawing.Size(824, 466);
            panel2.TabIndex = 0;
            // 
            // ucPaymentTaxpayers1
            // 
            ucPaymentTaxpayers1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentTaxpayers1.Location = new System.Drawing.Point(4, 3);
            ucPaymentTaxpayers1.Margin = new System.Windows.Forms.Padding(0);
            ucPaymentTaxpayers1.Name = "ucPaymentTaxpayers1";
            ucPaymentTaxpayers1.Size = new System.Drawing.Size(816, 460);
            ucPaymentTaxpayers1.TabIndex = 0;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPagePayment.Location = new System.Drawing.Point(4, 26);
            tabPagePayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPagePayment.Size = new System.Drawing.Size(824, 466);
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
            ucPayment1.Size = new System.Drawing.Size(816, 460);
            ucPayment1.TabIndex = 0;
            // 
            // tabPageReceipt
            // 
            tabPageReceipt.Controls.Add(ucPrintReceipt1);
            tabPageReceipt.Location = new System.Drawing.Point(4, 26);
            tabPageReceipt.Name = "tabPageReceipt";
            tabPageReceipt.Padding = new System.Windows.Forms.Padding(3);
            tabPageReceipt.Size = new System.Drawing.Size(824, 466);
            tabPageReceipt.TabIndex = 3;
            tabPageReceipt.Text = "tabPageReceipt";
            tabPageReceipt.UseVisualStyleBackColor = true;
            // 
            // ucPrintReceipt1
            // 
            ucPrintReceipt1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPrintReceipt1.Location = new System.Drawing.Point(3, 3);
            ucPrintReceipt1.Name = "ucPrintReceipt1";
            ucPrintReceipt1.Size = new System.Drawing.Size(818, 460);
            ucPrintReceipt1.TabIndex = 0;
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
            flowLayoutPanel2.TabIndex = 4;
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
            // tabPageTaxDues
            // 
            tabPageTaxDues.Font = new System.Drawing.Font("Segoe UI", 9F);
            tabPageTaxDues.Location = new System.Drawing.Point(4, 26);
            tabPageTaxDues.Margin = new System.Windows.Forms.Padding(0);
            tabPageTaxDues.Name = "tabPageTaxDues";
            tabPageTaxDues.Size = new System.Drawing.Size(824, 466);
            tabPageTaxDues.TabIndex = 1;
            tabPageTaxDues.Text = "tabPageTaxDues";
            tabPageTaxDues.UseVisualStyleBackColor = true;
            // 
            // frmCommunityTaxCertificate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCommunityTaxCertificate";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Payments > AF 15 - Community Tax Clearance";
            tabControlMain.ResumeLayout(false);
            tabPageTaxpayer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabPageReceipt.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageTaxpayer;
        private System.Windows.Forms.Panel panel2;
        private RealProperty.ucPaymentTaxpayers ucPaymentTaxpayers1;
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
    }
}