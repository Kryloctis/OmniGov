
namespace AccountingSystem.Views.Manage.Users.Roles
{
    partial class ucPermissions
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPermissions = new System.Windows.Forms.ComboBox();
            this.epPermissions = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgPermissions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.epPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Added";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Permission";
            // 
            // cmbPermissions
            // 
            this.cmbPermissions.FormattingEnabled = true;
            this.cmbPermissions.Location = new System.Drawing.Point(91, 14);
            this.cmbPermissions.Name = "cmbPermissions";
            this.cmbPermissions.Size = new System.Drawing.Size(345, 28);
            this.cmbPermissions.TabIndex = 7;
            this.cmbPermissions.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPermissions_Validating);
            this.cmbPermissions.Validated += new System.EventHandler(this.cmbPermissions_Validated);
            // 
            // epPermissions
            // 
            this.epPermissions.ContainerControl = this;
            // 
            // dgPermissions
            // 
            this.dgPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPermissions.Location = new System.Drawing.Point(91, 48);
            this.dgPermissions.Name = "dgPermissions";
            this.dgPermissions.RowHeadersWidth = 51;
            this.dgPermissions.RowTemplate.Height = 29;
            this.dgPermissions.Size = new System.Drawing.Size(345, 95);
            this.dgPermissions.TabIndex = 11;
            // 
            // ucPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgPermissions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPermissions);
            this.Name = "ucPermissions";
            this.Size = new System.Drawing.Size(468, 156);
            
            ((System.ComponentModel.ISupportInitialize)(this.epPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbPermissions;
        private System.Windows.Forms.ErrorProvider epPermissions;
        private System.Windows.Forms.DataGridView dgPermissions;
    }
}
