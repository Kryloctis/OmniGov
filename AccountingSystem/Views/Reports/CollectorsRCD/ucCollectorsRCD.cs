using ACC.Domain.Interfaces;
using AccountingSystem.Views.Reports.CollectorsRCD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCDCollector
{
    public partial class ucCollectorsRCD : UserControl
    {
        internal ushort reportId;
        internal byte fundId;
        internal ushort collectorId;
        internal bool isSaveFunction;

        public ucCollectorsRCD()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPayments, true);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = errorProvider.GetError(txtReport);
            errorArray[1] = errorProvider.GetError(cmbcollector);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void ucRCDCollector_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadFunds();
            LoadCollectors();

            cmbcollector.SelectedIndex = -1;

            btnadd.Enabled = false;
            btnRemove.Enabled = false;
        }

        internal void TotalCollections()
        {
            string TotalCollections;

            TotalCollections = (from DataGridViewRow row in dgPayments.Rows
                                where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

            txtTotal.Text = TotalCollections;
        }

        private void LoadCollectors()
        {
            try
            {
                cmbcollector.SelectedValueChanged -= new EventHandler(cmbcollector_SelectedValueChanged);
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();
                var dtCollectors = collectingOfficerRepository.GetRecords();

                cmbcollector.DataSource = dtCollectors;
                cmbcollector.DisplayMember = "fullname";
                cmbcollector.ValueMember = "id";
                cmbcollector.SelectedValueChanged += new EventHandler(cmbcollector_SelectedValueChanged);

                collectorId = (ushort)Convert.ToInt32(cmbcollector.SelectedValue);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void ResetForm() 
        {
            btnadd.Enabled = false;
            btnRemove.Enabled = false;
            btnclear.Enabled = false;
            
            txtTotal.Text = "0.00";

            cmbcollector.SelectedIndex = -1;
            txtReport.Text = string.Empty;
            dtdate.Value = DateTime.Now;

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

                // making general fund as default
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
            collectorId = (ushort)Convert.ToSByte(cmbcollector.SelectedValue);


            if (cmbcollector.SelectedIndex == -1) 
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
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            dgPayments.Rows.Clear();
            btnclear.Enabled = false;
        }

        private void txtReport_Validating(object sender, CancelEventArgs e)
        {
            string reportNo = txtReport.Text.Trim();

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtReport, "Report No.");

            var reportNoExist = Factory.CollectorReportRepository().ReportNumberExist(reportNo);

            if (reportNoExist)
            {
                errorProvider.SetError(txtReport, "Report number already existed.");
                e.Cancel = true;
            }
            else {
                e.Cancel = false;
            }
            
        }
        private void txtReport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtReport);
        }

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {

        }

        private void dgPayments_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRowCount = dgPayments.SelectedRows.Count;
            var rowCount = dgPayments.Rows.Count;

            btnRemove.Enabled = selectedRowCount  != 0 && selectedRowCount !> 1;
            btnclear.Enabled = rowCount > 0;

            TotalCollections();
        }
    }
}
