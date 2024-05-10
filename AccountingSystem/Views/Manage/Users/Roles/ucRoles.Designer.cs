
namespace AccountingSystem.Views.Manage.Users.Roles
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
            cmbxOffice = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            dgPermissions = new System.Windows.Forms.DataGridView();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgPermissions).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(1, 2);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 3;
            label1.Text = "Name*";
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtName.Location = new System.Drawing.Point(82, 2);
            txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtName.MaxLength = 99;
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(250, 23);
            txtName.TabIndex = 2;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // epName
            // 
            epName.ContainerControl = this;
            // 
            // cmbxOffice
            // 
            cmbxOffice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxOffice.FormattingEnabled = true;
            cmbxOffice.Location = new System.Drawing.Point(82, 30);
            cmbxOffice.Name = "cmbxOffice";
            cmbxOffice.Size = new System.Drawing.Size(250, 23);
            cmbxOffice.TabIndex = 4;
            cmbxOffice.SelectedValueChanged += CmbxOffice_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(1, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(44, 15);
            label2.TabIndex = 5;
            label2.Text = "Office*";
            // 
            // dgPermissions
            // 
            dgPermissions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPermissions.Location = new System.Drawing.Point(82, 59);
            dgPermissions.Name = "dgPermissions";
            dgPermissions.RowTemplate.Height = 25;
            dgPermissions.Size = new System.Drawing.Size(250, 198);
            dgPermissions.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(1, 59);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 15);
            label3.TabIndex = 3;
            label3.Text = "Permissions*";
            // 
            // ucRoles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dgPermissions);
            Controls.Add(label2);
            Controls.Add(cmbxOffice);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtName);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "ucRoles";
            Size = new System.Drawing.Size(353, 267);
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgPermissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbxOffice;
        internal System.Windows.Forms.DataGridView dgPermissions;
        private System.Windows.Forms.Label label3;
    }
}
