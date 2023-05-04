
namespace AccountingSystem.Views.Transactions.JEV
{
    partial class frmJEVDisapproval
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnAccept = new System.Windows.Forms.Button();
            btnDisapprove = new System.Windows.Forms.Button();
            btnSaveMessage = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            txtRemarks = new System.Windows.Forms.TextBox();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnAccept);
            flowLayoutPanel1.Controls.Add(btnDisapprove);
            flowLayoutPanel1.Controls.Add(btnSaveMessage);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 181);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(545, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(435, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(107, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            btnAccept.Location = new System.Drawing.Point(322, 3);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(107, 23);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept && Edit";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnDisapprove
            // 
            btnDisapprove.Location = new System.Drawing.Point(209, 3);
            btnDisapprove.Name = "btnDisapprove";
            btnDisapprove.Size = new System.Drawing.Size(107, 23);
            btnDisapprove.TabIndex = 2;
            btnDisapprove.Text = "Dissaprove";
            btnDisapprove.UseVisualStyleBackColor = true;
            btnDisapprove.Click += btnDisapprove_Click;
            // 
            // btnSaveMessage
            // 
            btnSaveMessage.Location = new System.Drawing.Point(96, 3);
            btnSaveMessage.Name = "btnSaveMessage";
            btnSaveMessage.Size = new System.Drawing.Size(107, 23);
            btnSaveMessage.TabIndex = 1;
            btnSaveMessage.Text = "Save Message";
            btnSaveMessage.UseVisualStyleBackColor = true;
            btnSaveMessage.Click += btnSaveMessage_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtRemarks);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(545, 181);
            panel1.TabIndex = 2;
            // 
            // txtRemarks
            // 
            txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            txtRemarks.Location = new System.Drawing.Point(4, 4);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new System.Drawing.Size(537, 173);
            txtRemarks.TabIndex = 1;
            // 
            // frmJEVDisapproval
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(545, 209);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmJEVDisapproval";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Disapproval Message";
            Load += frmRemarks_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSaveMessage;
        internal System.Windows.Forms.Button btnDisapprove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRemarks;
    }
}