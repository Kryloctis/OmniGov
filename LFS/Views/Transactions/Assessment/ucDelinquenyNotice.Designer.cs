using LFS.Views.Transactions.Assessment;
namespace LFS.Views.Transactions.Assessment
{
    partial class ucDelinquenyNotice
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
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            txtRpt = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            txtLocation = new System.Windows.Forms.TextBox();
            radMachinery = new System.Windows.Forms.RadioButton();
            label5 = new System.Windows.Forms.Label();
            radBuilding = new System.Windows.Forms.RadioButton();
            txtAssessedValue = new System.Windows.Forms.TextBox();
            txtOwner = new System.Windows.Forms.TextBox();
            radLand = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            panel2 = new System.Windows.Forms.Panel();
            dtPckrDate = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            rad3rdNotice = new System.Windows.Forms.RadioButton();
            label2 = new System.Windows.Forms.Label();
            rad2ndNotice = new System.Windows.Forms.RadioButton();
            rad1stNotice = new System.Windows.Forms.RadioButton();
            groupBox3 = new System.Windows.Forms.GroupBox();
            panel3 = new System.Windows.Forms.Panel();
            dgDelinquencies = new System.Windows.Forms.DataGridView();
            pbDelinquencies = new System.Windows.Forms.ProgressBar();
            bgwDelinquencies = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDelinquencies).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(panel1);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox1.Location = new System.Drawing.Point(0, 101);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(450, 176);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Real Property";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtRpt);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtLocation);
            panel1.Controls.Add(radMachinery);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(radBuilding);
            panel1.Controls.Add(txtAssessedValue);
            panel1.Controls.Add(txtOwner);
            panel1.Controls.Add(radLand);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
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
            txtRpt.Location = new System.Drawing.Point(97, 32);
            txtRpt.Name = "txtRpt";
            txtRpt.Size = new System.Drawing.Size(330, 23);
            txtRpt.TabIndex = 30;
            txtRpt.TextChanged += txtRpt_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 35);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 15);
            label8.TabIndex = 27;
            label8.Text = "ARP No.*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 1;
            label6.Text = "Kind";
            // 
            // txtLocation
            // 
            txtLocation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLocation.Location = new System.Drawing.Point(97, 89);
            txtLocation.Name = "txtLocation";
            txtLocation.ReadOnly = true;
            txtLocation.Size = new System.Drawing.Size(330, 23);
            txtLocation.TabIndex = 2;
            // 
            // radMachinery
            // 
            radMachinery.AutoSize = true;
            radMachinery.Location = new System.Drawing.Point(229, 7);
            radMachinery.Name = "radMachinery";
            radMachinery.Size = new System.Drawing.Size(81, 19);
            radMachinery.TabIndex = 23;
            radMachinery.Text = "Machinery";
            radMachinery.UseVisualStyleBackColor = true;
            radMachinery.CheckedChanged += radMachinery_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 91);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(53, 15);
            label5.TabIndex = 1;
            label5.Text = "Location";
            // 
            // radBuilding
            // 
            radBuilding.AutoSize = true;
            radBuilding.Location = new System.Drawing.Point(154, 7);
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
            txtAssessedValue.Location = new System.Drawing.Point(97, 118);
            txtAssessedValue.Name = "txtAssessedValue";
            txtAssessedValue.ReadOnly = true;
            txtAssessedValue.Size = new System.Drawing.Size(330, 23);
            txtAssessedValue.TabIndex = 2;
            // 
            // txtOwner
            // 
            txtOwner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOwner.Location = new System.Drawing.Point(97, 61);
            txtOwner.Name = "txtOwner";
            txtOwner.ReadOnly = true;
            txtOwner.Size = new System.Drawing.Size(330, 23);
            txtOwner.TabIndex = 2;
            // 
            // radLand
            // 
            radLand.AutoSize = true;
            radLand.Checked = true;
            radLand.Location = new System.Drawing.Point(97, 7);
            radLand.Name = "radLand";
            radLand.Size = new System.Drawing.Size(51, 19);
            radLand.TabIndex = 23;
            radLand.TabStop = true;
            radLand.Text = "Land";
            radLand.UseVisualStyleBackColor = true;
            radLand.CheckedChanged += radLand_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 120);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 15);
            label4.TabIndex = 1;
            label4.Text = "Assessed Value";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 62);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 15);
            label3.TabIndex = 1;
            label3.Text = "Owner";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(panel2);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(450, 88);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            groupBox2.Text = "Notice Details";
            // 
            // panel2
            // 
            panel2.Controls.Add(dtPckrDate);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(rad3rdNotice);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(rad2ndNotice);
            panel2.Controls.Add(rad1stNotice);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            panel2.Location = new System.Drawing.Point(3, 20);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(4);
            panel2.Size = new System.Drawing.Size(444, 65);
            panel2.TabIndex = 0;
            // 
            // dtPckrDate
            // 
            dtPckrDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dtPckrDate.CustomFormat = "MMM dd, yyyy";
            dtPckrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtPckrDate.Location = new System.Drawing.Point(97, 32);
            dtPckrDate.Name = "dtPckrDate";
            dtPckrDate.Size = new System.Drawing.Size(330, 23);
            dtPckrDate.TabIndex = 26;
            dtPckrDate.ValueChanged += dtPckrDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 15);
            label1.TabIndex = 25;
            label1.Text = "Type of Notice*";
            // 
            // rad3rdNotice
            // 
            rad3rdNotice.AutoSize = true;
            rad3rdNotice.Location = new System.Drawing.Point(194, 7);
            rad3rdNotice.Name = "rad3rdNotice";
            rad3rdNotice.Size = new System.Drawing.Size(42, 19);
            rad3rdNotice.TabIndex = 27;
            rad3rdNotice.Text = "3rd";
            rad3rdNotice.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(1, 36);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 15);
            label2.TabIndex = 24;
            label2.Text = "Date*";
            // 
            // rad2ndNotice
            // 
            rad2ndNotice.AutoSize = true;
            rad2ndNotice.Location = new System.Drawing.Point(143, 7);
            rad2ndNotice.Name = "rad2ndNotice";
            rad2ndNotice.Size = new System.Drawing.Size(45, 19);
            rad2ndNotice.TabIndex = 28;
            rad2ndNotice.Text = "2nd";
            rad2ndNotice.UseVisualStyleBackColor = true;
            // 
            // rad1stNotice
            // 
            rad1stNotice.AutoSize = true;
            rad1stNotice.Checked = true;
            rad1stNotice.Location = new System.Drawing.Point(97, 7);
            rad1stNotice.Name = "rad1stNotice";
            rad1stNotice.Size = new System.Drawing.Size(40, 19);
            rad1stNotice.TabIndex = 29;
            rad1stNotice.TabStop = true;
            rad1stNotice.Text = "1st";
            rad1stNotice.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(panel3);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox3.Location = new System.Drawing.Point(0, 287);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(450, 220);
            groupBox3.TabIndex = 28;
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
            panel3.Size = new System.Drawing.Size(444, 197);
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
            dgDelinquencies.Size = new System.Drawing.Size(436, 184);
            dgDelinquencies.TabIndex = 0;
            dgDelinquencies.Validating += dgDelinquencies_Validating;
            dgDelinquencies.Validated += dgDelinquencies_Validated;
            // 
            // pbDelinquencies
            // 
            pbDelinquencies.Dock = System.Windows.Forms.DockStyle.Top;
            pbDelinquencies.Location = new System.Drawing.Point(4, 4);
            pbDelinquencies.Name = "pbDelinquencies";
            pbDelinquencies.Size = new System.Drawing.Size(436, 5);
            pbDelinquencies.TabIndex = 2;
            // 
            // bgwDelinquencies
            // 
            bgwDelinquencies.WorkerReportsProgress = true;
            bgwDelinquencies.WorkerSupportsCancellation = true;
            bgwDelinquencies.DoWork += bgwDelinquencies_DoWork;
            bgwDelinquencies.ProgressChanged += bgwDelinquencies_ProgressChanged;
            bgwDelinquencies.RunWorkerCompleted += bgwDelinquencies_RunWorkerCompleted;
            // 
            // ucDelinquenyNotice
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ucDelinquenyNotice";
            Size = new System.Drawing.Size(450, 507);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgDelinquencies).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.RadioButton radMachinery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radBuilding;
        private System.Windows.Forms.RadioButton radLand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtPckrDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rad3rdNotice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rad2ndNotice;
        private System.Windows.Forms.RadioButton rad1stNotice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgDelinquencies;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAssessedValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRpt;
        private System.ComponentModel.BackgroundWorker bgwDelinquencies;
        private System.Windows.Forms.ProgressBar pbDelinquencies;
    }
}
