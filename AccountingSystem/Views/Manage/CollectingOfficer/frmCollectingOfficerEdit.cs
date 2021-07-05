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
    public partial class frmCollectingOfficerEdit : Form
    {
        private frmCollectingOfficer _frmCollectingOfficer;
        public frmCollectingOfficerEdit(frmCollectingOfficer frmCollectingOfficer, int OfficerId)
        {
            InitializeComponent();
            _frmCollectingOfficer = frmCollectingOfficer;
            ucCollectingOfficer1.OfficerId = OfficerId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucCollectingOfficer1;
                var repository = Factory.CollectingOfficerRepository();
                var data = repository.GetRecordByID(uc.OfficerId);
                uc.txtFname.Text = data["first_name"];
                uc.txtMI.Text = data["mid_initial"];
                uc.txtLname.Text = data["last_name"];
                uc.txtJobtitle.Text = data["job_title"];
                uc.UserId = data["users_id"] == string.Empty ? 0 : Convert.ToInt16(data["users_id"]);                
                uc.LoadLink(uc.UserId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                // proceed to update
                var collectingmodel = new CollectingOfficerModel()
                {
                    Id = uc.OfficerId,
                    FirstName = uc.txtFname.Text.Trim(),
                    MiddleInitial = uc.txtMI.Text.Trim(),
                    LastName = uc.txtLname.Text.Trim(),
                    JobTitle = uc.txtJobtitle.Text.Trim(),
                    UserId = uc.UserId
                };

                var collectingrepository = Factory.CollectingOfficerRepository();
                return collectingrepository.Update(collectingmodel);


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
            }
        }

        private void frmCollectingOfficerEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }
    }
}
