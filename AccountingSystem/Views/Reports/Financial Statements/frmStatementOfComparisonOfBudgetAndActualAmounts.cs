using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmStatementOfComparisonOfBudgetAndActualAmounts : Form
    {
        private readonly ReportViewer reportViewer;

        public frmStatementOfComparisonOfBudgetAndActualAmounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }
    }
}
