
namespace OmniGov.App.Views.Manage.Users
{
    partial class ucUsers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            panel1 = new System.Windows.Forms.Panel();
            btnConfirmPasswordVisibility = new System.Windows.Forms.Button();
            btnPasswordVisibility = new System.Windows.Forms.Button();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtLastname = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtMiddleInitial = new System.Windows.Forms.TextBox();
            txtPrefix = new System.Windows.Forms.TextBox();
            txtFirstname = new System.Windows.Forms.TextBox();
            txtSuffix = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            customTabControl1 = new OmniGov.App.CustomTools.CustomTabControl();
            tbPgRole = new System.Windows.Forms.TabPage();
            flwLytPnlRole = new System.Windows.Forms.FlowLayoutPanel();
            tbPgUserInfo = new System.Windows.Forms.TabPage();
            tbPgAccInf = new System.Windows.Forms.TabPage();
            panel3 = new System.Windows.Forms.Panel();
            radUserInfo = new System.Windows.Forms.RadioButton();
            radAccInfo = new System.Windows.Forms.RadioButton();
            radRole = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            customTabControl1.SuspendLayout();
            tbPgRole.SuspendLayout();
            tbPgUserInfo.SuspendLayout();
            tbPgAccInf.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(btnConfirmPasswordVisibility);
            panel1.Controls.Add(btnPasswordVisibility);
            panel1.Controls.Add(lblConfirmPassword);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtUsername);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(20, 4, 20, 4);
            panel1.Size = new System.Drawing.Size(613, 400);
            panel1.TabIndex = 1;
            // 
            // btnConfirmPasswordVisibility
            // 
            btnConfirmPasswordVisibility.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnConfirmPasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            btnConfirmPasswordVisibility.FlatAppearance.BorderSize = 0;
            btnConfirmPasswordVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnConfirmPasswordVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnConfirmPasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmPasswordVisibility.Image = Properties.Resources.visible_16px;
            btnConfirmPasswordVisibility.Location = new System.Drawing.Point(590, 133);
            btnConfirmPasswordVisibility.Margin = new System.Windows.Forms.Padding(0);
            btnConfirmPasswordVisibility.Name = "btnConfirmPasswordVisibility";
            btnConfirmPasswordVisibility.Size = new System.Drawing.Size(23, 23);
            btnConfirmPasswordVisibility.TabIndex = 10;
            btnConfirmPasswordVisibility.UseVisualStyleBackColor = true;
            btnConfirmPasswordVisibility.Click += btnConfirmPasswordVisibility_Click;
            // 
            // btnPasswordVisibility
            // 
            btnPasswordVisibility.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPasswordVisibility.FlatAppearance.BorderSize = 0;
            btnPasswordVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnPasswordVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnPasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPasswordVisibility.Image = Properties.Resources.visible_16px;
            btnPasswordVisibility.Location = new System.Drawing.Point(590, 75);
            btnPasswordVisibility.Margin = new System.Windows.Forms.Padding(0);
            btnPasswordVisibility.Name = "btnPasswordVisibility";
            btnPasswordVisibility.Size = new System.Drawing.Size(23, 23);
            btnPasswordVisibility.TabIndex = 10;
            btnPasswordVisibility.UseVisualStyleBackColor = true;
            btnPasswordVisibility.Click += btnPasswordVisibility_Click;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new System.Drawing.Point(23, 117);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(107, 15);
            lblConfirmPassword.TabIndex = 31;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtConfirmPassword.Location = new System.Drawing.Point(23, 134);
            txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtConfirmPassword.MaxLength = 60;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new System.Drawing.Size(564, 23);
            txtConfirmPassword.TabIndex = 9;
            txtConfirmPassword.Validating += txtConfirmPassword_Validating;
            txtConfirmPassword.Validated += txtConfirmPassword_Validated;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(23, 59);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(60, 15);
            lblPassword.TabIndex = 29;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPassword.Location = new System.Drawing.Point(23, 76);
            txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtPassword.MaxLength = 60;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(567, 23);
            txtPassword.TabIndex = 8;
            txtPassword.Validating += txtPassword_Validating;
            txtPassword.Validated += txtPassword_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(23, 4);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 15);
            label4.TabIndex = 28;
            label4.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtUsername.Location = new System.Drawing.Point(23, 21);
            txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtUsername.MaxLength = 45;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(567, 23);
            txtUsername.TabIndex = 7;
            txtUsername.Validating += txtUsername_Validating;
            txtUsername.Validated += txtUsername_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(170, 168);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 5;
            label1.Text = "Prefix:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 114);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(66, 15);
            label3.TabIndex = 9;
            label3.Text = "Last Name:";
            // 
            // txtLastname
            // 
            txtLastname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastname.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtLastname.Location = new System.Drawing.Point(23, 131);
            txtLastname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtLastname.MaxLength = 45;
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new System.Drawing.Size(568, 22);
            txtLastname.TabIndex = 5;
            txtLastname.Validating += txtLastname_Validating;
            txtLastname.Validated += txtLastname_Validated;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 168);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(40, 15);
            label8.TabIndex = 5;
            label8.Text = "Suffix:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 7;
            label2.Text = "Middle Initial:";
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMiddleInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleInitial.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtMiddleInitial.Location = new System.Drawing.Point(23, 77);
            txtMiddleInitial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtMiddleInitial.MaxLength = 1;
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new System.Drawing.Size(567, 22);
            txtMiddleInitial.TabIndex = 4;
            // 
            // txtPrefix
            // 
            txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPrefix.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtPrefix.Location = new System.Drawing.Point(170, 185);
            txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPrefix.MaxLength = 45;
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new System.Drawing.Size(83, 22);
            txtPrefix.TabIndex = 2;
            // 
            // txtFirstname
            // 
            txtFirstname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstname.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtFirstname.Location = new System.Drawing.Point(23, 23);
            txtFirstname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
            txtFirstname.MaxLength = 45;
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new System.Drawing.Size(567, 22);
            txtFirstname.TabIndex = 3;
            txtFirstname.Validating += txtFirstname_Validating;
            txtFirstname.Validated += txtFirstname_Validated;
            // 
            // txtSuffix
            // 
            txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtSuffix.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            txtSuffix.Location = new System.Drawing.Point(23, 185);
            txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtSuffix.MaxLength = 45;
            txtSuffix.Name = "txtSuffix";
            txtSuffix.Size = new System.Drawing.Size(95, 22);
            txtSuffix.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(23, 4);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(67, 15);
            label7.TabIndex = 5;
            label7.Text = "First Name:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtSuffix);
            panel2.Controls.Add(txtFirstname);
            panel2.Controls.Add(txtPrefix);
            panel2.Controls.Add(txtMiddleInitial);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtLastname);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(20, 4, 20, 4);
            panel2.Size = new System.Drawing.Size(613, 400);
            panel2.TabIndex = 1;
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tbPgRole);
            customTabControl1.Controls.Add(tbPgUserInfo);
            customTabControl1.Controls.Add(tbPgAccInf);
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.Location = new System.Drawing.Point(0, 46);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(621, 428);
            customTabControl1.TabIndex = 23;
            customTabControl1.SelectedIndexChanged += customTabControl1_SelectedIndexChanged;
            // 
            // tbPgRole
            // 
            tbPgRole.BackColor = System.Drawing.SystemColors.Control;
            tbPgRole.Controls.Add(flwLytPnlRole);
            tbPgRole.Location = new System.Drawing.Point(4, 24);
            tbPgRole.Name = "tbPgRole";
            tbPgRole.Size = new System.Drawing.Size(613, 400);
            tbPgRole.TabIndex = 0;
            tbPgRole.Text = "tbPgRole";
            // 
            // flwLytPnlRole
            // 
            flwLytPnlRole.AutoScroll = true;
            flwLytPnlRole.Dock = System.Windows.Forms.DockStyle.Fill;
            flwLytPnlRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            flwLytPnlRole.Location = new System.Drawing.Point(0, 0);
            flwLytPnlRole.Name = "flwLytPnlRole";
            flwLytPnlRole.Padding = new System.Windows.Forms.Padding(4);
            flwLytPnlRole.Size = new System.Drawing.Size(613, 400);
            flwLytPnlRole.TabIndex = 3;
            // 
            // tbPgUserInfo
            // 
            tbPgUserInfo.BackColor = System.Drawing.SystemColors.Control;
            tbPgUserInfo.Controls.Add(panel2);
            tbPgUserInfo.Location = new System.Drawing.Point(4, 24);
            tbPgUserInfo.Name = "tbPgUserInfo";
            tbPgUserInfo.Size = new System.Drawing.Size(613, 400);
            tbPgUserInfo.TabIndex = 1;
            tbPgUserInfo.Text = "tbPgUserInfo";
            // 
            // tbPgAccInf
            // 
            tbPgAccInf.BackColor = System.Drawing.SystemColors.Control;
            tbPgAccInf.Controls.Add(panel1);
            tbPgAccInf.Location = new System.Drawing.Point(4, 24);
            tbPgAccInf.Name = "tbPgAccInf";
            tbPgAccInf.Size = new System.Drawing.Size(613, 400);
            tbPgAccInf.TabIndex = 2;
            tbPgAccInf.Text = "tbPgAccInf";
            // 
            // panel3
            // 
            panel3.Controls.Add(radUserInfo);
            panel3.Controls.Add(radAccInfo);
            panel3.Controls.Add(radRole);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(621, 46);
            panel3.TabIndex = 24;
            // 
            // radUserInfo
            // 
            radUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            radUserInfo.AutoCheck = false;
            radUserInfo.AutoSize = true;
            radUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            radUserInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radUserInfo.Location = new System.Drawing.Point(259, 3);
            radUserInfo.Name = "radUserInfo";
            radUserInfo.Size = new System.Drawing.Size(86, 23);
            radUserInfo.TabIndex = 0;
            radUserInfo.Text = "User Info.";
            radUserInfo.UseVisualStyleBackColor = true;
            // 
            // radAccInfo
            // 
            radAccInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            radAccInfo.AutoCheck = false;
            radAccInfo.AutoSize = true;
            radAccInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            radAccInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radAccInfo.Location = new System.Drawing.Point(357, 3);
            radAccInfo.Name = "radAccInfo";
            radAccInfo.Size = new System.Drawing.Size(77, 23);
            radAccInfo.TabIndex = 0;
            radAccInfo.Text = "Account";
            radAccInfo.UseVisualStyleBackColor = true;
            // 
            // radRole
            // 
            radRole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            radRole.AutoCheck = false;
            radRole.AutoSize = true;
            radRole.Checked = true;
            radRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            radRole.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            radRole.Location = new System.Drawing.Point(187, 3);
            radRole.Name = "radRole";
            radRole.Size = new System.Drawing.Size(53, 23);
            radRole.TabIndex = 0;
            radRole.TabStop = true;
            radRole.Text = "Role";
            radRole.UseVisualStyleBackColor = true;
            // 
            // ucUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            Controls.Add(customTabControl1);
            Controls.Add(panel3);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucUsers";
            Size = new System.Drawing.Size(621, 474);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            customTabControl1.ResumeLayout(false);
            tbPgRole.ResumeLayout(false);
            tbPgUserInfo.ResumeLayout(false);
            tbPgAccInf.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirmPasswordVisibility;
        private System.Windows.Forms.Button btnPasswordVisibility;
        internal System.Windows.Forms.Label lblConfirmPassword;
        internal System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtSuffix;
        internal System.Windows.Forms.TextBox txtFirstname;
        internal System.Windows.Forms.TextBox txtPrefix;
        internal System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private OmniGov.App.CustomTools.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tbPgRole;
        private System.Windows.Forms.TabPage tbPgUserInfo;
        private System.Windows.Forms.TabPage tbPgAccInf;
        private System.Windows.Forms.FlowLayoutPanel flwLytPnlRole;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radUserInfo;
        private System.Windows.Forms.RadioButton radAccInfo;
        private System.Windows.Forms.RadioButton radRole;
        internal System.Windows.Forms.TextBox txtConfirmPassword;
        internal System.Windows.Forms.TextBox txtPassword;
    }
}
