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

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficerAdd : Form
    {
        private ucDisbursingOfficer uc;
        private frmDisbursingOfficer frmDisbursingOfficer;

        public frmDisbursingOfficerAdd(frmDisbursingOfficer _frmDisbursingOfficer)
        {
            InitializeComponent();
            frmDisbursingOfficer = _frmDisbursingOfficer;
            uc = ucDisbursingOfficer1;
            Helper.LoadFormIcon(this);
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var disbursingOfficerModel = new DisbursingOfficerModel()
            {
                Prefix = uc.txtPrefix.Text.Trim(),
                FirstName = uc.txtFirstName.Text.Trim(),
                MiddleInitial = uc.txtMidInitial.Text.Trim(),
                LastName = uc.txtLastName.Text.Trim(),
                Suffix = uc.txtSuffix.Text.Trim(),
                JobTitle = uc.txtJobTitle.Text.Trim(),
                UserId = uc.UserId
            };

            return AccFactory.DisbursingOfficerRepository().Insert(disbursingOfficerModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Disbursing office has been saved.");
                    frmDisbursingOfficer.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}