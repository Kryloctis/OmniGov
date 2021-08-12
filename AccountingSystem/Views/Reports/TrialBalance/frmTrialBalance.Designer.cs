
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
            this.tabTrialBalance = new System.Windows.Forms.TabControl();
            this.tabPagePreTrial = new System.Windows.Forms.TabPage();
            this.ucPreClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPreClosingTrialBalance();
            this.tabPagePostTrial = new System.Windows.Forms.TabPage();
            this.ucPostClosingTrialBalance1 = new AccountingSystem.Views.Reports.TrialBalance.ucPostClosingTrialBalance();
            this.panel2.SuspendLayout();
            this.tabTrialBalance.SuspendLayout();
            this.tabPagePreTrial.SuspendLayout();
            this.tabPagePostTrial.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(1120, 32);
            this.panel2.TabIndex = 3;
            // 
            // radioPostTB
            // 
            this.radioPostTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPostTB.Location = new System.Drawing.Point(131, 4);
            this.radioPostTB.Name = "radioPostTB";
            this.radioPostTB.Size = new System.Drawing.Size(124, 25);
            this.radioPostTB.TabIndex = 5;
            this.radioPostTB.Text = "Post Trial Balance";
            this.radioPostTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPostTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPostTB.UseVisualStyleBackColor = true;
            this.radioPostTB.CheckedChanged += new System.EventHandler(this.radioPostTB_CheckedChanged);
            // 
            // radioPreTB
            // 
            this.radioPreTB.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioPreTB.Checked = true;
            this.radioPreTB.Location = new System.Drawing.Point(4, 4);
            this.radioPreTB.Name = "radioPreTB";
            this.radioPreTB.Size = new System.Drawing.Size(124, 25);
            this.radioPreTB.TabIndex = 4;
            this.radioPreTB.TabStop = true;
            this.radioPreTB.Text = "Pre Trial Balance";
            this.radioPreTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioPreTB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioPreTB.UseVisualStyleBackColor = true;
            this.radioPreTB.CheckedChanged += new System.EventHandler(this.radioPreTB_CheckedChanged);
            // 
            // tabTrialBalance
            // 
            this.tabTrialBalance.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabTrialBalance.Controls.Add(this.tabPagePreTrial);
            this.tabTrialBalance.Controls.Add(this.tabPagePostTrial);
            this.tabTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTrialBalance.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabTrialBalance.ItemSize = new System.Drawing.Size(0, 1);
            this.tabTrialBalance.Location = new System.Drawing.Point(0, 32);
            this.tabTrialBalance.Name = "tabTrialBalance";
            this.tabTrialBalance.SelectedIndex = 0;
            this.tabTrialBalance.Size = new System.Drawing.Size(1120, 653);
            this.tabTrialBalance.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabTrialBalance.TabIndex = 4;
            // 
            // tabPagePreTrial
            // 
            this.tabPagePreTrial.Controls.Add(this.ucPreClosingTrialBalance1);
            this.tabPagePreTrial.Location = new System.Drawing.Point(4, 5);
            this.tabPagePreTrial.Name = "tabPagePreTrial";
            this.tabPagePreTrial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreTrial.Size = new System.Drawing.Size(1112, 644);
            this.tabPagePreTrial.TabIndex = 0;
            this.tabPagePreTrial.Text = "tabPage1";
            this.tabPagePreTrial.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            this.ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPreClosingTrialBalance1.Location = new System.Drawing.Point(3, 3);
            this.ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            this.ucPreClosingTrialBalance1.Size = new System.Drawing.Size(1106, 638);
            this.ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePostTrial
            // 
            this.tabPagePostTrial.Controls.Add(this.ucPostClosingTrialBalance1);
            this.tabPagePostTrial.Location = new System.Drawing.Point(4, 24);
            this.tabPagePostTrial.Name = "tabPagePostTrial";
            this.tabPagePostTrial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePostTrial.Size = new System.Drawing.Size(1112, 625);
            this.tabPagePostTrial.TabIndex = 1;
            this.tabPagePostTrial.Text = "tabPage2";
            this.tabPagePostTrial.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            this.ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPostClosingTrialBalance1.Location = new System.Drawing.Point(3, 3);
            this.ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            this.ucPostClosingTrialBalance1.Size = new System.Drawing.Size(1106, 619);
            this.ucPostClosingTrialBalance1.TabIndex = 0;
            // 
            // frmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 685);
            this.Controls.Add(this.tabTrialBalance);
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
            this.tabTrialBalance.ResumeLayout(false);
            this.tabPagePreTrial.ResumeLayout(false);
            this.tabPagePostTrial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioPreTB;
        private System.Windows.Forms.RadioButton radioPostTB;
        private System.Windows.Forms.TabControl tabTrialBalance;
        private System.Windows.Forms.TabPage tabPagePreTrial;
        private System.Windows.Forms.TabPage tabPagePostTrial;
        private ucPreClosingTrialBalance ucPreClosingTrialBalance1;
        private ucPostClosingTrialBalance ucPostClosingTrialBalance1;
    }
}