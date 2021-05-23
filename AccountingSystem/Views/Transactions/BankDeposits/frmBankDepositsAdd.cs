using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsAdd : Form
    {
        private frmBankDeposits _frmbd;
        public frmBankDepositsAdd(frmBankDeposits frmbd)
        {
            InitializeComponent();
            _frmbd = frmbd;
            ucbd1.userid = Helper.UserId;
        }

        private void frmBankDepositsAdd_Load(object sender, EventArgs e)
        {

        }

        private bool SaveData()
        {
            try
            {
                var uc = ucbd1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var bdModel = new BankDepositsModel()
                {
                    bankId = uc.bankId,
                    Reference = uc.txtreference.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    CreatedBy = 2,
                };

                var bdrepository = Factory.BankDepositsRepository();
                return bdrepository.Insert(bdModel);
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
                Helper.MessageBoxSuccess("Bank Deposit has been saved.");
                _frmbd.LoadRecords();
                ucbd1.ResetForm();
            }
        }
    }
}
