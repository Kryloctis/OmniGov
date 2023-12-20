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
            radFees = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton3 = new System.Windows.Forms.RadioButton();
            bgwSavingPayment = new System.ComponentModel.BackgroundWorker();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabPageFees = new System.Windows.Forms.TabPage();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageMarriageDetails = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucMarriageDetails1 = new ucMarriageDetails();
            tabPageGroomInfo = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucSpouseInfo1 = new ucSpouseInfo();
            tabPageBrideInfo = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            ucSpouseInfo2 = new ucSpouseInfo();
            ucPaymentFeesCharges1 = new ucPaymentFeesCharges();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabPageFees.SuspendLayout();
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
            // radFees
            // 
            radFees.Appearance = System.Windows.Forms.Appearance.Button;
            radFees.FlatAppearance.BorderSize = 0;
            radFees.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFees.Location = new System.Drawing.Point(0, 111);
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
            flowLayoutPanel2.Controls.Add(radioButton1);
            flowLayoutPanel2.Controls.Add(radioButton2);
            flowLayoutPanel2.Controls.Add(radioButton3);
            flowLayoutPanel2.Controls.Add(radFees);
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
            // radioButton1
            // 
            radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton1.FlatAppearance.BorderSize = 0;
            radioButton1.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton1.Location = new System.Drawing.Point(0, 0);
            radioButton1.Margin = new System.Windows.Forms.Padding(0);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(195, 37);
            radioButton1.TabIndex = 5;
            radioButton1.Text = "Marriage Details";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton2.FlatAppearance.BorderSize = 0;
            radioButton2.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton2.Location = new System.Drawing.Point(0, 37);
            radioButton2.Margin = new System.Windows.Forms.Padding(0);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(195, 37);
            radioButton2.TabIndex = 2;
            radioButton2.Text = "Groom Info.";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            radioButton3.FlatAppearance.BorderSize = 0;
            radioButton3.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radioButton3.Location = new System.Drawing.Point(0, 74);
            radioButton3.Margin = new System.Windows.Forms.Padding(0);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(195, 37);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "Bride Info.";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // bgwSavingPayment
            // 
            bgwSavingPayment.WorkerReportsProgress = true;
            bgwSavingPayment.WorkerSupportsCancellation = true;
            bgwSavingPayment.DoWork += backgroundWorker1_DoWork;
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
            tabPagePayment.Enter += tabPagePayment_Enter;
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
            // tabPageFees
            // 
            tabPageFees.Controls.Add(ucPaymentFeesCharges1);
            tabPageFees.Location = new System.Drawing.Point(4, 5);
            tabPageFees.Margin = new System.Windows.Forms.Padding(0);
            tabPageFees.Name = "tabPageFees";
            tabPageFees.Size = new System.Drawing.Size(746, 475);
            tabPageFees.TabIndex = 1;
            tabPageFees.Text = "tabPageFees";
            tabPageFees.UseVisualStyleBackColor = true;
            tabPageFees.Enter += tabPageFees_Enter;
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPageMarriageDetails);
            tabControlMain.Controls.Add(tabPageGroomInfo);
            tabControlMain.Controls.Add(tabPageBrideInfo);
            tabControlMain.Controls.Add(tabPageFees);
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
            groupBox2.Controls.Add(ucSpouseInfo1);
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
            // ucSpouseInfo1
            // 
            ucSpouseInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSpouseInfo1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucSpouseInfo1.Location = new System.Drawing.Point(4, 24);
            ucSpouseInfo1.Name = "ucSpouseInfo1";
            ucSpouseInfo1.Size = new System.Drawing.Size(738, 447);
            ucSpouseInfo1.TabIndex = 0;
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
            groupBox3.Controls.Add(ucSpouseInfo2);
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
            // ucSpouseInfo2
            // 
            ucSpouseInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSpouseInfo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucSpouseInfo2.Location = new System.Drawing.Point(4, 24);
            ucSpouseInfo2.Name = "ucSpouseInfo2";
            ucSpouseInfo2.Size = new System.Drawing.Size(738, 447);
            ucSpouseInfo2.TabIndex = 0;
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
            tabPageFees.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton radFees;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        internal System.ComponentModel.BackgroundWorker bgwSavingPayment;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.TabPage tabPageFees;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TabPage tabPageMarriageDetails;
        private System.Windows.Forms.TabPage tabPageGroomInfo;
        private System.Windows.Forms.TabPage tabPageBrideInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private ucMarriageDetails ucMarriageDetails1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ucSpouseInfo ucSpouseInfo1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ucSpouseInfo ucSpouseInfo2;
        private ucPaymentFeesCharges ucPaymentFeesCharges1;
    }
}