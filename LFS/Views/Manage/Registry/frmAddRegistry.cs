using LFS.Helpers;
using OmniGov.Core.Repositories;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.Registry
{
    public partial class frmAddRegistry : Form
    {
        private readonly ucRegistry uc;
        private readonly frmRegistry frmRegistry;

        public frmAddRegistry(frmRegistry frmRegistry)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmRegistry = frmRegistry;
            uc = ucRegistry1;
        }

        private bool SaveRegistry()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var registryModel = uc.RegistryModel();
            registryModel.CreatedBy = UserHelper.loggedUser.Id;

            return Factory.RegistryRepository().Insert(registryModel);
        }

        private void frmAddRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveRegistry())
                {
                    uc.ResetFields();
                    frmRegistry.LoadRecords();
                    Helper.MessageBoxSuccess("Registry has been saved.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddRegistry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveRegistry())
                    {
                        uc.ResetFields();
                        frmRegistry.LoadRecords();
                        Helper.MessageBoxSuccess("Registry has been saved.");
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}