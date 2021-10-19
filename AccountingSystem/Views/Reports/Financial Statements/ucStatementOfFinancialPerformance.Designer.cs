
namespace AccountingSystem.Views.Reports.Financial_Statements
{
    partial class ucStatementOfFinancialPerformance
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbxFunds = new System.Windows.Forms.ComboBox();
            this.dtPickerDateEnds = new System.Windows.Forms.DateTimePicker();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.cmbxFunds);
            this.panel2.Controls.Add(this.dtPickerDateEnds);
            this.panel2.Controls.Add(this.btnRetrieve);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 26);
            this.panel2.TabIndex = 0;
            // 
            // cmbxFunds
            // 
            this.cmbxFunds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFunds.FormattingEnabled = true;
            this.cmbxFunds.Location = new System.Drawing.Point(0, 0);
            this.cmbxFunds.Name = "cmbxFunds";
            this.cmbxFunds.Size = new System.Drawing.Size(185, 23);
            this.cmbxFunds.TabIndex = 3;
            // 
            // dtPickerDateEnds
            // 
            this.dtPickerDateEnds.Location = new System.Drawing.Point(191, 0);
            this.dtPickerDateEnds.Name = "dtPickerDateEnds";
            this.dtPickerDateEnds.Size = new System.Drawing.Size(211, 23);
            this.dtPickerDateEnds.TabIndex = 4;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetrieve.Location = new System.Drawing.Point(408, 0);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(84, 23);
            this.btnRetrieve.TabIndex = 5;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 698);
            this.panel1.TabIndex = 3;
            // 
            // ucStatementOfFinancialPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ucStatementOfFinancialPerformance";
            this.Size = new System.Drawing.Size(931, 724);
            this.Load += new System.EventHandler(this.ucStatementOfFinancialPerformance_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ComboBox cmbxFunds;
        internal System.Windows.Forms.DateTimePicker dtPickerDateEnds;
        internal System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Panel panel1;
    }
}
