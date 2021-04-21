
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class ucAllotmentReleaseMain
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
            this.dgAllotmentRelease = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbxOthersFPP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOthersFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epARONo = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDateIssued = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.mskYear = new System.Windows.Forms.MaskedTextBox();
            this.mskSeriesNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAllotmentClass = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAllotmentRelease
            // 
            this.dgAllotmentRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgAllotmentRelease.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllotmentRelease.Location = new System.Drawing.Point(6, 259);
            this.dgAllotmentRelease.Name = "dgAllotmentRelease";
            this.dgAllotmentRelease.RowTemplate.Height = 25;
            this.dgAllotmentRelease.Size = new System.Drawing.Size(537, 276);
            this.dgAllotmentRelease.TabIndex = 6;
            this.dgAllotmentRelease.Tag = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(306, 541);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(387, 541);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(468, 541);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funds";
            // 
            // flowLayoutPanelFunds
            // 
            this.flowLayoutPanelFunds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFunds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelFunds.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelFunds.Name = "flowLayoutPanelFunds";
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(531, 31);
            this.flowLayoutPanelFunds.TabIndex = 2;
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(66, 6);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(471, 23);
            this.cmbxFPP.TabIndex = 0;
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "FPP";
            // 
            // cmbxOthersFPP
            // 
            this.cmbxOthersFPP.FormattingEnabled = true;
            this.cmbxOthersFPP.Location = new System.Drawing.Point(66, 35);
            this.cmbxOthersFPP.Name = "cmbxOthersFPP";
            this.cmbxOthersFPP.Size = new System.Drawing.Size(471, 23);
            this.cmbxOthersFPP.TabIndex = 1;
            this.cmbxOthersFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOthersFPP_Validating);
            this.cmbxOthersFPP.Validated += new System.EventHandler(this.cmbxOthersFPP_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Other FPP";
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOthersFPP
            // 
            this.epOthersFPP.ContainerControl = this;
            // 
            // epARONo
            // 
            this.epARONo.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPurpose);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtDateIssued);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.mskYear);
            this.panel1.Controls.Add(this.mskSeriesNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.cmbxOthersFPP);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbxFPP);
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 253);
            this.panel1.TabIndex = 0;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(66, 205);
            this.txtPurpose.MaxLength = 200;
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(471, 39);
            this.txtPurpose.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Purpose";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "-";
            // 
            // dtDateIssued
            // 
            this.dtDateIssued.Location = new System.Drawing.Point(340, 176);
            this.dtDateIssued.Name = "dtDateIssued";
            this.dtDateIssued.Size = new System.Drawing.Size(197, 23);
            this.dtDateIssued.TabIndex = 36;
            this.dtDateIssued.ValueChanged += new System.EventHandler(this.dtDateIssued_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date Issued";
            // 
            // mskYear
            // 
            this.mskYear.Location = new System.Drawing.Point(111, 176);
            this.mskYear.Mask = "0000";
            this.mskYear.Name = "mskYear";
            this.mskYear.ReadOnly = true;
            this.mskYear.Size = new System.Drawing.Size(41, 23);
            this.mskYear.TabIndex = 40;
            this.mskYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mskSeriesNo
            // 
            this.mskSeriesNo.Location = new System.Drawing.Point(66, 176);
            this.mskSeriesNo.Mask = "000";
            this.mskSeriesNo.Name = "mskSeriesNo";
            this.mskSeriesNo.Size = new System.Drawing.Size(27, 23);
            this.mskSeriesNo.TabIndex = 35;
            this.mskSeriesNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskSeriesNo.Validating += new System.ComponentModel.CancelEventHandler(this.mskSeriesNo_Validating);
            this.mskSeriesNo.Validated += new System.EventHandler(this.mskSeriesNo_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "ARO No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelAllotmentClass);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 53);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allotment";
            // 
            // flowLayoutPanelAllotmentClass
            // 
            this.flowLayoutPanelAllotmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAllotmentClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelAllotmentClass.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelAllotmentClass.Name = "flowLayoutPanelAllotmentClass";
            this.flowLayoutPanelAllotmentClass.Size = new System.Drawing.Size(528, 31);
            this.flowLayoutPanelAllotmentClass.TabIndex = 3;
            // 
            // ucAllotmentReleaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgAllotmentRelease);
            this.Name = "ucAllotmentReleaseMain";
            this.Size = new System.Drawing.Size(566, 565);
            this.Load += new System.EventHandler(this.ucAllotmentReleaseMain_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ucAllotmentReleaseMain_Validating);
            this.Validated += new System.EventHandler(this.ucAllotmentReleaseMain_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.dgAllotmentRelease)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOthersFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epARONo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        private System.Windows.Forms.ComboBox CMB;
        private System.Windows.Forms.ComboBox cc;
        internal System.Windows.Forms.ComboBox cmbxOthersFPP;
        internal System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.ErrorProvider epOthersFPP;
        internal System.Windows.Forms.ErrorProvider epARONo;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotmentClass;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView dgAllotmentRelease;
        internal System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DateTimePicker dtDateIssued;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.MaskedTextBox mskYear;
        internal System.Windows.Forms.MaskedTextBox mskSeriesNo;
        private System.Windows.Forms.Label label1;
    }
}
