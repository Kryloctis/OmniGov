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

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIAdd : Form
    {
        private frmRCI _frmrci;
        public frmRCIAdd(frmRCI frmrci)
        {
            InitializeComponent();
            _frmrci = frmrci;
        }

        private void frmRCIAdd_Load(object sender, EventArgs e)
        {
            ucrci1.LoadBanks();
            ucrci1.LoadFunds();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucrci1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var rciModel = new RCIModel()
                {
                    BankId = Convert.ToInt32(uc.cmbbank.SelectedValue),
                    FundsId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    FunctionProgramProjectId = uc.functionId,
                    CheckNo = uc.txtcheckno.Text.Trim(),
                    CheckDate = Convert.ToDateTime(uc.dtcheckdate.Text.Trim()),
                    ObNo = uc.txtObno.Text.Trim(),
                    DvNo = uc.txtdvno.Text.Trim(),
                    Payee = uc.txtpayee.Text.Trim(),
                    NaturePayment = uc.txtnature.Text.Trim(),
                    TrustLiabilities = Convert.ToDecimal(uc.txttrust.Value),
                    BirVatNonVat = Convert.ToDecimal(uc.txtvat.Value),
                    Amount = Convert.ToDecimal(uc.txtamount.Value)
                };

                var rcirepository = Factory.RCIRepository();
                return rcirepository.Insert(rciModel);
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
                Helper.MessageBoxSuccess("RCI has been saved.");
                _frmrci.LoadRecords();
                ucrci1.ResetForm();
            }
        }
    }
}
