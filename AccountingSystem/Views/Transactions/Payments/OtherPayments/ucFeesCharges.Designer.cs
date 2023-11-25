namespace AccountingSystem.Views.Transactions.Payments.OtherPayments
{
    partial class ucFeesCharges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            treeViewTaxTypes = new System.Windows.Forms.TreeView();
            dgOtherPaymentCharges = new System.Windows.Forms.DataGridView();
            panel4 = new System.Windows.Forms.Panel();
            btnRemove = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnUndo = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgOtherPaymentCharges).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.Controls.Add(panel2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(688, 340);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fees && Charges";
            // 
            // panel2
            // 
            panel2.Controls.Add(splitContainer1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.Location = new System.Drawing.Point(4, 24);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(5);
            panel2.Size = new System.Drawing.Size(680, 312);
            panel2.TabIndex = 9;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            splitContainer1.Panel1.Controls.Add(treeViewTaxTypes);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgOtherPaymentCharges);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Size = new System.Drawing.Size(670, 302);
            splitContainer1.SplitterDistance = 223;
            splitContainer1.TabIndex = 10;
            // 
            // treeViewTaxTypes
            // 
            treeViewTaxTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewTaxTypes.Location = new System.Drawing.Point(0, 0);
            treeViewTaxTypes.Name = "treeViewTaxTypes";
            treeViewTaxTypes.Size = new System.Drawing.Size(223, 302);
            treeViewTaxTypes.TabIndex = 0;
            treeViewTaxTypes.AfterSelect += treeViewTaxTypes_AfterSelect;
            // 
            // dgOtherPaymentCharges
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgOtherPaymentCharges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgOtherPaymentCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgOtherPaymentCharges.DefaultCellStyle = dataGridViewCellStyle2;
            dgOtherPaymentCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            dgOtherPaymentCharges.Location = new System.Drawing.Point(38, 0);
            dgOtherPaymentCharges.Name = "dgOtherPaymentCharges";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgOtherPaymentCharges.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgOtherPaymentCharges.RowTemplate.Height = 25;
            dgOtherPaymentCharges.Size = new System.Drawing.Size(405, 302);
            dgOtherPaymentCharges.TabIndex = 8;
            dgOtherPaymentCharges.CellEndEdit += dgOtherPaymentCharges_CellEndEdit;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel4.Controls.Add(btnRemove);
            panel4.Controls.Add(btnAdd);
            panel4.Controls.Add(btnUndo);
            panel4.Dock = System.Windows.Forms.DockStyle.Left;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(38, 302);
            panel4.TabIndex = 4;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnRemove.Location = new System.Drawing.Point(3, 167);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(31, 23);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "x";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnAdd.Location = new System.Drawing.Point(3, 109);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(31, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = ">";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUndo
            // 
            btnUndo.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnUndo.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnUndo.Location = new System.Drawing.Point(3, 138);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new System.Drawing.Size(31, 23);
            btnUndo.TabIndex = 5;
            btnUndo.Text = "<";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // ucOtherCharges
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucOtherCharges";
            Size = new System.Drawing.Size(688, 340);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgOtherPaymentCharges).EndInit();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgOtherPaymentCharges;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.TreeView treeViewTaxTypes;
    }
}
