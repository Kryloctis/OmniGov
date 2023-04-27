
namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    partial class frmAddAllotmentClasses
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
            ucAllotmentClasses1 = new ucAllotmentClasses();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ucAllotmentClasses1
            // 
            ucAllotmentClasses1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucAllotmentClasses1.Location = new System.Drawing.Point(4, 4);
            ucAllotmentClasses1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ucAllotmentClasses1.Name = "ucAllotmentClasses1";
            ucAllotmentClasses1.Size = new System.Drawing.Size(389, 80);
            ucAllotmentClasses1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(397, 29);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(319, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(238, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ucAllotmentClasses1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(397, 88);
            panel1.TabIndex = 4;
            // 
            // frmAllotmentClassesAdd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(397, 88);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "frmAllotmentClassesAdd";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Allotment Class";
            Load += frmAllotmentClassesAdd_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ucAllotmentClasses ucAllotmentClasses1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
    }
}