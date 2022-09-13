
namespace AccountingSystem.Views.Reports.ConsolidatedReceipts
{
    partial class frmConsolidatedReceipts
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
            this.dtpEndingDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ending Date ";
            // 
            // dtpEndingDate
            // 
            this.dtpEndingDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndingDate.Location = new System.Drawing.Point(102, 10);
            this.dtpEndingDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndingDate.Name = "dtpEndingDate";
            this.dtpEndingDate.Size = new System.Drawing.Size(148, 23);
            this.dtpEndingDate.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(9, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 616);
            this.panel1.TabIndex = 26;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(256, 10);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 23;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // frmConsolidatedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 562);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndingDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRetrieve);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmConsolidatedReceipts";
            this.ShowInTaskbar = false;
            this.Text = "Reports > Consolidated Report of Accountability for Accountable Forms";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.DateTimePicker dtpEndingDate;
    }
}