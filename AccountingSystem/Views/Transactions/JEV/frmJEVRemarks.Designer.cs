
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class frmJEVRemarks
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDisapprove = new System.Windows.Forms.Button();
            this.btnSaveMessage = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(9, 11);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(609, 225);
            this.txtRemarks.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnAccept);
            this.flowLayoutPanel1.Controls.Add(this.btnDisapprove);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveMessage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 244);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(629, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(493, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(354, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(133, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept && Edit";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Location = new System.Drawing.Point(215, 3);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(133, 23);
            this.btnDisapprove.TabIndex = 2;
            this.btnDisapprove.Text = "Dissaprove";
            this.btnDisapprove.UseVisualStyleBackColor = true;
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // btnSaveMessage
            // 
            this.btnSaveMessage.Location = new System.Drawing.Point(76, 3);
            this.btnSaveMessage.Name = "btnSaveMessage";
            this.btnSaveMessage.Size = new System.Drawing.Size(133, 23);
            this.btnSaveMessage.TabIndex = 1;
            this.btnSaveMessage.Text = "Save Message";
            this.btnSaveMessage.UseVisualStyleBackColor = true;
            this.btnSaveMessage.Click += new System.EventHandler(this.btnSaveMessage_Click);
            // 
            // frmRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(629, 272);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtRemarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemarks";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disapproval Message";
            this.Load += new System.EventHandler(this.frmRemarks_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSaveMessage;
        internal System.Windows.Forms.Button btnDisapprove;
    }
}