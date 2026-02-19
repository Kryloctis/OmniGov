using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Registry
{
    public partial class frmEditRegistry : Form
    {
        private readonly ucRegistry uc;
        private int registryId;
        private readonly frmRegistry frmRegistry;

        public frmEditRegistry(int registryId, frmRegistry frmRegistry)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmRegistry = frmRegistry;
            this.registryId = registryId;
            uc = ucRegistry1;
        }

        private bool UpdateRegistry()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var registryModel = uc.RegistryModel();
            registryModel.Id = registryId;
            registryModel.UpdatedBy = UserHelper.loggedUser.Id;

            return Factory.RegistryRepository().Update(registryModel);
        }

        private void frmEditRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, registryId);
                ActiveControl = uc;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateRegistry())
                {
                    Helper.MessageBoxSuccess("Registry has been updated");
                    frmRegistry.LoadRecords();
                    Close();
                }
                ;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditRegistry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateRegistry())
                    {
                        Helper.MessageBoxSuccess("Registry has been updated");
                        frmRegistry.LoadRecords();
                        Close();
                    }
                    ;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

