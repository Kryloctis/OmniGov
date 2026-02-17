namespace LFS.Views.Transactions.Payments.BurialPermit
{
    partial class frmBurialPermit
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
            tabPageFeesCharges = new System.Windows.Forms.TabPage();
            ucPaymentFeesCharges1 = new ucPaymentFeesCharges();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageBurialDetails = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucBurialDetails1 = new ucBurialDetails();
            tabPageRemainsInfo = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucRemainsInfo1 = new ucRemainsInfo();
            tabPagePayment = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            ucPayment1 = new ucPayment();
            tabPageReceipt = new System.Windows.Forms.TabPage();
            ucPrintReceipt1 = new ucPrintReceipt();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            radFees = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radBurialDetails = new System.Windows.Forms.RadioButton();
            radRemainsInfo = new System.Windows.Forms.RadioButton();
            tabPageFeesCharges.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageBurialDetails.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageRemainsInfo.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPageReceipt.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageFeesCharges
            // 
            tabPageFeesCharges.Controls.Add(ucPaymentFeesCharges1);
            tabPageFeesCharges.Location = new System.Drawing.Point(4, 24);
            tabPageFeesCharges.Margin = new System.Windows.Forms.Padding(0);
            tabPageFeesCharges.Name = "tabPageFeesCharges";
            tabPageFeesCharges.Size = new System.Drawing.Size(824, 437);
            tabPageFeesCharges.TabIndex = 1;
            tabPageFeesCharges.Text = "tabPageFees";
            tabPageFeesCharges.UseVisualStyleBackColor = true;
            // 
            // ucPaymentFeesCharges1
            // 
            ucPaymentFeesCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentFeesCharges1.Location = new System.Drawing.Point(0, 0);
            ucPaymentFeesCharges1.Margin = new System.Windows.Forms.Padding(0);
            ucPaymentFeesCharges1.Name = "ucPaymentFeesCharges1";
            ucPaymentFeesCharges1.Size = new System.Drawing.Size(824, 437);
            ucPaymentFeesCharges1.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageBurialDetails);
            tabControlMain.Controls.Add(tabPageRemainsInfo);
            tabControlMain.Controls.Add(tabPageFeesCharges);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Controls.Add(tabPageReceipt);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(832, 465);
            tabControlMain.TabIndex = 9;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageBurialDetails
            // 
            tabPageBurialDetails.Controls.Add(groupBox1);
            tabPageBurialDetails.Location = new System.Drawing.Point(4, 24);
            tabPageBurialDetails.Name = "tabPageBurialDetails";
            tabPageBurialDetails.Size = new System.Drawing.Size(824, 437);
            tabPageBurialDetails.TabIndex = 3;
            tabPageBurialDetails.Text = "tabPageBurialDetails";
            tabPageBurialDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucBurialDetails1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
            groupBox1.Size = new System.Drawing.Size(824, 437);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Burial Details";
            // 
            // ucBurialDetails1
            // 
            ucBurialDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBurialDetails1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucBurialDetails1.Location = new System.Drawing.Point(4, 30);
            ucBurialDetails1.Name = "ucBurialDetails1";
            ucBurialDetails1.Size = new System.Drawing.Size(816, 403);
            ucBurialDetails1.TabIndex = 1;
            // 
            // tabPageRemainsInfo
            // 
            tabPageRemainsInfo.Controls.Add(groupBox2);
            tabPageRemainsInfo.Location = new System.Drawing.Point(4, 24);
            tabPageRemainsInfo.Name = "tabPageRemainsInfo";
            tabPageRemainsInfo.Size = new System.Drawing.Size(824, 437);
            tabPageRemainsInfo.TabIndex = 4;
            tabPageRemainsInfo.Text = "tabPageRemainsInfo";
            tabPageRemainsInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ucRemainsInfo1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
            groupBox2.Size = new System.Drawing.Size(824, 437);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Remains Info.";
            // 
            // ucRemainsInfo1
            // 
            ucRemainsInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRemainsInfo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucRemainsInfo1.Location = new System.Drawing.Point(4, 30);
            ucRemainsInfo1.Name = "ucRemainsInfo1";
            ucRemainsInfo1.Size = new System.Drawing.Size(816, 403);
            ucRemainsInfo1.TabIndex = 1;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(groupBox3);
            tabPagePayment.Location = new System.Drawing.Point(4, 24);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(3);
            tabPagePayment.Size = new System.Drawing.Size(824, 437);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = "tabPagePayment";
            tabPagePayment.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ucPayment1);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox3.Location = new System.Drawing.Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4, 10, 4, 4);
            groupBox3.Size = new System.Drawing.Size(818, 431);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Payment";
            // 
            // ucPayment1
            // 
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPayment1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucPayment1.Location = new System.Drawing.Point(4, 32);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(810, 395);
            ucPayment1.TabIndex = 0;
            // 
            // tabPageReceipt
            // 
            tabPageReceipt.Controls.Add(ucPrintReceipt1);
            tabPageReceipt.Location = new System.Drawing.Point(4, 24);
            tabPageReceipt.Name = "tabPageReceipt";
            tabPageReceipt.Padding = new System.Windows.Forms.Padding(3);
            tabPageReceipt.Size = new System.Drawing.Size(824, 437);
            tabPageReceipt.TabIndex = 5;
            tabPageReceipt.Text = "tabPageReceipt";
            tabPageReceipt.UseVisualStyleBackColor = true;
            // 
            // ucPrintReceipt1
            // 
            ucPrintReceipt1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPrintReceipt1.Location = new System.Drawing.Point(3, 3);
            ucPrintReceipt1.Name = "ucPrintReceipt1";
            ucPrintReceipt1.Size = new System.Drawing.Size(818, 431);
            ucPrintReceipt1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNextMain);
            flowLayoutPanel1.Controls.Add(btnBackMain);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 465);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(832, 31);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(694, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNextMain
            // 
            btnNextMain.Location = new System.Drawing.Point(552, 3);
            btnNextMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNextMain.Name = "btnNextMain";
            btnNextMain.Size = new System.Drawing.Size(134, 23);
            btnNextMain.TabIndex = 0;
            btnNextMain.Text = "Next";
            btnNextMain.UseVisualStyleBackColor = true;
            btnNextMain.Click += btnNextMain_Click;
            // 
            // btnBackMain
            // 
            btnBackMain.Location = new System.Drawing.Point(410, 3);
            btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBackMain.Name = "btnBackMain";
            btnBackMain.Size = new System.Drawing.Size(134, 23);
            btnBackMain.TabIndex = 2;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBackMain_Click;
            // 
            // radFees
            // 
            radFees.Appearance = System.Windows.Forms.Appearance.Button;
            radFees.FlatAppearance.BorderSize = 0;
            radFees.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFees.Location = new System.Drawing.Point(0, 74);
            radFees.Margin = new System.Windows.Forms.Padding(0);
            radFees.Name = "radFees";
            radFees.Size = new System.Drawing.Size(195, 37);
            radFees.TabIndex = 5;
            radFees.Text = "Fees && Charges";
            radFees.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            radPayment.FlatAppearance.BorderSize = 0;
            radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayment.Location = new System.Drawing.Point(0, 111);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(radBurialDetails);
            flowLayoutPanel2.Controls.Add(radRemainsInfo);
            flowLayoutPanel2.Controls.Add(radFees);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 496);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // radBurialDetails
            // 
            radBurialDetails.Appearance = System.Windows.Forms.Appearance.Button;
            radBurialDetails.FlatAppearance.BorderSize = 0;
            radBurialDetails.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radBurialDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radBurialDetails.Location = new System.Drawing.Point(0, 0);
            radBurialDetails.Margin = new System.Windows.Forms.Padding(0);
            radBurialDetails.Name = "radBurialDetails";
            radBurialDetails.Size = new System.Drawing.Size(195, 37);
            radBurialDetails.TabIndex = 2;
            radBurialDetails.Text = "Burial Details";
            radBurialDetails.UseVisualStyleBackColor = true;
            // 
            // radRemainsInfo
            // 
            radRemainsInfo.Appearance = System.Windows.Forms.Appearance.Button;
            radRemainsInfo.FlatAppearance.BorderSize = 0;
            radRemainsInfo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radRemainsInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radRemainsInfo.Location = new System.Drawing.Point(0, 37);
            radRemainsInfo.Margin = new System.Windows.Forms.Padding(0);
            radRemainsInfo.Name = "radRemainsInfo";
            radRemainsInfo.Size = new System.Drawing.Size(195, 37);
            radRemainsInfo.TabIndex = 2;
            radRemainsInfo.Text = "Remains Info.";
            radRemainsInfo.UseVisualStyleBackColor = true;
            // 
            // frmBurialPermit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBurialPermit";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Transactions > Payments > AF 58 - Burial Permit & Fee";
            FormClosing += frmBurialPermit_FormClosing;
            Load += frmBurialPermit_Load;
            tabPageFeesCharges.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageBurialDetails.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageRemainsInfo.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tabPageReceipt.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabPage tabPageFeesCharges;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.RadioButton radFees;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private ucPaymentFeesCharges ucPaymentFeesCharges1;
        private System.Windows.Forms.RadioButton radBurialDetails;
        private System.Windows.Forms.RadioButton radRemainsInfo;
        private System.Windows.Forms.TabPage tabPageBurialDetails;
        private System.Windows.Forms.TabPage tabPageRemainsInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private Payments.BurialPermit.ucBurialDetails ucBurialDetails1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Payments.BurialPermit.ucRemainsInfo ucRemainsInfo1;
        private System.Windows.Forms.TabPage tabPageReceipt;
        private System.Windows.Forms.GroupBox groupBox3;
        private ucPayment ucPayment1;
        private ucPrintReceipt ucPrintReceipt1;
    }
}
