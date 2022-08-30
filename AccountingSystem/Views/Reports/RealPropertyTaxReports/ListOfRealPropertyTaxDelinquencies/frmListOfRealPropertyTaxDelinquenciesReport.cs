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
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            cmbxLoadBy.SelectedIndex = 0;
            nudTaxYear.Value = Helper.GetCurrentDate().Year;
        }

        private void ShowHideButtons() 
        {
            string selectedLoadBy = cmbxLoadBy.Text.Trim();

            switch (selectedLoadBy)
            {
                case "Taxpayer":
                    btnFindTaxPayer.Visible = true;
                    cmbxBarangay.Visible = false;
                    cmbxMunicipality.Visible = false;
                    break;

                case "Municipality":
                    cmbxMunicipality.Visible = true;
                    cmbxBarangay.Visible = false;
                    btnFindTaxPayer.Visible = false;
                    break;

                case "Barangay":
                    cmbxBarangay.Visible = true;
                    btnFindTaxPayer.Visible = false;
                    cmbxMunicipality.Visible = false;
                    break;

                default:
                    btnFindTaxPayer.Visible = false;
                    cmbxBarangay.Visible = false;
                    cmbxMunicipality.Visible = false;
                    break;
            }
        }

        private void chkbxTaxYear_CheckedChanged(object sender, EventArgs e) => nudTaxYear.Enabled = chkbxTaxYear.Checked; 

        private void cmbxLoadBy_SelectedValueChanged(object sender, EventArgs e) =>  ShowHideButtons();
   
        private void frmListOfRealPropertyTaxDelinquenciesReport_Load(object sender, EventArgs e)
        {
            nudTaxYear.Enabled = chkbxTaxYear.Checked;
        }

        #region LoadReport

        private bool LoadReport() 
        {
            try
            {



                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion
    }
}
