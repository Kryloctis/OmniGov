
namespace OmniGov.App.Views.Manage.Amortization
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
            this.label4 = new System.Windows.Forms.Label();
            this.nudInterest = new System.Windows.Forms.NumericUpDown();
            this.epInterest = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epAmountRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epInterest)).BeginInit();
            this.SuspendLayout();
            // 
            // epAmountRelease
            // 
            this.epAmountRelease.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epAmountRelease.ContainerControl = this;
            // 
            // epBankName
            // 
            this.epBankName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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
            this.label3.Location = new System.Drawing.Point(4, 92);
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
            this.txtBankName.TabIndex = 0;
            this.txtBankName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBankName_Validating);
            this.txtBankName.Validated += new System.EventHandler(this.txtBankName_Validated);
            // 
            // cmbxTerm
            // 
            this.cmbxTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTerm.FormattingEnabled = true;
            this.cmbxTerm.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Annually"});
            this.cmbxTerm.Location = new System.Drawing.Point(106, 32);
            this.cmbxTerm.Name = "cmbxTerm";
            this.cmbxTerm.Size = new System.Drawing.Size(371, 23);
            this.cmbxTerm.TabIndex = 1;
            // 
            // nudAmountRelease
            // 
            this.nudAmountRelease.DecimalPlaces = 2;
            this.nudAmountRelease.Location = new System.Drawing.Point(106, 90);
            this.nudAmountRelease.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.nudAmountRelease.Name = "nudAmountRelease";
            this.nudAmountRelease.Size = new System.Drawing.Size(371, 23);
            this.nudAmountRelease.TabIndex = 3;
            this.nudAmountRelease.ThousandsSeparator = true;
            this.nudAmountRelease.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmountRelease_Validating);
            this.nudAmountRelease.Validated += new System.EventHandler(this.nudAmountRelease_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Interest";
            // 
            // nudInterest
            // 
            this.nudInterest.DecimalPlaces = 2;
            this.epInterest.SetIconPadding(this.nudInterest, 25);
            this.nudInterest.Location = new System.Drawing.Point(106, 61);
            this.nudInterest.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudInterest.Name = "nudInterest";
            this.nudInterest.Size = new System.Drawing.Size(90, 23);
            this.nudInterest.TabIndex = 2;
            this.nudInterest.Validating += new System.ComponentModel.CancelEventHandler(this.nudInterest_Validating);
            this.nudInterest.Validated += new System.EventHandler(this.nudInterest_Validated);
            // 
            // epInterest
            // 
            this.epInterest.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epInterest.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "%";
            // 
            // ucAmortization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.nudInterest);
            this.Controls.Add(this.nudAmountRelease);
            this.Controls.Add(this.cmbxTerm);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAmortization";
            this.Size = new System.Drawing.Size(499, 116);
            this.Load += new System.EventHandler(this.ucAmortization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epAmountRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmountRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epInterest)).EndInit();
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
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown nudInterest;
        private System.Windows.Forms.ErrorProvider epInterest;
        private System.Windows.Forms.Label label5;
    }
}
