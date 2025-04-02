
namespace LFS.Views.Manage.DisbursingOfficer
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
            components = new System.ComponentModel.Container();
            txtFirstName = new System.Windows.Forms.TextBox();
            lblFirstName = new System.Windows.Forms.Label();
            lblMidInitial = new System.Windows.Forms.Label();
            txtMidInitial = new System.Windows.Forms.TextBox();
            lblLastName = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            lblJobTitle = new System.Windows.Forms.Label();
            txtJobTitle = new System.Windows.Forms.TextBox();
            txtPrefix = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtSuffix = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            chckLinkAcc = new System.Windows.Forms.CheckBox();
            cmbxLinkedAcc = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtFirstName.Location = new System.Drawing.Point(94, 70);
            txtFirstName.MaxLength = 45;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(277, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.Validating += txtFirstName_Validating;
            txtFirstName.Validated += txtFirstName_Validated;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new System.Drawing.Point(13, 73);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(64, 15);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name";
            // 
            // lblMidInitial
            // 
            lblMidInitial.AutoSize = true;
            lblMidInitial.Location = new System.Drawing.Point(13, 102);
            lblMidInitial.Name = "lblMidInitial";
            lblMidInitial.Size = new System.Drawing.Size(76, 15);
            lblMidInitial.TabIndex = 3;
            lblMidInitial.Text = "Middle Initial";
            // 
            // txtMidInitial
            // 
            txtMidInitial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMidInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtMidInitial.Location = new System.Drawing.Point(94, 99);
            txtMidInitial.MaxLength = 1;
            txtMidInitial.Name = "txtMidInitial";
            txtMidInitial.Size = new System.Drawing.Size(277, 23);
            txtMidInitial.TabIndex = 2;
            txtMidInitial.Validating += txtMidInitial_Validating;
            txtMidInitial.Validated += txtMidInitial_Validated;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new System.Drawing.Point(13, 131);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(63, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtLastName.Location = new System.Drawing.Point(94, 128);
            txtLastName.MaxLength = 45;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(277, 23);
            txtLastName.TabIndex = 3;
            txtLastName.Validating += txtLastName_Validating;
            txtLastName.Validated += txtLastName_Validated;
            // 
            // lblJobTitle
            // 
            lblJobTitle.AutoSize = true;
            lblJobTitle.Location = new System.Drawing.Point(13, 185);
            lblJobTitle.Name = "lblJobTitle";
            lblJobTitle.Size = new System.Drawing.Size(50, 15);
            lblJobTitle.TabIndex = 7;
            lblJobTitle.Text = "Job Title";
            // 
            // txtJobTitle
            // 
            txtJobTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtJobTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtJobTitle.Location = new System.Drawing.Point(94, 185);
            txtJobTitle.MaxLength = 99;
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new System.Drawing.Size(277, 23);
            txtJobTitle.TabIndex = 5;
            txtJobTitle.Text = "DISBURSING OFFICER";
            txtJobTitle.Validating += txtJobTitle_Validating;
            txtJobTitle.Validated += txtJobTitle_Validated;
            // 
            // txtPrefix
            // 
            txtPrefix.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPrefix.Location = new System.Drawing.Point(94, 42);
            txtPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtPrefix.MaxLength = 45;
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new System.Drawing.Size(277, 23);
            txtPrefix.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(13, 45);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 18;
            label5.Text = "Prefix";
            // 
            // txtSuffix
            // 
            txtSuffix.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtSuffix.Location = new System.Drawing.Point(94, 157);
            txtSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtSuffix.MaxLength = 45;
            txtSuffix.Name = "txtSuffix";
            txtSuffix.Size = new System.Drawing.Size(277, 23);
            txtSuffix.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(13, 157);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 15);
            label8.TabIndex = 20;
            label8.Text = "Suffix";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // chckLinkAcc
            // 
            chckLinkAcc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chckLinkAcc.Appearance = System.Windows.Forms.Appearance.Button;
            chckLinkAcc.Image = Properties.Resources.link_14px;
            chckLinkAcc.Location = new System.Drawing.Point(348, 11);
            chckLinkAcc.Name = "chckLinkAcc";
            chckLinkAcc.Size = new System.Drawing.Size(24, 24);
            chckLinkAcc.TabIndex = 23;
            chckLinkAcc.UseVisualStyleBackColor = true;
            chckLinkAcc.CheckedChanged += chckLinkAcc_CheckedChanged;
            // 
            // cmbxLinkedAcc
            // 
            cmbxLinkedAcc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxLinkedAcc.Enabled = false;
            cmbxLinkedAcc.FormattingEnabled = true;
            cmbxLinkedAcc.Location = new System.Drawing.Point(92, 12);
            cmbxLinkedAcc.Name = "cmbxLinkedAcc";
            cmbxLinkedAcc.Size = new System.Drawing.Size(250, 23);
            cmbxLinkedAcc.TabIndex = 22;
            cmbxLinkedAcc.SelectionChangeCommitted += cmbxLinkedAcc_SelectionChangeCommitted;
            cmbxLinkedAcc.KeyDown += cmbxLinkedAcc_KeyDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(13, 15);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 15);
            label6.TabIndex = 21;
            label6.Text = "Linked Acc.";
            // 
            // ucDisbursingOfficer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chckLinkAcc);
            Controls.Add(cmbxLinkedAcc);
            Controls.Add(label6);
            Controls.Add(txtSuffix);
            Controls.Add(label8);
            Controls.Add(txtPrefix);
            Controls.Add(label5);
            Controls.Add(lblJobTitle);
            Controls.Add(txtJobTitle);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblMidInitial);
            Controls.Add(txtMidInitial);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Name = "ucDisbursingOfficer";
            Size = new System.Drawing.Size(380, 219);
            Load += ucDisbursingOfficer_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        internal System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckBox chckLinkAcc;
        internal System.Windows.Forms.ComboBox cmbxLinkedAcc;
        private System.Windows.Forms.Label label6;
    }
}
