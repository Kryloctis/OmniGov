using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmCDReport : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        private string Ids = string.Empty;
        public frmCDReport(string _ids)
        {
            InitializeComponent();
            Ids = _ids;
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmCDReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }


        private DataTable DataTableData(string id)
        {

            var dtPC = new dsLFS.dtRCDDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByData(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["rcdno"] = item["rcd_no"];
                    row["rcddate"] = item["rcd_date"];
                    row["officer"] = item["officer"];
                    row["fund"] = item["fund"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableForms(int id)
        {

            var dtPC = new dsLFS.dtRCDFormsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByForms(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["accforms"] = String.Format("{0} - {1}", item["acc_form_no"], item["acc_form_desc"]);
                    row["orfrom"] = item["orfrom"];
                    row["orto"] = item["orto"];
                    row["amount"] = item["total"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableCollections(int id)
        {

            var dtPC = new dsLFS.dtRCDCollectionsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByCollections(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["collectorname"] = item["collector"];
                    row["reportno"] = item["report_no"];
                    row["amount"] = item["total"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableDeposits(int id)
        {

            var dtPC = new dsLFS.dtRCDDepositsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByDeposits(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["bankname"] = String.Format("{0} - {1}", item["bank_name"], item["account_no"]);
                    row["reference"] = item["reference"];
                    row["amount"] = item["amount"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                var lguDetails = Helper.LGUDetails();
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"])
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\rcd.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtRCD", DataTableData(Ids)));
                report.SubreportProcessing += Report_SubreportProcessing;

                report.SetParameters(parameters);
                report.Refresh();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }
        private void Report_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            int id = int.Parse(e.Parameters["rcdid"].Values[0].ToString());
            e.DataSources.Add(new ReportDataSource("dtRCDForms", DataTableForms(id)));
            e.DataSources.Add(new ReportDataSource("dtRCDCollections", DataTableCollections(id)));
            e.DataSources.Add(new ReportDataSource("dtRCDDeposits", DataTableDeposits(id)));

        }
    }
}
