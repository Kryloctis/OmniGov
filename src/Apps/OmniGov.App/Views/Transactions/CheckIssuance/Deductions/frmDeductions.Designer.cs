
namespace OmniGov.App.Views.Transactions.CheckIssuance.Deductions
{
    partial class frmDeductions
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
            components = new System.ComponentModel.Container();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnAddDeductions = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            nudAmount = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            btnConfirmDeductions = new System.Windows.Forms.Button();
            dgDeductions = new System.Windows.Forms.DataGridView();
            epDescription = new System.Windows.Forms.ErrorProvider(components);
            epAmount = new System.Windows.Forms.ErrorProvider(components);
            btnRemoveDeductions = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDeductions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epAmount).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(btnAddDeductions);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nudAmount);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(7, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(367, 119);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Details ";
            // 
            // btnAddDeductions
            // 
            btnAddDeductions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAddDeductions.Location = new System.Drawing.Point(282, 88);
            btnAddDeductions.Name = "btnAddDeductions";
            btnAddDeductions.Size = new System.Drawing.Size(59, 23);
            btnAddDeductions.TabIndex = 2;
            btnAddDeductions.Text = "Add";
            btnAddDeductions.UseVisualStyleBackColor = true;
            btnAddDeductions.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(10, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 13);
            label1.TabIndex = 32;
            label1.Text = "Amount";
            // 
            // nudAmount
            // 
            nudAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            nudAmount.DecimalPlaces = 2;
            nudAmount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nudAmount.Location = new System.Drawing.Point(80, 62);
            nudAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            nudAmount.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new System.Drawing.Size(260, 22);
            nudAmount.TabIndex = 1;
            nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Validating += nudAmount_Validating;
            nudAmount.Validated += nudAmount_Validated;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(17, 23);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(69, 13);
            label6.TabIndex = 21;
            label6.Text = "Description ";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDescription.Location = new System.Drawing.Point(87, 23);
            txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtDescription.MaxLength = 150;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(260, 37);
            txtDescription.TabIndex = 0;
            txtDescription.Validating += txtDescription_Validating;
            txtDescription.Validated += txtDescription_Validated;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(btnConfirmDeductions);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(7, 128);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(367, 169);
            groupBox2.TabIndex = 32;
            groupBox2.TabStop = false;
            groupBox2.Text = "List";
            // 
            // btnConfirmDeductions
            // 
            btnConfirmDeductions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnConfirmDeductions.Enabled = false;
            btnConfirmDeductions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnConfirmDeductions.Location = new System.Drawing.Point(8, 141);
            btnConfirmDeductions.Name = "btnConfirmDeductions";
            btnConfirmDeductions.Size = new System.Drawing.Size(59, 23);
            btnConfirmDeductions.TabIndex = 4;
            btnConfirmDeductions.Text = "Confirm";
            btnConfirmDeductions.UseVisualStyleBackColor = true;
            btnConfirmDeductions.Click += btnConfirmDeductions_Click;
            // 
            // dgDeductions
            // 
            dgDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDeductions.Location = new System.Drawing.Point(16, 146);
            dgDeductions.Name = "dgDeductions";
            dgDeductions.RowTemplate.Height = 25;
            dgDeductions.Size = new System.Drawing.Size(351, 121);
            dgDeductions.TabIndex = 0;
            dgDeductions.SelectionChanged += dgDeductions_SelectionChanged;
            // 
            // epDescription
            // 
            epDescription.ContainerControl = this;
            // 
            // epAmount
            // 
            epAmount.ContainerControl = this;
            // 
            // btnRemoveDeductions
            // 
            btnRemoveDeductions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveDeductions.Enabled = false;
            btnRemoveDeductions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRemoveDeductions.Location = new System.Drawing.Point(309, 269);
            btnRemoveDeductions.Name = "btnRemoveDeductions";
            btnRemoveDeductions.Size = new System.Drawing.Size(59, 23);
            btnRemoveDeductions.TabIndex = 3;
            btnRemoveDeductions.Text = "Remove";
            btnRemoveDeductions.UseVisualStyleBackColor = true;
            btnRemoveDeductions.Click += btnRemove_Click;
            // 
            // frmDeductions
            // 
            AcceptButton = btnAddDeductions;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            ClientSize = new System.Drawing.Size(386, 309);
            Controls.Add(btnRemoveDeductions);
            Controls.Add(dgDeductions);
            Controls.Add(groupBox2);
            Controls.Add(txtDescription);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDeductions";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Deductions";
            FormClosing += frmDeductions_FormClosing;
            Load += frmDeductions_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDeductions).EndInit();
            ((System.ComponentModel.ISupportInitialize)epDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)epAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddDeductions;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.NumericUpDown nudAmount;
        internal System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ErrorProvider epDescription;
        private System.Windows.Forms.ErrorProvider epAmount;
        private System.Windows.Forms.Button btnRemoveDeductions;
        private System.Windows.Forms.Button btnConfirmDeductions;
        internal System.Windows.Forms.DataGridView dgDeductions;
    }
}
