using ACC.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.BudgetDashboard.BudgetSummary
{
    public partial class ucBudgetSummary : UserControl
    {
        public ucBudgetSummary()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];

            errorArray[0] = cmbxFpp.Tag.ToString();
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadBudgetDashboardContents()
        {
            string fppId = cmbxFpp.SelectedValue.ToString();
            string subFpp = cmbSubFPP.SelectedValue.ToString();
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            var dateAsOf = dtAsOf.Value;

            LoadGrandTotalAmounts(fppId, subFpp, fundId, dateAsOf);
            LoadCurrentYearAmounts(fppId, subFpp, fundId, dateAsOf);
            LoadContinuingAmounts(fppId, subFpp, fundId, dateAsOf);
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        internal void LoadFPP()
        {
            var dtFpp = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            var dataTable = new DataTable();
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(string)),
                new DataColumn("name", typeof(string)),
            };
            dataTable.Columns.AddRange(dataColumns);

            var defaultRow = dataTable.NewRow();
            defaultRow["id"] = "all";
            defaultRow["name"] = "All";
            dataTable.Rows.Add(defaultRow);

            foreach (DataRow dataRow in dtFpp.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = dataRow["id"].ToString();
                newRow["name"] = $"{dataRow["fpp_code"]} - {dataRow["fpp_name"]}";

                dataTable.Rows.Add(newRow);
            }

            cmbxFpp.DataSource = dataTable;
            cmbxFpp.DisplayMember = "name";
            cmbxFpp.ValueMember = "id";
            cmbxFpp.DropDownHeight = 200;
        }

        internal void LoadSubFPP(string fppId)
        {
            var dataTable = new DataTable();
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(string)),
                new DataColumn("name", typeof(string)),
            };
            dataTable.Columns.AddRange(dataColumns);

            var defaultRow = dataTable.NewRow();
            defaultRow["id"] = "all";
            defaultRow["name"] = "All";
            dataTable.Rows.Add(defaultRow);

            if (int.TryParse(fppId, out int result))
            {
                var dtSubFpp = AccFactory.SubFPPRepository().GetRecordsByFppId(Convert.ToInt32(result));
                foreach (DataRow dataRow in dtSubFpp.Rows)
                {
                    var newRow = dataTable.NewRow();
                    newRow["id"] = dataRow["id"].ToString();
                    newRow["name"] = $"{dataRow["others_fpp_code"]} - {dataRow["name"]}";

                    dataTable.Rows.Add(newRow);
                }
            }

            cmbSubFPP.DataSource = dataTable;
            cmbSubFPP.DisplayMember = "name";
            cmbSubFPP.ValueMember = "id";
            cmbSubFPP.DropDownHeight = 200;
        }

        private void CmbxFpp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cmbxFpp.SelectedValue.ToString()))
                    LoadSubFPP(cmbxFpp.SelectedValue.ToString());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private decimal GetAppropriations(string fppId, string subFppId, int fundId, DateTime dateAsOf, int allotmentClassId, byte isContinuing)
        {
            decimal appropriations = AccFactory.BudgetAppropriationsRepository().GetSumBudgetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, allotmentClassId, isContinuing);

            decimal supplementalAppropriations = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_FppId_SubFPPId_DateEntry_AllotmentClassId_IsContinuing(fppId, subFppId, fundId, dateAsOf.Date, allotmentClassId, isContinuing);

            decimal totalAppropriations = appropriations + supplementalAppropriations;

            return totalAppropriations;
        }

        private decimal GetGrandTotalAppropriations(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            decimal cyAppropriations = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0);

            decimal conAppropriations = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1) +
                                        GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1);

            decimal grandTotalAppropriations = cyAppropriations + conAppropriations;
            return grandTotalAppropriations;
        }

        private decimal GetAllotments(string fppId, string subFppId, int fundId, DateTime dateAsOf, int allotmentClassId, byte isContinuing)
        {
            decimal allotments = AccFactory.AllotmentReleaseRepository().GetSumAllotments(fppId, subFppId, fundId, dateAsOf.Date, allotmentClassId, isContinuing);

            return allotments;
        }

        private decimal GetGrandTotalAllotments(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            decimal cyAllotments = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 0) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 0) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 0) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 0);

            decimal conAllotments = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 1) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 1) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 1) +
                                    GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 1);

            decimal grandTotalAllotments = cyAllotments + conAllotments;
            return grandTotalAllotments;
        }

        private decimal GetSumObligations(string fppId, string subFppId, int fundId, DateTime dateAsOf, int allotmentClassId, byte isContinuing)
        {
            decimal obligations = AccFactory.ObligationRequestRepository().GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, allotmentClassId, isContinuing);

            return obligations;
        }

        private decimal GetGrandTotalObligations(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            decimal cyObligations = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0);

            decimal conObligations = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1) +
                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1);

            decimal grandTotalObligations = cyObligations + conObligations;
            return grandTotalObligations;
        }

        private void LoadCurrentYearAmounts(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            lblCYAppropriationsPS.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0).ToString("N2");

            lblCYAllotmentsPS.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 0).ToString("N2");

            lblCYObligationsPS.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0).ToString("N2");

            lblCYAppropriationBalancePS.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0)).ToString("N2");

            lblCYAllotmentBalancePS.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 0) -
                                            GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 0)).ToString("N2");

            lblCYAppropriationsMOOE.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0).ToString("N2");

            lblCYAllotmentsMOOE.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 0).ToString("N2");

            lblCYObligationsMOOE.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0).ToString("N2");

            lblCYAppropriationBalanceMOOE.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0) -
                                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0)).ToString("N2");

            lblCYAllotmentBalanceMOOE.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 0) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 0)).ToString("N2");

            lblCYAppropriationsFE.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0).ToString("N2");

            lblCYAllotmentsFE.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 0).ToString("N2");

            lblCYObligationsFE.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0).ToString("N2");

            lblCYAppropriationBalanceFE.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0)).ToString("N2");

            lblCYAllotmentBalanceFE.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 0) -
                                            GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 0)).ToString("N2");

            lblCYAppropriationsCO.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0).ToString("N2");

            lblCYAllotmentsCO.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 0).ToString("N2");

            lblCYObligationsCO.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0).ToString("N2");

            lblCYAppropriationBalanceCO.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0)).ToString("N2");

            lblCYAllotmentBalanceCO.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 0) -
                                            GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 0)).ToString("N2");
        }

        private void LoadContinuingAmounts(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            lblCONAppropriationsPS.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1).ToString("N2");

            lblCONAllotmentsPS.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 1).ToString("N2");

            lblCONObligationsPS.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1).ToString("N2");

            lblCONAppropriationBalancePS.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1) -
                                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1)).ToString("N2");

            lblCONAllotmentBalancePS.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 1, 1) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 1, 1)).ToString("N2");

            lblCONAppropriationsMOOE.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1).ToString("N2");

            lblCONAllotmentsMOOE.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 1).ToString("N2");

            lblCONObligationsMOOE.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1).ToString("N2");

            lblCONAppropriationBalanceMOOE.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1) -
                                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1)).ToString("N2");

            lblCONAllotmentBalanceMOOE.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 2, 1) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 2, 1)).ToString("N2");

            lblCONAppropriationsFE.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1).ToString("N2");

            lblCONAllotmentsFE.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 1).ToString("N2");

            lblCONObligationsFE.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1).ToString("N2");

            lblCONAppropriationBalanceFE.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1)).ToString("N2");

            lblCONAllotmentBalanceFE.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 3, 1) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 3, 1)).ToString("N2");

            lblCONAppropriationsCO.Text = GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1).ToString("N2");

            lblCONAllotmentsCO.Text = GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 1).ToString("N2");

            lblCONObligationsCO.Text = GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1).ToString("N2");

            lbCONAppropriationBalanceCO.Text = (GetAppropriations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1) -
                                                    GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1)).ToString("N2");

            lblCONAllotmentBalanceCO.Text = (GetAllotments(fppId, subFppId, fundId, dateAsOf.Date, 4, 1) -
                                                GetSumObligations(fppId, subFppId, fundId, dateAsOf.Date, 4, 1)).ToString("N2");
        }

        private void LoadGrandTotalAmounts(string fppId, string subFppId, int fundId, DateTime dateAsOf)
        {
            lblGrandTotalAppropriations.Text = GetGrandTotalAppropriations(fppId, subFppId, fundId, dateAsOf.Date).ToString("N2");

            lblGrandTotalAllotments.Text = GetGrandTotalAllotments(fppId, subFppId, fundId, dateAsOf.Date).ToString("N2");

            lblGrandTotalObligations.Text = GetGrandTotalObligations(fppId, subFppId, fundId, dateAsOf.Date).ToString("N2");

            lblGrandTotalAppropriationBalance.Text = (GetGrandTotalAppropriations(fppId, subFppId, fundId, dateAsOf.Date) -
                                                        GetGrandTotalObligations(fppId, subFppId, fundId, dateAsOf.Date)).ToString("N2");

            lblGrandTotalAllotmentBalance.Text = (GetGrandTotalAllotments(fppId, subFppId, fundId, dateAsOf.Date) -
                                                    GetGrandTotalObligations(fppId, subFppId, fundId, dateAsOf.Date)).ToString("N2");
        }

        internal void OnLoad()
        {
            LoadFPP();
            LoadFunds();
            dtAsOf.Value = Helper.GetCurrentDate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBudgetDashboardContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}