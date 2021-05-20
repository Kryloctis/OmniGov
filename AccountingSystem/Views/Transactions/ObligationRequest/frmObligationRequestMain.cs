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


        private bool SaveData() 
        {
            try
            {
                if (!uc.ValidateChildren() || uc.ShowErrorListEmpty()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
                uc.ResetForm();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_CLick(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

    }
}
