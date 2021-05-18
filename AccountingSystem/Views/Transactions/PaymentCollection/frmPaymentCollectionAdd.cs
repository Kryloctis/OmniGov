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

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollectionAdd : Form
    {
        private frmPaymentCollection _frmpc;
        public frmPaymentCollectionAdd(frmPaymentCollection frmpc)
        {
            InitializeComponent();
            _frmpc = frmpc;
            ucpc1.userid = Helper.UserId;
        }

        private void frmPaymentCollectionAdd_Load(object sender, EventArgs e)
        {
            ucpc1.LoadCollectors();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucpc1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var pcModel = new PaymentCollectionModel()
                {
                    CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                    AccId = uc.accId,
                    GlaId = uc.glaId,
                    SlaId = uc.slaId,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    CreatedBy = uc.userid,
                };

                var pcrepository = Factory.PaymentCollectionRepository();
                return pcrepository.Insert(pcModel);
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
                Helper.MessageBoxSuccess("Payment Collection has been saved.");
                _frmpc.LoadRecords();
                ucpc1.ResetForm();
            }
        }
    }
}
