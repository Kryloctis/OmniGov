
namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    partial class frmAF51_57
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
            radPayee = new System.Windows.Forms.RadioButton();
            radFees = new System.Windows.Forms.RadioButton();
            radPayment = new System.Windows.Forms.RadioButton();
            btnBackMain = new System.Windows.Forms.Button();
            btnNextMain = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            bgwPayee = new System.ComponentModel.BackgroundWorker();
            tabControlMain = new System.Windows.Forms.TabControl();
            tabPagePayee = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ucPaymentRegistry1 = new ucPaymentRegistry();
            tabPageFeesCharges = new System.Windows.Forms.TabPage();
            tabPagePayment = new System.Windows.Forms.TabPage();
            ucPayment1 = new ucPayment();
            ucPaymentFeesCharges1 = new ucPaymentFeesCharges();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPagePayee.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageFeesCharges.SuspendLayout();
            tabPagePayment.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(radPayee);
            flowLayoutPanel2.Controls.Add(radFees);
            flowLayoutPanel2.Controls.Add(radPayment);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            flowLayoutPanel2.Enabled = false;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(195, 496);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // radPayee
            // 
            radPayee.Appearance = System.Windows.Forms.Appearance.Button;
            radPayee.FlatAppearance.BorderSize = 0;
            radPayee.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radPayee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radPayee.Location = new System.Drawing.Point(0, 0);
            radPayee.Margin = new System.Windows.Forms.Padding(0);
            radPayee.Name = "radPayee";
            radPayee.Size = new System.Drawing.Size(195, 37);
            radPayee.TabIndex = 5;
            radPayee.Text = "Payee";
            radPayee.UseVisualStyleBackColor = true;
            // 
            // radFees
            // 
            radFees.Appearance = System.Windows.Forms.Appearance.Button;
            radFees.FlatAppearance.BorderSize = 0;
            radFees.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            radFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            radFees.Location = new System.Drawing.Point(0, 37);
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
            radPayment.Location = new System.Drawing.Point(0, 74);
            radPayment.Margin = new System.Windows.Forms.Padding(0);
            radPayment.Name = "radPayment";
            radPayment.Size = new System.Drawing.Size(195, 37);
            radPayment.TabIndex = 2;
            radPayment.Text = "Payment";
            radPayment.UseVisualStyleBackColor = true;
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
            flowLayoutPanel1.TabIndex = 5;
            // 
            // bgwPayee
            // 
            bgwPayee.WorkerReportsProgress = true;
            bgwPayee.WorkerSupportsCancellation = true;
            bgwPayee.DoWork += bgwPayee_DoWork;
            bgwPayee.ProgressChanged += bgwPayee_ProgressChanged;
            bgwPayee.RunWorkerCompleted += bgwPayee_RunWorkerCompleted;
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPagePayee);
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
            tabControlMain.TabIndex = 6;
            // 
            // tabPagePayee
            // 
            tabPagePayee.Controls.Add(groupBox1);
            tabPagePayee.Location = new System.Drawing.Point(4, 5);
            tabPagePayee.Margin = new System.Windows.Forms.Padding(0);
            tabPagePayee.Name = "tabPagePayee";
            tabPagePayee.Size = new System.Drawing.Size(824, 456);
            tabPagePayee.TabIndex = 0;
            tabPagePayee.Text = "tabPagePayee";
            tabPagePayee.UseVisualStyleBackColor = true;
            tabPagePayee.Enter += tabPagePayee_Enter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ucPaymentRegistry1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(824, 456);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Payee";
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
            // tabPageFeesCharges
            // 
            tabPageFeesCharges.Controls.Add(ucPaymentFeesCharges1);
            tabPageFeesCharges.Location = new System.Drawing.Point(4, 5);
            tabPageFeesCharges.Name = "tabPageFeesCharges";
            tabPageFeesCharges.Padding = new System.Windows.Forms.Padding(3);
            tabPageFeesCharges.Size = new System.Drawing.Size(824, 456);
            tabPageFeesCharges.TabIndex = 1;
            tabPageFeesCharges.Text = "tabPageFees";
            tabPageFeesCharges.UseVisualStyleBackColor = true;
            tabPageFeesCharges.Enter += tabPageFees_Enter;
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
            tabPagePayment.Enter += tabPagePayment_Enter;
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
            // ucPaymentFeesCharges1
            // 
            ucPaymentFeesCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPaymentFeesCharges1.Location = new System.Drawing.Point(3, 3);
            ucPaymentFeesCharges1.Name = "ucPaymentFeesCharges1";
            ucPaymentFeesCharges1.Size = new System.Drawing.Size(818, 450);
            ucPaymentFeesCharges1.TabIndex = 0;
            // 
            // frmAF51_57
            // 
            AcceptButton = btnNextMain;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            BackColor = System.Drawing.Color.White;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(1027, 496);
            Controls.Add(tabControlMain);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAF51_57";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Payments > AF51 & 57";
            Load += frmAF51_57_Load;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPagePayee.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tabPageFeesCharges.ResumeLayout(false);
            tabPagePayment.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radPayee;
        private System.Windows.Forms.RadioButton radFees;
        private System.Windows.Forms.RadioButton radPayment;
        private System.Windows.Forms.Button btnBackMain;
        private System.Windows.Forms.Button btnNextMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker bgwPayee;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePayee;
        private System.Windows.Forms.TabPage tabPageFeesCharges;
        private System.Windows.Forms.TabPage tabPagePayment;
        private ucPayment ucPayment1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ucPaymentRegistry ucPaymentRegistry1;
        private ucPaymentFeesCharges ucPaymentFeesCharges1;
    }
}