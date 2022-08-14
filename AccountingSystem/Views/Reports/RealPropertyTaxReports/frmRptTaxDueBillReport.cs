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
using static AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting.frmPropertyTaxDue;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports
{
    public partial class frmRptTaxDueBillReport : Form
    {

        private readonly List<TaxDuesModel> _taxDuesModels;

        public frmRptTaxDueBillReport(List<TaxDuesModel> taxDuesModels)
        {
            InitializeComponent();
            var reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            _taxDuesModels = taxDuesModels;
        }


        private void RptTaxDueBillDataTable() 
        {
            var dtRPTDueBill = new dsLFS.dtRPTDueBillDataTable();       

            foreach (TaxDuesModel taxDuesModel in _taxDuesModels)
            {
                var row = dtRPTDueBill.NewRow();
                row["arp_no"] = taxDuesModel.CompleteArpNo;
                row["kind"] = string.Empty;
                row["classification"] = string.Empty;
                row["lot_no"] = string.Empty;
                row["location"] = string.Empty;
                row["tax_year"] = taxDuesModel.Year;
                row["area"] = 0;
                row["assessed_value"] = taxDuesModel.AssessedValue;
                row["basic_tax"] = 0;
                row["sef_tax"] = 0;
                row["discount"] = taxDuesModel.Discount;
                row["penalty"] = taxDuesModel.Penalty;
                row["net_tax_due"] = taxDuesModel.TotalTaxDue;

                dtRPTDueBill.Rows.Add(row);
            }

        }
    }
}
