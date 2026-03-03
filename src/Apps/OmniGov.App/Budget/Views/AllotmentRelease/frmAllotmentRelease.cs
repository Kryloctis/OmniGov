using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Budget.Views.AllotmentRelease
{
    public partial class frmAllotmentRelease : Form
    {
        public frmAllotmentRelease()
        {
            InitializeComponent();
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "id", "fund_name");
        }

        private void LoadAllotmentClasses()
        {
            var dtFunds = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.AllotmentClasssesCombobox(dtFunds, cmbxAlltmntClass, "allotment_code", "id");
        }

        private void PreLoadDateIssuedFields()
        {
            dtPckrFrom.Value = DateTime.Now;
            dtPckrTo.MinDate = dtPckrFrom.Value;
        }

        private void frmAllotmentRelease_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgvMain, true);
            LoadFunds();
            LoadAllotmentClasses();
            PreLoadDateIssuedFields();
        }

        private void LoadAllotmentReleaseRecords()
        {
            string searchTxt = txtSearch.Text;
            object fund = cmbxFund.SelectedValue;
            object allotmentClass = cmbxAlltmntClass.SelectedValue;
            object dateFrom = dtPckrFrom.Value;
            object dateTo = dtPckrTo.Value;

            if (!backgroundWorker1.IsBusy)
            {
                var parameters = new object[]
                {
                    searchTxt,
                    fund,
                    allotmentClass,
                };

                backgroundWorker1.RunWorkerAsync(parameters);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((string searchTxt, int fundId, int allotmentClass, DateTime dateFrom, DateTime dateTo))e.Argument;

            var dbDtSrc = BudgetFactory.AllotmentReleaseRepository().
                                    GetViewRecordsBySearch(
                                        parameters.fundId,
                                        parameters.allotmentClass,
                                        parameters.dateFrom,
                                        parameters.searchTxt
                                    );
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
    }
}