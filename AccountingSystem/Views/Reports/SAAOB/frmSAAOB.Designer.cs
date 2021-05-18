
namespace AccountingSystem.Views.Reports.SAAOB
{
    partial class frmSAAOB
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.cmbxFund = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtAsOf);
            this.panel1.Controls.Add(this.cmbxFund);
            this.panel1.Controls.Add(this.btnRetrieve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 47);
            this.panel1.TabIndex = 0;
            // 
            // dtAsOf
            // 
            this.dtAsOf.Location = new System.Drawing.Point(333, 11);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(211, 23);
            this.dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            this.cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFund.FormattingEnabled = true;
            this.cmbxFund.Location = new System.Drawing.Point(52, 11);
            this.cmbxFund.Name = "cmbxFund";
            this.cmbxFund.Size = new System.Drawing.Size(218, 23);
            this.cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(567, 11);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "As of";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 638);
            this.panel2.TabIndex = 1;
            // 
            // epYear
            // 
            this.epYear.ContainerControl = this;
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // frmSAAOB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 685);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(931, 628);
            this.Name = "frmSAAOB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAAOB > Status of Appropriations, Allotments and Olbigation  Summary  (SAAOB Summ" +
    "ary)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSAAOB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.ErrorProvider epYear;
        private System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.ComboBox cmbxFund;
        internal System.Windows.Forms.DateTimePicker dtAsOf;
    }
}