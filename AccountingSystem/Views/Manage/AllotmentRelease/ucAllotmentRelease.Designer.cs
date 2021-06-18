
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
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.epAmount = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxBudgetAppropriations = new System.Windows.Forms.ComboBox();
            this.epBudgetAppropriation = new System.Windows.Forms.ErrorProvider(this.components);
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // nudAmount
            // 
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(135, 112);
            this.nudAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(419, 23);
            this.nudAmount.TabIndex = 4;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Validating += new System.ComponentModel.CancelEventHandler(this.nudAmount_Validating);
            this.nudAmount.Validated += new System.EventHandler(this.nudAmount_Validated);
            // 
            // epAmount
            // 
            this.epAmount.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appropriation Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbxBudgetAppropriations);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 87);
            this.panel1.TabIndex = 0;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(132, 3);
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
            this.nudYear.TabIndex = 43;
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
            this.label7.Location = new System.Drawing.Point(4, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 42;
            this.label7.Text = "Year";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(132, 61);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(419, 23);
            this.txtBalance.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Budget Appropriation";
            // 
            // cmbxBudgetAppropriations
            // 
            this.cmbxBudgetAppropriations.FormattingEnabled = true;
            this.cmbxBudgetAppropriations.IntegralHeight = false;
            this.cmbxBudgetAppropriations.Location = new System.Drawing.Point(132, 32);
            this.cmbxBudgetAppropriations.Name = "cmbxBudgetAppropriations";
            this.cmbxBudgetAppropriations.Size = new System.Drawing.Size(419, 23);
            this.cmbxBudgetAppropriations.TabIndex = 1;
            this.cmbxBudgetAppropriations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxBudgetAppropriations_KeyDown);
            this.cmbxBudgetAppropriations.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxBudgetAppropriations_Validating);
            this.cmbxBudgetAppropriations.Validated += new System.EventHandler(this.cmbxBudgetAppropriations_Validated);
            // 
            // epBudgetAppropriation
            // 
            this.epBudgetAppropriation.ContainerControl = this;
            // 
            // epYear
            // 
            this.epYear.ContainerControl = this;
            // 
            // ucAllotmentRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.label1);
            this.Name = "ucAllotmentRelease";
            this.Size = new System.Drawing.Size(579, 140);
            this.Load += new System.EventHandler(this.ucAllotmentRelease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epBudgetAppropriation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtBalance;
        internal System.Windows.Forms.ComboBox cmbxBudgetAppropriations;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ErrorProvider epBudgetAppropriation;
        internal System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider epYear;
    }
}
