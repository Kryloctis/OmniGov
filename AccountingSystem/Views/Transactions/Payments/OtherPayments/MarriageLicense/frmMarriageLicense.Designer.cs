namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense
{
    partial class frmMarriageLicense
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            radFeesCharges = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radMarriageDetails = new System.Windows.Forms.RadioButton();
            radGroomInfo = new System.Windows.Forms.RadioButton();
            radBrideInfo = new System.Windows.Forms.RadioButton();
            bgwSavingPayment = new System.ComponentModel.BackgroundWorker();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabPageFeesCharges = new System.Windows.Forms.TabPage();
            ucPaymentFeesCharges1 = new ucPaymentFeesCharges();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageMarriageDetails = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucMarriageDetails1 = new ucMarriageDetails();
            tabPageGroomInfo = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucSpouseInfoGroom1 = new ucSpouseInfo();
            tabPageBrideInfo = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            ucSpouseInfoBride1 = new ucSpouseInfo();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabPageFeesCharges.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageMarriageDetails.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageGroomInfo.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPageBrideInfo.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnNextMain);
            flowLayoutPanel1.Controls.Add(btnBackMain);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(195, 484);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(754, 31);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(616, 3);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(134, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNextMain
            // 
            btnNextMain.Location = new System.Drawing.Point(474, 3);
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
            btnBackMain.Location = new System.Drawing.Point(332, 3);
            btnBackMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBackMain.Name = "btnBackMain";
            btnBackMain.Size = new System.Drawing.Size(134, 23);
            btnBackMain.TabIndex = 1;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBackMain_Click;
            // 
            // radFeesCharges
            // 
            radFeesCharges.Appearance = System.Windows.Forms.Appearance.Button;
            radFeesCharges.FlatAppearance.BorderSize = 0;
            radFeesCharges.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFeesCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFeesCharges.Location = new System.Drawing.Point(0, 111);
            radFeesCharges.Margin = new System.Windows.Forms.Padding(0);
            radFeesCharges.Name = "radFeesCharges";
            radFeesCharges.Size = new System.Drawing.Size(195, 37);
            radFeesCharges.TabIndex = 5;
            radFeesCharges.Text = "Fees && Charges";
            radFeesCharges.UseVisualStyleBackColor = true;
            // 
            // radPayment
            // 
            radPayment.Appearance = System.Windows.Forms.Appearance.Button;
            radPayment.FlatAppearance.BorderSize = 0;
            radPayment.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayment.Location = new System.Drawing.Point(0, 148);
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
            flowLayoutPanel2.Controls.Add(radMarriageDetails);
            flowLayoutPanel2.Controls.Add(radGroomInfo);
            flowLayoutPanel2.Controls.Add(radBrideInfo);
            flowLayoutPanel2.Controls.Add(radFeesCharges);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 515);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // radMarriageDetails
            // 
            radMarriageDetails.Appearance = System.Windows.Forms.Appearance.Button;
            radMarriageDetails.FlatAppearance.BorderSize = 0;
            radMarriageDetails.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radMarriageDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radMarriageDetails.Location = new System.Drawing.Point(0, 0);
            radMarriageDetails.Margin = new System.Windows.Forms.Padding(0);
            radMarriageDetails.Name = "radMarriageDetails";
            radMarriageDetails.Size = new System.Drawing.Size(195, 37);
            radMarriageDetails.TabIndex = 5;
            radMarriageDetails.Text = "Marriage Details";
            radMarriageDetails.UseVisualStyleBackColor = true;
            // 
            // radGroomInfo
            // 
            radGroomInfo.Appearance = System.Windows.Forms.Appearance.Button;
            radGroomInfo.FlatAppearance.BorderSize = 0;
            radGroomInfo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radGroomInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radGroomInfo.Location = new System.Drawing.Point(0, 37);
            radGroomInfo.Margin = new System.Windows.Forms.Padding(0);
            radGroomInfo.Name = "radGroomInfo";
            radGroomInfo.Size = new System.Drawing.Size(195, 37);
            radGroomInfo.TabIndex = 2;
            radGroomInfo.Text = "Groom Info.";
            radGroomInfo.UseVisualStyleBackColor = true;
            // 
            // radBrideInfo
            // 
            radBrideInfo.Appearance = System.Windows.Forms.Appearance.Button;
            radBrideInfo.FlatAppearance.BorderSize = 0;
            radBrideInfo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radBrideInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radBrideInfo.Location = new System.Drawing.Point(0, 74);
            radBrideInfo.Margin = new System.Windows.Forms.Padding(0);
            radBrideInfo.Name = "radBrideInfo";
            radBrideInfo.Size = new System.Drawing.Size(195, 37);
            radBrideInfo.TabIndex = 2;
            radBrideInfo.Text = "Bride Info.";
            radBrideInfo.UseVisualStyleBackColor = true;
            // 
            // bgwSavingPayment
            // 
            bgwSavingPayment.WorkerReportsProgress = true;
            bgwSavingPayment.WorkerSupportsCancellation = true;
            bgwSavingPayment.DoWork += bgwSavingPayment_DoWork;
            bgwSavingPayment.ProgressChanged += bgwSavingPayment_ProgressChanged;
            bgwSavingPayment.RunWorkerCompleted += bgwSavingPayment_RunWorkerCompleted;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(3);
            tabPagePayment.Size = new System.Drawing.Size(746, 475);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = "tabPagePayment";
            tabPagePayment.UseVisualStyleBackColor = true;
            // 
            // ucPayment1
            // 
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPayment1.Location = new System.Drawing.Point(3, 3);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(740, 469);
            ucPayment1.TabIndex = 0;
            // 
            // tabPageFeesCharges
            // 
            tabPageFeesCharges.Controls.Add(ucPaymentFeesCharges1);
            tabPageFeesCharges.Location = new System.Drawing.Point(4, 5);
            tabPageFeesCharges.Margin = new System.Windows.Forms.Padding(0);
            tabPageFeesCharges.Name = "tabPageFeesCharges";
            tabPageFeesCharges.Size = new System.Drawing.Size(746, 475);
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
            ucPaymentFeesCharges1.Size = new System.Drawing.Size(746, 475);
            ucPaymentFeesCharges1.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPageMarriageDetails);
            tabControlMain.Controls.Add(tabPageGroomInfo);
            tabControlMain.Controls.Add(tabPageBrideInfo);
            tabControlMain.Controls.Add(tabPageFeesCharges);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new System.Drawing.Point(0, 0);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(754, 484);
            tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlMain.TabIndex = 9;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageMarriageDetails
            // 
            tabPageMarriageDetails.Controls.Add(groupBox1);
            tabPageMarriageDetails.Location = new System.Drawing.Point(4, 5);
            tabPageMarriageDetails.Name = "tabPageMarriageDetails";
            tabPageMarriageDetails.Size = new System.Drawing.Size(746, 475);
            tabPageMarriageDetails.TabIndex = 3;
            tabPageMarriageDetails.Text = "tabPageMarriageDetails";
            tabPageMarriageDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucMarriageDetails1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(746, 475);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Marriage Details";
            // 
            // ucMarriageDetails1
            // 
            ucMarriageDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucMarriageDetails1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucMarriageDetails1.Location = new System.Drawing.Point(4, 24);
            ucMarriageDetails1.Name = "ucMarriageDetails1";
            ucMarriageDetails1.Size = new System.Drawing.Size(738, 447);
            ucMarriageDetails1.TabIndex = 1;
            // 
            // tabPageGroomInfo
            // 
            tabPageGroomInfo.Controls.Add(groupBox2);
            tabPageGroomInfo.Location = new System.Drawing.Point(4, 5);
            tabPageGroomInfo.Name = "tabPageGroomInfo";
            tabPageGroomInfo.Size = new System.Drawing.Size(746, 475);
            tabPageGroomInfo.TabIndex = 4;
            tabPageGroomInfo.Text = "tabPageGroomInfo";
            tabPageGroomInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ucSpouseInfoGroom1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4);
            groupBox2.Size = new System.Drawing.Size(746, 475);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Groom Info.";
            // 
            // ucSpouseInfoGroom1
            // 
            ucSpouseInfoGroom1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSpouseInfoGroom1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucSpouseInfoGroom1.Location = new System.Drawing.Point(4, 24);
            ucSpouseInfoGroom1.Name = "ucSpouseInfoGroom1";
            ucSpouseInfoGroom1.Size = new System.Drawing.Size(738, 447);
            ucSpouseInfoGroom1.TabIndex = 0;
            // 
            // tabPageBrideInfo
            // 
            tabPageBrideInfo.Controls.Add(groupBox3);
            tabPageBrideInfo.Location = new System.Drawing.Point(4, 5);
            tabPageBrideInfo.Name = "tabPageBrideInfo";
            tabPageBrideInfo.Size = new System.Drawing.Size(746, 475);
            tabPageBrideInfo.TabIndex = 5;
            tabPageBrideInfo.Text = "tabPageBrideInfo";
            tabPageBrideInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ucSpouseInfoBride1);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox3.Location = new System.Drawing.Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4);
            groupBox3.Size = new System.Drawing.Size(746, 475);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bride Info.";
            // 
            // ucSpouseInfoBride1
            // 
            ucSpouseInfoBride1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSpouseInfoBride1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucSpouseInfoBride1.Location = new System.Drawing.Point(4, 24);
            ucSpouseInfoBride1.Name = "ucSpouseInfoBride1";
            ucSpouseInfoBride1.Size = new System.Drawing.Size(738, 447);
            ucSpouseInfoBride1.TabIndex = 0;
            // 
            // frmMarriageLicense
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(949, 515);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMarriageLicense";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Payment > AF 54 - Marriage License";
            Load += frmMarriageLicense_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabPageFeesCharges.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageMarriageDetails.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageGroomInfo.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabPageBrideInfo.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.RadioButton radFeesCharges;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        internal System.ComponentModel.BackgroundWorker bgwSavingPayment;
        private System.Windows.Forms.RadioButton radMarriageDetails;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.TabPage tabPageFeesCharges;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.RadioButton radGroomInfo;
        private System.Windows.Forms.RadioButton radBrideInfo;
        private System.Windows.Forms.TabPage tabPageMarriageDetails;
        private System.Windows.Forms.TabPage tabPageGroomInfo;
        private System.Windows.Forms.TabPage tabPageBrideInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private ucMarriageDetails ucMarriageDetails1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ucPaymentFeesCharges ucPaymentFeesCharges1;
        private ucSpouseInfo ucSpouseInfoGroom1;
        private ucSpouseInfo ucSpouseInfoBride1;
    }
}