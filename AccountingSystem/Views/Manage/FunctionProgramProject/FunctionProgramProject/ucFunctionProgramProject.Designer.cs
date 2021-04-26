
namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    partial class ucFunctionProgramProject
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cmbServiceName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.epServiceName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.epServiceId = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epServiceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epServiceId)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(97, 60);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 99;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 23);
            this.txtName.TabIndex = 11;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(97, 33);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.MaxLength = 4;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(324, 23);
            this.txtCode.TabIndex = 10;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            this.txtCode.Validated += new System.EventHandler(this.txtCode_Validated);
            // 
            // cmbServiceName
            // 
            this.cmbServiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceName.FormattingEnabled = true;
            this.cmbServiceName.Location = new System.Drawing.Point(97, 6);
            this.cmbServiceName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbServiceName.Name = "cmbServiceName";
            this.cmbServiceName.Size = new System.Drawing.Size(324, 23);
            this.cmbServiceName.TabIndex = 9;
            this.cmbServiceName.SelectionChangeCommitted += new System.EventHandler(this.cmbServiceName_SelectionChangeCommitted);
            this.cmbServiceName.Validated += new System.EventHandler(this.cmbServiceName_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "FPP Services";
            // 
            // txtServiceId
            // 
            this.txtServiceId.Location = new System.Drawing.Point(97, 87);
            this.txtServiceId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServiceId.MaxLength = 99;
            this.txtServiceId.Name = "txtServiceId";
            this.txtServiceId.Size = new System.Drawing.Size(324, 23);
            this.txtServiceId.TabIndex = 13;
            this.txtServiceId.Visible = false;
            this.txtServiceId.Validating += new System.ComponentModel.CancelEventHandler(this.txtServiceId_Validating);
            this.txtServiceId.Validated += new System.EventHandler(this.txtServiceId_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Service ID";
            this.label4.Visible = false;
            // 
            // epServiceName
            // 
            this.epServiceName.ContainerControl = this;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epCode
            // 
            this.epCode.ContainerControl = this;
            // 
            // epServiceId
            // 
            this.epServiceId.ContainerControl = this;
            // 
            // ucFunctionProgramProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtServiceId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cmbServiceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucFunctionProgramProject";
            this.Size = new System.Drawing.Size(445, 120);
            this.Load += new System.EventHandler(this.ucFunctionProgramProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epServiceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epServiceId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.ComboBox cmbServiceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtServiceId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider epServiceName;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epCode;
        private System.Windows.Forms.ErrorProvider epServiceId;
    }
}
