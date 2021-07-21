using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class UcBudgetDashboard : UserControl
    {
        internal string fppId;
        internal int fundId;
        internal DateTime DateAsOf;

        public UcBudgetDashboard()
        {
            InitializeComponent();
        }

        internal void LoadInformation()
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadGrandTotalAmounts();
            LoadCurrentYearAmounts();
            LoadContinuingAmounts();
            LoadDetailed();
            Cursor.Current = Cursors.Default;
        }

        #region DASHBOARD BUDGET SUMMARY
        private decimal GetAppropriations(int allotmentClassId, byte isContinuing)
        {
            try
            {
                decimal appropriations = Factory.BudgetAppropriationsRepository().GetSumBudgetAppropriations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                decimal supplementalAppropriations = Factory.SupplementalAppropriationsRepository().GetSumSupplementalAppropriations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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
                decimal allotments = Factory.AllotmentReleaseRepository().GetSumAllotments(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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
                decimal obligations = Factory.ObligationRequestRepository().GetSumObligations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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
                var dtAllotmentClassses = Factory.AllotmentClassesRepository().GetRecords();

                foreach (DataRow row in dtAllotmentClassses.Rows)
                {
                    int allotmentClassId = Convert.ToInt32(row["id"]);

                    switch (allotmentClassId)
                    {
                        case 1:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsPS.Text = GetAppropriations(1, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsPS.Text = GetAllotments(1, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsPS.Text = GetSumObligations(1, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalancePS.Text = (GetAppropriations(1, 0) - GetSumObligations(1, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalancePS.Text = (GetAllotments(1, 0) - GetSumObligations(1, 0)).ToString("N2");
                            break;
                        case 2:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsMOOE.Text = GetAppropriations(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsMOOE.Text = GetAllotments(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsMOOE.Text = GetSumObligations(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceMOOE.Text = (GetAppropriations(2, 0) - GetSumObligations(2, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceMOOE.Text = (GetAllotments(2, 0) - GetSumObligations(2, 0)).ToString("N2");
                            break;
                        case 3:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsFE.Text = GetAppropriations(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsFE.Text = GetAllotments(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsFE.Text = GetSumObligations(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceFE.Text = (GetAppropriations(3, 0) - GetSumObligations(3, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceFE.Text = (GetAllotments(3, 0) - GetSumObligations(3, 0)).ToString("N2");
                            break;
                        case 4:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsCO.Text = GetAppropriations(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsCO.Text = GetAllotments(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsCO.Text = GetSumObligations(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceCO.Text = (GetAppropriations(4, 0) - GetSumObligations(4, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceCO.Text = (GetAllotments(4, 0) - GetSumObligations(4, 0)).ToString("N2");
                            break;
                    }
                }
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
                var dtAllotmentClassses = Factory.AllotmentClassesRepository().GetRecords();

                foreach (DataRow row in dtAllotmentClassses.Rows)
                {
                    int allotmentClassId = Convert.ToInt32(row["id"]);

                    switch (allotmentClassId)
                    {
                        case 1:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsPS.Text = GetAppropriations(1, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsPS.Text = GetAllotments(1, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsPS.Text = GetSumObligations(1, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalancePS.Text = (GetAppropriations(1, 1) - GetSumObligations(1, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalancePS.Text = (GetAllotments(1, 1) - GetSumObligations(1, 1)).ToString("N2");
                            break;
                        case 2:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsMOOE.Text = GetAppropriations(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsMOOE.Text = GetAllotments(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsMOOE.Text = GetSumObligations(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceMOOE.Text = (GetAppropriations(2, 1) - GetSumObligations(2, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceMOOE.Text = (GetAllotments(2, 1) - GetSumObligations(2, 1)).ToString("N2");
                            break;
                        case 3:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsFE.Text = GetAppropriations(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsFE.Text = GetAllotments(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsFE.Text = GetSumObligations(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceFE.Text = (GetAppropriations(3, 1) - GetSumObligations(3, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceFE.Text = (GetAllotments(3, 1) - GetSumObligations(3, 1)).ToString("N2");
                            break;
                        case 4:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsCO.Text = GetAppropriations(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsCO.Text = GetAllotments(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsCO.Text = GetSumObligations(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceCO.Text = (GetAppropriations(4, 1) - GetSumObligations(4, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceCO.Text = (GetAllotments(4, 1) - GetSumObligations(4, 1)).ToString("N2");
                            break;
                    }
                }
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
        #endregion


        private void UcBudgetDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dataGridView1, true);
                LoadBudgetDashboardComboboxes();
                LoadBudgetDashboardContents();
            }
        }

        #region COMBOBOXES

        //FUNDS
        internal void LoadFunds()
        {
            cmbxFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbxFunds.DisplayMember = "fund_name";
            cmbxFunds.ValueMember = "id";
        }

        //ALLOTMENT CLASSES
        private void LoadAllotmentClasses()
        {
            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecords();
            HelperLoadRecords.BudgetAppropriationsAllotmentCombobox(dtAllotmentClasses, cmbxAllotmentClasses, "allotment_code", "id");
        }


        //FPP
        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbxFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text);

            return dtFPP;
        }

        internal void LoadFPP()
        {
            try
            {
                cmbxFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<string, string>();

                fppDict.Add("all", "All");
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
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxFPP.Text))
            {
                cmbxFPP.TextChanged -= new EventHandler(CmbxFPP_TextChanged);
                LoadFPP();
                cmbxFPP.SelectedIndex = -1;
                cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
            {
                LoadFPP();
                cmbxFPP.DroppedDown = true;
            }
        }

        #endregion


        private void LoadBudgetDashboardContents()
        {
            try
            {
                fppId = cmbxFPP.SelectedValue.ToString();
                fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateAsOf = dtAsOf.Value;

                LoadInformation();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadDetailed()
        {
            string fppId = cmbxFPP.SelectedValue.ToString();
            int allotmentClassId = Convert.ToInt32(cmbxAllotmentClasses.SelectedValue);

            HelperLoadRecords.DashboardDetailedDatagridView(dataGridView1, fppId, allotmentClassId, fundId, DateAsOf);
        }

        private void LoadBudgetDashboardComboboxes()
        {
            LoadFPP();
            LoadFunds();
            LoadAllotmentClasses();
            cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);

            LoadBudgetDashboardContents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBudgetDashboardContents();
        }

        private void chkbxDetailed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxDetailed.Checked)
            {
                cmbxAllotmentClasses.Visible = true;
                tabControl1.SelectedTab = tabBudgetDetailed;
                flowLayoutPanel1.Controls.SetChildIndex(cmbxAllotmentClasses, 2);
            }
            else
            {
                cmbxAllotmentClasses.Visible = false;
                tabControl1.SelectedTab = tabBudgetSummary;
            }
        }

    }
}
