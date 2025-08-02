
namespace LFS.Views.Manage.Users.Roles
{
    partial class ucRoles
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
            txtName = new System.Windows.Forms.TextBox();
            epName = new System.Windows.Forms.ErrorProvider(components);
            lblPermissions = new System.Windows.Forms.Label();
            chkBxPermissions = new System.Windows.Forms.CheckedListBox();
            chkBxSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 15);
            label1.TabIndex = 3;
            label1.Text = "Role Name* :";
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            epName.SetIconPadding(txtName, 2);
            txtName.Location = new System.Drawing.Point(7, 21);
            txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 20);
            txtName.MaxLength = 99;
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(243, 23);
            txtName.TabIndex = 2;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // epName
            // 
            epName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            epName.ContainerControl = this;
            // 
            // lblPermissions
            // 
            lblPermissions.AutoSize = true;
            lblPermissions.Location = new System.Drawing.Point(7, 64);
            lblPermissions.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            lblPermissions.Name = "lblPermissions";
            lblPermissions.Size = new System.Drawing.Size(101, 15);
            lblPermissions.TabIndex = 3;
            lblPermissions.Text = "Permissions (0/0):";
            // 
            // chkBxPermissions
            // 
            chkBxPermissions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chkBxPermissions.BackColor = System.Drawing.SystemColors.Control;
            chkBxPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            chkBxPermissions.CheckOnClick = true;
            chkBxPermissions.FormattingEnabled = true;
            chkBxPermissions.HorizontalScrollbar = true;
            chkBxPermissions.Location = new System.Drawing.Point(18, 92);
            chkBxPermissions.Name = "chkBxPermissions";
            chkBxPermissions.Size = new System.Drawing.Size(245, 180);
            chkBxPermissions.Sorted = true;
            chkBxPermissions.TabIndex = 4;
            chkBxPermissions.ItemCheck += chkBxPermissions_ItemCheck;
            // 
            // chkBxSelectAll
            // 
            chkBxSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkBxSelectAll.AutoSize = true;
            chkBxSelectAll.Location = new System.Drawing.Point(175, 63);
            chkBxSelectAll.Name = "chkBxSelectAll";
            chkBxSelectAll.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            chkBxSelectAll.Size = new System.Drawing.Size(75, 19);
            chkBxSelectAll.TabIndex = 5;
            chkBxSelectAll.Text = "Select All";
            chkBxSelectAll.UseVisualStyleBackColor = true;
            chkBxSelectAll.CheckedChanged += chkBxSelectAll_CheckedChanged;
            // 
            // ucRoles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chkBxSelectAll);
            Controls.Add(chkBxPermissions);
            Controls.Add(lblPermissions);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "ucRoles";
            Padding = new System.Windows.Forms.Padding(4);
            Size = new System.Drawing.Size(270, 277);
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.CheckedListBox chkBxPermissions;
        private System.Windows.Forms.CheckBox chkBxSelectAll;
    }
}
