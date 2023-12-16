namespace AccountingSystem.Views.Manage.TaxPayers
{
    partial class ucRealProperties
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
            txtArpNo = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtPropertyPin = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            cmbxBarangays = new System.Windows.Forms.ComboBox();
            cmbxClassification = new System.Windows.Forms.ComboBox();
            cmbxActualUse = new System.Windows.Forms.ComboBox();
            cmbxPropertyKind = new System.Windows.Forms.ComboBox();
            nudEffectivityQuarter = new System.Windows.Forms.NumericUpDown();
            nudEffectivityYear = new System.Windows.Forms.NumericUpDown();
            nudAssessedValue = new System.Windows.Forms.NumericUpDown();
            nudGrYear = new System.Windows.Forms.NumericUpDown();
            nudOtherImprv = new System.Windows.Forms.NumericUpDown();
            nudArea = new System.Windows.Forms.NumericUpDown();
            txtLotNo = new System.Windows.Forms.TextBox();
            chckTaxable = new System.Windows.Forms.CheckBox();
            chckCancelled = new System.Windows.Forms.CheckBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            label4 = new System.Windows.Forms.Label();
            cmbxTaxpayer = new System.Windows.Forms.ComboBox();
            txtRepresentative = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageDetails = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            txtStreet = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tabPagePreviousAsssessments = new System.Windows.Forms.TabPage();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            cmbxPreviousRpt = new System.Windows.Forms.ToolStripComboBox();
            btnAddPrevRpt = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            btnDeletePrevRpt = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)nudEffectivityQuarter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEffectivityYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAssessedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGrYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOtherImprv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageDetails.SuspendLayout();
            panel1.SuspendLayout();
            tabPagePreviousAsssessments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtArpNo
            // 
            txtArpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtArpNo.Location = new System.Drawing.Point(102, 33);
            txtArpNo.Name = "txtArpNo";
            txtArpNo.Size = new System.Drawing.Size(250, 23);
            txtArpNo.TabIndex = 0;
            txtArpNo.Validating += txtArpNo_Validating;
            txtArpNo.Validated += txtArpNo_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 15);
            label1.TabIndex = 24;
            label1.Text = "ARP No.";
            // 
            // txtPropertyPin
            // 
            txtPropertyPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPropertyPin.Location = new System.Drawing.Point(102, 62);
            txtPropertyPin.Name = "txtPropertyPin";
            txtPropertyPin.Size = new System.Drawing.Size(250, 23);
            txtPropertyPin.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 15);
            label2.TabIndex = 25;
            label2.Text = "Property PIN";
            // 
            // cmbxBarangays
            // 
            cmbxBarangays.FormattingEnabled = true;
            cmbxBarangays.Location = new System.Drawing.Point(102, 149);
            cmbxBarangays.Name = "cmbxBarangays";
            cmbxBarangays.Size = new System.Drawing.Size(250, 23);
            cmbxBarangays.TabIndex = 2;
            cmbxBarangays.Validating += cmbxBarangays_Validating;
            cmbxBarangays.Validated += cmbxBarangays_Validated;
            // 
            // cmbxClassification
            // 
            cmbxClassification.FormattingEnabled = true;
            cmbxClassification.Location = new System.Drawing.Point(102, 178);
            cmbxClassification.Name = "cmbxClassification";
            cmbxClassification.Size = new System.Drawing.Size(250, 23);
            cmbxClassification.TabIndex = 3;
            cmbxClassification.Validating += cmbxClassification_Validating;
            cmbxClassification.Validated += cmbxClassification_Validated;
            // 
            // cmbxActualUse
            // 
            cmbxActualUse.FormattingEnabled = true;
            cmbxActualUse.Location = new System.Drawing.Point(102, 207);
            cmbxActualUse.Name = "cmbxActualUse";
            cmbxActualUse.Size = new System.Drawing.Size(250, 23);
            cmbxActualUse.TabIndex = 4;
            cmbxActualUse.Validating += cmbxActualUse_Validating;
            cmbxActualUse.Validated += cmbxActualUse_Validated;
            // 
            // cmbxPropertyKind
            // 
            cmbxPropertyKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbxPropertyKind.FormattingEnabled = true;
            cmbxPropertyKind.Location = new System.Drawing.Point(102, 91);
            cmbxPropertyKind.Name = "cmbxPropertyKind";
            cmbxPropertyKind.Size = new System.Drawing.Size(250, 23);
            cmbxPropertyKind.TabIndex = 5;
            cmbxPropertyKind.SelectedValueChanged += cmbxPropertyKind_SelectedValueChanged;
            // 
            // nudEffectivityQuarter
            // 
            nudEffectivityQuarter.BackColor = System.Drawing.SystemColors.Window;
            nudEffectivityQuarter.Location = new System.Drawing.Point(102, 236);
            nudEffectivityQuarter.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudEffectivityQuarter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudEffectivityQuarter.Name = "nudEffectivityQuarter";
            nudEffectivityQuarter.ReadOnly = true;
            nudEffectivityQuarter.Size = new System.Drawing.Size(250, 23);
            nudEffectivityQuarter.TabIndex = 6;
            nudEffectivityQuarter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudEffectivityYear
            // 
            nudEffectivityYear.Location = new System.Drawing.Point(102, 265);
            nudEffectivityYear.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            nudEffectivityYear.Minimum = new decimal(new int[] { 1930, 0, 0, 0 });
            nudEffectivityYear.Name = "nudEffectivityYear";
            nudEffectivityYear.Size = new System.Drawing.Size(250, 23);
            nudEffectivityYear.TabIndex = 7;
            nudEffectivityYear.Value = new decimal(new int[] { 2022, 0, 0, 0 });
            nudEffectivityYear.Validating += nudEffectivityYear_Validating;
            nudEffectivityYear.Validated += nudEffectivityYear_Validated;
            // 
            // nudAssessedValue
            // 
            nudAssessedValue.DecimalPlaces = 2;
            nudAssessedValue.Location = new System.Drawing.Point(102, 294);
            nudAssessedValue.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudAssessedValue.Name = "nudAssessedValue";
            nudAssessedValue.Size = new System.Drawing.Size(250, 23);
            nudAssessedValue.TabIndex = 8;
            nudAssessedValue.ThousandsSeparator = true;
            nudAssessedValue.Validating += nudAssessedValue_Validating;
            nudAssessedValue.Validated += nudAssessedValue_Validated;
            // 
            // nudGrYear
            // 
            nudGrYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            nudGrYear.Location = new System.Drawing.Point(102, 352);
            nudGrYear.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudGrYear.Name = "nudGrYear";
            nudGrYear.Size = new System.Drawing.Size(250, 23);
            nudGrYear.TabIndex = 9;
            nudGrYear.Validating += nudGrYear_Validating;
            nudGrYear.Validated += nudGrYear_Validated;
            // 
            // nudOtherImprv
            // 
            nudOtherImprv.DecimalPlaces = 2;
            nudOtherImprv.Location = new System.Drawing.Point(102, 323);
            nudOtherImprv.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudOtherImprv.Name = "nudOtherImprv";
            nudOtherImprv.Size = new System.Drawing.Size(250, 23);
            nudOtherImprv.TabIndex = 10;
            nudOtherImprv.ThousandsSeparator = true;
            // 
            // nudArea
            // 
            nudArea.DecimalPlaces = 2;
            nudArea.Location = new System.Drawing.Point(102, 381);
            nudArea.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            nudArea.Name = "nudArea";
            nudArea.Size = new System.Drawing.Size(250, 23);
            nudArea.TabIndex = 11;
            nudArea.ThousandsSeparator = true;
            nudArea.Validating += nudArea_Validating;
            nudArea.Validated += nudArea_Validated;
            // 
            // txtLotNo
            // 
            txtLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLotNo.Location = new System.Drawing.Point(102, 410);
            txtLotNo.Name = "txtLotNo";
            txtLotNo.Size = new System.Drawing.Size(250, 23);
            txtLotNo.TabIndex = 12;
            txtLotNo.Validating += txtLotNo_Validating;
            txtLotNo.Validated += txtLotNo_Validated;
            // 
            // chckTaxable
            // 
            chckTaxable.AutoSize = true;
            chckTaxable.Checked = true;
            chckTaxable.CheckState = System.Windows.Forms.CheckState.Checked;
            chckTaxable.Location = new System.Drawing.Point(203, 8);
            chckTaxable.Name = "chckTaxable";
            chckTaxable.Size = new System.Drawing.Size(65, 19);
            chckTaxable.TabIndex = 13;
            chckTaxable.Text = "Taxable";
            chckTaxable.UseVisualStyleBackColor = true;
            // 
            // chckCancelled
            // 
            chckCancelled.AutoSize = true;
            chckCancelled.Location = new System.Drawing.Point(274, 8);
            chckCancelled.Name = "chckCancelled";
            chckCancelled.Size = new System.Drawing.Size(78, 19);
            chckCancelled.TabIndex = 14;
            chckCancelled.Text = "Cancelled";
            chckCancelled.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(10, 238);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(86, 15);
            label11.TabIndex = 2;
            label11.Text = "Effectivity Qrtr.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(10, 267);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(84, 15);
            label12.TabIndex = 3;
            label12.Text = "Effectivity Year";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(10, 296);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(85, 15);
            label13.TabIndex = 4;
            label13.Text = "Assessed Value";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(10, 325);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(74, 15);
            label14.TabIndex = 6;
            label14.Text = "Other Imprv.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(10, 383);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(31, 15);
            label15.TabIndex = 8;
            label15.Text = "Area";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(10, 412);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(43, 15);
            label16.TabIndex = 7;
            label16.Text = "Lot No";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(10, 354);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(47, 15);
            label17.TabIndex = 5;
            label17.Text = "GR year";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(10, 93);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 15);
            label10.TabIndex = 1;
            label10.Text = "Property Kind";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(10, 210);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(63, 15);
            label9.TabIndex = 0;
            label9.Text = "Actual Use";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(10, 181);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(77, 15);
            label8.TabIndex = 27;
            label8.Text = "Classification";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 152);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(56, 15);
            label7.TabIndex = 26;
            label7.Text = "Barangay";
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 441);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 15);
            label4.TabIndex = 1;
            label4.Text = "Taxpayer";
            // 
            // cmbxTaxpayer
            // 
            cmbxTaxpayer.FormattingEnabled = true;
            cmbxTaxpayer.Location = new System.Drawing.Point(102, 439);
            cmbxTaxpayer.Name = "cmbxTaxpayer";
            cmbxTaxpayer.Size = new System.Drawing.Size(250, 23);
            cmbxTaxpayer.TabIndex = 21;
            cmbxTaxpayer.SelectedIndexChanged += cmbxTaxpayer_SelectedIndexChanged;
            cmbxTaxpayer.KeyPress += cmbxTaxpayer_KeyPress;
            cmbxTaxpayer.PreviewKeyDown += cmbxTaxpayer_PreviewKeyDown;
            cmbxTaxpayer.Validating += cmbxTaxpayer_Validating;
            cmbxTaxpayer.Validated += cmbxTaxpayer_Validated;
            // 
            // txtRepresentative
            // 
            txtRepresentative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRepresentative.Location = new System.Drawing.Point(102, 468);
            txtRepresentative.Name = "txtRepresentative";
            txtRepresentative.ReadOnly = true;
            txtRepresentative.Size = new System.Drawing.Size(250, 23);
            txtRepresentative.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 470);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 15);
            label3.TabIndex = 1;
            label3.Text = "Representative";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDetails);
            tabControl1.Controls.Add(tabPagePreviousAsssessments);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(387, 533);
            tabControl1.TabIndex = 29;
            // 
            // tabPageDetails
            // 
            tabPageDetails.Controls.Add(panel1);
            tabPageDetails.Location = new System.Drawing.Point(4, 24);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            tabPageDetails.Size = new System.Drawing.Size(379, 505);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtStreet);
            panel1.Controls.Add(txtArpNo);
            panel1.Controls.Add(chckCancelled);
            panel1.Controls.Add(txtLotNo);
            panel1.Controls.Add(txtRepresentative);
            panel1.Controls.Add(cmbxActualUse);
            panel1.Controls.Add(chckTaxable);
            panel1.Controls.Add(cmbxPropertyKind);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(cmbxClassification);
            panel1.Controls.Add(nudAssessedValue);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPropertyPin);
            panel1.Controls.Add(nudArea);
            panel1.Controls.Add(nudGrYear);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(nudEffectivityQuarter);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(cmbxTaxpayer);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nudEffectivityYear);
            panel1.Controls.Add(nudOtherImprv);
            panel1.Controls.Add(cmbxBarangays);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(4);
            panel1.Size = new System.Drawing.Size(373, 499);
            panel1.TabIndex = 0;
            // 
            // txtStreet
            // 
            txtStreet.Location = new System.Drawing.Point(102, 120);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new System.Drawing.Size(250, 23);
            txtStreet.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 123);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 1;
            label5.Text = "Street";
            // 
            // tabPagePreviousAsssessments
            // 
            tabPagePreviousAsssessments.Controls.Add(dataGridView1);
            tabPagePreviousAsssessments.Controls.Add(toolStrip1);
            tabPagePreviousAsssessments.Location = new System.Drawing.Point(4, 24);
            tabPagePreviousAsssessments.Name = "tabPagePreviousAsssessments";
            tabPagePreviousAsssessments.Padding = new System.Windows.Forms.Padding(3);
            tabPagePreviousAsssessments.Size = new System.Drawing.Size(379, 505);
            tabPagePreviousAsssessments.TabIndex = 1;
            tabPagePreviousAsssessments.Text = "Previous Assessments";
            tabPagePreviousAsssessments.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(3, 34);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(373, 468);
            dataGridView1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { cmbxPreviousRpt, btnAddPrevRpt, toolStripSeparator1, btnDeletePrevRpt });
            toolStrip1.Location = new System.Drawing.Point(3, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(4);
            toolStrip1.Size = new System.Drawing.Size(373, 31);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // cmbxPreviousRpt
            // 
            cmbxPreviousRpt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            cmbxPreviousRpt.Name = "cmbxPreviousRpt";
            cmbxPreviousRpt.Size = new System.Drawing.Size(150, 23);
            cmbxPreviousRpt.KeyPress += cmbxPreviousRpt_KeyPress;
            // 
            // btnAddPrevRpt
            // 
            btnAddPrevRpt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnAddPrevRpt.Image = Properties.Resources.symbol_add_20px;
            btnAddPrevRpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnAddPrevRpt.Name = "btnAddPrevRpt";
            btnAddPrevRpt.Size = new System.Drawing.Size(23, 20);
            btnAddPrevRpt.Text = "Apply";
            btnAddPrevRpt.Click += btnAddPrevRpt_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDeletePrevRpt
            // 
            btnDeletePrevRpt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            btnDeletePrevRpt.Image = Properties.Resources.waste_bin_filled_20px;
            btnDeletePrevRpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDeletePrevRpt.Name = "btnDeletePrevRpt";
            btnDeletePrevRpt.Size = new System.Drawing.Size(23, 20);
            btnDeletePrevRpt.Text = "Delete";
            btnDeletePrevRpt.Click += btnDeleteRptPrev_Click;
            // 
            // ucRealProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            Controls.Add(tabControl1);
            Name = "ucRealProperties";
            Size = new System.Drawing.Size(387, 533);
            ((System.ComponentModel.ISupportInitialize)nudEffectivityQuarter).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEffectivityYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAssessedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGrYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOtherImprv).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPagePreviousAsssessments.ResumeLayout(false);
            tabPagePreviousAsssessments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        internal System.Windows.Forms.TextBox txtArpNo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPropertyPin;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtLotNo;
        internal System.Windows.Forms.ComboBox cmbxPropertyKind;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.NumericUpDown nudEffectivityQuarter;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.NumericUpDown nudEffectivityYear;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.NumericUpDown nudAssessedValue;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.NumericUpDown nudOtherImprv;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.NumericUpDown nudArea;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.NumericUpDown nudGrYear;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.CheckBox chckTaxable;
        internal System.Windows.Forms.CheckBox chckCancelled;
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ComboBox cmbxBarangays;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbxActualUse;
        internal System.Windows.Forms.ComboBox cmbxClassification;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectProperty;
        private System.Windows.Forms.ComboBox cmbxTaxpayer;
        private System.Windows.Forms.TextBox txtRepresentative;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPagePreviousAsssessments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeletePrevRpt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripComboBox cmbxPreviousRpt;
        private System.Windows.Forms.ToolStripButton btnAddPrevRpt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtStreet;
        internal System.Windows.Forms.Label label5;
    }
}