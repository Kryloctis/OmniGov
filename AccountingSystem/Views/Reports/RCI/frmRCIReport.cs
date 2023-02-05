using ACC.Domain.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCI
{
    public partial class frmRCIReport : Form
    {
        private readonly ReportViewer reportViewer;
        private string fundName = "General Fund";

        public frmRCIReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmRCIReport_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadBankAccounts();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbBankAccounts)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbBank.DataSource = dtBank;
                cmbBank.ValueMember = "id";
                cmbBank.DisplayMember = "bank_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbBankAccounts.DataSource = dtBankAccounts;
            cmbBankAccounts.ValueMember = "id";
            cmbBankAccounts.DisplayMember = "account_no";
        }


        private DataTable DataTableRCI()
        {
            int bankId = (int)cmbBankAccounts.SelectedValue;
            var dateYearMonth = Convert.ToDateTime(dtpMonth.Value).ToString("MM/yyyy");

            var dtRCI = new dsLFS.dtRCIDataTable();
            var dt = AccFactory.RCIRepository().GetViewRecordsByBankAccountIdAndMonth(bankId, dateYearMonth);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtRCI.NewRow();
                    row["account_no"] = item["bank_account_no"];
                    row["bank_name"] = item["bank_name"];
                    row["check_no"] = item["cheque_no"];
                    row["check_date"] = item["cheque_date"];
                    row["fund_code"] = item["fund_code"];
                    row["payee"] = item["payee"];
                    row["nature_of_payment"] = item["nature_of_payment"];
                    row["dv_no"] = item["dv_no"];
                    row["obligation_no"] = item["obligation_no"];
                    row["total_deductions"] = item["total_deductions"];
                    row["amount"] = item["amount"];
                    row["fpp_code"] = item["fpp_code"];
                    dtRCI.Rows.Add(row);
                }
            }

            return dtRCI;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                var dictDepartmentHeadSignatory = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Department Head", "Report of Check Issued");
                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        signatory = signatoryName;
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                string departmentHeadSignatory = string.Empty;
                string departmentHeadSignatoryTitle = string.Empty;
                ParseSignatory(dictDepartmentHeadSignatory, ref departmentHeadSignatory, ref departmentHeadSignatoryTitle);

                var dictAdministrativeOfficer = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Administrative Officer", "Report of Check Issued");
                string administrativeOfficerSignatory = string.Empty;
                string administrativeOfficerSignatoryTitle = string.Empty;
                ParseSignatory(dictAdministrativeOfficer, ref administrativeOfficerSignatory, ref administrativeOfficerSignatoryTitle);

                var lguDetails = Helper.LGUDetails();
                int bankAccountId = Convert.ToInt32(cmbBankAccounts.SelectedValue);
                var dictBankAccount = AccFactory.BankAccountsRepository().GetViewRecordById(bankAccountId);
                var fund = fundName;

                string bankDetails = string.Format("{0} - {1}", dictBankAccount["bank_name"], dictBankAccount["account_no"]);
                var parameters = new[] {
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramBankaccount", bankDetails),
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramDepartmentHeadSignatory", departmentHeadSignatory),
                    new ReportParameter("paramDepartmentHeadSignatoryTitle", departmentHeadSignatoryTitle),
                    new ReportParameter("paramAdministrativeOfficerSignatory", administrativeOfficerSignatory),
                    new ReportParameter("paramAdministrativeOfficerSignatoryTitle", administrativeOfficerSignatoryTitle)
                };

                report.ReportPath = $"{Application.StartupPath}Reports\\check-issued.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtRCI", DataTableRCI()));
                report.SetParameters(parameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void cmbBanks_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbBankAccounts, "Bank Account");
        }

        private void cmbBanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbBankAccounts);
        }

        private void cmbBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }
    }
}