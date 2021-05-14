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
            uc.LoadReference(_ucObligationRequestMain);
        }

        private bool AddToList() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                ushort accountId = Convert.ToUInt16(uc.cmbxAccount.SelectedValue);
                string accountName = uc.cmbxAccount.Text;
                string accountCode = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(accountId)["account_code"];
                decimal amount = uc.nudAmount.Value;

                var data = new object[]
                {
                    accountId,
                    accountName,
                    accountCode,
                    amount
                };

                _ucObligationRequestMain.dgObligationRequests.Rows.Add(data);

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void DisableComponents()
        {
            _ucObligationRequestMain.panel1.Enabled = false;
            _ucObligationRequestMain.dtDateRequested.Enabled = false;
        }

        private void frmObligationRequestAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (AddToList()) 
            {
                DisableComponents();
                Close();
            }
        }
    }
}
