namespace LFS.Views.Reports.TrialBalance
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            tabControlTrialBalance = new System.Windows.Forms.TabControl();
            tabPagePreTb = new System.Windows.Forms.TabPage();
            ucPreClosingTrialBalance1 = new ucPreClosingTrialBalance();
            tabPagePosTb = new System.Windows.Forms.TabPage();
            ucPostClosingTrialBalance1 = new ucPostClosingTrialBalance();
            tabControlTrialBalance.SuspendLayout();
            tabPagePreTb.SuspendLayout();
            tabPagePosTb.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(886, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControlTrialBalance
            // 
            tabControlTrialBalance.Controls.Add(tabPagePreTb);
            tabControlTrialBalance.Controls.Add(tabPagePosTb);
            tabControlTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlTrialBalance.Location = new System.Drawing.Point(0, 0);
            tabControlTrialBalance.Name = "tabControlTrialBalance";
            tabControlTrialBalance.SelectedIndex = 0;
            tabControlTrialBalance.Size = new System.Drawing.Size(886, 454);
            tabControlTrialBalance.TabIndex = 1;
            tabControlTrialBalance.SelectedIndexChanged += tabControlTrialBalance_SelectedIndexChanged;
            // 
            // tabPagePreTb
            // 
            tabPagePreTb.Controls.Add(ucPreClosingTrialBalance1);
            tabPagePreTb.Location = new System.Drawing.Point(4, 24);
            tabPagePreTb.Name = "tabPagePreTb";
            tabPagePreTb.Size = new System.Drawing.Size(878, 426);
            tabPagePreTb.TabIndex = 1;
            tabPagePreTb.Text = "Pre-Closing Trial Balance";
            tabPagePreTb.UseVisualStyleBackColor = true;
            // 
            // ucPreClosingTrialBalance1
            // 
            ucPreClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPreClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            ucPreClosingTrialBalance1.Name = "ucPreClosingTrialBalance1";
            ucPreClosingTrialBalance1.Size = new System.Drawing.Size(878, 426);
            ucPreClosingTrialBalance1.TabIndex = 0;
            // 
            // tabPagePosTb
            // 
            tabPagePosTb.Controls.Add(ucPostClosingTrialBalance1);
            tabPagePosTb.Location = new System.Drawing.Point(4, 24);
            tabPagePosTb.Name = "tabPagePosTb";
            tabPagePosTb.Size = new System.Drawing.Size(878, 426);
            tabPagePosTb.TabIndex = 0;
            tabPagePosTb.Text = "Post-Closing Trial Balance";
            tabPagePosTb.UseVisualStyleBackColor = true;
            // 
            // ucPostClosingTrialBalance1
            // 
            ucPostClosingTrialBalance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPostClosingTrialBalance1.Location = new System.Drawing.Point(0, 0);
            ucPostClosingTrialBalance1.Name = "ucPostClosingTrialBalance1";
            ucPostClosingTrialBalance1.Size = new System.Drawing.Size(878, 426);
            ucPostClosingTrialBalance1.TabIndex = 0;
            // 
            // frmTrialBalance
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(886, 476);
            Controls.Add(tabControlTrialBalance);
            Controls.Add(statusStrip1);
            MinimizeBox = false;
            Name = "frmTrialBalance";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Reports > TrialBalance";
            Load += frmTrialBalance_Load;
            tabControlTrialBalance.ResumeLayout(false);
            tabPagePreTb.ResumeLayout(false);
            tabPagePosTb.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlTrialBalance;
        private System.Windows.Forms.TabPage tabPagePreTb;
        private System.Windows.Forms.TabPage tabPagePosTb;
        private ucPreClosingTrialBalance ucPreClosingTrialBalance1;
        private ucPostClosingTrialBalance ucPostClosingTrialBalance1;
    }
}