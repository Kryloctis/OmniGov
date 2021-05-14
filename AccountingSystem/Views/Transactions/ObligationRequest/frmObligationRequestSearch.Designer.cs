
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class frmObligationRequestSearch
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
            this.mskTxtBoxObligationRequestNo = new System.Windows.Forms.MaskedTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskTxtBoxObligationRequestNo
            // 
            this.mskTxtBoxObligationRequestNo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mskTxtBoxObligationRequestNo.Location = new System.Drawing.Point(12, 12);
            this.mskTxtBoxObligationRequestNo.Mask = "0000-00-00-000";
            this.mskTxtBoxObligationRequestNo.Name = "mskTxtBoxObligationRequestNo";
            this.mskTxtBoxObligationRequestNo.Size = new System.Drawing.Size(320, 43);
            this.mskTxtBoxObligationRequestNo.TabIndex = 0;
            this.mskTxtBoxObligationRequestNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnOk);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 63);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(346, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Image = global::AccountingSystem.Properties.Resources.ok14px;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.Location = new System.Drawing.Point(268, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmObligationRequestSearch
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(346, 92);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mskTxtBoxObligationRequestNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObligationRequestSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Obligation Request";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.MaskedTextBox mskTxtBoxObligationRequestNo;
    }
}