using Microsoft.Reporting.WinForms;
using SpreadsheetLight;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.GeneralCollection
{
    public partial class frmAbstractOfGeneralCollection : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();

        public frmAbstractOfGeneralCollection()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmPCReport_Load(object sender, EventArgs e)
        {
           
        }

        private DataTable DataTablePC()
        {
            var dateYearMonth = String.Format("{0:MMMM}-{0:yyyy}", Convert.ToDateTime(dtpMonth.Value));
            var dtPC = new dsLFS.dtPCDataTable();
            var dt = Factory.PaymentCollectionRepository().GetRecordByLedger(dateYearMonth);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdno"] = item["rcdno"];
                    row["account_code"] = item["account_code"];
                    row["subsidiary"] = item["subsidiary"];
                    row["payee"] = item["payee"];
                    row["acc_form_desc"] = item["accform"];
                    row["ledger_name"] = item["ledger_name"];
                    row["payment_date"] = item["payment_date"];
                    row["receipt_no"] = item["receipt_no"];
                    row["amount"] = item["amount"];
                    row["collector"] = item["collector"];                    
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableGC(string from,string to)
        {
            
            var dtPC = new dsLFS.dtPCDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByGC(from,to);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["rcdno"] = item["rcd_no"];
                    row["reportno"] = item["report_no"];
                    row["account_code"] = item["account_code"];
                    row["subsidiary"] = item["subsidiary"];
                    row["payee"] = item["payee"];
                    row["acc_form_desc"] = item["accform"];
                    row["ledger_name"] = item["ledger_name"];
                    row["payment_date"] = item["payment_date"];
                    row["receipt_no"] = item["receipt_no"];
                    row["amount"] = item["amount"];
                    row["collector"] = item["collector"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }


        private void LoadReport(LocalReport report)
        {
            try
            {
                string from = String.Format("{0:yyyy-MM-dd}", dtpMonth.Value);
                string to = String.Format("{0:yyyy-MM-dd}", dtto.Value);
                var lguDetails = Helper.LGUDetails();
                var signatory = "ENSIGN S. UBA";
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramSignatory", signatory)
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\payment-collection2.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtPC", DataTableGC(from,to)));
                report.SetParameters(parameters);
                report.Refresh();


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

           
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

   
    }
}
