using ACC.Domain.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCIAdd : Form
    {
        private frmRCI _frmrci;
        private readonly ucRCI uc;
        public frmRCIAdd(frmRCI frmrci)
        {
            InitializeComponent();
            _frmrci = frmrci;

            uc = ucrci1;
        }

        private void frmRCIAdd_Load(object sender, EventArgs e)
        {
    


            uc.cmbFPP.SelectedIndex = -1;
            uc.cmbFPP.TextChanged += new EventHandler(uc.cmbxFPP_TextChanged);
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

                var rciModel = new RCIModel()
                {
                    DvNo = uc.txtdvno.Text.Trim(),
                    FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    BankId = Convert.ToInt32(uc.cmbbank.SelectedValue),
                    FunctionProgramProjectId = uc.functionId,
                    CheckNo = uc.txtcheckno.Text.Trim(),
                    CheckDate = Convert.ToDateTime(uc.dtcheckdate.Text.Trim()),
                    Payee = uc.txtpayee.Text.Trim(),
                    NaturePayment = uc.txtnature.Text.Trim(),
                    Amount = Convert.ToDecimal(uc.nudNetAmount.Value)
                };

                var rcirepository = Factory.RCIRepository();
                return rcirepository.Insert(rciModel);
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
                Helper.MessageBoxSuccess("RCI has been saved.");
                SaveDVObligations();
                SaveDeductions();

                _frmrci.LoadRecords();
                ucrci1.ResetForm();
            }
        }

        internal void SaveDVObligations()
        {
            try
            {
                string lastRecentRCIId = Factory.RCIRepository().GetRecentRCIId();

                short rcid = (short)(Convert.ToUInt32(lastRecentRCIId));
                string obligationNo = String.Empty;
                
                foreach (DataRow row in uc.dtObligations.Rows)
                {
                    obligationNo = row["obligation_no"].ToString();
                    Factory.RCIRepository().SaveRCIDVObligations(rcid, obligationNo);
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
                string lastRecentRCIId = Factory.RCIRepository().GetRecentRCIId();
                short rcid = (short)(Convert.ToUInt32(lastRecentRCIId));

                string deductionDescription = String.Empty; 
                decimal totalDeduction = 0;


                foreach (DataRow row in uc.dtDeductions.Rows)
                {
                    deductionDescription = row[0].ToString();
                    totalDeduction = Convert.ToDecimal(row[1].ToString());

                    Factory.RCIRepository().SaveRCIDeductions(rcid, deductionDescription, totalDeduction);
                } 
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
