
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
            dgPermissions = new System.Windows.Forms.DataGridView();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgPermissions).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 0);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(78, 30);
            label1.TabIndex = 3;
            label1.Text = "Name*";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(11, 34);
            txtName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 10);
            txtName.MaxLength = 99;
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(431, 35);
            txtName.TabIndex = 2;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // epName
            // 
            epName.ContainerControl = this;
            // 
            // dgPermissions
            // 
            dgPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPermissions.Location = new System.Drawing.Point(11, 119);
            dgPermissions.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dgPermissions.Name = "dgPermissions";
            dgPermissions.RowHeadersWidth = 72;
            dgPermissions.RowTemplate.Height = 25;
            dgPermissions.Size = new System.Drawing.Size(434, 396);
            dgPermissions.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 83);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(130, 30);
            label3.TabIndex = 3;
            label3.Text = "Permissions*";
            // 
            // ucRoles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dgPermissions);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtName);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "ucRoles";
            Size = new System.Drawing.Size(481, 535);
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgPermissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider epName;
        internal System.Windows.Forms.DataGridView dgPermissions;
        private System.Windows.Forms.Label label3;
    }
}
