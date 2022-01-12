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
    public partial class frmReceiptsEdit : Form
    {
        private frmReceipts frmaf;
        private int UserId = 0;
        public frmReceiptsEdit(frmReceipts _frmaf,int id)
        {
            InitializeComponent();
            frmaf = _frmaf;
            ucForms1.Id = id;
            UserId = Helper.UserId;
        }

        private void frmAccFromEdit_Load(object sender, EventArgs e)
        {
            ucForms1.LoadForms();
            LoadSelectedValue();
            
        }

        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucForms1;
                var rcRepository = Factory.ReceiptsRepository();
                var rcdata = rcRepository.GetRecordByID(uc.Id);
                uc.cmbAccountableForms.SelectedValue = rcdata["accountable_forms_id"];
                uc.txtORFrom.Text = rcdata["receiptsfrom"];
                uc.txtORTo.Text = rcdata["receiptsto"];
                uc.dtpReceivedDate.Value = Convert.ToDateTime(rcdata["received_date"]);
                uc.txtQuantity.Text = rcdata["quantity"];
                uc.txtRemark.Text = rcdata["remarks"];
                if (rcRepository.ReceiptsIssued(uc.Id))
                {
                    uc.cmbAccountableForms.Enabled = false;
                    uc.txtORFrom.Enabled = false;
                    uc.txtORTo.Enabled = false;
                }
                uc.cmbAccountableForms.Enabled = false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
                    Id = uc.Id,
                    AccId = int.Parse(uc.cmbAccountableForms.SelectedValue.ToString()),
                    Rfrom = int.Parse(uc.txtORFrom.Text.Trim()),
                    Rto = int.Parse(uc.txtORTo.Text.Trim()),
                    Rdate = uc.dtpReceivedDate.Value,
                    Quantity = int.Parse(uc.txtQuantity.Text.Trim()),
                    Remarks = uc.txtRemark.Text.Trim(),
                    UserId = UserId

                };

                var rcRepository = Factory.ReceiptsRepository();
                if (!uc.isTicket)
                {
                    if (int.Parse(uc.txtORFrom.Text.Trim()) > int.Parse(uc.txtORTo.Text.Trim()))
                    {
                        Helper.MessageBoxError("Invalid Receipt!");
                        return false;
                    }
                    else return rcRepository.Update(rModel);
                }
                else return rcRepository.Update(rModel);

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
                Helper.MessageBoxSuccess("Receipt has been updated.");
                frmaf.LoadRecords();
            }
        }
    }
}
