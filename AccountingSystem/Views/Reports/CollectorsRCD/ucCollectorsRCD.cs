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
            var errorArray = new string[2];
            errorArray[0] = epReportNo.GetError(txtReport);
            errorArray[1] = epReportNo.GetError(cmbCollector);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void ucRCDCollector_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadFunds();
            LoadCollectors();

            cmbCollector.SelectedIndex = -1;

            btnadd.Enabled = false;
            btnRemove.Enabled = false;
            btnClear.Enabled = false;
        }
        internal void ResetForm()
        {
            btnadd.Enabled = false;
            btnRemove.Enabled = false;
            btnClear.Enabled = false;

            txtTotal.Text = "0.00";

            cmbCollector.SelectedIndex = -1;
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
            ActionPerformIsSave(true);
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
                btnadd.Enabled = false;
            else
                btnadd.Enabled = true;

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

        private void txtReport_Validating(object sender, CancelEventArgs e)
        {

            string reportNo = txtReport.Text.Trim();

            if (String.IsNullOrEmpty(reportNo))
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReportNo, txtReport, "Report No.");
                return;
            }
          
            var reportNoExist = Factory.CollectorReportRepository().ReportNumberExist(reportNo);

            if (reportNoExist)
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

        private void dgPayments_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRowCount = dgPayments.SelectedRows.Count;
            var rowCount = dgPayments.Rows.Count;

            btnRemove.Enabled = selectedRowCount != 0;
            btnClear.Enabled = rowCount > 0;

            TotalCollections();
        }
    }
}
