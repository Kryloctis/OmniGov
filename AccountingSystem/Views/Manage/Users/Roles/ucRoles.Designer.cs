
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbOffice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDenyPermission = new System.Windows.Forms.Button();
            this.btnGrantPermission = new System.Windows.Forms.Button();
            this.btnDenyAllPermissions = new System.Windows.Forms.Button();
            this.btnGrantAllPermissions = new System.Windows.Forms.Button();
            this.dgPermissionGranted = new System.Windows.Forms.DataGridView();
            this.dgPermissions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissionGranted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 28);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 99;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(721, 23);
            this.txtName.TabIndex = 2;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // cmbOffice
            // 
            this.cmbOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffice.FormattingEnabled = true;
            this.cmbOffice.Location = new System.Drawing.Point(45, 0);
            this.cmbOffice.Name = "cmbOffice";
            this.cmbOffice.Size = new System.Drawing.Size(721, 23);
            this.cmbOffice.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Office";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 427);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissions";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDenyPermission);
            this.panel1.Controls.Add(this.btnGrantPermission);
            this.panel1.Controls.Add(this.btnDenyAllPermissions);
            this.panel1.Controls.Add(this.btnGrantAllPermissions);
            this.panel1.Controls.Add(this.dgPermissionGranted);
            this.panel1.Controls.Add(this.dgPermissions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 405);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "List:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Authorize to access:";
            // 
            // btnDenyPermission
            // 
            this.btnDenyPermission.Location = new System.Drawing.Point(344, 208);
            this.btnDenyPermission.Name = "btnDenyPermission";
            this.btnDenyPermission.Size = new System.Drawing.Size(57, 23);
            this.btnDenyPermission.TabIndex = 19;
            this.btnDenyPermission.Text = "<";
            this.btnDenyPermission.UseVisualStyleBackColor = true;
            this.btnDenyPermission.Click += new System.EventHandler(this.btnDenyPermission_Click);
            // 
            // btnGrantPermission
            // 
            this.btnGrantPermission.Location = new System.Drawing.Point(344, 179);
            this.btnGrantPermission.Name = "btnGrantPermission";
            this.btnGrantPermission.Size = new System.Drawing.Size(57, 23);
            this.btnGrantPermission.TabIndex = 18;
            this.btnGrantPermission.Text = ">";
            this.btnGrantPermission.UseVisualStyleBackColor = true;
            this.btnGrantPermission.Click += new System.EventHandler(this.btnGrantPermission_Click);
            // 
            // btnDenyAllPermissions
            // 
            this.btnDenyAllPermissions.Location = new System.Drawing.Point(344, 237);
            this.btnDenyAllPermissions.Name = "btnDenyAllPermissions";
            this.btnDenyAllPermissions.Size = new System.Drawing.Size(57, 23);
            this.btnDenyAllPermissions.TabIndex = 17;
            this.btnDenyAllPermissions.Text = "<<";
            this.btnDenyAllPermissions.UseVisualStyleBackColor = true;
            this.btnDenyAllPermissions.Click += new System.EventHandler(this.btnDenyAllPermissions_Click);
            // 
            // btnGrantAllPermissions
            // 
            this.btnGrantAllPermissions.Location = new System.Drawing.Point(344, 150);
            this.btnGrantAllPermissions.Name = "btnGrantAllPermissions";
            this.btnGrantAllPermissions.Size = new System.Drawing.Size(57, 23);
            this.btnGrantAllPermissions.TabIndex = 16;
            this.btnGrantAllPermissions.Text = ">>";
            this.btnGrantAllPermissions.UseVisualStyleBackColor = true;
            this.btnGrantAllPermissions.Click += new System.EventHandler(this.btnGrantAllPermissions_Click);
            // 
            // dgPermissionGranted
            // 
            this.dgPermissionGranted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPermissionGranted.Location = new System.Drawing.Point(407, 18);
            this.dgPermissionGranted.Name = "dgPermissionGranted";
            this.dgPermissionGranted.RowTemplate.Height = 25;
            this.dgPermissionGranted.Size = new System.Drawing.Size(335, 384);
            this.dgPermissionGranted.TabIndex = 15;
            this.dgPermissionGranted.SelectionChanged += new System.EventHandler(this.dgPermissionGranted_SelectionChanged);
            // 
            // dgPermissions
            // 
            this.dgPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPermissions.Location = new System.Drawing.Point(3, 18);
            this.dgPermissions.Name = "dgPermissions";
            this.dgPermissions.RowTemplate.Height = 25;
            this.dgPermissions.Size = new System.Drawing.Size(335, 384);
            this.dgPermissions.TabIndex = 13;
            this.dgPermissions.SelectionChanged += new System.EventHandler(this.dgPermissions_SelectionChanged);
            // 
            // ucRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOffice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucRoles";
            this.Size = new System.Drawing.Size(789, 493);
            this.Load += new System.EventHandler(this.ucRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissionGranted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDenyPermission;
        private System.Windows.Forms.Button btnGrantPermission;
        private System.Windows.Forms.Button btnDenyAllPermissions;
        private System.Windows.Forms.Button btnGrantAllPermissions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbOffice;
        internal System.Windows.Forms.DataGridView dgPermissionGranted;
        internal System.Windows.Forms.DataGridView dgPermissions;
    }
}
