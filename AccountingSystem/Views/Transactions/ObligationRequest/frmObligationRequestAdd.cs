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
        private ucObligationRequestMain _ucObligationRequestMain;
        private ucObligationRequest uc;

        public frmObligationRequestAdd(ucObligationRequestMain ucObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucObligationRequest1;
            _ucObligationRequestMain = ucObligationRequestMain;
            uc.LoadReferences(_ucObligationRequestMain);
        }


        private bool AddToListRecord() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                int accountId = Convert.ToInt32(uc.cmbxBudgetAppropriations.SelectedValue);
                string accountName = uc.cmbxBudgetAppropriations.Text;
                decimal obligationAmount = uc.nudAmount.Value;

                var items = new object[]
                {
                    accountId,
                    accountName,
                    obligationAmount
                };
                               
                _ucObligationRequestMain.dgObligationRequests.Rows.Add(items);
                _ucObligationRequestMain.GetTotalObligations();

                return true;
            
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (AddToListRecord()) 
            {
                uc.ResetForm();
                _ucObligationRequestMain.cmbxFPP.Enabled = false;
                _ucObligationRequestMain.cmbxSubFPP.Enabled = false;
                _ucObligationRequestMain.flowLayoutPanelFunds.Enabled = false;
                _ucObligationRequestMain.flowLayoutPanelAllotmentClass.Enabled = false;
                _ucObligationRequestMain.dtDateRequest.Enabled = false;
            }
        }

    }
}
