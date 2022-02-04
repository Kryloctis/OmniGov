using System;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDepositsAdd : Form
    {
        private frmBankDeposits _frmBankDeposits;
        private ucBD uc;
        public int Gcid = 0;
        public decimal Gcamount = 0;
        internal string _referenceNumber;

        public frmBankDepositsAdd(frmBankDeposits frmBankDeposits, string referenceNumber)
        {
            InitializeComponent();
            _frmBankDeposits = frmBankDeposits;
            _referenceNumber = referenceNumber;

            uc = ucBankDeposit1;
            uc.userid = Helper.UserId;
        }

        private void frmBankDepositsAdd_Load(object sender, EventArgs e)
        {
            if (Gcid > 0)
            {
                uc.nudAmount.Value = Gcamount;
                uc.nudAmount.Enabled = false;
            }

            uc.txtReferenceNumber.Text = _referenceNumber;
        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                var bdModel = new BankDepositsModel()
                {
                    bankId = Convert.ToInt16(uc.cmbBank.SelectedValue),
                    fundId = Convert.ToInt16(uc.cmbFund.SelectedValue),                     
                    Reference = uc.txtReferenceNumber.Text.Trim(),
                    Date = Convert.ToDateTime(uc.dtDate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.nudAmount.Value),
                    CreatedBy = uc.userid,
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
                    _frmBankDeposits.LoadRecords();
                    ucBankDeposit1.ResetForm();
                }
                
            }
        }
    }
}
