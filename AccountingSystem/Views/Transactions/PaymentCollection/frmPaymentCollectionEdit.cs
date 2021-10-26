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
        private string receipt = string.Empty;
        public frmPaymentCollectionEdit(frmPaymentCollection frmpc,int Id)
        {
            InitializeComponent();
            _frmpc = frmpc;
            ucpc1.Id = Id;
            ucpc1.userid = Helper.UserId;
           
        }

        private void frmPaymentCollectionEdit_Load(object sender, EventArgs e)
        {
            ucpc1.LoadForms();
            ucpc1.LoadCollectors();
            ucpc1.LoadFunds();
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
                uc.cmbfund.SelectedValue = pcData["funds_id"];
                uc.cmbforms.SelectedValue = pcData["accountable_forms_id"];
                uc.setSelectedValue(Convert.ToInt32(pcData["general_ledger_accounts_id"]), "ledger");
                uc.txtpayee.Text = pcData["payee"];
                uc.txtreceipt.Text = pcData["receipt_no"];
                uc.dtdate.Value = Convert.ToDateTime(pcData["payment_date"]);
                uc.txtamount.Value = Convert.ToDecimal(pcData["amount"]);
                receipt = pcData["receipt_no"];
                uc.accId = Convert.ToInt32(pcData["accountable_forms_id"]);
                uc.receipt = Convert.ToInt32(pcData["receipt_no"]);
                uc.cmbcollector.Enabled = false;                
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
                    CoId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                    FId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    AccId = Convert.ToInt32(uc.cmbforms.SelectedValue),
                    GlaId = uc.glaId,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    UpdatedBy =uc.userid,
                };

                var pcrepository = Factory.PaymentCollectionRepository();
                if (!receipt.Equals(uc.txtreceipt.Text.Trim()))
                {
                    if (pcrepository.Update(pcModel))
                    {
                        var riRepository = Factory.ReceiptsIssuedRepository();
                        var dtri = riRepository.GetRecords(uc.cmbcollector.SelectedValue.ToString(), uc.cmbforms.SelectedValue.ToString());
                        if (dtri.Rows.Count > 0)
                        {
                            int rid = 0;
                            for (int i = 0; i < dtri.Rows.Count; i++)
                            {
                                rid = Convert.ToInt32(dtri.Rows[i]["id"]);
                            }
                            var rcModel = new ReceiptsIssuedModel()
                            {
                                Id = rid,
                                Last_issued = Convert.ToInt32(uc.txtreceipt.Text.Trim())
                            };
                            return riRepository.UpdateCurrentIssued(rcModel);
                        }
                    }                       
                    else return false;
                }
                else if (uc.txtamount.Value <= 0)
                {
                    Helper.MessageBoxSuccess("Empty Amount!");
                    uc.txtamount.Focus();
                    return false;
                }
                else
                {
                    return pcrepository.Update(pcModel);
                }
                
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
