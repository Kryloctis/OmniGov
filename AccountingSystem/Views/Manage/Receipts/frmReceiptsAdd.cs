using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceiptsAdd : Form
    {
        private frmReceipts frmaf;
        private int UserId = 0;
        public frmReceiptsAdd(frmReceipts _frmaf)
        {
            InitializeComponent();
            frmaf = _frmaf;
            UserId = Helper.UserId;
        }

        private void frmAccFormsAdd_Load(object sender, EventArgs e)
        {
            ucForms1.LoadForms();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucForms1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                var receiptModel = new ReceiptsModel()
                {
                    AccId = int.Parse(uc.cmbAccountableForms.SelectedValue.ToString()),
                    Rfrom = int.Parse(uc.txtORFrom.Text.Trim()),
                    Rto = int.Parse(uc.txtORTo.Text.Trim()),
                    Rdate = uc.dtpReceivedDate.Value,
                    Quantity = int.Parse(uc.txtQuantity.Text.Trim()),
                    Remarks = uc.txtRemark.Text.Trim(),
                    UserId = UserId
                };

                var receiptRepository = Factory.ReceiptsRepository();

                if (!uc.isTicket)
                {
                    var serialNoFrom = int.Parse(uc.txtORFrom.Text.Trim());
                    var serialNoTo = int.Parse(uc.txtORTo.Text.Trim());

                    if (serialNoFrom > serialNoTo)
                    {
                        Helper.MessageBoxError("Invalid Receipt.");
                        return false;
                    }
                    else
                    {
                        return receiptRepository.Insert(receiptModel);
                    }
                }
                else
                {
                    return receiptRepository.Insert(receiptModel);
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
                Helper.MessageBoxSuccess("Receipt has been saved.");
                frmaf.LoadRecords();
                ucForms1.ResetForm();
            }
        }

     
    }
}
