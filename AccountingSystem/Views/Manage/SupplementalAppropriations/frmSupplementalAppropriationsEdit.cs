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
    public partial class frmSupplementalAppropriationsEdit : Form
    {
        private ucSupplementalAppropriations uc;
        private frmSupplementalAppropriations _frmSupplementalAppropriations;

        public frmSupplementalAppropriationsEdit(frmSupplementalAppropriations frmSupplementalAppropriations)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmSupplementalAppropriations = frmSupplementalAppropriations;
            uc = ucSupplementalAppropriations1;
        }

        private void LoadSelected()
        {
            try
            {
                int supplementalAppropriationId = uc.supplementalAppropriationId;

                var supplementalAppropriationsRepo = Factory.SupplementalAppropriationsRepository().GetRecordByID(supplementalAppropriationId);

                uc.dtDateEntry.Value = Convert.ToDateTime(supplementalAppropriationsRepo["date_entry"]);
                uc.nudAmount.Value = Convert.ToDecimal(supplementalAppropriationsRepo["amount"]);
                uc.txtRemarks.Text = supplementalAppropriationsRepo["remarks"].ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

                var supplemmentalAppropriationsModel = new SupplementalAppropriationsModel()
                {
                    Id = uc.supplementalAppropriationId,
                    date_entry = uc.dtDateEntry.Value,
                    amount = uc.nudAmount.Value,
                    remarks = uc.txtRemarks.Text.Trim()
                };

                return Factory.SupplementalAppropriationsRepository().Update(supplemmentalAppropriationsModel);
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
                Helper.MessageBoxSuccess("Supplemental Appropriation has been updated.");
                _frmSupplementalAppropriations.LoadSupplementalApproprations();
                _frmSupplementalAppropriations._frmBudgetAppropriations.LoadBudgetAppropriationRecords();
                Close();
            }
        }

        private void frmSupplementalAppropriationsEdit_Load(object sender, EventArgs e)
        {
            LoadSelected();
        }
    }
}
