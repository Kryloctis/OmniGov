namespace LFS.Views.Transactions.JEV.JournalForms
{
    partial class ucCshDsbrsmntJrnl
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
            comboBox1 = new System.Windows.Forms.ComboBox();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(23, 150);
            comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(229, 23);
            comboBox1.TabIndex = 33;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dateTimePicker2.Location = new System.Drawing.Point(23, 38);
            dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(229, 23);
            dateTimePicker2.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 15);
            label2.TabIndex = 18;
            label2.Text = "Date Paid:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 132);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(105, 15);
            label8.TabIndex = 20;
            label8.Text = "Disbursing Officer:";
            // 
            // textBox4
            // 
            textBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox4.Location = new System.Drawing.Point(23, 94);
            textBox4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(229, 23);
            textBox4.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 76);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(44, 15);
            label5.TabIndex = 23;
            label5.Text = "DV No.";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucCshDsbrsmntJrnl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Name = "ucCshDsbrsmntJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(278, 207);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
