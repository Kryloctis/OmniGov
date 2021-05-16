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
    public partial class frmObligationRequestAdd : Form
    {
        private ucObligationRequest uc;

        public frmObligationRequestAdd()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
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

                string obligationNo = $"{uc.mskTxtSeriesNo.Text}-{uc.GenerateObligationNoTemplate()}";
                int userId =  Helper.UserId;

                var obligationRequestModel = new ObligationRequestModel()
                {
                    FundID = uc.fundId,
                    FPPId = uc.fppId,
                    OtherFPPId = uc.otherFPPId,
                    AllotmentClassesID = uc.allotmentClassId,
                    GenLedgerAccID = uc.accountId,
                    DateRequested = uc.dtDateRequest.Value,
                    ObligationNo = obligationNo,
                    Payee = uc.txtPayee.Text.Trim(),
                    Explanation = uc.txtExplanation.Text.Trim(),
                    ReferencesNo = uc.txtReferenceNo.Text.Trim(),
                    ObligationAmount = uc.nudAmount.Value,
                    CreatedBy = userId
                };


                return Factory.ObligationRequestRepository().Insert(obligationRequestModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                uc.ResetForm();
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
            }
        }
    }
}
