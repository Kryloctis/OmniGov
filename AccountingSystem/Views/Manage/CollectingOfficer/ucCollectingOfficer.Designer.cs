
namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    partial class ucCollectingOfficer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobtitle = new System.Windows.Forms.TextBox();
            this.epFname = new System.Windows.Forms.ErrorProvider(this.components);
            this.epMI = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLname = new System.Windows.Forms.ErrorProvider(this.components);
            this.epJobtitle = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epFname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobtitle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(90, 11);
            this.txtFname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFname.MaxLength = 45;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(324, 23);
            this.txtFname.TabIndex = 6;
            this.txtFname.Validating += new System.ComponentModel.CancelEventHandler(this.txtFname_Validating);
            this.txtFname.Validated += new System.EventHandler(this.txtFname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Middle Initial";
            // 
            // txtMI
            // 
            this.txtMI.Location = new System.Drawing.Point(90, 37);
            this.txtMI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMI.MaxLength = 3;
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(324, 23);
            this.txtMI.TabIndex = 8;
            this.txtMI.Validating += new System.ComponentModel.CancelEventHandler(this.txtMI_Validating);
            this.txtMI.Validated += new System.EventHandler(this.txtMI_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(90, 63);
            this.txtLname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLname.MaxLength = 45;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(324, 23);
            this.txtLname.TabIndex = 10;
            this.txtLname.Validating += new System.ComponentModel.CancelEventHandler(this.txtLname_Validating);
            this.txtLname.Validated += new System.EventHandler(this.txtLname_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Job Title";
            // 
            // txtJobtitle
            // 
            this.txtJobtitle.Location = new System.Drawing.Point(90, 89);
            this.txtJobtitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobtitle.MaxLength = 99;
            this.txtJobtitle.Name = "txtJobtitle";
            this.txtJobtitle.Size = new System.Drawing.Size(324, 23);
            this.txtJobtitle.TabIndex = 12;
            // 
            // epFname
            // 
            this.epFname.ContainerControl = this;
            // 
            // epMI
            // 
            this.epMI.ContainerControl = this;
            // 
            // epLname
            // 
            this.epLname.ContainerControl = this;
            // 
            // epJobtitle
            // 
            this.epJobtitle.ContainerControl = this;
            // 
            // ucCollectingOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobtitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFname);
            this.Name = "ucCollectingOfficer";
            this.Size = new System.Drawing.Size(449, 123);
            ((System.ComponentModel.ISupportInitialize)(this.epFname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobtitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtJobtitle;
        private System.Windows.Forms.ErrorProvider epFname;
        private System.Windows.Forms.ErrorProvider epMI;
        private System.Windows.Forms.ErrorProvider epLname;
        private System.Windows.Forms.ErrorProvider epJobtitle;
    }
}
