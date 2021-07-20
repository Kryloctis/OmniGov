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

namespace AccountingSystem.Views.Reports.DailyCashReport
{
    public partial class frmDailyCash : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        public frmDailyCash()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void btnretrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private DataTable DataTableCash(string fund,string date)
        {
            var dtcash = new dsLFS.dtCashreportDataTable();
            var dtdata = Factory.FundsRepository().GetRecordsPrintCashposition(date);
            if(dtdata.Rows.Count > 0)
            {
                var rows = dtdata.Select($"fund LIKE '%{fund}%'");
                decimal beginning = 0;
                decimal end = 0;
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Beginning Balance";
                    row["balance"] = item["beginning"];
                    beginning = decimal.Parse(item["beginning"].ToString());
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Collections";
                    row["collection"] = item["collection"];
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Deposits";
                    row["deposit"] = item["deposited"];
                    end = decimal.Parse(item["deposited"].ToString());
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Ending Balance";
                    row["balance"] = beginning+end;
                    dtcash.Rows.Add(row);
                }
            }
            return dtcash;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                string date = String.Format("{0:yyyy-MM-dd}", dtdate.Value);
                var lguDetails = Helper.LGUDetails();
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramDate", String.Format("{0:MMMM dd, yyyy}", dtdate.Value)),
                            new ReportParameter("paramMayor", "HON. DIONESIA B. LAGAS"),
                            new ReportParameter("paramLGUProvince", "BUUG, ZAMBONGA SIBUGAY"),
                            new ReportParameter("paramSignatory", "ENSIGN S. UBA"),
                            new ReportParameter("paramLiquidating", "FE F. HAMOY"),
                            new ReportParameter("paramMayorSign", "DIONESIA B. LAGAS"),
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\dailycashposition.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtCashreport", DataTableCash("General",date)));
                report.DataSources.Add(new ReportDataSource("dtCashreport1", DataTableCash("Special", date)));
                report.DataSources.Add(new ReportDataSource("dtCashreport2", DataTableCash("Trust", date)));
                report.SetParameters(parameters);
                report.Refresh();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }


        }
    }
}
