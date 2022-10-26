
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
            this.components = new System.ComponentModel.Container();
            this.txtArpNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPropertyPin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbxActualUseCodes = new System.Windows.Forms.ComboBox();
            this.cmbxClassificationCodes = new System.Windows.Forms.ComboBox();
            this.cmbxActualUse = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbxBarangays = new System.Windows.Forms.ComboBox();
            this.nudArea = new System.Windows.Forms.NumericUpDown();
            this.nudGrYear = new System.Windows.Forms.NumericUpDown();
            this.nudOtherImprv = new System.Windows.Forms.NumericUpDown();
            this.nudAssessedValue = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.nudEffectivityYear = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.nudEffectivityQuarter = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbxPropertyKind = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chckTaxable = new System.Windows.Forms.CheckBox();
            this.chckCancelled = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelectTaxpayer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOtherImprv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssessedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityQuarter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtArpNo
            // 
            this.txtArpNo.Location = new System.Drawing.Point(111, 3);
            this.txtArpNo.Name = "txtArpNo";
            this.txtArpNo.Size = new System.Drawing.Size(216, 23);
            this.txtArpNo.TabIndex = 2;
            this.txtArpNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtArpNo_Validating);
            this.txtArpNo.Validated += new System.EventHandler(this.txtArpNo_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ARP No.";
            // 
            // txtPropertyPin
            // 
            this.txtPropertyPin.Location = new System.Drawing.Point(111, 32);
            this.txtPropertyPin.Name = "txtPropertyPin";
            this.txtPropertyPin.Size = new System.Drawing.Size(216, 23);
            this.txtPropertyPin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Property PIN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(356, 466);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Property Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbxActualUseCodes);
            this.panel2.Controls.Add(this.cmbxClassificationCodes);
            this.panel2.Controls.Add(this.cmbxActualUse);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.cmbxBarangays);
            this.panel2.Controls.Add(this.nudArea);
            this.panel2.Controls.Add(this.nudGrYear);
            this.panel2.Controls.Add(this.nudOtherImprv);
            this.panel2.Controls.Add(this.nudAssessedValue);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.nudEffectivityYear);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.nudEffectivityQuarter);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.cmbxPropertyKind);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtArpNo);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtLotNo);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtPropertyPin);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(4, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 442);
            this.panel2.TabIndex = 0;
            // 
            // cmbxActualUseCodes
            // 
            this.cmbxActualUseCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxActualUseCodes.FormattingEnabled = true;
            this.cmbxActualUseCodes.Location = new System.Drawing.Point(111, 406);
            this.cmbxActualUseCodes.Name = "cmbxActualUseCodes";
            this.cmbxActualUseCodes.Size = new System.Drawing.Size(216, 23);
            this.cmbxActualUseCodes.TabIndex = 1;
            // 
            // cmbxClassificationCodes
            // 
            this.cmbxClassificationCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxClassificationCodes.FormattingEnabled = true;
            this.cmbxClassificationCodes.Location = new System.Drawing.Point(111, 379);
            this.cmbxClassificationCodes.Name = "cmbxClassificationCodes";
            this.cmbxClassificationCodes.Size = new System.Drawing.Size(216, 23);
            this.cmbxClassificationCodes.TabIndex = 1;
            // 
            // cmbxActualUse
            // 
            this.cmbxActualUse.FormattingEnabled = true;
            this.cmbxActualUse.Location = new System.Drawing.Point(111, 119);
            this.cmbxActualUse.Name = "cmbxActualUse";
            this.cmbxActualUse.Size = new System.Drawing.Size(216, 23);
            this.cmbxActualUse.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(216, 23);
            this.comboBox1.TabIndex = 15;
            // 
            // cmbxBarangays
            // 
            this.cmbxBarangays.FormattingEnabled = true;
            this.cmbxBarangays.Location = new System.Drawing.Point(111, 61);
            this.cmbxBarangays.Name = "cmbxBarangays";
            this.cmbxBarangays.Size = new System.Drawing.Size(216, 23);
            this.cmbxBarangays.TabIndex = 15;
            // 
            // nudArea
            // 
            this.nudArea.DecimalPlaces = 2;
            this.nudArea.Location = new System.Drawing.Point(111, 322);
            this.nudArea.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudArea.Name = "nudArea";
            this.nudArea.Size = new System.Drawing.Size(216, 23);
            this.nudArea.TabIndex = 13;
            this.nudArea.ThousandsSeparator = true;
            this.nudArea.Validating += new System.ComponentModel.CancelEventHandler(this.nudArea_Validating);
            this.nudArea.Validated += new System.EventHandler(this.nudArea_Validated);
            // 
            // nudGrYear
            // 
            this.nudGrYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudGrYear.Location = new System.Drawing.Point(111, 264);
            this.nudGrYear.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudGrYear.Name = "nudGrYear";
            this.nudGrYear.Size = new System.Drawing.Size(216, 23);
            this.nudGrYear.TabIndex = 11;
            this.nudGrYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudGrYear_Validating);
            this.nudGrYear.Validated += new System.EventHandler(this.nudGrYear_Validated);
            // 
            // nudOtherImprv
            // 
            this.nudOtherImprv.DecimalPlaces = 2;
            this.nudOtherImprv.Location = new System.Drawing.Point(111, 293);
            this.nudOtherImprv.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudOtherImprv.Name = "nudOtherImprv";
            this.nudOtherImprv.Size = new System.Drawing.Size(216, 23);
            this.nudOtherImprv.TabIndex = 12;
            this.nudOtherImprv.ThousandsSeparator = true;
            // 
            // nudAssessedValue
            // 
            this.nudAssessedValue.DecimalPlaces = 2;
            this.nudAssessedValue.Location = new System.Drawing.Point(111, 235);
            this.nudAssessedValue.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudAssessedValue.Name = "nudAssessedValue";
            this.nudAssessedValue.Size = new System.Drawing.Size(216, 23);
            this.nudAssessedValue.TabIndex = 10;
            this.nudAssessedValue.ThousandsSeparator = true;
            this.nudAssessedValue.Validating += new System.ComponentModel.CancelEventHandler(this.nudAssessedValue_Validating);
            this.nudAssessedValue.Validated += new System.EventHandler(this.nudAssessedValue_Validated);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 409);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 15);
            this.label24.TabIndex = 1;
            this.label24.Text = "Lot No";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 354);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Lot No";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 382);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 15);
            this.label23.TabIndex = 1;
            this.label23.Text = "Area";
            // 
            // nudEffectivityYear
            // 
            this.nudEffectivityYear.Location = new System.Drawing.Point(111, 206);
            this.nudEffectivityYear.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nudEffectivityYear.Minimum = new decimal(new int[] {
            1930,
            0,
            0,
            0});
            this.nudEffectivityYear.Name = "nudEffectivityYear";
            this.nudEffectivityYear.Size = new System.Drawing.Size(216, 23);
            this.nudEffectivityYear.TabIndex = 9;
            this.nudEffectivityYear.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nudEffectivityYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudEffectivityYear_Validating);
            this.nudEffectivityYear.Validated += new System.EventHandler(this.nudEffectivityYear_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 325);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 15);
            this.label15.TabIndex = 1;
            this.label15.Text = "Area";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 267);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "GR year";
            // 
            // nudEffectivityQuarter
            // 
            this.nudEffectivityQuarter.BackColor = System.Drawing.SystemColors.Window;
            this.nudEffectivityQuarter.Location = new System.Drawing.Point(111, 177);
            this.nudEffectivityQuarter.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudEffectivityQuarter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEffectivityQuarter.Name = "nudEffectivityQuarter";
            this.nudEffectivityQuarter.ReadOnly = true;
            this.nudEffectivityQuarter.Size = new System.Drawing.Size(216, 23);
            this.nudEffectivityQuarter.TabIndex = 8;
            this.nudEffectivityQuarter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 296);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 15);
            this.label14.TabIndex = 1;
            this.label14.Text = "Other Imprv.";
            // 
            // cmbxPropertyKind
            // 
            this.cmbxPropertyKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPropertyKind.FormattingEnabled = true;
            this.cmbxPropertyKind.Location = new System.Drawing.Point(111, 148);
            this.cmbxPropertyKind.Name = "cmbxPropertyKind";
            this.cmbxPropertyKind.Size = new System.Drawing.Size(216, 23);
            this.cmbxPropertyKind.TabIndex = 7;
            this.cmbxPropertyKind.SelectedValueChanged += new System.EventHandler(this.cmbxPropertyKind_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Assessed Value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Effectivity Year";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(111, 351);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(216, 23);
            this.txtLotNo.TabIndex = 14;
            this.txtLotNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLotNo_Validating);
            this.txtLotNo.Validated += new System.EventHandler(this.txtLotNo_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "Effectivity Quarter";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Property Kind";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Actual Use";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Classification";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Barangay";
            // 
            // chckTaxable
            // 
            this.chckTaxable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chckTaxable.AutoSize = true;
            this.chckTaxable.Location = new System.Drawing.Point(500, -67);
            this.chckTaxable.Name = "chckTaxable";
            this.chckTaxable.Size = new System.Drawing.Size(65, 19);
            this.chckTaxable.TabIndex = 1;
            this.chckTaxable.Text = "Taxable";
            this.chckTaxable.UseVisualStyleBackColor = true;
            // 
            // chckCancelled
            // 
            this.chckCancelled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chckCancelled.AutoSize = true;
            this.chckCancelled.Location = new System.Drawing.Point(582, -67);
            this.chckCancelled.Name = "chckCancelled";
            this.chckCancelled.Size = new System.Drawing.Size(78, 19);
            this.chckCancelled.TabIndex = 4;
            this.chckCancelled.Text = "Cancelled";
            this.chckCancelled.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSelectTaxpayer
            // 
            this.btnSelectTaxpayer.BackgroundImage = global::AccountingSystem.Properties.Resources.others;
            this.btnSelectTaxpayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectTaxpayer.Location = new System.Drawing.Point(292, 2);
            this.btnSelectTaxpayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectTaxpayer.Name = "btnSelectTaxpayer";
            this.btnSelectTaxpayer.Size = new System.Drawing.Size(25, 24);
            this.btnSelectTaxpayer.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnSelectTaxpayer, "Select taxpayer");
            this.btnSelectTaxpayer.UseVisualStyleBackColor = true;
            this.btnSelectTaxpayer.Click += new System.EventHandler(this.btnSelectTaxpayer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectTaxpayer);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(4, 20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(332, 203);
            this.panel1.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 148);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 15);
            this.label22.TabIndex = 9;
            this.label22.Text = "Address";
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(101, 144);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(216, 49);
            this.textBox5.TabIndex = 22;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Location = new System.Drawing.Point(101, 115);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(216, 23);
            this.textBox4.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Contact";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(101, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(216, 23);
            this.textBox3.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "TIN";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(101, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(216, 23);
            this.textBox1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(101, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(216, 23);
            this.textBox2.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Taxpayer";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(363, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(340, 227);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Taxpayer Details";
            // 
            // ucRealProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.chckCancelled);
            this.Controls.Add(this.chckTaxable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucRealProperties";
            this.Size = new System.Drawing.Size(722, 475);
            this.Load += new System.EventHandler(this.ucRealProperties_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGrYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOtherImprv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAssessedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEffectivityQuarter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtArpNo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPropertyPin;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Panel panel2;
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
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbxClassificationCodes;
        private System.Windows.Forms.ComboBox cmbxActualUseCodes;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectTaxpayer;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label label4;
    }
}
