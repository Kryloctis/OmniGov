
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateEntry = new System.Windows.Forms.DateTimePicker();
            this.btnAddObligations = new System.Windows.Forms.Button();
            this.txtObno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveObligations = new System.Windows.Forms.Button();
            this.dgObligation = new System.Windows.Forms.DataGridView();
            this.btnConfirmObligation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligation)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDateEntry);
            this.groupBox1.Controls.Add(this.btnAddObligations);
            this.groupBox1.Controls.Add(this.txtObno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpDateEntry
            // 
            this.dtpDateEntry.Location = new System.Drawing.Point(97, 40);
            this.dtpDateEntry.Name = "dtpDateEntry";
            this.dtpDateEntry.Size = new System.Drawing.Size(267, 22);
            this.dtpDateEntry.TabIndex = 1;
            // 
            // btnAddObligations
            // 
            this.btnAddObligations.Enabled = false;
            this.btnAddObligations.Location = new System.Drawing.Point(300, 68);
            this.btnAddObligations.Name = "btnAddObligations";
            this.btnAddObligations.Size = new System.Drawing.Size(64, 23);
            this.btnAddObligations.TabIndex = 2;
            this.btnAddObligations.Text = "Add";
            this.btnAddObligations.UseVisualStyleBackColor = true;
            this.btnAddObligations.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtObno
            // 
            this.txtObno.FormattingEnabled = true;
            this.txtObno.Location = new System.Drawing.Point(97, 14);
            this.txtObno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObno.MaxLength = 15;
            this.txtObno.Name = "txtObno";
            this.txtObno.Size = new System.Drawing.Size(267, 21);
            this.txtObno.TabIndex = 0;
            this.txtObno.TextChanged += new System.EventHandler(this.txtObno_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Obligation No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(4, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 182);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List";
            // 
            // btnRemoveObligations
            // 
            this.btnRemoveObligations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveObligations.Enabled = false;
            this.btnRemoveObligations.Location = new System.Drawing.Point(304, 293);
            this.btnRemoveObligations.Name = "btnRemoveObligations";
            this.btnRemoveObligations.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveObligations.TabIndex = 20;
            this.btnRemoveObligations.Text = "Remove";
            this.btnRemoveObligations.UseVisualStyleBackColor = true;
            this.btnRemoveObligations.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // dgObligation
            // 
            this.dgObligation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgObligation.Location = new System.Drawing.Point(12, 123);
            this.dgObligation.Name = "dgObligation";
            this.dgObligation.RowTemplate.Height = 25;
            this.dgObligation.Size = new System.Drawing.Size(354, 157);
            this.dgObligation.TabIndex = 0;
            this.dgObligation.SelectionChanged += new System.EventHandler(this.dgObligation_SelectionChanged);
            // 
            // btnConfirmObligation
            // 
            this.btnConfirmObligation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmObligation.Enabled = false;
            this.btnConfirmObligation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmObligation.Location = new System.Drawing.Point(12, 292);
            this.btnConfirmObligation.Name = "btnConfirmObligation";
            this.btnConfirmObligation.Size = new System.Drawing.Size(64, 23);
            this.btnConfirmObligation.TabIndex = 22;
            this.btnConfirmObligation.Text = "Confirm";
            this.btnConfirmObligation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmObligation.UseVisualStyleBackColor = true;
            this.btnConfirmObligation.Click += new System.EventHandler(this.btnConfirmObligation_Click);
            // 
            // frmObligations
            // 
            this.AcceptButton = this.btnAddObligations;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(380, 322);
            this.Controls.Add(this.btnConfirmObligation);
            this.Controls.Add(this.btnRemoveObligations);
            this.Controls.Add(this.dgObligation);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObligations";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obligations No/s";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmObligations_FormClosing);
            this.Load += new System.EventHandler(this.frmObligations_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObligation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddObligations;
        internal System.Windows.Forms.ComboBox txtObno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveObligations;
        private System.Windows.Forms.Button btnConfirmObligation;
        internal System.Windows.Forms.DataGridView dgObligation;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEntry;
    }
}