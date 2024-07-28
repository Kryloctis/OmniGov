
namespace AccountingSystem.Views.Manage.Journals
{
    partial class frmJournalsAdd
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
            btnSave = new System.Windows.Forms.Button();
            ucJournals1 = new ucJournals();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 89);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            flowLayoutPanel1.Size = new System.Drawing.Size(315, 27);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(162, 2);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnCancel.Size = new System.Drawing.Size(150, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSave.Location = new System.Drawing.Point(6, 2);
            btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            btnSave.Size = new System.Drawing.Size(150, 22);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save (Ctrl +S)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ucJournals1
            // 
            ucJournals1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucJournals1.Location = new System.Drawing.Point(3, 3);
            ucJournals1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ucJournals1.Name = "ucJournals1";
            ucJournals1.Size = new System.Drawing.Size(315, 86);
            ucJournals1.TabIndex = 2;
            ucJournals1.Load += ucJournals1_Load;
            // 
            // frmJournalsAdd
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(321, 119);
            Controls.Add(ucJournals1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "frmJournalsAdd";
            Padding = new System.Windows.Forms.Padding(3);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Journal";
            Load += frmJournalsAdd_Load;
            KeyDown += frmJournalsAdd_KeyDown;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ucJournals ucJournals1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}