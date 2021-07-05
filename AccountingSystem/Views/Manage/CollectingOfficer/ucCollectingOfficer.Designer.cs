
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
            this.linkuser = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.epFname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobtitle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(115, 15);
            this.txtFname.MaxLength = 45;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(370, 27);
            this.txtFname.TabIndex = 6;
            this.txtFname.Validating += new System.ComponentModel.CancelEventHandler(this.txtFname_Validating);
            this.txtFname.Validated += new System.EventHandler(this.txtFname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Middle Initial";
            // 
            // txtMI
            // 
            this.txtMI.Location = new System.Drawing.Point(115, 49);
            this.txtMI.MaxLength = 3;
            this.txtMI.Name = "txtMI";
            this.txtMI.Size = new System.Drawing.Size(370, 27);
            this.txtMI.TabIndex = 8;
            this.txtMI.Validating += new System.ComponentModel.CancelEventHandler(this.txtMI_Validating);
            this.txtMI.Validated += new System.EventHandler(this.txtMI_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(115, 84);
            this.txtLname.MaxLength = 45;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(370, 27);
            this.txtLname.TabIndex = 10;
            this.txtLname.Validating += new System.ComponentModel.CancelEventHandler(this.txtLname_Validating);
            this.txtLname.Validated += new System.EventHandler(this.txtLname_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Job Title";
            // 
            // txtJobtitle
            // 
            this.txtJobtitle.Location = new System.Drawing.Point(115, 119);
            this.txtJobtitle.MaxLength = 99;
            this.txtJobtitle.Name = "txtJobtitle";
            this.txtJobtitle.Size = new System.Drawing.Size(370, 27);
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
            // linkuser
            // 
            this.linkuser.AutoSize = true;
            this.linkuser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkuser.Location = new System.Drawing.Point(14, 165);
            this.linkuser.Name = "linkuser";
            this.linkuser.Size = new System.Drawing.Size(82, 20);
            this.linkuser.TabIndex = 14;
            this.linkuser.TabStop = true;
            this.linkuser.Text = "+ Link User";
            this.linkuser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkuser_LinkClicked);
            // 
            // ucCollectingOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobtitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFname);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucCollectingOfficer";
            this.Size = new System.Drawing.Size(513, 196);
            this.Load += new System.EventHandler(this.ucCollectingOfficer_Load);
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
        internal System.Windows.Forms.LinkLabel linkuser;
    }
}
