
namespace AccountingSystem
{
    partial class frmSignIn
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
            txtUsername = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            pcBoxEmblem = new System.Windows.Forms.PictureBox();
            label3 = new System.Windows.Forms.Label();
            btnLogin = new System.Windows.Forms.Button();
            btnVisibility = new System.Windows.Forms.Button();
            lblServer = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxEmblem).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtUsername.Location = new System.Drawing.Point(301, 73);
            txtUsername.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtUsername.MaxLength = 45;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(230, 23);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(237, 76);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(237, 105);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPassword.Location = new System.Drawing.Point(301, 102);
            txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new System.Drawing.Size(230, 23);
            txtPassword.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(24, 44, 97);
            panel1.Controls.Add(pcBoxEmblem);
            panel1.Controls.Add(label3);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(219, 218);
            panel1.TabIndex = 4;
            // 
            // pcBoxEmblem
            // 
            pcBoxEmblem.Image = Properties.Resources.local_finance_logo;
            pcBoxEmblem.Location = new System.Drawing.Point(58, 38);
            pcBoxEmblem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            pcBoxEmblem.Name = "pcBoxEmblem";
            pcBoxEmblem.Size = new System.Drawing.Size(100, 100);
            pcBoxEmblem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pcBoxEmblem.TabIndex = 2;
            pcBoxEmblem.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(28, 141);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(172, 21);
            label3.TabIndex = 1;
            label3.Text = "Local Finance System";
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(431, 144);
            btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(100, 25);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnSignIn_Click;
            // 
            // btnVisibility
            // 
            btnVisibility.FlatAppearance.BorderSize = 0;
            btnVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVisibility.Image = Properties.Resources.visible_16px;
            btnVisibility.Location = new System.Drawing.Point(533, 100);
            btnVisibility.Margin = new System.Windows.Forms.Padding(0);
            btnVisibility.Name = "btnVisibility";
            btnVisibility.Size = new System.Drawing.Size(21, 25);
            btnVisibility.TabIndex = 7;
            btnVisibility.UseVisualStyleBackColor = true;
            btnVisibility.Click += btnVisibility_Click;
            // 
            // lblServer
            // 
            lblServer.AutoEllipsis = true;
            lblServer.Location = new System.Drawing.Point(237, 194);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(294, 15);
            lblServer.TabIndex = 8;
            lblServer.Text = "(F12) Server: ---";
            lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(440, 19);
            label4.Margin = new System.Windows.Forms.Padding(2, 10, 2, 8);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(91, 21);
            label4.TabIndex = 6;
            label4.Text = "Welcome! ";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(424, 48);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(107, 15);
            label6.TabIndex = 1;
            label6.Text = "Sign in to continue";
            // 
            // frmSignIn
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(567, 218);
            Controls.Add(lblServer);
            Controls.Add(btnVisibility);
            Controls.Add(label4);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(txtUsername);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSignIn";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sign In";
            Load += SignInForm_Load;
            VisibleChanged += SignInForm_VisibleChanged;
            KeyDown += SignInForm_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxEmblem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcBoxEmblem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnVisibility;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblServer;
    }
}