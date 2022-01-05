
namespace AccountingSystem.Views.Reports.DailyCashReport
{
    partial class frmDailyCash
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
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnretrieve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(7, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 464);
            this.panel1.TabIndex = 1;
            // 
            // dtdate
            // 
            this.dtdate.Location = new System.Drawing.Point(58, 9);
            this.dtdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(305, 23);
            this.dtdate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date :";
            // 
            // btnretrieve
            // 
            this.btnretrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnretrieve.Location = new System.Drawing.Point(368, 8);
            this.btnretrieve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnretrieve.Name = "btnretrieve";
            this.btnretrieve.Size = new System.Drawing.Size(82, 22);
            this.btnretrieve.TabIndex = 8;
            this.btnretrieve.Text = "Retrieve";
            this.btnretrieve.UseVisualStyleBackColor = true;
            this.btnretrieve.Click += new System.EventHandler(this.btnretrieve_Click);
            // 
            // frmDailyCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 507);
            this.Controls.Add(this.btnretrieve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDailyCash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Cash Position";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnretrieve;
    }
}