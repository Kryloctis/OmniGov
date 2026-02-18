using OmniGov.App.Views.Manage.CashTicketIssuance;
namespace OmniGov.App.Views.Manage.CashTicketIssuance
{
    partial class frmCashTicketEditIssuance
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
            btnUpdate = new System.Windows.Forms.Button();
            ucCashTicketIssuance1 = new ucCashTicketIssuance();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnUpdate);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 254);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            flowLayoutPanel1.Size = new System.Drawing.Size(360, 27);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(257, 2);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnCancel.Size = new System.Drawing.Size(100, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(151, 2);
            btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnUpdate.Size = new System.Drawing.Size(100, 22);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ucCashTicketIssuance1
            // 
            ucCashTicketIssuance1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCashTicketIssuance1.Location = new System.Drawing.Point(4, 4);
            ucCashTicketIssuance1.Name = "ucCashTicketIssuance1";
            ucCashTicketIssuance1.Padding = new System.Windows.Forms.Padding(20);
            ucCashTicketIssuance1.Size = new System.Drawing.Size(352, 246);
            ucCashTicketIssuance1.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucCashTicketIssuance1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(360, 254);
            panel1.TabIndex = 9;
            // 
            // frmCashTicketEditIssuance
            // 
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(360, 281);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCashTicketEditIssuance";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Issued Cash Ticket";
            Load += frmCashTicketEditIssuance_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private ucCashTicketIssuance ucCashTicketIssuance1;
        private System.Windows.Forms.Panel panel1;
    }
}
