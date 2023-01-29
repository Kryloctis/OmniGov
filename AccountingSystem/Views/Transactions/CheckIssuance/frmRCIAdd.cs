using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Vml.Office;
using System;
using System.Data;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIAdd : Form
    {
        private frmRCI _frmRCI;
        private readonly ucRCI uc;

        public frmRCIAdd(frmRCI frmrci)
        {
            InitializeComponent();
            _frmRCI = frmrci;
            uc = ucrci1;
        }

        private void frmRCIAdd_Load(object sender, EventArgs e)
        {
            uc.cmbFPP.SelectedIndex = -1;
            uc.cmbFPP.TextChanged += new EventHandler(uc.cmbxFPP_TextChanged);
        }

        private bool SaveCheque()
        {
            var chequeModel = new ChequesModel()
            {
                BankAccountsId = Convert.ToInt32(uc.cmbBankAccounts.SelectedValue),
                ChequeNo = uc.txtCheckNo.Text,
                ChequeDate = Convert.ToDateTime(uc.dtCheckDate.Value),
                Amount = uc.nudNetAmount.Value,
            };

            return AccFactory.ChequesRepository().Insert(chequeModel);
        }
        private bool SaveRCI()
        {
            var RCIModel = new RCIModel()
            {
                ChequeID = AccFactory.ChequesRepository().GetLastInsertId(),
                FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                FunctionProgramProjectId = uc.functionId,
                DVNo = uc.txtDVNo.Text.Trim(),
                Payee = uc.txtPayee.Text.Trim(),
                NaturePayment = uc.txtNature.Text.Trim(),
            };

            return AccFactory.RCIRepository().Insert(RCIModel);
        }


        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            using (var scope = new TransactionScope())
            {
                if (SaveCheque())
                {
                    SaveRCI();
                    SaveDVObligations();
                    SaveDeductions();
                    scope.Complete();
                    return true;
                }
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("RCI has been saved.");

                _frmRCI.LoadRecords();
                ucrci1.ResetForm();
            }
        }

        internal void SaveDVObligations()
        {
            try
            {
                string lastRecentRCIId = AccFactory.RCIRepository().GetRecentRCIId();

                short rcid = (short)(Convert.ToUInt32(lastRecentRCIId));
                string obligationNo = String.Empty;

                foreach (DataRow row in uc.dtObligations.Rows)
                {
                    obligationNo = row["obligation_no"].ToString();
                    AccFactory.RCIRepository().SaveRCIDVObligations(rcid, obligationNo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SaveDeductions()
        {
            try
            {
                string lastRecentRCIId = AccFactory.RCIRepository().GetRecentRCIId();
                short rcid = (short)(Convert.ToUInt32(lastRecentRCIId));

                string deductionDescription = String.Empty;
                decimal deductionAmount = 0;

                foreach (DataRow row in uc.dtDeductions.Rows)
                {
                    deductionDescription = row[0].ToString();
                    deductionAmount = Convert.ToDecimal(row[1].ToString());
                    uc.totalDeduction += deductionAmount;

                    AccFactory.RCIRepository().SaveRCIDeductions(rcid, deductionDescription, deductionAmount);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}