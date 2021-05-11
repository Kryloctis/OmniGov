
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class frmAllotmentReleaseAdd
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.ucAllotmentRelease1 = new AccountingSystem.Views.Manage.AllotmentRelease.ucAllotmentRelease();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnAddToList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 163);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(486, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(405, 3);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 1;
            this.btnAddToList.Text = "Add to list";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.BtnAddToList_Click);
            // 
            // ucAllotmentRelease1
            // 
            this.ucAllotmentRelease1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucAllotmentRelease1.Location = new System.Drawing.Point(12, 12);
            this.ucAllotmentRelease1.Name = "ucAllotmentRelease1";
            this.ucAllotmentRelease1.Size = new System.Drawing.Size(543, 145);
            this.ucAllotmentRelease1.TabIndex = 0;
            // 
            // frmAllotmentReleaseAdd
            // 
            this.AcceptButton = this.btnAddToList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(564, 192);
            this.Controls.Add(this.ucAllotmentRelease1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllotmentReleaseAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Allotment Release";
            this.Load += new System.EventHandler(this.frmAllotmentReleaseAdd_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnAddToList;
        internal ucAllotmentRelease ucAllotmentRelease1;
    }
}