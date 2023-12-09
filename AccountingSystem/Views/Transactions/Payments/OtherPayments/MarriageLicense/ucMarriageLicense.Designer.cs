namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense
{
    partial class ucMarriageLicense
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpIssuedDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPublishedDate = new System.Windows.Forms.DateTimePicker();
            this.txtRegistrationNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSpousalInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbxHusbandBarangay = new System.Windows.Forms.ComboBox();
            this.cmbxHusbandMunicipality = new System.Windows.Forms.ComboBox();
            this.cmbxHusbandProvince = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHusbandStreet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbxWifeBarangay = new System.Windows.Forms.ComboBox();
            this.cmbxWifeMunicipality = new System.Windows.Forms.ComboBox();
            this.cmbxWifeProvince = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtWifeStreet = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudHusbandAgeMonth = new System.Windows.Forms.NumericUpDown();
            this.nudHusbandAgeYear = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHusbandName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudWifeAgeMonth = new System.Windows.Forms.NumericUpDown();
            this.nudWifeAgeYear = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWifeName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPageCharges = new System.Windows.Forms.TabPage();
            this.ucOtherCharges1 = new AccountingSystem.Views.Transactions.Payments.OtherPayments.ucPaymentFeesCharges();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageSpousalInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHusbandAgeMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHusbandAgeYear)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWifeAgeMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWifeAgeYear)).BeginInit();
            this.tabPageCharges.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDetails);
            this.tabControl1.Controls.Add(this.tabPageSpousalInfo);
            this.tabControl1.Controls.Add(this.tabPageCharges);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 476);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.panel2);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 24);
            this.tabPageDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Size = new System.Drawing.Size(591, 448);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Marriage Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpIssuedDate);
            this.panel2.Controls.Add(this.dtpPublishedDate);
            this.panel2.Controls.Add(this.txtRegistrationNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 448);
            this.panel2.TabIndex = 1;
            // 
            // dtpIssuedDate
            // 
            this.dtpIssuedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpIssuedDate.CustomFormat = "MMMM dd,  yyyy";
            this.dtpIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssuedDate.Location = new System.Drawing.Point(7, 131);
            this.dtpIssuedDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            this.dtpIssuedDate.Name = "dtpIssuedDate";
            this.dtpIssuedDate.Size = new System.Drawing.Size(564, 23);
            this.dtpIssuedDate.TabIndex = 2;
            // 
            // dtpPublishedDate
            // 
            this.dtpPublishedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPublishedDate.CustomFormat = "MMMM dd,  yyyy";
            this.dtpPublishedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPublishedDate.Location = new System.Drawing.Point(7, 80);
            this.dtpPublishedDate.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            this.dtpPublishedDate.Name = "dtpPublishedDate";
            this.dtpPublishedDate.Size = new System.Drawing.Size(564, 23);
            this.dtpPublishedDate.TabIndex = 1;
            // 
            // txtRegistrationNumber
            // 
            this.txtRegistrationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrationNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistrationNumber.Location = new System.Drawing.Point(7, 29);
            this.txtRegistrationNumber.Margin = new System.Windows.Forms.Padding(3, 3, 20, 10);
            this.txtRegistrationNumber.Name = "txtRegistrationNumber";
            this.txtRegistrationNumber.Size = new System.Drawing.Size(564, 23);
            this.txtRegistrationNumber.TabIndex = 0;
            this.txtRegistrationNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegistrationNumber_Validating);
            this.txtRegistrationNumber.Validated += new System.EventHandler(this.txtRegistrationNumber_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Issued on";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Published on";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Registration No. *";
            // 
            // tabPageSpousalInfo
            // 
            this.tabPageSpousalInfo.Controls.Add(this.tableLayoutPanel1);
            this.tabPageSpousalInfo.Location = new System.Drawing.Point(4, 24);
            this.tabPageSpousalInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSpousalInfo.Name = "tabPageSpousalInfo";
            this.tabPageSpousalInfo.Size = new System.Drawing.Size(591, 448);
            this.tabPageSpousalInfo.TabIndex = 1;
            this.tabPageSpousalInfo.Text = "Spousal Info.";
            this.tabPageSpousalInfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.51903F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.48097F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.66055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.33945F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 448);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(3, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(292, 251);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Husband\'s Address";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbxHusbandBarangay);
            this.panel4.Controls.Add(this.cmbxHusbandMunicipality);
            this.panel4.Controls.Add(this.cmbxHusbandProvince);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtHusbandStreet);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(286, 229);
            this.panel4.TabIndex = 0;
            // 
            // cmbxHusbandBarangay
            // 
            this.cmbxHusbandBarangay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxHusbandBarangay.FormattingEnabled = true;
            this.cmbxHusbandBarangay.Location = new System.Drawing.Point(12, 184);
            this.cmbxHusbandBarangay.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxHusbandBarangay.Name = "cmbxHusbandBarangay";
            this.cmbxHusbandBarangay.Size = new System.Drawing.Size(256, 23);
            this.cmbxHusbandBarangay.TabIndex = 12;
            this.cmbxHusbandBarangay.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxHusbandBarangay_Validating);
            this.cmbxHusbandBarangay.Validated += new System.EventHandler(this.cmbxHusbandBarangay_Validated);
            // 
            // cmbxHusbandMunicipality
            // 
            this.cmbxHusbandMunicipality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxHusbandMunicipality.FormattingEnabled = true;
            this.cmbxHusbandMunicipality.Location = new System.Drawing.Point(7, 133);
            this.cmbxHusbandMunicipality.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxHusbandMunicipality.Name = "cmbxHusbandMunicipality";
            this.cmbxHusbandMunicipality.Size = new System.Drawing.Size(256, 23);
            this.cmbxHusbandMunicipality.TabIndex = 11;
            this.cmbxHusbandMunicipality.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxHusbandMunicipality_Validating);
            this.cmbxHusbandMunicipality.Validated += new System.EventHandler(this.cmbxHusbandMunicipality_Validated);
            // 
            // cmbxHusbandProvince
            // 
            this.cmbxHusbandProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxHusbandProvince.FormattingEnabled = true;
            this.cmbxHusbandProvince.Location = new System.Drawing.Point(7, 82);
            this.cmbxHusbandProvince.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxHusbandProvince.Name = "cmbxHusbandProvince";
            this.cmbxHusbandProvince.Size = new System.Drawing.Size(256, 23);
            this.cmbxHusbandProvince.TabIndex = 10;
            this.cmbxHusbandProvince.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxHusbandProvince_Validating);
            this.cmbxHusbandProvince.Validated += new System.EventHandler(this.cmbxHusbandProvince_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Barangay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mun./City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Province";
            // 
            // txtHusbandStreet
            // 
            this.txtHusbandStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHusbandStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHusbandStreet.Location = new System.Drawing.Point(7, 31);
            this.txtHusbandStreet.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.txtHusbandStreet.Name = "txtHusbandStreet";
            this.txtHusbandStreet.Size = new System.Drawing.Size(256, 23);
            this.txtHusbandStreet.TabIndex = 9;
            this.txtHusbandStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtHusbandStreet_Validating);
            this.txtHusbandStreet.Validated += new System.EventHandler(this.txtHusbandStreet_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Street";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(301, 194);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 251);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wife\'s Address";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbxWifeBarangay);
            this.panel5.Controls.Add(this.cmbxWifeMunicipality);
            this.panel5.Controls.Add(this.cmbxWifeProvince);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.txtWifeStreet);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(3, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(281, 229);
            this.panel5.TabIndex = 0;
            // 
            // cmbxWifeBarangay
            // 
            this.cmbxWifeBarangay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWifeBarangay.FormattingEnabled = true;
            this.cmbxWifeBarangay.Location = new System.Drawing.Point(6, 184);
            this.cmbxWifeBarangay.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxWifeBarangay.Name = "cmbxWifeBarangay";
            this.cmbxWifeBarangay.Size = new System.Drawing.Size(257, 23);
            this.cmbxWifeBarangay.TabIndex = 16;
            this.cmbxWifeBarangay.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxWifeBarangay_Validating);
            this.cmbxWifeBarangay.Validated += new System.EventHandler(this.cmbxWifeBarangay_Validated);
            // 
            // cmbxWifeMunicipality
            // 
            this.cmbxWifeMunicipality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWifeMunicipality.FormattingEnabled = true;
            this.cmbxWifeMunicipality.Location = new System.Drawing.Point(6, 133);
            this.cmbxWifeMunicipality.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxWifeMunicipality.Name = "cmbxWifeMunicipality";
            this.cmbxWifeMunicipality.Size = new System.Drawing.Size(257, 23);
            this.cmbxWifeMunicipality.TabIndex = 15;
            this.cmbxWifeMunicipality.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxWifeMunicipality_Validating);
            this.cmbxWifeMunicipality.Validated += new System.EventHandler(this.cmbxWifeMunicipality_Validated);
            // 
            // cmbxWifeProvince
            // 
            this.cmbxWifeProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxWifeProvince.FormattingEnabled = true;
            this.cmbxWifeProvince.Location = new System.Drawing.Point(6, 82);
            this.cmbxWifeProvince.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.cmbxWifeProvince.Name = "cmbxWifeProvince";
            this.cmbxWifeProvince.Size = new System.Drawing.Size(257, 23);
            this.cmbxWifeProvince.TabIndex = 14;
            this.cmbxWifeProvince.Validating += new System.ComponentModel.CancelEventHandler(this.cmbxWifeProvince_Validating);
            this.cmbxWifeProvince.Validated += new System.EventHandler(this.cmbxWifeProvince_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Barangay";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Mun./City";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 15);
            this.label16.TabIndex = 2;
            this.label16.Text = "Province";
            // 
            // txtWifeStreet
            // 
            this.txtWifeStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWifeStreet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWifeStreet.Location = new System.Drawing.Point(6, 31);
            this.txtWifeStreet.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.txtWifeStreet.Name = "txtWifeStreet";
            this.txtWifeStreet.Size = new System.Drawing.Size(257, 23);
            this.txtWifeStreet.TabIndex = 13;
            this.txtWifeStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtWifeStreet_Validating);
            this.txtWifeStreet.Validated += new System.EventHandler(this.txtWifeStreet_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "Street";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 185);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Husband\'s Info.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudHusbandAgeMonth);
            this.panel1.Controls.Add(this.nudHusbandAgeYear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtHusbandName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 163);
            this.panel1.TabIndex = 0;
            // 
            // nudHusbandAgeMonth
            // 
            this.nudHusbandAgeMonth.Location = new System.Drawing.Point(7, 124);
            this.nudHusbandAgeMonth.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.nudHusbandAgeMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudHusbandAgeMonth.Name = "nudHusbandAgeMonth";
            this.nudHusbandAgeMonth.Size = new System.Drawing.Size(66, 23);
            this.nudHusbandAgeMonth.TabIndex = 5;
            this.nudHusbandAgeMonth.Validating += new System.ComponentModel.CancelEventHandler(this.nudHusbandAgeMonth_Validating);
            this.nudHusbandAgeMonth.Validated += new System.EventHandler(this.nudHusbandAgeMonth_Validated);
            // 
            // nudHusbandAgeYear
            // 
            this.nudHusbandAgeYear.Location = new System.Drawing.Point(7, 73);
            this.nudHusbandAgeYear.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.nudHusbandAgeYear.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudHusbandAgeYear.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudHusbandAgeYear.Name = "nudHusbandAgeYear";
            this.nudHusbandAgeYear.Size = new System.Drawing.Size(66, 23);
            this.nudHusbandAgeYear.TabIndex = 4;
            this.nudHusbandAgeYear.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudHusbandAgeYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudHusbandAgeYear_Validating);
            this.nudHusbandAgeYear.Validated += new System.EventHandler(this.nudHusbandAgeYear_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Months *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Age *";
            // 
            // txtHusbandName
            // 
            this.txtHusbandName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHusbandName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHusbandName.Location = new System.Drawing.Point(7, 22);
            this.txtHusbandName.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.txtHusbandName.Name = "txtHusbandName";
            this.txtHusbandName.Size = new System.Drawing.Size(250, 23);
            this.txtHusbandName.TabIndex = 3;
            this.txtHusbandName.Validating += new System.ComponentModel.CancelEventHandler(this.txtHusbandName_Validating);
            this.txtHusbandName.Validated += new System.EventHandler(this.txtHusbandName_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Name *";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(301, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 185);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wife\'s Info.";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nudWifeAgeMonth);
            this.panel3.Controls.Add(this.nudWifeAgeYear);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtWifeName);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 163);
            this.panel3.TabIndex = 0;
            // 
            // nudWifeAgeMonth
            // 
            this.nudWifeAgeMonth.Location = new System.Drawing.Point(6, 124);
            this.nudWifeAgeMonth.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.nudWifeAgeMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudWifeAgeMonth.Name = "nudWifeAgeMonth";
            this.nudWifeAgeMonth.Size = new System.Drawing.Size(89, 23);
            this.nudWifeAgeMonth.TabIndex = 8;
            this.nudWifeAgeMonth.Validating += new System.ComponentModel.CancelEventHandler(this.nudWifeAgeMonth_Validating);
            this.nudWifeAgeMonth.Validated += new System.EventHandler(this.nudWifeAgeMonth_Validated);
            // 
            // nudWifeAgeYear
            // 
            this.nudWifeAgeYear.Location = new System.Drawing.Point(6, 73);
            this.nudWifeAgeYear.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.nudWifeAgeYear.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudWifeAgeYear.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudWifeAgeYear.Name = "nudWifeAgeYear";
            this.nudWifeAgeYear.Size = new System.Drawing.Size(89, 23);
            this.nudWifeAgeYear.TabIndex = 7;
            this.nudWifeAgeYear.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudWifeAgeYear.Validating += new System.ComponentModel.CancelEventHandler(this.nudWifeAgeYear_Validating);
            this.nudWifeAgeYear.Validated += new System.EventHandler(this.nudWifeAgeYear_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Months *";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Age *";
            // 
            // txtWifeName
            // 
            this.txtWifeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWifeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWifeName.Location = new System.Drawing.Point(6, 19);
            this.txtWifeName.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.txtWifeName.Name = "txtWifeName";
            this.txtWifeName.Size = new System.Drawing.Size(251, 23);
            this.txtWifeName.TabIndex = 6;
            this.txtWifeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtWifeName_Validating);
            this.txtWifeName.Validated += new System.EventHandler(this.txtWifeName_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Name *";
            // 
            // tabPageCharges
            // 
            this.tabPageCharges.Controls.Add(this.ucOtherCharges1);
            this.tabPageCharges.Location = new System.Drawing.Point(4, 24);
            this.tabPageCharges.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageCharges.Name = "tabPageCharges";
            this.tabPageCharges.Size = new System.Drawing.Size(591, 448);
            this.tabPageCharges.TabIndex = 2;
            this.tabPageCharges.Text = "Charges";
            this.tabPageCharges.UseVisualStyleBackColor = true;
            // 
            // ucOtherCharges1
            // 
            this.ucOtherCharges1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOtherCharges1.Location = new System.Drawing.Point(0, 0);
            this.ucOtherCharges1.Margin = new System.Windows.Forms.Padding(0);
            this.ucOtherCharges1.Name = "ucOtherCharges1";
            this.ucOtherCharges1.Size = new System.Drawing.Size(591, 448);
            this.ucOtherCharges1.TabIndex = 0;
            // 
            // ucMarriageLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucMarriageLicense";
            this.Size = new System.Drawing.Size(599, 476);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageSpousalInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHusbandAgeMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHusbandAgeYear)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWifeAgeMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWifeAgeYear)).EndInit();
            this.tabPageCharges.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DateTimePicker dtpIssuedDate;
        internal System.Windows.Forms.DateTimePicker dtpPublishedDate;
        internal System.Windows.Forms.TextBox txtRegistrationNumber;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.ComboBox cmbxHusbandBarangay;
        internal System.Windows.Forms.ComboBox cmbxHusbandMunicipality;
        internal System.Windows.Forms.ComboBox cmbxHusbandProvince;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtHusbandStreet;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.ComboBox cmbxWifeBarangay;
        internal System.Windows.Forms.ComboBox cmbxWifeMunicipality;
        internal System.Windows.Forms.ComboBox cmbxWifeProvince;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtWifeStreet;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.NumericUpDown nudHusbandAgeMonth;
        internal System.Windows.Forms.NumericUpDown nudHusbandAgeYear;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtHusbandName;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.NumericUpDown nudWifeAgeMonth;
        internal System.Windows.Forms.NumericUpDown nudWifeAgeYear;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtWifeName;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPageDetails;
        internal System.Windows.Forms.TabPage tabPageSpousalInfo;
        internal System.Windows.Forms.TabPage tabPageCharges;
        internal ucPaymentFeesCharges ucOtherCharges1;
    }
}
