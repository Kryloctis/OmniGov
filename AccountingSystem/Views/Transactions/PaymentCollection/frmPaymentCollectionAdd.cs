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
            ucpc1.LoadForms();
            ucpc1.LoadCollectors();
            ucpc1.LoadFunds();
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
                    CoId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                    FId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    AccId = Convert.ToInt32(uc.cmbforms.SelectedValue),
                    GlaId = uc.glaId,
                    SlaId = uc.slaId,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    CreatedBy = uc.userid,
                };

                var pcrepository = Factory.PaymentCollectionRepository();
                if (pcrepository.ReceiptExist(uc.txtreceipt.Text.Trim(), Convert.ToInt32(uc.cmbforms.SelectedValue)))
                {
                    Helper.MessageBoxSuccess("Receipt already exists!.");
                    uc.txtreceipt.Focus();
                    return false;
                }
                else
                {
                    if (pcrepository.Insert(pcModel))
                    {
                        var riRepository = Factory.ReceiptsIssuedRepository();
                        var rcRepository = Factory.ReceiptsRepository();
                        var dtri = riRepository.GetRecords(uc.cmbcollector.SelectedValue.ToString(), uc.cmbforms.SelectedValue.ToString());
                        if (dtri.Rows.Count > 0)
                        {
                            int rid = 0;
                            for (int i = 0; i < dtri.Rows.Count; i++)
                            {
                                rid = Convert.ToInt32(dtri.Rows[i]["id"]);
                            }
                            var rcModel = new ReceiptsModel()
                            {
                                Id = rid,
                                Last_issued = Convert.ToInt32(uc.txtreceipt.Text.Trim())
                            };
                            return rcRepository.UpdateCurrentIssued(rcModel);
                        }
                    }
                    else
                    {
                        return false;
                    }
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
                Helper.MessageBoxSuccess("Payment Collection has been saved.");
                _frmpc.LoadRecords();
                ucpc1.ResetForm();
            }
        }
    }
}
