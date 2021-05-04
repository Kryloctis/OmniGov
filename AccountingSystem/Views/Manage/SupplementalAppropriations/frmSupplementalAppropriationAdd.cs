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

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class frmSupplementalAppropriationAdd : Form
    {
        internal ucSupplementalAppropriations uc;

        public frmSupplementalAppropriationAdd()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucSupplementalAppropriations1;
        }

        private bool SaveData() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var supplementalAppropriationsModel = new SupplementalAppropriationsModel()
                {
                    BudgetAppropriationID = uc.budgetAppropriationId,
                    date_entry = uc.dtDateEntry.Value,
                    amount = uc.nudAmount.Value,
                    remarks = uc.txtRemarks.Text.Trim(),
                };

                return Factory.SupplementalAppropriationsRepository().Insert(supplementalAppropriationsModel);
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
                Helper.MessageBoxSuccess("Supplemental Appropriation has been saved.");
                uc.ResetForm();
            }
        }
    }
}
