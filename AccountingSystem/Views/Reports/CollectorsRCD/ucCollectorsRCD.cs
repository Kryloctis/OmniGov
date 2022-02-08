using ACC.Domain.Interfaces;
using AccountingSystem.Views.Reports.CollectorsRCD;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCDCollector
{
    public partial class ucCollectorsRCD : UserControl
    {
        internal ushort reportId;
        internal byte fundId;
        internal ushort collectorId;
        internal bool isSaveFunction = true;

        public ucCollectorsRCD()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPayments, true);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epReportNo.GetError(txtReport);
            errorArray[1] = epCollector.GetError(cmbCollector);
            errorArray[2] = epPayments.GetError(dgPayments);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void ucRCDCollector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadCollectors();
                LoadCurrentCollector();
            }
        }
        private void LoadCurrentCollector()
        {
            try
            {
                if (cmbCollector.Items.Count > 0)
                {
                    var uRepository = Factory.UsersRepository();
                    if (uRepository.LinkedCollector(Helper.UserId))
                    {
                        var colRepository = Factory.CollectingOfficerRepository();
                        var data = colRepository.GetRecordByUserID(Helper.UserId);
                        cmbCollector.SelectedValue = data["id"];
                        cmbCollector.Enabled = false;
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        cmbCollector.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void ResetForm()
        {
            btnClear.Enabled = false;

            txtTotal.Text = "0.00";

            txtReport.Text = string.Empty;
            dtRCDDate.Value = DateTime.Now;

            dgPayments.Rows.Clear();
            dgPayments.Refresh();
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                }


                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += (s, e) => {
                    var radFund = s as RadioButton;
                    fundId = Convert.ToByte(radFund.Tag);
                };
                radFund.CheckedChanged += (s, e) => {
                    var radFund = s as RadioButton;
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                };
            }
        }

        private void LoadCollectors()
        {
            try
            {
                cmbCollector.SelectedValueChanged -= new EventHandler(cmbcollector_SelectedValueChanged);
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();
                var dtCollectors = collectingOfficerRepository.GetRecords();

                cmbCollector.DataSource = dtCollectors;
                cmbCollector.DisplayMember = "fullname";
                cmbCollector.ValueMember = "id";
                cmbCollector.SelectedValueChanged += new EventHandler(cmbcollector_SelectedValueChanged);

                cmbCollector.SelectedIndex = -1;
                collectorId = (ushort)Convert.ToInt32(cmbCollector.SelectedValue);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void TotalCollections()
        {
            string TotalCollections;

            TotalCollections = (from DataGridViewRow row in dgPayments.Rows
                                where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

            txtTotal.Text = TotalCollections;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _ = new frmCollectorsRCDLoad(fundId, collectorId, this).ShowDialog();
        }

        internal void ActionPerformIsSave(bool isSave)
        {
            isSaveFunction = isSave;
        }

        private void cmbcollector_SelectedValueChanged(object sender, EventArgs e)
        {
            collectorId = (ushort)Convert.ToSByte(cmbCollector.SelectedValue);


            if (cmbCollector.SelectedIndex == -1)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgPayments.SelectedRows)
            {
                dgPayments.Rows.RemoveAt(item.Index);
            }

            TotalCollections();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            dgPayments.Rows.Clear();
            btnClear.Enabled = false;

            TotalCollections();
        }

        private void dgPayments_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRowCount = dgPayments.SelectedRows.Count;
            var rowCount = dgPayments.Rows.Count;

            btnRemove.Enabled = selectedRowCount != 0;
            btnClear.Enabled = rowCount > 0;

            TotalCollections();
        }

        #region Validation
        private void txtReport_Validating(object sender, CancelEventArgs e)
        {
            string reportNo = txtReport.Text.Trim();
            bool reportNoExist;

            if (string.IsNullOrEmpty(reportNo))
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReportNo, txtReport, "Report No.");

            if (isSaveFunction == true)
                reportNoExist  = Factory.CollectorReportRepository().ReportNumberExist(reportNo);
            else
                reportNoExist  = Factory.CollectorReportRepository().ReportNumberExist(reportId, reportNo);

            if (reportNoExist == true)
            {
                epReportNo.SetError(txtReport, "Report number already existed.");
                e.Cancel = true;
            }
            else
            { 
                e.Cancel = false;
            }

        }

        private void txtReport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReportNo, txtReport);
        }

        private void dgPayments_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorDatagridView(epPayments, dgPayments , "Payments.");
        }

        private void dgPayments_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDatagridView(epPayments, dgPayments);
        }

        private void cmbCollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollector, cmbCollector, "Collector.");
        }

        private void cmbCollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollector, cmbCollector);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }

    #endregion


}
