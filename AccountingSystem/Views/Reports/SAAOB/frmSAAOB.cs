using ACC.Domain.Interfaces;
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

namespace AccountingSystem.Views.Reports.SAAOB
{
    public partial class frmSAAOB : Form
    {

        private readonly ReportViewer reportViewer;

        public frmSAAOB()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel2.Controls.Add(reportViewer);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epFPP.GetError(cmbxFPP);
            errorArray[1] = epYear.GetError(nudYear);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private bool LoadReport(LocalReport report) 
        {
            try
            {
                if (!ValidateChildren()) 
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }


                int fppID = Convert.ToInt32(cmbxFPP.SelectedValue);
                short year = Convert.ToInt16(nudYear.Value);

                var dtSAAOB = Factory.BudgetAppropriationsRepository().GetViewRecordsSAAOB(fppID, year);

                reportViewer.SetDisplayMode(DisplayMode.Normal);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                var parameters = new[] {
                    new ReportParameter("paramYear", nudYear.Value.ToString()),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\status-of-appropriations-allotments-and-obligation.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOB", dtSAAOB));
                report.SetParameters(parameters);

                reportViewer.RefreshReport();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void frmSAAOB_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            HelperLoadRecords.FPPComboBox(Factory.FunctionProgramProjectRepository().GetRecords(), cmbxFPP, "fpp_name", "id");
            nudYear.Value = DateTime.Now.Year; 
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        #region Validations

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text.Trim()))
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epFPP, cmbxFPP, "FPP");
            }
            else if (!Factory.FunctionProgramProjectRepository().NameExist(cmbxFPP.Text.Trim()))
            {
                epFPP.SetError(cmbxFPP, "FPP Name doesn't exist.");
                e.Cancel = true;
            }
        }
        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbxFPP);
        }

        private void nudYear_Validating(object sender, CancelEventArgs e)
        {
             e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epYear, nudYear, "YEAR");
        }
        private void nudYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epYear, nudYear);
        }

        #endregion Validations


    }
}
