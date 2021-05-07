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

                if (!uc.ValidateChildren() || !string.IsNullOrEmpty(uc.epBudgetAppropriation.GetError(uc.cmbxTypeOfFund)))
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = uc.cmbxOthersFPP.SelectedValue == null ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue),
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    Year = Convert.ToInt16(uc.nudYear.Value),
                    DateEntry = uc.dtDateEntry.Value,
                    Amount = uc.nudAmount.Value,
                    Continuing = uc.chckbxContinuing.Checked
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
                int fundID = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue);
                short year = Convert.ToInt16(uc.nudYear.Value);

                _frmBudgetAppropriations.RecordLocator(fppID, allotmentClassID, fundID, year);
                _frmBudgetAppropriations.cmbxAllotmentClass.ComboBox.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFundType.ComboBox.SelectedValue = fundID;
                _frmBudgetAppropriations.cmbxYear.ComboBox.SelectedValue = year;

                //Reset User Control Form
                uc.cmbxLedgerAccount.SelectedIndex = -1;
                uc.nudAmount.Value = 0;

                Helper.MessageBoxSuccess("Budget Appropriation has been saved."); 
            }
        }

        private void frmBudgetAppropriationsAdd_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }
    }
}
