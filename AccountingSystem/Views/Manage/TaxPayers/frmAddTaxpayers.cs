using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmAddTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;

        public frmAddTaxpayers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
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
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}