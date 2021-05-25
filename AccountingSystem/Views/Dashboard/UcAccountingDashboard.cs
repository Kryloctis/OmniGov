using ACC.Domain.Interfaces;
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
    public partial class UcAccountingDashboard : UserControl
    {
        private Dictionary<string, string> userDict;
        public UcAccountingDashboard(Dictionary<string, string> _userDict)
        {
            InitializeComponent();
            userDict = _userDict;
        }


        private void UcAccountingDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadFPP();
                Dock = DockStyle.Fill;

                tlpJournals.Visible = false;

                if (userDict["office"] == "Accounting" || userDict["office"] == "SysAdmin")
                    tlpJournals.Visible = true;

                LoadCardRecords();
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = epFPP.GetError(cmbFPP);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }


        internal void LoadFunds()
        {
            cmbFund.DataSource = Factory.FundsRepository().GetRecords();
            cmbFund.DisplayMember = "fund_name";
            cmbFund.ValueMember = "id";

            cmbFund.SelectedValueChanged += new System.EventHandler(cmbFund_SelectedValueChanged);
        }

        internal void LoadFPP()
        {
            cmbFPP.SelectedValueChanged -= new System.EventHandler(cmbFPP_SelectedValueChanged);
            var dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            HelperLoadRecords.FPPComboBox(dtFPP, cmbFPP, "fpp_name", "id");
            cmbFPP.SelectedValueChanged += new System.EventHandler(cmbFPP_SelectedValueChanged);
        }

        private void LoadCardRecords() 
        {
            try
            {
                int fundId = Convert.ToInt32(cmbFund.SelectedValue);
                int fppId = Convert.ToInt32(cmbFPP.SelectedValue);
                int[] allotmentClassIds = new int[] {1,2,3,4,};


                foreach (int allotmentClassId in allotmentClassIds)
                {
                    decimal TotalbudgetAppropriations = Factory.BudgetAppropriationsRepository().GetTotalBudgetAppropriationsByIds(fundId, allotmentClassId, fppId);

                    decimal TotalAllotmentReleases = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseByIds(fundId, allotmentClassId, fppId);

                    decimal TotalObligations = Factory.ObligationRequestRepository().GetTotalObligationsByIds(fundId, allotmentClassId, fppId);


                    decimal UnobligatedAppropriationBalance = TotalbudgetAppropriations - TotalObligations;

                    switch (allotmentClassId) 
                    {
                        case 1:
                            lblPSAppropriations.Text = TotalbudgetAppropriations.ToString("N2");
                            lblPSAllotmentReleases.Text = TotalAllotmentReleases.ToString("N2");
                            lblPSObligations.Text = TotalObligations.ToString("N2");
                            lblPSUnobligatedBalances.Text = UnobligatedAppropriationBalance.ToString("N2");
                            break;
                        case 2:
                            lblMOOEAppropriations.Text = TotalbudgetAppropriations.ToString("N2");
                            lblMOOEAllotmentReleases.Text = TotalAllotmentReleases.ToString("N2");
                            lblMOOEObligations.Text = TotalObligations.ToString("N2");
                            lblMOOEUnobligatedBalances.Text = UnobligatedAppropriationBalance.ToString("N2");
                            break;
                        case 3:
                            lblCOAppropriatons.Text = TotalbudgetAppropriations.ToString("N2");
                            lblCOAllotmentReleases.Text = TotalAllotmentReleases.ToString("N2");
                            lblCOObligations.Text = TotalObligations.ToString("N2");
                            lblCOUnobligatedBalances.Text = UnobligatedAppropriationBalance.ToString("N2");
                            break;
                        case 4:
                            lblFEAppropriations.Text = TotalbudgetAppropriations.ToString("N2");
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private bool fppNameNotExist()
        {
            try
            {
                bool fppNameExist = Factory.FunctionProgramProjectRepository().NameExist(cmbFPP.Text);

                if (!fppNameExist && !string.IsNullOrEmpty(cmbFPP.Text)) 
                {
                    epFPP.SetError(cmbFPP,"FPP you entered doesn't exist on your system.");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbFund_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCardRecords();
        }

        private void cmbFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
            }
            else
                LoadCardRecords();
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            if (fppNameNotExist())
                e.Cancel = fppNameNotExist();
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbFPP);
        }
    }
}
