namespace AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership
{
    partial class frmCattleTransfer
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
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            radCattleTransfer = new System.Windows.Forms.RadioButton();
            radFeesCharges = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnBackMain = new System.Windows.Forms.Button();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPageCattleTransfer = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucCattleTransfer1 = new OtherPayments.CattleTransferOfOwnership.ucCattleTransfer();
            tabPageFeesCharges = new System.Windows.Forms.TabPage();
            ucPaymentFeesCharges1 = new ucPaymentFeesCharges();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageCattleTransfer.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageFeesCharges.SuspendLayout();
            tabPagePayment.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            flowLayoutPanel2.Controls.Add(radCattleTransfer);
            flowLayoutPanel2.Controls.Add(radFeesCharges);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 496);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // radCattleTransfer
            // 
            radCattleTransfer.Appearance = System.Windows.Forms.Appearance.Button;
            radCattleTransfer.FlatAppearance.BorderSize = 0;
            radCattleTransfer.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radCattleTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radCattleTransfer.Location = new System.Drawing.Point(0, 0);
            radCattleTransfer.Margin = new System.Windows.Forms.Padding(0);
            radCattleTransfer.Name = "radCattleTransfer";
            radCattleTransfer.Size = new System.Drawing.Size(195, 37);
            radCattleTransfer.TabIndex = 7;
            radCattleTransfer.Text = "Cattle Transfer";
            radCattleTransfer.UseVisualStyleBackColor = true;
            // 
            // radFeesCharges
            // 
            radFeesCharges.Appearance = System.Windows.Forms.Appearance.Button;
            radFeesCharges.FlatAppearance.BorderSize = 0;
            radFeesCharges.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFeesCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFeesCharges.Location = new System.Drawing.Point(0, 37);
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
            radPayment.Location = new System.Drawing.Point(0, 74);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
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
            flowLayoutPanel1.TabIndex = 12;
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
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            tabControlMain.Controls.Add(tabPageCattleTransfer);
            tabControlMain.Controls.Add(tabPageFeesCharges);
            tabControlMain.Controls.Add(tabPagePayment);
            tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControlMain.ItemSize = new System.Drawing.Size(0, 1);
            tabControlMain.Location = new System.Drawing.Point(195, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new System.Drawing.Point(0, 0);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new System.Drawing.Size(832, 465);
            tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControlMain.TabIndex = 13;
            tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
            // 
            // tabPageCattleTransfer
            // 
            tabPageCattleTransfer.Controls.Add(groupBox1);
            tabPageCattleTransfer.Location = new System.Drawing.Point(4, 5);
            tabPageCattleTransfer.Name = "tabPageCattleTransfer";
            tabPageCattleTransfer.Padding = new System.Windows.Forms.Padding(3);
            tabPageCattleTransfer.Size = new System.Drawing.Size(824, 456);
            tabPageCattleTransfer.TabIndex = 0;
            tabPageCattleTransfer.Text = "tabPageCattleTransfer";
            tabPageCattleTransfer.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucCattleTransfer1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            groupBox1.Location = new System.Drawing.Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(818, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cattle Transfer";
            // 
            // ucCattleTransfer1
            // 
            ucCattleTransfer1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCattleTransfer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            ucCattleTransfer1.Location = new System.Drawing.Point(3, 25);
            ucCattleTransfer1.Name = "ucCattleTransfer1";
            ucCattleTransfer1.Size = new System.Drawing.Size(812, 422);
            ucCattleTransfer1.TabIndex = 3;
            // 
            // tabPageFeesCharges
            // 
            tabPageFeesCharges.Controls.Add(ucPaymentFeesCharges1);
            tabPageFeesCharges.Location = new System.Drawing.Point(4, 5);
            tabPageFeesCharges.Name = "tabPageFeesCharges";
            tabPageFeesCharges.Padding = new System.Windows.Forms.Padding(3);
            tabPageFeesCharges.Size = new System.Drawing.Size(824, 456);
            tabPageFeesCharges.TabIndex = 1;
            tabPageFeesCharges.Text = "tabPageFeesCharges";
            tabPageFeesCharges.UseVisualStyleBackColor = true;
            // 
            // ucPaymentFeesCharges1
            // 
            ucPaymentFeesCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentFeesCharges1.Location = new System.Drawing.Point(3, 3);
            ucPaymentFeesCharges1.Margin = new System.Windows.Forms.Padding(0);
            ucPaymentFeesCharges1.Name = "ucPaymentFeesCharges1";
            ucPaymentFeesCharges1.Size = new System.Drawing.Size(818, 450);
            ucPaymentFeesCharges1.TabIndex = 0;
            // 
            // tabPagePayment
            // 
            tabPagePayment.Controls.Add(ucPayment1);
            tabPagePayment.Location = new System.Drawing.Point(4, 5);
            tabPagePayment.Name = "tabPagePayment";
            tabPagePayment.Padding = new System.Windows.Forms.Padding(3);
            tabPagePayment.Size = new System.Drawing.Size(824, 456);
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
            ucPayment1.Size = new System.Drawing.Size(818, 450);
            ucPayment1.TabIndex = 0;
            // 
            // frmCattleTransfer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            MinimizeBox = false;
            Name = "frmCattleTransfer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payment > AF 52 - Certificate of Record of Transfer of Large Cattle";
            Load += frmCattleTransfer_Load;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageCattleTransfer.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageFeesCharges.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radCattleDetails;
        private System.Windows.Forms.RadioButton radFeesCharges;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCattleTransfer;
        private System.Windows.Forms.TabPage tabPageFeesCharges;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPaymentFeesCharges ucPaymentFeesCharges1;
        private ucPayment ucPayment1;
        private System.Windows.Forms.GroupBox groupBox1;
        private OtherPayments.CattleTransferOfOwnership.ucCattleTransfer ucCattleTransfer1;
        private System.Windows.Forms.RadioButton radCattleTransfer;
    }
}