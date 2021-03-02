
namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    partial class frmFunctionalClassificationAdd
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunctionalClassificationAdd));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.ucFunctionalClassification1 = new AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification.ucFunctionalClassification();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Controls.Add(this.btnSave);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 59);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.flowLayoutPanel1.Size = new System.Drawing.Size(410, 27);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(325, 2);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnCancel.Size = new System.Drawing.Size(82, 22);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(237, 2);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btnSave.Size = new System.Drawing.Size(82, 22);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// ucFunctionalClassification1
			// 
			this.ucFunctionalClassification1.Location = new System.Drawing.Point(2, -1);
			this.ucFunctionalClassification1.Name = "ucFunctionalClassification1";
			this.ucFunctionalClassification1.Size = new System.Drawing.Size(408, 63);
			this.ucFunctionalClassification1.TabIndex = 5;
			// 
			// frmFunctionalClassificationAdd
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(410, 86);
			this.Controls.Add(this.ucFunctionalClassification1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximumSize = new System.Drawing.Size(426, 125);
			this.MinimumSize = new System.Drawing.Size(426, 125);
			this.Name = "frmFunctionalClassificationAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Functional Classification";
			this.Load += new System.EventHandler(this.frmFunctionalClassificationAdd_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private ucFunctionalClassification ucFunctionalClassification1;
    }
}