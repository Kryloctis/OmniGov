using ACC.Data;
using ACC.Domain.Models;
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
    public partial class frmAddRegistry : Form
    {
        private readonly ucRegistry uc;
        private readonly frmRegistry frmRegistry;

        public frmAddRegistry(frmRegistry frmRegistry)
        {
            InitializeComponent();
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
            registryModel.CreatedBy = Helper.UserId;

            return AccFactory.RegistryRepository().Insert(registryModel);
        }

        private void frmAddRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
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
                    frmRegistry.LoadRegistryList();
                    Helper.MessageBoxSuccess("Registry has been saved.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}