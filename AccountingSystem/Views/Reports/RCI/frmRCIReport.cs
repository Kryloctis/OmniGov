using ACC.Domain.Interfaces;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCI
{
    public partial class frmRCIReport : Form
    {
        private readonly ReportViewer reportViewer;
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
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = errorProvider1.GetError(cmbBanks);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void LoadBanks()
        {
            cmbBanks.DataSource = Factory.BanksRepository().GetRecords();
            cmbBanks.ValueMember = "id";
            cmbBanks.DisplayMember = "account_no";
        }

        private DataTable DataTableRCI()
        {
            int bankId = (int)cmbBanks.SelectedValue;
            var dateYearMonth = Convert.ToDateTime(dtpMonth.Value).ToString("MM/yyyy");


            var dtRCI = new dsLFS.dtRCIDataTable();
            var dt = Factory.RCIRepository().GetRecordsByAccountId(bankId, dateYearMonth);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {

                    DataRow row = dtRCI.NewRow();
                    row["account_no"] = item["account_no"];
                    row["bank_name"] = item["bank_name"];
                    row["check_no"] = item["check_no"];
                    row["check_date"] = item["check_date"];
                    row["fund_code"] = "100";
                    row["payee"] = item["payee"];
                    row["nature_of_payment"] = item["nature_of_payment"];
                    row["dv_no"] = item["dv_no"];
                    row["obligation_no"] = item["obligation_no"];
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
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                var lguDetails = Helper.LGUDetails();
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var bankrepo = Factory.BanksRepository();
                var bankdata = bankrepo.GetRecordByID((int)cmbBanks.SelectedValue);
                var bankDetails = String.Format("{0} - {1}", bankdata["bank_name"], bankdata["account_no"]);
                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramBankaccount", bankDetails),
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramMunicipalTreasurerSignatory", signatory),
                    new ReportParameter("paramAdministrativeOfficerSignatory", string.Empty)
                };

                report.ReportPath = $"{Application.StartupPath}Reports\\check-issued.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtRCI", DataTableRCI()));
                report.SetParameters(parameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

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
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbBanks, "Bank");
        }

        private void cmbBanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbBanks);
        }
    }
}
