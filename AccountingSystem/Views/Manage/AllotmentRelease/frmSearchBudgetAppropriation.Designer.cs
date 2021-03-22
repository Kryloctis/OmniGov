
namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    partial class frmSearchBudgetAppropriation
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgBudgetAppropriations = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbxYear = new System.Windows.Forms.ComboBox();
            this.cmbxTypeOfFund = new System.Windows.Forms.ComboBox();
            this.cmboxAllotmentClass = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgFPP = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.epYear = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgBudgetAppropriations);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(230, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(857, 492);
            this.panel1.TabIndex = 1;
            // 
            // dgBudgetAppropriations
            // 
            this.dgBudgetAppropriations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBudgetAppropriations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBudgetAppropriations.Location = new System.Drawing.Point(3, 35);
            this.dgBudgetAppropriations.Name = "dgBudgetAppropriations";
            this.dgBudgetAppropriations.RowTemplate.Height = 25;
            this.dgBudgetAppropriations.Size = new System.Drawing.Size(851, 454);
            this.dgBudgetAppropriations.TabIndex = 1;
            this.dgBudgetAppropriations.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgBudgetAppropriations_ColumnAdded);
            this.dgBudgetAppropriations.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBudgetAppropriations_RowHeaderMouseDoubleClick);
            this.dgBudgetAppropriations.SelectionChanged += new System.EventHandler(this.dgBudgetAppropriations_SelectionChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cmbxYear);
            this.flowLayoutPanel2.Controls.Add(this.cmbxTypeOfFund);
            this.flowLayoutPanel2.Controls.Add(this.cmboxAllotmentClass);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(851, 32);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // cmbxYear
            // 
            this.cmbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxYear.FormattingEnabled = true;
            this.cmbxYear.Location = new System.Drawing.Point(706, 3);
            this.cmbxYear.Name = "cmbxYear";
            this.cmbxYear.Size = new System.Drawing.Size(142, 23);
            this.cmbxYear.TabIndex = 2;
            this.cmbxYear.SelectedValueChanged += new System.EventHandler(this.cmbxYear_SelectedValueChanged);
            // 
            // cmbxTypeOfFund
            // 
            this.cmbxTypeOfFund.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxTypeOfFund.FormattingEnabled = true;
            this.cmbxTypeOfFund.Location = new System.Drawing.Point(558, 3);
            this.cmbxTypeOfFund.Name = "cmbxTypeOfFund";
            this.cmbxTypeOfFund.Size = new System.Drawing.Size(142, 23);
            this.cmbxTypeOfFund.TabIndex = 0;
            this.cmbxTypeOfFund.SelectedValueChanged += new System.EventHandler(this.cmbxTypeOfFund_SelectedValueChanged);
            // 
            // cmboxAllotmentClass
            // 
            this.cmboxAllotmentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxAllotmentClass.FormattingEnabled = true;
            this.cmboxAllotmentClass.Location = new System.Drawing.Point(410, 3);
            this.cmboxAllotmentClass.Name = "cmboxAllotmentClass";
            this.cmboxAllotmentClass.Size = new System.Drawing.Size(142, 23);
            this.cmboxAllotmentClass.TabIndex = 1;
            this.cmboxAllotmentClass.SelectedValueChanged += new System.EventHandler(this.cmboxAllotmentClass_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgFPP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel2.Size = new System.Drawing.Size(230, 492);
            this.panel2.TabIndex = 2;
            // 
            // dgFPP
            // 
            this.dgFPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFPP.Location = new System.Drawing.Point(3, 3);
            this.dgFPP.Name = "dgFPP";
            this.dgFPP.RowTemplate.Height = 25;
            this.dgFPP.Size = new System.Drawing.Size(227, 486);
            this.dgFPP.TabIndex = 1;
            this.dgFPP.SelectionChanged += new System.EventHandler(this.dgFPP_SelectionChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 492);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1087, 30);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1009, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(928, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // epYear
            // 
            this.epYear.ContainerControl = this;
            // 
            // frmSearchBudgetAppropriation
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1087, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "frmSearchBudgetAppropriation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Budget Appropriation";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBudgetAppropriations)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFPP)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        internal System.Windows.Forms.DataGridView dgFPP;
        internal System.Windows.Forms.DataGridView dataGridView2;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ComboBox cmbxTypeOfFund;
        internal System.Windows.Forms.ComboBox cmboxAllotmentClass;
        internal System.Windows.Forms.Button btnSelect;
        internal System.Windows.Forms.DataGridView dgBudgetAppropriations;
        internal System.Windows.Forms.ErrorProvider epYear;
        internal System.Windows.Forms.ComboBox cmbxYear;
    }
}