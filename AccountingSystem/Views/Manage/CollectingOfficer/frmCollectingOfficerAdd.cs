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


namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficerAdd : Form
    {
        private frmCollectingOfficer _frmCollectingOfficer;
        public frmCollectingOfficerAdd(frmCollectingOfficer frmCollectingOfficer)
        {
            InitializeComponent();
            _frmCollectingOfficer = frmCollectingOfficer;
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucCollectingOfficer1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var model = new CollectingOfficerModel()
                {
                    FirstName = uc.txtFname.Text.Trim(),
                    MiddleInitia = uc.txtMI.Text.Trim(),
                    LastName = uc.txtLname.Text.Trim(),
                    JobTitle = uc.txtJobtitle.Text.Trim()

                };

                var repository = Factory.CollectingOfficerRepository();
                return repository.Insert(model);
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
                Helper.MessageBoxSuccess("Collecting Officer has been saved.");
                _frmCollectingOfficer.LoadRecords();
                ucCollectingOfficer1.ResetForm();
            }
        }

        private void frmCollectingOfficerAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }
    }
}
