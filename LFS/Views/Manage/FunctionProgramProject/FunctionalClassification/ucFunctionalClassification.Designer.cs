
namespace LFS.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    partial class ucFunctionalClassification
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
            txtCode = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            epCode = new System.Windows.Forms.ErrorProvider(components);
            epName = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)epCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 5;
            label1.Text = "Code";
            // 
            // txtCode
            // 
            txtCode.Location = new System.Drawing.Point(46, 2);
            txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtCode.MaxLength = 4;
            txtCode.Name = "txtCode";
            txtCode.Size = new System.Drawing.Size(324, 23);
            txtCode.TabIndex = 4;
            txtCode.Validating += txtCode_Validating;
            txtCode.Validated += txtCode_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(46, 29);
            txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(324, 23);
            txtName.TabIndex = 5;
            txtName.Validating += txtName_Validating;
            txtName.Validated += txtName_Validated;
            // 
            // epCode
            // 
            epCode.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            epCode.ContainerControl = this;
            // 
            // epName
            // 
            epName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            epName.ContainerControl = this;
            // 
            // ucFunctionalClassification
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(txtCode);
            Name = "ucFunctionalClassification";
            Size = new System.Drawing.Size(391, 57);
            ((System.ComponentModel.ISupportInitialize)epCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ErrorProvider epCode;
        private System.Windows.Forms.ErrorProvider epName;
    }
}
