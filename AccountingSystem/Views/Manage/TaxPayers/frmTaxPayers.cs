using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class frmTaxPayers : Form
    {
        private ucTaxPayers uc;

        public frmTaxPayers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucTaxPayers1;
        }

        private void frmTaxPayers_Load(object sender, EventArgs e)
        {

        }

        private bool SaveTaxPayers()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveTaxPayers())
            {
                Helper.MessageBoxSuccess("Taxpayer Property has been saved.");
                uc.ResetForm();
            }
        }
    }
}
