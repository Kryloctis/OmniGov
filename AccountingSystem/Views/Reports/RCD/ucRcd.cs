using ACC.Data;
using ACC.Domain.Models;
using Microsoft.Win32;
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
            checkBox1.Checked = false;
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
            LoadCollections();
            LoadDeposits();
            if (isEdit) LoadSelectedRecord(rcdId.Value); else ResetForm();
            errorProvider1.Clear();
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

        private DataTable RcdCollectionsDataTable(bool isEdit)
        {
            if (isEdit)
            {
                var rcdModel = new RcdModel() { Id = rcdId.Value };
                var rcdCollectionsModel = new RcdCollectionsModel() { RcdModel = rcdModel };
                return AccFactory.PaymentCollectionsRepository().GetViewConsolidatedRcdRecords(rcdCollectionsModel);
            }
            else
            {
                var date = dtDate.Value;
                var userModel = new UsersModel() { Id = Helper.userId };
                return AccFactory.PaymentCollectionsRepository().GetViewConsolidatedRcdRecords(date, userModel);
            }
        }

        private void LoadCollections()
        {
            var dataTable = new DataTable();
            var dataColumns = new List<DataColumn>
            {
                new DataColumn ("acc_form_id", typeof(int)),
                new DataColumn ("acc_form",typeof(string)),
                new DataColumn ("receipt_no", typeof(string)),
                new DataColumn ("total_amount", typeof(decimal)),
            };

            dataTable.Columns.AddRange(dataColumns.ToArray());

            foreach (DataRow dataRow in RcdCollectionsDataTable(isEdit).Rows)
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

        private DataTable RcdDepositsDataTable(bool isEdit)
        {
            if (isEdit)
            {
                var rcdModel = new RcdModel() { Id = rcdId.Value };
                var rcdDepositsModel = new RcdDepositsModel() { RcdModel = rcdModel };
                return AccFactory.BankDepositsRepository().GetViewRcdRecord(rcdDepositsModel);
            }
            else
            {
                var date = dtDate.Value;
                var userModel = new UsersModel() { Id = Helper.userId };
                return AccFactory.BankDepositsRepository().GetViewRcdRecord(date, userModel);
            }
        }

        private void LoadDeposits()
        {
            var dataTable = new DataTable();
            var dataColumns = new List<DataColumn>()
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("account_no", typeof(int)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("reference",typeof(string)),
                new DataColumn("amount", typeof(decimal))
            };
            dataTable.Columns.AddRange(dataColumns.ToArray());

            foreach (DataRow dataRow in RcdDepositsDataTable(isEdit).Rows)
            {
                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(dataRow["id"]);
                string bankAccNo = dataRow["account_no"].ToString();
                string bankName = dataRow["bank_name"].ToString();
                string reference = dataRow["reference"].ToString();
                decimal amount = Convert.ToDecimal(dataRow["amount"]);

                newRow["id"] = id;
                newRow["account_no"] = bankAccNo;
                newRow["bank_name"] = bankName;
                newRow["reference"] = reference;
                newRow["amount"] = amount;
                dataTable.Rows.Add(newRow);
            }
            HelperLoadRecords.DgvRcdDeposits(dgvDeposits, dataTable);
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
            if (isEdit)
            {
                var rcdModel = new RcdModel() { Id = rcdId.Value };
                return AccFactory.PaymentCollectionsRepository().GetRcdCollections(rcdModel);
            }
            else
            {
                var date = dtDate.Value;
                var userModel = new UsersModel() { Id = Helper.userId };
                return AccFactory.PaymentCollectionsRepository().GetRcdCollections(date, userModel);
            }
        }

        internal List<RcdDepositsModel> RcdDepositsModels()
        {
            var rcdDepositModels = new List<RcdDepositsModel>();
            var dtRcdDeposit = (DataTable)dgvDeposits.DataSource;

            foreach (DataRow dataRow in dtRcdDeposit.Rows)
            {
                var rcdDepositModel = new RcdDepositsModel() { BankDepositsModel = new BankDepositsModel() { Id = Convert.ToInt32(dataRow["id"]) } };
                rcdDepositModels.Add(rcdDepositModel);
            }

            return rcdDepositModels;
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

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCollections();
                LoadDeposits();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}