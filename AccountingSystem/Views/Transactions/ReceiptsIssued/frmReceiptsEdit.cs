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
    public partial class frmReceiptsEdit : Form
    {
        private frmReceipts frmr;

        public frmReceiptsEdit(frmReceipts _frmr,int id)
        {
            InitializeComponent();
            frmr = _frmr;
            ucReceipts1.Id = id;
        }

        private void frmReceiptsEdit_Load(object sender, EventArgs e)
        {
            ucReceipts1.LoadCollectors();
            ucReceipts1.LoadReceipts();
            LoadSelectedValue();
        }

        internal void LoadSelectedValue()
        {
            try
            {
                var uc = ucReceipts1;
                var riRepository = Factory.ReceiptsIssuedRepository();
                var riData = riRepository.GetRecordByID(uc.Id);
                uc.cmbcollector.SelectedValue = riData["collecting_officers_id"];
                uc.cmbreceipt.SelectedValue = riData["receipts_id"];
                uc.dtpissued.Value = Convert.ToDateTime(riData["date_issued"]);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                    Id = uc.Id,
                    CoId = Convert.ToInt16(uc.cmbcollector.SelectedValue),
                    RId = Convert.ToInt16(uc.cmbreceipt.SelectedValue),
                    Issued = uc.dtpissued.Value
                };

                var riRepository = Factory.ReceiptsIssuedRepository();
                return riRepository.Update(riModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Receipt Issued has been updated.");
                frmr.LoadRecords();
            }
        }
    }
}
