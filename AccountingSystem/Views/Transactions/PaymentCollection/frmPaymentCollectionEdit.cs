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
    public partial class frmPaymentCollectionEdit : Form
    {
        private frmPaymentCollection _frmpc;
        public frmPaymentCollectionEdit(frmPaymentCollection frmpc,int Id)
        {
            InitializeComponent();
            _frmpc = frmpc;
            ucpc1.Id = Id;
            ucpc1.userid = Helper.UserId;
        }

        private void frmPaymentCollectionEdit_Load(object sender, EventArgs e)
        {
            ucpc1.LoadCollectors();
            LoadSelectedValue();
        }

        private void LoadSelectedValue()
        {
           
            try
            {
                var uc = ucpc1;
                var pcRepository = Factory.PaymentCollectionRepository();
                var pcData = pcRepository.GetRecordByID(uc.Id);
                uc.cmbcollector.SelectedValue = pcData["collecting_officers_id"];
                uc.setSelectedValue(Convert.ToInt16(pcData["accountable_forms_id"]), "accountable");
                uc.setSelectedValue(Convert.ToInt16(pcData["general_ledger_accounts_id"]), "ledger");
                uc.txtpayee.Text = pcData["payee"];
                uc.txtreceipt.Text = pcData["receipt_no"];
                uc.dtdate.Value = Convert.ToDateTime(pcData["payment_date"]);
                uc.txtamount.Value = Convert.ToDecimal(pcData["amount"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                    Id = uc.Id,
                    CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                    AccId = uc.accId,
                    GlaId = uc.glaId,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    UpdatedBy =uc.userid,
                };

                var pcrepository = Factory.PaymentCollectionRepository();
                return pcrepository.Update(pcModel);
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
                Helper.MessageBoxSuccess("Payment Collection has been updated.");
                _frmpc.LoadRecords();
                
            }
        }
    }
}
