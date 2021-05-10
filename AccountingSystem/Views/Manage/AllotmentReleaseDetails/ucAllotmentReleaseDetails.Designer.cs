
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class ucAllotmentReleaseDetails
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
            this.epARONo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPurpose = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDateIssued = new System.Windows.Forms.ErrorProvider(this.components);
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.mskTxtSeriesNo = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mskTxtYear = new System.Windows.Forms.MaskedTextBox();
            this.epAllotmentRelease = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentRelease)).BeginInit();
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
            this.txtPurpose.TabIndex = 1;
            this.txtPurpose.Validating += new System.ComponentModel.CancelEventHandler(this.txtPurpose_Validating);
            this.txtPurpose.Validated += new System.EventHandler(this.txtPurpose_Validated);
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.CustomFormat = "";
            this.dtDateIssued.Location = new System.Drawing.Point(72, 58);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(316, 23);
            this.dtDateIssued.TabIndex = 2;
            this.dtDateIssued.ValueChanged += new System.EventHandler(this.dtDateIssued_ValueChanged);
            this.dtDateIssued.Validating += new System.ComponentModel.CancelEventHandler(this.dtDateIssued_Validating);
            this.dtDateIssued.Validated += new System.EventHandler(this.dtDateIssued_Validated);
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
            this.nudAmount.TabIndex = 3;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
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
            // mskTxtSeriesNo
            // 
            this.mskTxtSeriesNo.Location = new System.Drawing.Point(72, 0);
            this.mskTxtSeriesNo.Mask = "000";
            this.mskTxtSeriesNo.Name = "mskTxtSeriesNo";
            this.mskTxtSeriesNo.Size = new System.Drawing.Size(28, 23);
            this.mskTxtSeriesNo.TabIndex = 0;
            this.mskTxtSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTxtSeriesNo.Validating += new System.ComponentModel.CancelEventHandler(this.mskTxtSeriesNo_Validating);
            this.mskTxtSeriesNo.Validated += new System.EventHandler(this.mskTxtSeriesNo_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "-";
            // 
            // mskTxtYear
            // 
            this.mskTxtYear.Location = new System.Drawing.Point(118, 0);
            this.mskTxtYear.Mask = "0000";
            this.mskTxtYear.Name = "mskTxtYear";
            this.mskTxtYear.ReadOnly = true;
            this.mskTxtYear.Size = new System.Drawing.Size(38, 23);
            this.mskTxtYear.TabIndex = 5;
            // 
            // epAllotmentRelease
            // 
            this.epAllotmentRelease.ContainerControl = this;
            // 
            // ucAllotmentReleaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mskTxtYear);
            this.Controls.Add(this.mskTxtSeriesNo);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.dtDateIssued);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "ucAllotmentReleaseDetails";
            this.Size = new System.Drawing.Size(409, 114);
            this.Load += new System.EventHandler(this.ucAllotmentReleaseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDateIssued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAllotmentRelease)).EndInit();
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
        private System.Windows.Forms.ErrorProvider epARONo;
        private System.Windows.Forms.ErrorProvider epPurpose;
        private System.Windows.Forms.ErrorProvider epDateIssued;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.MaskedTextBox mskTxtYear;
        internal System.Windows.Forms.MaskedTextBox mskTxtSeriesNo;
        internal System.Windows.Forms.ErrorProvider epAllotmentRelease;
    }
}
