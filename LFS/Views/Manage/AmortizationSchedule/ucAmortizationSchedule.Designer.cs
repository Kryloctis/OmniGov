
namespace OmniGov.App.Views.Manage.AmortizationSchedule
{
    partial class ucAmortizationSchedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPrincipal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudInterest = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudGRT = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGRT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(59, 0);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(332, 23);
            this.dtDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Principal";
            // 
            // nudPrincipal
            // 
            this.nudPrincipal.DecimalPlaces = 2;
            this.nudPrincipal.Location = new System.Drawing.Point(59, 29);
            this.nudPrincipal.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPrincipal.Name = "nudPrincipal";
            this.nudPrincipal.Size = new System.Drawing.Size(332, 23);
            this.nudPrincipal.TabIndex = 1;
            this.nudPrincipal.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Interest";
            // 
            // nudInterest
            // 
            this.nudInterest.DecimalPlaces = 2;
            this.nudInterest.Location = new System.Drawing.Point(59, 58);
            this.nudInterest.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudInterest.Name = "nudInterest";
            this.nudInterest.Size = new System.Drawing.Size(332, 23);
            this.nudInterest.TabIndex = 2;
            this.nudInterest.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "GRT";
            // 
            // nudGRT
            // 
            this.nudGRT.DecimalPlaces = 2;
            this.nudGRT.Location = new System.Drawing.Point(59, 87);
            this.nudGRT.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudGRT.Name = "nudGRT";
            this.nudGRT.Size = new System.Drawing.Size(332, 23);
            this.nudGRT.TabIndex = 3;
            this.nudGRT.ThousandsSeparator = true;
            // 
            // ucAmortizationSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.nudGRT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudInterest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudPrincipal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label1);
            this.Name = "ucAmortizationSchedule";
            this.Size = new System.Drawing.Size(416, 113);
            this.Load += new System.EventHandler(this.ucAmortizationSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGRT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DateTimePicker dtDate;
        internal System.Windows.Forms.NumericUpDown nudPrincipal;
        internal System.Windows.Forms.NumericUpDown nudInterest;
        internal System.Windows.Forms.NumericUpDown nudGRT;
    }
}
