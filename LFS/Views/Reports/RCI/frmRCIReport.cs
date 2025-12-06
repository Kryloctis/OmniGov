using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.RCI
{
    public partial class frmRciReport : Form
    {
        private readonly ReportViewer reportViewer;
        private string fundName = "General Fund";

        public frmRciReport()
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
                errorProvider1.GetError(cmbxBankAccounts)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadBanks()
        {
            var dtBank = AccFactory.BanksRepository().GetRecords();
            HelperLoadRecords.BankComboBox(dtBank, cmbxBank, "id", "bank_name");
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbxBankAccounts.DataSource = dtBankAccounts;
            cmbxBankAccounts.ValueMember = "id";
            cmbxBankAccounts.DisplayMember = "account_no";
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                progressBar1.Value = 0;
                ToogleRunButton(false);
                int bankAccId = Convert.ToInt32(cmbxBankAccounts.SelectedValue);
                var dateYearMonth = Convert.ToDateTime(dtpPeriodCover.Value).ToString("MM/yyyy");
                var parameters = (bankAccId, dateYearMonth);
                backgroundWorker1.RunWorkerAsync(parameters);
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxBanks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxBankAccounts, "Bank Account");
        }

        private void cmbxBanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxBankAccounts);
        }

        private void cmbxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int bankAccId, string dateYearMonth))e.Argument;
                var dtRci = new dsLFS.dtRCINewDataTable().Clone();
                var dtCheckIssuance = AccFactory.RciRepository().GetViewRecordsByBankAccountIdAndMonth(parameters.bankAccId, parameters.dateYearMonth);
                int totalProgressCount = dtCheckIssuance.Rows.Count;
                int progressCount = 0;

                decimal netAmount = 0.0m;

                foreach (DataRow item in dtCheckIssuance.Rows)
                {
                    DataRow row = dtRci.NewRow();
                    netAmount = Convert.ToDecimal(item["amount"]) - Convert.ToDecimal(item["total_deductions"]);

                    row["cheque_date"] = item["cheque_date"];
                    row["cheque_no"] = item["cheque_no"];
                    row["dv_no"] = item["dv_no"];
                    row["res_ctr"] = string.Empty;
                    row["payee"] = item["payee"];
                    row["nature_of_payment"] = item["nature_of_payment"];
                    row["office_code"] = item["fpp_code"];
                    row["obr_number"] = item["obligation_no"];
                    var dateEntry = item["date_entry"];

                    if (dateEntry == DBNull.Value || Convert.ToDateTime(dateEntry).Year < dtpPeriodCover.Value.Year)
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
                    dtRci.Rows.Add(row);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                //Report Parameters
                var dictDepartmentHeadSignatory = AccFactory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Department Head", "Report of Check Issued");
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

                var dictAdministrativeOfficer = AccFactory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Administrative Officer", "Report of Check Issued");
                string administrativeOfficerSignatory = string.Empty;
                string administrativeOfficerSignatoryTitle = string.Empty;
                ParseSignatory(dictAdministrativeOfficer, ref administrativeOfficerSignatory, ref administrativeOfficerSignatoryTitle);

                var dictBankAccount = AccFactory.BankAccountsRepository().GetViewRecordById(parameters.bankAccId);
                var fund = fundName;

                string bankDetails = string.Format("{0} - {1}", dictBankAccount["bank_name"], dictBankAccount["account_no"]);

                var reportParameters = new List<ReportParameter>
                {
                    new("paramFund", fundName),
                    new("paramLGUName", ServerHelper.selectedServer.MunicipalityName),
                    new("paramBankaccount", bankDetails),
                    new("paramMonth", dtpPeriodCover.Value.ToString()),
                    new("paramDepartmentHeadSignatory", departmentHeadSignatory),
                    new("paramDepartmentHeadSignatoryTitle", departmentHeadSignatoryTitle),
                    new("paramAdministrativeOfficerSignatory", administrativeOfficerSignatory),
                    new("paramAdministrativeOfficerSignatoryTitle", administrativeOfficerSignatoryTitle)
                };

                //totalProgressCount += reportParameters.Count();

                //for (int i = 0; i < reportParameters.Count(); i++)
                //{
                //    progressCount++;
                //    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                //}

                var result = (reportParameters, dtRci);
                e.Result = result;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var localReport = reportViewer.LocalReport;
                var parameters = ((List<ReportParameter> reportParameters, DataTable dataTable))e.Result;

                localReport.ReportPath = $"{Application.StartupPath}Reports\\check-issued.rdlc";
                localReport.DataSources.Clear();

                localReport.DataSources.Add(new ReportDataSource("dtRCINew", parameters.dataTable));
                localReport.SetParameters(parameters.reportParameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}