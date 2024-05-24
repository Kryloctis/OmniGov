namespace AccountingSystem.Views.Transactions.Assessment
{
    partial class ucWarrantLevy
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            dtPckrDateIssued = new System.Windows.Forms.DateTimePicker();
            label10 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            dgDelinquencies = new System.Windows.Forms.DataGridView();
            pbDelinquencies = new System.Windows.Forms.ProgressBar();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            txtRpt = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            txtLocation = new System.Windows.Forms.TextBox();
            radMachinery = new System.Windows.Forms.RadioButton();
            label12 = new System.Windows.Forms.Label();
            radBuilding = new System.Windows.Forms.RadioButton();
            txtAssessedValue = new System.Windows.Forms.TextBox();
            txtOwner = new System.Windows.Forms.TextBox();
            radLand = new System.Windows.Forms.RadioButton();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            bgwDelinquencies = new System.ComponentModel.BackgroundWorker();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDelinquencies).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox2.Location = new System.Drawing.Point(3, 3);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(450, 57);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Warrant Details";
            // 
            // panel2
            // 
            panel2.Controls.Add(dtPckrDateIssued);
            panel2.Controls.Add(label10);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            panel2.Location = new System.Drawing.Point(3, 20);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(444, 34);
            panel2.TabIndex = 0;
            // 
            // dtPckrDateIssued
            // 
            dtPckrDateIssued.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtPckrDateIssued.CustomFormat = "MMM dd, yyyy";
            dtPckrDateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrDateIssued.Location = new System.Drawing.Point(101, 5);
            dtPckrDateIssued.Name = "dtPckrDateIssued";
            dtPckrDateIssued.Size = new System.Drawing.Size(322, 23);
            dtPckrDateIssued.TabIndex = 26;
            dtPckrDateIssued.ValueChanged += dtPckrDateIssued_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(3, 9);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(72, 15);
            label10.TabIndex = 24;
            label10.Text = "Date Issued*";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(panel3);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox3.Location = new System.Drawing.Point(0, 245);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(453, 235);
            groupBox3.TabIndex = 39;
            groupBox3.TabStop = false;
            groupBox3.Text = "Delinquencies";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgDelinquencies);
            panel3.Controls.Add(pbDelinquencies);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            panel3.Location = new System.Drawing.Point(3, 20);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(4);
            panel3.Size = new System.Drawing.Size(447, 212);
            panel3.TabIndex = 0;
            // 
            // dgDelinquencies
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgDelinquencies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgDelinquencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgDelinquencies.DefaultCellStyle = dataGridViewCellStyle2;
            dgDelinquencies.Dock = System.Windows.Forms.DockStyle.Fill;
            dgDelinquencies.Location = new System.Drawing.Point(4, 9);
            dgDelinquencies.Name = "dgDelinquencies";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgDelinquencies.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgDelinquencies.RowTemplate.Height = 25;
            dgDelinquencies.Size = new System.Drawing.Size(439, 199);
            dgDelinquencies.TabIndex = 0;
            dgDelinquencies.Validating += dgDelinquencies_Validating;
            dgDelinquencies.Validated += dgDelinquencies_Validated;
            // 
            // pbDelinquencies
            // 
            pbDelinquencies.Dock = System.Windows.Forms.DockStyle.Top;
            pbDelinquencies.Location = new System.Drawing.Point(4, 4);
            pbDelinquencies.Name = "pbDelinquencies";
            pbDelinquencies.Size = new System.Drawing.Size(439, 5);
            pbDelinquencies.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox1.Location = new System.Drawing.Point(3, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(450, 176);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Real Property";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtRpt);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtLocation);
            panel1.Controls.Add(radMachinery);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(radBuilding);
            panel1.Controls.Add(txtAssessedValue);
            panel1.Controls.Add(txtOwner);
            panel1.Controls.Add(radLand);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label14);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            panel1.Location = new System.Drawing.Point(3, 20);
            panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(444, 153);
            panel1.TabIndex = 0;
            // 
            // txtRpt
            // 
            txtRpt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRpt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            txtRpt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtRpt.Location = new System.Drawing.Point(93, 32);
            txtRpt.Name = "txtRpt";
            txtRpt.Size = new System.Drawing.Size(330, 23);
            txtRpt.TabIndex = 30;
            txtRpt.TextChanged += txtRpt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 15);
            label2.TabIndex = 27;
            label2.Text = "ARP No.*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 8);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(31, 15);
            label11.TabIndex = 1;
            label11.Text = "Kind";
            // 
            // txtLocation
            // 
            txtLocation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLocation.Location = new System.Drawing.Point(93, 89);
            txtLocation.Name = "txtLocation";
            txtLocation.ReadOnly = true;
            txtLocation.Size = new System.Drawing.Size(330, 23);
            txtLocation.TabIndex = 2;
            // 
            // radMachinery
            // 
            radMachinery.AutoSize = true;
            radMachinery.Location = new System.Drawing.Point(225, 7);
            radMachinery.Name = "radMachinery";
            radMachinery.Size = new System.Drawing.Size(81, 19);
            radMachinery.TabIndex = 23;
            radMachinery.Text = "Machinery";
            radMachinery.UseVisualStyleBackColor = true;
            radMachinery.CheckedChanged += radMachinery_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 91);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(53, 15);
            label12.TabIndex = 1;
            label12.Text = "Location";
            // 
            // radBuilding
            // 
            radBuilding.AutoSize = true;
            radBuilding.Location = new System.Drawing.Point(150, 7);
            radBuilding.Name = "radBuilding";
            radBuilding.Size = new System.Drawing.Size(69, 19);
            radBuilding.TabIndex = 23;
            radBuilding.Text = "Building";
            radBuilding.UseVisualStyleBackColor = true;
            radBuilding.CheckedChanged += radBuilding_CheckedChanged;
            // 
            // txtAssessedValue
            // 
            txtAssessedValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAssessedValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAssessedValue.Location = new System.Drawing.Point(93, 118);
            txtAssessedValue.Name = "txtAssessedValue";
            txtAssessedValue.ReadOnly = true;
            txtAssessedValue.Size = new System.Drawing.Size(330, 23);
            txtAssessedValue.TabIndex = 2;
            // 
            // txtOwner
            // 
            txtOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOwner.Location = new System.Drawing.Point(93, 61);
            txtOwner.Name = "txtOwner";
            txtOwner.ReadOnly = true;
            txtOwner.Size = new System.Drawing.Size(330, 23);
            txtOwner.TabIndex = 2;
            // 
            // radLand
            // 
            radLand.AutoSize = true;
            radLand.Checked = true;
            radLand.Location = new System.Drawing.Point(93, 7);
            radLand.Name = "radLand";
            radLand.Size = new System.Drawing.Size(51, 19);
            radLand.TabIndex = 23;
            radLand.TabStop = true;
            radLand.Text = "Land";
            radLand.UseVisualStyleBackColor = true;
            radLand.CheckedChanged += radLand_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(3, 120);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(85, 15);
            label13.TabIndex = 1;
            label13.Text = "Assessed Value";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(3, 62);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(42, 15);
            label14.TabIndex = 1;
            label14.Text = "Owner";
            // 
            // bgwDelinquencies
            // 
            bgwDelinquencies.WorkerReportsProgress = true;
            bgwDelinquencies.WorkerSupportsCancellation = true;
            bgwDelinquencies.DoWork += bgwDelinquencies_DoWork;
            bgwDelinquencies.ProgressChanged += bgwDelinquencies_ProgressChanged;
            bgwDelinquencies.RunWorkerCompleted += bgwDelinquencies_RunWorkerCompleted;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // ucWarrantLevy
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ucWarrantLevy";
            Size = new System.Drawing.Size(457, 482);
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDelinquencies).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtPckrDateIssued;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgDelinquencies;
        private System.Windows.Forms.ProgressBar pbDelinquencies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.RadioButton radMachinery;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radBuilding;
        private System.Windows.Forms.TextBox txtAssessedValue;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.RadioButton radLand;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker bgwDelinquencies;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
