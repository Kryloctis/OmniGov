using ACC.Domain.Models;
using AccountingSystem;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsAdd : Form
    {
        private frmBudgetAppropriations _frmBudgetAppropriations;
        public frmBudgetAppropriationsAdd(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
        }

        private void LoadComboboxes()
        {
            var uc = ucBudgetAppropriations1;
            uc.LoadFPPRecords();
            uc.LoadOtherFPPRecords();
            uc.LoadAllotmentClassRecords();
            uc.LoadGeneralLedgerAccounts();
            uc.LoadTypeOfFund();
            uc.ResetForm();
            uc.nudYear.Value = DateTime.Now.Year;
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                int? othersFPPId;

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                if (uc.cmbxOthersFPP.SelectedValue == null)
                    othersFPPId = null;
                else
                    othersFPPId = Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);

                // proceed to insert
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    Year = Convert.ToInt16(uc.nudYear.Value),
                    DateEntry = uc.dtDateEntry.Value,
                    amount = uc.nudAmount.Value
                };

                return Factory.BudgetAppropriationsRepository().Insert(budgetAppropriationsModel);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uc = ucBudgetAppropriations1;

            //If Save data is successful
            if (SaveData()) 
            {
                //Initialze data references
                int fppID = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue);
                int typeOfFundID = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue);
                short year = Convert.ToInt16(uc.nudYear.Value);

                //Update FPP datagrid, Appropriations datagrid and Combobox Year before reseting user control
                HelperLoadRecords.FPPDgVBudgetAppropriations(_frmBudgetAppropriations.dgFPP);
                HelperLoadRecords.YearToolStripCmbx(Factory.BudgetAppropriationsRepository().GetYearsBudgetAppropriations(), _frmBudgetAppropriations.cmbxYear, "year", "year");
                HelperLoadRecords.BudgetAppropriationsDgV(_frmBudgetAppropriations.dgBudgetAppropriations, fppID, allotmentClassID, typeOfFundID, year, _frmBudgetAppropriations.txtTotal);

                //Reset User Control Form
                uc.ResetForm();

                Helper.MessageBoxSuccess("Budget Appropriation has been saved."); 
            }
        }

        private void frmBudgetAppropriationsAdd_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }
    }
}
