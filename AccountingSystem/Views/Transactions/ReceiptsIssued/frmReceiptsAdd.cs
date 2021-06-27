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
    public partial class frmReceiptsAdd : Form
    {
        private frmReceipts frmr;
        private int Rid = 0;
        public frmReceiptsAdd(frmReceipts _frmr,int rid)
        {
            InitializeComponent();
            frmr = _frmr;
            Rid = rid;
        }

        private void frmReceiptsAdd_Load(object sender, EventArgs e)
        {
            ucReceipts1.LoadCollectors();
            ucReceipts1.LoadReceipts();
            if(Rid > 0)
            {
                ucReceipts1.cmbreceipt.SelectedValue = Rid;
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
                   CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                   RId = Convert.ToInt16(uc.cmbreceipt.SelectedValue),
                   Issued = uc.dtpissued.Value
                };

                var riRepository = Factory.ReceiptsIssuedRepository();
                if (riRepository.IssuedExist(Convert.ToInt16(uc.cmbcollector.SelectedValue), Convert.ToInt16(uc.cmbreceipt.SelectedValue))){
                    Helper.MessageBoxError("Receipt already issued!");
                    uc.cmbreceipt.Focus();
                    return false;
                }
                else
                {
                    return riRepository.Insert(riModel);
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
