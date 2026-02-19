using OmniGov.App.Views.Manage.RealProperties;
namespace OmniGov.App.Views.Manage.RealProperties
{
    partial class frmEditRealProperties
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
            ucRealProperties1 = new ucRealProperties();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ucRealProperties1
            // 
            ucRealProperties1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucRealProperties1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRealProperties1.Location = new System.Drawing.Point(0, 0);
            ucRealProperties1.Margin = new System.Windows.Forms.Padding(0);
            ucRealProperties1.Name = "ucRealProperties1";
            ucRealProperties1.Size = new System.Drawing.Size(385, 531);
            ucRealProperties1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Controls.Add(btnUpdate);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 531);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(385, 29);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(249, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(133, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnUpdate.Location = new System.Drawing.Point(110, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(133, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update (Ctrl + S)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frmEditRealProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(385, 560);
            Controls.Add(ucRealProperties1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEditRealProperties";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Real Property";
            Load += frmEditRealProperties_Load;
            KeyDown += frmEditRealProperties_KeyDown;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ucRealProperties ucRealProperties1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}
