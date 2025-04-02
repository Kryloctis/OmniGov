
namespace LFS.Views.Manage.Users.List
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
            label1 = new System.Windows.Forms.Label();
            txtFirstname = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtMiddleInitial = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtLastname = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            cmbRoles = new System.Windows.Forms.ComboBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            btnConfirmPasswordVisibility = new System.Windows.Forms.Button();
            btnPasswordVisibility = new System.Windows.Forms.Button();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            cmbOffice = new System.Windows.Forms.ComboBox();
            txtPrefix = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txtSuffix = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 15);
            label1.TabIndex = 5;
            label1.Text = "Prefix";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new System.Drawing.Point(119, 85);
            txtFirstname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtFirstname.MaxLength = 45;
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new System.Drawing.Size(250, 23);
            txtFirstname.TabIndex = 3;
            txtFirstname.Validating += txtFirstname_Validating;
            txtFirstname.Validated += txtFirstname_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(9, 114);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 15);
            label2.TabIndex = 7;
            label2.Text = "Middle Initial";
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new System.Drawing.Point(119, 112);
            txtMiddleInitial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtMiddleInitial.MaxLength = 1;
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new System.Drawing.Size(250, 23);
            txtMiddleInitial.TabIndex = 4;
            txtMiddleInitial.Validating += txtMiddleInitial_Validating;
            txtMiddleInitial.Validated += txtMiddleInitial_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 141);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 9;
            label3.Text = "Last Name";
            // 
            // txtLastname
            // 
            txtLastname.Location = new System.Drawing.Point(119, 139);
            txtLastname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtLastname.MaxLength = 45;
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new System.Drawing.Size(250, 23);
            txtLastname.TabIndex = 5;
            txtLastname.Validating += txtLastname_Validating;
            txtLastname.Validated += txtLastname_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 33);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(30, 15);
            label6.TabIndex = 15;
            label6.Text = "Role";
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new System.Drawing.Point(119, 31);
            cmbRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new System.Drawing.Size(250, 23);
            cmbRoles.TabIndex = 1;
            cmbRoles.Validating += cmbRoles_Validating;
            cmbRoles.Validated += cmbRoles_Validated;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            groupBox1.Location = new System.Drawing.Point(3, 201);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(400, 121);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Details";
            // 
            // panel1
            // 
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
            panel1.Location = new System.Drawing.Point(3, 19);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(394, 99);
            panel1.TabIndex = 0;
            // 
            // btnConfirmPasswordVisibility
            // 
            btnConfirmPasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            btnConfirmPasswordVisibility.FlatAppearance.BorderSize = 0;
            btnConfirmPasswordVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnConfirmPasswordVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnConfirmPasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmPasswordVisibility.Image = Properties.Resources.visible_16px;
            btnConfirmPasswordVisibility.Location = new System.Drawing.Point(366, 62);
            btnConfirmPasswordVisibility.Margin = new System.Windows.Forms.Padding(0);
            btnConfirmPasswordVisibility.Name = "btnConfirmPasswordVisibility";
            btnConfirmPasswordVisibility.Size = new System.Drawing.Size(23, 23);
            btnConfirmPasswordVisibility.TabIndex = 10;
            btnConfirmPasswordVisibility.UseVisualStyleBackColor = true;
            btnConfirmPasswordVisibility.Click += btnConfirmPasswordVisibility_Click;
            // 
            // btnPasswordVisibility
            // 
            btnPasswordVisibility.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPasswordVisibility.FlatAppearance.BorderSize = 0;
            btnPasswordVisibility.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnPasswordVisibility.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnPasswordVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPasswordVisibility.Image = Properties.Resources.visible_16px;
            btnPasswordVisibility.Location = new System.Drawing.Point(366, 34);
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
            lblConfirmPassword.Location = new System.Drawing.Point(3, 64);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(104, 15);
            lblConfirmPassword.TabIndex = 31;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new System.Drawing.Point(113, 61);
            txtConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtConfirmPassword.MaxLength = 60;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new System.Drawing.Size(250, 23);
            txtConfirmPassword.TabIndex = 9;
            txtConfirmPassword.Validating += txtConfirmPassword_Validating;
            txtConfirmPassword.Validated += txtConfirmPassword_Validated;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(3, 37);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 29;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(113, 34);
            txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPassword.MaxLength = 60;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(250, 23);
            txtPassword.TabIndex = 8;
            txtPassword.Validating += txtPassword_Validating;
            txtPassword.Validated += txtPassword_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 10);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 15);
            label4.TabIndex = 28;
            label4.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(113, 7);
            txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtUsername.MaxLength = 45;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(250, 23);
            txtUsername.TabIndex = 7;
            txtUsername.Validating += txtUsername_Validating;
            txtUsername.Validated += txtUsername_Validated;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 6);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(39, 15);
            label5.TabIndex = 15;
            label5.Text = "Office";
            // 
            // cmbOffice
            // 
            cmbOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbOffice.FormattingEnabled = true;
            cmbOffice.Location = new System.Drawing.Point(119, 3);
            cmbOffice.Name = "cmbOffice";
            cmbOffice.Size = new System.Drawing.Size(250, 23);
            cmbOffice.TabIndex = 0;
            cmbOffice.SelectedValueChanged += cmbOffice_SelectedValueChanged;
            // 
            // txtPrefix
            // 
            txtPrefix.Location = new System.Drawing.Point(119, 58);
            txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPrefix.MaxLength = 45;
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new System.Drawing.Size(250, 23);
            txtPrefix.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(11, 88);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(64, 15);
            label7.TabIndex = 5;
            label7.Text = "First Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(9, 169);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 15);
            label8.TabIndex = 5;
            label8.Text = "Suffix";
            // 
            // txtSuffix
            // 
            txtSuffix.Location = new System.Drawing.Point(119, 166);
            txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtSuffix.MaxLength = 45;
            txtSuffix.Name = "txtSuffix";
            txtSuffix.Size = new System.Drawing.Size(250, 23);
            txtSuffix.TabIndex = 6;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucUsers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtSuffix);
            Controls.Add(txtPrefix);
            Controls.Add(cmbOffice);
            Controls.Add(groupBox1);
            Controls.Add(cmbRoles);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(txtLastname);
            Controls.Add(label2);
            Controls.Add(txtMiddleInitial);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(txtFirstname);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "ucUsers";
            Size = new System.Drawing.Size(409, 326);
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblConfirmPassword;
        internal System.Windows.Forms.TextBox txtConfirmPassword;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnConfirmPasswordVisibility;
        private System.Windows.Forms.Button btnPasswordVisibility;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbOffice;
        internal System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
