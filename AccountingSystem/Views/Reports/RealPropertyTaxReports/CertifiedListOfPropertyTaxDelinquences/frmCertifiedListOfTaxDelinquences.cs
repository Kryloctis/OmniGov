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

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.CertifiedListOfPropertyTaxDelinquences
{
    public partial class frmCertifiedListOfTaxDelinquences : Form
    {
        private ReportViewer reportViewer;

        public frmCertifiedListOfTaxDelinquences()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }
    }
}
