using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsAdd : Form
    {
        public frmBudgetAppropriationsAdd()
        {
            InitializeComponent();
        }

        private void LoadComboboxes()
        {
            var uc = ucBudgetAppropriations1;
            uc.LoadFPPRecords();
            uc.LoadOtherFPPRecords();
            uc.LoadAllotmentClassRecords();
            uc.LoadGeneralLedgerAccounts();
            uc.ResetForm();
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                return true;
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uc = ucBudgetAppropriations1;

            if (SaveData()) 
            {
                uc.ResetForm();
            }
        }

        private void frmBudgetAppropriationsAdd_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }
    }
}
