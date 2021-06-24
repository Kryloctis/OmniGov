
namespace AccountingSystem.Views.Reports.PaymentCollection
{
    partial class frmPCReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnexcel = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "";
            this.dtpMonth.Location = new System.Drawing.Point(73, 13);
            this.dtpMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(294, 27);
            this.dtpMonth.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "From:";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(384, 43);
            this.btnRetrieve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(86, 31);
            this.btnRetrieve.TabIndex = 16;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(15, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 790);
            this.panel1.TabIndex = 19;
            // 
            // btnexcel
            // 
            this.btnexcel.Location = new System.Drawing.Point(944, 7);
            this.btnexcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(134, 31);
            this.btnexcel.TabIndex = 20;
            this.btnexcel.Text = "Generate Excel";
            this.btnexcel.UseVisualStyleBackColor = true;
            this.btnexcel.Visible = false;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // dtto
            // 
            this.dtto.Location = new System.Drawing.Point(73, 47);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(294, 27);
            this.dtto.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "To:";
            // 
            // frmPCReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 885);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtto);
            this.Controls.Add(this.btnexcel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetrieve);
            this.Name = "frmPCReport";
            this.Text = "Reports > Reports of General Collection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPCReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnexcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label2;
    }
}