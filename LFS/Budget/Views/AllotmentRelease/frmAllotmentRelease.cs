using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace LFS.Budget.Views.AllotmentRelease
{
    public partial class frmAllotmentRelease : Form
    {
        public frmAllotmentRelease()
        {
            InitializeComponent();
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "id", "fund_name");
        }

        private void LoadAllotmentClasses()
        {
            var dtFunds = AccFactory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.AllotmentClasssesCombobox(dtFunds, cmbxAlltmntClass, "allotment_code", "id");
        }

        private void PreLoadDateIssuedFields()
        {
            dtPckrFrom.Value = DateTime.Now;
            dtPckrTo.MinDate = dtPckrFrom.Value;
        }

        private void frmAllotmentRelease_Load(object sender, EventArgs e)
        {
            try
            {
                Helper.DatagridFullRowSelectStyle(dgvMain, true);
                LoadFunds();
                LoadAllotmentClasses();
                PreLoadDateIssuedFields();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            try
            {
                var parameters = ((string searchTxt, int fundId, int allotmentClass, DateTime dateFrom, DateTime dateTo))e.Argument;

                var dbDtSrc = AccFactory.AllotmentReleaseRepository().
                                        GetViewRecordsBySearch(
                                            parameters.fundId,
                                            parameters.allotmentClass,
                                            parameters.dateFrom,
                                            parameters.searchTxt
                                        );
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}