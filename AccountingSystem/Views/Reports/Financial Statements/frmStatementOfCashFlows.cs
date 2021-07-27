using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmStatementOfCashFlows : Form
    {
        private readonly ReportViewer reportViewer;

        public frmStatementOfCashFlows()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }
    }
}
