using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAccountableAdd : Form
    {
        private frmAccountable _frmacc;
        public frmAccountableAdd(frmAccountable frmacc)
        {
            InitializeComponent();
            _frmacc = frmacc;
        }

        private void frmAccountableAdd_Load(object sender, EventArgs e)
        {

        }

        private bool SaveData()
        {
            try
            {
                var uc = ucAccountable1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var accModel = new AccountableModel()
                {
                    AccFormNo = uc.txtformno.Text.Trim(),
                    AccFormDesc = uc.txtformdesc.Text.Trim()

                };

                var accrepository = AccFactory.AccountableFormsRepository();
                return accrepository.Insert(accModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Accountable Form has been saved.");
                _frmacc.LoadRecords();
                ucAccountable1.ResetForm();
            }
        }
    }
}
