
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class ucAllotmentRelease
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epBudgetAppropriations = new System.Windows.Forms.ErrorProvider(this.components);
            this.epARONo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPurpose = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDateIssued = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.mskTxtAroNo = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ARO No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Date Issued";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "FPP";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(72, 29);
            this.txtPurpose.MaxLength = 100000;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(316, 23);
            this.txtPurpose.TabIndex = 3;
            this.txtPurpose.Validating += new System.ComponentModel.CancelEventHandler(this.txtPurpose_Validating);
            this.txtPurpose.Validated += new System.EventHandler(this.txtPurpose_Validated);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(72, 58);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(316, 23);
            this.dtDateIssued.TabIndex = 4;
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(72, 87);
            this.nudAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(316, 23);
            this.nudAmount.TabIndex = 5;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epBudgetAppropriations
            // 
            this.epBudgetAppropriations.ContainerControl = this;
            // 
            // epARONo
            // 
            this.epARONo.ContainerControl = this;
            // 
            // epPurpose
            // 
            this.epPurpose.ContainerControl = this;
            // 
            // epDateIssued
            // 
            this.epDateIssued.ContainerControl = this;
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // mskTxtAroNo
            // 
            this.mskTxtAroNo.Location = new System.Drawing.Point(72, 0);
            this.mskTxtAroNo.Mask = "000-0000";
            this.mskTxtAroNo.Name = "mskTxtAroNo";
            this.mskTxtAroNo.Size = new System.Drawing.Size(316, 23);
            this.mskTxtAroNo.TabIndex = 6;
            this.mskTxtAroNo.Validating += new System.ComponentModel.CancelEventHandler(this.mskTxtAroNo_Validating);
            this.mskTxtAroNo.Validated += new System.EventHandler(this.mskTxtAroNo_Validated);
            // 
            // ucAllotmentRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mskTxtAroNo);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.dtDateIssued);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAllotmentRelease";
            this.Size = new System.Drawing.Size(415, 114);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPurpose;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.ErrorProvider epBudgetAppropriations;
        private System.Windows.Forms.ErrorProvider epARONo;
        private System.Windows.Forms.ErrorProvider epPurpose;
        private System.Windows.Forms.ErrorProvider epDateIssued;
        private System.Windows.Forms.ErrorProvider epAmount;
        internal System.Windows.Forms.MaskedTextBox mskTxtAroNo;
    }
}
