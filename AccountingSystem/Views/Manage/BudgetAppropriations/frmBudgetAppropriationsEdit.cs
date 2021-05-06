using ACC.Domain.Models;
using AccountingSystem;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using BudgetSystem.Views.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.Manage.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsEdit : Form
    {
        private frmBudgetAppropriations _frmBudgetAppropriations;
        private ucBudgetAppropriations uc;

        public frmBudgetAppropriationsEdit(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
            uc = ucBudgetAppropriations1;
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
        }

        private void LoadSelected() 
        {
            try
            {
                int ucBudgetAppropriationId = uc.budgetAppropriationId;
                int ucFPPId = uc.fppId;
                int? ucOtherFPPId = uc.othersFPPId;
                int ucAllotmentClassId = uc.allotmentClassId;
                int ucGeneralLedgerAccountId = uc.generalLedgerAccountId;

           
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetRecordByIDs(ucBudgetAppropriationId, ucFPPId, ucOtherFPPId, ucAllotmentClassId, ucGeneralLedgerAccountId);

                int fundId = Convert.ToInt32(selectedBudgetAppropriation["funds_id"]);
                int fppId = Convert.ToInt32(selectedBudgetAppropriation["function_program_project_id"]);
                int? othersFPPId = string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_id"]) ? null : Convert.ToInt32(selectedBudgetAppropriation["others_fpp_id"]);
                int allotmentClassId = Convert.ToInt32(selectedBudgetAppropriation["allotment_classes_id"]);
                int generalLedgerAccountId = Convert.ToInt32(selectedBudgetAppropriation["general_ledger_accounts_id"]);
                DateTime dateEntry = Convert.ToDateTime(selectedBudgetAppropriation["date_entry"]);
                short year = Convert.ToInt16(selectedBudgetAppropriation["year"]);
                decimal appropriationAmount = Convert.ToDecimal(selectedBudgetAppropriation["amount"]);

                bool continuing = Convert.ToByte(selectedBudgetAppropriation["continuing"]) == 0 ? false : true;

                uc.cmbxTypeOfFund.SelectedValue = fundId;
                uc.cmbxFPP.SelectedValue = fppId;

                if (othersFPPId == null) 
                    uc.cmbxOthersFPP.SelectedIndex = -1;
                else
                    uc.cmbxOthersFPP.SelectedValue = othersFPPId;

                uc.cmbxAllotmentClass.SelectedValue = allotmentClassId;
                uc.cmbxLedgerAccount.SelectedValue = generalLedgerAccountId;
                uc.dtDateEntry.Value = dateEntry;
                uc.nudYear.Value = year;
                uc.nudAmount.Value = appropriationAmount;
                uc.chckbxContinuing.Checked = continuing;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                int? othersFPPId;

                //Check Validation
                if (!uc.ValidateChildren() || !string.IsNullOrEmpty(uc.epBudgetAppropriation.GetError(uc.cmbxTypeOfFund))) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.cmbxOthersFPP.SelectedValue == null)
                    othersFPPId = null;
                else
                    othersFPPId = Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);


                var budgetAppModel = new BudgetAppropriationsModel()
                {
                    ID = uc.budgetAppropriationId,
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    DateEntry = uc.dtDateEntry.Value,
                    Year = Convert.ToInt16(uc.nudYear.Value),
                    amount = uc.nudAmount.Value,
                    continuing = uc.chckbxContinuing.Checked
                };

                return Factory.BudgetAppropriationsRepository().Update(budgetAppModel);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmBudgetAppropriationsEdit_Load(object sender, EventArgs e)
        {
            var uc = ucBudgetAppropriations1;
            LoadComboboxes();
            LoadSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucBudgetAppropriations1;

                //Initialze data references
                int fppID = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue);
                int fundID = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue);
                short year = Convert.ToInt16(uc.nudYear.Value);

                _frmBudgetAppropriations.RecordLocator(fppID, allotmentClassID, fundID, year);
                _frmBudgetAppropriations.cmbxAllotmentClass.ComboBox.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFundType.ComboBox.SelectedValue = fundID;
                _frmBudgetAppropriations.cmbxYear.ComboBox.SelectedValue = year;

                Helper.MessageBoxSuccess("Budget Appropriation update has been saved.");
                Close();

                //Reset User Control Form
                uc.ResetForm();
            }
        }
    }
}
