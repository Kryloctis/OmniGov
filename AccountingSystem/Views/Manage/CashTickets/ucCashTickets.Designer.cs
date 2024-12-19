namespace AccountingSystem.Views.Manage.CashTickets
{
    partial class ucCashTickets
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
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            label4 = new System.Windows.Forms.Label();
            txtRemark = new System.Windows.Forms.TextBox();
            cmbAccountableForms = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(14, 42);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 22;
            label5.Text = "Quantity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(14, 99);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 15);
            label6.TabIndex = 23;
            label6.Text = "Remarks ";
            // 
            // dtpReceivedDate
            // 
            dtpReceivedDate.Location = new System.Drawing.Point(138, 69);
            dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dtpReceivedDate.Name = "dtpReceivedDate";
            dtpReceivedDate.Size = new System.Drawing.Size(200, 23);
            dtpReceivedDate.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(14, 73);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 15);
            label4.TabIndex = 21;
            label4.Text = "Received Date ";
            // 
            // txtRemark
            // 
            txtRemark.Location = new System.Drawing.Point(138, 96);
            txtRemark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtRemark.MaxLength = 500;
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new System.Drawing.Size(200, 46);
            txtRemark.TabIndex = 20;
            // 
            // cmbAccountableForms
            // 
            cmbAccountableForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAccountableForms.DropDownWidth = 200;
            cmbAccountableForms.FormattingEnabled = true;
            cmbAccountableForms.Location = new System.Drawing.Point(138, 12);
            cmbAccountableForms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            cmbAccountableForms.Name = "cmbAccountableForms";
            cmbAccountableForms.Size = new System.Drawing.Size(200, 23);
            cmbAccountableForms.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 15);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(110, 15);
            label3.TabIndex = 24;
            label3.Text = "Accountable Forms";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(138, 41);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(200, 23);
            numericUpDown1.TabIndex = 26;
            numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ucCashTickets
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(numericUpDown1);
            Controls.Add(cmbAccountableForms);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtRemark);
            Controls.Add(label4);
            Controls.Add(dtpReceivedDate);
            Name = "ucCashTickets";
            Size = new System.Drawing.Size(359, 151);
            Load += ucCashTickets_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtRemark;
        internal System.Windows.Forms.ComboBox cmbAccountableForms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
