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

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssuedAdd : Form
    {
        private frmReceiptsIssued frmr;
        private int Rid = 0;
        public frmReceiptsIssuedAdd(frmReceiptsIssued _frmr,int rid)
        {
            InitializeComponent();
            frmr = _frmr;
            Rid = rid;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
           
            if(Rid > 0)
            {
                ucReceipts1.LoadCollectors(Rid);
                ucReceipts1.cmbreceipt.SelectedValue = Rid;
                ucReceipts1.cmbreceipt.Enabled = false;
            }
            else
            {
                ucReceipts1.LoadCollectors();
            }
        }


        private bool SaveData()
        {
            try
            {
                var uc = ucReceipts1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var riModel = new ReceiptsIssuedModel()
                {
                   CoId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                   RId = Convert.ToInt32(uc.cmbreceipt.SelectedValue),
                   Issued = uc.dtpissued.Value,
                   IssuedFrom = Convert.ToInt32(uc.txtfrom.Text.Trim()),
                   IssuedTo = Convert.ToInt32(uc.txtto.Text.Trim()),
                   Quantity = Convert.ToInt32(uc.txtquantity.Text.Trim())
                   
                };

                var riRepository = Factory.ReceiptsIssuedRepository();
                if (!uc.istickets)
                {
                    if (riRepository.IssuedExist(riModel))
                    {
                        Helper.MessageBoxError("Receipt already issued!");
                        uc.cmbreceipt.Focus();
                        return false;
                    }
                    else if (Convert.ToInt32(uc.txtfrom.Text.Trim()) > Convert.ToInt32(uc.txtto.Text.Trim()))
                    {
                        Helper.MessageBoxError("Invalid Receipt!");
                        return false;
                    }
                    else if (int.Parse(uc.txtquantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }
                    else riRepository.Insert(riModel);
                }
                else
                {
                    if (int.Parse(uc.txtquantity.Text.Trim()) <= 0)
                    {
                        Helper.MessageBoxError("Quantity Empty!");
                        return false;
                    }
                    else return riRepository.Insert(riModel);
                }
               

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been saved.");
                frmr.LoadRecords();
                ucReceipts1.ResetForm();
                if(Rid > 0)
                {
                    this.Close();
                }
            }
        }
    }
}
