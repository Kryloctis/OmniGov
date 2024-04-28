using ACC.Data;
using ACC.Domain.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void OnLoad()
        {
            LoadBanks();
            LoadBankAccounts();
        }

        private void frmRCIReport_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            var dtBank = AccFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dtBank, cmbBank, "id", "bank_name");
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
            int bankID = Convert.ToInt32(cmbBankAccounts.SelectedValue);
            var dateYearMonth = Convert.ToDateTime(dtpPeriodCover.Value).ToString("MM/yyyy");

            var dtRCI = new dsLFS.dtRCINewDataTable();
            var dtCheckIssuance = AccFactory.RCIRepository().GetViewRecordsByBankAccountIdAndMonth(bankID, dateYearMonth);

            if (dtCheckIssuance.Rows.Count == 0)
                return dtRCI;

            decimal netAmount = 0.0m;

            foreach (DataRow item in dtCheckIssuance.Rows)
            {
                DataRow row = dtRCI.NewRow();
                netAmount = Convert.ToDecimal(item["amount"]) - Convert.ToDecimal(item["total_deductions"]);

                row["cheque_date"] = item["cheque_date"];
                row["cheque_no"] = item["cheque_no"];
                row["dv_no"] = item["dv_no"];
                row["res_ctr"] = string.Empty;
                row["payee"] = item["payee"];
                row["nature_of_payment"] = item["nature_of_payment"];
                row["office_code"] = item["fpp_code"];
                row["obr_number"] = item["obligation_no"];

                if (Convert.ToDateTime(item["date_entry"]).Year < dtpPeriodCover.Value.Year)
                {
                    row["trust_liabilities"] = Convert.ToDecimal(item["amount"]);
                }
                else
                {
                    switch (item["fund_code"].ToString())
                    {
                        case "100":
                            row["fpp_100"] = netAmount;
                            break;

                        case "200":
                            row["fpp_200"] = netAmount;
                            break;

                        case "300":
                            row["fpp_300"] = netAmount;
                            break;
                    }
                }

                row["bir_vat_and_nonvat"] = Convert.ToDecimal(item["total_deductions"]);
                row["gross_amount"] = Convert.ToDecimal(item["amount"]);
                dtRCI.Rows.Add(row);
            }

            return dtRCI;
        }

        private void LoadReport(LocalReport report)
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
            var parameters = new[]
            {
                new ReportParameter("paramFund", fundName),
                new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                new ReportParameter("paramBankaccount", bankDetails),
                new ReportParameter("paramMonth", dtpPeriodCover.Value.ToString()),
                new ReportParameter("paramDepartmentHeadSignatory", departmentHeadSignatory),
                new ReportParameter("paramDepartmentHeadSignatoryTitle", departmentHeadSignatoryTitle),
                new ReportParameter("paramAdministrativeOfficerSignatory", administrativeOfficerSignatory),
                new ReportParameter("paramAdministrativeOfficerSignatoryTitle", administrativeOfficerSignatoryTitle)
            };

            report.ReportPath = $"{Application.StartupPath}Reports\\check-issued.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtRCINew", DataTableRCI()));
            report.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();

            Cursor = Cursors.Default;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer.LocalReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbBanks_Validating(object sender, CancelEventArgs e)
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