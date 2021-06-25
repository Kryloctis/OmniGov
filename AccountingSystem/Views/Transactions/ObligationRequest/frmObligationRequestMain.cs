using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestMain : Form
    {
        private ucObligationRequestMain uc;

        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequestMain1;
            btnDelete.Enabled = false;
        }

        private List<ObligationAccountModel> ObligationAccountsModelList() 
        {
            var obligationRequestModelList = new List<ObligationAccountModel>();

            foreach (DataGridViewRow item in uc.dgObligationRequests.Rows) 
            {
                int budgetAppropriationId = Convert.ToInt32(item.Cells["budget_appropriation_id"].Value);
                decimal obligationAmount = Convert.ToDecimal(item.Cells["obligation_amount"].Value);

                var obligationAccountModel = new ObligationAccountModel()
                {
                    BudgetAppropriationId = budgetAppropriationId,
                    Amount = obligationAmount
                };

                obligationRequestModelList.Add(obligationAccountModel);
            }

            return obligationRequestModelList;
        }

        internal void EnableDisableButtons() 
        {
            if (uc.obligationRequestId == 0)
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnCancel.Enabled = true;
            }
        }


        //DELETE
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmDelete(1))
                {
                    _ = Factory.ObligationRequestRepository().Delete(uc.obligationRequestId);
                    btnSave.Text = "&Save";
                    btnDelete.Enabled = false;
                    uc.ResetForm();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        //INSERT
        private bool InsertData() 
        {
            try
            {
                string obligationNo = $"{uc.mskTxtObligationNoSeries.Text}-{uc.mskTxtObligationNoTemplate.Text}";

                var obligationRequestModel = new ObligationRequestModel()
                {
                    ObligationNo = obligationNo,
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
                    DateRequested = uc.dtDateRequest.Value,
                    CreatedBy = Helper.UserId
                };


                return Factory.ObligationRequestRepository().Insert(obligationRequestModel, ObligationAccountsModelList());
            }
            catch (MySqlException ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        //UPDATE
        private bool UpdateData() 
        {
            try
            {
                string obligationNo = $"{uc.mskTxtObligationNoSeries.Text}-{uc.mskTxtObligationNoTemplate.Text}";

                var obligationRequestModel = new ObligationRequestModel()
                {
                    Id = uc.obligationRequestId,
                    ObligationNo = obligationNo,
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
                    DateRequested = uc.dtDateRequest.Value,
                    UpdatedBy = Helper.UserId
                };


                return Factory.ObligationRequestRepository().Update(obligationRequestModel, ObligationAccountsModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
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

                bool saveData;

                if (uc.obligationRequestId == 0)
                    saveData = InsertData();
                else
                {
                    saveData = UpdateData();
                }


                return saveData;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private void Actions()
        {
            if (uc.obligationRequestId == 0)
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
            else
            {
                Helper.MessageBoxSuccess("Obligation Request has been updated.");
                btnSave.Text = "&Save";
                btnCancel.Enabled = false;
            }

            uc.ResetForm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Actions();
            }
        }



        private void CancelAction() 
        {
            string message = "Are you sure? Changes cannot be undone.";

            if (uc.obligationRequestId > 0 || uc.dgObligationRequests.Rows.Count > 0)
            {
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    btnSave.Text = "Save";
                    btnDelete.Enabled = false;
                    uc.ResetForm();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelAction();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestSearch(this).ShowDialog();
        }
    }
}
