
namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    partial class ucDisbursingOfficer
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblMidInitial = new System.Windows.Forms.Label();
            this.txtMidInitial = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.epFirstName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epMidInitial = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLastName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epJobTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkuser = new System.Windows.Forms.LinkLabel();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMidInitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(99, 66);
            this.txtFirstName.MaxLength = 45;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(353, 23);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFirstName_Validating);
            this.txtFirstName.Validated += new System.EventHandler(this.txtFirstName_Validated);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 69);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(64, 15);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblMidInitial
            // 
            this.lblMidInitial.AutoSize = true;
            this.lblMidInitial.Location = new System.Drawing.Point(15, 98);
            this.lblMidInitial.Name = "lblMidInitial";
            this.lblMidInitial.Size = new System.Drawing.Size(76, 15);
            this.lblMidInitial.TabIndex = 3;
            this.lblMidInitial.Text = "Middle Initial";
            // 
            // txtMidInitial
            // 
            this.txtMidInitial.Location = new System.Drawing.Point(99, 95);
            this.txtMidInitial.MaxLength = 3;
            this.txtMidInitial.Name = "txtMidInitial";
            this.txtMidInitial.Size = new System.Drawing.Size(353, 23);
            this.txtMidInitial.TabIndex = 2;
            this.txtMidInitial.Validating += new System.ComponentModel.CancelEventHandler(this.txtMidInitial_Validating);
            this.txtMidInitial.Validated += new System.EventHandler(this.txtMidInitial_Validated);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(15, 127);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 15);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(99, 124);
            this.txtLastName.MaxLength = 45;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(353, 23);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastName_Validating);
            this.txtLastName.Validated += new System.EventHandler(this.txtLastName_Validated);
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Location = new System.Drawing.Point(15, 181);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(50, 15);
            this.lblJobTitle.TabIndex = 7;
            this.lblJobTitle.Text = "Job Title";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(99, 181);
            this.txtJobTitle.MaxLength = 99;
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(353, 23);
            this.txtJobTitle.TabIndex = 5;
            this.txtJobTitle.Text = "Disbursing Officer";
            this.txtJobTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtJobTitle_Validating);
            this.txtJobTitle.Validated += new System.EventHandler(this.txtJobTitle_Validated);
            // 
            // epFirstName
            // 
            this.epFirstName.ContainerControl = this;
            // 
            // epMidInitial
            // 
            this.epMidInitial.ContainerControl = this;
            // 
            // epLastName
            // 
            this.epLastName.ContainerControl = this;
            // 
            // epJobTitle
            // 
            this.epJobTitle.ContainerControl = this;
            // 
            // linkuser
            // 
            this.linkuser.AutoSize = true;
            this.linkuser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkuser.Location = new System.Drawing.Point(15, 16);
            this.linkuser.Name = "linkuser";
            this.linkuser.Size = new System.Drawing.Size(55, 15);
            this.linkuser.TabIndex = 15;
            this.linkuser.TabStop = true;
            this.linkuser.Text = "Link User";
            this.linkuser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkuser_LinkClicked);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(99, 38);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrefix.MaxLength = 45;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(353, 23);
            this.txtPrefix.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Prefix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(99, 153);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSuffix.MaxLength = 45;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(353, 23);
            this.txtSuffix.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Suffix";
            // 
            // ucDisbursingOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkuser);
            this.Controls.Add(this.lblJobTitle);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblMidInitial);
            this.Controls.Add(this.txtMidInitial);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "ucDisbursingOfficer";
            this.Size = new System.Drawing.Size(479, 212);
            ((System.ComponentModel.ISupportInitialize)(this.epFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMidInitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epJobTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMidInitial;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblJobTitle;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.TextBox txtMidInitial;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.ErrorProvider epFirstName;
        private System.Windows.Forms.ErrorProvider epMidInitial;
        private System.Windows.Forms.ErrorProvider epLastName;
        private System.Windows.Forms.ErrorProvider epJobTitle;
        internal System.Windows.Forms.LinkLabel linkuser;
        internal System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label8;
    }
}
