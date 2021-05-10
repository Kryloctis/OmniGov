using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficerAdd : Form
    {
        private ucDisbursingOfficer uc;

        public frmDisbursingOfficerAdd()
        {
            InitializeComponent();
            uc = ucDisbursingOfficer1;
            Helper.LoadFormIcon(this);
        }

        private void frmDisbursingOfficerAdd_Load(object sender, EventArgs e)
        {

        }

        private bool SaveData()
        {
            try
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
                    FirstName = uc.txtFirstName.Text.Trim(),
                    MiddleInitial = uc.txtMidInitial.Text.Trim(),
                    LastName = uc.txtLastName.Text.Trim(),
                    JobTitle = uc.txtJobTitle.Text.Trim()
                };

                return Factory.DisbursingOfficerRepository().Insert(disbursingOfficerModel);
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
                Helper.MessageBoxSuccess("Disbursing office has been saved.");
                uc.ResetForm();
            }
        }
    }
}
