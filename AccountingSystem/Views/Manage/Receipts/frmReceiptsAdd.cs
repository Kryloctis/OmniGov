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
                var rModel = new ReceiptsModel()
                {
                    AccId = int.Parse(uc.cmbforms.SelectedValue.ToString()),
                    Rfrom = int.Parse(uc.txtfrom.Text.Trim()),
                    Rto = int.Parse(uc.txtto.Text.Trim()),
                    Rdate = uc.dtpreceived.Value,
                    Quantity = int.Parse(uc.txtquantity.Text.Trim()),
                    Remarks = uc.txtremarks.Text.Trim(),
                    UserId = UserId

                };

                var rcRepository = Factory.ReceiptsRepository();
                /* if (rcRepository.ReceiptExist(int.Parse(uc.cmbforms.SelectedValue), int.Parse(uc.txtfrom.Text.Trim()), int.Parse(uc.txtto.Text.Trim())))
                 {
                     Helper.MessageBoxError("Receipt already exists!");
                     uc.cmbforms.Focus();
                     return false;
                 }
                 else */
                if (!uc.istickets)
                {
                    if (int.Parse(uc.txtfrom.Text.Trim()) > int.Parse(uc.txtto.Text.Trim()))
                    {
                        Helper.MessageBoxError("Invalid Receipt!");
                        return false;
                    }
                    else
                    {
                        return rcRepository.Insert(rModel);
                    }
                }
                else
                {
                    return rcRepository.Insert(rModel);
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
