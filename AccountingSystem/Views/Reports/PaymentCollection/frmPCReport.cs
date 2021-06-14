using Microsoft.Reporting.WinForms;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmPCReport : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        private string Ids = string.Empty;
        private string type = string.Empty;
        public frmPCReport(string name,string _type,string _Ids)
        {
            InitializeComponent();
            Text = String.Format("Reports > {0}", name);
            Ids = _Ids;
            type = _type;
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void frmPCReport_Load(object sender, EventArgs e)
        {
            if (type.Equals("GC"))
            {
                LoadReport(reportViewer.LocalReport);
                //reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            else
            {
                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            
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

        private DataTable DataTableGC(string id)
        {
            
            var dtPC = new dsLFS.dtPCDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByGC(id);
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
                    row["accforms"] = String.Format("{0} - {1}",item["acc_form_no"], item["acc_form_desc"]);
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

        private DataTable DataTableDeposits (int id)
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
                var signatory = "FELIX A. TRAPA";
                if (type.Equals("GC"))
                {
                    var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramSignatory", signatory)
                    };
                    report.ReportPath = $"{Application.StartupPath}Reports\\payment-collection2.rdlc";
                    report.DataSources.Clear();
                    report.DataSources.Add(new ReportDataSource("dtPC", DataTableGC(Ids)));
                    report.SetParameters(parameters);
                    report.Refresh();
                }
                else
                {
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

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            var lguDetails = Helper.LGUDetails();
            var dateYearMonth = String.Format("{0:MMMM}-{0:yyyy}", Convert.ToDateTime(dtpMonth.Value));
            var dt = Factory.PaymentCollectionRepository().GetRecordByExcel(dateYearMonth);
            var dtcode = Factory.GeneralLedgerAccountsRepository().GetRecordsBySearch();
            string filePath = Application.StartupPath + String.Format("report{0:yyyy-MM-ddhhmmsstt}.xlsx",DateTime.Now);
            Dictionary<string, string> record = new Dictionary<string, string>();
            Dictionary<string, string> summary = new Dictionary<string, string>();
            using (SLDocument sl = new SLDocument())
            {
                //Header
                SLStyle hstyle = new SLStyle();
                hstyle.SetWrapText(true);
                hstyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
                hstyle.Font.Bold = true;

                //Column
                SLStyle colstyle = new SLStyle();
                colstyle.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid,Color.LightGray,Color.LightGray);
                colstyle.SetWrapText(true);
                colstyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
                colstyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
                colstyle.Font.Bold = true;
                colstyle.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                colstyle.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                colstyle.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                colstyle.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);

                //Rows
                SLStyle rowstyle = new SLStyle();
                rowstyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
                rowstyle.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                rowstyle.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                rowstyle.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);
                rowstyle.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black);

                sl.SetCellValue("A1", "REPORT OF GENERAL COLLECTION");
                sl.MergeWorksheetCells("A1","F1");
                sl.SetCellStyle("A1", hstyle);                
                sl.SetCellValue("A2", String.Format("{0}: {1}", "Period Covered", dateYearMonth));
                sl.MergeWorksheetCells("A2", "F2");
                sl.SetCellStyle("A2", hstyle);
                
                sl.SetCellValue("A3", "RCD #");
                sl.MergeWorksheetCells("A3", "A6");
                sl.SetCellStyle("A3", colstyle);
                sl.SetCellStyle("A4", colstyle);
                sl.SetCellStyle("A5", colstyle);
                sl.SetCellStyle("A6", colstyle);

                sl.SetCellValue("B3", "PAYEE");
                sl.MergeWorksheetCells("B3", "B6");
                sl.SetCellStyle("B3", colstyle);
                sl.SetCellStyle("B4", colstyle);
                sl.SetCellStyle("B5", colstyle);
                sl.SetCellStyle("B6", colstyle);

                sl.SetCellValue("C3", "DATE");
                sl.MergeWorksheetCells("C3", "C6");
                sl.SetCellStyle("C3", colstyle);
                sl.SetCellStyle("C4", colstyle);
                sl.SetCellStyle("C5", colstyle);
                sl.SetCellStyle("C6", colstyle);

                sl.SetCellValue("D3", "RECEIPT NO.");
                sl.MergeWorksheetCells("D3", "D6");
                sl.SetCellStyle("D3", colstyle);
                sl.SetCellStyle("D4", colstyle);
                sl.SetCellStyle("D5", colstyle);
                sl.SetCellStyle("D6", colstyle);

                sl.SetCellValue("E3", "AMOUNT");
                sl.MergeWorksheetCells("E3", "E6");
                sl.SetCellStyle("E3", colstyle);
                sl.SetCellStyle("E4", colstyle);
                sl.SetCellStyle("E5", colstyle);
                sl.SetCellStyle("E6", colstyle);

                if (dtcode.Rows.Count > 0)
                {
                    int start = 6;
                    int m1merge = 6;
                    int moving1merge = 6;
                    int m2merge = 6;
                    int moving2merge = 6;
                    string startdata1 = string.Empty;
                    string startdata2 = string.Empty;
                    for (int i = 0; i < dtcode.Rows.Count; i++)
                    {
                        record.Add(dtcode.Rows[i]["account_code"].ToString(), start.ToString());
                        sl.SetCellStyle(3, start, colstyle);
                        sl.SetCellStyle(4, start, colstyle);
                        sl.SetCellStyle(5, start, colstyle);
                        sl.SetCellStyle(6, start, colstyle);
                        sl.SetCellValue(3, start, dtcode.Rows[i]["maj_acc_group_name"].ToString());
                        sl.SetCellValue(4, start, dtcode.Rows[i]["sub_maj_acc_group_name"].ToString());                       
                        sl.SetCellValue(5, start, dtcode.Rows[i]["ledger_name"].ToString().ToUpper());
                        sl.SetCellValue(6, start, dtcode.Rows[i]["account_code"].ToString().ToUpper());
                        if (!startdata1.Equals(dtcode.Rows[i]["maj_acc_group_name"].ToString()) || (dtcode.Rows.Count - 1).Equals(i))
                        {
                            if ((dtcode.Rows.Count - 1).Equals(i))
                            {                                
                                if (sl.MergeWorksheetCells(3, m1merge, 3, moving1merge))
                                    startdata1 = dtcode.Rows[i]["maj_acc_group_name"].ToString();
                                m1merge = moving1merge;
                            }
                            else
                            {
                                if (sl.MergeWorksheetCells(3, m1merge, 3, moving1merge - 1))
                                    startdata1 = dtcode.Rows[i]["maj_acc_group_name"].ToString();
                                m1merge = moving1merge;
                            }

                           
                        }
                        if (!startdata2.Equals(dtcode.Rows[i]["sub_maj_acc_group_name"].ToString()) || (dtcode.Rows.Count - 1).Equals(i))
                        {
                            if ((dtcode.Rows.Count - 1).Equals(i))
                            {
                 
                                if (sl.MergeWorksheetCells(4, m2merge, 4, moving2merge))
                                    startdata2 = dtcode.Rows[i]["sub_maj_acc_group_name"].ToString();
                                m2merge = moving2merge;
                            }
                            else
                            {
                                if (sl.MergeWorksheetCells(4, m2merge, 4, moving2merge - 1))
                                    startdata2 = dtcode.Rows[i]["sub_maj_acc_group_name"].ToString();
                                m2merge = moving2merge;
                            }
                          
                        }
                        
                        startdata1 = dtcode.Rows[i]["maj_acc_group_name"].ToString();
                        startdata2 = dtcode.Rows[i]["sub_maj_acc_group_name"].ToString();
                        //sl.AutoFitColumn(start);
                        start++;
                        moving1merge++;
                        moving2merge++;
                       
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    int start = 7;
                    for (int i=0; i < dt.Rows.Count; i++)
                    {
                        sl.SetCellStyle(String.Format("A{0}", start), rowstyle);
                        sl.SetCellValue(String.Format("A{0}", start), dt.Rows[i]["rcdno"].ToString());
                        sl.SetCellStyle(String.Format("B{0}", start), rowstyle);
                        sl.SetCellValue(String.Format("B{0}", start), dt.Rows[i]["payee"].ToString());
                        sl.SetCellStyle(String.Format("C{0}", start), rowstyle);
                        sl.SetCellValue(String.Format("C{0}", start), dt.Rows[i]["payment_date"].ToString());
                        sl.SetCellStyle(String.Format("D{0}", start), rowstyle);
                        sl.SetCellValue(String.Format("D{0}", start), dt.Rows[i]["receipt_no"].ToString());
                        sl.SetCellStyle(String.Format("E{0}", start), rowstyle);
                        sl.SetCellValueNumeric(String.Format("E{0}", start), dt.Rows[i]["amount"].ToString());
                        if (record.TryGetValue(dt.Rows[i]["account_code"].ToString(),out string value))
                        {
                            sl.SetCellValueNumeric(start, Convert.ToInt32(value), dt.Rows[i]["amount"].ToString());
                            if (summary.ContainsKey(value))
                            {

                                decimal total = Convert.ToDecimal(summary[value]);
                                summary[value] = (total + Convert.ToDecimal(dt.Rows[i]["amount"])).ToString();
                            }
                            else
                            {
                                summary.Add(value, dt.Rows[i]["amount"].ToString());
                            }
                        }
                        decimal sum =+ sl.GetCellValueAsDecimal(String.Format("E{0}", start));
                        for (int j = 0; j < dtcode.Rows.Count + 6; j++)
                        {
                            sl.SetCellStyle(start, j, rowstyle);
                            if (start.Equals(dt.Rows.Count + 6))
                            {
                                sl.SetCellStyle(String.Format("D{0}", start + 1), colstyle);
                                sl.SetCellValue(String.Format("D{0}", start + 1), "TOTAL");
                                sl.SetCellValue(String.Format("E{0}", start + 1), sum.ToString());
                                if (summary.ContainsKey(j.ToString()))
                                {
                                    sl.SetCellValueNumeric(start + 1, j < 6 ? 6 : j, summary[j.ToString()]);
                                }                                    
                                sl.SetCellStyle(start + 1, j, rowstyle);
                            }
                        }

                        sl.AutoFitRow(start);
                        start++;
                    }
                   


                }
                saveFileDialog.InitialDirectory = @"C:\";      
                saveFileDialog.Title = "Report of General Collection";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = String.Format("report{0:yyyy-MM-ddhhmmsstt}.xlsx", DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sl.SaveAs(saveFileDialog.FileName);
                }
            }
        }
    }
}
