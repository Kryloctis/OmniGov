using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationsMain : Form
    {
        internal frmBudgetAppropriations _frmBudgetAppropriations;
        ucSupplementalAppropriationsMain uc;

        public frmSupplementalAppropriationsMain(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucSupplementalAppropriationsMain1;
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void frmSupplementalAppropriationsMain_Load(object sender, EventArgs e)
        {
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = uc.fundId,
                    FunctionProgramProjectId = uc.fppId,
                    OthersFPPId = uc.cmbxSubFPP.SelectedValue == null ? null : Convert.ToInt32(uc.cmbxSubFPP.SelectedValue),
                    AllotmentClassesId = uc.allotmentClassId,
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxAccount.SelectedValue),
                    Year = (short)uc.year,
                    DateEntry = uc.dtpDateEntry.Value,
                    Continuing = uc.chckbxContinuing.Checked,
                    Remarks = uc.txtRemarks.Text.Trim()
                };

                var SupplementalAppropriationList = new List<SupplementalAppropriationsModel>();

                foreach (DataGridViewRow row in uc.dgSupplementalAppropriations.Rows)
                {
                    var supplementalAppropriationsModel = new SupplementalAppropriationsModel()
                    {
                        date_entry = Convert.ToDateTime(row.Cells["date_entry"].Value),
                        amount = Convert.ToDecimal(row.Cells["amount"].Value),
                        remarks = row.Cells["remarks"].Value.ToString().Trim()
                    };

                    if (uc.budgetAppropriationId != 0)
                        supplementalAppropriationsModel.BudgetAppropriationID = uc.budgetAppropriationId;

                    SupplementalAppropriationList.Add(supplementalAppropriationsModel);
                }

                if (uc.budgetAppropriationId == 0)
                    return Factory.BudgetAppropriationsRepository().Insert(budgetAppropriationsModel, SupplementalAppropriationList);
                else
                    return Factory.SupplementalAppropriationsRepository().Insert(SupplementalAppropriationList);

            }
            catch (Exception ex) { Helper.MessageBoxSuccess(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                string generalLedgerAccountName = uc.cmbxAccount.Text;
                string remarks = uc.txtRemarks.Text;
                string objectOfExpenditures = $" {generalLedgerAccountName}{(string.IsNullOrEmpty(remarks) ? string.Empty : $" → {remarks}")}";

                Helper.MessageBoxSuccess("Supplemental appropriations has been saved.");
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                Helper.DatagridViewRecordFinder(_frmBudgetAppropriations.dgBudgetAppropriations, "object_of_expenditures", objectOfExpenditures);
            }
        }
    }
}
