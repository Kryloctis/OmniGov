using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Cursor.Current = Cursors.Default;
        }

        private decimal GetAppropriations(int allotmentClassId, byte isContinuing) 
        {
            try
            {
                decimal appropriations = Factory.BudgetAppropriationsRepository().GetBudgetAppropriations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

                decimal supplementalAppropriations = Factory.SupplementalAppropriationsRepository().GetSupplementalAppropriations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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
                decimal allotments = Factory.AllotmentReleaseRepository().GetAllotments(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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

        private decimal GetObligations(int allotmentClassId, byte isContinuing) 
        {
            try
            {
                decimal obligations = Factory.ObligationRequestRepository().GetObligations(fppId, fundId, DateAsOf.Date, allotmentClassId, isContinuing);

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
            decimal cyObligations= GetObligations(1, 0) + GetObligations(2, 0) + GetObligations(3, 0) + GetObligations(4, 0);
            decimal conObligations = GetObligations(1, 1) + GetObligations(2, 1) + GetObligations(3, 1) + GetObligations(4, 1);
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
                            ucBudgetCardsByAllotmentClassCY.lblObligationsPS.Text = GetObligations(1, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalancePS.Text = (GetAppropriations(1, 0) - GetObligations(1, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalancePS.Text = (GetAllotments(1, 0) - GetObligations(1, 0)).ToString("N2");
                            break;
                        case 2:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsMOOE.Text = GetAppropriations(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsMOOE.Text = GetAllotments(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsMOOE.Text = GetObligations(2, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceMOOE.Text = (GetAppropriations(2, 0) - GetObligations(2, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceMOOE.Text = (GetAllotments(2, 0) - GetObligations(2, 0)).ToString("N2");
                            break;
                        case 3:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsFE.Text = GetAppropriations(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsFE.Text = GetAllotments(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsFE.Text = GetObligations(3, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceFE.Text = (GetAppropriations(3, 0) - GetObligations(3, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceFE.Text = (GetAllotments(3, 0) - GetObligations(3, 0)).ToString("N2");
                            break;
                        case 4:
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationsCO.Text = GetAppropriations(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentsCO.Text = GetAllotments(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblObligationsCO.Text = GetObligations(4, 0).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAppropriationBalanceCO.Text = (GetAppropriations(4, 0) - GetObligations(4, 0)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCY.lblAllotmentBalanceCO.Text = (GetAllotments(4, 0) - GetObligations(4, 0)).ToString("N2");
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
                            ucBudgetCardsByAllotmentClassCON.lblObligationsPS.Text = GetObligations(1, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalancePS.Text = (GetAppropriations(1, 1) - GetObligations(1, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalancePS.Text = (GetAllotments(1, 1) - GetObligations(1, 1)).ToString("N2");
                            break;
                        case 2:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsMOOE.Text = GetAppropriations(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsMOOE.Text = GetAllotments(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsMOOE.Text = GetObligations(2, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceMOOE.Text = (GetAppropriations(2, 1) - GetObligations(2, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceMOOE.Text = (GetAllotments(2, 1) - GetObligations(2, 1)).ToString("N2");
                            break;
                        case 3:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsFE.Text = GetAppropriations(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsFE.Text = GetAllotments(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsFE.Text = GetObligations(3, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceFE.Text = (GetAppropriations(3, 1) - GetObligations(3, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceFE.Text = (GetAllotments(3, 1) - GetObligations(3, 1)).ToString("N2");
                            break;
                        case 4:
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationsCO.Text = GetAppropriations(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentsCO.Text = GetAllotments(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblObligationsCO.Text = GetObligations(4, 1).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAppropriationBalanceCO.Text = (GetAppropriations(4, 1) - GetObligations(4, 1)).ToString("N2");
                            ucBudgetCardsByAllotmentClassCON.lblAllotmentBalanceCO.Text = (GetAllotments(4, 1) - GetObligations(4, 1)).ToString("N2");
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

        private void UcBudgetDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadInformation();
            }
        }
    }
}
