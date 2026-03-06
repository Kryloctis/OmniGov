using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Registry

{
    public partial class frmAddRegistry : Form

    {
        private readonly frmRegistry frmRegistry;
        private readonly ucRegistry uc;

        public frmAddRegistry(frmRegistry frmRegistry)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            this.frmRegistry = frmRegistry;

            uc = ucRegistry1;
        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            if (SaveRegistry())
            {
                uc.ResetFields();
                frmRegistry.LoadRecords();
                Helper.MessageBoxSuccess("Registry has been saved.");
            }
        }

        private void frmAddRegistry_KeyDown(object sender, KeyEventArgs e)

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

        private void frmAddRegistry_Load(object sender, EventArgs e)

        {
            uc.OnLoad(false, null);
            ActiveControl = uc;
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
    }
}