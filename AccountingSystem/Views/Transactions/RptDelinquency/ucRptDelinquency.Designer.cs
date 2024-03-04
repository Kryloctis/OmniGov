namespace AccountingSystem.Views.Reports.RptDelinquency
{
    partial class ucRptDelinquency
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
            cmbxDelinquentPropertiesArpNo = new System.Windows.Forms.ComboBox();
            cmbxDelinquentStatus = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Properties";
            // 
            // cmbxDelinquentPropertiesArpNo
            // 
            cmbxDelinquentPropertiesArpNo.FormattingEnabled = true;
            cmbxDelinquentPropertiesArpNo.Location = new System.Drawing.Point(113, 3);
            cmbxDelinquentPropertiesArpNo.Name = "cmbxDelinquentPropertiesArpNo";
            cmbxDelinquentPropertiesArpNo.Size = new System.Drawing.Size(228, 23);
            cmbxDelinquentPropertiesArpNo.TabIndex = 1;
            cmbxDelinquentPropertiesArpNo.Validating += cmbxDelinquentPropertiesArpNo_Validating;
            cmbxDelinquentPropertiesArpNo.Validated += cmbxDelinquentPropertiesArpNo_Validated;
            // 
            // cmbxDelinquentStatus
            // 
            cmbxDelinquentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxDelinquentStatus.FormattingEnabled = true;
            cmbxDelinquentStatus.Location = new System.Drawing.Point(113, 32);
            cmbxDelinquentStatus.Name = "cmbxDelinquentStatus";
            cmbxDelinquentStatus.Size = new System.Drawing.Size(228, 23);
            cmbxDelinquentStatus.TabIndex = 3;
            cmbxDelinquentStatus.Validating += cmbxDelinquentStatus_Validating;
            cmbxDelinquentStatus.Validated += cmbxDelinquentStatus_Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(108, 15);
            label2.TabIndex = 2;
            label2.Text = "Delinquency Status";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucRptDelinquency
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbxDelinquentStatus);
            Controls.Add(label2);
            Controls.Add(cmbxDelinquentPropertiesArpNo);
            Controls.Add(label1);
            Name = "ucRptDelinquency";
            Size = new System.Drawing.Size(364, 58);
            Load += ucRptDelinquency_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbxDelinquentPropertiesArpNo;
        internal System.Windows.Forms.ComboBox cmbxDelinquentStatus;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
