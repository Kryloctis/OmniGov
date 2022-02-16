
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
            this.chkbxSpecialFPP = new System.Windows.Forms.CheckBox();
            this.dtAsOf = new System.Windows.Forms.DateTimePicker();
            this.cmbxFund = new System.Windows.Forms.ComboBox();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelConfig = new System.Windows.Forms.Panel();
            this.radBtn5 = new System.Windows.Forms.RadioButton();
            this.radBtn4 = new System.Windows.Forms.RadioButton();
            this.radBtn3 = new System.Windows.Forms.RadioButton();
            this.radBtn2 = new System.Windows.Forms.RadioButton();
            this.radBtn1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkbxSpecialFPP);
            this.panel1.Controls.Add(this.dtAsOf);
            this.panel1.Controls.Add(this.cmbxFund);
            this.panel1.Controls.Add(this.btnRetrieve);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 41);
            this.panel1.TabIndex = 0;
            // 
            // chkbxSpecialFPP
            // 
            this.chkbxSpecialFPP.AutoSize = true;
            this.chkbxSpecialFPP.Location = new System.Drawing.Point(566, 14);
            this.chkbxSpecialFPP.Name = "chkbxSpecialFPP";
            this.chkbxSpecialFPP.Size = new System.Drawing.Size(116, 19);
            this.chkbxSpecialFPP.TabIndex = 7;
            this.chkbxSpecialFPP.Text = "Special Accounts";
            this.chkbxSpecialFPP.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            this.dtAsOf.Location = new System.Drawing.Point(331, 11);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(211, 23);
            this.dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            this.cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFund.FormattingEnabled = true;
            this.cmbxFund.Location = new System.Drawing.Point(50, 12);
            this.cmbxFund.Name = "cmbxFund";
            this.cmbxFund.Size = new System.Drawing.Size(218, 23);
            this.cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(811, 11);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(92, 23);
            this.btnRetrieve.TabIndex = 4;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "As of";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 621);
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
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.Color.White;
            this.panelConfig.Controls.Add(this.radBtn5);
            this.panelConfig.Controls.Add(this.radBtn4);
            this.panelConfig.Controls.Add(this.radBtn3);
            this.panelConfig.Controls.Add(this.radBtn2);
            this.panelConfig.Controls.Add(this.radBtn1);
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig.Location = new System.Drawing.Point(0, 41);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(915, 23);
            this.panelConfig.TabIndex = 2;
            // 
            // radBtn5
            // 
            this.radBtn5.AutoSize = true;
            this.radBtn5.Checked = true;
            this.radBtn5.Location = new System.Drawing.Point(227, 3);
            this.radBtn5.Name = "radBtn5";
            this.radBtn5.Size = new System.Drawing.Size(31, 19);
            this.radBtn5.TabIndex = 18;
            this.radBtn5.TabStop = true;
            this.radBtn5.Text = "5";
            this.radBtn5.UseVisualStyleBackColor = true;
            this.radBtn5.CheckedChanged += new System.EventHandler(this.radBtn5_CheckedChanged);
            // 
            // radBtn4
            // 
            this.radBtn4.AutoSize = true;
            this.radBtn4.Location = new System.Drawing.Point(190, 3);
            this.radBtn4.Name = "radBtn4";
            this.radBtn4.Size = new System.Drawing.Size(31, 19);
            this.radBtn4.TabIndex = 18;
            this.radBtn4.Text = "4";
            this.radBtn4.UseVisualStyleBackColor = true;
            this.radBtn4.CheckedChanged += new System.EventHandler(this.radBtn4_CheckedChanged);
            // 
            // radBtn3
            // 
            this.radBtn3.AutoSize = true;
            this.radBtn3.Location = new System.Drawing.Point(153, 3);
            this.radBtn3.Name = "radBtn3";
            this.radBtn3.Size = new System.Drawing.Size(31, 19);
            this.radBtn3.TabIndex = 18;
            this.radBtn3.Text = "3";
            this.radBtn3.UseVisualStyleBackColor = true;
            this.radBtn3.CheckedChanged += new System.EventHandler(this.radBtn3_CheckedChanged);
            // 
            // radBtn2
            // 
            this.radBtn2.AutoSize = true;
            this.radBtn2.Location = new System.Drawing.Point(116, 3);
            this.radBtn2.Name = "radBtn2";
            this.radBtn2.Size = new System.Drawing.Size(31, 19);
            this.radBtn2.TabIndex = 18;
            this.radBtn2.Text = "2";
            this.radBtn2.UseVisualStyleBackColor = true;
            this.radBtn2.CheckedChanged += new System.EventHandler(this.radBtn2_CheckedChanged);
            // 
            // radBtn1
            // 
            this.radBtn1.AutoSize = true;
            this.radBtn1.Location = new System.Drawing.Point(79, 3);
            this.radBtn1.Name = "radBtn1";
            this.radBtn1.Size = new System.Drawing.Size(31, 19);
            this.radBtn1.TabIndex = 18;
            this.radBtn1.Text = "1";
            this.radBtn1.UseVisualStyleBackColor = true;
            this.radBtn1.CheckedChanged += new System.EventHandler(this.radBtn1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filter Level";
            // 
            // frmSAAOB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 685);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(931, 724);
            this.Name = "frmSAAOB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status of Appropriations, Allotments and Obligation (SAAOB)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSAAOB_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel panelConfig;
        internal System.Windows.Forms.RadioButton radBtn1;
        internal System.Windows.Forms.RadioButton radBtn5;
        internal System.Windows.Forms.RadioButton radBtn4;
        internal System.Windows.Forms.RadioButton radBtn3;
        internal System.Windows.Forms.RadioButton radBtn2;
        private System.Windows.Forms.CheckBox chkbxSpecialFPP;
    }
}