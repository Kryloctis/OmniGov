
namespace AccountingSystem.Views.Reports.Saaob
{
    partial class frmSaaob
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
            panel1 = new System.Windows.Forms.Panel();
            chkbxSpecialFPP = new System.Windows.Forms.CheckBox();
            dtAsOf = new System.Windows.Forms.DateTimePicker();
            cmbxFund = new System.Windows.Forms.ComboBox();
            btnRetrieve = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            panelConfig = new System.Windows.Forms.Panel();
            radBtn5 = new System.Windows.Forms.RadioButton();
            radBtn4 = new System.Windows.Forms.RadioButton();
            radBtn3 = new System.Windows.Forms.RadioButton();
            radBtn2 = new System.Windows.Forms.RadioButton();
            radBtn1 = new System.Windows.Forms.RadioButton();
            label3 = new System.Windows.Forms.Label();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            panel1.SuspendLayout();
            panelConfig.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(chkbxSpecialFPP);
            panel1.Controls.Add(dtAsOf);
            panel1.Controls.Add(cmbxFund);
            panel1.Controls.Add(btnRetrieve);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(886, 37);
            panel1.TabIndex = 0;
            // 
            // chkbxSpecialFPP
            // 
            chkbxSpecialFPP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkbxSpecialFPP.AutoSize = true;
            chkbxSpecialFPP.Location = new System.Drawing.Point(607, 9);
            chkbxSpecialFPP.Name = "chkbxSpecialFPP";
            chkbxSpecialFPP.Size = new System.Drawing.Size(116, 19);
            chkbxSpecialFPP.TabIndex = 7;
            chkbxSpecialFPP.Text = "Special Accounts";
            chkbxSpecialFPP.UseVisualStyleBackColor = true;
            // 
            // dtAsOf
            // 
            dtAsOf.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtAsOf.CustomFormat = "MMM dd, yyyy";
            dtAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAsOf.Location = new System.Drawing.Point(471, 7);
            dtAsOf.Name = "dtAsOf";
            dtAsOf.Size = new System.Drawing.Size(130, 23);
            dtAsOf.TabIndex = 6;
            // 
            // cmbxFund
            // 
            cmbxFund.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbxFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxFund.FormattingEnabled = true;
            cmbxFund.Location = new System.Drawing.Point(247, 7);
            cmbxFund.Name = "cmbxFund";
            cmbxFund.Size = new System.Drawing.Size(218, 23);
            cmbxFund.TabIndex = 5;
            // 
            // btnRetrieve
            // 
            btnRetrieve.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRetrieve.Location = new System.Drawing.Point(729, 7);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new System.Drawing.Size(150, 23);
            btnRetrieve.TabIndex = 4;
            btnRetrieve.Text = "Run Report";
            btnRetrieve.UseVisualStyleBackColor = true;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(886, 394);
            panel2.TabIndex = 1;
            // 
            // panelConfig
            // 
            panelConfig.BackColor = System.Drawing.Color.White;
            panelConfig.Controls.Add(radBtn5);
            panelConfig.Controls.Add(radBtn4);
            panelConfig.Controls.Add(radBtn3);
            panelConfig.Controls.Add(radBtn2);
            panelConfig.Controls.Add(radBtn1);
            panelConfig.Controls.Add(label3);
            panelConfig.Dock = System.Windows.Forms.DockStyle.Top;
            panelConfig.Location = new System.Drawing.Point(0, 37);
            panelConfig.Name = "panelConfig";
            panelConfig.Size = new System.Drawing.Size(886, 23);
            panelConfig.TabIndex = 2;
            // 
            // radBtn5
            // 
            radBtn5.AutoSize = true;
            radBtn5.Checked = true;
            radBtn5.Location = new System.Drawing.Point(227, 3);
            radBtn5.Name = "radBtn5";
            radBtn5.Size = new System.Drawing.Size(31, 19);
            radBtn5.TabIndex = 18;
            radBtn5.TabStop = true;
            radBtn5.Text = "5";
            radBtn5.UseVisualStyleBackColor = true;
            radBtn5.CheckedChanged += radBtn5_CheckedChanged;
            // 
            // radBtn4
            // 
            radBtn4.AutoSize = true;
            radBtn4.Location = new System.Drawing.Point(190, 3);
            radBtn4.Name = "radBtn4";
            radBtn4.Size = new System.Drawing.Size(31, 19);
            radBtn4.TabIndex = 18;
            radBtn4.Text = "4";
            radBtn4.UseVisualStyleBackColor = true;
            radBtn4.CheckedChanged += radBtn4_CheckedChanged;
            // 
            // radBtn3
            // 
            radBtn3.AutoSize = true;
            radBtn3.Location = new System.Drawing.Point(153, 3);
            radBtn3.Name = "radBtn3";
            radBtn3.Size = new System.Drawing.Size(31, 19);
            radBtn3.TabIndex = 18;
            radBtn3.Text = "3";
            radBtn3.UseVisualStyleBackColor = true;
            radBtn3.CheckedChanged += radBtn3_CheckedChanged;
            // 
            // radBtn2
            // 
            radBtn2.AutoSize = true;
            radBtn2.Location = new System.Drawing.Point(116, 3);
            radBtn2.Name = "radBtn2";
            radBtn2.Size = new System.Drawing.Size(31, 19);
            radBtn2.TabIndex = 18;
            radBtn2.Text = "2";
            radBtn2.UseVisualStyleBackColor = true;
            radBtn2.CheckedChanged += radBtn2_CheckedChanged;
            // 
            // radBtn1
            // 
            radBtn1.AutoSize = true;
            radBtn1.Location = new System.Drawing.Point(79, 3);
            radBtn1.Name = "radBtn1";
            radBtn1.Size = new System.Drawing.Size(31, 19);
            radBtn1.TabIndex = 18;
            radBtn1.Text = "1";
            radBtn1.UseVisualStyleBackColor = true;
            radBtn1.CheckedChanged += radBtn1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 4);
            label3.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 15;
            label3.Text = "Filter Level";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(886, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // frmSaaob
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(886, 476);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(panelConfig);
            Controls.Add(panel1);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(902, 515);
            Name = "frmSaaob";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > Status of Appropriations, Allotments and Obligation (SAAOB)";
            Load += frmSAAOB_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelConfig.ResumeLayout(false);
            panelConfig.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button btnRetrieve;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
