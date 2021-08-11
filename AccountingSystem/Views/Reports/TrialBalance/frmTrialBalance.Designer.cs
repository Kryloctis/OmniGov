
namespace AccountingSystem.Views.Reports.TrialBalance
{
    partial class frmTrialBalance
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioPostTB = new System.Windows.Forms.RadioButton();
            this.radioPreTB = new System.Windows.Forms.RadioButton();
            this.panelReport = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.radioPostTB);
            this.panel2.Controls.Add(this.radioPreTB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 47);
            this.panel2.TabIndex = 3;
            // 
            // radioPostTB
            // 
            this.radioPostTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPostTB.AutoSize = true;
            this.radioPostTB.Location = new System.Drawing.Point(131, 10);
            this.radioPostTB.Name = "radioPostTB";
            this.radioPostTB.Size = new System.Drawing.Size(109, 25);
            this.radioPostTB.TabIndex = 5;
            this.radioPostTB.Text = "Post Trial Balance";
            this.radioPostTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPostTB.UseVisualStyleBackColor = true;
            this.radioPostTB.CheckedChanged += new System.EventHandler(this.radioPostTB_CheckedChanged);
            // 
            // radioPreTB
            // 
            this.radioPreTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPreTB.AutoSize = true;
            this.radioPreTB.Checked = true;
            this.radioPreTB.Location = new System.Drawing.Point(9, 10);
            this.radioPreTB.Name = "radioPreTB";
            this.radioPreTB.Size = new System.Drawing.Size(103, 25);
            this.radioPreTB.TabIndex = 4;
            this.radioPreTB.TabStop = true;
            this.radioPreTB.Text = "Pre Trial Balance";
            this.radioPreTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPreTB.UseVisualStyleBackColor = true;
            this.radioPreTB.CheckedChanged += new System.EventHandler(this.radioPreTB_CheckedChanged);
            // 
            // panelReport
            // 
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 47);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(1120, 638);
            this.panelReport.TabIndex = 4;
            // 
            // frmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 685);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmTrialBalance";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Balance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrialBalance_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioPreTB;
        private System.Windows.Forms.RadioButton radioPostTB;
        internal System.Windows.Forms.Panel panelReport;
    }
}