using ACC.Data;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.TaxPayers
{
    public partial class frmAddTaxpayers : Form
    {
        private readonly ucTaxPayers uc;
        private frmTaxpayers frmTaxpayers;

        public frmAddTaxpayers(frmTaxpayers frmTaxpayers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmTaxpayers = frmTaxpayers;
            uc = ucTaxPayers1;
        }

        private bool SaveTaxpayer()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var taxpayersModel = uc.TaxpayersModel();
            taxpayersModel.CreatedBy = Helper.userId;

            return AccFactory.TaxpayersRepository().Insert(taxpayersModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveTaxpayer())
                {
                    Helper.MessageBoxSuccess("Taxpayer has been saved.");
                    frmTaxpayers.LoadTaxpayers();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddTaxpayers_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddTaxpayers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveTaxpayer())
                    {
                        Helper.MessageBoxSuccess("Taxpayer has been saved.");
                        frmTaxpayers.LoadTaxpayers();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}