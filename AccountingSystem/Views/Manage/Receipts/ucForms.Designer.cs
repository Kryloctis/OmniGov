
namespace AccountingSystem.Views.Manage.Receipts
{
    partial class ucForms
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
            this.cmbforms = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpreceived = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtfrom = new System.Windows.Forms.TextBox();
            this.txtto = new System.Windows.Forms.TextBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accountable Forms";
            // 
            // cmbforms
            // 
            this.cmbforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbforms.FormattingEnabled = true;
            this.cmbforms.Location = new System.Drawing.Point(139, 12);
            this.cmbforms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbforms.Name = "cmbforms";
            this.cmbforms.Size = new System.Drawing.Size(377, 23);
            this.cmbforms.TabIndex = 1;
            this.cmbforms.SelectedIndexChanged += new System.EventHandler(this.cmbforms_SelectedIndexChanged);
            this.cmbforms.Validating += new System.ComponentModel.CancelEventHandler(this.cmbforms_Validating);
            this.cmbforms.Validated += new System.EventHandler(this.cmbforms_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Receipt No. From ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "To ";
            // 
            // dtpreceived
            // 
            this.dtpreceived.Location = new System.Drawing.Point(139, 81);
            this.dtpreceived.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpreceived.Name = "dtpreceived";
            this.dtpreceived.Size = new System.Drawing.Size(377, 23);
            this.dtpreceived.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Received Date ";
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(139, 147);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(377, 69);
            this.txtremarks.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Remarks ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtfrom
            // 
            this.txtfrom.Location = new System.Drawing.Point(139, 47);
            this.txtfrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.Size = new System.Drawing.Size(162, 23);
            this.txtfrom.TabIndex = 12;
            this.txtfrom.TextChanged += new System.EventHandler(this.txtfrom_TextChanged);
            this.txtfrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfrom_KeyPress);
            this.txtfrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtfrom_KeyUp);
            this.txtfrom.Validating += new System.ComponentModel.CancelEventHandler(this.txtfrom_Validating);
            this.txtfrom.Validated += new System.EventHandler(this.txtfrom_Validated);
            // 
            // txtto
            // 
            this.txtto.Location = new System.Drawing.Point(350, 47);
            this.txtto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtto.Name = "txtto";
            this.txtto.Size = new System.Drawing.Size(166, 23);
            this.txtto.TabIndex = 13;
            this.txtto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtto_KeyPress);
            this.txtto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtto_KeyUp);
            this.txtto.Validating += new System.ComponentModel.CancelEventHandler(this.txtto_Validating);
            this.txtto.Validated += new System.EventHandler(this.txtto_Validated);
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(139, 110);
            this.txtquantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.ReadOnly = true;
            this.txtquantity.Size = new System.Drawing.Size(377, 23);
            this.txtquantity.TabIndex = 14;
            this.txtquantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtquantity_KeyPress);
            this.txtquantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtquantity_Validating);
            this.txtquantity.Validated += new System.EventHandler(this.txtquantity_Validated);
            // 
            // ucForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.txtto);
            this.Controls.Add(this.txtfrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtremarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpreceived);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbforms);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucForms";
            this.Size = new System.Drawing.Size(540, 226);
            this.Load += new System.EventHandler(this.ucForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
        internal System.Windows.Forms.ComboBox cmbforms;
        internal System.Windows.Forms.DateTimePicker dtpreceived;
        internal System.Windows.Forms.TextBox txtremarks;
        internal System.Windows.Forms.TextBox txtquantity;
        internal System.Windows.Forms.TextBox txtto;
        internal System.Windows.Forms.TextBox txtfrom;
    }
}
