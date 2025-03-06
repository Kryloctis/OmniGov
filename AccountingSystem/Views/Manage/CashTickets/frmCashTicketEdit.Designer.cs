namespace AccountingSystem.Views.Manage.CashTickets
{
    partial class frmCashTicketEdit
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
            panel1 = new System.Windows.Forms.Panel();
            ucCashTickets1 = new ucCashTickets();
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
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 150);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            flowLayoutPanel1.Size = new System.Drawing.Size(359, 27);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(274, 2);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnCancel.Size = new System.Drawing.Size(82, 22);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(186, 2);
            btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnUpdate.Size = new System.Drawing.Size(82, 22);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucCashTickets1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(359, 150);
            panel1.TabIndex = 7;
            // 
            // ucCashTickets1
            // 
            ucCashTickets1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucCashTickets1.Location = new System.Drawing.Point(4, 4);
            ucCashTickets1.Name = "ucCashTickets1";
            ucCashTickets1.Size = new System.Drawing.Size(351, 142);
            ucCashTickets1.TabIndex = 0;
            // 
            // frmCashTicketEdit
            // 
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(359, 177);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "frmCashTicketEdit";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Cash Ticket";
            Load += FrmCashTicketEdit_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private ucCashTickets ucCashTickets1;
    }
}