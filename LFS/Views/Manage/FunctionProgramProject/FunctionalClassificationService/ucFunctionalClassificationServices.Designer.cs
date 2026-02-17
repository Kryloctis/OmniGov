
namespace LFS.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    partial class ucFunctionalClassificationServices
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbSectorName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSectorName = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSectorName)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Service Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 26);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 23);
            this.txtName.TabIndex = 14;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // cmbSectorName
            // 
            this.cmbSectorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSectorName.FormattingEnabled = true;
            this.cmbSectorName.Location = new System.Drawing.Point(96, 0);
            this.cmbSectorName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSectorName.Name = "cmbSectorName";
            this.cmbSectorName.Size = new System.Drawing.Size(324, 23);
            this.cmbSectorName.TabIndex = 12;
            this.cmbSectorName.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSectorName_Validating);
            this.cmbSectorName.Validated += new System.EventHandler(this.cmbSectorName_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sector";
            // 
            // epName
            // 
            this.epName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epName.ContainerControl = this;
            // 
            // epSectorName
            // 
            this.epSectorName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epSectorName.ContainerControl = this;
            // 
            // ucFunctionalClassificationServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cmbSectorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Name = "ucFunctionalClassificationServices";
            this.Size = new System.Drawing.Size(439, 51);
            this.Load += new System.EventHandler(this.ucFunctonalClassificationServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSectorName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.ComboBox cmbSectorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epSectorName;
    }
}
