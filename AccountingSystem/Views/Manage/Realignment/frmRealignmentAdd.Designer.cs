
namespace AccountingSystem.Views.Manage.Realignment
{
    partial class frmRealignmentAdd
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
            ucRealignment1 = new ucRealignment();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            btnSave = new System.Windows.Forms.ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ucRealignment1
            // 
            ucRealignment1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ucRealignment1.Location = new System.Drawing.Point(0, 54);
            ucRealignment1.Name = "ucRealignment1";
            ucRealignment1.Size = new System.Drawing.Size(550, 589);
            ucRealignment1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnSave });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(543, 50);
            toolStrip1.TabIndex = 47;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save28px;
            btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnSave.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(35, 47);
            btnSave.Text = "&Save";
            btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmRealignmentAdd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(543, 318);
            Controls.Add(toolStrip1);
            Controls.Add(ucRealignment1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRealignmentAdd";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add Realignment";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ucRealignment ucRealignment1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
    }
}