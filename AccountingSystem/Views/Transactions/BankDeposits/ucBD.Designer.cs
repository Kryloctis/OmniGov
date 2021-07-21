
namespace AccountingSystem.Views.Transactions.BankDeposits
{
    partial class ucBD
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
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            this.cmbbanks = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbfunds = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Reference";
            // 
            // txtreference
            // 
            this.txtreference.Location = new System.Drawing.Point(85, 71);
            this.txtreference.MaxLength = 99;
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(399, 27);
            this.txtreference.TabIndex = 2;
            this.txtreference.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            this.txtreference.Validated += new System.EventHandler(this.txtreference_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Location = new System.Drawing.Point(85, 107);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(399, 27);
            this.dtdate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Amount";
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(85, 143);
            this.txtamount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(400, 27);
            this.txtamount.TabIndex = 4;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtamount.ThousandsSeparator = true;
            // 
            // cmbbanks
            // 
            this.cmbbanks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbanks.FormattingEnabled = true;
            this.cmbbanks.Location = new System.Drawing.Point(85, 3);
            this.cmbbanks.Name = "cmbbanks";
            this.cmbbanks.Size = new System.Drawing.Size(399, 28);
            this.cmbbanks.TabIndex = 1;
            this.cmbbanks.Validating += new System.ComponentModel.CancelEventHandler(this.cmbbanks_Validating);
            this.cmbbanks.Validated += new System.EventHandler(this.cmbbanks_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fund";
            // 
            // cmbfunds
            // 
            this.cmbfunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfunds.FormattingEnabled = true;
            this.cmbfunds.Location = new System.Drawing.Point(85, 37);
            this.cmbfunds.Name = "cmbfunds";
            this.cmbfunds.Size = new System.Drawing.Size(399, 28);
            this.cmbfunds.TabIndex = 26;
            this.cmbfunds.Validating += new System.ComponentModel.CancelEventHandler(this.cmbfunds_Validating);
            this.cmbfunds.Validated += new System.EventHandler(this.cmbfunds_Validated);
            // 
            // ucBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbfunds);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbbanks);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.txtreference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBD";
            this.Size = new System.Drawing.Size(512, 182);
            this.Load += new System.EventHandler(this.ucBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.NumericUpDown txtamount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtdate;
        internal System.Windows.Forms.TextBox txtreference;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbbanks;
        internal System.Windows.Forms.ComboBox cmbfunds;
        private System.Windows.Forms.Label label5;
    }
}
