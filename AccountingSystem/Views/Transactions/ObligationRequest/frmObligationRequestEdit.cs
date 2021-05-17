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
    public partial class frmObligationRequestEdit : Form
    {
        private ucObligationRequest uc;
        private frmObligationRequestMain _frmObligationRequestMain;

        public frmObligationRequestEdit(frmObligationRequestMain frmObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
            _frmObligationRequestMain = frmObligationRequestMain;
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

                var obligationRequestModel = new ObligationRequestModel()
                {
                    ID = uc.obligationRequestId,
                    ObligationNo = $"{uc.mskTxtSeriesNo.Text}-{uc.GenerateObligationNoTemplate()}",
                    Payee = uc.txtPayee.Text.Trim(),
                    ReferencesNo = uc.txtReferenceNo.Text.Trim(),
                    ObligationAmount = uc.nudAmount.Value,
                    Explanation = uc.txtExplanation.Text.Trim(),
                    UpdatedBy = Helper.UserId
                };

                return Factory.ObligationRequestRepository().Update(obligationRequestModel);
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
                Helper.MessageBoxSuccess("Obligation Request has been updated.");
                _frmObligationRequestMain.ucObligationRequestMain1.LoadObligationRequestRecords();
                Close();
            }
        }
    }
}
