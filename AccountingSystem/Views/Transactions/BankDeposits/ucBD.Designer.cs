
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
            this.txtbank = new System.Windows.Forms.TextBox();
            this.btnbank = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtreference = new System.Windows.Forms.TextBox();
            this.dtdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank :";
            // 
            // txtbank
            // 
            this.errorProvider.SetIconAlignment(this.txtbank, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtbank.Location = new System.Drawing.Point(101, 11);
            this.txtbank.Name = "txtbank";
            this.txtbank.ReadOnly = true;
            this.txtbank.Size = new System.Drawing.Size(461, 27);
            this.txtbank.TabIndex = 1;
            this.txtbank.DoubleClick += new System.EventHandler(this.txtbank_DoubleClick);
            this.txtbank.Validating += new System.ComponentModel.CancelEventHandler(this.txtbank_Validating);
            this.txtbank.Validated += new System.EventHandler(this.txtbank_Validated);
            // 
            // btnbank
            // 
            this.btnbank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbank.Image = global::AccountingSystem.Properties.Resources.find1;
            this.btnbank.Location = new System.Drawing.Point(568, 11);
            this.btnbank.Name = "btnbank";
            this.btnbank.Size = new System.Drawing.Size(34, 27);
            this.btnbank.TabIndex = 19;
            this.btnbank.UseVisualStyleBackColor = true;
            this.btnbank.Click += new System.EventHandler(this.btnbank_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Reference :";
            // 
            // txtreference
            // 
            this.txtreference.Location = new System.Drawing.Point(101, 44);
            this.txtreference.MaxLength = 99;
            this.txtreference.Name = "txtreference";
            this.txtreference.Size = new System.Drawing.Size(501, 27);
            this.txtreference.TabIndex = 21;
            this.txtreference.Validating += new System.ComponentModel.CancelEventHandler(this.txtreference_Validating);
            this.txtreference.Validated += new System.EventHandler(this.txtreference_Validated);
            // 
            // dtdate
            // 
            this.dtdate.Location = new System.Drawing.Point(101, 77);
            this.dtdate.Name = "dtdate";
            this.dtdate.Size = new System.Drawing.Size(501, 27);
            this.dtdate.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Amount :";
            // 
            // txtamount
            // 
            this.txtamount.DecimalPlaces = 2;
            this.txtamount.Location = new System.Drawing.Point(101, 110);
            this.txtamount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(501, 27);
            this.txtamount.TabIndex = 25;
            this.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ucBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtdate);
            this.Controls.Add(this.txtreference);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnbank);
            this.Controls.Add(this.txtbank);
            this.Controls.Add(this.label1);
            this.Name = "ucBD";
            this.Size = new System.Drawing.Size(618, 151);
            this.Load += new System.EventHandler(this.ucBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtamount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbank;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.TextBox txtbank;
        internal System.Windows.Forms.NumericUpDown txtamount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtdate;
        internal System.Windows.Forms.TextBox txtreference;
        private System.Windows.Forms.Label label2;
    }
}
