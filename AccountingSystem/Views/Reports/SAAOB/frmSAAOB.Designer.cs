
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
            this.panelConfig = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.chkBxAdvanceMode = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
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
            this.dtAsOf.Location = new System.Drawing.Point(362, 12);
            this.dtAsOf.Name = "dtAsOf";
            this.dtAsOf.Size = new System.Drawing.Size(211, 23);
            this.dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            this.cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFund.FormattingEnabled = true;
            this.cmbxFund.Location = new System.Drawing.Point(81, 12);
            this.cmbxFund.Name = "cmbxFund";
            this.cmbxFund.Size = new System.Drawing.Size(218, 23);
            this.cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(596, 12);
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
            this.label2.Location = new System.Drawing.Point(322, 16);
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
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 603);
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
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Controls.Add(this.btnOne);
            this.panelConfig.Controls.Add(this.btnTwo);
            this.panelConfig.Controls.Add(this.btnThree);
            this.panelConfig.Controls.Add(this.btnFour);
            this.panelConfig.Controls.Add(this.btnFive);
            this.panelConfig.Controls.Add(this.chkBxAdvanceMode);
            this.panelConfig.Controls.Add(this.btnPrint);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig.Location = new System.Drawing.Point(0, 47);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(915, 35);
            this.panelConfig.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filter Level";
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(81, 6);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(27, 23);
            this.btnOne.TabIndex = 9;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // btnTwo
            // 
            this.btnTwo.Location = new System.Drawing.Point(114, 6);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(27, 23);
            this.btnTwo.TabIndex = 10;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            // 
            // btnThree
            // 
            this.btnThree.Location = new System.Drawing.Point(147, 6);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(27, 23);
            this.btnThree.TabIndex = 11;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = true;
            this.btnThree.Click += new System.EventHandler(this.btnThree_Click);
            // 
            // btnFour
            // 
            this.btnFour.Location = new System.Drawing.Point(180, 6);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(27, 23);
            this.btnFour.TabIndex = 12;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = true;
            this.btnFour.Click += new System.EventHandler(this.btnFour_Click);
            // 
            // btnFive
            // 
            this.btnFive.Location = new System.Drawing.Point(213, 6);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(27, 23);
            this.btnFive.TabIndex = 13;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = true;
            this.btnFive.Click += new System.EventHandler(this.btnFive_Click);
            // 
            // chkBxAdvanceMode
            // 
            this.chkBxAdvanceMode.AutoSize = true;
            this.chkBxAdvanceMode.Location = new System.Drawing.Point(362, 10);
            this.chkBxAdvanceMode.Margin = new System.Windows.Forms.Padding(17, 7, 3, 3);
            this.chkBxAdvanceMode.Name = "chkBxAdvanceMode";
            this.chkBxAdvanceMode.Size = new System.Drawing.Size(106, 19);
            this.chkBxAdvanceMode.TabIndex = 16;
            this.chkBxAdvanceMode.Text = "Advance Mode";
            this.chkBxAdvanceMode.UseVisualStyleBackColor = true;
            this.chkBxAdvanceMode.CheckedChanged += new System.EventHandler(this.chkBxAdvanceMode_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::AccountingSystem.Properties.Resources.print_14px;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(596, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 23);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.MinimumSize = new System.Drawing.Size(931, 628);
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
        internal System.Windows.Forms.Button btnOne;
        internal System.Windows.Forms.Button btnTwo;
        internal System.Windows.Forms.Button btnThree;
        internal System.Windows.Forms.Button btnFour;
        internal System.Windows.Forms.Button btnFive;
        internal System.Windows.Forms.CheckBox chkBxAdvanceMode;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Panel panelConfig;
    }
}