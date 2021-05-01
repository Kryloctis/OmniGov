
namespace AccountingSystem.Views.Reports.RCI
{
    partial class frmRCIReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBanks = new System.Windows.Forms.ComboBox();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Bank Account:";
            // 
            // cmbBanks
            // 
            this.cmbBanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanks.FormattingEnabled = true;
            this.cmbBanks.Location = new System.Drawing.Point(126, 13);
            this.cmbBanks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBanks.Name = "cmbBanks";
            this.cmbBanks.Size = new System.Drawing.Size(209, 28);
            this.cmbBanks.TabIndex = 16;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMMM-yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(398, 12);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(175, 27);
            this.dtpMonth.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Month";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(581, 12);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(86, 31);
            this.btnRetrieve.TabIndex = 13;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(18, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 688);
            this.panel1.TabIndex = 12;
            // 
            // frmRCIReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBanks);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.panel1);
            this.Name = "frmRCIReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report > Report of Checks Issued";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRCIReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBanks;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel1;
    }
}