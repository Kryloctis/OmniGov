using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Registry
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
            registryModel.UpdatedBy = Helper.UserId;

            return AccFactory.RegistryRepository().Update(registryModel);
        }

        private void frmEditRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, registryId);
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
                    frmRegistry.LoadRegistryList();
                    Close();
                };
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}