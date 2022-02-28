
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
            this.cmbFunctionalClassificationService = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epServiceName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.chckboxSpecial = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.epServiceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 59);
            this.txtName.MaxLength = 99;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 23);
            this.txtName.TabIndex = 11;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(91, 30);
            this.txtCode.MaxLength = 4;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(324, 23);
            this.txtCode.TabIndex = 10;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            this.txtCode.Validated += new System.EventHandler(this.txtCode_Validated);
            // 
            // cmbFunctionalClassificationService
            // 
            this.cmbFunctionalClassificationService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunctionalClassificationService.FormattingEnabled = true;
            this.cmbFunctionalClassificationService.Location = new System.Drawing.Point(91, 2);
            this.cmbFunctionalClassificationService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFunctionalClassificationService.Name = "cmbFunctionalClassificationService";
            this.cmbFunctionalClassificationService.Size = new System.Drawing.Size(324, 23);
            this.cmbFunctionalClassificationService.TabIndex = 9;
            this.cmbFunctionalClassificationService.SelectionChangeCommitted += new System.EventHandler(this.cmbServiceName_SelectionChangeCommitted);
            this.cmbFunctionalClassificationService.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFunctionalClassificationService_Validating);
            this.cmbFunctionalClassificationService.Validated += new System.EventHandler(this.cmbFunctionalClassificationService_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Service Name";
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
            // chckboxSpecial
            // 
            this.chckboxSpecial.AutoSize = true;
            this.chckboxSpecial.Location = new System.Drawing.Point(91, 88);
            this.chckboxSpecial.Name = "chckboxSpecial";
            this.chckboxSpecial.Size = new System.Drawing.Size(63, 19);
            this.chckboxSpecial.TabIndex = 14;
            this.chckboxSpecial.Text = "Special";
            this.chckboxSpecial.UseVisualStyleBackColor = true;
            // 
            // ucFunctionProgramProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.chckboxSpecial);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cmbFunctionalClassificationService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucFunctionProgramProject";
            this.Size = new System.Drawing.Size(436, 110);
            this.Load += new System.EventHandler(this.ucFunctionProgramProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epServiceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.ComboBox cmbFunctionalClassificationService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epServiceName;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epCode;
        internal System.Windows.Forms.CheckBox chckboxSpecial;
    }
}
