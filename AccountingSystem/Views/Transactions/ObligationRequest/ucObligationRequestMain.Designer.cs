
namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    partial class ucObligationRequestMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelFunds = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAllotmentClass = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxFPP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxOtherFPP = new System.Windows.Forms.ComboBox();
            this.dtDateRequest = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.mskTxtObligationNoSeries = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtObligationNoTemplate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.epFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epOtherFPP = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epReferenceNo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epExplanation = new System.Windows.Forms.ErrorProvider(this.components);
            this.epObligationRequest = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPayee = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOtherFPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFunds);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 54);
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
            this.flowLayoutPanelFunds.Size = new System.Drawing.Size(535, 32);
            this.flowLayoutPanelFunds.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelAllotmentClass);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 54);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allotment Class";
            // 
            // flowLayoutPanelAllotmentClass
            // 
            this.flowLayoutPanelAllotmentClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAllotmentClass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flowLayoutPanelAllotmentClass.Location = new System.Drawing.Point(3, 19);
            this.flowLayoutPanelAllotmentClass.Name = "flowLayoutPanelAllotmentClass";
            this.flowLayoutPanelAllotmentClass.Size = new System.Drawing.Size(535, 32);
            this.flowLayoutPanelAllotmentClass.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "FPP";
            // 
            // cmbxFPP
            // 
            this.cmbxFPP.FormattingEnabled = true;
            this.cmbxFPP.Location = new System.Drawing.Point(92, 10);
            this.cmbxFPP.Name = "cmbxFPP";
            this.cmbxFPP.Size = new System.Drawing.Size(449, 23);
            this.cmbxFPP.TabIndex = 0;
            this.cmbxFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxFPP_Validating);
            this.cmbxFPP.Validated += new System.EventHandler(this.cmbxFPP_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Other FPP";
            // 
            // cmbxOtherFPP
            // 
            this.cmbxOtherFPP.FormattingEnabled = true;
            this.cmbxOtherFPP.Location = new System.Drawing.Point(92, 39);
            this.cmbxOtherFPP.Name = "cmbxOtherFPP";
            this.cmbxOtherFPP.Size = new System.Drawing.Size(449, 23);
            this.cmbxOtherFPP.TabIndex = 1;
            this.cmbxOtherFPP.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxOtherFPP_Validating);
            this.cmbxOtherFPP.Validated += new System.EventHandler(this.cmbxOtherFPP_Validated);
            // 
            // dtDateRequest
            // 
            this.dtDateRequest.Location = new System.Drawing.Point(332, 184);
            this.dtDateRequest.Name = "dtDateRequest";
            this.dtDateRequest.Size = new System.Drawing.Size(209, 23);
            this.dtDateRequest.TabIndex = 8;
            this.dtDateRequest.ValueChanged += new System.EventHandler(this.dtDateRequest_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date of Request";
            // 
            // mskTxtObligationNoSeries
            // 
            this.mskTxtObligationNoSeries.Location = new System.Drawing.Point(92, 184);
            this.mskTxtObligationNoSeries.Mask = "0000";
            this.mskTxtObligationNoSeries.Name = "mskTxtObligationNoSeries";
            this.mskTxtObligationNoSeries.Size = new System.Drawing.Size(33, 23);
            this.mskTxtObligationNoSeries.TabIndex = 6;
            this.mskTxtObligationNoSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTxtObligationNoSeries.Validating += new System.ComponentModel.CancelEventHandler(this.mskTxtObligationNoSeries_Validating);
            this.mskTxtObligationNoSeries.Validated += new System.EventHandler(this.mskTxtObligationNoSeries_Validated);
            // 
            // mskTxtObligationNoTemplate
            // 
            this.mskTxtObligationNoTemplate.Location = new System.Drawing.Point(143, 184);
            this.mskTxtObligationNoTemplate.Mask = "00-00-000";
            this.mskTxtObligationNoTemplate.Name = "mskTxtObligationNoTemplate";
            this.mskTxtObligationNoTemplate.ReadOnly = true;
            this.mskTxtObligationNoTemplate.Size = new System.Drawing.Size(67, 23);
            this.mskTxtObligationNoTemplate.TabIndex = 7;
            this.mskTxtObligationNoTemplate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Obligation No.";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(92, 242);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(449, 23);
            this.txtPayee.TabIndex = 10;
            this.txtPayee.Validating += new System.ComponentModel.CancelEventHandler(this.txtPayee_Validating);
            this.txtPayee.Validated += new System.EventHandler(this.txtPayee_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Payee";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Explanation";
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(92, 271);
            this.txtExplanation.Multiline = true;
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.Size = new System.Drawing.Size(449, 36);
            this.txtExplanation.TabIndex = 11;
            this.txtExplanation.Validating += new System.ComponentModel.CancelEventHandler(this.txtExplanation_Validating);
            this.txtExplanation.Validated += new System.EventHandler(this.txtExplanation_Validated);
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(92, 213);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(449, 23);
            this.txtReferenceNo.TabIndex = 9;
            this.txtReferenceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtReferenceNo_Validating);
            this.txtReferenceNo.Validated += new System.EventHandler(this.txtReferenceNo_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Reference No.";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(541, 237);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(466, 556);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(385, 556);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(304, 556);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // epFPP
            // 
            this.epFPP.ContainerControl = this;
            // 
            // epOtherFPP
            // 
            this.epOtherFPP.ContainerControl = this;
            // 
            // epObligationNo
            // 
            this.epObligationNo.ContainerControl = this;
            // 
            // epReferenceNo
            // 
            this.epReferenceNo.ContainerControl = this;
            // 
            // epExplanation
            // 
            this.epExplanation.ContainerControl = this;
            // 
            // epObligationRequest
            // 
            this.epObligationRequest.ContainerControl = this;
            // 
            // epPayee
            // 
            this.epPayee.ContainerControl = this;
            // 
            // ucObligationRequestMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mskTxtObligationNoTemplate);
            this.Controls.Add(this.mskTxtObligationNoSeries);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtDateRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxOtherFPP);
            this.Controls.Add(this.cmbxFPP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucObligationRequestMain";
            this.Size = new System.Drawing.Size(561, 583);
            this.Load += new System.EventHandler(this.ucObligationRequestMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epOtherFPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epReferenceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epExplanation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epObligationRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPayee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ComboBox cmbxOtherFPP;
        internal System.Windows.Forms.ComboBox cmbxFPP;
        internal System.Windows.Forms.MaskedTextBox mskTxtObligationNoTemplate;
        internal System.Windows.Forms.DateTimePicker dtDateRequest;
        internal System.Windows.Forms.MaskedTextBox mskTxtObligationNoSeries;
        internal System.Windows.Forms.TextBox txtExplanation;
        internal System.Windows.Forms.TextBox txtPayee;
        internal System.Windows.Forms.TextBox txtReferenceNo;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ErrorProvider epFPP;
        internal System.Windows.Forms.ErrorProvider epOtherFPP;
        internal System.Windows.Forms.ErrorProvider epObligationNo;
        internal System.Windows.Forms.ErrorProvider epReferenceNo;
        internal System.Windows.Forms.ErrorProvider epExplanation;
        internal System.Windows.Forms.ErrorProvider epObligationRequest;
        internal System.Windows.Forms.ErrorProvider epPayee;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFunds;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAllotmentClass;
    }
}
