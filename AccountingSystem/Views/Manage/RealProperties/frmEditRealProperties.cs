using ACC.Data;
using AccountingSystem.Views.Manage.RealProperties;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmEditRealProperties : Form
    {
        private readonly ucRealProperties uc;
        private readonly int rptId;
        private readonly frmRealProperties frmRealProperties;

        public frmEditRealProperties(frmRealProperties frmRealProperties, int rptId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmRealProperties = frmRealProperties;
            this.rptId = rptId;
            uc = ucRealProperties1;
        }

        private void OnLoad()
        {
            uc.OnLoad(true, rptId);
        }

        private bool UpdateRpt()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormError());
                return false;
            }

            var rptModel = uc.RealPropertiesModel();
            rptModel.TaxpayersModel.Id = rptId;
            rptModel.UpdatedBy = Helper.UserId;

            return AccFactory.RealPropertiesRepository().Update(rptModel);
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateRpt())
                {
                    Helper.MessageBoxSuccess("Real property has been updated.");
                    frmRealProperties.LoadProperties();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}