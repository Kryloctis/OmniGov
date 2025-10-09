using ACC.Data;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.TaxPayers
{
    public partial class frmEditTaxpayers : Form
    {
        internal readonly ucTaxPayers uc;
        private readonly int taxpayerId;
        private readonly frmTaxpayers frmTaxpayers;

        public frmEditTaxpayers(int taxpayerId, frmTaxpayers frmTaxpayers)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.taxpayerId = taxpayerId;
            this.frmTaxpayers = frmTaxpayers;
            uc = ucTaxPayers1;
        }

        private bool UpdateTaxpayer()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var taxpayersModel = uc.TaxpayersModel();
            taxpayersModel.Id = taxpayerId;
            taxpayersModel.UpdatedBy = UserHelper.loggedUser.Id;

            return AccFactory.TaxpayersRepository().Update(taxpayersModel);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateTaxpayer())
                {
                    Helper.MessageBoxSuccess("Taxpayer has been updated.");
                    frmTaxpayers.LoadTaxpayers();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditTaxpayers_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, taxpayerId);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditTaxpayers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateTaxpayer())
                    {
                        Helper.MessageBoxSuccess("Taxpayer has been updated.");
                        frmTaxpayers.LoadTaxpayers();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}