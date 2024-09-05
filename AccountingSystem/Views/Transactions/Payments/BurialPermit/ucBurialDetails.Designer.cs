namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    partial class ucBurialDetails
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
            dtDeathDate = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtCauseOfDeath = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txtCemetery = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtDisinterment = new System.Windows.Forms.TextBox();
            radInfectiousYes = new System.Windows.Forms.RadioButton();
            radInfectiousNo = new System.Windows.Forms.RadioButton();
            label5 = new System.Windows.Forms.Label();
            panelInfectious = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            panelEmbalmed = new System.Windows.Forms.Panel();
            radEmbalmedYes = new System.Windows.Forms.RadioButton();
            radEmbalmedNo = new System.Windows.Forms.RadioButton();
            label7 = new System.Windows.Forms.Label();
            txtDisposition = new System.Windows.Forms.TextBox();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            panelInfectious.SuspendLayout();
            panelEmbalmed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtDeathDate
            // 
            dtDeathDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDeathDate.Location = new System.Drawing.Point(188, 139);
            dtDeathDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            dtDeathDate.Name = "dtDeathDate";
            dtDeathDate.Size = new System.Drawing.Size(461, 39);
            dtDeathDate.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 151);
            label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(145, 32);
            label1.TabIndex = 1;
            label1.Text = "Death Date*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 207);
            label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(188, 32);
            label2.TabIndex = 1;
            label2.Text = "Cause of Death*";
            // 
            // txtCauseOfDeath
            // 
            txtCauseOfDeath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCauseOfDeath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCauseOfDeath.Location = new System.Drawing.Point(188, 201);
            txtCauseOfDeath.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtCauseOfDeath.Multiline = true;
            txtCauseOfDeath.Name = "txtCauseOfDeath";
            txtCauseOfDeath.Size = new System.Drawing.Size(461, 217);
            txtCauseOfDeath.TabIndex = 2;
            txtCauseOfDeath.Validating += txtCauseOfDeath_Validating;
            txtCauseOfDeath.Validated += txtCauseOfDeath_Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 442);
            label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(127, 32);
            label3.TabIndex = 1;
            label3.Text = "Cemetery*";
            // 
            // txtCemetery
            // 
            txtCemetery.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtCemetery.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtCemetery.Location = new System.Drawing.Point(188, 435);
            txtCemetery.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtCemetery.Name = "txtCemetery";
            txtCemetery.Size = new System.Drawing.Size(461, 39);
            txtCemetery.TabIndex = 3;
            txtCemetery.Validating += txtCemetery_Validating;
            txtCemetery.Validated += txtCemetery_Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 503);
            label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(152, 32);
            label4.TabIndex = 1;
            label4.Text = "Disinterment";
            // 
            // txtDisinterment
            // 
            txtDisinterment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDisinterment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtDisinterment.Location = new System.Drawing.Point(188, 497);
            txtDisinterment.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtDisinterment.Name = "txtDisinterment";
            txtDisinterment.Size = new System.Drawing.Size(461, 39);
            txtDisinterment.TabIndex = 3;
            // 
            // radInfectiousYes
            // 
            radInfectiousYes.AutoSize = true;
            radInfectiousYes.Location = new System.Drawing.Point(6, 6);
            radInfectiousYes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            radInfectiousYes.Name = "radInfectiousYes";
            radInfectiousYes.Size = new System.Drawing.Size(79, 36);
            radInfectiousYes.TabIndex = 4;
            radInfectiousYes.Text = "Yes";
            radInfectiousYes.UseVisualStyleBackColor = true;
            // 
            // radInfectiousNo
            // 
            radInfectiousNo.AutoSize = true;
            radInfectiousNo.Checked = true;
            radInfectiousNo.Location = new System.Drawing.Point(95, 6);
            radInfectiousNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            radInfectiousNo.Name = "radInfectiousNo";
            radInfectiousNo.Size = new System.Drawing.Size(77, 36);
            radInfectiousNo.TabIndex = 4;
            radInfectiousNo.TabStop = true;
            radInfectiousNo.Text = "No";
            radInfectiousNo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 17);
            label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(128, 32);
            label5.TabIndex = 1;
            label5.Text = "Infectious*";
            // 
            // panelInfectious
            // 
            panelInfectious.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelInfectious.Controls.Add(radInfectiousYes);
            panelInfectious.Controls.Add(radInfectiousNo);
            panelInfectious.Location = new System.Drawing.Point(188, 6);
            panelInfectious.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            panelInfectious.Name = "panelInfectious";
            panelInfectious.Size = new System.Drawing.Size(464, 53);
            panelInfectious.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 83);
            label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(137, 32);
            label6.TabIndex = 1;
            label6.Text = "Embalmed*";
            // 
            // panelEmbalmed
            // 
            panelEmbalmed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelEmbalmed.Controls.Add(radEmbalmedYes);
            panelEmbalmed.Controls.Add(radEmbalmedNo);
            panelEmbalmed.Location = new System.Drawing.Point(188, 73);
            panelEmbalmed.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            panelEmbalmed.Name = "panelEmbalmed";
            panelEmbalmed.Size = new System.Drawing.Size(464, 53);
            panelEmbalmed.TabIndex = 5;
            // 
            // radEmbalmedYes
            // 
            radEmbalmedYes.AutoSize = true;
            radEmbalmedYes.Checked = true;
            radEmbalmedYes.Location = new System.Drawing.Point(6, 6);
            radEmbalmedYes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            radEmbalmedYes.Name = "radEmbalmedYes";
            radEmbalmedYes.Size = new System.Drawing.Size(79, 36);
            radEmbalmedYes.TabIndex = 4;
            radEmbalmedYes.TabStop = true;
            radEmbalmedYes.Text = "Yes";
            radEmbalmedYes.UseVisualStyleBackColor = true;
            // 
            // radEmbalmedNo
            // 
            radEmbalmedNo.AutoSize = true;
            radEmbalmedNo.Location = new System.Drawing.Point(95, 6);
            radEmbalmedNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            radEmbalmedNo.Name = "radEmbalmedNo";
            radEmbalmedNo.Size = new System.Drawing.Size(77, 36);
            radEmbalmedNo.TabIndex = 4;
            radEmbalmedNo.Text = "No";
            radEmbalmedNo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 565);
            label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(133, 32);
            label7.TabIndex = 1;
            label7.Text = "Disposition";
            // 
            // txtDisposition
            // 
            txtDisposition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDisposition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtDisposition.Location = new System.Drawing.Point(188, 559);
            txtDisposition.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            txtDisposition.Name = "txtDisposition";
            txtDisposition.Size = new System.Drawing.Size(461, 39);
            txtDisposition.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucBurialDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(panelEmbalmed);
            Controls.Add(panelInfectious);
            Controls.Add(txtDisposition);
            Controls.Add(txtDisinterment);
            Controls.Add(label7);
            Controls.Add(txtCemetery);
            Controls.Add(label4);
            Controls.Add(txtCauseOfDeath);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(dtDeathDate);
            Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            Name = "ucBurialDetails";
            Size = new System.Drawing.Size(693, 621);
            panelInfectious.ResumeLayout(false);
            panelInfectious.PerformLayout();
            panelEmbalmed.ResumeLayout(false);
            panelEmbalmed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCauseOfDeath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCemetery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDisinterment;
        private System.Windows.Forms.RadioButton radInfectiousYes;
        private System.Windows.Forms.RadioButton radInfectiousNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelInfectious;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelEmbalmed;
        private System.Windows.Forms.RadioButton radEmbalmedYes;
        private System.Windows.Forms.RadioButton radEmbalmedNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDisposition;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.DateTimePicker dtDeathDate;
    }
}
