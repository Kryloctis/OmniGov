namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    partial class frmCattleOwnership
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
            bgwSavingPayment = new System.ComponentModel.BackgroundWorker();
            radFeesCharges = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            btnCancel = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageOwner = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucPaymentRegistry1 = new ucPaymentRegistry();
            tabPageCattleDetails = new System.Windows.Forms.TabPage();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ucCattleDetails1 = new ucCattleDetails();
            tabPageFeesCharges = new System.Windows.Forms.TabPage();
            ucFeesCharges1 = new ucFeesCharges();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radOwner = new System.Windows.Forms.RadioButton();
            radCattleDetails = new System.Windows.Forms.RadioButton();
            flowLayoutPanel1.SuspendLayout();
            tabPagePayment.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageOwner.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageCattleDetails.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPageFeesCharges.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // bgwSavingPayment
            // 
            bgwSavingPayment.WorkerReportsProgress = true;
            bgwSavingPayment.WorkerSupportsCancellation = true;
            bgwSavingPayment.DoWork += bgwSavingPayment_DoWork;
            bgwSavingPayment.ProgressChanged += bgwSavingPayment_ProgressChanged;
            bgwSavingPayment.RunWorkerCompleted += bgwSavingPayment_RunWorkerCompleted;
            // 
            // radFeesCharges
            // 
            radFeesCharges.Appearance = System.Windows.Forms.Appearance.Button;
            radFeesCharges.FlatAppearance.BorderSize = 0;
            radFeesCharges.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFeesCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFeesCharges.Location = new System.Drawing.Point(0, 74);
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
            radPayment.Location = new System.Drawing.Point(0, 111);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
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
            btnBackMain.TabIndex = 0;
            btnBackMain.Text = "Back";
            btnBackMain.UseVisualStyleBackColor = true;
            btnBackMain.Click += btnBackMain_Click;
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
            flowLayoutPanel1.TabIndex = 11;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Size = new System.Drawing.Size(824, 456);
            tabPagePayment.TabIndex = 2;
            tabPagePayment.Text = "tabPagePayment";
            tabPagePayment.UseVisualStyleBackColor = true;
            // 
            // ucPayment1
            // 
            ucPayment1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ucPayment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucPayment1.Location = new System.Drawing.Point(0, 0);
            ucPayment1.Name = "ucPayment1";
            ucPayment1.Size = new System.Drawing.Size(824, 460);
            ucPayment1.TabIndex = 0;
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPageOwner);
            tabControlMain.Controls.Add(tabPageCattleDetails);
            tabControlMain.Controls.Add(tabPageFeesCharges);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new System.Drawing.Point(0, 0);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(832, 465);
            tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlMain.TabIndex = 12;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageOwner
            // 
            tabPageOwner.Controls.Add(groupBox1);
            tabPageOwner.Location = new System.Drawing.Point(4, 5);
            tabPageOwner.Name = "tabPageOwner";
            tabPageOwner.Size = new System.Drawing.Size(824, 456);
            tabPageOwner.TabIndex = 3;
            tabPageOwner.Text = "tabPageOwner";
            tabPageOwner.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucPaymentRegistry1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(824, 456);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Owner";
            // 
            // ucPaymentRegistry1
            // 
            ucPaymentRegistry1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentRegistry1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucPaymentRegistry1.Location = new System.Drawing.Point(3, 23);
            ucPaymentRegistry1.Name = "ucPaymentRegistry1";
            ucPaymentRegistry1.Size = new System.Drawing.Size(818, 430);
            ucPaymentRegistry1.TabIndex = 1;
            // 
            // tabPageCattleDetails
            // 
            tabPageCattleDetails.Controls.Add(groupBox2);
            tabPageCattleDetails.Location = new System.Drawing.Point(4, 5);
            tabPageCattleDetails.Name = "tabPageCattleDetails";
            tabPageCattleDetails.Size = new System.Drawing.Size(824, 456);
            tabPageCattleDetails.TabIndex = 4;
            tabPageCattleDetails.Text = "tabPageCattleDetails";
            tabPageCattleDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ucCattleDetails1);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4);
            groupBox2.Size = new System.Drawing.Size(824, 456);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cattle Details";
            // 
            // ucCattleDetails1
            // 
            ucCattleDetails1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucCattleDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCattleDetails1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ucCattleDetails1.Location = new System.Drawing.Point(4, 24);
            ucCattleDetails1.Name = "ucCattleDetails1";
            ucCattleDetails1.Size = new System.Drawing.Size(816, 428);
            ucCattleDetails1.TabIndex = 0;
            // 
            // tabPageFeesCharges
            // 
            tabPageFeesCharges.Controls.Add(ucFeesCharges1);
            tabPageFeesCharges.Location = new System.Drawing.Point(4, 5);
            tabPageFeesCharges.Margin = new System.Windows.Forms.Padding(0);
            tabPageFeesCharges.Name = "tabPageFeesCharges";
            tabPageFeesCharges.Size = new System.Drawing.Size(824, 456);
            tabPageFeesCharges.TabIndex = 1;
            tabPageFeesCharges.Text = "tabPageFeesCharges";
            tabPageFeesCharges.UseVisualStyleBackColor = true;
            // 
            // ucFeesCharges1
            // 
            ucFeesCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucFeesCharges1.Location = new System.Drawing.Point(0, 0);
            ucFeesCharges1.Name = "ucFeesCharges1";
            ucFeesCharges1.Size = new System.Drawing.Size(824, 456);
            ucFeesCharges1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(radOwner);
            flowLayoutPanel2.Controls.Add(radCattleDetails);
            flowLayoutPanel2.Controls.Add(radFeesCharges);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 496);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // radOwner
            // 
            radOwner.Appearance = System.Windows.Forms.Appearance.Button;
            radOwner.BackColor = System.Drawing.Color.Transparent;
            radOwner.FlatAppearance.BorderSize = 0;
            radOwner.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radOwner.Location = new System.Drawing.Point(0, 0);
            radOwner.Margin = new System.Windows.Forms.Padding(0);
            radOwner.Name = "radOwner";
            radOwner.Size = new System.Drawing.Size(195, 37);
            radOwner.TabIndex = 6;
            radOwner.Text = "Owner";
            radOwner.UseVisualStyleBackColor = false;
            // 
            // radCattleDetails
            // 
            radCattleDetails.Appearance = System.Windows.Forms.Appearance.Button;
            radCattleDetails.FlatAppearance.BorderSize = 0;
            radCattleDetails.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radCattleDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radCattleDetails.Location = new System.Drawing.Point(0, 37);
            radCattleDetails.Margin = new System.Windows.Forms.Padding(0);
            radCattleDetails.Name = "radCattleDetails";
            radCattleDetails.Size = new System.Drawing.Size(195, 37);
            radCattleDetails.TabIndex = 7;
            radCattleDetails.Text = "Cattle Details";
            radCattleDetails.UseVisualStyleBackColor = true;
            // 
            // frmCattleOwnership
            // 
            AcceptButton = btnNextMain;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            MinimizeBox = false;
            Name = "frmCattleOwnership";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payment > AF 53 - Cattle Ownership";
            Load += frmCattleOwnership_Load;
            flowLayoutPanel1.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageOwner.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageCattleDetails.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabPageFeesCharges.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwSavingPayment;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageFeesCharges;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TabPage tabPageOwner;
        private System.Windows.Forms.TabPage tabPageCattleDetails;
        private System.Windows.Forms.RadioButton radFeesCharges;
        private System.Windows.Forms.RadioButton radOwner;
        private System.Windows.Forms.RadioButton radCattleDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private ucPaymentRegistry ucPaymentRegistry1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ucCattleDetails ucCattleDetails1;
        private ucFeesCharges ucFeesCharges1;
    }
}