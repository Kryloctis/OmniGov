using ACC.Domain.Interfaces;
using ACC.Domain.Models;
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
            btnNew.Click += new EventHandler(BtnNew_Click);
            btnSave.Click += new EventHandler(BtnSave_Click);
            btnDelete.Click += new EventHandler(BtnDelete_Click);
            btnCancel.Click += new EventHandler(BtnCancel_CLick);
            btnSearch.Click += new EventHandler(BtnSearch_Click);
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void UnsavedWorkPrompt()
        {
            var message = "Are you sure? Unsaved data will not be saved.";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uc.ResetForm();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            UnsavedWorkPrompt();
        }


        private List<ObligationAccountModel> ObligationAccountsModelList() 
        {
            var obligationRequestModelList = new List<ObligationAccountModel>();

            foreach (DataGridViewRow item in uc.dataGridView1.Rows) 
            {

                int accountId = Convert.ToInt32(item.Cells["account_id"].Value);
                decimal amount = Convert.ToDecimal(item.Cells["amount"].Value);

                var obligationAccountModel = new ObligationAccountModel()
                {
                    AccountId = accountId,
                    Amount = amount
                };


                obligationRequestModelList.Add(obligationAccountModel);
            }

            return obligationRequestModelList;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }



        private bool InsertData() 
        {
            try
            {

                var obligationRequestModel = new ObligationRequestModel()
                {
                    FPPId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OtherFPPId = string.IsNullOrEmpty(uc.cmbxOtherFPP.Text) ? null : Convert.ToInt32(uc.cmbxOtherFPP.SelectedValue),
                    FundId = uc.fundId,
                    AllotmentClassId = uc.allotmentClassId,
                    DateRequested = uc.dtDateRequest.Value,
                    ObligationNo = $"{uc.mskTxtObligationNoSeries.Text}-{uc.mskTxtObligationNoTemplate.Text}",
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
                    CreatedBy = Helper.UserId
                };


                return Factory.ObligationRequestRepository().Insert(obligationRequestModel, ObligationAccountsModelList());
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private bool UpdateData() 
        {
            try
            {
                var obligationRequestModel = new ObligationRequestModel()
                {
                    Id = uc.obligationRequestId,
                    Payee = uc.txtPayee.Text,
                    Explanation = uc.txtExplanation.Text,
                    ReferenceNo = uc.txtReferenceNo.Text,
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
                if (!uc.ValidateChildren() || uc.ShowErrorListEmpty()) 
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
                btnNew.Enabled = true;
                btnSave.Text = "&Save";
                btnDelete.Enabled = false;
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


        private void BtnCancel_CLick(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            btnNew.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            uc.ResetForm();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestSearch(this).ShowDialog();
        }

    }
}
