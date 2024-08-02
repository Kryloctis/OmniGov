
namespace AccountingSystem.Views.Manage.AccountableForm
{
    partial class ucFaceValue
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
            dtDateEffective = new System.Windows.Forms.DateTimePicker();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            chckDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dtDateEffective
            // 
            dtDateEffective.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDateEffective.CustomFormat = "MMM dd, yyyy";
            dtDateEffective.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDateEffective.Location = new System.Drawing.Point(93, 30);
            dtDateEffective.Name = "dtDateEffective";
            dtDateEffective.Size = new System.Drawing.Size(192, 23);
            dtDateEffective.TabIndex = 0;
            // 
            // nudAmount
            // 
            nudAmount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new System.Drawing.Point(93, 59);
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(192, 23);
            nudAmount.TabIndex = 1;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 15);
            label1.TabIndex = 2;
            label1.Text = "Date Effective*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Amount*";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // chckDefault
            // 
            chckDefault.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chckDefault.AutoSize = true;
            chckDefault.Location = new System.Drawing.Point(221, 5);
            chckDefault.Name = "chckDefault";
            chckDefault.Size = new System.Drawing.Size(64, 19);
            chckDefault.TabIndex = 3;
            chckDefault.Text = "Default";
            chckDefault.UseVisualStyleBackColor = true;
            // 
            // ucFaceValue
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(chckDefault);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudAmount);
            Controls.Add(dtDateEffective);
            Name = "ucFaceValue";
            Size = new System.Drawing.Size(303, 92);
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal System.Windows.Forms.DateTimePicker dtDateEffective;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.CheckBox chckDefault;
    }
}
