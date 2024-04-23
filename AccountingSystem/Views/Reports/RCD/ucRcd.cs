using ACC.Data;
using ACC.Domain.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class ucRcd : UserControl
    {
        private int? rcdId;
        private bool isEdit;

        public ucRcd()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgvCollections, true);
            Helper.DatagridFullRowSelectStyle(dgvDeposits, true);
        }

        internal void ResetForm()
        {
            rcdId = null;
            txtAccountableOfficer.Text = Helper.LoggedInUserData()["user_full_name"];
            dtDate.Value = Helper.GetCurrentDate();
            txtReportNo.Clear();
            LoadFunds();
        }

        private void LoadSelectedRecord(int rcdId)
        {
            var dictRcd = AccFactory.RcdRepository().GetViewRecord(rcdId);
            txtReportNo.Text = dictRcd["report_no"];
            if (string.IsNullOrWhiteSpace(dictRcd["fund_id"]))
            {
                checkBox1.Checked = false;
                cmbxFunds.SelectedIndex = -1;
            }
            else
            {
                checkBox1.Checked = true;
                cmbxFunds.SelectedValue = Convert.ToInt32(dictRcd["fund_id"]);
            }

            dtDate.Value = Convert.ToDateTime(dictRcd["date"]);
        }

        internal void OnLoad(bool isEdit, int? rcdId)
        {
            this.rcdId = rcdId;
            this.isEdit = isEdit;
            dtDate.Value = Helper.GetCurrentDate();
            txtAccountableOfficer.Text = Helper.LoggedInUserData()["user_full_name"];
            LoadFunds();
            if (isEdit) LoadSelectedRecord(rcdId.Value); else ResetForm();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtReportNo),
                errorProvider1.GetError(checkBox1),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        private void LoadCollections(DateTime dateFrom, DateTime dateTo)
        {
            var dtPaymentCollections = AccFactory.PaymentCollectionsRepository().GetViewConsolidatedRecord(dateFrom, dateTo);
            var dataTable = new DataTable();
            var dataColumns = new List<DataColumn>
            {
                new DataColumn ("acc_form_id", typeof(int)),
                new DataColumn ("acc_form",typeof(string)),
                new DataColumn ("receipt_no", typeof(string)),
                new DataColumn ("total_amount", typeof(decimal)),
            };

            dataTable.Columns.AddRange(dataColumns.ToArray());

            foreach (DataRow dataRow in dtPaymentCollections.Rows)
            {
                var newRow = dataTable.NewRow();

                int accFormId = Convert.ToInt32(dataRow["acc_form_id"]);
                string accFormNo = dataRow["acc_form_no"].ToString();
                string accFormDesc = dataRow["acc_form_desc"].ToString();
                string receiptFrom = Convert.ToInt32(dataRow["receipt_from"]).ToString("D7");
                string receipTo = Convert.ToInt32(dataRow["receipt_to"]).ToString("D7");
                decimal totalAmount = Convert.ToInt32(dataRow["total_amount"]);

                newRow["acc_form_id"] = accFormId;
                newRow["acc_form"] = $"{accFormNo}-{accFormDesc}";
                newRow["receipt_no"] = $"{receiptFrom} > {receipTo}";
                newRow["total_amount"] = totalAmount;

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.DgvRcdCollections(dgvCollections, dataTable);
        }

        private void LoadDeposits(DateTime dateFrom, DateTime dateTo)
        {

        }

        private void dtCollectionsFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtCollectionsFrom.Value;
                var dateTo = dtCollectionsTo.Value;
                LoadCollections(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtCollectionsTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtCollectionsFrom.Value;
                var dateTo = dtCollectionsTo.Value;
                LoadCollections(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtDepositsFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtDepositsFrom.Value;
                var dateTo = dtDepositsTo.Value;
                LoadDeposits(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtDepositsTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtDepositsFrom.Value;
                var dateTo = dtDepositsTo.Value;
                LoadDeposits(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRefreshCollections_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtCollectionsFrom.Value;
                var dateTo = dtCollectionsTo.Value;
                LoadCollections(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRefreshDeposits_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = dtDepositsFrom.Value;
                var dateTo = dtDepositsTo.Value;
                LoadDeposits(dateFrom, dateTo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ReportNoValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool isValidated;
            bool reportNoExist = isEdit ? AccFactory.RcdRepository().reportNoExist(textBox.Text.Trim(), rcdId.Value) : AccFactory.RcdRepository().reportNoExist(textBox.Text.Trim());

            isValidated = !Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Report No.") && !reportNoExist;
            errorProvider.SetError(textBox, reportNoExist ? "Report No. exist." : errorProvider.GetError(textBox));

            return isValidated;
        }

        private void txtReportNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ReportNoValidated(errorProvider1, txtReportNo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtReportNo_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorTextBox(errorProvider1, txtReportNo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            bool isToggled = checkBox1.Checked;
            if (isToggled)
            {
                var dtFunds = AccFactory.FundsRepository().GetRecords();
                cmbxFunds.Enabled = true;
                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
            }
            else
            {
                cmbxFunds.Enabled = false;
                cmbxFunds.SelectedIndex = -1;
            }
        }

        private bool FundValidated(ErrorProvider errorProvider, ComboBox comboBox, CheckBox checkBox)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text.Trim()) && checkBox.Checked)
            {
                errorProvider.SetError(checkBox, "Funds");
                return false;
            }
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadFunds();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !FundValidated(errorProvider1, cmbxFunds, checkBox1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxFunds);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal RcdModel RcdModel()
        {
            var model = new RcdModel()
            {
                ReportNo = txtReportNo.Text.Trim(),
                FundsModel = checkBox1.Checked ? new FundsModel() { Id = Convert.ToInt32(cmbxFunds.SelectedValue) } : null,
                CreatedBy = new UsersModel() { Id = Helper.userId },
                Date = dtDate.Value,
            };

            if (isEdit) model.Id = rcdId.Value;

            return model;
        }

        internal List<RcdCollectionsModel> RcdCollectionsModels()
        {
            var models = new List<RcdCollectionsModel>();
            return models;
        }

        internal List<RcdDepositsModel> RcdDepositsModels()
        {
            var models = new List<RcdDepositsModel>();
            return models;
        }

        internal bool Save(ref bool isEdit)
        {
            isEdit = this.isEdit;
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            return this.isEdit ? AccFactory.RcdRepository().UpdateWithCollectionsDeposits(RcdModel(), RcdCollectionsModels(), RcdDepositsModels()) : AccFactory.RcdRepository().InsertWithCollectionsDeposits(RcdModel(), RcdCollectionsModels(), RcdDepositsModels());
        }
    }
}