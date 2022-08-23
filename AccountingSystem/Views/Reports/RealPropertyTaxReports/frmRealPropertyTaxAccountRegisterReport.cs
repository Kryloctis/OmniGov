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

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports
{
    public partial class frmRealPropertyTaxAccountRegisterReport : Form
    {
        private readonly LocalReport localReport;

        public frmRealPropertyTaxAccountRegisterReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            var reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            localReport = reportViewer.LocalReport;
            reportViewer.Dock = DockStyle.Fill;
        }
    }
}
