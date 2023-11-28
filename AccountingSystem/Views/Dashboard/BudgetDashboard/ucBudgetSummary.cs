using ACC.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary
{
    public partial class ucBudgetSummary : UserControl
    {
        internal string fppId;
        internal string subFPPId;
        internal int fundId;
        internal DateTime DateAsOf;

        public ucBudgetSummary()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];

            errorArray[0] = cmbxFPP.Tag.ToString();
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool isValidated()
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.Tag = "No FPP selected.";
                return false;
            }
            return true;
        }

        internal void LoadInformation()
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadSummary();
            Cursor.Current = Cursors.Default;
        }

        internal void LoadBudgetDashboardContents()
        {
            try
            {
                if (!isValidated())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                fppId = cmbxFPP.SelectedValue.ToString();
                subFPPId = string.IsNullOrEmpty(cmbSubFPP.Text) ? string.Empty : cmbSubFPP.SelectedValue.ToString();
                fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateAsOf = dtAsOf.Value;

                LoadInformation();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadSummary()
        {
            LoadGrandTotalAmounts();
            LoadCurrentYearAmounts();
            LoadContinuingAmounts();
        }

        internal void LoadBudgetDashboardComboboxes()
        {
            LoadFPP(false);
            LoadSubFPP();
            LoadFunds();
            LoadBudgetDashboardContents();
        }

        #region COMBOBOXES

        internal void LoadFunds()
        {
            cmbxFunds.DataSource = AccFactory.FundsRepository().GetRecords();
            cmbxFunds.DisplayMember = "fund_name";
            cmbxFunds.ValueMember = "id";
        }

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbxFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text);

            return dtFPP;
        }

        private DataTable DataTableSubFPP()
        {
            DataTable dtSubFPP;
            int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);

            dtSubFPP = AccFactory.SubFPPRepository().GetRecordsByFPPId(fppId);

            return dtSubFPP;
        }

        internal void LoadFPP(bool isSearch)
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                cmbxFPP.SelectedValueChanged -= new EventHandler(CmbxFPP_SelectedValueChanged);
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0)
                {
                    cmbxFPP.DataSource = null;
                    cmbxFPP.DropDownHeight = 100;
                    return;
                };

                var fppDict = new Dictionary<string, string>();

                if (!isSearch) fppDict.Add("all", "All");
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    string fppId = item["id"].ToString();
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbxFPP.DataSource = new BindingSource(fppDict, null);
                cmbxFPP.DisplayMember = "value";
                cmbxFPP.ValueMember = "key";
                cmbxFPP.DropDownHeight = 400;
                cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadSubFPP()
        {
            try
            {
                cmbSubFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (cmbxFPP.DataSource == null || cmbxFPP.SelectedValue.ToString() == "all" || DataTableSubFPP().Rows.Count == 0)
                {
                    cmbSubFPP.DataSource = null;
                    cmbSubFPP.Enabled = false;
                    return;
                }

                var subFPPDict = new Dictionary<string, string>();

                subFPPDict.Add("all", "All");
                foreach (DataRow item in DataTableSubFPP().Rows)
                {
                    string subFPPId = item["id"].ToString();
                    string subFPPName = $"{item["others_fpp_code"]} - {item["name"]}";

                    subFPPDict.Add(subFPPId, subFPPName);
                }

                cmbSubFPP.DataSource = new BindingSource(subFPPDict, null);
                cmbSubFPP.Enabled = true;
                cmbSubFPP.DisplayMember = "value";
                cmbSubFPP.ValueMember = "key";
                cmbSubFPP.SelectedIndex = -1;
                cmbSubFPP.DropDownHeight = 400;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubFPP();
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP(true);
                cmbxFPP.DroppedDown = true;
            }
        }

        #endregion COMBOBOXES

        #region DASHBOARD BUDGET SUMMARY

        private decimal GetAppropriations(int allotmentClassId, byte isContinuing)
        {
            try
            {
                decimal appropriations = AccFactory.BudgetAppropriationsRepository().GetSumBudgetAppropriations(fppId, subFPPId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                decimal supplementalAppropriations = AccFactory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriationsBy_FppId_SubFPPId_DateEntry_AllotmentClassId_IsContinuing(fppId, subFPPId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                decimal totalAppropriations = appropriations + supplementalAppropriations;

                return totalAppropriations;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return 0;
        }

        private decimal GetGrandTotalAppropriations()
        {
            decimal cyAppropriations = GetAppropriations(1, 0) + GetAppropriations(2, 0) + GetAppropriations(3, 0) + GetAppropriations(4, 0);
            decimal conAppropriations = GetAppropriations(1, 1) + GetAppropriations(2, 1) + GetAppropriations(3, 1) + GetAppropriations(4, 1);
            decimal grandTotalAppropriations = cyAppropriations + conAppropriations;
            return grandTotalAppropriations;
        }

        private decimal GetAllotments(int allotmentClassId, byte isContinuing)
        {
            try
            {
                decimal allotments = AccFactory.AllotmentReleaseRepository().GetSumAllotments(fppId, subFPPId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                return allotments;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return 0;
        }

        private decimal GetGrandTotalAllotments()
        {
            decimal cyAllotments = GetAllotments(1, 0) + GetAllotments(2, 0) + GetAllotments(3, 0) + GetAllotments(4, 0);
            decimal conAllotments = GetAllotments(1, 1) + GetAllotments(2, 1) + GetAllotments(3, 1) + GetAllotments(4, 1);
            decimal grandTotalAllotments = cyAllotments + conAllotments;
            return grandTotalAllotments;
        }

        private decimal GetSumObligations(int allotmentClassId, byte isContinuing)
        {
            try
            {
                decimal obligations = AccFactory.ObligationRequestRepository().GetSumObligations(fppId, subFPPId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                return obligations;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return 0;
        }

        private decimal GetGrandTotalObligations()
        {
            decimal cyObligations = GetSumObligations(1, 0) + GetSumObligations(2, 0) + GetSumObligations(3, 0) + GetSumObligations(4, 0);
            decimal conObligations = GetSumObligations(1, 1) + GetSumObligations(2, 1) + GetSumObligations(3, 1) + GetSumObligations(4, 1);
            decimal grandTotalObligations = cyObligations + conObligations;
            return grandTotalObligations;
        }

        private void LoadCurrentYearAmounts()
        {
            try
            {
                lblCYAppropriationsPS.Text = GetAppropriations(1, 0).ToString("N2");
                lblCYAllotmentsPS.Text = GetAllotments(1, 0).ToString("N2");
                lblCYObligationsPS.Text = GetSumObligations(1, 0).ToString("N2");
                lblCYAppropriationBalancePS.Text = (GetAppropriations(1, 0) - GetSumObligations(1, 0)).ToString("N2");
                lblCYAllotmentBalancePS.Text = (GetAllotments(1, 0) - GetSumObligations(1, 0)).ToString("N2");

                lblCYAppropriationsMOOE.Text = GetAppropriations(2, 0).ToString("N2");
                lblCYAllotmentsMOOE.Text = GetAllotments(2, 0).ToString("N2");
                lblCYObligationsMOOE.Text = GetSumObligations(2, 0).ToString("N2");
                lblCYAppropriationBalanceMOOE.Text = (GetAppropriations(2, 0) - GetSumObligations(2, 0)).ToString("N2");
                lblCYAllotmentBalanceMOOE.Text = (GetAllotments(2, 0) - GetSumObligations(2, 0)).ToString("N2");

                lblCYAppropriationsFE.Text = GetAppropriations(3, 0).ToString("N2");
                lblCYAllotmentsFE.Text = GetAllotments(3, 0).ToString("N2");
                lblCYObligationsFE.Text = GetSumObligations(3, 0).ToString("N2");
                lblCYAppropriationBalanceFE.Text = (GetAppropriations(3, 0) - GetSumObligations(3, 0)).ToString("N2");
                lblCYAllotmentBalanceFE.Text = (GetAllotments(3, 0) - GetSumObligations(3, 0)).ToString("N2");

                lblCYAppropriationsCO.Text = GetAppropriations(4, 0).ToString("N2");
                lblCYAllotmentsCO.Text = GetAllotments(4, 0).ToString("N2");
                lblCYObligationsCO.Text = GetSumObligations(4, 0).ToString("N2");
                lblCYAppropriationBalanceCO.Text = (GetAppropriations(4, 0) - GetSumObligations(4, 0)).ToString("N2");
                lblCYAllotmentBalanceCO.Text = (GetAllotments(4, 0) - GetSumObligations(4, 0)).ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadContinuingAmounts()
        {
            try
            {
                lblCONAppropriationsPS.Text = GetAppropriations(1, 1).ToString("N2");
                lblCONAllotmentsPS.Text = GetAllotments(1, 1).ToString("N2");
                lblCONObligationsPS.Text = GetSumObligations(1, 1).ToString("N2");
                lblCONAppropriationBalancePS.Text = (GetAppropriations(1, 1) - GetSumObligations(1, 1)).ToString("N2");
                lblCONAllotmentBalancePS.Text = (GetAllotments(1, 1) - GetSumObligations(1, 1)).ToString("N2");

                lblCONAppropriationsMOOE.Text = GetAppropriations(2, 1).ToString("N2");
                lblCONAllotmentsMOOE.Text = GetAllotments(2, 1).ToString("N2");
                lblCONObligationsMOOE.Text = GetSumObligations(2, 1).ToString("N2");
                lblCONAppropriationBalanceMOOE.Text = (GetAppropriations(2, 1) - GetSumObligations(2, 1)).ToString("N2");
                lblCONAllotmentBalanceMOOE.Text = (GetAllotments(2, 1) - GetSumObligations(2, 1)).ToString("N2");

                lblCONAppropriationsFE.Text = GetAppropriations(3, 1).ToString("N2");
                lblCONAllotmentsFE.Text = GetAllotments(3, 1).ToString("N2");
                lblCONObligationsFE.Text = GetSumObligations(3, 1).ToString("N2");
                lblCONAppropriationBalanceFE.Text = (GetAppropriations(3, 1) - GetSumObligations(3, 1)).ToString("N2");
                lblCONAllotmentBalanceFE.Text = (GetAllotments(3, 1) - GetSumObligations(3, 1)).ToString("N2");

                lblCONAppropriationsCO.Text = GetAppropriations(4, 1).ToString("N2");
                lblCONAllotmentsCO.Text = GetAllotments(4, 1).ToString("N2");
                lblCONObligationsCO.Text = GetSumObligations(4, 1).ToString("N2");
                lbCONAppropriationBalanceCO.Text = (GetAppropriations(4, 1) - GetSumObligations(4, 1)).ToString("N2");
                lblCONAllotmentBalanceCO.Text = (GetAllotments(4, 1) - GetSumObligations(4, 1)).ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadGrandTotalAmounts()
        {
            lblGrandTotalAppropriations.Text = GetGrandTotalAppropriations().ToString("N2");
            lblGrandTotalAllotments.Text = GetGrandTotalAllotments().ToString("N2");
            lblGrandTotalObligations.Text = GetGrandTotalObligations().ToString("N2");
            lblGrandTotalAppropriationBalance.Text = (GetGrandTotalAppropriations() - GetGrandTotalObligations()).ToString("N2");
            lblGrandTotalAllotmentBalance.Text = (GetGrandTotalAllotments() - GetGrandTotalObligations()).ToString("N2");
        }

        #endregion DASHBOARD BUDGET SUMMARY

        private void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP(false);
                cmbxFPP.Text = string.Empty;
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void ucBudgetSummary_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBudgetDashboardComboboxes();
                LoadBudgetDashboardContents();
                cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBudgetDashboardContents();
        }
    }
}