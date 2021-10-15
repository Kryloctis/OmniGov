
namespace AccountingSystem.Views.Manage.Amortization
{
    partial class ucAmortization
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
            this.epAmountRelease = new System.Windows.Forms.ErrorProvider(this.components);
            this.epBankName = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.cmbxTerm = new System.Windows.Forms.ComboBox();
            this.nudAmountRelease = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.epAmountRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountRelease)).BeginInit();
            this.SuspendLayout();
            // 
            // epAmountRelease
            // 
            this.epAmountRelease.ContainerControl = this;
            // 
            // epBankName
            // 
            this.epBankName.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Term";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Amount Release";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(106, 3);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(371, 23);
            this.txtBankName.TabIndex = 1;
            // 
            // cmbxTerm
            // 
            this.cmbxTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTerm.FormattingEnabled = true;
            this.cmbxTerm.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Annualy"});
            this.cmbxTerm.Location = new System.Drawing.Point(106, 32);
            this.cmbxTerm.Name = "cmbxTerm";
            this.cmbxTerm.Size = new System.Drawing.Size(371, 23);
            this.cmbxTerm.TabIndex = 2;
            // 
            // nudAmountRelease
            // 
            this.nudAmountRelease.DecimalPlaces = 2;
            this.nudAmountRelease.Location = new System.Drawing.Point(106, 61);
            this.nudAmountRelease.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.nudAmountRelease.Name = "nudAmountRelease";
            this.nudAmountRelease.Size = new System.Drawing.Size(371, 23);
            this.nudAmountRelease.TabIndex = 3;
            this.nudAmountRelease.ThousandsSeparator = true;
            this.nudAmountRelease.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ucAmortization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.nudAmountRelease);
            this.Controls.Add(this.cmbxTerm);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAmortization";
            this.Size = new System.Drawing.Size(499, 87);
            ((System.ComponentModel.ISupportInitialize)(this.epAmountRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountRelease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epAmountRelease;
        private System.Windows.Forms.ErrorProvider epBankName;
        internal System.Windows.Forms.NumericUpDown nudAmountRelease;
        internal System.Windows.Forms.ComboBox cmbxTerm;
        internal System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
