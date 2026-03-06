using Microsoft.Reporting.WinForms;

using OmniGov.App.DataSets;

using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

using System.ComponentModel;

using System.Data;

namespace OmniGov.App.Views.Reports.RCD

{
    public partial class ucRcdReport : UserControl

    {
        private int rcdId;

        public ucRcdReport()

        {
            InitializeComponent();

            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int rcdId)

        {
            this.rcdId = rcdId;

            LoadReport();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            int rcdId = (int)e.Argument;
            var rcdModel = new RcdModel() { Id = rcdId };
            var rcdCollectionsModel = new RcdCollectionsModel() { RcdModel = rcdModel };
            var rcdDepositsModel = new RcdDepositsModel() { RcdModel = rcdModel };

            //Collections
            var dbRcdCollections = TreasuryFactory.PaymentCollectionsRepository().GetViewConsolidatedRcdRecords(rcdCollectionsModel);
            var dtRcdCollections = new dsTreasury.dtRcdCollectionsDataTable();

            //Deposits
            var dbRcdDeposits = TreasuryFactory.BankDepositsRepository().GetViewRcdRecord(rcdDepositsModel);
            var dtRcdDeposits = new dsTreasury.dtRcdDepositsDataTable();

            var dtRcdAccForms = new dsTreasury.dtRcdAccFormsDataTable();

            int totalProgressCount = (dbRcdCollections.Rows.Count * 2) + dbRcdDeposits.Rows.Count;
            int progressCount = 0;

            //Collections
            foreach (DataRow dataRow in dbRcdCollections.Rows)
            {
                var rcdCollectionsNewRow = dtRcdCollections.NewRow();
                string accForm = $"{dataRow["acc_form_no"]} - {dataRow["acc_form_desc"]}";
                decimal collectedReceiptFrom = Convert.ToInt32(dataRow["receipt_from"]);
                decimal collectedReceiptTo = Convert.ToInt32(dataRow["receipt_to"]);
                decimal totalCollection = Convert.ToDecimal(dataRow["total_amount"]);

                rcdCollectionsNewRow["acc_form"] = accForm;
                rcdCollectionsNewRow["receipt_from"] = collectedReceiptFrom;
                rcdCollectionsNewRow["receipt_to"] = collectedReceiptTo;
                rcdCollectionsNewRow["amount"] = totalCollection;

                dtRcdCollections.Rows.Add(rcdCollectionsNewRow);

                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            //Deposits
            foreach (DataRow dataRow in dbRcdDeposits.Rows)
            {
                var newRow = dtRcdDeposits.NewRow();

                newRow["acc_bank"] = $"{dataRow["account_no"]}-{dataRow["bank_name"]}";
                newRow["reference"] = dataRow["reference"];
                newRow["amount"] = dataRow["amount"];

                dtRcdDeposits.Rows.Add(newRow);
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            foreach (DataRow dataRow in dbRcdCollections.Rows)
            {
                var accFormsModel = new AccountableFormsModel() { Id = Convert.ToInt32(dataRow["acc_form_id"]) };
                var usersModel = new UsersModel() { Id = Convert.ToInt32(dataRow["created_by"]) };
                var dictRcdAccForms = TreasuryFactory.ReceiptsIssuedRepository().GetViewRcdRecord(accFormsModel, usersModel);
                string accForm = $"{dataRow["acc_form_no"]} - {dataRow["acc_form_desc"]}";
                decimal collectedReceiptFrom = Convert.ToInt32(dataRow["receipt_from"]);
                decimal collectedReceiptTo = Convert.ToInt32(dataRow["receipt_to"]);
                decimal totalCollection = Convert.ToDecimal(dataRow["total_amount"]);

                var rcdAccFormsNewRow = dtRcdAccForms.NewRow();
                rcdAccFormsNewRow["acc_form"] = accForm;
                rcdAccFormsNewRow["beg_from"] = dictRcdAccForms["receipt_issued_from"];
                rcdAccFormsNewRow["beg_to"] = dictRcdAccForms["receipt_issued_to"];
                rcdAccFormsNewRow["issued_from"] = collectedReceiptFrom;
                rcdAccFormsNewRow["issued_to"] = collectedReceiptTo;
                rcdAccFormsNewRow["end_from"] = collectedReceiptTo + 1;
                rcdAccFormsNewRow["end_to"] = dictRcdAccForms["receipt_issued_to"];

                dtRcdAccForms.Rows.Add(rcdAccFormsNewRow);
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = (dtRcdCollections, dtRcdDeposits, dtRcdAccForms);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {
            if (e.Result is not (DataTable dtRcdCollections, DataTable dtRcdDeposits, DataTable dtRcdAccForms))
            {
                progressBar1.Value = 100;
                return;
            }

            if (dtRcdCollections.Rows.Count < 1 && dtRcdDeposits.Rows.Count < 1 && dtRcdAccForms.Rows.Count < 1)
                progressBar1.Value = 100;

            var report = reportViewer1.LocalReport;
            report.ReportPath = $"{Application.StartupPath}Reports\\rcd.rdlc";
            report.DataSources.Clear();

            var dictRcd = TreasuryFactory.RcdRepository().GetViewRecord(rcdId);

            var reportParameters = new ReportParameter[]
            {
                new("paramLguName", (ServerHelper.SelectedProfile?.Name ?? "")),
                new("paramVerfSig", string.Empty),
                new("paramReportNo", dictRcd["report_no"]),
                new("paramDate", dictRcd["date"]),
                new("paramAccOfficer", Helper.GetUserDataById(Convert.ToInt32(dictRcd["created_by_id"]))["user_full_name"]),
                new("paramFund", dictRcd["fund_name"])
            };

            report.DataSources.Add(new ReportDataSource("dtRcdCollections", dtRcdCollections));
            report.DataSources.Add(new ReportDataSource("dtRcdDeposits", dtRcdDeposits));
            report.DataSources.Add(new ReportDataSource("dtRcdAccForms", dtRcdAccForms));
            report.DataSources.Add(new ReportDataSource("dtRcdAccEntries", new DataTable()));
            report.DataSources.Add(new ReportDataSource("dtRcdChecks", new DataTable()));
            report.SetParameters(reportParameters);
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }

        private void LoadReport()

        {
            if (!backgroundWorker1.IsBusy)

            {
                progressBar1.Value = 0;

                backgroundWorker1.RunWorkerAsync(rcdId);
            }
        }
    }
}