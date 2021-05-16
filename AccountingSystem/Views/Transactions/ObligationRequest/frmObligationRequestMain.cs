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
        ucObligationRequestMain uc;

        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnAdd.Click += new EventHandler(BtnAdd_Click);
            uc = ucObligationRequestMain1;
        }

        private bool ShowObligationRequestAdd() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var frmObligationAdd = new frmObligationRequestAdd();
                var ucFrmObligationAdd = frmObligationAdd.ucObligationRequest1;

                ucFrmObligationAdd.fppId = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                ucFrmObligationAdd.otherFPPId = string.IsNullOrEmpty(uc.cmbxOthersFPP.Text) ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);
                ucFrmObligationAdd.fundId = uc.fundId;
                ucFrmObligationAdd.allotmentClassId = uc.allotmentClassId;
                ucFrmObligationAdd.accountId = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
                ucFrmObligationAdd.txtAccountName.Text = uc.cmbxAccount.Text;
                ucFrmObligationAdd.month = Convert.ToByte(uc.cmbxMonths.SelectedValue);
                ucFrmObligationAdd.year = Convert.ToInt16(uc.nudYear.Value);

                frmObligationAdd.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ShowObligationRequestAdd();
        }

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {

        }

    }
}
