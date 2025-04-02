
namespace LFS.Views.Manage.AllotmentRelease
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
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnreleasedBal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxBudgetAppropriations = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemainingBal = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(128, 87);
            this.nudAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(419, 23);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(128, 29);
            this.nudYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(419, 23);
            this.nudYear.TabIndex = 49;
            this.nudYear.Value = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);
            this.nudYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudYear_Validating);
            this.nudYear.Validated += new System.EventHandler(this.nudYear_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Year";
            // 
            // txtUnreleasedBal
            // 
            this.txtUnreleasedBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnreleasedBal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnreleasedBal.Location = new System.Drawing.Point(128, 58);
            this.txtUnreleasedBal.Name = "txtUnreleasedBal";
            this.txtUnreleasedBal.ReadOnly = true;
            this.txtUnreleasedBal.Size = new System.Drawing.Size(419, 23);
            this.txtUnreleasedBal.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "Unrealeased Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Budget Appropriation";
            // 
            // cmbxBudgetAppropriations
            // 
            this.cmbxBudgetAppropriations.FormattingEnabled = true;
            this.cmbxBudgetAppropriations.IntegralHeight = false;
            this.cmbxBudgetAppropriations.Location = new System.Drawing.Point(128, 0);
            this.cmbxBudgetAppropriations.Name = "cmbxBudgetAppropriations";
            this.cmbxBudgetAppropriations.Size = new System.Drawing.Size(419, 23);
            this.cmbxBudgetAppropriations.TabIndex = 44;
            this.cmbxBudgetAppropriations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxBudgetAppropriations_KeyDown);
            this.cmbxBudgetAppropriations.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxBudgetAppropriations_Validating);
            this.cmbxBudgetAppropriations.Validated += new System.EventHandler(this.cmbxBudgetAppropriations_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "Remaining Balance";
            // 
            // txtRemainingBal
            // 
            this.txtRemainingBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemainingBal.Location = new System.Drawing.Point(128, 116);
            this.txtRemainingBal.Name = "txtRemainingBal";
            this.txtRemainingBal.ReadOnly = true;
            this.txtRemainingBal.Size = new System.Drawing.Size(419, 23);
            this.txtRemainingBal.TabIndex = 51;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucAllotmentRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtRemainingBal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUnreleasedBal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxBudgetAppropriations);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label1);
            this.Name = "ucAllotmentRelease";
            this.Size = new System.Drawing.Size(565, 142);
            this.Load += new System.EventHandler(this.ucAllotmentRelease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtUnreleasedBal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbxBudgetAppropriations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemainingBal;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
