
namespace AccountingSystem.Views.Transactions.CheckIssuance.Obligations
{
    partial class frmObligations
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
            this.dgObligationNoList = new System.Windows.Forms.DataGridView();
            this.obligation_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.options = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtObno = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationNoList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgObligationNoList
            // 
            this.dgObligationNoList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgObligationNoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligationNoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.obligation_no,
            this.options});
            this.dgObligationNoList.Location = new System.Drawing.Point(332, 197);
            this.dgObligationNoList.MultiSelect = false;
            this.dgObligationNoList.Name = "dgObligationNoList";
            this.dgObligationNoList.RowTemplate.Height = 25;
            this.dgObligationNoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgObligationNoList.Size = new System.Drawing.Size(227, 83);
            this.dgObligationNoList.TabIndex = 16;
            // 
            // obligation_no
            // 
            this.obligation_no.HeaderText = "Obligation No.";
            this.obligation_no.Name = "obligation_no";
            this.obligation_no.Width = 140;
            // 
            // options
            // 
            this.options.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.options.FillWeight = 50F;
            this.options.HeaderText = "";
            this.options.Name = "options";
            this.options.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.options.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(484, 170);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtObno
            // 
            this.txtObno.FormattingEnabled = true;
            this.txtObno.Location = new System.Drawing.Point(332, 170);
            this.txtObno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(146, 23);
            this.txtObno.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Obligation No.";
            // 
            // frmObligations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgObligationNoList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtObno);
            this.Controls.Add(this.label6);
            this.Name = "frmObligations";
            this.Text = "frmObligations";
            ((System.ComponentModel.ISupportInitialize)(this.dgObligationNoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgObligationNoList;
        private System.Windows.Forms.DataGridViewTextBoxColumn obligation_no;
        private System.Windows.Forms.DataGridViewButtonColumn options;
        private System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.ComboBox txtObno;
        private System.Windows.Forms.Label label6;
    }
}