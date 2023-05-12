
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class frmJEVAccountAdd
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
            btnOk = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            ucjevAccount1 = new ucJEVAccount();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnOk);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 186);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(595, 29);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(517, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(436, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOK_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucjevAccount1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(595, 215);
            panel1.TabIndex = 4;
            // 
            // ucjevAccount1
            // 
            ucjevAccount1.AutoSize = true;
            ucjevAccount1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucjevAccount1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucjevAccount1.Location = new System.Drawing.Point(4, 4);
            ucjevAccount1.Name = "ucjevAccount1";
            ucjevAccount1.Size = new System.Drawing.Size(587, 207);
            ucjevAccount1.TabIndex = 1;
            // 
            // frmJEVAccountAdd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(595, 215);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "frmJEVAccountAdd";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Account";
            Load += frmJEVAccountAdd_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        internal ucJEVAccount ucjevAccount1;
    }
}