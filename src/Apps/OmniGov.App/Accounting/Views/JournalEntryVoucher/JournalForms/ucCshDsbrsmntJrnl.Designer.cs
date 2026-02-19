namespace OmniGov.App.Accounting.Views.JournalEntryVoucher.JournalForms
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
            cmbxDsbrsngOffcr = new System.Windows.Forms.ComboBox();
            dtDatePaid = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txtDvNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cmbxDsbrsngOffcr
            // 
            cmbxDsbrsngOffcr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cmbxDsbrsngOffcr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxDsbrsngOffcr.FormattingEnabled = true;
            cmbxDsbrsngOffcr.Location = new System.Drawing.Point(85, 95);
            cmbxDsbrsngOffcr.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            cmbxDsbrsngOffcr.Name = "cmbxDsbrsngOffcr";
            cmbxDsbrsngOffcr.Size = new System.Drawing.Size(226, 23);
            cmbxDsbrsngOffcr.TabIndex = 33;
            cmbxDsbrsngOffcr.Validating += cmbxDsbrsngOffcr_Validating;
            cmbxDsbrsngOffcr.Validated += cmbxDsbrsngOffcr_Validated;
            // 
            // dtDatePaid
            // 
            dtDatePaid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtDatePaid.Location = new System.Drawing.Point(85, 23);
            dtDatePaid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            dtDatePaid.Name = "dtDatePaid";
            dtDatePaid.Size = new System.Drawing.Size(226, 23);
            dtDatePaid.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 18;
            label2.Text = "Date Paid";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 99);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 15);
            label8.TabIndex = 20;
            label8.Text = "Disb. Off.";
            // 
            // txtDvNo
            // 
            txtDvNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtDvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDvNo.Location = new System.Drawing.Point(85, 59);
            txtDvNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            txtDvNo.Name = "txtDvNo";
            txtDvNo.Size = new System.Drawing.Size(226, 23);
            txtDvNo.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(23, 63);
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
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(cmbxDsbrsngOffcr);
            Controls.Add(dtDatePaid);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(txtDvNo);
            Controls.Add(label5);
            Name = "ucCshDsbrsmntJrnl";
            Padding = new System.Windows.Forms.Padding(20);
            Size = new System.Drawing.Size(334, 137);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxDsbrsngOffcr;
        private System.Windows.Forms.DateTimePicker dtDatePaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDvNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
