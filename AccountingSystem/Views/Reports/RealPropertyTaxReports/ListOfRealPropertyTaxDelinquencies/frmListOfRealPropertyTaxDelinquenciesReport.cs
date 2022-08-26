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

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies
{
    public partial class frmListOfRealPropertyTaxDelinquenciesReport : Form
    {
        private ReportViewer reportViewer;

        public frmListOfRealPropertyTaxDelinquenciesReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            cmbxLoadBy.SelectedIndex = 0;
            nudTaxYear.Value = Helper.GetCurrentDate().Year;
        }

        private void EnableDisableTaxPayerButton() 
        {
            if (cmbxLoadBy.Text == "Taxpayer")
                btnFindTaxPayer.Enabled = true;
            else
                btnFindTaxPayer.Enabled = false;
        }

        private void chkbxTaxYear_CheckedChanged(object sender, EventArgs e)
        {
            nudTaxYear.Enabled = chkbxTaxYear.Checked;
        }

        private void cmbxLoadBy_SelectedValueChanged(object sender, EventArgs e)
        {
            EnableDisableTaxPayerButton();

        }

        private void frmListOfRealPropertyTaxDelinquenciesReport_Load(object sender, EventArgs e)
        {
            nudTaxYear.Enabled = chkbxTaxYear.Checked;
        }
    }
}
