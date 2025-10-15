namespace LFS.Views.Dashboard.Accounting
{
    partial class ucAccounting
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
            panel1 = new System.Windows.Forms.Panel();
            btnRecordJev = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ucJevDashboard1 = new ucJevDashboard();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRecordJev);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4, 20, 4, 4);
            panel1.Size = new System.Drawing.Size(990, 53);
            panel1.TabIndex = 17;
            // 
            // btnRecordJev
            // 
            btnRecordJev.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRecordJev.Location = new System.Drawing.Point(783, 23);
            btnRecordJev.Name = "btnRecordJev";
            btnRecordJev.Size = new System.Drawing.Size(200, 23);
            btnRecordJev.TabIndex = 1;
            btnRecordJev.Text = "Record JEV";
            btnRecordJev.UseVisualStyleBackColor = true;
            btnRecordJev.Click += btnRecordJev_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point(7, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(181, 17);
            label1.TabIndex = 0;
            label1.Text = "Journal Entry Voucher (JEV)";
            // 
            // ucJevDashboard1
            // 
            ucJevDashboard1.Dock = System.Windows.Forms.DockStyle.Top;
            ucJevDashboard1.Location = new System.Drawing.Point(0, 53);
            ucJevDashboard1.Margin = new System.Windows.Forms.Padding(0);
            ucJevDashboard1.Name = "ucJevDashboard1";
            ucJevDashboard1.Padding = new System.Windows.Forms.Padding(4);
            ucJevDashboard1.Size = new System.Drawing.Size(990, 133);
            ucJevDashboard1.TabIndex = 18;
            // 
            // ucAccounting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(ucJevDashboard1);
            Controls.Add(panel1);
            Name = "ucAccounting";
            Size = new System.Drawing.Size(990, 525);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRecordJev;
        private System.Windows.Forms.Label label1;
        private ucJevDashboard ucJevDashboard1;
    }
}
