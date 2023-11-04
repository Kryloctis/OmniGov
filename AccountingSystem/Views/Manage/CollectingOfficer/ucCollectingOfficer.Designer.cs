
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
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbxLinkedAcc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chckLinkAcc = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.Location = new System.Drawing.Point(78, 58);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.MaxLength = 45;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(280, 23);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFname_Validating);
            this.txtFirstName.Validated += new System.EventHandler(this.txtFname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "M.I";
            // 
            // txtMiddleInitial
            // 
            this.txtMiddleInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMiddleInitial.Location = new System.Drawing.Point(78, 111);
            this.txtMiddleInitial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMiddleInitial.MaxLength = 1;
            this.txtMiddleInitial.Name = "txtMiddleInitial";
            this.txtMiddleInitial.Size = new System.Drawing.Size(280, 23);
            this.txtMiddleInitial.TabIndex = 2;
            this.txtMiddleInitial.Validating += new System.ComponentModel.CancelEventHandler(this.txtMI_Validating);
            this.txtMiddleInitial.Validated += new System.EventHandler(this.txtMI_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(78, 85);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.MaxLength = 45;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(280, 23);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtLname_Validating);
            this.txtLastName.Validated += new System.EventHandler(this.txtLname_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Job Title";
            // 
            // txtJobtitle
            // 
            this.txtJobtitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJobtitle.Location = new System.Drawing.Point(78, 165);
            this.txtJobtitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobtitle.MaxLength = 99;
            this.txtJobtitle.Name = "txtJobtitle";
            this.txtJobtitle.Size = new System.Drawing.Size(280, 23);
            this.txtJobtitle.TabIndex = 5;
            // 
            // txtPrefix
            // 
            this.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrefix.Location = new System.Drawing.Point(78, 31);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrefix.MaxLength = 45;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(280, 23);
            this.txtPrefix.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Prefix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSuffix.Location = new System.Drawing.Point(78, 138);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSuffix.MaxLength = 45;
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(280, 23);
            this.txtSuffix.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Suffix";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbxLinkedAcc
            // 
            this.cmbxLinkedAcc.Enabled = false;
            this.cmbxLinkedAcc.FormattingEnabled = true;
            this.cmbxLinkedAcc.Location = new System.Drawing.Point(78, 3);
            this.cmbxLinkedAcc.Name = "cmbxLinkedAcc";
            this.cmbxLinkedAcc.Size = new System.Drawing.Size(250, 23);
            this.cmbxLinkedAcc.TabIndex = 18;
            this.cmbxLinkedAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbxLinkedAcc_KeyDown);
            this.cmbxLinkedAcc.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxLinkedAcc_Validating);
            this.cmbxLinkedAcc.Validated += new System.EventHandler(this.cmbxLinkedAcc_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Linked Acc.";
            // 
            // chckLinkAcc
            // 
            this.chckLinkAcc.Appearance = System.Windows.Forms.Appearance.Button;
            this.chckLinkAcc.Image = global::AccountingSystem.Properties.Resources.link_14px;
            this.chckLinkAcc.Location = new System.Drawing.Point(334, 2);
            this.chckLinkAcc.Name = "chckLinkAcc";
            this.chckLinkAcc.Size = new System.Drawing.Size(24, 24);
            this.chckLinkAcc.TabIndex = 19;
            this.chckLinkAcc.UseVisualStyleBackColor = true;
            this.chckLinkAcc.CheckedChanged += new System.EventHandler(this.chckLinkAcc_CheckedChanged);
            // 
            // ucCollectingOfficer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chckLinkAcc);
            this.Controls.Add(this.cmbxLinkedAcc);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJobtitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMiddleInitial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Name = "ucCollectingOfficer";
            this.Size = new System.Drawing.Size(381, 198);
            this.Load += new System.EventHandler(this.ucCollectingOfficer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        internal System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox chckLinkAcc;
        internal System.Windows.Forms.ComboBox cmbxLinkedAcc;
    }
}
