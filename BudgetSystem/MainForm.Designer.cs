
namespace BudgetSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBudgetAppropriations = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemManage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItemManage
            // 
            this.toolStripMenuItemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemBudgetAppropriations});
            this.toolStripMenuItemManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemManage.Name = "toolStripMenuItemManage";
            this.toolStripMenuItemManage.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItemManage.Text = "Manage";
            // 
            // MenuItemBudgetAppropriations
            // 
            this.MenuItemBudgetAppropriations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuItemBudgetAppropriations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuItemBudgetAppropriations.Name = "MenuItemBudgetAppropriations";
            this.MenuItemBudgetAppropriations.Size = new System.Drawing.Size(203, 22);
            this.MenuItemBudgetAppropriations.Text = "Budget Appropriations...";
            this.MenuItemBudgetAppropriations.Click += new System.EventHandler(this.MenuItemBudgetAppropriations_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "BUDGET SYSTEM DASHBOARD";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 538);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        internal System.Windows.Forms.ToolStripMenuItem toolStripMenuItemManage;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStripMenuItem MenuItemBudgetAppropriations;
    }
}

