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
        public UcBudgetDashboard()
        {
            InitializeComponent();
        }

        private DataTable DatatableDashboard()
        {

            var dataSet = new dsLFS();
            DataTable dtSAAOBB = dataSet.dtSAAOBB;

            int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            DateTime date = dtAsOf.Value;


            //Get Current Records
            var dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords(fppId, fundId, date);

            foreach (DataRow item in dtBudgetAppropriations.Rows)
            {
                int rowBudgetAppropriationId = Convert.ToInt32(item["id"]);

                //FUND
                int rowFundId = Convert.ToInt32(item["funds_id"]);
                string rowFundCode = item["fund_code"].ToString();
                string rowFundName = item["fund_name"].ToString();

                //FUNCTION CLASSIFICATION
                int rowFunctionalClassificationId = Convert.ToInt32(item["functional_classification_id"]);
                string rowFunctionalClassificationSectorCode = item["functional_classification_sector_code"].ToString();
                string rowFunctionalClassificationSectorName = item["functional_classification_sector_name"].ToString();

                //FUNCTION CLASSIFICATION SERVICE
                int rowFunctionalClassificationServiceId = Convert.ToInt32(item["functional_classification_service_id"]);
                string rowFunctionalClassificationServiceName = item["functional_classification_service_name"].ToString();

                //FPP
                int rowFPPId = Convert.ToInt32(item["fpp_id"]);
                string rowFPPCode = item["fpp_code"].ToString();
                string rowFPPName = item["fpp_name"].ToString();
                byte rowFPPSpecial = Convert.ToByte(item["fpp_is_special"]);

                //SUB FPP
                string rowSubFPPId = item["others_fpp_id"] == null ? string.Empty : item["others_fpp_id"].ToString();
                string rowSubFPPCode = item["others_fpp_code"].ToString();
                string rowSubFPPName = item["others_fpp_name"].ToString();

                //ALLOTMENT CLASS
                int rowAllotmentClassId = Convert.ToInt32(item["allotment_class_id"]);
                string rowAllotmentClassCode = item["allotment_class_code"].ToString();
                string rowAllotmentClassName = item["allotment_class_name"].ToString();

                //ACCOUNT
                int rowAccountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                string rowAccountCode = item["account_code"].ToString();
                string rowAccountName = item["general_ledger_accounts_name"].ToString();

                short rowYear = Convert.ToInt16(item["year"]);
                string rowRemarks = item["remarks"].ToString();
                bool rowIsContinuing = Convert.ToBoolean(item["continuing"]);

                //TOTAL APPROPRIATIONS
                var dtSupplemtedAmount = Factory.SupplementalAppropriationsRepository().GetRecordsByBudgetAppropriationIdDateEntry(rowBudgetAppropriationId, date);
                decimal supplementedAmount = Convert.ToDecimal(dtSupplemtedAmount.Rows.Count == 0 ? 0 : dtSupplemtedAmount.Compute("SUM(amount)", string.Empty));

                decimal rowBudgetAppropriation = Convert.ToDecimal(item["amount"]);

                decimal TotalBudgetAppropraition = rowBudgetAppropriation + supplementedAmount;

                //ALLOTMENT RELEASE
                var dtAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewRecordsByBudgetAppropriationIdDateIssued(rowBudgetAppropriationId, date);
                decimal allotmentReleaseAmount = Convert.ToDecimal(dtAllotmentRelease.Rows.Count == 0 ? 0 : dtAllotmentRelease.Compute("SUM(amount)", string.Empty));

                //OBLIGATIONS
                var dtObligation = Factory.ObligationRequestRepository().GetViewRecords(rowBudgetAppropriationId, date);
                decimal obligationRequestAmount = Convert.ToDecimal(dtObligation.Rows.Count == 0 ? 0 : dtObligation.Compute("SUM(amount)", string.Empty));

                //BALANCES OF APPROPRIATIONS
                decimal balancesOfAppropriationsAmount = TotalBudgetAppropraition - obligationRequestAmount;

                //BALANCES OF ALLOTMENTS
                decimal balancesOfAllotments = allotmentReleaseAmount - obligationRequestAmount;


                var items = new object[]
                {
                    rowFundId,
                    rowFundCode,
                    rowFundName,
                    rowFunctionalClassificationId,
                    rowFunctionalClassificationSectorCode,
                    rowFunctionalClassificationSectorName,
                    rowFunctionalClassificationServiceId,
                    rowFunctionalClassificationServiceName,
                    rowFPPId,
                    rowFPPCode,
                    rowFPPName,
                    rowFPPSpecial,
                    rowSubFPPId,
                    rowSubFPPCode,
                    rowSubFPPName,
                    rowAllotmentClassId,
                    rowAllotmentClassCode,
                    rowAllotmentClassName,
                    rowAccountId,
                    rowAccountCode,
                    rowAccountName,
                    rowYear,
                    rowRemarks,
                    rowIsContinuing,
                    TotalBudgetAppropraition,
                    balancesOfAppropriationsAmount,
                    allotmentReleaseAmount,
                    obligationRequestAmount,
                    balancesOfAllotments
                };

                if (rowIsContinuing == true)
                    dtSAAOBB.Rows.Add(items);
                else if (rowYear == dtAsOf.Value.Year)
                    dtSAAOBB.Rows.Add(items);
            }

            return dtSAAOBB;
        }

        private Dictionary<string, string> GetDashboardRecords() 
        {

            decimal psAppropriationsCY = 0, psAllotmentsCY = 0, psObligationsCY = 0, psAppropriationBalanceCY = 0, psAllotmentBalanceCY = 0;
            decimal mooeAppropriationsCY = 0, mooeAllotmentsCY = 0, mooeObligationsCY = 0, mooeAppropriationBalanceCY = 0, mooeAllotmentBalanceCY = 0;
            decimal coAppropriationsCY = 0, coAllotmentsCY = 0, coObligationsCY = 0, coAppropriationBalanceCY = 0, coAllotmentBalanceCY = 0;
            decimal feAppropriationsCY = 0, feAllotmentsCY = 0, feObligationsCY = 0, feAppropriationBalanceCY = 0, feAllotmentBalanceCY = 0;


            decimal psAppropriationsCON = 0, psAllotmentsCON = 0, psObligationsCON = 0, psAppropriationBalanceCON = 0, psAllotmentBalanceCON = 0;
            decimal mooeAppropriationsCON = 0, mooeAllotmentsCON = 0, mooeObligationsCON = 0, mooeAppropriationBalanceCON = 0, mooeAllotmentBalanceCON = 0;
            decimal coAppropriationsCON = 0, coAllotmentsCON = 0, coObligationsCON = 0, coAppropriationBalanceCON = 0, coAllotmentBalanceCON = 0;
            decimal feAppropriationsCON = 0, feAllotmentsCON = 0, feObligationsCON = 0, feAppropriationBalanceCON = 0, feAllotmentBalanceCON = 0;

            decimal grandTotalAppropriations = 0, grandTotalAllotments = 0, grandTotalObligations = 0, grandTotalAppropriationBalance = 0, grandTotalAllotmentBalance =0 ;


            foreach (DataRow row in DatatableDashboard().Rows) 
            {
                int allotmentClassId = Convert.ToInt32(row["allotment_class_id"]);
                bool isContinuing = Convert.ToBoolean(row["continuing"]);

                grandTotalAppropriations += (decimal)row["appropriations"];
                grandTotalAllotments += (decimal)row["allotments"];
                grandTotalObligations += (decimal)row["obligations"];
                grandTotalAppropriationBalance += (decimal)row["appropriatons_balance"];
                grandTotalAllotmentBalance += (decimal)row["allotment_release_balance"];

                switch (allotmentClassId) 
                {
                    case 1:
                        if (!isContinuing)
                        {
                            psAppropriationsCY += (decimal)row["appropriations"];
                            psAllotmentsCY += (decimal)row["allotments"];
                            psObligationsCY += (decimal)row["obligations"];
                            psAppropriationBalanceCY += (decimal)row["appropriatons_balance"];
                            psAllotmentBalanceCY += (decimal)row["allotment_release_balance"];
                        }
                        else 
                        {
                            psAppropriationsCON += (decimal)row["appropriations"];
                            psAllotmentsCON += (decimal)row["allotments"];
                            psObligationsCON += (decimal)row["obligations"];
                            psAppropriationBalanceCON += (decimal)row["appropriatons_balance"];
                            psAllotmentBalanceCON += (decimal)row["allotment_release_balance"];
                        }
                        break;
                    case 2:
                        if (!isContinuing)
                        {
                            mooeAppropriationsCY += (decimal)row["appropriations"];
                            mooeAllotmentsCY += (decimal)row["allotments"];
                            mooeObligationsCY += (decimal)row["obligations"];
                            mooeAppropriationBalanceCY += (decimal)row["appropriatons_balance"];
                            mooeAllotmentBalanceCY += (decimal)row["allotment_release_balance"];
                        }
                        else
                        {
                            mooeAppropriationsCON += (decimal)row["appropriations"];
                            mooeAllotmentsCON += (decimal)row["allotments"];
                            mooeObligationsCON += (decimal)row["obligations"];
                            mooeAppropriationBalanceCON += (decimal)row["appropriatons_balance"];
                            mooeAllotmentBalanceCON += (decimal)row["allotment_release_balance"];
                        }
                        break;
                    case 3:
                        if (!isContinuing)
                        {
                            coAppropriationsCY += (decimal)row["appropriations"];
                            coAllotmentsCY += (decimal)row["allotments"];
                            coObligationsCY += (decimal)row["obligations"];
                            coAppropriationBalanceCY += (decimal)row["appropriatons_balance"];
                            coAllotmentBalanceCY += (decimal)row["allotment_release_balance"];
                        }
                        else
                        {
                            coAppropriationsCON += (decimal)row["appropriations"];
                            coAllotmentsCON += (decimal)row["allotments"];
                            coObligationsCON += (decimal)row["obligations"];
                            coAppropriationBalanceCON += (decimal)row["appropriatons_balance"];
                            coAllotmentBalanceCON += (decimal)row["allotment_release_balance"];
                        }
                        break;
                    case 4:
                        break;

                }
            
            }


            var dashboardRecords = new Dictionary<string, string>();

            #region CURRENT YEAR

            //PS
            dashboardRecords.Add("ps_appropriations_cy", psAppropriationsCY.ToString("N2"));
            dashboardRecords.Add("ps_allotments_cy", psAllotmentsCY.ToString("N2"));
            dashboardRecords.Add("ps_obligations_cy", psObligationsCY.ToString("N2"));
            dashboardRecords.Add("ps_appropriaton_balance_cy", psAppropriationBalanceCY.ToString("N2"));
            dashboardRecords.Add("ps_allotment_balance_cy", psAllotmentBalanceCY.ToString("N2"));

            //MOOE
            dashboardRecords.Add("mooe_appropriations_cy", mooeAppropriationsCY.ToString("N2"));
            dashboardRecords.Add("mooe_allotments_cy", mooeAllotmentsCY.ToString("N2"));
            dashboardRecords.Add("mooe_obligations_cy", mooeObligationsCY.ToString("N2"));
            dashboardRecords.Add("mooe_appropriaton_balance_cy", mooeAppropriationBalanceCY.ToString("N2"));
            dashboardRecords.Add("mooe_allotment_balance_cy", mooeAllotmentBalanceCY.ToString("N2"));

            //CO
            dashboardRecords.Add("co_appropriations_cy", coAppropriationsCY.ToString("N2"));
            dashboardRecords.Add("co_allotments_cy", coAllotmentsCY.ToString("N2"));
            dashboardRecords.Add("co_obligations_cy", coObligationsCY.ToString("N2"));
            dashboardRecords.Add("co_appropriaton_balance_cy", coAppropriationBalanceCY.ToString("N2"));
            dashboardRecords.Add("co_allotment_balance_cy", coAllotmentBalanceCY.ToString("N2"));

            //FE
            dashboardRecords.Add("fe_appropriations_cy", feAppropriationsCY.ToString("N2"));
            dashboardRecords.Add("fe_allotments_cy", feAllotmentsCY.ToString("N2"));
            dashboardRecords.Add("fe_obligations_cy", feObligationsCY.ToString("N2"));
            dashboardRecords.Add("fe_appropriaton_balance_cy", feAppropriationBalanceCY.ToString("N2"));
            dashboardRecords.Add("fe_allotment_balance_cy", feAllotmentBalanceCY.ToString("N2"));

            #endregion

            #region CONTINUING

            //PS
            dashboardRecords.Add("ps_appropriations_con", psAppropriationsCON.ToString("N2"));
            dashboardRecords.Add("ps_allotments_con", psAllotmentsCON.ToString("N2"));
            dashboardRecords.Add("ps_obligations_con", psObligationsCON.ToString("N2"));
            dashboardRecords.Add("ps_appropriaton_balance_con", psAppropriationBalanceCON.ToString("N2"));
            dashboardRecords.Add("ps_allotment_balance_con", psAllotmentBalanceCON.ToString("N2"));

            //MOOE
            dashboardRecords.Add("mooe_appropriations_con", mooeAppropriationsCON.ToString("N2"));
            dashboardRecords.Add("mooe_allotments_con", mooeAllotmentsCON.ToString("N2"));
            dashboardRecords.Add("mooe_obligations_con", mooeObligationsCON.ToString("N2"));
            dashboardRecords.Add("mooe_appropriaton_balance_con", mooeAppropriationBalanceCON.ToString("N2"));
            dashboardRecords.Add("mooe_allotment_balance_con", mooeAllotmentBalanceCON.ToString("N2"));

            //CO
            dashboardRecords.Add("co_appropriations_con", coAppropriationsCON.ToString("N2"));
            dashboardRecords.Add("co_allotments_con", coAllotmentsCON.ToString("N2"));
            dashboardRecords.Add("co_obligations_con", coObligationsCON.ToString("N2"));
            dashboardRecords.Add("co_appropriaton_balance_con", coAppropriationBalanceCON.ToString("N2"));
            dashboardRecords.Add("co_allotment_balance_con", coAllotmentBalanceCON.ToString("N2"));

            //FE
            dashboardRecords.Add("fe_appropriations_con", feAppropriationsCON.ToString("N2"));
            dashboardRecords.Add("fe_allotments_con", feAllotmentsCON.ToString("N2"));
            dashboardRecords.Add("fe_obligations_con", feObligationsCON.ToString("N2"));
            dashboardRecords.Add("fe_appropriaton_balance_con", feAppropriationBalanceCON.ToString("N2"));
            dashboardRecords.Add("fe_allotment_balance_con", feAllotmentBalanceCON.ToString("N2"));

            #endregion

            //GRAND TOTAL
            dashboardRecords.Add("grand_total_appropriations", grandTotalAppropriations.ToString("N2"));
            dashboardRecords.Add("grand_total_allotments", grandTotalAllotments.ToString("N2"));
            dashboardRecords.Add("grand_total_obligations", grandTotalObligations.ToString("N2"));
            dashboardRecords.Add("grand_total_appropriation_balance",grandTotalAppropriationBalance.ToString("N2"));
            dashboardRecords.Add("grand_total_allotment_balance", grandTotalAllotmentBalance.ToString("N2"));

            return dashboardRecords;
        }


        private void LoadDashboarInformations() 
        {
            Cursor.Current = Cursors.WaitCursor;

            #region CURRENT YEAR

            lblPSappropriationsCY.Text = GetDashboardRecords()["ps_appropriations_cy"];
            lblPSallotmentsCY.Text = GetDashboardRecords()["ps_allotments_cy"];
            lblPSobligationsCY.Text = GetDashboardRecords()["ps_obligations_cy"];
            lblPSappropriationBalanceCY.Text = GetDashboardRecords()["ps_appropriaton_balance_cy"];
            lblPSallotmentBalanceCY.Text = GetDashboardRecords()["ps_allotment_balance_cy"];

            lblMOOEappropriationsCY.Text = GetDashboardRecords()["mooe_appropriations_cy"];
            lblMOOEallotmentsCY.Text = GetDashboardRecords()["mooe_allotments_cy"];
            lblMOOEobligationsCY.Text = GetDashboardRecords()["mooe_obligations_cy"];
            lblMOOEappropriationBalanceCY.Text = GetDashboardRecords()["mooe_appropriaton_balance_cy"];
            lblMOOEallotmentBalanceCY.Text = GetDashboardRecords()["mooe_allotment_balance_cy"];

            lblCOappropriationsCY.Text = GetDashboardRecords()["co_appropriations_cy"];
            lblCOallotmentsCY.Text = GetDashboardRecords()["co_allotments_cy"];
            lblCOobligationsCY.Text = GetDashboardRecords()["co_obligations_cy"];
            lblCOappropriationBalanceCY.Text = GetDashboardRecords()["co_appropriaton_balance_cy"];
            lblCOallotmentBalanceCY.Text = GetDashboardRecords()["co_allotment_balance_cy"];

            lblFEappropriationsCY.Text = GetDashboardRecords()["fe_appropriations_cy"];
            lblFEallotmentsCY.Text = GetDashboardRecords()["fe_allotments_cy"];
            lblFEobligationsCY.Text = GetDashboardRecords()["fe_obligations_cy"];
            lblFEappropriationBalanceCY.Text = GetDashboardRecords()["fe_appropriaton_balance_cy"];
            lblFEallotmentBalanceCY.Text = GetDashboardRecords()["fe_allotment_balance_cy"];

            #endregion

            #region CONTINUNING

            lblPSappropriationsCON.Text = GetDashboardRecords()["ps_appropriations_con"];
            lblPSallotmentsCON.Text = GetDashboardRecords()["ps_allotments_con"];
            lblPSobligationsCON.Text = GetDashboardRecords()["ps_obligations_con"];
            lblPSappropriationBalanceCON.Text = GetDashboardRecords()["ps_appropriaton_balance_con"];
            lblPSallotmentBalanceCON.Text = GetDashboardRecords()["ps_allotment_balance_con"];

            lblMOOEappropriationsCON.Text = GetDashboardRecords()["mooe_appropriations_con"];
            lblMOOEallotmentsCON.Text = GetDashboardRecords()["mooe_allotments_con"];
            lblMOOEobligationsCON.Text = GetDashboardRecords()["mooe_obligations_con"];
            lblMOOEappropriationBalanceCON.Text = GetDashboardRecords()["mooe_appropriaton_balance_con"];
            lblMOOEallotmentBalanceCON.Text = GetDashboardRecords()["mooe_allotment_balance_con"];

            lblCOappropriationsCON.Text = GetDashboardRecords()["co_appropriations_con"];
            lblCOallotmentsCON.Text = GetDashboardRecords()["co_allotments_con"];
            lblCOobligationsCON.Text = GetDashboardRecords()["co_obligations_con"];
            lblCOappropriationBalanceCON.Text = GetDashboardRecords()["co_appropriaton_balance_con"];
            lblCOallotmentBalanceCON.Text = GetDashboardRecords()["co_allotment_balance_con"];

            lblFEappropriationsCON.Text = GetDashboardRecords()["fe_appropriations_con"];
            lblFEallotmentsCON.Text = GetDashboardRecords()["fe_allotments_con"];
            lblFEobligationsCON.Text = GetDashboardRecords()["fe_obligations_con"];
            lblFEappropriationBalanceCON.Text = GetDashboardRecords()["fe_appropriaton_balance_con"];
            lblFEallotmentBalanceCON.Text = GetDashboardRecords()["fe_allotment_balance_con"];

            #endregion


            #region GRAND TOTAL

            lblGrandTotalAppropriations.Text = GetDashboardRecords()["grand_total_appropriations"];
            lblGrandTotalAllotments.Text = GetDashboardRecords()["grand_total_allotments"];
            lblGrandTotalObligations.Text = GetDashboardRecords()["grand_total_obligations"];
            lblGrandTotalAppropriationBalance.Text = GetDashboardRecords()["grand_total_appropriation_balance"];
            lblGrandTotalAllotmentBalance.Text = GetDashboardRecords()["grand_total_allotment_balance"];

            #endregion

            Cursor.Current = Cursors.Default;
        }



        #region COMBOBOXES

        //FUNDS
        internal void LoadFunds()
        {
            cmbxFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbxFunds.DisplayMember = "fund_name";
            cmbxFunds.ValueMember = "id";
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

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
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

        private void CmbxFPP_SelectedValueChanged(object sender, EventArgs e)
        {
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

        private void UcBudgetDashboard_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            LoadFunds();

            //FPP
            LoadFPP();
            cmbxFPP.TextChanged += new EventHandler(CmbxFPP_TextChanged);
            cmbxFPP.SelectedValueChanged += new EventHandler(CmbxFPP_SelectedValueChanged);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboarInformations();
        }
    }
}
