
namespace AccountingSystem.Views.Reports.Cashbook
{
    partial class frmCashbook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbbank = new System.Windows.Forms.ComboBox();
            this.btnretrieve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(11, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 765);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank :";
            // 
            // cmbbank
            // 
            this.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbank.FormattingEnabled = true;
            this.cmbbank.Location = new System.Drawing.Point(66, 12);
            this.cmbbank.Name = "cmbbank";
            this.cmbbank.Size = new System.Drawing.Size(457, 28);
            this.cmbbank.TabIndex = 4;
            // 
            // btnretrieve
            // 
            this.btnretrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnretrieve.Location = new System.Drawing.Point(528, 12);
            this.btnretrieve.Name = "btnretrieve";
            this.btnretrieve.Size = new System.Drawing.Size(94, 29);
            this.btnretrieve.TabIndex = 7;
            this.btnretrieve.Text = "Retrieve";
            this.btnretrieve.UseVisualStyleBackColor = true;
            this.btnretrieve.Click += new System.EventHandler(this.btnretrieve_Click);
            // 
            // frmCashbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 749);
            this.Controls.Add(this.btnretrieve);
            this.Controls.Add(this.cmbbank);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmCashbook";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports > Check Cashbook";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCashbook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbbank;
        private System.Windows.Forms.Button btnretrieve;
    }
}