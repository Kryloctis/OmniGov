
namespace AccountingSystem.Views.Manage.ChartOfAccounts.MajorAccountGroup
{
    partial class UcMajorAccountGroup
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAccountGroup = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.epAccountGroup = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epAccountGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // cmbAccountGroup
            // 
            this.cmbAccountGroup.FormattingEnabled = true;
            this.cmbAccountGroup.Location = new System.Drawing.Point(116, 7);
            this.cmbAccountGroup.Name = "cmbAccountGroup";
            this.cmbAccountGroup.Size = new System.Drawing.Size(370, 28);
            this.cmbAccountGroup.TabIndex = 3;
            this.cmbAccountGroup.Validating += new System.ComponentModel.CancelEventHandler(this.cmbAccountGroup_Validating);
            this.cmbAccountGroup.Validated += new System.EventHandler(this.cmbAccountGroup_Validated);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(116, 41);
            this.txtCode.MaxLength = 2;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(370, 27);
            this.txtCode.TabIndex = 4;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            this.txtCode.Validated += new System.EventHandler(this.txtCode_Validated);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 74);
            this.txtName.MaxLength = 99;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(370, 27);
            this.txtName.TabIndex = 5;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // epAccountGroup
            // 
            this.epAccountGroup.ContainerControl = this;
            // 
            // epCode
            // 
            this.epCode.ContainerControl = this;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // UcMajorAccountGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cmbAccountGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcMajorAccountGroup";
            this.Size = new System.Drawing.Size(521, 115);
            
            ((System.ComponentModel.ISupportInitialize)(this.epAccountGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epAccountGroup;
        private System.Windows.Forms.ErrorProvider epCode;
        private System.Windows.Forms.ErrorProvider epName;
        internal System.Windows.Forms.ComboBox cmbAccountGroup;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtName;
    }
}
