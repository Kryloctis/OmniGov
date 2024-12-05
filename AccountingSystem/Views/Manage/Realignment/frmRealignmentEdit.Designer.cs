
namespace AccountingSystem.Views.Manage.Realignment
{
    partial class frmRealignmentEdit
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
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnUpdate = new System.Windows.Forms.ToolStripButton();
            ucRealignment1 = new ucRealignment();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnUpdate });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(544, 50);
            toolStrip1.TabIndex = 48;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnUpdate
            // 
            btnUpdate.Image = Properties.Resources.save28px;
            btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnUpdate.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(49, 47);
            btnUpdate.Text = "&Update";
            btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ucRealignment1
            // 
            ucRealignment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucRealignment1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucRealignment1.Location = new System.Drawing.Point(0, 50);
            ucRealignment1.Name = "ucRealignment1";
            ucRealignment1.Size = new System.Drawing.Size(544, 262);
            ucRealignment1.TabIndex = 49;
            // 
            // frmRealignmentEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(544, 312);
            Controls.Add(ucRealignment1);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRealignmentEdit";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Realignment";
            Load += frmRealignmentEdit_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnUpdate;
        private ucRealignment ucRealignment1;
    }
}