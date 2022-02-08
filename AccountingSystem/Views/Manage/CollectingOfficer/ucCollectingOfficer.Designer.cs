
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMiddleInitial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobtitle = new System.Windows.Forms.TextBox();
            this.epFirstName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epMiddleInitial = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLastName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epJobtitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkuser = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMiddleInitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobtitle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(99, 32);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.MaxLength = 45;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(324, 23);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFname_Validating);
            this.txtFirstName.Validated += new System.EventHandler(this.txtFname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Middle Initial";
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.Location = new System.Drawing.Point(99, 66);
            this.txtMiddleInitial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiddleInitial.MaxLength = 3;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(324, 23);
            this.txtMiddleInitial.TabIndex = 8;
            this.txtMiddleInitial.Validating += new System.ComponentModel.CancelEventHandler(this.txtMI_Validating);
            this.txtMiddleInitial.Validated += new System.EventHandler(this.txtMI_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(99, 100);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.MaxLength = 45;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(324, 23);
            this.txtLastName.TabIndex = 10;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLname_Validating);
            this.txtLastName.Validated += new System.EventHandler(this.txtLname_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Job Title";
            // 
            // txtJobtitle
            // 
            this.txtJobtitle.Location = new System.Drawing.Point(99, 134);
            this.txtJobtitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobtitle.MaxLength = 99;
            this.txtJobtitle.Name = "txtJobtitle";
            this.txtJobtitle.Size = new System.Drawing.Size(324, 23);
            this.txtJobtitle.TabIndex = 12;
            this.txtJobtitle.Text = "Collecting Officer";
            // 
            // epFirstName
            // 
            this.epFirstName.ContainerControl = this;
            // 
            // epMiddleInitial
            // 
            this.epMiddleInitial.ContainerControl = this;
            // 
            // epLastName
            // 
            this.epLastName.ContainerControl = this;
            // 
            // epJobtitle
            // 
            this.epJobtitle.ContainerControl = this;
            // 
            // linkuser
            // 
            this.linkuser.AutoSize = true;
            this.linkuser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkuser.Location = new System.Drawing.Point(12, 9);
            this.linkuser.Name = "linkuser";
            this.linkuser.Size = new System.Drawing.Size(66, 15);
            this.linkuser.TabIndex = 14;
            this.linkuser.TabStop = true;
            this.linkuser.Text = "+ Link User";
            this.linkuser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkuser_LinkClicked);
            // 
            // ucCollectingOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobtitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMiddleInitial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Name = "ucCollectingOfficer";
            this.Size = new System.Drawing.Size(449, 176);
            this.Load += new System.EventHandler(this.ucCollectingOfficer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMiddleInitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobtitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtJobtitle;
        private System.Windows.Forms.ErrorProvider epFirstName;
        private System.Windows.Forms.ErrorProvider epMiddleInitial;
        private System.Windows.Forms.ErrorProvider epLastName;
        private System.Windows.Forms.ErrorProvider epJobtitle;
        internal System.Windows.Forms.LinkLabel linkuser;
    }
}
