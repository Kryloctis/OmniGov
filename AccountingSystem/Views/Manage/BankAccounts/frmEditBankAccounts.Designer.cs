namespace AccountingSystem.Views.Manage.BankAccounts
{
    partial class frmEditBankAccounts
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
            btnSave = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            ucBankAccounts1 = new ucBankAccounts();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(368, 28);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(215, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(150, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(59, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(150, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Update (Ctrl +S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucBankAccounts1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(368, 94);
            panel1.TabIndex = 4;
            // 
            // ucBankAccounts1
            // 
            ucBankAccounts1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucBankAccounts1.Location = new System.Drawing.Point(4, 4);
            ucBankAccounts1.Name = "ucBankAccounts1";
            ucBankAccounts1.Size = new System.Drawing.Size(360, 86);
            ucBankAccounts1.TabIndex = 0;
            // 
            // frmEditBankAccounts
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(368, 94);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditBankAccounts";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Bank Accounts";
            Load += frmEditBankAccounts_Load;
            KeyDown += frmEditBankAccounts_KeyDown;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private ucBankAccounts ucBankAccounts1;
    }
}