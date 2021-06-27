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
    public partial class frmAccFromEdit : Form
    {
        private frmAccForms frmaf;
        private int UserId = 0;
        public frmAccFromEdit(frmAccForms _frmaf,int id)
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
                uc.cmbforms.SelectedValue = rcdata["accountable_forms_id"];
                uc.txtfrom.Text = rcdata["receiptsfrom"];
                uc.txtto.Text = rcdata["receiptsto"];
                uc.dtpreceived.Value = Convert.ToDateTime(rcdata["received_date"]);
                uc.txtquantity.Text = rcdata["quantity"];
                uc.txtremarks.Text = rcdata["remarks"];
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
                    AccId = Convert.ToInt16(uc.cmbforms.SelectedValue),
                    Rfrom = Convert.ToInt16(uc.txtfrom.Text.Trim()),
                    Rto = Convert.ToInt16(uc.txtto.Text.Trim()),
                    Rdate = uc.dtpreceived.Value,
                    Quantity = Convert.ToInt16(uc.txtquantity.Text.Trim()),
                    Remarks = uc.txtremarks.Text.Trim(),
                    UserId = UserId

                };

                var rcRepository = Factory.ReceiptsRepository();
                return rcRepository.Update(rModel);
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
