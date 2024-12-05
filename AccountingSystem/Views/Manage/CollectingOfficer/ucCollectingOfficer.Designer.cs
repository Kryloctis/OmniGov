
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
            components = new System.ComponentModel.Container();
            label2 = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtMiddleInitial = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtJobtitle = new System.Windows.Forms.TextBox();
            txtPrefix = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtSuffix = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            label6 = new System.Windows.Forms.Label();
            chckLinkAcc = new System.Windows.Forms.CheckBox();
            cmbxLinkedAcc = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(4, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 15);
            label2.TabIndex = 7;
            label2.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(78, 58);
            txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtFirstName.MaxLength = 45;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(280, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.Validating += txtFname_Validating;
            txtFirstName.Validated += txtFname_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 15);
            label1.TabIndex = 9;
            label1.Text = "M.I";
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMiddleInitial.Location = new System.Drawing.Point(78, 111);
            txtMiddleInitial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtMiddleInitial.MaxLength = 1;
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new System.Drawing.Size(280, 23);
            txtMiddleInitial.TabIndex = 2;
            txtMiddleInitial.Validating += txtMI_Validating;
            txtMiddleInitial.Validated += txtMI_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 88);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 15);
            label3.TabIndex = 11;
            label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(78, 85);
            txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtLastName.MaxLength = 45;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(280, 23);
            txtLastName.TabIndex = 3;
            txtLastName.Validating += txtLname_Validating;
            txtLastName.Validated += txtLname_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(4, 168);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(50, 15);
            label4.TabIndex = 13;
            label4.Text = "Job Title";
            // 
            // txtJobtitle
            // 
            txtJobtitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtJobtitle.Location = new System.Drawing.Point(78, 165);
            txtJobtitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtJobtitle.MaxLength = 99;
            txtJobtitle.Name = "txtJobtitle";
            txtJobtitle.Size = new System.Drawing.Size(280, 23);
            txtJobtitle.TabIndex = 5;
            // 
            // txtPrefix
            // 
            txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPrefix.Location = new System.Drawing.Point(78, 31);
            txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPrefix.MaxLength = 45;
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new System.Drawing.Size(280, 23);
            txtPrefix.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(4, 34);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 16;
            label5.Text = "Prefix";
            // 
            // txtSuffix
            // 
            txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtSuffix.Location = new System.Drawing.Point(78, 138);
            txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtSuffix.MaxLength = 45;
            txtSuffix.Name = "txtSuffix";
            txtSuffix.Size = new System.Drawing.Size(280, 23);
            txtSuffix.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(4, 141);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 15);
            label8.TabIndex = 17;
            label8.Text = "Suffix";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(4, 7);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 15);
            label6.TabIndex = 16;
            label6.Text = "Linked Acc.";
            // 
            // chckLinkAcc
            // 
            chckLinkAcc.Appearance = System.Windows.Forms.Appearance.Button;
            chckLinkAcc.Image = Properties.Resources.link_14px;
            chckLinkAcc.Location = new System.Drawing.Point(334, 2);
            chckLinkAcc.Name = "chckLinkAcc";
            chckLinkAcc.Size = new System.Drawing.Size(24, 24);
            chckLinkAcc.TabIndex = 19;
            chckLinkAcc.UseVisualStyleBackColor = true;
            chckLinkAcc.CheckedChanged += chckLinkAcc_CheckedChanged;
            // 
            // cmbxLinkedAcc
            // 
            cmbxLinkedAcc.Enabled = false;
            cmbxLinkedAcc.FormattingEnabled = true;
            cmbxLinkedAcc.Location = new System.Drawing.Point(78, 3);
            cmbxLinkedAcc.Name = "cmbxLinkedAcc";
            cmbxLinkedAcc.Size = new System.Drawing.Size(250, 23);
            cmbxLinkedAcc.TabIndex = 18;
            cmbxLinkedAcc.SelectionChangeCommitted += cmbxLinkedAcc_SelectionChangeCommitted;
            cmbxLinkedAcc.KeyDown += cmbxLinkedAcc_KeyDown;
            cmbxLinkedAcc.Validating += cmbxLinkedAcc_Validating;
            cmbxLinkedAcc.Validated += cmbxLinkedAcc_Validated;
            // 
            // ucCollectingOfficer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chckLinkAcc);
            Controls.Add(cmbxLinkedAcc);
            Controls.Add(txtSuffix);
            Controls.Add(label8);
            Controls.Add(txtPrefix);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtJobtitle);
            Controls.Add(label3);
            Controls.Add(txtLastName);
            Controls.Add(label1);
            Controls.Add(txtMiddleInitial);
            Controls.Add(label2);
            Controls.Add(txtFirstName);
            Name = "ucCollectingOfficer";
            Size = new System.Drawing.Size(381, 198);
            Load += ucCollectingOfficer_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
