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
        public int Gcid = 0;
        public decimal Gcamount = 0;
        public frmBankDepositsAdd(frmBankDeposits frmbd)
        {
            InitializeComponent();
            _frmbd = frmbd;
            ucbd1.userid = Helper.UserId;
        }

        private void frmBankDepositsAdd_Load(object sender, EventArgs e)
        {
            if(Gcid > 0)
            {
                ucbd1.txtamount.Value = Gcamount;
                ucbd1.txtamount.Enabled = false;
            }
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
                    CreatedBy = 2//uc.userid,
                };

                var bdrepository = Factory.BankDepositsRepository();
                if (Gcid > 0)
                {
                    int insertId = bdrepository.Deposits(bdModel);
                    if (insertId > 0)
                    {
                        var gcdRepository = Factory.GeneralCollectionsDepositsRepository();
                        var gcdModel = new GeneralCollectionsDepositsModel()
                        {
                            Bdid = insertId,
                            Gcid = Gcid
                        };
                        if (!gcdRepository.IdExist(Gcid))
                        {
                            return gcdRepository.Insert(gcdModel);
                        }
                        else
                        {
                            Helper.MessageBoxSuccess("General Collection has already been deposited!");
                        }
                    }
                }
                else
                {
                    return bdrepository.Insert(bdModel);
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
                if(Gcid > 0)
                {
                    Helper.MessageBoxSuccess("General Collection Deposits has been saved.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    Helper.MessageBoxSuccess("Bank Deposit has been saved.");
                    _frmbd.LoadRecords();
                    ucbd1.ResetForm();
                }
                
            }
        }
    }
}
