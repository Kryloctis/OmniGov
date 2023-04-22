namespace AccountingSystem.Views.Manage.Barangay
{
    partial class ucBarangay
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
            label2 = new System.Windows.Forms.Label();
            txtBarangay = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtCode = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 16;
            label2.Text = "Barangay";
            // 
            // txtBarangay
            // 
            txtBarangay.AcceptsReturn = true;
            txtBarangay.AcceptsTab = true;
            txtBarangay.Location = new System.Drawing.Point(68, 31);
            txtBarangay.MaxLength = 45;
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new System.Drawing.Size(218, 23);
            txtBarangay.TabIndex = 1;
            txtBarangay.Validating += txtBarangay_Validating;
            txtBarangay.Validated += txtBarangay_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "Code ";
            // 
            // txtCode
            // 
            txtCode.AcceptsReturn = true;
            txtCode.AcceptsTab = true;
            txtCode.Location = new System.Drawing.Point(68, 3);
            txtCode.MaxLength = 4;
            txtCode.Name = "txtCode";
            txtCode.Size = new System.Drawing.Size(218, 23);
            txtCode.TabIndex = 0;
            txtCode.Validating += txtCode_Validating;
            txtCode.Validated += txtCode_Validated;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucBarangay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(txtCode);
            Controls.Add(txtBarangay);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucBarangay";
            Size = new System.Drawing.Size(309, 59);
            Load += ucBarangay_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtBarangay;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
